// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportScriptHandlerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CDP4Reporting.ReportScript;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class ReportScriptHandlerTestFixture
    {
        private Mock<IXtraReportHandler<object, object>> xtraReportHandler;
        private Mock<ICodeCompiler> codeCompiler;
        private string okDataSource;
        private string wrongDataSource;
        private Mock<Action<string>> onErrorAction;
        private Mock<Action<string>> onOutputAction;

        [SetUp]
        public void SetUp()
        {
            this.xtraReportHandler = new Mock<IXtraReportHandler<object, object>>();
            this.codeCompiler = new Mock<ICodeCompiler>();

            this.onErrorAction = new Mock<Action<string>>();
            this.onOutputAction = new Mock<Action<string>>();

            this.wrongDataSource = @"
using System;
public class MyDataSource : OptionDependentDataCollectorr
{
}
";

            this.okDataSource = @"
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using CDP4Reporting.DataCollection;
using CDP4Reporting.Parameters;
using CDP4Reporting.Utilities;

using CDP4Common.EngineeringModelData;
using CDP4Common.SiteDirectoryData;
using CDP4Common.Helpers;

/// <summary>
/// Class that defines in the actual data source
/// Exactly one class that implements IDataCollector should be available in the code editor.
/// </summary>
public class MyDataSource : OptionDependentDataCollector
{
   /// <summary>
   /// A must override method that returns the actual data object.
   /// A data object could be anything, except a dynamic/ExpandoObject type.
   /// </summary>
   /// <returns>
   /// The data as an object.
   /// </returns>
   public override object CreateDataObject()
   {
      var list = new List<obj>();
      var obj1 = new obj();
      obj1.value1 = ""row1"";
            obj1.value2 = ""value1"";

            var obj2 = new obj();
            obj2.value1 = ""row2"";
            obj2.value2 = ""value2"";

            var obj3 = new obj();
            obj3.value1 = ""row3"";
            obj3.value2 = ""value3"";

            list.Add(obj1);
            list.Add(obj2);
            list.Add(obj2);
      
            return list;
        }
   
        public class obj
        {
            public string value1 {get;set;}
      
            public string value2 {get;set;}
        }
    }";
        }

        [Test]
        public void VerifyThatConstructorWorks()
        {
            Assert.DoesNotThrow(() => new ReportScriptHandler<object, object>(
                this.xtraReportHandler.Object, 
                this.codeCompiler.Object,
                x => { },
                x => { }));
        }
        
        [Test]
        public void VerifyThatGetReportWorks()
        {
            var reportScriptHandler = new ReportScriptHandler<object, object>(
                this.xtraReportHandler.Object, 
                this.codeCompiler.Object,
                x => { },
                x => { });

            var reportArchive = reportScriptHandler.GetReportZipArchive("Data/report.rep4");

            Assert.That(reportArchive.DataSourceCode.Length, Is.GreaterThan(0));
            Assert.That(reportArchive.ReportDefinition.Length, Is.GreaterThan(0));
        }

        [Test]
        public void VerifyThatGetCompileAssemblyWorks()
        {
            var reportScriptHandler = new ReportScriptHandler<object, object>(
                this.xtraReportHandler.Object, 
                this.codeCompiler.Object,
                this.onErrorAction.Object,
                this.onOutputAction.Object);


            Assert.DoesNotThrow(() => reportScriptHandler.CompileAssembly(this.okDataSource));
            Assert.That(reportScriptHandler.CompileResults, Is.Null);
            this.codeCompiler.Verify(x => x.Compile(It.IsAny<string>(), It.IsAny<string[]>()), Times.Once);
            this.onErrorAction.Verify(x => x.Invoke(string.Empty), Times.Exactly(2));
            this.onOutputAction.Verify(x => x.Invoke(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void VerifyThatGetCompileAssemblyFails()
        {
            var reportScriptHandler = new ReportScriptHandler<object, object>(
                this.xtraReportHandler.Object, 
                this.codeCompiler.Object,
                this.onErrorAction.Object,
                this.onOutputAction.Object);

            var failedResult = "Failed";

            this.codeCompiler.Setup(x => x.Compile(It.IsAny<string>(), It.IsAny<string[]>())).Returns(new CompilerResults(Assembly.GetExecutingAssembly(), new [] {failedResult}.ToList()));

            Assert.DoesNotThrow(() => reportScriptHandler.CompileAssembly(this.wrongDataSource));
            Assert.That(reportScriptHandler.CompileResults, Is.Null);
            this.onErrorAction.Verify(x => x.Invoke(string.Empty), Times.Once);
            this.onErrorAction.Verify(x => x.Invoke(It.Is<string>(s => s.Contains(failedResult))), Times.Once);
        }

        [Test]
        public void VerifyThatGetCompileAssemblyFailsOnEmptyDataSource()
        {
            var reportScriptHandler = new ReportScriptHandler<object, object>(
                this.xtraReportHandler.Object, 
                this.codeCompiler.Object,
                this.onErrorAction.Object,
                this.onOutputAction.Object);

            Assert.DoesNotThrow(() => reportScriptHandler.CompileAssembly(string.Empty));
            this.onErrorAction.Verify(x => x.Invoke(string.Empty), Times.Once);
            this.onOutputAction.Verify(x => x.Invoke(It.IsAny<string>()), Times.Once);
        }
    }
}
