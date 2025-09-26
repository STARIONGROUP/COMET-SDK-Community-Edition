// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionServiceTestFixtures.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Web.Tests.Services.SessionService
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Reactive.Linq;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4Web.Enumerations;
    using CDP4Web.Extensions;
    using CDP4Web.Services.SessionService;

    using MELT;

    using Microsoft.Extensions.Logging;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class SessionServiceTestFixtures
    {
        private readonly Uri uri = new("http://test.com");
        private Assembler assembler;
        private DomainOfExpertise domain;
        private EngineeringModelSetup engineeringSetup;
        private Iteration iteration;
        private ITestLoggerFactory logger;
        private ConcurrentDictionary<Iteration, Tuple<DomainOfExpertise, Participant>> openIteration;
        private Participant participant;
        private Person person;
        private ModelReferenceDataLibrary referenceDataLibrary;
        private Mock<ISession> session;
        private SessionService sessionService;
        private SiteDirectory siteDirectory;
        private CDPMessageBus messageBus;

        [SetUp]
        public void Setup()
        {
            this.logger = TestLoggerFactory.Create();
            this.session = new Mock<ISession>();
            this.messageBus = new CDPMessageBus();

            this.sessionService = new SessionService(this.logger.CreateLogger<SessionService>(), this.messageBus)
            {
                Session = this.session.Object
            };

            this.assembler = new Assembler(this.uri, this.messageBus);
            this.domain = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.person = new Person(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.participant = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                Person = this.person,
            };

            this.participant.Domain.Add(this.domain);

            this.referenceDataLibrary = new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                ShortName = "ARDL"
            };

            this.engineeringSetup = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                RequiredRdl =
                {
                    this.referenceDataLibrary,
                    new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri)
                    {
                        FileType =
                        {
                            new FileType(Guid.NewGuid(), this.assembler.Cache, this.uri) { Extension = "tar" },
                            new FileType(Guid.NewGuid(), this.assembler.Cache, this.uri) { Extension = "gz" },
                            new FileType(Guid.NewGuid(), this.assembler.Cache, this.uri) { Extension = "zip" }
                        }
                    }
                },
                Participant = { this.participant }
            };

            var iterationId = Guid.NewGuid();

            this.iteration = new Iteration(iterationId, this.assembler.Cache, this.uri)
            {
                Container = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri)
                {
                    EngineeringModelSetup = this.engineeringSetup
                },
                IterationSetup = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri)
                {
                    IterationIid = iterationId
                },
                DomainFileStore =
                {
                    new DomainFileStore(Guid.NewGuid(), this.assembler.Cache, this.uri) { Owner = this.domain }
                }
            };

            this.assembler.Cache[this.iteration.CacheKey] = new Lazy<Thing>(this.iteration);
            this.assembler.Cache[this.iteration.DomainFileStore[0].CacheKey] = new Lazy<Thing>(this.iteration.DomainFileStore[0]);
            this.assembler.Cache[this.iteration.IterationSetup.CacheKey] = new Lazy<Thing>(this.iteration.IterationSetup);
            this.assembler.Cache[this.iteration.Container.CacheKey] = new Lazy<Thing>(this.iteration.Container);

            this.engineeringSetup.IterationSetup.Add(this.iteration.IterationSetup);

            this.openIteration = new ConcurrentDictionary<Iteration, Tuple<DomainOfExpertise, Participant>>();

            this.siteDirectory = new SiteDirectory(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                Model = { this.engineeringSetup, new EngineeringModelSetup() { IterationSetup = { new IterationSetup() } } }
            };

            this.siteDirectory.Person.Add(this.person);
            this.siteDirectory.Organization.Add(new Organization());
            this.siteDirectory.PersonRole.Add(new PersonRole());
            this.siteDirectory.Domain.Add(this.domain);

            this.session.Setup(x => x.Assembler).Returns(this.assembler);
            this.session.Setup(x => x.OpenIterations).Returns(this.openIteration);
            this.session.Setup(x => x.Credentials).Returns(new Credentials("admin", "pass", this.uri));
            this.session.Setup(x => x.ActivePerson).Returns(this.person);
        }

        [TearDown]
        public void Teardown()
        {
            this.messageBus.ClearSubscriptions();
        }

        [Test]
        public void VerifyProperties()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.sessionService.OpenedIterations, Is.Empty);
                Assert.That(this.sessionService.OpenedEngineeringModels, Is.Empty);
            });

            this.SetIsSessionOpen();
            this.openIteration[this.iteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant);

            Assert.Multiple(() =>
            {
                Assert.That(this.sessionService.OpenedIterations, Has.Count.EqualTo(1));
                Assert.That(this.sessionService.OpenedEngineeringModels, Has.Count.EqualTo(1));
            });

            var newIteration = new Iteration()
            {
                Container = this.iteration.Container
            };

            this.openIteration[newIteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant);

            Assert.Multiple(() =>
            {
                Assert.That(this.sessionService.OpenedIterations, Has.Count.EqualTo(2));
                Assert.That(this.sessionService.OpenedEngineeringModels, Has.Count.EqualTo(1));
            });
        }

        [Test]
        [Category("WebServicesDependent")]
        public void VerifyOpenSession()
        {
            const string publicServerUrl = "https://cdp4services-test.cdp4.org";

            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.OpenSession("", "", ""), Throws.Exception);
                Assert.That(() => this.sessionService.OpenSession("a", "", ""), Throws.Exception);
                Assert.That(() => this.sessionService.OpenSession("a", "p", ""), Throws.Exception);
                Assert.That(() => this.sessionService.OpenSession("admin", "pass", "something"), Throws.Exception);
                Assert.That(() => this.sessionService.OpenSession("admin", "pass", "http://a.com"), Throws.Nothing);
                Assert.That(this.sessionService.IsSessionOpen, Is.False);
                Assert.That(async () => (await this.sessionService.OpenSession("admin", "pass", publicServerUrl)).IsSuccess, Is.True);
                Assert.That(this.sessionService.IsSessionOpen, Is.True);
                Assert.That(async () => (await this.sessionService.OpenSession("admin", "pas", publicServerUrl)).IsSuccess, Is.False);
                Assert.That(this.sessionService.IsSessionOpen, Is.False);
                Assert.That(() => this.sessionService.OpenSession(new Credentials("", "", this.uri)), Throws.Exception);
                Assert.That(() => this.sessionService.OpenSession(new Credentials("a", "", this.uri)), Throws.Exception);
            });
        }

        [Test]
        public async Task VerifyOpenIteration()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.OpenIteration(null, null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.OpenIteration(this.iteration.IterationSetup, null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.OpenIteration(this.iteration.IterationSetup, this.domain), Throws.InvalidOperationException);
                Assert.That(() => this.sessionService.OpenActiveIteration(null, this.domain), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.OpenActiveIteration(this.engineeringSetup, null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.OpenActiveIteration(this.engineeringSetup, this.domain), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();

            var openIterationResult = await this.sessionService.OpenIteration(this.iteration.IterationSetup, this.domain);
            Assert.That(openIterationResult.IsSuccess, Is.False);

            this.session.Setup(x => x.Read(It.IsAny<Iteration>(), It.IsAny<DomainOfExpertise>(), true))
                .Callback(() => { this.openIteration[this.iteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant); });

            openIterationResult = await this.sessionService.OpenIteration(this.iteration.IterationSetup, this.domain);
            Assert.That(openIterationResult.IsSuccess, Is.True);

            this.session.Setup(x => x.Read(It.IsAny<Iteration>(), It.IsAny<DomainOfExpertise>(), true))
                .ThrowsAsync(new InvalidOperationException());

            openIterationResult = await this.sessionService.OpenIteration(this.iteration.IterationSetup, this.domain);
            Assert.That(openIterationResult.IsSuccess, Is.False);

            this.session.Setup(x => x.Read(It.IsAny<Iteration>(), It.IsAny<DomainOfExpertise>(), true))
                .ThrowsAsync(new DalReadException());

            openIterationResult = await this.sessionService.OpenIteration(this.iteration.IterationSetup, this.domain);
            Assert.That(openIterationResult.IsSuccess, Is.False);
        }

        [Test]
        public async Task VerifyCloseIteration()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.CloseIteration(null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.CloseIteration(this.iteration), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();

            var isIterationClose = false;

            this.messageBus.Listen<SessionServiceEvent>(this.session.Object).Where(x => x == SessionServiceEvent.IterationClosed)
                .Subscribe(_ => isIterationClose = true);

            Assert.That(isIterationClose, Is.False);

            await this.sessionService.CloseIteration(this.iteration);

            Assert.Multiple(() =>
            {
                Assert.That(isIterationClose, Is.True);
                this.session.Verify(x => x.CloseIterationSetup(this.iteration.IterationSetup), Times.Once);
            });
        }

        [Test]
        public async Task VerifyCloseIterations()
        {
            this.SetIsSessionOpen();
            var closedIterationsCount = 0;

            this.messageBus.Listen<SessionServiceEvent>(this.session.Object).Where(x => x == SessionServiceEvent.IterationClosed)
                .Subscribe(_ => closedIterationsCount++);

            await this.sessionService.CloseIterations();

            Assert.Multiple(() =>
            {
                Assert.That(closedIterationsCount, Is.EqualTo(0));
                this.session.Verify(x => x.CloseIterationSetup(It.IsAny<IterationSetup>()), Times.Never);
            });

            this.openIteration[this.iteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant);

            var newIteration = new Iteration()
            {
                IterationSetup = new IterationSetup()
            };

            this.openIteration[newIteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant);

            await this.sessionService.CloseIterations();

            Assert.Multiple(() =>
            {
                Assert.That(closedIterationsCount, Is.EqualTo(2));
                this.session.Verify(x => x.CloseIterationSetup(It.IsAny<IterationSetup>()), Times.Exactly(2));
            });
        }

        [Test]
        public void VerifyGetParticipantModels()
        {
            Assert.That(this.sessionService.GetParticipantModels(), Is.Empty);

            this.SetIsSessionOpen();
            Assert.That(this.sessionService.GetParticipantModels().Count(), Is.EqualTo(1));
        }

        [Test]
        public void VerifyGetAvailableModels()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.GetAvailableDomains(null), Throws.ArgumentNullException);
                Assert.That(this.sessionService.GetAvailableDomains(this.iteration.IterationSetup.Container as EngineeringModelSetup), Is.EquivalentTo(new[] { this.domain }));
                Assert.That(this.sessionService.GetAvailableDomains(this.siteDirectory.Model[1]), Is.Empty);
            });
        }

        [Test]
        public async Task VerifyRefresh()
        {
            await this.sessionService.RefreshSession();
            this.session.Verify(x => x.Refresh(), Times.Never);

            this.SetIsSessionOpen();
            await this.sessionService.RefreshSession();
            this.session.Verify(x => x.Refresh(), Times.Once);
        }

        [Test]
        public async Task VerifyReload()
        {
            await this.sessionService.ReloadSession();
            this.session.Verify(x => x.Reload(), Times.Never);

            this.SetIsSessionOpen();
            await this.sessionService.ReloadSession();
            this.session.Verify(x => x.Reload(), Times.Once);
        }

        [Test]
        public async Task VerifyClose()
        {
            this.session.Setup(x => x.Close()).Callback(() => { this.SetIsSessionOpen(false); });
            this.SetIsSessionOpen();

            Assert.Multiple(() =>
            {
                Assert.That(this.sessionService.IsSessionOpen, Is.True);
                Assert.That(this.logger.Sink.LogEntries, Is.Empty);
            });

            await this.sessionService.CloseSession();

            Assert.Multiple(() =>
            {
                Assert.That(this.sessionService.IsSessionOpen, Is.False);
                this.session.Verify(x => x.Close(), Times.Once);
                Assert.That(this.logger.Sink.LogEntries.Count(x => x.LogLevel == LogLevel.Information), Is.EqualTo(2));
                Assert.That(this.logger.Sink.LogEntries.Count(), Is.EqualTo(2));
            });
        }

        [Test]
        public void VerifyGetParticipant()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.GetParticipant(null), Throws.ArgumentNullException);
                Assert.That(this.sessionService.GetParticipant(this.iteration), Is.Null);
            });

            this.SetIsSessionOpen();

            Assert.That(this.sessionService.GetParticipant(this.iteration), Is.EqualTo(this.participant));

            var newIteration = new Iteration()
            {
                IterationSetup = this.siteDirectory.Model[1].IterationSetup[0]
            };

            Assert.That(this.sessionService.GetParticipant(newIteration), Is.Null);
        }

        [Test]
        public void VerifyGetDomainOfExpertise()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.GetDomainOfExpertise(null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.GetDomainOfExpertise(this.iteration), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();

            Assert.That(() => this.sessionService.GetDomainOfExpertise(this.iteration), Throws.ArgumentException);
            this.openIteration[this.iteration] = new Tuple<DomainOfExpertise, Participant>(this.domain, this.participant);

            Assert.That(this.sessionService.GetDomainOfExpertise(this.iteration), Is.EqualTo(this.domain));
        }

        [Test]
        public void VerifySwitchDomain()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.SwitchDomain(null, null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.SwitchDomain(this.iteration, null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.SwitchDomain(this.iteration, this.domain), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();
            this.sessionService.SwitchDomain(this.iteration, this.domain);

            this.session.Verify(x => x.SwitchDomain(this.iteration.Iid, this.domain), Times.Once);
        }

        [Test]
        public async Task VerifyCreateOrUpdateThings()
        {
            var thingsToAdd = new List<Thing>();

            var element = new ElementDefinition()
            {
                Iid = Guid.NewGuid()
            };

            var iterationCloned = this.iteration.Clone(false);
            iterationCloned.Element.Add(element);
            thingsToAdd.Add(element);

            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.CreateOrUpdateThings(this.iteration, null), Throws.Exception);
                Assert.That(() => this.sessionService.CreateOrUpdateThings(iterationCloned, null), Throws.Exception);
                Assert.That(() => this.sessionService.CreateOrUpdateThings(iterationCloned, new List<Thing>()), Throws.Exception);
                Assert.That(() => this.sessionService.CreateOrUpdateThings(iterationCloned, thingsToAdd), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();
            var result = await this.sessionService.CreateOrUpdateThings(iterationCloned, thingsToAdd);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                this.session.Verify(x => x.Write(It.IsAny<OperationContainer>()), Times.Once);
            });
        }

        [Test]
        public async Task VerifyDeleteThings()
        {
            var thingsToDelete = new List<Thing>();

            var iterationCloned = this.iteration.Clone(false);
            thingsToDelete.Add(iterationCloned.DomainFileStore[0]);

            iterationCloned.DomainFileStore.Clear();

            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.DeleteThings(this.iteration, null), Throws.Exception);
                Assert.That(() => this.sessionService.DeleteThings(iterationCloned, null), Throws.Exception);
                Assert.That(() => this.sessionService.DeleteThings(iterationCloned, new List<Thing>()), Throws.Exception);
                Assert.That(() => this.sessionService.DeleteThings(iterationCloned, thingsToDelete), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();

            Assert.That(() => this.sessionService.DeleteThings(iterationCloned, thingsToDelete), Throws.Exception);
            thingsToDelete.Clear();
            thingsToDelete.Add(this.iteration.DomainFileStore[0].Clone(false));

            var result = await this.sessionService.DeleteThings(iterationCloned, thingsToDelete);

            Assert.Multiple(() =>
            {
                Assert.That(result.IsSuccess, Is.True);
                this.session.Verify(x => x.Write(It.IsAny<OperationContainer>()), Times.Once);
            });
        }

        [Test]
        public async Task VerifyWriteTransaction()
        {
            var operationContainer = new OperationContainer(this.iteration.Route);

            Assert.Multiple(() =>
            {
                Assert.That(() => this.sessionService.WriteTransaction(null), Throws.ArgumentNullException);
                Assert.That(() => this.sessionService.WriteTransaction(operationContainer), Throws.InvalidOperationException);
            });

            this.SetIsSessionOpen();

            var result = await this.sessionService.WriteTransaction(operationContainer);

            Assert.Multiple(() =>
            {
                this.session.Verify(x => x.Write(operationContainer), Times.Once);
                Assert.That(result.IsSuccess, Is.True);
            });

            this.session.Setup(x => x.Write(operationContainer)).ThrowsAsync(new InvalidOperationException());
            result = await this.sessionService.WriteTransaction(operationContainer);

            Assert.Multiple(() =>
            {
                this.session.Verify(x => x.Write(operationContainer), Times.Exactly(2));
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors[0].Metadata[ReasonExtensions.Cdp4CometReasonIdentifier], Is.EqualTo(HttpStatusCode.Unauthorized));
            });

            this.session.Setup(x => x.Write(operationContainer)).ThrowsAsync(new DalWriteException());
            result = await this.sessionService.WriteTransaction(operationContainer);

            Assert.Multiple(() =>
            {
                this.session.Verify(x => x.Write(operationContainer), Times.Exactly(3));
                Assert.That(result.IsSuccess, Is.False);
                Assert.That(result.Errors[0].Metadata[ReasonExtensions.Cdp4CometReasonIdentifier], Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }

        private void SetIsSessionOpen(bool isSessionOpen = true)
        {
            this.session.Setup(x => x.RetrieveSiteDirectory()).Returns(isSessionOpen ? this.siteDirectory : null);
        }
    }
}
