// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    using CDP4Common.DTO;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4JsonFileDal;

    using Moq;

    using NLog;
    using NLog.Config;
    using NLog.Targets;

    using NUnit.Framework;

    using DomainOfExpertise = CDP4Common.SiteDirectoryData.DomainOfExpertise;
    using EngineeringModel = CDP4Common.EngineeringModelData.EngineeringModel;
    using EngineeringModelSetup = CDP4Common.DTO.EngineeringModelSetup;
    using File = System.IO.File;
    using IterationSetup = CDP4Common.DTO.IterationSetup;
    using ModelReferenceDataLibrary = CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary;
    using Organization = CDP4Common.SiteDirectoryData.Organization;
    using Participant = CDP4Common.SiteDirectoryData.Participant;
    using ParticipantRole = CDP4Common.SiteDirectoryData.ParticipantRole;
    using Person = CDP4Common.SiteDirectoryData.Person;
    using PersonRole = CDP4Common.SiteDirectoryData.PersonRole;
    using ReferenceSource = CDP4Common.SiteDirectoryData.ReferenceSource;
    using SiteDirectory = CDP4Common.SiteDirectoryData.SiteDirectory;
    using SiteReferenceDataLibrary = CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary;
    using Thing = CDP4Common.CommonData.Thing;

    [TestFixture]
    public class JsonFileDalTestFixture
    {
        /// <summary>
        /// AnnexC3 file archive
        /// </summary>
        private string annexC3File;

        /// <summary>
        /// Migration file that will be included
        /// </summary>
        private string migrationFile;

        /// <summary>
        /// The instance of <see cref="JsonFileDal"/> that is being tested
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
            var migrationSourceFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "migration.json");

            this.annexC3File = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "AnnexC3.zip");
            this.migrationFile = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "migration.json");

            if (!File.Exists(this.migrationFile))
            {
                File.Copy(migrationSourceFile, this.migrationFile);
            }

            this.cancelationTokenSource = new CancellationTokenSource();
            this.credentials = new Credentials("admin", "pass", new Uri(path));
            this.session = new Mock<ISession>();

            this.dal = new JsonFileDal
            {
                Session = this.session.Object
            };

            this.siteDirectoryData = new SiteDirectory();
            this.session.Setup(x => x.RetrieveSiteDirectory()).Returns(this.siteDirectoryData);
            this.session.Setup(x => x.Credentials).Returns(this.credentials);
        }

        [TearDown]
        public void TearDown()
        {
            this.credentials = null;
            this.dal = null;

            if (File.Exists(this.annexC3File))
            {
                File.Delete(this.annexC3File);
            }
        }

        [Test]
        public void Verify_that_when_uri_path_does_not_exist_exception_is_thrown()
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
            Assert.That(returned, Is.Not.Null);
            Assert.That(returned, Is.Not.Empty);
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
            Assert.That(this.dal.Credentials, Is.Null);
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
            var modelRdlData = new ModelReferenceDataLibrary { Iid = engineeringModelSetupDto.RequiredRdl.Single() };
            var engineeringModelSetupData = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { EngineeringModelIid = engineeringModelSetupDto.EngineeringModelIid };
            engineeringModelSetupData.RequiredRdl.Add(modelRdlData);
            engineeringModelSetupData.IterationSetup.Add(iterationSetupData);
            this.siteDirectoryData.Model.Add(engineeringModelSetupData);

            var iterObject = new Iteration { Iid = iterationSetupDto.IterationIid };

            var readResult = (await this.dal.Read(iterObject, this.cancelationTokenSource.Token)).ToList();

            // General assertions for any kind of Thing we read
            Assert.That(readResult, Is.Not.Null);
            Assert.That(readResult.Count(), Is.Not.EqualTo(1));
            
            var iter1 = readResult.Single(d => d.ClassKind == ClassKind.Iteration);
            Assert.That(iter1.ClassKind, Is.EqualTo(iterObject.ClassKind));
            Assert.That(iter1.Iid, Is.EqualTo(iterObject.Iid));
        }

        [Test]
        public void VerifyThatReadWithNonIterationInstanceSuppliedThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();

            Assert.That(async () => await this.dal.Read(alias, new CancellationToken()), Throws.TypeOf<NotSupportedException>());
        }

        [Test]
        public void VerifyThatWriteAsyncOperationContainerThrowsException()
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

            var domainSys = new DomainOfExpertise(Guid.NewGuid(), cache, this.credentials.Uri) { ShortName = "SYS" };
            this.siteDirectoryData.Domain.Add(domainSys);

            var domainAer = new DomainOfExpertise(Guid.NewGuid(), cache, this.credentials.Uri) { ShortName = "AER" };
            this.siteDirectoryData.Domain.Add(domainAer);

            var domainProp = new DomainOfExpertise(Guid.NewGuid(), cache, this.credentials.Uri) { ShortName = "PROP" };
            this.siteDirectoryData.Domain.Add(domainProp);

            // PersonRole
            var role = new PersonRole(Guid.NewGuid(), null, null);
            this.siteDirectoryData.PersonRole.Add(role);
            this.siteDirectoryData.DefaultPersonRole = role;

            // ParticipantRole
            var participantRole = new ParticipantRole(Guid.Empty, null, null);
            this.siteDirectoryData.ParticipantRole.Add(participantRole);
            this.siteDirectoryData.DefaultParticipantRole = participantRole;

            // Organization
            var organization = new Organization(Guid.NewGuid(), null, null)
            {
                Container = this.siteDirectoryData
            };

            var sitedirectoryDto = (CDP4Common.DTO.SiteDirectory)this.siteDirectoryData.ToDto();
            var clone = sitedirectoryDto.DeepClone<CDP4Common.DTO.SiteDirectory>();
            var operation = new Operation(sitedirectoryDto, clone, OperationKind.Update);

            Assert.That(operationContainers.Single().Operations.Count(), Is.EqualTo(0));
            operationContainers.Single().AddOperation(operation);

            Assert.That(operationContainers.Single().Operations.Count(), Is.EqualTo(1));
            Assert.Throws<ArgumentException>(() => this.dal.Write(operationContainers, files));

            operationContainers.Single().RemoveOperation(operation);
            Assert.That(operationContainers.Single().Operations.Count(), Is.EqualTo(0));

            var iterationIid = new Guid("b58ea73d-350d-4520-b9d9-a52c75ac2b5d");
            var iterationSetup = new IterationSetup(Guid.NewGuid(), 0);
            var iterationSetupPoco = new CDP4Common.SiteDirectoryData.IterationSetup(iterationSetup.Iid, cache, this.credentials.Uri);
            var model = new EngineeringModel(Guid.NewGuid(), cache, this.credentials.Uri);
            var modelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup();
            modelSetup.ActiveDomain.Add(domainSys);

            var source = new ReferenceSource(Guid.NewGuid(), cache, this.credentials.Uri)
            {
                Publisher = new Organization(Guid.NewGuid(), cache, this.credentials.Uri)
                {
                    Container = this.siteDirectoryData
                }
            };

            var requiredRdl = new ModelReferenceDataLibrary
            {
                RequiredRdl = new SiteReferenceDataLibrary(),
                ReferenceSource = { source }
            };

            var person = new Person
            {
                ShortName = "admin",
                Organization = organization,
                DefaultDomain = domainAer
            };

            var participant = new Participant(Guid.NewGuid(), cache, this.credentials.Uri) { Person = person };
            participant.Person.Role = role;
            participant.Role = participantRole;
            participant.Domain.Add(domainSys);
            participant.Domain.Add(domainProp);
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
            var operationContainer = new OperationContainer("/EngineeringModel/" + model.Iid + "/iteration/" + iteration.Iid, 0);
            operationContainer.AddOperation(operation);
            operationContainers = new[] { operationContainer, operationContainer };

            var things = await this.dal.Write(operationContainers, files);
            Assert.That(things, Is.Empty);
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
        public void Verify_that_ReadFile_throws_exception()
        {
            Assert.Throws<NotSupportedException>(() => this.dal.ReadFile(null, CancellationToken.None));
        }

        [Test]
        public void Verify_that_Open_with_null_credentials_throws_exception()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await this.dal.Open(null, this.cancelationTokenSource.Token));
        }

        [Test]
        public void VerifyCtorWithVersion()
        {
            this.dal = new JsonFileDal(new Version("1.0.0"));

            Assert.That(this.dal.Serializer.RequestDataModelVersion.Major, Is.EqualTo(1));
            Assert.That(this.dal.Serializer.RequestDataModelVersion.Minor, Is.EqualTo(0));
            Assert.That(this.dal.Serializer.RequestDataModelVersion.Build, Is.EqualTo(0));

            this.dal = new JsonFileDal(null);

            Assert.That(this.dal.DalVersion.Major, Is.EqualTo(1));
            Assert.That(this.dal.DalVersion.Minor, Is.EqualTo(2));
            Assert.That(this.dal.DalVersion.Build, Is.EqualTo(0));
        }

        [Test]
        public void VerifyCtorWithVersionAndCopyright()
        {
            this.dal = new JsonFileDal(new Version("1.0.0"));
            const string COPYRIGHT = "Copyright 2020 © RHEA Group.";
            const string REMARK = "This is custom ECSS-E-TM-10-25 exchange file";

            Assert.That(this.dal.Serializer.RequestDataModelVersion.Major, Is.EqualTo(1));
            Assert.That(this.dal.Serializer.RequestDataModelVersion.Minor, Is.EqualTo(0));
            Assert.That(this.dal.Serializer.RequestDataModelVersion.Build, Is.EqualTo(0));
            
            this.dal.UpdateExchangeFileHeader(new Person { ShortName = "admin" });
            Assert.That(this.dal.FileHeader, Is.InstanceOf<CDP4JsonFileDal.Json.ExchangeFileHeader>());

            this.dal.UpdateExchangeFileHeader(new Person { ShortName = "admin" }, COPYRIGHT, REMARK);
            Assert.That(this.dal.FileHeader.Copyright, Is.EqualTo(COPYRIGHT));
            Assert.That(this.dal.FileHeader.Remark, Is.EqualTo(REMARK));
        }

        [Test]
        public void VerifyVersionCheckCtor()
        {
            var baseDalVersion = new JsonFileDal().DalVersion;

            Assert.DoesNotThrow(
                () => this.dal = new JsonFileDal(baseDalVersion));

            Assert.DoesNotThrow(
                () => this.dal = new JsonFileDal(new Version($"{baseDalVersion.Major - 1}.{baseDalVersion.Minor}.{baseDalVersion.Build}")));

            Assert.DoesNotThrow(
                () => this.dal = new JsonFileDal(new Version($"{baseDalVersion.Major}.{baseDalVersion.Minor - 1}.{baseDalVersion.Build}")));

            Assert.Throws<DalVersionException>(
                () => this.dal = new JsonFileDal(new Version($"{baseDalVersion.Major + 1}.{baseDalVersion.Minor}.{baseDalVersion.Build}")));

            Assert.Throws<DalVersionException>(
                () => this.dal = new JsonFileDal(new Version($"{baseDalVersion.Major}.{baseDalVersion.Minor + 1}.{baseDalVersion.Build}")));

            Assert.Throws<DalVersionException>(
                () => this.dal = new JsonFileDal(new Version($"{baseDalVersion.Major}.{baseDalVersion.Minor}.{baseDalVersion.Build + 1}")));
        }

        [Test]
        public void VerifyWritingWithoutMigrationFile()
        {
            var zipCredentials = new Credentials("admin", "pass", new Uri(this.annexC3File));
            var zipSession = new Session(this.dal, zipCredentials);

            var operationContainers = this.BuildOperationContainers();

            Assert.DoesNotThrowAsync(async () => await Task.Run(() => this.dal.Write(operationContainers)));
        }

        [Test]
        public void VerifyWritingMigrationFile()
        {
            var zipCredentials = new Credentials("admin", "pass", new Uri(this.annexC3File));
            var zipSession = new Session(this.dal, zipCredentials);

            var operationContainers = this.BuildOperationContainers();

            Assert.DoesNotThrowAsync(async () => await Task.Run(() => this.dal.Write(operationContainers, new string[] { this.migrationFile })));
        }

        /// <summary>
        /// Build operation containes structure that will be serialized
        /// </summary>
        /// <returns>
        /// List of <see cref="OperationContainer"/>
        /// </returns>
        private IEnumerable<OperationContainer> BuildOperationContainers()
        {
            var cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            // DomainOfExpertise
            var domain = new DomainOfExpertise(Guid.NewGuid(), cache, this.credentials.Uri) { ShortName = "SYS" };
            this.siteDirectoryData.Domain.Add(domain);

            // PersonRole
            var role = new PersonRole(Guid.NewGuid(), null, null);
            this.siteDirectoryData.PersonRole.Add(role);
            this.siteDirectoryData.DefaultPersonRole = role;

            // ParticipantRole
            var participantRole = new ParticipantRole(Guid.Empty, null, null);
            this.siteDirectoryData.ParticipantRole.Add(participantRole);
            this.siteDirectoryData.DefaultParticipantRole = participantRole;

            // Organization
            var organization = new Organization(Guid.NewGuid(), null, null)
            {
                Container = this.siteDirectoryData
            };

            // Iteration
            var iterationIid = new Guid("b58ea73d-350d-4520-b9d9-a52c75ac2b5d");
            var iterationSetup = new IterationSetup(Guid.NewGuid(), 0);
            var iterationSetupPoco = new CDP4Common.SiteDirectoryData.IterationSetup(iterationSetup.Iid, cache, this.credentials.Uri);

            // EngineeringModel
            var model = new EngineeringModel(Guid.NewGuid(), cache, this.credentials.Uri);
            var modelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup();
            modelSetup.ActiveDomain.Add(domain);

            var requiredRdl = new ModelReferenceDataLibrary();

            var person = new Person { ShortName = "admin", Organization = organization };
            var participant = new Participant(Guid.NewGuid(), cache, this.credentials.Uri) { Person = person };
            participant.Person.Role = role;
            participant.Role = participantRole;
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
            var iterationClone = iteration.DeepClone<Iteration>();

            var operation = new Operation(iteration, iterationClone, OperationKind.Update);
            var operationContainers = new[] { new OperationContainer("/EngineeringModel/" + model.Iid + "/iteration/" + iteration.Iid, 0) };
            operationContainers.Single().AddOperation(operation);

            return operationContainers;
        }
    }
}
