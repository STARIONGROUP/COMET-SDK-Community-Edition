// <copyright file="RequirementStateOfComplianceTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4RequirementsVerification.Tests.Calculations
{
    using CDP4Common.EngineeringModelData;

    using CDP4RequirementsVerification.Calculations;
    using CDP4RequirementsVerification.Tests.Builders;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="RequirementStateOfComplianceCalculatorTestFixture"/> class.
    /// </summary>
    [TestFixture]
    public class RequirementStateOfComplianceCalculatorTestFixture
    {
        private RequirementStateOfComplianceCalculator requirementStateOfComplianceCalculator;
  
        private const double HighValue = 2D;
        private const double LowValue = 1D;

        [SetUp]
        public void SetUp()
        {
            this.requirementStateOfComplianceCalculator = new RequirementStateOfComplianceCalculator();
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void Verify_that_state_of_compliances_are_properly_calculated(
            double value1, double value2, RelationalOperatorKind relationalOperatorKind, RequirementStateOfCompliance expectedResult)
        {
            var relationalExpression =
                new RelationalExpressionBuilder()
                    .WithSimpleQuantityKindParameterType()
                    .WithValue(value1)
                    .WithRelationalOperatorKind(relationalOperatorKind)
                    .Build();

            var parameter = new ParameterBuilder()
                .WithSimpleQuantityKindParameterType()
                .WithValue(value2)
                .Build();

            Assert.AreEqual(expectedResult, this.requirementStateOfComplianceCalculator.Calculate(parameter.ValueSet[0], relationalExpression));
        }

        public static object[] TestCases =
        {
            new object[] { LowValue, LowValue, RelationalOperatorKind.EQ, RequirementStateOfCompliance.Pass },
            new object[] { LowValue, LowValue, RelationalOperatorKind.NE, RequirementStateOfCompliance.Failed },
            new object[] { LowValue, LowValue, RelationalOperatorKind.GE, RequirementStateOfCompliance.Pass},
            new object[] { LowValue, LowValue, RelationalOperatorKind.GT, RequirementStateOfCompliance.Failed },
            new object[] { LowValue, LowValue, RelationalOperatorKind.LE, RequirementStateOfCompliance.Pass },
            new object[] { LowValue, LowValue, RelationalOperatorKind.LT, RequirementStateOfCompliance.Failed },

            new object[] { LowValue, HighValue, RelationalOperatorKind.EQ, RequirementStateOfCompliance.Failed },
            new object[] { LowValue, HighValue, RelationalOperatorKind.NE, RequirementStateOfCompliance.Pass },
            new object[] { LowValue, HighValue, RelationalOperatorKind.GE, RequirementStateOfCompliance.Pass },
            new object[] { LowValue, HighValue, RelationalOperatorKind.GT, RequirementStateOfCompliance.Pass },
            new object[] { LowValue, HighValue, RelationalOperatorKind.LE, RequirementStateOfCompliance.Failed },
            new object[] { LowValue, HighValue, RelationalOperatorKind.LT, RequirementStateOfCompliance.Failed },

            new object[] { HighValue, LowValue, RelationalOperatorKind.EQ, RequirementStateOfCompliance.Failed },
            new object[] { HighValue, LowValue, RelationalOperatorKind.NE, RequirementStateOfCompliance.Pass },
            new object[] { HighValue, LowValue, RelationalOperatorKind.GE, RequirementStateOfCompliance.Failed },
            new object[] { HighValue, LowValue, RelationalOperatorKind.GT, RequirementStateOfCompliance.Failed },
            new object[] { HighValue, LowValue, RelationalOperatorKind.LE, RequirementStateOfCompliance.Pass }, 
            new object[] { HighValue, LowValue, RelationalOperatorKind.LT, RequirementStateOfCompliance.Pass },

            new object[] { HighValue, HighValue, RelationalOperatorKind.EQ, RequirementStateOfCompliance.Pass },
            new object[] { HighValue, HighValue, RelationalOperatorKind.NE, RequirementStateOfCompliance.Failed },
            new object[] { HighValue, HighValue, RelationalOperatorKind.GE, RequirementStateOfCompliance.Pass },
            new object[] { HighValue, HighValue, RelationalOperatorKind.GT, RequirementStateOfCompliance.Failed },
            new object[] { HighValue, HighValue, RelationalOperatorKind.LE, RequirementStateOfCompliance.Pass },
            new object[] { HighValue, HighValue, RelationalOperatorKind.LT, RequirementStateOfCompliance.Failed }
        };
    }
}
