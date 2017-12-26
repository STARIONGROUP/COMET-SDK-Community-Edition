// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2016 RHEA System S.A.
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
    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Operations;
    using CDP4JsonFileDal;
    using CDP4JsonFileDal.Json;
    using Ionic.Zip;
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
            this.credentials = new Credentials("admin", "pass", new Uri(path), "pass");
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
        public void VerifyCacheIsPresentOnOperationThing()
        {
            var iterationPoco = new CDP4Common.EngineeringModelData.Iteration
                                    {
                                        Iid = Guid.NewGuid(),
                                        Cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>(),
                                        Container = new EngineeringModel() {Iid = Guid.NewGuid()}
                                    };
            var iterationDto = iterationPoco.ToDto();

            Assert.NotNull(iterationDto.QuerySourceThing());

            var operation = new Operation(iterationDto, iterationDto, OperationKind.Create);
            Assert.NotNull(JsonFileDal.GetAssociatedCache(operation));
        }

        [Test]
        public void VerifyCacheRetrievalThrowsExceptionIfSourceThingMissing()
        {
            var iterationDto = new Iteration();
            var operation = new Operation(iterationDto, iterationDto, OperationKind.Create);

            Assert.Throws<ArgumentException>(() => JsonFileDal.GetAssociatedCache(operation));
        }

        [Test]
        [Category("AppVeyorExclusion")]
        public async Task VerifyThatOpenCreatesAConnection()
        {
            var returned = await this.dal.Open(this.credentials, this.cancelationTokenSource.Token);
            Assert.NotNull(returned);
            Assert.IsNotEmpty(returned);
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
            var modelRdlData = new CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary  { Iid = engineeringModelSetupDto.RequiredRdl.Single() };
            var engineeringModelSetupData = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { EngineeringModelIid = engineeringModelSetupDto.EngineeringModelIid };
            engineeringModelSetupData.RequiredRdl.Add(modelRdlData);
            engineeringModelSetupData.IterationSetup.Add(iterationSetupData);
            this.siteDirectoryData.Model.Add(engineeringModelSetupData);
            
            var iterObject = new Iteration { Iid = iterationSetupDto.IterationIid};

            var readResult = (await this.dal.Read(iterObject, this.cancelationTokenSource.Token)).ToList();

            // General assertions for any kind of Thing we read
            Assert.NotNull(readResult);
            Assert.IsTrue(readResult.Count() != 1);
            var iter1 = readResult.Single(d => d.ClassKind == ClassKind.Iteration);
            Assert.IsTrue(iterObject.ClassKind == iter1.ClassKind);
            Assert.IsTrue(iterObject.Iid == iter1.Iid);
        }

        [Test]
        public void VerifyNonExportableItems()
        {
            // setup engineeringmodelsetup with 2 iterationsetup instances and 2 active domains
            var iterationSetupData1 = new CDP4Common.SiteDirectoryData.IterationSetup { Iid = Guid.NewGuid() };
            var iterationSetupData2 = new CDP4Common.SiteDirectoryData.IterationSetup { Iid = Guid.NewGuid() };
            var domain1 = new CDP4Common.SiteDirectoryData.DomainOfExpertise { Iid = Guid.NewGuid() };
            var domain2 = new CDP4Common.SiteDirectoryData.DomainOfExpertise { Iid = Guid.NewGuid() };
            var domain3 = new CDP4Common.SiteDirectoryData.DomainOfExpertise { Iid = Guid.NewGuid() };
            var domain4 = new CDP4Common.SiteDirectoryData.DomainOfExpertise { Iid = Guid.NewGuid() };

            var engineeringModelSetupData1 = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { Iid = Guid.NewGuid() };
            engineeringModelSetupData1.IterationSetup.AddRange(new[] { iterationSetupData1, iterationSetupData2 });
            engineeringModelSetupData1.ActiveDomain.AddRange(new[] { domain1, domain2 });

            // setup second engineeringmodelsetip with 1 iterationsetup instance and 2 active domains
            var iterationSetupData3 = new CDP4Common.SiteDirectoryData.IterationSetup { Iid = Guid.NewGuid() };
            var engineeringModelSetupData2 = new CDP4Common.SiteDirectoryData.EngineeringModelSetup { Iid = Guid.NewGuid() };
            engineeringModelSetupData2.IterationSetup.Add(iterationSetupData3);
            engineeringModelSetupData2.ActiveDomain.AddRange(new[] { domain3, domain4 });

            // prepare the site directory
            this.siteDirectoryData.Model.AddRange(new[] { engineeringModelSetupData1, engineeringModelSetupData2 });
            this.siteDirectoryData.Domain.AddRange(new[] { domain1, domain2, domain3, domain4 });

            // determine all Thing instances that should not be included in the export
            var nonExportables = JsonFileDal.DetermineNonExportableItems(
                this.siteDirectoryData, new List<SiteReferenceDataLibrary>(),  new[] { iterationSetupData1 }.ToList());

            // the container engineeringmodel of iterationsetupdata 1 should be in the export, so not returned here
            CollectionAssert.DoesNotContain(nonExportables, engineeringModelSetupData1);

            // iterationsetupdata 1 should be in the export, so not returned here
            CollectionAssert.DoesNotContain(nonExportables, iterationSetupData1);

            // domain 1 and 2 should be in the export, so not returned here
            CollectionAssert.DoesNotContain(nonExportables, domain1);
            CollectionAssert.DoesNotContain(nonExportables, domain2);

            // make sure that the the other items will be skipped during export, so should be included in the returned listing
            CollectionAssert.Contains(nonExportables, engineeringModelSetupData2);
            CollectionAssert.Contains(nonExportables, iterationSetupData2);
            CollectionAssert.Contains(nonExportables, iterationSetupData3);
            CollectionAssert.Contains(nonExportables, domain3);
            CollectionAssert.Contains(nonExportables, domain4);
        }

        [Test]
        public void VerifyWriteHeaderThrowsException()
        {
            var person = new Person();
            var exchangeFileHeader = new ExchangeFileHeader();
            var zipFile = new ZipFile();
            const string FilePath = "test";
            
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteHeaderFile(null, exchangeFileHeader, zipFile, FilePath));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteHeaderFile(person, null, zipFile, FilePath));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteHeaderFile(person, exchangeFileHeader, null, FilePath));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteHeaderFile(person, exchangeFileHeader, zipFile, null));
        }

        [Test]
        public void VerifyWriteSiteDirectoryFileThrowsException()
        {
            var siteDirItems = new List<Thing> { new CDP4Common.SiteDirectoryData.IterationSetup() };
            var referencedSiteRdls = new List<SiteReferenceDataLibrary> { new SiteReferenceDataLibrary() };
            var engineeringModelSetups = new List<CDP4Common.SiteDirectoryData.EngineeringModelSetup> { new CDP4Common.SiteDirectoryData.EngineeringModelSetup() };
            var referencedIterationSetups = new List<CDP4Common.SiteDirectoryData.IterationSetup> { new CDP4Common.SiteDirectoryData.IterationSetup() };
            var zipFile = new ZipFile();
            
            // assert in reverse method variable order assignment to trip the proper variable exception
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, zipFile, null));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, null, null));
            
            referencedIterationSetups.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, null, null));

            engineeringModelSetups.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, null, null));
            
            referencedSiteRdls.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, null, null));

            siteDirItems.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteSiteDirectoryFile(siteDirItems, referencedSiteRdls, engineeringModelSetups, referencedIterationSetups, null, null));
        }

        [Test]
        public void VerifyWriteSiteReferenceDataLibraryFilesThrowsException()
        {
            var siteReferenceDataLibraryItems = new List<List<Thing>> { new List<Thing> { new CDP4Common.SiteDirectoryData.SimpleUnit() } };
            var zipFile = new ZipFile();

            // assert in reverse method variable order assignment to trip the proper variable exception
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteSiteReferenceDataLibraryFiles(siteReferenceDataLibraryItems, zipFile, null));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteSiteReferenceDataLibraryFiles(siteReferenceDataLibraryItems, null, null));
            
            siteReferenceDataLibraryItems.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteSiteReferenceDataLibraryFiles(siteReferenceDataLibraryItems, null, null));
        }

        [Test]
        public void VerifyWriteModelReferenceDataLibraryFilesThrowsException()
        {
            var modelReferenceDataLibraryItems = new List<List<Thing>> { new List<Thing> { new CDP4Common.SiteDirectoryData.SimpleUnit() } };
            var zipFile = new ZipFile();

            // assert in reverse method variable order assignment to trip the proper variable exception
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteModelReferenceDataLibraryFiles(modelReferenceDataLibraryItems, zipFile, null));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteModelReferenceDataLibraryFiles(modelReferenceDataLibraryItems, null, null));

            modelReferenceDataLibraryItems.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteModelReferenceDataLibraryFiles(modelReferenceDataLibraryItems, null, null));
        }

        [Test]
        public void VerifyWriteEngineeringModelFilesThrowsException()
        {
            var engineeringModelItems = new List<List<Thing>> { new List<Thing> { new EngineeringModel() } };
            var iterationItems = new List<List<Thing>>() { new List<Thing> { new CDP4Common.EngineeringModelData.Iteration() } };
            var zipFile = new ZipFile();

            // assert in reverse method variable order assignment to trip the proper variable exception
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteEngineeringModelFiles(engineeringModelItems, iterationItems, zipFile, null));
            Assert.Throws<ArgumentNullException>(() => this.dal.WriteEngineeringModelFiles(engineeringModelItems, iterationItems, null, null));
            
            iterationItems.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteEngineeringModelFiles(engineeringModelItems, iterationItems, null, null));
            
            engineeringModelItems.Clear();
            Assert.Throws<ArgumentException>(() => this.dal.WriteEngineeringModelFiles(engineeringModelItems, iterationItems, null, null));
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
            var files = new[] { "file1" };
            Assert.Throws<ArgumentNullException>(() => this.dal.Write((IEnumerable<OperationContainer>)null, files));
            Assert.Throws<ArgumentException>(() => this.dal.Write(new List<OperationContainer>(), files));

            var operationContainers = new[] { new OperationContainer("/SiteDirectory/00000000-0000-0000-0000-000000000000", 0) };
            Assert.Throws<ArgumentException>(() => this.dal.Write(operationContainers, files));

            var sitedirectoryDto = (CDP4Common.DTO.SiteDirectory)this.siteDirectoryData.ToDto();
            var clone = sitedirectoryDto.DeepClone<CDP4Common.DTO.SiteDirectory>();
            var operation = new Operation(sitedirectoryDto, clone, OperationKind.Update);
            Assert.AreEqual(0, operationContainers.Single().Operations.Count());
            operationContainers.Single().AddOperation(operation);

            Assert.AreEqual(1, operationContainers.Single().Operations.Count());
            Assert.Throws<ArgumentException>(() => this.dal.Write(operationContainers, files));

            operationContainers.Single().RemoveOperation(operation);
            Assert.AreEqual(0, operationContainers.Single().Operations.Count());

            var cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();
            var iterationIid = new Guid("b58ea73d-350d-4520-b9d9-a52c75ac2b5d");
            var iterationSetup = new IterationSetup(Guid.NewGuid(), 0);
            var iterationSetupPoco = new CDP4Common.SiteDirectoryData.IterationSetup(iterationSetup.Iid, cache, this.credentials.Uri);
            var model= new EngineeringModel(Guid.NewGuid(), cache, this.credentials.Uri);
            var modelSetup = new CDP4Common.SiteDirectoryData.EngineeringModelSetup();
            var requiredRdl = new CDP4Common.SiteDirectoryData.ModelReferenceDataLibrary();
            var person = new Person { ShortName = "admin" };
            var lazyPerson = new Lazy<Thing>(() => person);
            var iterationPoco = new CDP4Common.EngineeringModelData.Iteration(iterationIid, cache, this.credentials.Uri) { IterationSetup = iterationSetupPoco };
            model.Iteration.Add(iterationPoco);
            var iteration =  (Iteration)iterationPoco.ToDto();
            model.EngineeringModelSetup = modelSetup;
            this.siteDirectoryData.Model.Add(modelSetup);
            modelSetup.RequiredRdl.Add(requiredRdl);
            modelSetup.IterationSetup.Add(iterationSetupPoco);
            cache.TryAdd(new Tuple<Guid, Guid?>(person.Iid, this.siteDirectoryData.Iid), lazyPerson);
            this.siteDirectoryData.Cache = cache;
            iteration.IterationSetup = iterationSetup.Iid;
            var clone1 = iteration.DeepClone<Iteration>();
            operation = new Operation(iteration, clone1, OperationKind.Update);
            operationContainers = new[] { new OperationContainer("/EngineeringModel/"+model.Iid+"/iteration/"+iteration.Iid, 0) };
            operationContainers.Single().AddOperation(operation);

           Assert.IsEmpty(await this.dal.Write(operationContainers, files));
        }
    }
}
