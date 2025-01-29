// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpServicesDalTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.DAL.ECSS1025AnnexC;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Authentication;
    using CDP4DalCommon.Tasks;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using RichardSzalay.MockHttp;

    /// <summary>
    /// Suite of tests for the <see cref="CdpServicesDal"/> class
    /// </summary>
    [TestFixture]
    public class CdpServicesDalTestFixture
    {
        private CdpServicesDal dal;
        private Credentials credentials;
        private ISession session;

        private readonly Uri uri = new Uri("https://cdp4services-test.cdp4.org");
        private CancellationTokenSource cancelationTokenSource;

        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private EngineeringModelSetup engineeringModelSetup;
        private Iteration iteration;
        private IterationSetup iterationSetup;
        private SiteReferenceDataLibrary siteReferenceDataLibrary;
        private ModelReferenceDataLibrary modelReferenceDataLibrary;
        private CDPMessageBus messageBus;

        [SetUp]
        public void Setup()
        {
            this.cancelationTokenSource = new CancellationTokenSource();
            
            this.credentials = new Credentials("admin", "pass", this.uri, true);
            this.dal = new CdpServicesDal();
            this.messageBus = new CDPMessageBus();
            this.session = new Session(this.dal, this.credentials, this.messageBus);

            // Add SiteDirectory to cache
            this.siteDirectory = new SiteDirectory(Guid.Parse("f13de6f8-b03a-46e7-a492-53b2f260f294"), this.session.Assembler.Cache, this.uri);
            var lazySiteDirectory = new Lazy<Thing>(() => this.siteDirectory);
            lazySiteDirectory.Value.Cache.TryAdd(new CacheKey(lazySiteDirectory.Value.Iid, null), lazySiteDirectory);
            
            this.PopulateSiteDirectory();
        }

        /// <summary>
        /// populates the <see cref="SiteDirectory"/>
        /// </summary>
        private void PopulateSiteDirectory()
        {
            this.siteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.Parse("c454c687-ba3e-44c4-86bc-44544b2c7880"), this.session.Assembler.Cache, this.uri);
            this.modelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.Parse("3483f2b5-ea29-45cc-8a46-f5f598558fc3"), this.session.Assembler.Cache, this.uri);
            this.modelReferenceDataLibrary.RequiredRdl = this.siteReferenceDataLibrary;

            this.engineeringModel = new EngineeringModel(Guid.Parse("9ec982e4-ef72-4953-aa85-b158a95d8d56"), this.session.Assembler.Cache, this.uri);
            this.iteration = new Iteration(Guid.Parse("e163c5ad-f32b-4387-b805-f4b34600bc2c"), this.session.Assembler.Cache, this.uri);
            this.engineeringModel.Iteration.Add(this.iteration);

            this.engineeringModelSetup = new EngineeringModelSetup(Guid.Parse("86163b0e-8341-4316-94fc-93ed60ad0dcf"), this.session.Assembler.Cache, this.uri);
            this.engineeringModelSetup.EngineeringModelIid = this.engineeringModel.Iid;
            this.engineeringModelSetup.RequiredRdl.Add(this.modelReferenceDataLibrary);

            this.iterationSetup = new IterationSetup(Guid.NewGuid(), this.session.Assembler.Cache, this.uri);
            this.iterationSetup.IterationIid = this.iteration.Iid;
            this.engineeringModelSetup.IterationSetup.Add(this.iterationSetup);

            this.siteDirectory.Model.Add(this.engineeringModelSetup);
        }

        [TearDown]
        public void TearDown()
        {
            this.messageBus.ClearSubscriptions();
            this.credentials = null;
            this.dal = null;
            this.session = null;
            this.siteDirectory = null;
            this.siteReferenceDataLibrary = null;
            this.modelReferenceDataLibrary = null;
            this.iterationSetup = null;
            this.engineeringModelSetup = null;
            this.engineeringModel = null;
        }

        [Test]
        public void VerifyThatCdpServicesDalCanBeConstructed()
        {
            var dal = new CdpServicesDal();
            Assert.That(dal, Is.Not.Null);
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifyThatOpenReturnsDTOs()
        {
            var uriBuilder = new UriBuilder(this.credentials.Uri) { Path = "/Data/Restore" };
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{this.credentials.UserName}:{this.credentials.Password}")));
            await httpClient.PostAsync(uriBuilder.Uri, null);

            var dal = new CdpServicesDal();
            var result = await dal.Open(this.credentials, new CancellationToken());

            var amountOfDtos = result.ToList().Count;

            Assert.That(amountOfDtos, Is.EqualTo(86));
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifThatAClosedDalCannotBeClosedAgain()
        {
            var dal = new CdpServicesDal();
            await dal.Open(this.credentials, new CancellationToken());

            dal.Close();

            Assert.Throws<InvalidOperationException>(() => dal.Close());
        }

        [Test]
        public void VerifyThatIfCredentialsAreNullExceptionIsThrown()
        {
            var dal = new CdpServicesDal();

            Assert.That(async () => await dal.Open(null, new CancellationToken()), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        [Category("WebServicesDependent")]
        public void VerifyThatIfNotHttpOrHttpsExceptionIsThrown()
        {
            var uri = new Uri("https://cdp4services-test.cdp4.org");
            var invalidCredentials = new Credentials("John", "a password", uri);

            Assert.That(async () => await this.dal.Open(invalidCredentials, new CancellationToken()), Throws.TypeOf<DalReadException>());
        }

        [Test]
        public void VerifyThatIfCredentialsAreNullOnReadExceptionIsThrown()
        {
            var organizationIid = Guid.Parse("44d1ff16-8195-47d0-abfa-163bbba9bf39");
            var organizationDto = new CDP4Common.DTO.Organization(organizationIid, 0);
            organizationDto.AddContainer(ClassKind.SiteDirectory, Guid.Parse("eb77f3e1-a0f3-412d-8ed6-b8ce881c0145"));

            var dal = new CdpServicesDal();

            Assert.That(async () => await dal.Read(organizationDto, new CancellationToken()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatWriteCreateException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotImplementedException>(() => this.dal.Create(alias));
        }

        [Test]
        public void VerifyThatUpdateThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotImplementedException>(() => this.dal.Update(alias));
        }

        [Test]
        public void VerifyThatDeleteThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotImplementedException>(() => this.dal.Delete(alias));
        }

        [Test]
        public void VerifyThatDalThatIsNotOpenCannotBeClosed()
        {
            Assert.That(this.dal.Credentials, Is.Null);
            Assert.Throws<InvalidOperationException>(() => this.dal.Close());
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifyThatReadReturnsCorrectDTO()
        {
            this.dal = new CdpServicesDal();

            var returned = (await this.dal.Open(this.credentials, this.cancelationTokenSource.Token)).ToList();
            Assert.That(returned, Is.Not.Null);
            Assert.That(returned, Is.Not.Empty);

            var sd = returned.OfType<CDP4Common.DTO.SiteDirectory>().First();

            var attributes = new QueryAttributes();
            var readResult = await this.dal.Read(sd, this.cancelationTokenSource.Token, attributes);

            // General assertions for any kind of Thing we read
            Assert.That(readResult, Is.Not.Null);
            Assert.That(readResult.Count() == 1, Is.True);
            var sd1 = readResult.Single();
            Assert.That(sd.ClassKind == sd1.ClassKind, Is.True);
            Assert.That(sd.Iid == sd1.Iid, Is.True);
            Assert.That(sd.Route == sd1.Route, Is.True);

            // Specific assertions for Sitedirectory ClassKind
            var castedSd = sd as CDP4Common.DTO.SiteDirectory;
            var castedSd1 = sd as CDP4Common.DTO.SiteDirectory;
            Assert.That(castedSd, Is.Not.Null);
            Assert.That(castedSd1, Is.Not.Null);
            Assert.That(castedSd.Name == castedSd1.Name, Is.True);
            Assert.That(castedSd.Domain.Count == castedSd1.Domain.Count, Is.True);
            Assert.That(castedSd.SiteReferenceDataLibrary == castedSd1.SiteReferenceDataLibrary, Is.True);
            Assert.That(castedSd.Model == castedSd1.Model, Is.True);
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task IntegrationTest()
        {
            this.dal = new CdpServicesDal();
            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            var assembler = new Assembler(this.credentials.Uri, this.messageBus);

            await assembler.Synchronize(returned);

            var attributes = new DalQueryAttributes { RevisionNumber = 0 };
            var topcontainers = assembler.Cache.Select(x => x.Value).Where(x => x.Value is TopContainer).ToList();

            Assert.That(async () =>
            {
                foreach (var container in topcontainers)
                {
                    returned = await this.dal.Read(container.Value.ToDto(), this.cancelationTokenSource.Token, attributes);
                    await assembler.Synchronize(returned);
                }
            }, Throws.Nothing);
        }

        [Test]
        public void VerifyThatPostBodyIsCorrectlyResolves()
        {
            var siteDirecortoryIid = Guid.Parse("f289023d-41e8-4aaf-aae5-1be1ecf24bac");
            var domainOfExpertiseIid = Guid.NewGuid();

            var context = "/SiteDirectory/f289023d-41e8-4aaf-aae5-1be1ecf24bac";
            var operationContainer = new OperationContainer(context);

            var testDtoOriginal = new CDP4Common.DTO.Alias(Guid.NewGuid(), 1)
            {
                Content = "content",
                IsSynonym = false,
                LanguageCode = "en",
            };

            testDtoOriginal.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoOriginal.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoModified = new CDP4Common.DTO.Alias(testDtoOriginal.Iid, 1)
            {
                Content = "content2",
                IsSynonym = true,
                LanguageCode = "en",
            };

            testDtoModified.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoModified.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoOriginal2 = new CDP4Common.DTO.Definition(Guid.NewGuid(), 1)
            {
                Content = "somecontent",
                LanguageCode = "en",
            };

            testDtoOriginal2.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoOriginal2.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoModified2 = new CDP4Common.DTO.Definition(testDtoOriginal2.Iid, 1)
            {
                Content = "somecontent2",
                LanguageCode = "en",
            };

            testDtoModified2.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoModified2.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            testDtoModified2.Citation.Add(Guid.NewGuid());
            testDtoModified2.Citation.Add(Guid.NewGuid());
            testDtoModified2.Citation.Add(Guid.NewGuid());
            testDtoModified2.Citation.Add(Guid.NewGuid());

            testDtoOriginal2.Citation.Add(testDtoModified2.Citation[0]);
            testDtoOriginal2.Citation.Add(testDtoModified2.Citation[1]);
            testDtoOriginal2.Citation.Add(testDtoModified2.Citation[2]);

            testDtoModified2.Citation.Remove(testDtoModified2.Citation[1]);

            testDtoOriginal2.Note.Add(new OrderedItem()
            {
                K = 1234,
                V = Guid.NewGuid()
            });

            testDtoOriginal2.Note.Add(new OrderedItem()
            {
                K = 2345,
                V = Guid.NewGuid()
            });

            testDtoModified2.Note.Add(new OrderedItem()
            {
                K = 234,
                V = Guid.NewGuid()
            });

            testDtoModified2.Note.Add(new OrderedItem()
            {
                K = 2346,
                V = testDtoOriginal2.Note[1].V
            });

            // make a few operations
            var operation1 = new Operation(null, testDtoModified, OperationKind.Create);
            var operation2 = new Operation(null, testDtoModified, OperationKind.Delete);
            var operation3 = new Operation(testDtoOriginal, testDtoModified, OperationKind.Update);
            var operation4 = new Operation(testDtoOriginal2, testDtoModified2, OperationKind.Update);

            operationContainer.AddOperation(operation1);
            operationContainer.AddOperation(operation2);
            operationContainer.AddOperation(operation3);
            operationContainer.AddOperation(operation4);

            var stream = new MemoryStream();
            this.dal.ConstructPostRequestBodyStream(string.Empty, operationContainer, stream);

            Assert.That(stream.Length, Is.Not.EqualTo(0));
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifyThatReadIterationWorks()
        {
            var dal = new CdpServicesDal { Session = this.session };
            var credentials = new Credentials("admin", "pass", new Uri("https://cdp4services-public.cdp4.org"));
            var session = new Session(dal, credentials, this.messageBus);

            var returned = await dal.Open(credentials, this.cancelationTokenSource.Token);

            await session.Assembler.Synchronize(returned);

            var siteDir = session.Assembler.RetrieveSiteDirectory();
            var modelSetup = siteDir.Model.Single(x => x.ShortName == "LOFT");
            var iterationSetup = modelSetup.IterationSetup.First();

            var openCount = session.Assembler.Cache.Count;

            var model = new EngineeringModel(modelSetup.EngineeringModelIid, null, null);
            var iteration = new Iteration(iterationSetup.IterationIid, null, null);
            iteration.Container = model;

            var modelDtos = await dal.Read((CDP4Common.DTO.Iteration)iteration.ToDto(), this.cancelationTokenSource.Token);
            await session.Assembler.Synchronize(modelDtos);

            var readCount = session.Assembler.Cache.Count;
            Assert.That(readCount > openCount, Is.True);
        }

        [Test]
        [Category("WebServicesDependent")]
        [Category("Performance")]
        public async Task AssemblerSynchronizePerformanceTest()
        {
            this.dal = new CdpServicesDal();

            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            var returnedlist = returned.ToList();
            const int iterationNumber = 1000;
            var elapsedTimes = new List<long>();

            Assert.That(async () =>
            {
                for (var i = 0; i < iterationNumber; i++)
                {
                    var assembler = new Assembler(this.uri, this.messageBus);
                    var stopwatch = Stopwatch.StartNew();
                    await assembler.Synchronize(returnedlist);
                    elapsedTimes.Add(stopwatch.ElapsedMilliseconds);
                    await assembler.Clear();
                }
            }, Throws.Nothing);

            var synchronizeMeanElapsedTime = elapsedTimes.Average();
            var maxElapsedTime = elapsedTimes.Max();
            var minElapsedTime = elapsedTimes.Min();

            // 204.64 | 181 | 458 ms
            // refactor: 31.61 | 26 | 283
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifyThatFileCanBeUploaded()
        {
            this.dal = new CdpServicesDal { Session = this.session };

            var filename = @"TestData\testfile.pdf";
            var directory = TestContext.CurrentContext.TestDirectory;
            var filepath = Path.Combine(directory, filename);
            var files = new List<string> { filepath };

            var contentHash = "F73747371CFD9473C19A0A7F99BCAB008474C4CA";
            var uri = new Uri("https://cdp4services-test.cdp4.org");
            this.credentials = new Credentials("admin", "pass", uri);

            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);

            var engineeringModeliid = Guid.Parse("9ec982e4-ef72-4953-aa85-b158a95d8d56");
            var iterationiid = Guid.Parse("e163c5ad-f32b-4387-b805-f4b34600bc2c");
            var domainFileStoreIid = Guid.Parse("da7dddaa-02aa-4897-9935-e8d66c811a96");
            var fileIid = Guid.NewGuid();
            var fileRevisionIid = Guid.NewGuid();
            var domainOfExpertiseIid = Guid.Parse("0e92edde-fdff-41db-9b1d-f2e484f12535");
            var fileTypeIid = Guid.Parse("b16894e4-acb5-4e81-a118-16c00eb86d8f"); //PDF
            var participantIid = Guid.Parse("284334dd-e8e5-42d6-bc8a-715c507a7f02");

            var originalDomainFileStore = new CDP4Common.DTO.DomainFileStore(domainFileStoreIid, 0);
            originalDomainFileStore.AddContainer(ClassKind.Iteration, iterationiid);
            originalDomainFileStore.AddContainer(ClassKind.EngineeringModel, engineeringModeliid);

            var modifiedDomainFileStore = new CDP4Common.DTO.DomainFileStore(domainFileStoreIid, 0);
            modifiedDomainFileStore.File.Add(fileIid);
            modifiedDomainFileStore.AddContainer(ClassKind.Iteration, iterationiid);
            modifiedDomainFileStore.AddContainer(ClassKind.EngineeringModel, engineeringModeliid);

            var file = new CDP4Common.DTO.File(fileIid, 0) { Owner = domainOfExpertiseIid };
            file.FileRevision.Add(fileRevisionIid);
            file.AddContainer(ClassKind.DomainFileStore, domainFileStoreIid);
            file.AddContainer(ClassKind.Iteration, iterationiid);
            file.AddContainer(ClassKind.EngineeringModel, engineeringModeliid);

            var fileRevision = new CDP4Common.DTO.FileRevision(fileRevisionIid, 0);
            fileRevision.Name = "testfile";
            fileRevision.ContentHash = contentHash;
            fileRevision.FileType.Add(new OrderedItem() { K = 1, V = fileTypeIid });
            fileRevision.Creator = participantIid;
            fileRevision.AddContainer(ClassKind.File, fileIid);
            fileRevision.AddContainer(ClassKind.DomainFileStore, domainFileStoreIid);
            fileRevision.AddContainer(ClassKind.Iteration, iterationiid);
            fileRevision.AddContainer(ClassKind.EngineeringModel, engineeringModeliid);

            var context = $"/EngineeringModel/{engineeringModeliid}/iteration/{iterationiid}";
            var operationContainer = new OperationContainer(context);

            var updateCommonFileStoreOperation = new Operation(originalDomainFileStore, modifiedDomainFileStore, OperationKind.Update);
            operationContainer.AddOperation(updateCommonFileStoreOperation);

            var createFileOperation = new Operation(null, file, OperationKind.Create);
            operationContainer.AddOperation(createFileOperation);

            var createFileRevisionOperation = new Operation(null, fileRevision, OperationKind.Create);
            operationContainer.AddOperation(createFileRevisionOperation);

            Assert.DoesNotThrowAsync(async () => await this.dal.Write(operationContainer, files));
        }

        [Test]
        public void VerifyThatIsValidUriReturnsExpectedResult()
        {
            var dal = new CdpServicesDal();

            Assert.That(dal.IsValidUri("http://cdp4services-test.cdp4.org"), Is.True);
            Assert.That(dal.IsValidUri("https://cdp4services-test.cdp4.org"), Is.True);
            Assert.That(dal.IsValidUri("file://some file"), Is.False);
        }

        [Test]
        public void VerifyThatSessionMustBeSetToReadIteration()
        {
            var iterationDto = new CDP4Common.DTO.Iteration(Guid.NewGuid(), 0);

            var dal = new CdpServicesDal();

            Assert.That(async () => await dal.Read(iterationDto, new CancellationToken()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatWritingMultipleOperationContainersIsNotSupported()
        {
            var dal = new CdpServicesDal();
            this.SetDalToBeOpen(dal);

            var contextOne = $"/EngineeringModel/{Guid.NewGuid()}/iteration/{Guid.NewGuid()}";
            var contextTwo = $"/EngineeringModel/{Guid.NewGuid()}/iteration/{Guid.NewGuid()}";

            var operationContainerOne = new OperationContainer(contextOne);
            var operationContainerTwo = new OperationContainer(contextTwo);

            var operationContainers = new List<OperationContainer> { operationContainerOne, operationContainerTwo };

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));
        }

        [Test]
        public async Task Vefify_that_when_OperationContainer_is_empty_an_empty_is_returned()
        {
            var dal = new CdpServicesDal();
            this.SetDalToBeOpen(dal);

            var context = $"/EngineeringModel/{Guid.NewGuid()}/iteration/{Guid.NewGuid()}";
            var operationContainer = new OperationContainer(context);

            Assert.That(await dal.Write(operationContainer), Is.Empty);
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task Verify_that_opens_returns_expected_result()
        {
            var uri = new Uri("https://cdp4services-test.cdp4.org");
            this.credentials = new Credentials("admin", "pass", uri);

            var dal = new CdpServicesDal();
            var result = await dal.Open(this.credentials, new CancellationToken());

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("WebServicesDependent")]
        [Category("CICDExclusion")]
        public async Task Verify_that_opens_and_close_removes_items_from_cache()
        {
            this.dal = new CdpServicesDal { Session = this.session };
            this.credentials = new Credentials("admin", "pass", new Uri("https://cdp4services-public.cdp4.org"));

            this.session = new Session(this.dal, this.credentials, this.messageBus);
            await this.session.Open();

            this.siteDirectory = this.session.Assembler.RetrieveSiteDirectory();
            this.engineeringModelSetup = this.siteDirectory.Model.Single(x => x.ShortName == "LOFT");
            this.iterationSetup = this.engineeringModelSetup.IterationSetup.First();
            var domainOfExpertise = this.engineeringModelSetup.ActiveDomain.First(x => x.ShortName == "SYS");

            var openCount = this.session.Assembler.Cache.Count;

            var cache = this.session.Assembler.Cache;

            var model = new EngineeringModel(this.engineeringModelSetup.EngineeringModelIid, null, null);
            this.iteration = new Iteration(this.iterationSetup.IterationIid, null, null);
            this.iteration.Container = model;

            await this.session.Read(this.iteration, domainOfExpertise);

            var readCount = this.session.Assembler.Cache.Count;
            Assert.That(readCount > openCount, Is.True);

            await this.session.CloseIterationSetup(this.iterationSetup);

            var closeCount = this.session.Assembler.Cache.Count;

            Assert.That(closeCount < readCount, Is.True);
        }

        [Test]
        [Category("WebServicesDependent")]
        [Category("CICDExclusion")]
        public async Task Verify_that_opens_and_close_removes_items_from_cache_with_full_truest()
        {
            this.dal = new CdpServicesDal { Session = this.session };
            this.credentials = new Credentials("admin", "pass", new Uri("https://cdp4services-public.cdp4.org"), true);

            this.session = new Session(this.dal, this.credentials, this.messageBus);
            await this.session.Open();

            this.siteDirectory = this.session.Assembler.RetrieveSiteDirectory();
            this.engineeringModelSetup = this.siteDirectory.Model.Single(x => x.ShortName == "LOFT");
            this.iterationSetup = this.engineeringModelSetup.IterationSetup.First();
            var domainOfExpertise = this.engineeringModelSetup.ActiveDomain.First(x => x.ShortName == "SYS");

            var openCount = this.session.Assembler.Cache.Count;

            var cache = this.session.Assembler.Cache;

            var model = new EngineeringModel(this.engineeringModelSetup.EngineeringModelIid, null, null);
            this.iteration = new Iteration(this.iterationSetup.IterationIid, null, null);
            this.iteration.Container = model;

            await this.session.Read(this.iteration, domainOfExpertise);

            var readCount = this.session.Assembler.Cache.Count;
            Assert.That(readCount > openCount, Is.True);

            await this.session.CloseIterationSetup(this.iterationSetup);

            var closeCount = this.session.Assembler.Cache.Count;

            Assert.That(closeCount < readCount, Is.True);
        }

        [Test]
        [Category("WebServicesDependent")]
        [Category("CICDExclusion")]
        public async Task Verify_that_open_with_proxy_returns_expected_result()
        {
            var proxySettings = new ProxySettings(new Uri("http://tinyproxy:8888"));

            var uri = new Uri("https://cdp4services-test.cdp4.org");
            this.credentials = new Credentials("admin", "pass", uri, false, proxySettings);

            var dal = new CdpServicesDal();
            var result = await dal.Open(this.credentials, new CancellationToken());

            Assert.That(result, Is.Not.Null);
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task Verify_that_multiple_read_requests_can_be_made_in_parallel()
        {
            var uri = new Uri("https://cdp4services-test.cdp4.org");
            var credentials = new Credentials("admin", "pass", uri);
            var assembler = new Assembler(this.uri, this.messageBus);

            var dal = new CdpServicesDal();
            var session = new Session(dal, credentials, this.messageBus);

            var result = await dal.Open(credentials, new CancellationToken());

            var siteDirectory = result.OfType<CDP4Common.DTO.SiteDirectory>().Single();

            var queryAttributes = new QueryAttributes { Extent = ExtentQueryAttribute.deep };

            for (var i = 0; i < 9; i++)
            {
                await dal.Read(siteDirectory, new CancellationToken(), queryAttributes);
            }

            var readresult = await dal.Read(siteDirectory, new CancellationToken());

            Assert.That(readresult, Is.Not.Empty);
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task Verify_that_person_can_be_Posted()
        {
            var cdpServicesDal = new CdpServicesDal();
            var dtos = await cdpServicesDal.Open(this.credentials, this.cancelationTokenSource.Token);

            var siteDirectory = (CDP4Common.DTO.SiteDirectory)dtos.Single(x => x.ClassKind == ClassKind.SiteDirectory);

            var context = siteDirectory.Route;
            var operationContainer = new OperationContainer(context, siteDirectory.RevisionNumber);

            var person = new CDP4Common.DTO.Person(Guid.NewGuid(), 1);
            person.ShortName = Guid.NewGuid().ToString();
            person.Surname = Guid.NewGuid().ToString();
            person.GivenName = Guid.NewGuid().ToString();
            person.AddContainer(ClassKind.SiteDirectory, siteDirectory.Iid);

            var operation1 = new Operation(null, person, OperationKind.Create);
            operationContainer.AddOperation(operation1);

            var siteDirectoryClone = siteDirectory.DeepClone<CDP4Common.DTO.SiteDirectory>();
            siteDirectoryClone.Person.Add(person.Iid);
            var operation2 = new Operation(siteDirectory, siteDirectoryClone, OperationKind.Update);
            operationContainer.AddOperation(operation2);

            var result = await cdpServicesDal.Write(operationContainer);

            var resultPerson = (CDP4Common.DTO.Person)result.Single(x => x.Iid == person.Iid);

            Assert.That(resultPerson, Is.Not.Null);
        }

                [Test]
        public async Task VerifyReadCometTask()
        {
            var mockHttp = new MockHttpMessageHandler();
            var httpClient = mockHttp.ToHttpClient();
            httpClient.BaseAddress = this.uri;

            this.dal = new CdpServicesDal(httpClient);
            this.SetDalToBeOpen(this.dal);
            
            var cometTaskId = Guid.NewGuid();

            var requestHandler = mockHttp.When($"{CdpServicesDal.CometTaskRoute}/{cometTaskId}");

            var notFoundHttpResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound
            };

            requestHandler.Respond(_ => notFoundHttpResponse);
            Assert.That(() => this.dal.ReadCometTask(cometTaskId, CancellationToken.None), Throws.Exception.TypeOf<DalReadException>());

            var foundHttpResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => foundHttpResponse);

            var cometTask = new CometTask()
            {
                Id = cometTaskId,
                Actor = Guid.NewGuid(),
                FinishedAt = DateTime.UtcNow,
                StartedAt = DateTime.UtcNow - TimeSpan.FromSeconds(10),
                TopContainer = "SiteDirectory",
                StatusKind = StatusKind.SUCCEEDED
            };

            foundHttpResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTask));
            SetHttpHeader(foundHttpResponse, "application/json");

            var readCometTask = await this.dal.ReadCometTask(cometTaskId, CancellationToken.None);
            Assert.That(readCometTask, Is.EqualTo(cometTask));

            var messagePackHttpResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => messagePackHttpResponse);
            messagePackHttpResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTask));
            SetHttpHeader(messagePackHttpResponse, "application/msgpack");

            Assert.That(() => this.dal.ReadCometTask(cometTaskId, CancellationToken.None), Throws.Exception.TypeOf<NotSupportedException>());
        }

        [Test]
        public async Task VerifyReadCometTasks()
        {
            var mockHttp = new MockHttpMessageHandler();
            var httpClient = mockHttp.ToHttpClient();
            httpClient.BaseAddress = this.uri;

            this.dal = new CdpServicesDal(httpClient);
            this.SetDalToBeOpen(this.dal);
            
            var requestHandler = mockHttp.When($"{CdpServicesDal.CometTaskRoute}");

            var notFoundHttpResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound
            };

            requestHandler.Respond(_ => notFoundHttpResponse);
            Assert.That(() => this.dal.ReadCometTasks(CancellationToken.None), Throws.Exception.TypeOf<DalReadException>());

            var foundHttpResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => foundHttpResponse);

            var cometTasks = new List<CometTask>()
            {
                new CometTask()
                {
                    Id = Guid.NewGuid(),
                    Actor = Guid.NewGuid(),
                    FinishedAt = DateTime.UtcNow,
                    StartedAt = DateTime.UtcNow - TimeSpan.FromSeconds(10),
                    TopContainer = "SiteDirectory",
                    StatusKind = StatusKind.SUCCEEDED
                }
            };

            foundHttpResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTasks));
            SetHttpHeader(foundHttpResponse, "application/json");

            var readCometTasks = await this.dal.ReadCometTasks(CancellationToken.None);
            Assert.That(readCometTasks, Is.EquivalentTo(cometTasks));

            var messagePackHttpResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => messagePackHttpResponse);
            messagePackHttpResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTasks));
            SetHttpHeader(messagePackHttpResponse, "application/msgpack");

            Assert.That(() => this.dal.ReadCometTasks(CancellationToken.None), Throws.Exception.TypeOf<NotSupportedException>());
        }

        [Test]
        public async Task VerifyWriteLongRunningTask()
        {
            var mockHttp = new MockHttpMessageHandler();
            var httpClient = mockHttp.ToHttpClient();
            httpClient.BaseAddress = this.uri;
            var operationContainer = new OperationContainer($"/SiteDirectory/{Guid.NewGuid()}");
            this.dal = new CdpServicesDal(httpClient);

            Assert.That(() => this.dal.Write(operationContainer, 1), Throws.InvalidOperationException);
            this.SetDalToBeOpen(this.dal);

            Assert.Multiple(() =>
            {
                Assert.That(() => this.dal.Write(null, 1), Throws.ArgumentNullException);
                Assert.That(() => this.dal.Write(operationContainer, 0), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            });

            var requestHandler = mockHttp.When(HttpMethod.Post, operationContainer.Context);

            var notFoundHttpResponse = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.NotFound
            };

            requestHandler.Respond(_ => notFoundHttpResponse);
            notFoundHttpResponse.Content = new StringContent("Unable to proced the write operation");

            Assert.That(() => this.dal.Write(operationContainer, 1), Throws.Exception.TypeOf<DalWriteException>());

            var cometTask = new CometTask()
            {
                Id = Guid.NewGuid(),
                Actor = Guid.NewGuid(),
                StartedAt = DateTime.UtcNow - TimeSpan.FromSeconds(1)
            };

            var newCometTaskResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => newCometTaskResponse);

            newCometTaskResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTask));
            SetHttpHeader(newCometTaskResponse, "application/json");

            var longRunningTaskResult = await this.dal.Write(operationContainer,1);

            Assert.Multiple(() =>
            {
                Assert.That(longRunningTaskResult.IsWaitTimeReached, Is.True);
                Assert.That(longRunningTaskResult.Things, Is.Null);
                Assert.That(longRunningTaskResult.Task, Is.EqualTo(cometTask));
            });

            var thingsResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => thingsResponse);

            var stream = new MemoryStream();
            this.dal.Cdp4JsonSerializer.SerializeToStream(this.iteration, stream, true);
            stream.Position = 0;
            thingsResponse.Content = new StreamContent(stream);
            SetHttpHeader(thingsResponse, "application/json");

            longRunningTaskResult = await this.dal.Write(operationContainer,1);

            Assert.Multiple(() =>
            {
                Assert.That(longRunningTaskResult.IsWaitTimeReached, Is.False);
                Assert.That(longRunningTaskResult.Things, Is.Not.Null);
                Assert.That(longRunningTaskResult.Task.Id, Is.EqualTo(Guid.Empty));
            });

            var messagePackResponse = new HttpResponseMessage();
            requestHandler.Respond(_ => messagePackResponse);

            messagePackResponse.Content = new StringContent(JsonConvert.SerializeObject(cometTask));
            SetHttpHeader(messagePackResponse, "application/msgpack");
            Assert.That(() => this.dal.Write(operationContainer, 1), Throws.Exception.TypeOf<NotSupportedException>());
        }

        [Test]
        [Category("WebServicesDependent")]
        // To test this, please enable one by one authentication scheme on the CDP4 COMET Server
        public async Task VerifyCanAuthenticateWithMultipleSchemeAtDalLevel()
        {
            var authentitcatioCredentials = new Credentials(new Uri("http://localhost:5000/"));
            var servicesDal = new CdpServicesDal();
            
            var cancellationSource = new CancellationTokenSource();
            servicesDal.InitializeDalCredentials(authentitcatioCredentials);
            var availableScheme = (await servicesDal.RequestAvailableAuthenticationScheme(cancellationSource.Token)).Schemes.Single();
            const string username = "admin";
            const string password = "pass";
            const string externalToken = "update-with-a-generated-token";
            
            switch (availableScheme)
            {
                case AuthenticationSchemeKind.Basic:
                    authentitcatioCredentials.ProvideUserCredentials(username, password, availableScheme);
                    break;
                case AuthenticationSchemeKind.LocalJwtBearer:
                    await servicesDal.Login(username, password, cancellationSource.Token);
                    break;
                case AuthenticationSchemeKind.ExternalJwtBearer:
                    authentitcatioCredentials.ProvideUserToken(externalToken,availableScheme);
                    break;
            }

            var readThings = await servicesDal.Open(authentitcatioCredentials, cancellationSource.Token);
            cancellationSource.Dispose();
            
            Assert.That(readThings, Is.Not.Empty);
            Console.WriteLine($"Test passed wih {availableScheme}");
        }

        [Test]
        [Category("WebServicesDependent")]
        // To test this, please enable one by one authentication scheme on the CDP4 COMET Server
        public async Task VerifyCanAuthenticateWithMultipleSchemeAtSessionLevel()
        {
            var authentitcatioCredentials = new Credentials(new Uri("http://localhost:5000/"));
            var authenticationSession = new Session(new CdpServicesDal(), authentitcatioCredentials, this.messageBus);

            var availableScheme = (await authenticationSession.QueryAvailableAuthenticationScheme()).Schemes.Single();

            const string username = "admin";
            const string password = "pass";
            const string externalToken = "update-with-a-generated-token";

            var authenticationInformation = availableScheme switch
            {
                AuthenticationSchemeKind.Basic or AuthenticationSchemeKind.LocalJwtBearer => new AuthenticationInformation(username, password),
                AuthenticationSchemeKind.ExternalJwtBearer => new AuthenticationInformation(externalToken),
                _ => throw new ArgumentOutOfRangeException(nameof(availableScheme))
            };

            await authenticationSession.AuthenticateAndOpen(availableScheme, authenticationInformation);
            Assert.That(authenticationSession.RetrieveSiteDirectory(), Is.Not.Null);
            Console.WriteLine($"Test passed wih {availableScheme}");
        }

        /// <summary>
        /// Set the credentials property so DAL appears to be open
        /// </summary>
        /// <param name="dal">
        /// The <see cref="CdpServicesDal"/> that is to be opened
        /// </param>
        private void SetDalToBeOpen(CdpServicesDal dal)
        {
            var credentialsProperty = typeof(CdpServicesDal).GetProperty("Credentials");
            credentialsProperty.SetValue(dal, this.credentials);
        }

        /// <summary>
        /// Set correct headers to be validated by the <see cref="CdpServicesDal"/>
        /// </summary>
        /// <param name="response">The <see cref="HttpResponseMessage"/></param>
        /// <param name="contentType">The content type to add to the http content header</param>
        private static void SetHttpHeader(HttpResponseMessage response, string contentType)
        {
            response.Headers.Add(Headers.CDPServer, "1.0.0");
            response.Headers.Add(Headers.CDPCommon, "1.3.0");
            response.Content.Headers.Remove(Headers.ContentType);
            response.Content.Headers.Add(Headers.ContentType, $"{contentType};ecss-e-tm-10-25;version=1.0.0");
        }
    }
}
