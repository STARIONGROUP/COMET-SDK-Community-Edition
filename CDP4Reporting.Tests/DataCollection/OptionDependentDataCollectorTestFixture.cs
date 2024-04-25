// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionDependentDataCollectorTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2023 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class OptionDependentDataCollectorTestFixture
    {
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;

        private Iteration iteration;

        private Option option1;

        private Option option2;

        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null);

            // Option 1
            this.option1 = new Option(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "option1",
                Name = "option1"
            };

            // Option 2
            this.option2 = new Option(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "option2",
                Name = "option2"
            };

            this.iteration.Option.Add(this.option1);
            this.iteration.Option.Add(this.option2);
        }

        [Test]
        public void Verify_that_SelectedOption_Is_First_Option_If_No_DefaultOption_Is_Defined()
        {
            var dataCollector = new TestOptionDependentDataCollector();
            dataCollector.Initialize(this.iteration, null);

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option1));
        }

        [Test]
        public void Verify_that_SelectedOption_Is_DefaultOption_If_DefaultOption_Is_Defined()
        {
            var dataCollector = new TestOptionDependentDataCollector();
            dataCollector.Initialize(this.iteration, null);
            this.iteration.DefaultOption = this.option2;

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option2));
        }

        [Test]
        public void Verify_that_SelectOption_Is_Not_Called_When_Iteration_Contains_Single_Option()
        {
            var dataCollector = new TestOptionDependentDataCollector();
            dataCollector.Initialize(this.iteration, null);
            this.iteration.Option.Remove(this.option2);

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option1));

            var optionSelectorWasCalled = false;

            ReportScript.ReportingSettings.OptionSelector = (list, option) =>
            {
                optionSelectorWasCalled = true;
                return null;
            };

            Assert.DoesNotThrow(() => dataCollector.SelectOption());

            Assert.That(optionSelectorWasCalled, Is.False);

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option1));
        }

        [Test]
        public void Verify_that_SelectOption_Is_Called_When_Iteration_Contains_Multiple_Options()
        {
            var dataCollector = new TestOptionDependentDataCollector();
            dataCollector.Initialize(this.iteration, null);
            this.iteration.DefaultOption = this.option1;

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option1));

            var optionSelectorWasCalled = false;

            ReportScript.ReportingSettings.OptionSelector = (list, option) =>
            {
                optionSelectorWasCalled = true;
                return this.option2;
            };

            Assert.DoesNotThrow(() => dataCollector.SelectOption());

            Assert.That(optionSelectorWasCalled, Is.True);

            Assert.That(dataCollector.SelectedOption, Is.EqualTo(this.option2));
        }

        private class TestOptionDependentDataCollector : OptionDependentDataCollector
        {
            public override object CreateDataObject()
            {
                return null;
            }
        }
    }
}
