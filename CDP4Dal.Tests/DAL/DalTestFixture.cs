﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DalTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.DAL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Helpers;

    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Tasks;

    using NUnit.Framework;

    using Thing = CDP4Common.DTO.Thing;

    [TestFixture]
    public class DalTestFixture
    {
        private Credentials credentials;
        private string someURI = "http://someURI";
        private string somePath = "SiteDirectory";
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
            Assert.That(dal.Credentials, Is.Null);
        }

        [Test]
        public void Verify_That_Clean_Uri_Final_Slash_Removes_Last_Slash_From_Uri()
        {
            var dal = new TestDal(this.credentials);

            var uriWithTrailingSlash = this.someURI + "/";

            Assert.That(this.someURI, Is.EqualTo(dal.CleanSlashes(this.someURI)));
            Assert.That(this.someURI, Is.EqualTo(dal.CleanSlashes(uriWithTrailingSlash)));
            Assert.That(string.Empty, Is.EqualTo(dal.CleanSlashes(string.Empty)));
            Assert.That(string.Empty, Is.EqualTo(dal.CleanSlashes(null)));
        }

        [Test]
        public void Verify_That_Clean_Path_Start_Slash_Removes_First_Slash_From_Path()
        {
            var dal = new TestDal(this.credentials);

            var pathWithSlash = $"/{this.somePath}";

            Assert.That(this.somePath, Is.EqualTo(dal.CleanPathSlashes(this.somePath)));
            Assert.That(this.somePath, Is.EqualTo(dal.CleanPathSlashes(pathWithSlash)));
            Assert.That(string.Empty, Is.EqualTo(dal.CleanPathSlashes(string.Empty)));
            Assert.That(string.Empty, Is.EqualTo(dal.CleanPathSlashes(null)));
        }

        [Test]
        public void Verify_That_UriBuilder_Constructs_Proper_Uris()
        {
            var dal = new TestDal(this.credentials);

            var pathWithSlash = $"/{this.somePath}";
            var correctFullUri = "http://someuri:80/SiteDirectory";

            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithSlash).ToString()));
            Assert.That(this.somePath, Is.EqualTo(pathWithSlash));
            this.credentials = new Credentials("John", "Doe", new Uri("http://someURI/"));

            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithSlash).ToString()));

            var pathWithoutSlash = $"{this.somePath}";
            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithoutSlash).ToString()));

            this.credentials = new Credentials("John", "Doe", new Uri("http://someURI/mdb/"));
            correctFullUri = "http://someuri:80/mdb/SiteDirectory";

            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithoutSlash).ToString()));
            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithSlash).ToString()));

            this.credentials = new Credentials("John", "Doe", new Uri("http://someURI/mdb/a/b/c"));
            correctFullUri = "http://someuri:80/mdb/a/b/c/SiteDirectory";

            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithoutSlash).ToString()));
            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithSlash).ToString()));

            this.credentials = new Credentials("John", "Doe", new Uri("http://someURI/mdb/a/b/c/"));

            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithoutSlash).ToString()));
            Assert.That(correctFullUri, Is.EqualTo(dal.GetBuilder(this.credentials.Uri, ref pathWithSlash).ToString()));
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

            Assert.That(model.IterationContainerId, Is.Null);
            Assert.That(iteration.IterationContainerId, Is.Null);
            Assert.That("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", Is.EqualTo(elementDefinition.IterationContainerId.Value.ToString()));
            Assert.That("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", Is.EqualTo(parameter.IterationContainerId.Value.ToString()));
        }

        [Test]
        public void Verify_That_SetIterationId_Works_For_All_PartitionDependentContainmentClassType()
        {
            var dal = new TestDal(this.credentials);
            var uri = new Uri(@"http://localhost.com/EngineeringModel/694508eb-2730-488c-9405-6ca561df68dd/iteration/44647ff6-ffe3-44ff-9ed9-3256e2a97f9d?extent=deep&includeReferenceData=true&includeAllContainers=true");

            var folder = new Folder();
            var file = new CDP4Common.DTO.File();
            var fileRevision = new FileRevision();
            var list = new Thing[] { folder, file, fileRevision };

            Assert.That(PartitionDependentContainmentClassType.EngineeringModelAndIterationClassKindArray.Length, Is.EqualTo(3), "a ClassKind was added to or removed from PartitionDependentContainmentClassType.EngineeringModelAndIterationClassKindArray. Please make sure that this unit test, so that it tests all individual ClassKinds.");

            if (dal.TryExtractIterationIdfromUri(uri, out var iterationId))
            {
                dal.SetIterationContainer(list, iterationId);
            }

            Assert.That("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", Is.EqualTo(folder.IterationContainerId.Value.ToString()));
            Assert.That("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", Is.EqualTo(file.IterationContainerId.Value.ToString()));
            Assert.That("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", Is.EqualTo(fileRevision.IterationContainerId.Value.ToString()));
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

            var elementDefinitionUri = new Uri("http://www.stariongroup.eu/EngineeringModel/00B1FD7E-BE0F-4512-A406-02FCBD63E06A/iteration/0111A76D-346D-4055-A78D-B8215B993DA1/element/E9E8E386-B8BB-44F1-80B9-2C30761EE688");
            var elementDefinitionContext = testdal.QueryRequestContext(elementDefinitionUri);
            Assert.That("/EngineeringModel/00B1FD7E-BE0F-4512-A406-02FCBD63E06A/iteration/0111A76D-346D-4055-A78D-B8215B993DA1", Is.EqualTo(elementDefinitionContext));
        }

        [Test]
        public void Verify_that_for_a_decorated_dal_the_version_is_set()
        {
            var dal = new DecoratedDal();
            Assert.That(dal.DalVersion, Is.EqualTo(new Version(1, 1, 0)));
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

            var files = new List<string> { this.filePath };

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

            var files = new List<string> { this.filePath };

            var testDal = new TestDal(this.credentials);

            Assert.DoesNotThrow(() => testDal.TestOperationContainerFileVerification(operationContainer, files));
        }
    }

    [CDPVersion("1.1.0")]
    internal class TestDal : Dal
    {
        public override bool IsReadOnly
        {
            get { return false; }
        }

        public TestDal(Credentials credentials)
            : base()
        {
            this.Credentials = credentials;
        }

        public string CleanSlashes(string uri)
        {
            return base.CleanUriFinalSlash(uri);
        }

        public string CleanPathSlashes(string path)
        {
            return base.CleanPathStartingSlash(path);
        }

        public UriBuilder GetBuilder(Uri uri, ref string path)
        {
            return base.GetUriBuilder(uri, ref path);
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

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously for a possible long running task.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="waitTime">The maximum time that we allow the server before responding. If the write operation takes more time
        /// than the provided <paramref name="waitTime"/>, a <see cref="CometTask"/></param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            return null;
        }

        public override Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IEnumerable<EngineeringModel>> Read(IEnumerable<EngineeringModel> engineeringModels, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public override Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public override Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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

        /// <summary>
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="Iteration"/> that match provided <see cref="Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="Category"/> <see cref="Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{T}" /> of type <see cref="IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public override Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <remarks>This method should be used when using a CDP4-COMET WebServices and that it provides LocalJwtBearer authentication flow</remarks>
        public override Task Login(string userName, string password, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Applies Authentication information based on the <see cref="Dal.Credentials" /> 
        /// </summary>
        /// <param name="credentials"></param>
        public override void ApplyAuthenticationCredentials(Credentials credentials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Queries the shortname of the authenticated User
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the retrieved user shortname</returns>
        public override Task<string> QueryAuthenticatedUserName(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// Requests new <see cref="AuthenticationToken" /> based on the current refresh token
        /// </summary>
        /// <returns>An awaitabl <see cref="System.Threading.Tasks.Task" /></returns>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <exception cref="System.InvalidOperationException">If the current <see cref="Dal.Credentials" /> does not meet following constraints : not null, with non-null <see cref="AuthenticationToken" />
        ///  containing a refresh token and where the <see cref="AuthenticationSchemeKind" /> is <see cref="AuthenticationSchemeKind.LocalJwtBearer" /></exception>
        /// <exception cref="DalReadException">In case of non successful response from the CDP4 Data source</exception>
        public override Task RequestAuthenticationTokenFromRefreshToken(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }

    [DalExportAttribute("decorateddal", "a decorated dal", "1.1.0", DalType.Web)]
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

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously for a possible long running task.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="waitTime">The maximum time that we allow the server before responding. If the write operation takes more time
        /// than the provided <paramref name="waitTime"/>, a <see cref="CometTask"/></param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            return null;
        }

        public override Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<EngineeringModel>> Read(IEnumerable<EngineeringModel> engineeringModels, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public override Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public override Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken)
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

        /// <summary>
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="Iteration"/> that match provided <see cref="Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="Category"/> <see cref="Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{T}" /> of type <see cref="IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public override Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId, CancellationToken cancellationToken)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <remarks>This method should be used when using a CDP4-COMET WebServices and that it provides LocalJwtBearer authentication flow</remarks>
        public override Task Login(string userName, string password, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Applies Authentication information based on the <see cref="Dal.Credentials" /> 
        /// </summary>
        /// <param name="credentials"></param>
        public override void ApplyAuthenticationCredentials(Credentials credentials)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Queries the shortname of the authenticated User
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the retrieved user shortname</returns>
        public override Task<string> QueryAuthenticatedUserName(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Requests new <see cref="AuthenticationToken" /> based on the current refresh token
        /// </summary>
        /// <returns>An awaitabl <see cref="System.Threading.Tasks.Task" /></returns>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <exception cref="System.InvalidOperationException">If the current <see cref="Dal.Credentials" /> does not meet following constraints : not null, with non-null <see cref="AuthenticationToken" />
        ///  containing a refresh token and where the <see cref="AuthenticationSchemeKind" /> is <see cref="AuthenticationSchemeKind.LocalJwtBearer" /></exception>
        /// <exception cref="DalReadException">In case of non successful response from the CDP4 Data source</exception>
        public override Task RequestAuthenticationTokenFromRefreshToken(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
