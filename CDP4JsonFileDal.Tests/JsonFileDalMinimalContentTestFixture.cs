// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalMinimalContentTestFixture.cs" company="RHEA System S.A.">
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
    using System.Reactive.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.MetaInfo;

    using CDP4Dal;
    using CDP4Dal.DAL;
    using CDP4Dal.Events;
    using CDP4Dal.Operations;

    using CDP4JsonFileDal;
    using CDP4JsonFileDal.Json;

    using Ionic.Zip;
    using Microsoft.Practices.ServiceLocation;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests that verifies that the <see cref="JsonFileDal"/> reads the 
    /// minimalcontent.zip file properly
    /// </summary>
    [TestFixture]
    public class JsonFileDalMinimalContentTestFixture
    {
        private JsonFileDal dal;
        private Credentials credentials;
        private Session session;
        
        [SetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "minimalcontent.zip");
            
            this.credentials = new Credentials("admin", "pass", new Uri(path));
            this.dal = new JsonFileDal();

            this.session = new Session(this.dal, this.credentials);
        }

        [TearDown]
        public void TearDown()
        {
            this.credentials = null;
            this.dal = null;
        }

        [Test]
        public async Task VerifyThatSiteDirectoryCanBeOpened()
        {
            await this.session.Open();
            Assert.AreEqual(62, this.session.Assembler.Cache.Count);

            var iterationSetups =
                    this.session.Assembler.Cache.Select(x => x.Value)
                        .Where(lazy => lazy.Value.ClassKind == ClassKind.IterationSetup)
                        .Select(lazy => lazy.Value)
                        .Cast<CDP4Common.SiteDirectoryData.IterationSetup>();

            var iterationSetupToRead =
                iterationSetups.Single(x => x.Iid == Guid.Parse("11111111-0c20-417a-a83f-c80fbc93e394"));

            var engineeringModelSetup = (CDP4Common.SiteDirectoryData.EngineeringModelSetup)iterationSetupToRead.Container;

            var domainsOfExpertise = this.session.Assembler.Cache.Select(x => x.Value)
                        .Where(lazy => lazy.Value.ClassKind == ClassKind.DomainOfExpertise)
                        .Select(lazy => lazy.Value)
                        .Cast<CDP4Common.SiteDirectoryData.DomainOfExpertise>();

            var domainOfExpertise = domainsOfExpertise.Single(x => x.Iid == Guid.Parse("8790fe92-d1fa-42ea-9520-e0ddac52f1ad"));

            var model = new CDP4Common.EngineeringModelData.EngineeringModel(engineeringModelSetup.EngineeringModelIid, this.session.Assembler.Cache, this.session.Credentials.Uri)
            { EngineeringModelSetup = engineeringModelSetup };
            var iteration = new CDP4Common.EngineeringModelData.Iteration(iterationSetupToRead.IterationIid, this.session.Assembler.Cache, this.session.Credentials.Uri);

            model.Iteration.Add(iteration);

            await this.session.Read(iteration, domainOfExpertise);

            Assert.AreEqual(93, this.session.Assembler.Cache.Count);

            var siteReferenceDataLibrary = this.session.Assembler.Cache.Select(x => x.Value)
                        .Where(lazy => lazy.Value.ClassKind == ClassKind.SiteReferenceDataLibrary)
                        .Select(lazy => lazy.Value)
                        .Cast<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary>().Single(x => x.Iid == Guid.Parse("bff9f871-3b7f-4e57-ac82-5ab499f9baf5"));

            Assert.IsNotNull(siteReferenceDataLibrary);

            Assert.IsNotEmpty(siteReferenceDataLibrary.ParameterType);

            var simpleQuantityKind = siteReferenceDataLibrary.ParameterType.Single(x => x.Iid == Guid.Parse("66766f44-0a0b-4e0a-9bc7-8ae027c2da5c"));

            Assert.AreEqual("length", simpleQuantityKind.Name);
            Assert.AreEqual("l", simpleQuantityKind.ShortName);            
        }
    }
}
