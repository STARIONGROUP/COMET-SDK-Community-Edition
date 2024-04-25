// <copyright file="ElementDefinitionRuleChecker.cs" company="Starion Group S.A.">
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
    using CDP4Common.EngineeringModelData;

    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="ElementDefinitionRuleChecker"/> is to execute the rules for instances of type <see cref="ElementDefinition"/>
    /// </summary>
    [RuleChecker(typeof(ElementDefinition))]
    public class ElementDefinitionRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether the contained <see cref="Parameter"/>s have unique shortnames
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ElementDefinition"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ElementDefinition"/>
        /// </exception>
        [Rule("MA-0610")]
        public IEnumerable<RuleCheckResult> CheckWhetherContainerParametersHaveUniqueNames(Thing thing)
        {
            var elementDefinition = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var duplicates = elementDefinition.Parameter.GroupBy(p => p.ParameterType.Name).Where(grp => grp.Count() > 1).SelectMany(d => d).ToList();

            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(p => p.Iid));
                var duplicateNames = string.Join(",", duplicates.Select(p => p.ParameterType.Name));

                var result = new RuleCheckResult(thing, rule.Id, $"The ElementDefinition contains Parameters with non-unique names: {duplicateIdentifiers}:{duplicateNames}", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether the contained <see cref="Parameter"/>s have unique shortnames
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ElementDefinition"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ElementDefinition"/>
        /// </exception>
        [Rule("MA-0620")]
        public IEnumerable<RuleCheckResult> CheckWhetherContainerParametersHaveUniqueShortNames(Thing thing)
        {
            var elementDefinition = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var duplicates = elementDefinition.Parameter.GroupBy(p => p.ParameterType.ShortName).Where(grp => grp.Count() > 1).SelectMany(d => d).ToList();

            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(p => p.Iid));
                var duplicateShortNames = string.Join(",", duplicates.Select(p => p.ParameterType.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The ElementDefinition contains Parameters with non-unique short names: {duplicateIdentifiers}:{duplicateShortNames}", SeverityKind.Error);
                results.Add(result);
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
        /// an instance of <see cref="ElementDefinition"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ElementDefinition"/>
        /// </exception>
        private ElementDefinition VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var elementDefinition = thing as ElementDefinition;
            if (elementDefinition == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ElementDefinition", nameof(thing));
            }

            return elementDefinition;
        }
    }
}