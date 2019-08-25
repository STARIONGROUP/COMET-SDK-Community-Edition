// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4JsonFileDal.Tests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Operations;
    using CDP4JsonFileDal;
    using Moq;
    using NLog;
    using NLog.Config;
    using NLog.Targets;
    using NUnit.Framework;

    using EngineeringModel = CDP4Common.EngineeringModelData.EngineeringModel;
    using EngineeringModelSetup = CDP4Common.DTO.EngineeringModelSetup;
    using Iteration = CDP4Common.DTO.Iteration;
    using IterationSetup = CDP4Common.DTO.IterationSetup;
    using Person = CDP4Common.SiteDirectoryData.Person;
    using SiteDirectory = CDP4Common.SiteDirectoryData.SiteDirectory;
    using SiteReferenceDataLibrary = CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary;
    using Thing = CDP4Common.CommonData.Thing;

    [TestFixture]
    public class JsonFileDalTestFixture
    {
        /// <summary>
        /// The instance of <see cref="JSONFileDal"/> that is being tested
        /// </summary>
        private JsonFileDal dal;

        /// <summary>
        /// The <see cref="Credentials"/> used to connect to the data-source
        /// </summary>
        private Credentials credentials;

        /// <summary>
        /// The cancelation token source.
        /// </summary>
        private CancellationTokenSource cancelationTokenSource;

        /// <summary>
        /// Mock the session of the dal.
        /// </summary>
        private Mock<ISession> session;

        /// <summary>
        /// An instance of site directory data used to be returned from the mocked session.
        /// </summary>
        private SiteDirectory siteDirectoryData;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget();
            config.AddTarget("file", fileTarget);
            fileTarget.FileName = Path.Combine(TestContext.CurrentContext.TestDirectory, "file.txt");
            fileTarget.Layout = @"${date:format=HH\:mm\:ss} ${logger} ${message}";
            var fileRule = new LoggingRule("*", LogLevel.Trace, fileTarget);
            config.LoggingRules.Add(fileRule);

            LogManager.Configuration = config;
        }

        [SetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "LOFT_ECSS-E-TM-10-25_AnnexC.zip");

            this.cancelationTokenSource = new CancellationTokenSource();
            this.credentials = new Credentials("admin", "pass", new Uri(path));
            this.session = new Mock<ISession>();
            this.dal = new JsonFileDal();
            this.dal.Session = this.session.Object;

            this.siteDirectoryData = new SiteDirectory();
            this.session.Setup(x => x.RetrieveSiteDirectory()).Returns(this.siteDirectoryData);
            this.session.Setup(x => x.Credentials).Returns(this.credentials);
        }

        [TearDown]
        public void TearDown()
        {
            this.credentials = null;
            this.dal = null;
        }

        [Test]
        public async Task Verify_that_when_uri_path_does_not_exist_exception_is_thrown()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "does_not_exist.zip");
            this.credentials = new Credentials("admin", "pass", new Uri(path));
            var jsonfiledal = new JsonFileDal();

            Assert.ThrowsAsync<FileLoadException>(async () => await jsonfiledal.Open(this.credentials, this.cancelationTokenSource.Token));
        }

        [Test]
        [Category("AppVeyorExclusion")]
        public async Task VerifyThatOpenCreatesAConnection()
        {
            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            Assert.NotNull(returned);
            Assert.IsNotEmpty(returned);

            Assert.DoesNotThrow(() => this.dal.Close());
        }

        [Test]
        public void VerifyThatUpdateThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotSupportedException>(() => this.dal.Update(alias));
        }

        [Test]
        public void VerifyThatDeleteThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotSupportedException>(() => this.dal.Delete(alias));
        }

        [Test]
        public void VerifyThatAJsonDalThatIsNotOpenCannotBeClosed()
        {
            Assert.IsNull(this.dal.Credentials);
            Assert.Throws<InvalidOperationException>(() => this.dal.Close());
        }

        [Test]
        [Category("AppVeyorExclusion")]
        public async Task VerifyThatReadReturnsCorrectDTO()
        {
            var returned = (await this.dal.Open(this.credentials, this.cancelationTokenSource.Token)).ToList();

            Assert.NotNull(returned);
            Assert.IsNotEmpty(returned);

            // read info from the open call
            var engineeringModelSetupDto = returned.Single(d => d.ClassKind == ClassKind.EngineeringModelSetup) as EngineeringModelSetup;
            var iterationSetupDto = returned.First(d => d.ClassKind == ClassKind.IterationSetup) as IterationSetup;

            Assert.NotNull(engineeringModelSetupDto);
            Assert.NotNull(iterationSetupDto);

            // setup expected SiteDirectory instance
            var iterationSetupData = new CDP4Common.SiteDirectoryData.IterationSetup { IterationIid = iterationSetupDto.IterationIid };
            var modelRdlData = new CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary { Iid = engineeringModelSetupDto.RequiredRdl.Single() };
            var engineeringModelSetupData = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { EngineeringModelIid = engineeringModelSetupDto.EngineeringModelIid };
            engineeringModelSetupData.RequiredRdl.Add(modelRdlData);
            engineeringModelSetupData.IterationSetup.Add(iterationSetupData);
            this.siteDirectoryData.Model.Add(engineeringModelSetupData);

            var iterObject = new Iteration { Iid = iterationSetupDto.IterationIid };

            var readResult = (await this.dal.Read(iterObject, this.cancelationTokenSource.Token)).ToList();

            // General assertions for any kind of Thing we read
            Assert.NotNull(readResult);
            Assert.IsTrue(readResult.Count() != 1);
            var iter1 = readResult.Single(d => d.ClassKind == ClassKind.Iteration);
            Assert.IsTrue(iterObject.ClassKind == iter1.ClassKind);
            Assert.IsTrue(iterObject.Iid == iter1.Iid);
        }
        
        [Test]
        public async Task VerifyThatReadWithNonIterationInstanceSuppliedThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();

            Assert.That(async () => await this.dal.Read(alias, new CancellationToken()), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public async Task VerifyThatWriteAsyncOperationContainerThrowsException()
        {
            var operationContainer = new OperationContainer("/SiteDirectory/47363f0d-eb6d-4a58-95f5-fa7854995650", 1);

            Assert.That(async () => await this.dal.Write(operationContainer, It.IsAny<IEnumerable<string>>()), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public async Task VerifyWriteEnumerableOperationContainer()
        {
            var cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            var files = new[] { "file1" };
            Assert.Throws<ArgumentNullException>(() => this.dal.Write((IEnumerable<OperationContainer>)null, files));
            Assert.Throws<ArgumentException>(() => this.dal.Write(new List<OperationContainer>(), files));

            var operationContainers = new[] { new OperationContainer("/SiteDirectory/00000000-0000-0000-0000-000000000000", 0) };
            Assert.Throws<ArgumentException>(() => this.dal.Write(operationContainers, files));

            var domain = new DomainOfExpertise(Guid.NewGuid(), cache, this.credentials.Uri) { ShortName = "SYS" };
            this.siteDirectoryData.Domain.Add(domain);

            var sitedirectoryDto = (CDP4Common.DTO.SiteDirectory)this.siteDirectoryData.ToDto();
            var clone = sitedirectoryDto.DeepClone<CDP4Common.DTO.SiteDirectory>();
            var operation = new Operation(sitedirectoryDto, clone, OperationKind.Update);
            Assert.AreEqual(0, operationContainers.Single().Operations.Count());
            operationContainers.Single().AddOperation(operation);

            Assert.AreEqual(1, operationContainers.Single().Operations.Count());
            Assert.Throws<ArgumentException>(() => this.dal.Write(operationContainers, files));

            operationContainers.Single().RemoveOperation(operation);
            Assert.AreEqual(0, operationContainers.Single().Operations.Count());

            var iterationIid = new Guid("b58ea73d-350d-4520-b9d9-a52c75ac2b5d");
            var iterationSetup = new IterationSetup(Guid.NewGuid(), 0);
            var iterationSetupPoco = new CDP4Common.SiteDirectoryData.IterationSetup(iterationSetup.Iid, cache, this.credentials.Uri);
            var model = new EngineeringModel(Guid.NewGuid(), cache, this.credentials.Uri);
            var modelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup();
            modelSetup.ActiveDomain.Add(domain);

            var requiredRdl = new CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary();
            
            var person = new Person { ShortName = "admin" };
            var participant = new Participant(Guid.NewGuid(), cache, this.credentials.Uri) {Person = person};
            participant.Domain.Add(domain);
            modelSetup.Participant.Add(participant);

            var lazyPerson = new Lazy<Thing>(() => person);
            var iterationPoco = new CDP4Common.EngineeringModelData.Iteration(iterationIid, cache, this.credentials.Uri) { IterationSetup = iterationSetupPoco };
            model.Iteration.Add(iterationPoco);
            var iteration = (Iteration)iterationPoco.ToDto();
            model.EngineeringModelSetup = modelSetup;
            this.siteDirectoryData.Model.Add(modelSetup);
            modelSetup.RequiredRdl.Add(requiredRdl);
            modelSetup.IterationSetup.Add(iterationSetupPoco);
            cache.TryAdd(new CacheKey(person.Iid, this.siteDirectoryData.Iid), lazyPerson);
            this.siteDirectoryData.Cache = cache;
            iteration.IterationSetup = iterationSetup.Iid;
            var clone1 = iteration.DeepClone<Iteration>();
            operation = new Operation(iteration, clone1, OperationKind.Update);
            operationContainers = new[] { new OperationContainer("/EngineeringModel/" + model.Iid + "/iteration/" + iteration.Iid, 0) };
            operationContainers.Single().AddOperation(operation);

            Assert.IsEmpty(await this.dal.Write(operationContainers, files));
        }

        [Test]
        public void Verify_that_JsonFileDal_IsReadOnly()
        {
            Assert.That(this.dal.IsReadOnly, Is.True);
        }

        [Test]
        public void Verify_that_Create_throws_exception()
        {
            var alias = new CDP4Common.DTO.Alias();

            Assert.Throws<NotSupportedException>(() => this.dal.Create(alias));
        }

        [Test]
        public async Task Verify_that_Open_with_null_credentials_throws_exception()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await this.dal.Open(null, this.cancelationTokenSource.Token));
        }
    }
}