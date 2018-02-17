#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WSPDalTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4WspDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.DAL.ECSS1025AnnexC;
    using CDP4Dal.Operations;
    using CDP4WspDal;
    using NUnit.Framework;

    using File = System.IO.File;
    using Thing = CDP4Common.CommonData.Thing;

    /// <summary>
    /// Suite of tests for the <see cref="WspDal"/>
    /// </summary>
    [TestFixture]
    public class WspDalTestFixture
    {
        private WspDal dal;
        private Credentials credentials;
        private CancellationTokenSource cancelationTokenSource;
        private Uri uri = new Uri("https://cdp4services-test.rheagroup.com");
        private ISession session;
        private Assembler assembler;

        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private EngineeringModelSetup engineeringModelSetup;
        private Iteration iteration;
        private IterationSetup iterationSetup;
        private SiteReferenceDataLibrary siteReferenceDataLibrary;
        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        [SetUp]
        public void SetUp()
        {
            this.cancelationTokenSource = new CancellationTokenSource();

            this.credentials = new Credentials("admin", "pass", this.uri);
            this.dal = new WspDal();
            this.session = new Session(this.dal, this.credentials);

            // Add SiteDirectory to cache
            this.siteDirectory = new SiteDirectory(Guid.Parse("f13de6f8-b03a-46e7-a492-53b2f260f294"), this.session.Assembler.Cache, this.uri);
            var lazySiteDirectory = new Lazy<Thing>(() => this.siteDirectory);
            lazySiteDirectory.Value.Cache.TryAdd(new Tuple<Guid, Guid?>(lazySiteDirectory.Value.Iid, null), lazySiteDirectory);

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
            CDPMessageBus.Current.ClearSubscriptions();
            this.credentials = null;
            this.dal = null;
        }

        [Test]
        public void VerifyThatCdpServicesDalCanBeConstructed()
        {
            var dal = new WspDal();
            Assert.IsNotNull(dal);
        }

        [Test]
        public async Task VerifyThatOpenReturnsDTOs()
        {
            var dal = new WspDal();
            var result = await dal.Open(this.credentials, new CancellationToken());

            var amountOfDtos = result.ToList().Count;

            Assert.AreEqual(60, amountOfDtos);
        }

        [Test]
        public async Task VerifThatAClosedDalCannotBeClosedAgain()
        {
            var dal = new WspDal();
            await dal.Open(this.credentials, new CancellationToken());

            dal.Close();

            Assert.Throws<InvalidOperationException>(() => dal.Close());
        }

        [Test]
        public async Task VerifyThatIfCredentialsAreNullExceptionIsThrown()
        {
            var dal = new WspDal();

            Assert.That(async () => await dal.Open(null, new CancellationToken()), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task VerifyThatIfNotHttpOrHttpsExceptionIsThrown()
        {
            var uri = new Uri("file://somefile");
            var invalidCredentials = new Credentials("John", "a password", uri);

            var dal = new WspDal();

            Assert.That(async () => await dal.Open(invalidCredentials, new CancellationToken()), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public async Task VerifyThatIfCredentialsAreNullOnReadExceptionIsThrown()
        {
            var organizationIid = Guid.Parse("44d1ff16-8195-47d0-abfa-163bbba9bf39");
            var organizationDto = new CDP4Common.DTO.Organization(organizationIid, 0);
            organizationDto.AddContainer(ClassKind.SiteDirectory, Guid.Parse("eb77f3e1-a0f3-412d-8ed6-b8ce881c0145"));

            var dal = new WspDal();

            Assert.That(async () => await dal.Read(organizationDto, new CancellationToken()), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void VerifyThatWriteThrowsException()
        {
            var alias = new CDP4Common.DTO.Alias();
            Assert.Throws<NotSupportedException>(() => this.dal.Create(alias));
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
        public void VerifyThatAWspThatIsNotOpenCannotBeClosed()
        {
            Assert.IsNull(this.dal.Credentials);
            Assert.Throws<InvalidOperationException>(() => this.dal.Close());
        }

        [Test]
        [Category("WSP_dependent")]
        public async Task VerifyThatReadReturnsCorrectDTO()
        {
            this.dal = new WspDal();

            var returned = (await this.dal.Open(this.credentials, this.cancelationTokenSource.Token)).ToList();
            Assert.NotNull(returned);
            Assert.IsNotEmpty(returned);

            var sd = returned.First();

            var attributes = new QueryAttributes();
            var readResult = await dal.Read(sd, this.cancelationTokenSource.Token, attributes);

            // General assertions for any kind of Thing we read
            Assert.NotNull(readResult);
            Assert.IsTrue(readResult.Count() == 1);
            var sd1 = readResult.Single();
            Assert.IsTrue(sd.ClassKind == sd1.ClassKind);
            Assert.IsTrue(sd.Iid == sd1.Iid);
            Assert.IsTrue(sd.Route == sd1.Route);

            // Specific assertions for Sitedirectory ClassKind
            var castedSd = sd as CDP4Common.DTO.SiteDirectory;
            var castedSd1 = sd as CDP4Common.DTO.SiteDirectory;
            Assert.NotNull(castedSd);
            Assert.NotNull(castedSd1);
            Assert.IsTrue(castedSd.Name == castedSd1.Name);
            Assert.IsTrue(castedSd.Domain.Count == castedSd1.Domain.Count);
            Assert.IsTrue(castedSd.SiteReferenceDataLibrary == castedSd1.SiteReferenceDataLibrary);
            Assert.IsTrue(castedSd.Model == castedSd1.Model);
        }

        /// <summary>
        /// Verify that the App does not crash
        /// </summary>
        [Test]
        [Category("WSP_dependent")]
        public async Task IntegrationTest()
        {
            this.dal = new WspDal();
            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            var assembler = new Assembler(this.credentials.Uri);

            await assembler.Synchronize(returned);

            var attributes = new DalQueryAttributes { RevisionNumber = 0 };
            var topcontainers = assembler.Cache.Select(x => x.Value).Where(x => x.Value is CDP4Common.CommonData.TopContainer).ToList();

            foreach (var container in topcontainers)
            {
                returned = await this.dal.Read(container.Value.ToDto(), this.cancelationTokenSource.Token, attributes);
                await assembler.Synchronize(returned);
            }
        }

        [Test]
        public void VerifyThatWSPPostBodyIsCorrectlyResolves()
        {
            var siteDirecortoryIid = Guid.Parse("f289023d-41e8-4aaf-aae5-1be1ecf24bac");
            var domainOfExpertiseIid = Guid.NewGuid();

            var context = "/SiteDirectory/f289023d-41e8-4aaf-aae5-1be1ecf24bac";
            var operationContainer = new OperationContainer(context);

            var testDtoOriginal = new CDP4Common.DTO.Alias(iid: Guid.NewGuid(), rev: 1)
            {
                Content = "content",
                IsSynonym = false,
                LanguageCode = "en",
            };
            testDtoOriginal.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoOriginal.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoModified = new CDP4Common.DTO.Alias(iid: testDtoOriginal.Iid, rev: 1)
            {
                Content = "content2",
                IsSynonym = true,
                LanguageCode = "en",
            };
            testDtoModified.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoModified.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoOriginal2 = new CDP4Common.DTO.Definition(iid: Guid.NewGuid(), rev: 1)
            {
                Content = "somecontent",
                LanguageCode = "en",
            };
            testDtoOriginal2.AddContainer(ClassKind.DomainOfExpertise, domainOfExpertiseIid);
            testDtoOriginal2.AddContainer(ClassKind.SiteDirectory, siteDirecortoryIid);

            var testDtoModified2 = new CDP4Common.DTO.Definition(iid: testDtoOriginal2.Iid, rev: 1)
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

            Assert.AreNotEqual(0, stream.Length);
        }

        [Test]
        [Category("WSP_dependent")]
        public async Task VerifyThatReadIterationWorks()
        {
            var dal = new WspDal { Session = this.session };
            var credentials = new Credentials("admin", "pass", new Uri("https://cdp4services-public.rheagroup.com"));
            var session = new Session(dal, credentials);

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
            Assert.IsTrue(readCount > openCount);
        }

        [Test]
        [Category("WSP_dependent")]
        [Category("Performance")]
        public async Task AssemblerSynchronizePerformanceTest()
        {
            this.dal = new WspDal();

            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            var returnedlist = returned.ToList();
            const int iterationNumber = 1000;
            var elapsedTimes = new List<long>();

            for (int i = 0; i < iterationNumber; i++)
            {
                var assemble = new Assembler(this.uri);
                var stopwatch = Stopwatch.StartNew();
                await assemble.Synchronize(returnedlist);
                elapsedTimes.Add(stopwatch.ElapsedMilliseconds);
                await assemble.Clear();
            }

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
            this.dal = new WspDal { Session = this.session };

            var filename = @"TestData\testfile.pdf";
            var directory = TestContext.CurrentContext.TestDirectory;
            var filepath = Path.Combine(directory, filename);
            var files = new List<string> { filepath };

            var contentHash = "F73747371CFD9473C19A0A7F99BCAB008474C4CA";
            var uri = new Uri("https://cdp4services-test.rheagroup.com");
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

            var context = string.Format("/EngineeringModel/{0}/iteration/{1}", engineeringModeliid, iterationiid);
            var operationContainer = new OperationContainer(context);

            var updateCommonFileStoreOperation = new Operation(originalDomainFileStore, modifiedDomainFileStore, OperationKind.Update);
            operationContainer.AddOperation(updateCommonFileStoreOperation);

            var createFileOperation = new Operation(null, file, OperationKind.Create);
            operationContainer.AddOperation(createFileOperation);

            var createFileRevisionOperation = new Operation(null, fileRevision, OperationKind.Create);
            operationContainer.AddOperation(createFileRevisionOperation);

            Assert.DoesNotThrowAsync(async () => await dal.Write(operationContainer, files));
        }

        [Test]
        public void VerifyThatWritingMultipleOperationContainersIsNotSupported()
        {
            var dal = new WspDal();
            this.SetDalToBeOpen(dal);

            var contextOne = string.Format("/EngineeringModel/{0}/iteration/{1}", Guid.NewGuid(), Guid.NewGuid());
            var contextTwo = string.Format("/EngineeringModel/{0}/iteration/{1}", Guid.NewGuid(), Guid.NewGuid());

            var operationContainerOne = new OperationContainer(contextOne);
            var operationContainerTwo = new OperationContainer(contextTwo);

            var operationContainers = new List<OperationContainer> { operationContainerOne, operationContainerTwo };

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));
        }

        [Test]
        [Category("WSP_dependent")]
        public async Task Verify_that_person_can_be_Posted()
        {
            var uri = new Uri("http://ocdt-dev.rheagroup.com");
            var credentials = new Credentials("admin", "Dahubo12", uri);

            var wspdal = new WspDal();
            var dtos = await wspdal.Open(credentials, this.cancelationTokenSource.Token);

            var siteDirectory = (CDP4Common.DTO.SiteDirectory)dtos.Single(x => x.ClassKind == ClassKind.SiteDirectory);

            var context = siteDirectory.Route;
            var operationContainer = new OperationContainer(context, siteDirectory.RevisionNumber);

            var person = new CDP4Common.DTO.Person(Guid.NewGuid(), 1);
            person.ShortName = Guid.NewGuid().ToString();
            person.Surname = Guid.NewGuid().ToString();
            person.GivenName = Guid.NewGuid().ToString();
            person.AddContainer(ClassKind.SiteDirectory, Guid.Parse("eb77f3e1-a0f3-412d-8ed6-b8ce881c0145"));

            var operation1 = new Operation(null, person, OperationKind.Create);
            operationContainer.AddOperation(operation1);

            var siteDirectoryClone = siteDirectory.DeepClone<CDP4Common.DTO.SiteDirectory>();
            siteDirectoryClone.Person.Add(person.Iid);
            var operation2 = new Operation(siteDirectory, siteDirectoryClone, OperationKind.Update);
            operationContainer.AddOperation(operation2);

            var result = await wspdal.Write(operationContainer);

            var resultPerson = (CDP4Common.DTO.Person)result.Single(x => x.Iid == person.Iid);

            Assert.NotNull(resultPerson);
        }

        /// <summary>
        /// Set the credentials property so DAL appears to be open
        /// </summary>
        /// <param name="dal">
        /// The <see cref="CdpServicesDal"/> that is to be opened
        /// </param>
        private void SetDalToBeOpen(WspDal dal)
        {
            var credentialsProperty = typeof(WspDal).GetProperty("Credentials");
            credentialsProperty.SetValue(dal, this.credentials);
        }

        /// <summary>
        /// Gets the directory of the executing assembly
        /// </summary>
        /// <returns></returns>
        private string GetAssemblyDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            var directory = Path.GetDirectoryName(path);
            return directory;
        }
    }
}