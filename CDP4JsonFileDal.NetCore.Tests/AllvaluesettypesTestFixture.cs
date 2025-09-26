// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllValueSetTypesTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4JsonFileDal.NetCore.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.DAL;

    using NUnit.Framework;

    [TestFixture]
    public class AllValueSetTypesTestFixture
    {
        private JsonFileDal dal;

        private Uri uri;

        private Credentials credentials;

        private Session session;

        private NestedElementTreeGenerator nestedElementTreeGenerator;

        private CDPMessageBus messageBus;

        [SetUp]
        public async Task SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "allvaluesettypes.zip");

            this.uri = new Uri(path);

            this.credentials = new Credentials("admin", "pass", this.uri);

            this.dal = new JsonFileDal();

            this.messageBus = new CDPMessageBus();

            this.session = new Session(this.dal, this.credentials, this.messageBus);
            await this.session.Open();

            this.nestedElementTreeGenerator = new NestedElementTreeGenerator();
        }

        [Test]
        public async Task Verfiy_that_NestedElementTree_generates_expected_ValueSets()
        {
            var siteDirectory = this.session.RetrieveSiteDirectory();
            var system = siteDirectory.Domain.Single(x => x.Iid == Guid.Parse("8790fe92-d1fa-42ea-9520-e0ddac52f1ad"));

            Assert.That(siteDirectory, Is.Not.Null);

            var engineeringModelSetup = siteDirectory.Model.Single();
            var iterationSetup = engineeringModelSetup.IterationSetup.Single();

            var engineeringModel = new EngineeringModel(engineeringModelSetup.EngineeringModelIid, engineeringModelSetup.Cache, this.uri);
            var iteration = new Iteration(iterationSetup.IterationIid, iterationSetup.Cache, this.uri);
            engineeringModel.Iteration.Add(iteration);

            await this.session.Read(iteration, system);

            Lazy<Thing> lazyIteration;
            this.session.Assembler.Cache.TryGetValue(new CacheKey(iteration.Iid, null), out lazyIteration);

            iteration = (Iteration)lazyIteration.Value;
            Assert.That(iteration, Is.Not.Null);

            var option_1 = iteration.Option.Single(x => x.Iid == Guid.Parse("7476595f-e1f7-4a40-ba6f-720ce40fc0b2"));
            Assert.That(option_1.Name, Is.EqualTo("Option 1"));

            var option_2 = iteration.Option.Single(x => x.Iid == Guid.Parse("635e84b2-64c4-4905-a71d-0d8e83757570"));
            Assert.That(option_2.Name, Is.EqualTo("Option 2"));

            var nestedElements = this.nestedElementTreeGenerator.Generate(option_1, system, false);

            Assert.That(nestedElements.Count(), Is.EqualTo(10));

            var nestedParameters = new List<NestedParameter>();

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine($"{nestedElement.ShortName} - {nestedElement.Name}");

                foreach (var nestedParameter in nestedElement.NestedParameter)
                {
                    nestedParameters.Add(nestedParameter);
                }
            }

            var DT_ATO = nestedElements.Single(x => x.ShortName == "DT.ATO");
            Assert.That(DT_ATO.NestedParameter.Count, Is.EqualTo(12));
        }
    }
}
