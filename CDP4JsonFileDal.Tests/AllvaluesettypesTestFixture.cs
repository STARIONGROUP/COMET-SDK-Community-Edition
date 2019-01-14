// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllValueSetTypesTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4JsonFileDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
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

        [SetUp]
        public async Task SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "allvaluesettypes.zip");

            this.uri = new Uri(path);

            this.credentials = new Credentials("admin", "pass", this.uri);

            this.dal = new JsonFileDal();

            this.session = new Session(this.dal, this.credentials);
            await this.session.Open();

            this.nestedElementTreeGenerator = new NestedElementTreeGenerator();
        }

        [Test]
        public async Task Verfiy_that_NestedElementTree_generates_expected_ValueSets()
        {
            var siteDirectory = session.RetrieveSiteDirectory();
            var system = siteDirectory.Domain.Single(x => x.Iid == Guid.Parse("8790fe92-d1fa-42ea-9520-e0ddac52f1ad"));
            
            Assert.IsNotNull(siteDirectory);

            var engineeringModelSetup = siteDirectory.Model.Single();
            var iterationSetup = engineeringModelSetup.IterationSetup.Single();

            var engineeringModel = new EngineeringModel(engineeringModelSetup.EngineeringModelIid, engineeringModelSetup.Cache, this.uri);
            var iteration = new Iteration(iterationSetup.IterationIid, iterationSetup.Cache, this.uri);
            engineeringModel.Iteration.Add(iteration);

            await session.Read(iteration, system);

            Lazy<Thing> lazyIteration;
            session.Assembler.Cache.TryGetValue(new Tuple<Guid, Guid?>(iteration.Iid, null), out lazyIteration);

            iteration = (Iteration)lazyIteration.Value;
            Assert.IsNotNull(iteration);
            
            var option_1 = iteration.Option.Single(x => x.Iid == Guid.Parse("7476595f-e1f7-4a40-ba6f-720ce40fc0b2"));            
            Assert.AreEqual("Option 1", option_1.Name);

            var option_2 = iteration.Option.Single(x => x.Iid == Guid.Parse("635e84b2-64c4-4905-a71d-0d8e83757570"));
            Assert.AreEqual("Option 2", option_2.Name);

            var nestedElements = this.nestedElementTreeGenerator.Generate(option_1, system, false);

            Assert.AreEqual(10, nestedElements.Count());

            var nestedParameters = new List<NestedParameter>();

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine($"{nestedElement.ShortName} - {nestedElement.Name}" );

                foreach (var nestedParameter in nestedElement.NestedParameter)
                {
                    nestedParameters.Add(nestedParameter);
                }
            }

            var DT_ATO = nestedElements.Single(x => x.ShortName == "DT.ATO");
            Assert.AreEqual(12, DT_ATO.NestedParameter.Count); 
        }
    }
}