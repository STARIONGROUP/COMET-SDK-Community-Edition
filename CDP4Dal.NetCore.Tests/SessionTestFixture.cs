// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Helpers;
    using CDP4Common.MetaInfo;
    using CDP4Dal.Operations;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using CDP4Dal.Events;
    using Moq;
    using NUnit.Framework;
    
    using DomainOfExpertise = CDP4Common.SiteDirectoryData.DomainOfExpertise;
    using EngineeringModelSetup = CDP4Common.DTO.EngineeringModelSetup;
    using ModelReferenceDataLibrary = CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary;
    using SiteDirectory = CDP4Common.DTO.SiteDirectory;
    using SiteReferenceDataLibrary = CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary;
    using TelephoneNumber = CDP4Common.SiteDirectoryData.TelephoneNumber;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// Suite of tests for the <see cref="Session"/> class
    /// </summary>
    [TestFixture]
    public class SessionTestFixture
    {
        /// <summary>
        /// mocked data service
        /// </summary>
        private Mock<IDal> mockedDal;

        /// <summary>
        /// a list of <see cref="CDP4Common.DTO.Thing"/> returned from the mocked <see cref="IDal"/>
        /// </summary>
        private List<Thing> dalOutputs;

        /// <summary>
        /// The uri of the mocked <see cref="IDal"/>
        /// </summary>
        private Uri uri;

        /// <summary>
        /// The <see cref="Session"/> object under test
        /// </summary>
        private Session session;

        /// <summary>
        /// The <see cref="Person"/> object under test
        /// </summary>
        private CDP4Common.DTO.Person person;

        private CDP4Common.DTO.SiteDirectory sieSiteDirectoryDto;

        private CancellationTokenSource tokenSource;
        
        [SetUp]
        public void SetUp()
        {
            this.dalOutputs = new List<Thing>();

            this.sieSiteDirectoryDto = new CDP4Common.DTO.SiteDirectory(Guid.NewGuid(), 22);
            this.person = new CDP4Common.DTO.Person(Guid.NewGuid(), 22) { ShortName = "John", GivenName = "John", Password = "Doe", IsActive = true };
            var phone1 = new CDP4Common.DTO.TelephoneNumber(Guid.NewGuid(), 22) { Value = "123" };
            phone1.VcardType.Add(VcardTelephoneNumberKind.HOME);
            var phone2 = new CDP4Common.DTO.TelephoneNumber(Guid.NewGuid(), 22) { Value = "456" };
            phone2.VcardType.Add(VcardTelephoneNumberKind.WORK);
            var phone3 = new CDP4Common.DTO.TelephoneNumber(Guid.NewGuid(), 22) { Value = "789" };
            phone3.VcardType.Add(VcardTelephoneNumberKind.FAX);

            this.sieSiteDirectoryDto.Person.Add(this.person.Iid);

            this.person.TelephoneNumber.Add(phone1.Iid);
            this.person.TelephoneNumber.Add(phone2.Iid);
            this.person.TelephoneNumber.Add(phone3.Iid);

            this.dalOutputs.Add(this.sieSiteDirectoryDto);
            this.dalOutputs.Add(this.person);
            this.dalOutputs.Add(phone1);
            this.dalOutputs.Add(phone2);
            this.dalOutputs.Add(phone3);

            this.uri = new Uri("http://www.rheagroup.com/");
            var credentials = new Credentials("John", "Doe", this.uri);

            this.mockedDal = new Mock<IDal>();
            this.mockedDal.SetupProperty(d => d.Session);
            
            this.session = new Session(this.mockedDal.Object, credentials);
            
            this.tokenSource = new CancellationTokenSource();

            var openTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            openTaskCompletionSource.SetResult(this.dalOutputs);
            this.mockedDal.Setup(x => x.Open(It.IsAny<Credentials>(), It.IsAny<CancellationToken>())).Returns(openTaskCompletionSource.Task);
        }

        [TearDown]
        public void TearDown()
        {
            CDPMessageBus.Current.ClearSubscriptions();
        }

        [Test]
        public async Task VerifythatOpenCallAssemblerSynchronizeWithDtos()
        {
            var eventReceived = false;
            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            await this.session.Open();

            Assert.IsTrue(eventReceived);
        }

        [Test]
        public async Task VerifyThatWriteWithEmptyResponseSendsMessages()
        {
            var beginUpdateReceived = false;
            var endUpdateReceived = false;

            var writeWithNoResultsTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            writeWithNoResultsTaskCompletionSource.SetResult(new List<Thing>());
            this.mockedDal.Setup(x => x.Open(It.IsAny<Credentials>(), It.IsAny<CancellationToken>())).Returns(writeWithNoResultsTaskCompletionSource.Task);

            CDPMessageBus.Current.Listen<SessionEvent>()                
                .Subscribe(x => 
            {
                if (x.Status == SessionStatus.BeginUpdate)
                {
                    beginUpdateReceived = true;
                    return;
                }

                if (x.Status == SessionStatus.EndUpdate)
                {
                    endUpdateReceived = true;
                }
            });
            
            var context = string.Format("/SiteDirectory/{0}", Guid.NewGuid());
            await this.session.Write(new OperationContainer(context));

            Assert.IsTrue(beginUpdateReceived);
            Assert.IsTrue(endUpdateReceived);
        }

        [Test]
        public async Task VerifythatRefreshSynchronizeTheAssembler()
        {
            var eventReceived = false;

            var uriQueryAttMock = new Mock<IQueryAttributes>();
            uriQueryAttMock.Setup(x => x.RevisionNumber).Returns(22);

            // returns the dtos only if revisionNumber == 0
            var readTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            readTaskCompletionSource.SetResult(this.dalOutputs);
            this.mockedDal.Setup(x => x.Read(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.Is<IQueryAttributes>(query => query.RevisionNumber == 0))).Returns(readTaskCompletionSource.Task);
            
            await this.session.Open();

            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            // refresh shouldnt do anything
            await this.session.Refresh();

            Assert.IsFalse(eventReceived);
        }

        [Test]
        public async Task VerifythatReloadSynchronizeTheAssembler()
        {
            var updatedTel = new CDP4Common.DTO.TelephoneNumber(this.dalOutputs.OfType<CDP4Common.DTO.TelephoneNumber>().First().Iid, 100);
            var eventReceived = false;

            var uriQueryAttMock = new Mock<IQueryAttributes>();
            uriQueryAttMock.Setup(x => x.RevisionNumber).Returns(0);

            // returns the dtos only if revisionNumber == 0
            var readTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            readTaskCompletionSource.SetResult(new List<Thing> { updatedTel });
            this.mockedDal.Setup(x => x.Read(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.Is<IQueryAttributes>(query => query.RevisionNumber == 0))).Returns(readTaskCompletionSource.Task);

            await this.session.Open();

            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            await this.session.Reload();

            Assert.IsTrue(eventReceived);
        }

        /// <summary>
        /// The verify that get active person works.
        /// </summary>
        [Test]
        public async Task VerifyThatGetActivePersonWorks()
        {
            await this.session.Open();

            var activePerson = this.session.ActivePerson;
            Assert.IsNotNull(activePerson);
            Assert.AreEqual("John", activePerson.ShortName);

            activePerson = null;

            // query again to cover cached activeperson property
            activePerson = this.session.ActivePerson;
            Assert.IsNotNull(activePerson);
        }

        [Test]
        public async Task VerifyThatOpenSiteRDLUpdatesListInSession()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory() { Iid = Guid.NewGuid() };
            var requiredPocoDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredPocoRdl = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary(requiredPocoDto.Iid, null, null);
            rdlDto.RequiredRdl = requiredPocoDto.Iid;

            var credentials = new Credentials("admin", "pass", new Uri("http://www.rheagroup.com"));
            var session2 = new Session(this.mockedDal.Object, credentials);
            var rdlPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary { Iid = rdlDto.Iid, Name = rdlDto.Name, ShortName = rdlDto.ShortName, Container = siteDir, RequiredRdl = requiredPocoRdl };
            var thingsToAdd = new List<Thing>() { siteDirDto, requiredPocoDto, rdlDto };
            
            await session2.Assembler.Synchronize(thingsToAdd);

            Assert.IsEmpty(session2.OpenReferenceDataLibraries);

            await session2.Read(rdlPoco);

            Assert.AreEqual(2, session2.OpenReferenceDataLibraries.ToList().Count());

            await session2.Close();
            Assert.IsEmpty(session2.OpenReferenceDataLibraries);
        }

        [Test]
        public async Task VerifyThatCloseRdlWorks()
        {
            var siteDirectoryPoco = new CDP4Common.SiteDirectoryData.SiteDirectory(this.sieSiteDirectoryDto.Iid, this.session.Assembler.Cache, this.uri);

            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var rdlPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary { Iid = rdlDto.Iid, Name = rdlDto.Name, ShortName = rdlDto.ShortName, Container = siteDirectoryPoco };
            
            var requiredSiteReferenceDataLibraryDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredSiteReferenceDataLibraryPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary(requiredSiteReferenceDataLibraryDto.Iid, this.session.Assembler.Cache, this.uri);
            
            rdlDto.RequiredRdl = requiredSiteReferenceDataLibraryDto.Iid;
            rdlPoco.RequiredRdl = requiredSiteReferenceDataLibraryPoco;

            var thingsToAdd = new List<Thing>() { requiredSiteReferenceDataLibraryDto, rdlDto };

            await session.Assembler.Synchronize(thingsToAdd);
            await session.Read(rdlPoco);
            Assert.AreEqual(2, session.OpenReferenceDataLibraries.ToList().Count());

            Lazy<CDP4Common.CommonData.Thing> rdlPocoToClose;
            session.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(rdlPoco.Iid, null), out rdlPocoToClose);
            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)rdlPocoToClose.Value);
            Assert.AreEqual(1, session.OpenReferenceDataLibraries.ToList().Count());

            await session.Read(rdlPoco);
            Assert.AreEqual(2, session.OpenReferenceDataLibraries.ToList().Count());

            session.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(rdlPoco.Iid, null), out rdlPocoToClose);
            Lazy<CDP4Common.CommonData.Thing> requiredRdlToClose;
            session.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(requiredSiteReferenceDataLibraryPoco.Iid, null), out requiredRdlToClose);
            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)requiredRdlToClose.Value);
            
            Assert.AreEqual(0, session.OpenReferenceDataLibraries.ToList().Count());

            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)rdlPocoToClose.Value);
            Assert.AreEqual(0, session.OpenReferenceDataLibraries.ToList().Count());
        }

        [Test]
        public async Task VerifyThatSiteRdlRequiredByModelRdlCannotBeClosed()
        {
            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory() { Iid = Guid.NewGuid() };
            var requiredRdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            rdlDto.RequiredRdl = requiredRdlDto.Iid;
            siteDirDto.SiteReferenceDataLibrary.Add(rdlDto.Iid);
            siteDirDto.SiteReferenceDataLibrary.Add(requiredRdlDto.Iid);

            var mrdl = new CDP4Common.DTO.ModelReferenceDataLibrary(Guid.NewGuid(), 0) { RequiredRdl = requiredRdlDto.Iid };
            var modelsetup = new EngineeringModelSetup(Guid.NewGuid(), 0);
            modelsetup.RequiredRdl.Add(mrdl.Iid);

            var model = new EngineeringModel(Guid.NewGuid(), 0) { EngineeringModelSetup = modelsetup.Iid };
            var iteration = new Iteration(Guid.NewGuid(), 0);
            model.Iteration.Add(iteration.Iid);

            siteDirDto.Model.Add(modelsetup.Iid);

            var readReturn = new List<Thing>
            {
                siteDirDto,
                mrdl,
                modelsetup,
                model,
                iteration
            };

            var mrdlpoco = new ModelReferenceDataLibrary(mrdl.Iid, null, null);
            var modelsetuppoco = new CDP4Common.SiteDirectoryData.EngineeringModelSetup(modelsetup.Iid, null, null);
            modelsetuppoco.RequiredRdl.Add(mrdlpoco);

            var participant = new CDP4Common.DTO.Participant(Guid.NewGuid(), 0) { Person = this.person.Iid };
            modelsetup.Participant.Add(participant.Iid);
            var modelPoco = new CDP4Common.EngineeringModelData.EngineeringModel(model.Iid, null, null){EngineeringModelSetup = modelsetuppoco};
            var iterationPoco = new CDP4Common.EngineeringModelData.Iteration(iteration.Iid, null, null);
            modelPoco.Iteration.Add(iterationPoco);

            var readTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            readTaskCompletionSource.SetResult(readReturn);
            this.mockedDal.Setup(
                x => x.Read(It.IsAny<Iteration>(), It.IsAny<CancellationToken>(), null))
                .Returns(readTaskCompletionSource.Task);

            var thingsToAdd = new List<Thing>() { siteDirDto, requiredRdlDto, rdlDto, this.person, participant, modelsetup };

            await this.session.Assembler.Synchronize(thingsToAdd);
            await this.session.Read(iterationPoco, null);
            
            Assert.AreEqual(2, this.session.OpenReferenceDataLibraries.Count());

            Lazy<CDP4Common.CommonData.Thing> requiredRdlToClose;
            this.session.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(requiredRdlDto.Iid, null), out requiredRdlToClose);

            await this.session.CloseRdl((SiteReferenceDataLibrary)requiredRdlToClose.Value);
            Assert.AreEqual(2, this.session.OpenReferenceDataLibraries.Count());
        }

        [Test]
        public async Task VerifyThatCloseModelRdlWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var modelRdlDto = new CDP4Common.DTO.ModelReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory() { Iid = Guid.NewGuid() };
            var requiredPocoDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredPocoRdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var containerEngModelSetupDto = new EngineeringModelSetup() { Iid = Guid.NewGuid() };
            var containerEngModelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup() { Iid = containerEngModelSetupDto.Iid };
            siteDir.Model.Add(containerEngModelSetup);
            modelRdlDto.RequiredRdl = requiredPocoDto.Iid;

            var credentials = new Credentials("admin", "pass", new Uri("http://www.rheagroup.com"));
            var session2 = new Session(this.mockedDal.Object, credentials);
            var modelRdlPoco = new ModelReferenceDataLibrary { Iid = modelRdlDto.Iid, Name = modelRdlDto.Name, ShortName = modelRdlDto.ShortName, Container = containerEngModelSetup, RequiredRdl = requiredPocoRdl };
            var thingsToAdd = new List<Thing>() { siteDirDto, requiredPocoDto, containerEngModelSetupDto, modelRdlDto };

            await session2.Assembler.Synchronize(thingsToAdd);
            await session2.Read(modelRdlPoco);
            Assert.AreEqual(2, session2.OpenReferenceDataLibraries.ToList().Count());

            Lazy<CDP4Common.CommonData.Thing> rdlPocoToClose;
            session2.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(modelRdlPoco.Iid, null), out rdlPocoToClose);
            Assert.NotNull(rdlPocoToClose);
            await session2.CloseModelRdl((ModelReferenceDataLibrary)rdlPocoToClose.Value);

            // Checkt that closing a modelRDL doesn't close it's required SiteRDL
            Assert.AreEqual(1, session2.OpenReferenceDataLibraries.ToList().Count());
            Assert.AreEqual(ClassKind.SiteReferenceDataLibrary, session2.OpenReferenceDataLibraries.First().ClassKind);
        }

        [Test]
        public async Task VerifyThatCloseModelWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var modelRdlDto = new CDP4Common.DTO.ModelReferenceDataLibrary { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory { Iid = Guid.NewGuid() };
            var requiredPocoDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var containerEngModelSetupDto = new EngineeringModelSetup { Iid = Guid.NewGuid() };
            var containerEngModelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { Iid = containerEngModelSetupDto.Iid };
            var iterationDto = new Iteration { Iid = Guid.NewGuid() };
            var iteration = new CDP4Common.EngineeringModelData.Iteration { Iid = iterationDto.Iid };
            var iterationSetupDto = new CDP4Common.DTO.IterationSetup { Iid = Guid.NewGuid(), IterationIid = iterationDto.Iid };
            iterationDto.IterationSetup = iterationSetupDto.IterationIid;
            siteDir.Model.Add(containerEngModelSetup);
            modelRdlDto.RequiredRdl = requiredPocoDto.Iid;

            var credentials = new Credentials("admin", "pass", new Uri("http://www.rheagroup.com"));
            var session2 = new Session(this.mockedDal.Object, credentials);

            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup { Iid = iterationSetupDto.Iid, Container = containerEngModelSetup, IterationIid = iteration.Iid };
            var thingsToAdd = new List<Thing> { siteDirDto, requiredPocoDto, containerEngModelSetupDto, modelRdlDto, iterationSetupDto };

            await session2.Assembler.Synchronize(thingsToAdd);

            var lazyiteration = new Lazy<CDP4Common.CommonData.Thing>(() => iteration);
            session2.Assembler.Cache.GetOrAdd(new Tuple<Guid, Guid?>(iterationDto.Iid, null), lazyiteration);

            CDP4Common.CommonData.Thing changedObject = null;
            CDPMessageBus.Current.Listen<ObjectChangedEvent>(typeof(CDP4Common.EngineeringModelData.Iteration)).Subscribe(x => changedObject = x.ChangedThing);
            session2.CloseIterationSetup(iterationSetup);
            Assert.NotNull(changedObject);
        }

        [Test]
        public async Task VerifyThatReadRdlWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(siteDir.Iid, null),
                new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));

            var sitedirDto = new SiteDirectory(siteDir.Iid, 1);
            var rdl = new CDP4Common.DTO.SiteReferenceDataLibrary(Guid.NewGuid(), 1);
            sitedirDto.SiteReferenceDataLibrary.Add(rdl.Iid);

            var readOutput = new List<Thing>
            {
                sitedirDto,
                rdl
            };

            var readTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            readTaskCompletionSource.SetResult(readOutput);
            this.mockedDal.Setup(x => x.Read(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>())).Returns(readTaskCompletionSource.Task);

            var srdl = new SiteReferenceDataLibrary(rdl.Iid, null, null);
            srdl.Container = siteDir;

            await this.session.Read(srdl);

            Assert.AreEqual(1, this.session.OpenReferenceDataLibraries.Count());
            Assert.IsTrue(siteDir.SiteReferenceDataLibrary.Any());
        }

        [Test]
        public void VerifyThatReadIterationWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var modelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup(Guid.NewGuid(), this.session.Assembler.Cache, this.uri) { FrozenOn = DateTime.Now, IterationIid = Guid.NewGuid() };
            var mrdl = new ModelReferenceDataLibrary(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var srdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var activeDomain = new DomainOfExpertise(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            mrdl.RequiredRdl = srdl;
            modelSetup.RequiredRdl.Add(mrdl);
            modelSetup.IterationSetup.Add(iterationSetup);
            siteDir.Model.Add(modelSetup);
            siteDir.SiteReferenceDataLibrary.Add(srdl);
            siteDir.Domain.Add(activeDomain);

            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(modelSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => modelSetup));
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(mrdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => mrdl));
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(srdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => srdl));
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new Tuple<Guid, Guid?>(iterationSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => iterationSetup));

            var participant = new CDP4Common.SiteDirectoryData.Participant(Guid.NewGuid(), this.session.Assembler.Cache, this.uri) { Person = this.session.ActivePerson };
            modelSetup.Participant.Add(participant);

            var model = new EngineeringModel(Guid.NewGuid(), 1);
            var iteration = new Iteration(iterationSetup.IterationIid, 10) { IterationSetup = iterationSetup.Iid };
            model.Iteration.Add(iteration.Iid);
            model.EngineeringModelSetup = modelSetup.Iid;

            var readOutput = new List<Thing>
            {
                model,
                iteration
            };

            var readTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            readTaskCompletionSource.SetResult(readOutput);
            this.mockedDal.Setup(x => x.Read(It.IsAny<Iteration>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>())).Returns(readTaskCompletionSource.Task);

            var iterationToOpen = new CDP4Common.EngineeringModelData.Iteration(iteration.Iid, null, null);
            var modelToOpen = new CDP4Common.EngineeringModelData.EngineeringModel(model.Iid, null, null);
            iterationToOpen.Container = modelToOpen;

            this.session.Read(iterationToOpen, activeDomain).Wait();
            this.mockedDal.Verify(x => x.Read(It.Is<Iteration>(i => i.Iid == iterationToOpen.Iid), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Once);

            var pair = this.session.OpenIterations.Single();
            Assert.AreEqual(pair.Value.Item1, activeDomain);

            this.session.Read(iterationToOpen, activeDomain).Wait();
            this.mockedDal.Verify(x => x.Read(It.Is<Iteration>(i => i.Iid == iterationToOpen.Iid), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Exactly(2));

            pair = this.session.OpenIterations.Single();
            Assert.AreEqual(pair.Value.Item1, activeDomain);

            var selectedDomain = this.session.QuerySelectedDomainOfExpertise(iterationToOpen);
            Assert.AreEqual(activeDomain.Iid, selectedDomain.Iid);

            this.mockedDal.Setup(x => x.Read(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>())).Returns<Thing, CancellationToken, IQueryAttributes>(
                (x, y, z) =>
                {
                    // the method with iteration is called
                    var xvariable = x;
                    return readTaskCompletionSource.Task;
                });

            this.session.Refresh().Wait();
            this.mockedDal.Verify(x => x.Read<Thing>(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Exactly(1));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.session.Read(iterationToOpen, null));
        }
    

        [Test]
        public void VeriyThatCDPVersionIsSet()
        {
            var testDal = new TestDal();
            var credentials = new Credentials("John", "Doe", this.uri);

            this.session = new Session(testDal, credentials);
            var version = new Version("1.1.0");
            
            Assert.AreEqual(version.Major, this.session.DalVersion.Major);
            Assert.AreEqual(version.Minor, this.session.DalVersion.Minor);
            Assert.AreEqual(version.Build, this.session.DalVersion.Build);
        }

        [Test]
        public void VerifyThatIsVersionSupportedReturnsExpectedResult()
        {
            var testDal = new TestDal();
            var credentials = new Credentials("John", "Doe", this.uri);
            this.session = new Session(testDal, credentials);

            var supportedVersion = new Version("1.0.0");
            Assert.IsTrue(this.session.IsVersionSupported(supportedVersion));

            supportedVersion = new Version("1.1.0");
            Assert.IsTrue(this.session.IsVersionSupported(supportedVersion));

            var notSupportedVersion = new Version("2.0.0");
            Assert.IsFalse(this.session.IsVersionSupported(notSupportedVersion));
        }
    }

    //[DalExport("test dal", "test dal description", "1.1.0", DalType.Web)]
    internal class TestDal : IDal
    {
        public Version SupportedVersion { get {return new Version(1, 0, 0);} }
        public Version DalVersion { get {return new Version("1.1.0");} }
        public IMetaDataProvider MetaDataProvider { get {return new MetaDataProvider();} }

        /// <summary>
        /// Gets or sets the <see cref="ISession"/> that uses this <see cref="IDal"/>
        /// </summary>
        public ISession Session { get; set; }

        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainers, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the data related to the provided <see cref="Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/>.
        /// In case the 
        /// <param name="thing">
        /// </param>
        /// is a top container then all the <see cref="Thing"/>s that have been updated since the
        /// last read will be returned.
        /// </returns>
        public Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken cancellationToken, IQueryAttributes attributes = null) where T : Thing
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the data related to the provided <see cref="Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="Iteration"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        public Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates the specified <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been created.
        /// </returns>
        public IEnumerable<Thing> Create<T>(T thing) where T : Thing
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Performs an update to the <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be updated
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated.
        /// </returns>
        public IEnumerable<Thing> Update<T>(T thing) where T : Thing
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified <see cref="Thing"/> from the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be deleted
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public IEnumerable<Thing> Delete<T>(T thing) where T : Thing
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Opens a connection to a data-source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> that the services return when connecting to the <see cref="SiteDirectory"/>.
        /// </returns>
        public Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes the connection to the data-source.
        /// </summary>
        public void Close()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>
        /// </param>
        /// <returns>
        /// true when valid, false when invalid
        /// </returns>
        public bool IsValidUri(string uri)
        {
            throw new NotImplementedException();
        }
    }
}