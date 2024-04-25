// <copyright file="ParameterizedCategoryRuleRuleChecker.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="ParameterizedCategoryRuleRuleChecker"/> is to execute the rules for instances of type <see cref="ParameterizedCategoryRule"/>
    /// </summary>
    [RuleChecker(typeof(ParameterizedCategoryRule))]
    public class ParameterizedCategoryRuleRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ParameterizedCategoryRule"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterizedCategoryRule"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var parameterizedCategoryRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (!parameterizedCategoryRule.IsDeprecated)
            {
                if (parameterizedCategoryRule.Category.IsDeprecated)
                {
                    var result = new RuleCheckResult(thing, rule.Id,
                        $"The referenced Category {parameterizedCategoryRule.Category.Iid}:{parameterizedCategoryRule.Category.ShortName} of ParameterizedCategoryRule.Category is deprecated",
                        SeverityKind.Warning);
                    results.Add(result);
                }

                foreach (var parameterType in parameterizedCategoryRule.ParameterType)
                {
                    if (parameterType.IsDeprecated)
                    {
                        var result = new RuleCheckResult(thing, rule.Id,
                            $"The referenced ParameterType {parameterType.Iid}:{parameterType.ShortName} in ParameterizedCategoryRule.ParameterType is deprecated",
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
        /// The subject <see cref="ParameterizedCategoryRule"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterizedCategoryRule"/>
        /// </exception>
        [Rule("MA-0200")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedCategoryIsInChainOfRdls(Thing thing)
        {
            var parameterizedCategoryRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)parameterizedCategoryRule.Container;

            if (!referenceDataLibrary.IsCategoryInChainOfRdls(parameterizedCategoryRule.Category))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The ParameterizedCategoryRule.Category {parameterizedCategoryRule.Category.Iid}:{parameterizedCategoryRule.Category.ShortName} of {parameterizedCategoryRule.Iid}:{parameterizedCategoryRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="ParameterType"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterizedCategoryRule"/>
        /// </exception>
        [Rule("MA-0220")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedParameterTypeIsInChainOfRdls(Thing thing)
        {
            var parameterizedCategoryRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary) thing.Container;

            foreach (var parameterType in parameterizedCategoryRule.ParameterType)
            {
                if (!referenceDataLibrary.IsParameterTypeInChainOfRdls(parameterType))
                {
                    var result = new RuleCheckResult(thing, rule.Id, $"The referenced ParameterType {parameterType.Iid}:{parameterType.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
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
        /// an instance of <see cref="ParameterizedCategoryRule"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ParameterizedCategoryRule"/>
        /// </exception>
        private ParameterizedCategoryRule VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var parameterizedCategoryRule = thing as ParameterizedCategoryRule;
            if (parameterizedCategoryRule == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ParameterizedCategoryRule", nameof(thing));
            }

            return parameterizedCategoryRule;
        }
    }
}