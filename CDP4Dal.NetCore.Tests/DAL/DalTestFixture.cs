// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Dal.Tests.DAL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Dal.Composition;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;
    using CDP4Dal.DAL;
    using NUnit.Framework;

    [TestFixture]
    public class DalTestFixture
    {
        private Credentials credentials;
        private string someURI = "http://someURI";
        private string filePath;

        [SetUp]
        public void SetUp()
        {
            this.filePath = Path.Combine(TestContext.CurrentContext.TestDirectory, "DAL", "files", "SiteDirectory.json");
            this.credentials = new Credentials("John", "Doe", new Uri(this.someURI));
        }

        [Test]
        public void Verify_that_the_credentials_are_set_to_Null_when_closed()
        {
            var dal = new TestDal(this.credentials);            
            dal.CloseSession();
            Assert.IsNull(dal.Credentials);
        }

        [Test]
        public void Verify_That_Clean_Uri_Final_Slash_Removes_Last_Slash_From_Uri()
        {
            var dal = new TestDal(this.credentials);

            var uriWithTrailingSlash = this.someURI + "/";

            Assert.AreEqual(this.someURI, dal.CleanSlashes(this.someURI));
            Assert.AreEqual(this.someURI, dal.CleanSlashes(uriWithTrailingSlash));
            Assert.AreEqual(string.Empty, dal.CleanSlashes(string.Empty));
            Assert.AreEqual(string.Empty, dal.CleanSlashes(null));
        }

        [Test]
        public void Verify_That_SetIterationId_Works_as_expected()
        {
            var dal = new TestDal(this.credentials);
            var uri = new Uri(@"http://localhost.com/EngineeringModel/694508eb-2730-488c-9405-6ca561df68dd/iteration/44647ff6-ffe3-44ff-9ed9-3256e2a97f9d?extent=deep&includeReferenceData=true&includeAllContainers=true");

            var model = new EngineeringModel();
            var iteration = new Iteration();
            var elementDefinition = new ElementDefinition();
            var parameter = new Parameter();
            var list = new List<Thing>
            {
                model,
                iteration,
                elementDefinition,
                parameter
            };

            if (dal.TryExtractIterationIdfromUri(uri, out var iterationId))
            {
                dal.SetIterationContainer(list, iterationId);
            }

            Assert.IsNull(model.IterationContainerId);
            Assert.IsNull(iteration.IterationContainerId);
            Assert.AreEqual("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", elementDefinition.IterationContainerId.Value.ToString());
            Assert.AreEqual("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", parameter.IterationContainerId.Value.ToString());
        }

        [Test]
        public void Verify_that_when_fault_uri_is_provided_TryExtractIterationIdfromUri_returns_false()
        {
            var faultyUri = new Uri("http://some/faulty/uri/1234");
            var dal = new TestDal(this.credentials);

            Assert.That(dal.TryExtractIterationIdfromUri(faultyUri, out var iterationId), Is.False);
            Assert.That(iterationId, Is.EqualTo(Guid.Empty));
        }

        [Test]
        public void Verify_that_when_SetIterationContainer_is_called_with_empty_guid_exception_is_thrown()
        {
            var dtos = new List<Thing>();

            var dal = new TestDal(this.credentials);

            Assert.Throws<ArgumentException>(() => dal.SetIterationContainer(dtos, Guid.Empty));
        }

        [Test]
        public void Verify_That_QueryRequestContext_Returns_Expected_Result()
        {
            var testdal = new TestDal(this.credentials);
            
            var elementDefinitionUri = new Uri("http://www.rheagroup.com/EngineeringModel/00B1FD7E-BE0F-4512-A406-02FCBD63E06A/iteration/0111A76D-346D-4055-A78D-B8215B993DA1/element/E9E8E386-B8BB-44F1-80B9-2C30761EE688");
            var elementDefinitionContext = testdal.QueryRequestContext(elementDefinitionUri);
            Assert.AreEqual("/EngineeringModel/00B1FD7E-BE0F-4512-A406-02FCBD63E06A/iteration/0111A76D-346D-4055-A78D-B8215B993DA1", elementDefinitionContext);
        }

        [Test]
        public void Verify_that_for_a_decorated_dal_the_version_is_set()
        {
            var dal = new DecoratedDal();
            Assert.That(dal.DalVersion,  Is.EqualTo(new Version(1,1,0)));
        }

        [Test]
        public void Verify_that_OperationContainerFileVerification_throws_an_exception_when_data_is_incomplete()
        {
            var siteDirectory = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var engineeringModelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup(Guid.NewGuid(), null, null);
            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup(Guid.NewGuid(), null, null);

            siteDirectory.Model.Add(engineeringModelSetup);
            engineeringModelSetup.IterationSetup.Add(iterationSetup);

            var engineeringModel = new CDP4Common.EngineeringModelData.EngineeringModel(Guid.NewGuid(), null, null);
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;

            var iteration = new CDP4Common.EngineeringModelData.Iteration(Guid.NewGuid(), null, null);
            iteration.IterationSetup = iterationSetup;

            var commonFileStore = new CDP4Common.EngineeringModelData.CommonFileStore(Guid.NewGuid(), null, null);
            engineeringModel.Iteration.Add(iteration);
            engineeringModel.CommonFileStore.Add(commonFileStore);
            
            var context = TransactionContextResolver.ResolveContext(commonFileStore);
            var transaction = new ThingTransaction(context);

            var commonFileStoreClone = commonFileStore.Clone(false);

            var file = new CDP4Common.EngineeringModelData.File(Guid.NewGuid(), null, null);
            var fileRevision = new CDP4Common.EngineeringModelData.FileRevision(Guid.NewGuid(), null, null);
            
            transaction.Create(file, commonFileStoreClone);
            transaction.Create(fileRevision, file);

            var operationContainer = transaction.FinalizeTransaction();

            var files = new List<string> {this.filePath};

            var testDal = new TestDal(this.credentials);
            Assert.Throws<InvalidOperationContainerException>(() => testDal.TestOperationContainerFileVerification(operationContainer, files));
        }

        [Test]
        public void Verify_that_OperationContainerFileVerification_throws_no_exception_when_data_is_complete()
        {
            var siteDirectory = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var engineeringModelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup(Guid.NewGuid(), null, null);
            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup(Guid.NewGuid(), null, null);

            siteDirectory.Model.Add(engineeringModelSetup);
            engineeringModelSetup.IterationSetup.Add(iterationSetup);

            var engineeringModel = new CDP4Common.EngineeringModelData.EngineeringModel(Guid.NewGuid(), null, null);
            engineeringModel.EngineeringModelSetup = engineeringModelSetup;

            var iteration = new CDP4Common.EngineeringModelData.Iteration(Guid.NewGuid(), null, null);
            iteration.IterationSetup = iterationSetup;

            var commonFileStore = new CDP4Common.EngineeringModelData.CommonFileStore(Guid.NewGuid(), null, null);
            engineeringModel.Iteration.Add(iteration);
            engineeringModel.CommonFileStore.Add(commonFileStore);
            
            var context = TransactionContextResolver.ResolveContext(commonFileStore);
            var transaction = new ThingTransaction(context);

            var commonFileStoreClone = commonFileStore.Clone(false);

            var file = new CDP4Common.EngineeringModelData.File(Guid.NewGuid(), null, null);
            var fileRevision = new CDP4Common.EngineeringModelData.FileRevision(Guid.NewGuid(), null, null);
            fileRevision.ContentHash = "1B686ADFA2CAE870A96E5885087337C032781BE6";
            
            transaction.Create(file, commonFileStoreClone);
            transaction.Create(fileRevision, file);

            var operationContainer = transaction.FinalizeTransaction();

            var files = new List<string> {this.filePath};

            var testDal = new TestDal(this.credentials);

            Assert.DoesNotThrow(() => testDal.TestOperationContainerFileVerification(operationContainer, files));
        }
    }

    [CDPVersion("1.1.0")]
    internal class TestDal : Dal
    {
        public override bool IsReadOnly { get { return false; } }
        
        public TestDal(Credentials credentials)
            : base()
        {
            this.Credentials = credentials;
        }

        public string CleanSlashes(string uri)
        {
            return base.CleanUriFinalSlash(uri);
        }

        internal void TestOperationContainerFileVerification(OperationContainer operationContainer, IEnumerable<string> files)
        {
            this.OperationContainerFileVerification(operationContainer, files);
        }

        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> ReadByRoute(string route, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Thing> Create<T>(T thing)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Thing> Update<T>(T thing)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<Thing> Delete<T>(T thing)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override void Close()
        {
            throw new System.NotImplementedException();
        }
        
        public override bool IsValidUri(string uri)
        {
            throw new System.NotImplementedException();
        }
    }

    [DalExport("decorateddal","a decorated dal","1.1.0",DalType.Web)]
    internal class DecoratedDal : Dal
    {
        public override bool IsReadOnly { get; }
        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> ReadByRoute(string route, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Create<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Update<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Delete<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidUri(string uri)
        {
            throw new NotImplementedException();
        }
    }
}