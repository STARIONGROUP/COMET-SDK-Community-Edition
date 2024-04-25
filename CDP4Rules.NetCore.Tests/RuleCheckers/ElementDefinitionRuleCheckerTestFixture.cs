// <copyright file="ElementDefinitionRuleCheckerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ElementDefinitionRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class ElementDefinitionRuleCheckerTestFixture
    {
        private ElementDefinitionRuleChecker elementDefinitionRuleChecker;

        private ElementDefinition elementDefinition;

        private Parameter Parameter_1;
        
        private Parameter Parameter_2;

        private TextParameterType textParameterType_1;

        private TextParameterType textParameterType_2;

        [SetUp]
        public void SetUp()
        {
            this.elementDefinitionRuleChecker = new ElementDefinitionRuleChecker();

            this.elementDefinition = new ElementDefinition();
            this.Parameter_1 = new Parameter { Iid = Guid.Parse("d9ac20be-1578-47cc-81e1-a60c8533c266") };
            this.Parameter_2 = new Parameter { Iid = Guid.Parse("7b67663b-13c6-40c2-b31a-28b109333ee3") };
            this.textParameterType_1 = new TextParameterType();
            this.textParameterType_2 = new TextParameterType();

            this.elementDefinition.Parameter.Add(this.Parameter_1);
            this.elementDefinition.Parameter.Add(this.Parameter_2);

            this.Parameter_1.ParameterType = textParameterType_1;
            this.Parameter_2.ParameterType = textParameterType_2;
        }

        [Test]
        public void Verify_that_when_Check_is_called_with_null_exception_isThrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueShortNames(null));
        }

        [Test]
        public void Verify_that_when_Check_is_called_with_not_ElementDefinition_exception_isThrown()
        {
            var alias = new Alias();
            Assert.Throws<ArgumentException>(() => this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueShortNames(alias));
        }

        [Test]
        public void Verify_that_when_ElementDefinition_contains_parameters_with_duplicate_shortnames_a_result_is_returned()
        {
            this.textParameterType_1.ShortName = "TEXT";
            this.textParameterType_2.ShortName = "TEXT";

            var result = this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueShortNames(this.elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0620"));
            Assert.That(result.Description, Is.EqualTo("The ElementDefinition contains Parameters with non-unique short names: d9ac20be-1578-47cc-81e1-a60c8533c266,7b67663b-13c6-40c2-b31a-28b109333ee3:TEXT,TEXT"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.elementDefinition));
        }

        [Test]
        public void Verify_that_when_ElementDefinition_contains_parameters_with_unique_shortnames_no_result_is_returned()
        {
            this.textParameterType_1.ShortName = "TEXT_1";
            this.textParameterType_2.ShortName = "TEXT_2";

            var results = this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueShortNames(this.elementDefinition);

            Assert.That(results, Is.Empty);
        }

        [Test]
        public void Verify_that_when_ElementDefinition_contains_parameters_with_duplicate_names_a_result_is_returned()
        {
            this.textParameterType_1.Name = "TEXT";
            this.textParameterType_2.Name = "TEXT";

            var result = this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueNames(this.elementDefinition).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0610"));
            Assert.That(result.Description, Is.EqualTo("The ElementDefinition contains Parameters with non-unique names: d9ac20be-1578-47cc-81e1-a60c8533c266,7b67663b-13c6-40c2-b31a-28b109333ee3:TEXT,TEXT"));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Error));
            Assert.That(result.Thing, Is.EqualTo(this.elementDefinition));
        }

        [Test]
        public void Verify_that_when_ElementDefinition_contains_parameters_with_unique_names_no_result_is_returned()
        {
            this.textParameterType_1.Name = "TEXT_1";
            this.textParameterType_2.Name = "TEXT_2";

            var results = this.elementDefinitionRuleChecker.CheckWhetherContainerParametersHaveUniqueNames(this.elementDefinition);

            Assert.That(results, Is.Empty);
        }
    }
}


