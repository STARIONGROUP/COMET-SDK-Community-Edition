// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.NetCore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Dal.Composition;
    using CDP4Dal.Operations;
    using CDP4Dal.DAL;
    using CDP4Dal.Events;
    using CDP4Dal.Exceptions;

    using CDP4DalCommon.Authentication;
    using CDP4DalCommon.Tasks;

    using Moq;
    
    using NUnit.Framework;
    
    using DomainOfExpertise = CDP4Common.SiteDirectoryData.DomainOfExpertise;
    using EngineeringModelSetup = CDP4Common.DTO.EngineeringModelSetup;
    using ModelReferenceDataLibrary = CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary;
    using Person = CDP4Common.SiteDirectoryData.Person;
    using SiteDirectory = CDP4Common.DTO.SiteDirectory;
    using SiteReferenceDataLibrary = CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary;
    using TelephoneNumber = CDP4Common.SiteDirectoryData.TelephoneNumber;
    using TextParameterType = CDP4Common.DTO.TextParameterType;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// Suite of tests for the <see cref="Session"/> class
    /// </summary>
    [TestFixture]
    public class SessionTestFixture
    {
        private Mock<IDal> mockedDal;

        private List<Thing> dalOutputs;

        private Uri uri;

        private Session session;

        private CDP4Common.DTO.Person person;

        private CDP4Common.DTO.SiteDirectory sieSiteDirectoryDto;

        private CDPMessageBus messageBus;

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

            this.uri = new Uri("http://www.stariongroup.eu/");
            var credentials = new Credentials("John", "Doe", this.uri);

            this.mockedDal = new Mock<IDal>();
            this.mockedDal.SetupProperty(d => d.Session);

            this.messageBus = new CDPMessageBus();

            this.session = new Session(this.mockedDal.Object, credentials, this.messageBus);

            var openTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            openTaskCompletionSource.SetResult(this.dalOutputs);
            this.mockedDal.Setup(x => x.Open(It.IsAny<Credentials>(), It.IsAny<CancellationToken>())).Returns(openTaskCompletionSource.Task);
        }

        [TearDown]
        public void TearDown()
        {
            this.messageBus.ClearSubscriptions();
        }

        [Test]
        public async Task VerifythatOpenCallAssemblerSynchronizeWithDtos()
        {
            var eventReceived = false;
            this.messageBus.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            await this.session.Open();

            Assert.That(eventReceived, Is.True);
        }

        [Test]
        public async Task VerifyThatWriteWithEmptyResponseSendsMessages()
        {
            var beginUpdateReceived = false;
            var endUpdateReceived = false;

            var writeWithNoResultsTaskCompletionSource = new TaskCompletionSource<IEnumerable<Thing>>();
            writeWithNoResultsTaskCompletionSource.SetResult(new List<Thing>());
            this.mockedDal.Setup(x => x.Open(It.IsAny<Credentials>(), It.IsAny<CancellationToken>())).Returns(writeWithNoResultsTaskCompletionSource.Task);

            this.messageBus.Listen<SessionEvent>()                
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

            var context = $"/SiteDirectory/{Guid.NewGuid()}";

            var johnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.GetType().GetProperty("ActivePerson").SetValue(session, johnDoe, null);
            await this.session.Write(new OperationContainer(context));

            Assert.That(beginUpdateReceived, Is.True);
            Assert.That(endUpdateReceived, Is.True);
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

            this.messageBus.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            // refresh shouldnt do anything
            await this.session.Refresh();

            Assert.That(eventReceived, Is.False);
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

            this.messageBus.Listen<ObjectChangedEvent>(typeof(TelephoneNumber)).Subscribe(x =>
            {
                eventReceived = true;
            });

            await this.session.Reload();

            Assert.That(eventReceived, Is.True);
        }

        /// <summary>
        /// The verify that get active person works.
        /// </summary>
        [Test]
        public async Task VerifyThatGetActivePersonWorks()
        {
            await this.session.Open();

            var activePerson = this.session.ActivePerson;
            Assert.That(activePerson, Is.Not.Null);
            Assert.That("John", Is.EqualTo(activePerson.ShortName));
        }

        [Test]
        public async Task VerifyThatOpenSiteRDLUpdatesListInSession()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory() { Iid = Guid.NewGuid() };
            var requiredPocoDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredPocoRdl = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary(requiredPocoDto.Iid, null, null);
            rdlDto.RequiredRdl = requiredPocoDto.Iid;

            var credentials = new Credentials("admin", "pass", new Uri("http://www.stariongroup.eu"));
            var session2 = new Session(this.mockedDal.Object, credentials, this.messageBus);
            var rdlPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary { Iid = rdlDto.Iid, Name = rdlDto.Name, ShortName = rdlDto.ShortName, Container = siteDir, RequiredRdl = requiredPocoRdl };
            var thingsToAdd = new List<Thing>() { siteDirDto, requiredPocoDto, rdlDto };

            session2.GetType().GetProperty("ActivePerson").SetValue(session2, JohnDoe, null);
            await session2.Assembler.Synchronize(thingsToAdd);

            Assert.That(session2.OpenReferenceDataLibraries, Is.Empty);

            await session2.Read(rdlPoco);

            Assert.That(2, Is.EqualTo(session2.OpenReferenceDataLibraries.ToList().Count));

            await session2.Close();
            Assert.That(session2.OpenReferenceDataLibraries, Is.Empty);
        }

        [Test]
        public async Task VerifyThatCloseRdlWorks()
        {
            var siteDirectoryPoco = new CDP4Common.SiteDirectoryData.SiteDirectory(this.sieSiteDirectoryDto.Iid, this.session.Assembler.Cache, this.uri);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            siteDirectoryPoco.Person.Add(JohnDoe);

            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var rdlPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary { Iid = rdlDto.Iid, Name = rdlDto.Name, ShortName = rdlDto.ShortName, Container = siteDirectoryPoco };
            
            var requiredSiteReferenceDataLibraryDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredSiteReferenceDataLibraryPoco = new CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary(requiredSiteReferenceDataLibraryDto.Iid, this.session.Assembler.Cache, this.uri);
            
            rdlDto.RequiredRdl = requiredSiteReferenceDataLibraryDto.Iid;
            rdlPoco.RequiredRdl = requiredSiteReferenceDataLibraryPoco;

            var thingsToAdd = new List<Thing>() { requiredSiteReferenceDataLibraryDto, rdlDto };

            session.GetType().GetProperty("ActivePerson").SetValue(session, JohnDoe, null);
            await session.Assembler.Synchronize(thingsToAdd);
            await session.Read(rdlPoco);
            Assert.That(2, Is.EqualTo(session.OpenReferenceDataLibraries.ToList().Count));

            Lazy<CDP4Common.CommonData.Thing> rdlPocoToClose;
            session.Assembler.Cache.TryGetValue(new CacheKey(rdlPoco.Iid, null), out rdlPocoToClose);
            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)rdlPocoToClose.Value);
            Assert.That(1, Is.EqualTo(session.OpenReferenceDataLibraries.ToList().Count));

            await session.Read(rdlPoco);
            Assert.That(2, Is.EqualTo(session.OpenReferenceDataLibraries.ToList().Count));

            session.Assembler.Cache.TryGetValue(new CacheKey(rdlPoco.Iid, null), out rdlPocoToClose);
            Lazy<CDP4Common.CommonData.Thing> requiredRdlToClose;
            session.Assembler.Cache.TryGetValue(new CacheKey(requiredSiteReferenceDataLibraryPoco.Iid, null), out requiredRdlToClose);
            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)requiredRdlToClose.Value);
            
            Assert.That(0, Is.EqualTo(session.OpenReferenceDataLibraries.ToList().Count));

            await session.CloseRdl((CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary)rdlPocoToClose.Value);
            Assert.That(0, Is.EqualTo(session.OpenReferenceDataLibraries.ToList().Count));
        }

        [Test]
        public async Task VerifyThatSiteRdlRequiredByModelRdlCannotBeClosed()
        {
            var rdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory { Iid = Guid.NewGuid() };
            var requiredRdlDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            rdlDto.RequiredRdl = requiredRdlDto.Iid;
            siteDirDto.SiteReferenceDataLibrary.Add(rdlDto.Iid);
            siteDirDto.SiteReferenceDataLibrary.Add(requiredRdlDto.Iid);
            
            siteDirDto.Person.Add(this.person.Iid);

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
                iteration,
                this.person
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

            var JohnDoe = this.session.RetrieveSiteDirectory().Person.Single(x => x.Iid == this.person.Iid);
            this.session.GetType().GetProperty("ActivePerson").SetValue(this.session, JohnDoe, null);

            await this.session.Read(iterationPoco, null);
            
            Assert.That(2, Is.EqualTo(this.session.OpenReferenceDataLibraries.Count()));

            Lazy<CDP4Common.CommonData.Thing> requiredRdlToClose;
            this.session.Assembler.Cache.TryGetValue(new CacheKey(requiredRdlDto.Iid, null), out requiredRdlToClose);

            await this.session.CloseRdl((SiteReferenceDataLibrary)requiredRdlToClose.Value);
            Assert.That(2, Is.EqualTo(this.session.OpenReferenceDataLibraries.Count()));
        }

        [Test]
        public async Task VerifyThatCloseModelRdlWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), null, null);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            var modelRdlDto = new CDP4Common.DTO.ModelReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var siteDirDto = new CDP4Common.DTO.SiteDirectory() { Iid = Guid.NewGuid() };
            var requiredPocoDto = new CDP4Common.DTO.SiteReferenceDataLibrary() { Iid = Guid.NewGuid() };
            var requiredPocoRdl = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);
            var containerEngModelSetupDto = new EngineeringModelSetup() { Iid = Guid.NewGuid() };
            var containerEngModelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup() { Iid = containerEngModelSetupDto.Iid };
            siteDir.Model.Add(containerEngModelSetup);
            modelRdlDto.RequiredRdl = requiredPocoDto.Iid;
            siteDir.Person.Add(JohnDoe);
            
            var credentials = new Credentials("admin", "pass", new Uri("http://www.stariongroup.eu"));
            var session2 = new Session(this.mockedDal.Object, credentials, this.messageBus);
            session2.GetType().GetProperty("ActivePerson").SetValue(session2, JohnDoe, null);

            var modelRdlPoco = new ModelReferenceDataLibrary { Iid = modelRdlDto.Iid, Name = modelRdlDto.Name, ShortName = modelRdlDto.ShortName, Container = containerEngModelSetup, RequiredRdl = requiredPocoRdl };
            var thingsToAdd = new List<Thing>() { siteDirDto, requiredPocoDto, containerEngModelSetupDto, modelRdlDto };

            await session2.Assembler.Synchronize(thingsToAdd);
            await session2.Read(modelRdlPoco);
            Assert.That(2, Is.EqualTo(session2.OpenReferenceDataLibraries.ToList().Count));

            Lazy<CDP4Common.CommonData.Thing> rdlPocoToClose;
            session2.Assembler.Cache.TryGetValue(new CacheKey(modelRdlPoco.Iid, null), out rdlPocoToClose);
            Assert.That(rdlPocoToClose, Is.Not.Null);
            await session2.CloseModelRdl((ModelReferenceDataLibrary)rdlPocoToClose.Value);

            // Checkt that closing a modelRDL doesn't close it's required SiteRDL
            Assert.That(1, Is.EqualTo(session2.OpenReferenceDataLibraries.ToList().Count));
            Assert.That(ClassKind.SiteReferenceDataLibrary, Is.EqualTo(session2.OpenReferenceDataLibraries.First().ClassKind));
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

            var credentials = new Credentials("admin", "pass", new Uri("http://www.stariongroup.eu"));
            var session2 = new Session(this.mockedDal.Object, credentials, this.messageBus);

            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup { Iid = iterationSetupDto.Iid, Container = containerEngModelSetup, IterationIid = iteration.Iid };
            var thingsToAdd = new List<Thing> { siteDirDto, requiredPocoDto, containerEngModelSetupDto, modelRdlDto, iterationSetupDto };

            await session2.Assembler.Synchronize(thingsToAdd);

            var lazyiteration = new Lazy<CDP4Common.CommonData.Thing>(() => iteration);
            session2.Assembler.Cache.GetOrAdd(new CacheKey(iterationDto.Iid, null), lazyiteration);

            CDP4Common.CommonData.Thing changedObject = null;
            this.messageBus.Listen<ObjectChangedEvent>(typeof(CDP4Common.EngineeringModelData.Iteration)).Subscribe(x => changedObject = x.ChangedThing);
            await session2.CloseIterationSetup(iterationSetup);
            Assert.That(changedObject, Is.Not.Null);
        }

        [Test]
        public async Task VerifyThatReadRdlWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.Assembler.Cache.TryAdd(new CacheKey(siteDir.Iid, null),
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

            this.session.GetType().GetProperty("ActivePerson").SetValue(this.session, JohnDoe, null);
            await this.session.Read(srdl);

            Assert.That(1, Is.EqualTo(this.session.OpenReferenceDataLibraries.Count()));
            Assert.That(siteDir.SiteReferenceDataLibrary.Any(), Is.True);
        }

        [Test]
        public async Task Verify_that_EngineeringModel_returns_result()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
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
            siteDir.Person.Add(JohnDoe);

            var engineeringModel = new CDP4Common.DTO.EngineeringModel(Guid.NewGuid(), 1)
            {
                EngineeringModelSetup = modelSetup.Iid
            };

            modelSetup.EngineeringModelIid = engineeringModel.Iid;
            var dalResult = new List<CDP4Common.DTO.EngineeringModel>() { engineeringModel };

            this.mockedDal.Setup(x => x.Read(It.IsAny<IEnumerable<CDP4Common.DTO.EngineeringModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(dalResult);

            this.session.Assembler.Cache.TryAdd(new CacheKey(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new CacheKey(JohnDoe.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => JohnDoe));
            this.session.Assembler.Cache.TryAdd(new CacheKey(modelSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => modelSetup));
            this.session.Assembler.Cache.TryAdd(new CacheKey(mrdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => mrdl));
            this.session.Assembler.Cache.TryAdd(new CacheKey(srdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => srdl));
            this.session.Assembler.Cache.TryAdd(new CacheKey(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new CacheKey(iterationSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => iterationSetup));

            this.session.GetType().GetProperty("ActivePerson").SetValue(this.session, JohnDoe, null);

            var iids = new List<Guid>();

            await this.session.Read(iids);

            Assert.That(this.session.Assembler.Cache.ContainsKey(new CacheKey(engineeringModel.Iid, null)), Is.True); 
        }

        [Test]
        public async Task VerifyThatReadIterationWorks()
        {
            var siteDir = new CDP4Common.SiteDirectoryData.SiteDirectory(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            var JohnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) {ShortName = "John"};
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
            siteDir.Person.Add(JohnDoe);

            this.session.Assembler.Cache.TryAdd(new CacheKey(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new CacheKey(JohnDoe.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => JohnDoe));
            this.session.Assembler.Cache.TryAdd(new CacheKey(modelSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => modelSetup));
            this.session.Assembler.Cache.TryAdd(new CacheKey(mrdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => mrdl));
            this.session.Assembler.Cache.TryAdd(new CacheKey(srdl.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => srdl));
            this.session.Assembler.Cache.TryAdd(new CacheKey(siteDir.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => siteDir));
            this.session.Assembler.Cache.TryAdd(new CacheKey(iterationSetup.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => iterationSetup));

            this.session.GetType().GetProperty("ActivePerson").SetValue(this.session, JohnDoe, null);

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
            
            await this.session.Read(iterationToOpen, activeDomain);
            this.mockedDal.Verify(x => x.Read(It.Is<Iteration>(i => i.Iid == iterationToOpen.Iid), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Once);

            var pair = this.session.OpenIterations.Single();
            Assert.That(pair.Value.Item1, Is.EqualTo(activeDomain));

            await this.session.Read(iterationToOpen, activeDomain);
            this.mockedDal.Verify(x => x.Read(It.Is<Iteration>(i => i.Iid == iterationToOpen.Iid), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Exactly(2));

            pair = this.session.OpenIterations.Single();
            Assert.That(pair.Value.Item1, Is.EqualTo(activeDomain));

            var selectedDomain = this.session.QuerySelectedDomainOfExpertise(iterationToOpen);
            Assert.That(activeDomain.Iid, Is.EqualTo(selectedDomain.Iid));

            this.mockedDal.Setup(x => x.Read(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>())).Returns<Thing, CancellationToken, IQueryAttributes>(
                (x, y, z) =>
                {
                    // the method with iteration is called
                    var xvariable = x;
                    return readTaskCompletionSource.Task;
                });

            await this.session.Refresh();
            this.mockedDal.Verify(x => x.Read<Thing>(It.IsAny<Thing>(), It.IsAny<CancellationToken>(), It.IsAny<IQueryAttributes>()), Times.Exactly(1));

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.session.Read(iterationToOpen, null));
        }

        [Test]
        public void Verify_that_when_active_person_is_null_Iteration_is_not_read()
        {
            var iterationSetup = new CDP4Common.SiteDirectoryData.IterationSetup(Guid.NewGuid(), null, null) { FrozenOn = DateTime.Now, IterationIid = Guid.NewGuid() };
            var activeDomain = new DomainOfExpertise(Guid.NewGuid(), null, null);
            var model = new EngineeringModel(Guid.NewGuid(), 1);
            var iteration = new Iteration(Guid.NewGuid(), 10) { IterationSetup = iterationSetup.Iid };
            
            var iterationToOpen = new CDP4Common.EngineeringModelData.Iteration(iteration.Iid, null, null);
            var modelToOpen = new CDP4Common.EngineeringModelData.EngineeringModel(model.Iid, null, null);
            iterationToOpen.Container = modelToOpen;

            Assert.ThrowsAsync<InvalidOperationException>(async () => await this.session.Read(iterationToOpen, activeDomain));
        }

        [Test]
        public void VeriyThatCDPVersionIsSet()
        {
            var testDal = new TestDal();
            var credentials = new Credentials("John", "Doe", this.uri);

            this.session = new Session(testDal, credentials, this.messageBus);
            var version = new Version("1.1.0");
            
            Assert.That(version.Major, Is.EqualTo(this.session.DalVersion.Major));
            Assert.That(version.Minor, Is.EqualTo(this.session.DalVersion.Minor));
            Assert.That(version.Build, Is.EqualTo(this.session.DalVersion.Build));
        }

        [Test]
        public void VerifyThatIsVersionSupportedReturnsExpectedResult()
        {
            var testDal = new TestDal();
            var credentials = new Credentials("John", "Doe", this.uri);
            this.session = new Session(testDal, credentials, this.messageBus);

            var supportedVersion = new Version("1.0.0");
            Assert.That(this.session.IsVersionSupported(supportedVersion), Is.True);

            supportedVersion = new Version("1.1.0");
            Assert.That(this.session.IsVersionSupported(supportedVersion), Is.True);

            var notSupportedVersion = new Version("2.0.0");
            Assert.That(this.session.IsVersionSupported(notSupportedVersion), Is.False);
        }

        [Test]
        public async Task VerifyThatWriteWorksWithoutEventHandler()
        {
            var context = $"/SiteDirectory/{Guid.NewGuid()}";
            var johnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.GetType().GetProperty("ActivePerson")?.SetValue(this.session, johnDoe, null);
            await this.session.Write(new OperationContainer(context));

            this.mockedDal.Verify(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<IEnumerable<string>>()), Times.Exactly(1));
        }

        [Test]
        public async Task VerifyThatWriteWorksWithEventHandler()
        {
            var context = $"/SiteDirectory/{Guid.NewGuid()}";
            var johnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.GetType().GetProperty("ActivePerson")?.SetValue(this.session, johnDoe, null);

            this.session.BeforeWrite += (o, args) =>
            {
                args.Cancelled = false;
            };

            await this.session.Write(new OperationContainer(context));

            this.mockedDal.Verify(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<IEnumerable<string>>()), Times.Exactly(1));
        }

        [Test]
        public void VerifyThatCancelWriteWorks()
        {
            var context = $"/SiteDirectory/{Guid.NewGuid()}";
            var johnDoe = new CDP4Common.SiteDirectoryData.Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.GetType().GetProperty("ActivePerson")?.SetValue(this.session, johnDoe, null);

            this.session.BeforeWrite += (o, args) =>
            {
                args.Cancelled = true;
            };

            Assert.ThrowsAsync<OperationCanceledException>(async () => await this.session.Write(new OperationContainer(context)));

            this.mockedDal.Verify(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<IEnumerable<string>>()), Times.Exactly(0));
        }

        [Test]
        public async Task VerifyCanReadCometTask()
        {
            var cometTaskId = Guid.NewGuid();

            Assert.Multiple(() =>
            {
                Assert.That(this.session.ActivePerson, Is.Null);
                Assert.That(() => this.session.ReadCometTask(cometTaskId), Throws.InvalidOperationException);
            });

            this.AssignActivePerson();

            var returnedCometTask = new CometTask()
            {
                Id = cometTaskId
            };

            this.mockedDal.Setup(x => x.ReadCometTask(cometTaskId, It.IsAny<CancellationToken>())).ReturnsAsync(returnedCometTask);

            var cometTask = await this.session.ReadCometTask(cometTaskId);

            Assert.Multiple(() =>
            {
                Assert.That(cometTask, Is.Not.Null);
                Assert.That(cometTask, Is.EqualTo(returnedCometTask));
                Assert.That(this.session.CometTasks[cometTaskId], Is.EqualTo(returnedCometTask));
            });

            this.mockedDal.Setup(x => x.ReadCometTask(cometTaskId, It.IsAny<CancellationToken>())).Throws<OperationCanceledException>();
            cometTask = await this.session.ReadCometTask(cometTaskId);

            Assert.Multiple(() =>
            {
                Assert.That(cometTask, Is.EqualTo((CometTask)default));
                Assert.That(this.session.CometTasks[cometTaskId], Is.EqualTo(returnedCometTask));
            });

            this.mockedDal.Setup(x => x.ReadCometTask(cometTaskId, It.IsAny<CancellationToken>())).Throws<DalReadException>();
            Assert.That(() => this.session.ReadCometTask(cometTaskId), Throws.Exception.TypeOf<DalReadException>());
        }

        [Test]
        public async Task VerifyCanReadCometTasks()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.session.ActivePerson, Is.Null);
                Assert.That(() => this.session.ReadCometTasks(), Throws.InvalidOperationException);
            });

            this.AssignActivePerson();

            var returnedCometTasks = new List<CometTask>()
            {
                new ()
                {
                    Id = Guid.NewGuid()
                },
                new ()
                {
                    Id = Guid.NewGuid()
                },
            };

            this.mockedDal.Setup(x => x.ReadCometTasks(It.IsAny<CancellationToken>())).ReturnsAsync(returnedCometTasks);

            var cometTasks = await this.session.ReadCometTasks();

            Assert.Multiple(() =>
            {
                Assert.That(cometTasks, Is.Not.Empty);
                Assert.That(cometTasks, Is.EquivalentTo(returnedCometTasks));
                Assert.That(this.session.CometTasks, Has.Count.EqualTo(returnedCometTasks.Count));
            });

            this.mockedDal.Setup(x => x.ReadCometTasks(It.IsAny<CancellationToken>())).Throws<OperationCanceledException>();
            cometTasks = await this.session.ReadCometTasks();

            Assert.Multiple(() =>
            {
                Assert.That(cometTasks, Is.Empty);
                Assert.That(this.session.CometTasks, Has.Count.EqualTo(returnedCometTasks.Count));
            });

            this.mockedDal.Setup(x => x.ReadCometTasks(It.IsAny<CancellationToken>())).Throws<DalReadException>();
            Assert.That(() => this.session.ReadCometTasks(), Throws.Exception.TypeOf<DalReadException>());
        }

        [Test]
        public async Task VerifyWritePossibleLongRunningTask()
        {
            var context = $"/SiteDirectory/{Guid.NewGuid()}";
            this.AssignActivePerson();

            this.mockedDal.Setup(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(new LongRunningTaskResult(new CometTask() { Id = Guid.Empty }));
            
            var cometTask = await this.session.Write(new OperationContainer(context), 1);

            Assert.Multiple(() =>
            {
                Assert.That(cometTask.HasValue, Is.True);
                Assert.That(this.session.CometTasks, Is.Not.Empty);
            });

            this.mockedDal.Setup(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>()))
                .ReturnsAsync(new LongRunningTaskResult(new List<Thing>()
                {
                    new TextParameterType()
                    {
                        Iid = Guid.NewGuid()
                    }
                }));

            cometTask = await this.session.Write(new OperationContainer(context), 1);

            Assert.Multiple(() =>
            {
                Assert.That(cometTask.HasValue, Is.False);
                Assert.That(this.session.CometTasks, Is.Not.Empty);
            });

            this.mockedDal.Setup(x => x.Write(It.IsAny<OperationContainer>(), It.IsAny<int>(), It.IsAny<IEnumerable<string>>()))
                .ThrowsAsync(new DalReadException());

            Assert.That(() =>this.session.Write(new OperationContainer(context), 1), Throws.Exception.TypeOf<DalReadException>());
        }

        [Test]
        public async Task VerifyQueryAuthenticatedUserName()
        {
            var temporaryCredentials = new Credentials(this.uri);
            var multipleAuthSchemeSession = new Session(this.mockedDal.Object, temporaryCredentials, this.messageBus);
            
            await Assert.ThatAsync(() => multipleAuthSchemeSession.QueryAuthenticatedUserName(), Throws.InvalidOperationException);
            temporaryCredentials.ProvideUserToken(new AuthenticationTokens("token", "refreshToken"), AuthenticationSchemeKind.ExternalJwtBearer);

            this.mockedDal.Setup(x => x.QueryAuthenticatedUserName(It.IsAny<CancellationToken>())).ReturnsAsync("user");

            await Assert.ThatAsync(() => multipleAuthSchemeSession.QueryAuthenticatedUserName(), Is.EqualTo("user"));
            this.AssignActivePerson();
            
            await Assert.ThatAsync(() => this.session.QueryAuthenticatedUserName(), Is.EqualTo("John"));
        }
        
        private void AssignActivePerson()
        {
            var johnDoe = new Person(this.person.Iid, this.session.Assembler.Cache, this.uri) { ShortName = "John" };
            this.session.GetType().GetProperty("ActivePerson")?.SetValue(this.session, johnDoe, null);
        }
    }

    [DalExport("test dal", "test dal description", "1.1.0", DalType.Web)]
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
        /// <param name="operationContainers">
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
        /// <param name="files">
        /// the files that are to be written
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
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
        public Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null)
        {
            throw new System.NotImplementedException();
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
        /// Reads the <see cref="EngineeringModel"/> instances from the data-source
        /// </summary>
        /// <param name="engineeringModels">
        /// The <see cref="EngineeringModel"/>s that needs to be read from the data-source, in case the list is empty
        /// all the <see cref="EngineeringModel"/>s will be read
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A list of <see cref="EngineeringModel"/>s
        /// </returns>
        /// <remarks>
        /// Only those <see cref="EngineeringModel"/>s are retunred that the <see cref="Person"/> is a <see cref="Participant"/> in
        /// </remarks>
        public Task<IEnumerable<EngineeringModel>> Read(IEnumerable<EngineeringModel> engineeringModels, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="System.Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="CDP4Common.DTO.Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> ReadFile(Thing localFile, CancellationToken cancellationToken)
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

        /// <summary>
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="Iteration"/> that match provided <see cref="CDP4Common.DTO.Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="System.Guid"/> of the <see cref="EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="System.Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="CDP4Common.DTO.Category"/> <see cref="System.Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken"/></param>
        /// <returns>A <see cref="System.Threading.Tasks.Task{TResult}" /> of type <see cref="System.Collections.Generic.IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds, IEnumerable<Guid> categoriesId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Requests to retrieve all available <see cref="AuthenticationSchemeKind" /> available on the datasource
        /// </summary>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <returns>An awaitable <see cref="System.Threading.Tasks.Task{TResult}"/> that contains the value of the queried <see cref="AuthenticationSchemeResponse" /></returns>
        public Task<AuthenticationSchemeResponse> RequestAvailableAuthenticationScheme(CancellationToken cancellationToken)
        {
            return Task.FromResult(new AuthenticationSchemeResponse()
            {
                Schemes = [AuthenticationSchemeKind.Basic]
            });
        }

        /// <summary>
        /// Initializes this <see cref="Dal" /> with created <see cref="Dal.Credentials" />. 
        /// </summary>
        /// <param name="credentials">The <see cref="Dal.Credentials"/></param>
        /// <remarks>To be used in case of multiple-step authentication, requires to be able to support multiple Authentication scheme</remarks>
        public void InitializeDalCredentials(Credentials credentials)
        {
        }

        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken"/></param>
        /// <remarks>This method should be used when using a CDP4-COMET WebServices and that it provides LocalJwtBearer authentication flow</remarks>
        public Task Login(string userName, string password, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Applies Authentication information based on the <see cref="Dal.Credentials" /> 
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials" /></param>
        public void ApplyAuthenticationCredentials(Credentials credentials)
        {
        }

        /// <summary>
        /// Queries the shortname of the authenticated User
        /// </summary>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken"/></param>
        /// <returns>A <see cref="System.Threading.Tasks.Task{TResult}"/> that contains the retrieved user shortname</returns>
        public Task<string> QueryAuthenticatedUserName(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        
        /// <summary>
        /// Requests new <see cref="AuthenticationTokens" /> based on the current refresh token
        /// </summary>
        /// <returns>An awaitabl <see cref="System.Threading.Tasks.Task" /></returns>
        /// <param name="cancellationToken">The <see cref="System.Threading.CancellationToken" /></param>
        /// <exception cref="System.InvalidOperationException">If the current <see cref="Dal.Credentials" /> does not meet following constraints : not null, with non-null <see cref="AuthenticationTokens" />
        ///  containing a refresh token and where the <see cref="AuthenticationSchemeKind" /> is <see cref="AuthenticationSchemeKind.LocalJwtBearer" /></exception>
        /// <exception cref="DalReadException">In case of non successful response from the CDP4 Data source</exception>
        public Task RequestAuthenticationTokenFromRefreshToken(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}