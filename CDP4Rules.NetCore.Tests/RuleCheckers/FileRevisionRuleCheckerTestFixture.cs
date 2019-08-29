// <copyright file="FileRevisionRuleCheckerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="FileRevisionRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class FileRevisionRuleCheckerTestFixture
    {
        private FileRevisionRuleChecker fileRevisionRuleChecker;

        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        private EngineeringModelSetup engineeringModelSetup;

        private EngineeringModel engineeringModel;
        
        private CommonFileStore commonFileStore;

        private File file;

        private FileRevision fileRevision;

        [SetUp]
        public void SetUp()
        {
            this.fileRevisionRuleChecker = new FileRevisionRuleChecker();

            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary();
            this.engineeringModelSetup = new EngineeringModelSetup();
            this.engineeringModel = new EngineeringModel();
            this.commonFileStore = new CommonFileStore();
            this.file = new File();
            this.fileRevision = new FileRevision();

            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);
            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.engineeringModel.CommonFileStore.Add(commonFileStore);
            this.commonFileStore.File.Add(this.file);
            this.file.FileRevision.Add(this.fileRevision);
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedFileTypeIsInChainOfRlds_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.fileRevisionRuleChecker.CheckWhetherReferencedFileTypeIsInChainOfRlds(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherReferencedFileTypeIsInChainOfRlds_is_called_with_not_FileRevision_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.fileRevisionRuleChecker.CheckWhetherReferencedFileTypeIsInChainOfRlds(alias));
        }

        [Test]
        public void Verify_that_when_FileType_is_not_in_chain_of_Rdls_result_is_returned()
        {
            var fileType = new FileType();
            this.fileRevision.FileType.Add(fileType);

            var result = this.fileRevisionRuleChecker.CheckWhetherReferencedFileTypeIsInChainOfRlds(this.fileRevision).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0210"));
            Assert.That(result.Description, Is.EqualTo("The referenced FileType of the FileRevision is not in the chain of Reference Data Libraries"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.fileRevision));
        }

        [Test]
        public void Verify_that_when_FileType_is_in_chain_of_Rdls_no_result_is_returned()
        {
            var fileType = new FileType();
            this.modelReferenceDataLibrary.FileType.Add(fileType);

            this.fileRevision.FileType.Add(fileType);

            var results = this.fileRevisionRuleChecker.CheckWhetherReferencedFileTypeIsInChainOfRlds(this.fileRevision);

            Assert.That(results, Is.Empty);
        }
    }
}