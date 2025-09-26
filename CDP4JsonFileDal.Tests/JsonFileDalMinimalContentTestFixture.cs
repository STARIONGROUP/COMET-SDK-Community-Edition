﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonFileDalMinimalContentTestFixture.cs" company="Starion Group S.A.">
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonFileDal.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;

    using CDP4Dal;
    using CDP4Dal.DAL;

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
        private CDPMessageBus messageBus;

        [SetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "files", "minimalcontent.zip");

            this.credentials = new Credentials("admin", "pass", new Uri(path));
            this.dal = new JsonFileDal();

            this.messageBus = new CDPMessageBus();

            this.session = new Session(this.dal, this.credentials, this.messageBus);
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
            Assert.That(this.session.Assembler.Cache.Count, Is.EqualTo(62));

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

            Assert.That(this.session.Assembler.Cache.Count, Is.EqualTo(93));

            var siteReferenceDataLibrary = this.session.Assembler.Cache.Select(x => x.Value)
                .Where(lazy => lazy.Value.ClassKind == ClassKind.SiteReferenceDataLibrary)
                .Select(lazy => lazy.Value)
                .Cast<CDP4Common.SiteDirectoryData.SiteReferenceDataLibrary>().Single(x => x.Iid == Guid.Parse("bff9f871-3b7f-4e57-ac82-5ab499f9baf5"));

            Assert.That(siteReferenceDataLibrary, Is.Not.Null);

            Assert.That(siteReferenceDataLibrary.ParameterType, Is.Not.Empty);

            var simpleQuantityKind = siteReferenceDataLibrary.ParameterType.Single(x => x.Iid == Guid.Parse("66766f44-0a0b-4e0a-9bc7-8ae027c2da5c"));

            Assert.That(simpleQuantityKind.Name, Is.EqualTo("length"));
            Assert.That(simpleQuantityKind.ShortName, Is.EqualTo("l"));
        }
    }
}
