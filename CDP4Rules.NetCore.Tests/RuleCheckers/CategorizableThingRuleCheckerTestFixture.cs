// <copyright file="CategorizableThingRuleCheckerTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CategorizableThingRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class CategorizableThingRuleCheckerTestFixture
    {
        private CategorizableThingRuleChecker categorizableThingRuleChecker;

        [SetUp]
        public void SetUp()
        {
            this.categorizableThingRuleChecker = new CategorizableThingRuleChecker();
        }

        [Test]
        public void Verify_that_when_CheckWhetherThereAreNoDuplicateCategoriesAreDefined_is_called_with_null_thing_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(null));
        }

        [Test]
        public void Verify_that_when_CheckWhetherThereAreNoDuplicateCategoriesAreDefined_is_called_with_non_categorizable_thing_exception_is_thrown()
        {
            var unit = new SimpleUnit();

            Assert.Throws<ArgumentException>(() => this.categorizableThingRuleChecker.CheckWhetherThereAreNoDuplicateCategoriesAreDefined(unit));
        }
    }
}