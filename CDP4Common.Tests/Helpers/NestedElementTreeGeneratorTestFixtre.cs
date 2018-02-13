#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeGeneratorTestFixtre.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="NestedElementTreeGenerator"/> class.
    /// </summary>
    [TestFixture]
    public class NestedElementTreeGeneratorTestFixtre
    {
        private NestedElementTreeGenerator nestedElementTreeGenerator;
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;
        private Iteration iteration;
        private DomainOfExpertise domainOfExpertise;


        [SetUp]
        public void SetUp()
        {
            this.nestedElementTreeGenerator = new NestedElementTreeGenerator();
            
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.domainOfExpertise = new DomainOfExpertise(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "SYS",
                Name = "System"
            };
            
            this.iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);

            var option_A = new Option(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "OPT_A",
                Name = "Option A"
            };
            this.iteration.Option.Add(option_A);
            this.iteration.DefaultOption = option_A;

            var option_B = new Option(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "OPT_B",
                Name = "Option B"
            };
            this.iteration.Option.Add(option_B);

            var satellite = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "Sat",
                Name = "Satellite"
            };
            this.iteration.Element.Add(satellite);
            this.iteration.TopElement = satellite;

            var battery = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "Bat",
                Name = "Battery"
            };
            this.iteration.Element.Add(battery);

            var battery_a = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = battery,
                ShortName = "bat_a",
                Name = "battery a"
            };
            satellite.ContainedElement.Add(battery_a);
            
            var battery_b = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = battery,
                ShortName = "bat_b",
                Name = "battery b"                
            };
            battery_b.ExcludeOption.Add(option_A);

            satellite.ContainedElement.Add(battery_b);
        }

        [Test]
        public void Verify_that_null_arguments_throws_exception()
        {
            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.Generate(null, null));

            var option = this.iteration.Option.First();
            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.Generate(option, null));
        }

        [Test]
        public void Verify_that_excluded_usage_option_a_does_not_get_generated_as_nested_element()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");
            
            var nestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise);

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(2, nestedElements.Count());
        }

        [Test]
        public void Verify_that_excluded_usage_option_a_does_not_get_generated_as_nested_element_if_option_is_a_cloned_object()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");
            var optionClone = option.Clone(false);

            var nestedElements = this.nestedElementTreeGenerator.Generate(optionClone, this.domainOfExpertise);

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(2, nestedElements.Count());
        }

        [Test]
        public void Verify_that_excluded_usage_from_a_In_option_b_get_generated_as_nested_element()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_B");

            var nestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise);

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(3, nestedElements.Count());
        }
    }
}