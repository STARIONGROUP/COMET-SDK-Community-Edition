// <copyright file="IterationRuleChecker.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Linq;
    using CDP4Rules.Common;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="IterationRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class IterationRuleCheckerTestFixture
    {
        private IterationRuleChecker iterationRuleChecker;

        private EngineeringModelSetup engineeringModelSetup;

        private IterationSetup iterationSetup;

        private EngineeringModel engineeringModel;

        private Iteration iteration;

        [SetUp]
        public void SetUp()
        {
            this.iterationRuleChecker = new IterationRuleChecker();

            this.engineeringModelSetup = new EngineeringModelSetup();
            this.iterationSetup = new IterationSetup();
            this.engineeringModelSetup.IterationSetup.Add(iterationSetup);

            this.engineeringModel = new EngineeringModel();
            this.iteration = new Iteration { Iid = Guid.Parse("37076675-f0cd-47e8-8ab4-1d2e7025f591") };
            this.engineeringModel.Iteration.Add(iteration);

            this.engineeringModel.EngineeringModelSetup = this.engineeringModelSetup;
            this.iteration.IterationSetup = this.iterationSetup;
        }

        [Test]
        public void Verify_that_when_thing_is_not_an_Iteration_an_exception_is_thrown()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => this.iterationRuleChecker.CheckWhetherACatalogueContainsNoMoreThanOneOptionPerIteration(elementDefinition));
        }

        [Test]
        public void Verify_that_when_Iteration_is_null_exception_is_thrown()
        {
            this.iteration = null;
            Assert.Throws<ArgumentNullException>(() => this.iterationRuleChecker.CheckWhetherACatalogueContainsNoMoreThanOneOptionPerIteration(iteration));
        }

        [Test]
        public void Verify_that_when_catalogue_contains_more_than_one_option_result_is_returned()
        {
            this.engineeringModelSetup.Kind = EngineeringModelKind.MODEL_CATALOGUE;
            
            var option_1 = new Option();
            var option_2 = new Option();

            this.iteration.Option.Add(option_1);
            this.iteration.Option.Add(option_2);

            var results = this.iterationRuleChecker.CheckWhetherACatalogueContainsNoMoreThanOneOptionPerIteration(this.iteration);
            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo("MA-0900"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
            Assert.That(result.Description, Is.EqualTo("The Iteration 37076675-f0cd-47e8-8ab4-1d2e7025f591 is contained by a MODEL_CATALOGUE and contains more than one Option"));
            Assert.That(result.Thing, Is.EqualTo(this.iteration));
        }

        [Test]
        public void Verify_that_when_an_EngineeringModel_is_not_a_catalogue_and_contains_more_than_one_option_no_result_is_returned()
        {
            this.engineeringModelSetup.Kind = EngineeringModelKind.STUDY_MODEL;

            var option_1 = new Option();
            var option_2 = new Option();

            this.iteration.Option.Add(option_1);
            this.iteration.Option.Add(option_2);

            var results = this.iterationRuleChecker.CheckWhetherACatalogueContainsNoMoreThanOneOptionPerIteration(this.iteration);
            
            Assert.That(results, Is.Empty);
        }
    }
}