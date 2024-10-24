﻿// <copyright file="ReferencerRuleRuleChecker.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2021 Starion Group S.A.
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

namespace CDP4Rules.RuleCheckers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="ReferencerRuleRuleChecker"/> is to execute the rules for instances of type <see cref="ReferencerRule"/>
    /// </summary>
    [RuleChecker(typeof(ReferencerRule))]
    public class ReferencerRuleRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ReferencerRule"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ReferencerRule"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var referencerRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (!referencerRule.IsDeprecated)
            {
                if (referencerRule.ReferencingCategory.IsDeprecated)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"The referenced Category {referencerRule.ReferencingCategory.Iid}:{referencerRule.ReferencingCategory.ShortName} of ReferencerRule.ReferencingCategory is deprecated",
                        SeverityKind.Warning);
                    results.Add(result);
                }

                foreach (var category in referencerRule.ReferencedCategory)
                {
                    if (category.IsDeprecated)
                    {
                        var result = new RuleCheckResult(thing, rule.Id,
                            $"The referenced Category {category.Iid}:{category.ShortName} in ReferencerRule.ReferencedCategory is deprecated",
                            SeverityKind.Warning);
                        results.Add(result);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="Category"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ReferencerRule"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ReferencerRule"/>
        /// </exception>
        [Rule("MA-0200")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedCategoryIsInChainOfRdls(Thing thing)
        {
            var referencerRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)referencerRule.Container;

            if (!referenceDataLibrary.IsCategoryInChainOfRdls(referencerRule.ReferencingCategory))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The ReferencerRule.RelationshipCategory {referencerRule.ReferencingCategory.Iid}:{referencerRule.ReferencingCategory.ShortName} of {referencerRule.Iid}:{referencerRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            foreach (var category in referencerRule.ReferencedCategory)
            {
                if (!referenceDataLibrary.IsCategoryInChainOfRdls(category))
                {
                    var result = new RuleCheckResult(thing, rule.Id, $"The ReferencerRule.ReferencedCategory {category.Iid}:{category.ShortName} of {referencerRule.Iid}:{referencerRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                    results.Add(result);
                }
            }

            return results;
        }

        /// <summary>
        /// Verifies that the <see cref="Thing"/> is of the correct type
        /// </summary>
        /// <param name="thing">
        /// the subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="ReferencerRule"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ReferencerRule"/>
        /// </exception>
        private ReferencerRule VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var referencerRule = thing as ReferencerRule;
            if (referencerRule == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ReferencerRule", nameof(thing));
            }

            return referencerRule;
        }
    }
}