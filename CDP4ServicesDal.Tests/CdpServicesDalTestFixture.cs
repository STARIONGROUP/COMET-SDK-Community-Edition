// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpServicesDalTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2018 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
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
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;
    using NUnit.Framework;
    
    /// <summary>
    /// Suite of tests for the <see cref="CdpServicesDal"/> class
    /// </summary>
    [TestFixture]
    public class CdpServicesDalTestFixture
    {
        private CdpServicesDal dal;
        private Credentials credentials;
        private List<Parameter> headers;
        private ISession session;

        private readonly Uri uri = new Uri("https://cdp4services-test.rheagroup.com");
        private CancellationTokenSource cancelationTokenSource;
        
        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private EngineeringModelSetup engineeringModelSetup;
        private Iteration iteration;
        private IterationSetup iterationSetup;
        private SiteReferenceDataLibrary siteReferenceDataLibrary;
        private ModelReferenceDataLibrary modelReferenceDataLibrary;

        [SetUp]
        public void Setup()
        {
            this.cancelationTokenSource = new CancellationTokenSource();
            
            this.credentials = new Credentials("admin", "pass", this.uri);
            this.dal = new CdpServicesDal();
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
            this.session = null;
        }

        [Test]
        public void VerifyThatCdpServicesDalCanBeConstructed()
        {
            var dal = new CdpServicesDal();
            Assert.IsNotNull(dal);
        }
        
        [Test]
        public void VerifyThatCDPPostBodyIsCorrectlyResolves()
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

            var request = this.dal.ConstructPostRequestBody(operationContainer);

            Assert.NotNull(request);
        }

        [Test]
        public async Task VerifyThatOpenReturnsDTOs()
        {
            var dal = new CdpServicesDal();
            var result = await dal.Open(this.credentials, new CancellationToken());

            var amountOfDtos = result.ToList().Count;

            Assert.AreEqual(60, amountOfDtos);
        }

        [Test]
        public async Task VerifThatAClosedDalCannotBeClosedAgain()
        {
            var dal = new CdpServicesDal();
            await dal.Open(this.credentials, new CancellationToken());

            dal.Close();

            Assert.Throws<InvalidOperationException>(() => dal.Close());
        }

        [Test]
        public void VerifyThatIsValidUriReturnsExpectedResult()
        {
            var dal = new CdpServicesDal();

            Assert.IsTrue(dal.IsValidUri("http://cdp4services-test.rheagroup.com"));
            Assert.IsTrue(dal.IsValidUri("https://cdp4services-test.rheagroup.com"));
            Assert.IsFalse(dal.IsValidUri("file://some file"));
        }

        [Test]        
        public async Task VerifyThatIfCredentialsAreNullExceptionIsThrown()
        {
            var dal = new CdpServicesDal();

            Assert.That(async () => await dal.Open(null, new CancellationToken()), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public async Task VerifyThatIfNotHttpOrHttpsExceptionIsThrown()
        {
            var uri = new Uri("https://cdp4services-test.rheagroup.com");
            var invalidCredentials = new Credentials("John", "a password", uri);

            Assert.That(async () => await dal.Open(invalidCredentials, new CancellationToken()), Throws.TypeOf<DalReadException>());
        }
        
        [Test]
        public async Task VerifyThatSessionMustBeSetToReadIteration()
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

            var contextOne = string.Format("/EngineeringModel/{0}/iteration/{1}", Guid.NewGuid(), Guid.NewGuid());
            var contextTwo = string.Format("/EngineeringModel/{0}/iteration/{1}", Guid.NewGuid(), Guid.NewGuid());

            var operationContainerOne = new OperationContainer(contextOne);
            var operationContainerTwo = new OperationContainer(contextTwo);

            var operationContainers = new List<OperationContainer> { operationContainerOne, operationContainerTwo };

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));

            Assert.Throws<NotSupportedException>(() => dal.Write(operationContainers));
        }

        [Test]
        public async Task Verify_that_opens_returns_expected_result()
        {
            var uri = new Uri("https://cdp4services-test.rheagroup.com");
            this.credentials = new Credentials("admin", "pass", uri);

            var dal = new CdpServicesDal();
            var result = await dal.Open(this.credentials, new CancellationToken());
            
            Assert.NotNull(result);            
        }

        ///EngineeringModel/9ec982e4-ef72-4953-aa85-b158a95d8d56/iteration

        [Test]
        public async Task Verify_that_multiple_read_requests_can_be_made_in_parallel()
        {
            var uri = new Uri("https://cdp4services-test.rheagroup.com");
            var credentials = new Credentials("admin", "pass", uri);
            var assembler = new Assembler(this.uri);
            
            var dal = new CdpServicesDal();
            var session = new Session(dal, credentials);
            
            var result = await dal.Open(credentials, new CancellationToken());

            var siteDirectory = result.OfType<CDP4Common.DTO.SiteDirectory>().Single();

            var queryAttributes = new QueryAttributes {Extent = ExtentQueryAttribute.deep};

            for (int i = 0; i < 9; i++)
            {
                dal.Read(siteDirectory, new CancellationToken(), queryAttributes);
            }

            var readresult = await dal.Read(siteDirectory, new CancellationToken());
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
    }
}