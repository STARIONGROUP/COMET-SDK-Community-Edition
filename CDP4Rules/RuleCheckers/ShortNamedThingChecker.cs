// <copyright file="ShortNamedThingChecker.cs" company="Starion Group S.A.">
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
    using System.Text.RegularExpressions;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;

    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="ShortNamedThingChecker"/> is to execute the rules for instances of type <see cref="IShortNamedThing"/>
    /// </summary>
    [RuleChecker(typeof(IShortNamedThing))]
    public class ShortNamedThingChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether the ShortName of a <see cref="IShortNamedThing"/> is valid
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="IShortNamedThing"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="IShortNamedThing"/>
        /// </exception>
        [Rule("MA-0010")]
        public IEnumerable<RuleCheckResult> CheckWhetherTheShortNameIsAValidShortName(Thing thing)
        {
            var shortNamedThing = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            switch (thing)
            {
                case ElementBase elementBase:
                {
                    var result = this.CheckShortNameValidityOfElementBase(elementBase, rule);
                    if (result != null)
                    {
                        results.Add(result);
                    }

                    break;
                }

                case RequirementsContainer requirementsContainer:
                {
                    var result = this.CheckShortNameValidityOfRequirementsContainer(requirementsContainer, rule);
                    if (result != null)
                    {
                        results.Add(result);
                    }

                    break;
                }

                default:
                {
                    var result = this.CheckShortNameValidityOfShortNamedThing(shortNamedThing, rule);
                    if (result != null)
                    {
                        results.Add(result);
                    }

                    break;
                }
            }

            return results;
        }

        /// <summary>
        /// Checks the validity of the <see cref="DefinedThing.ShortName"/> property
        /// </summary>
        /// <param name="elementBase">
        /// the subject <see cref="ElementBase"/>
        /// </param>
        /// <param name="rule">
        /// the corresponding <see cref="IRule"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/> when the rule is violated, or null when all is good
        /// </returns>
        private RuleCheckResult CheckShortNameValidityOfElementBase(ElementBase elementBase, IRule rule)
        {
            if (!Regex.IsMatch(elementBase.ShortName, "^[a-zA-Z][a-zA-Z0-9_]*$"))
            {
                return new RuleCheckResult(elementBase, rule.Id, $"The ShortName: {elementBase.ShortName} is invalid. The ShortName must start with a letter and not contain any spaces or non alphanumeric characters.", rule.Severity);
            }

            return null;
        }

        /// <summary>
        /// Checks the validity of the <see cref="RequirementsContainer"/> ShortName property
        /// </summary>
        /// <param name="requirementsContainer">
        /// the subject <see cref="RequirementsContainer"/>
        /// </param>
        /// <param name="rule">
        /// the corresponding <see cref="IRule"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/> when the rule is violated, or null when all is good
        /// </returns>
        private RuleCheckResult CheckShortNameValidityOfRequirementsContainer(RequirementsContainer requirementsContainer, IRule rule)
        {
            if (!Regex.IsMatch(requirementsContainer.ShortName, "^[a-zA-Z][a-zA-Z0-9_]*$"))
            {
                return new RuleCheckResult(requirementsContainer, rule.Id, $"The ShortName: {requirementsContainer.ShortName} is invalid. The ShortName must start with a letter and not contain any spaces or non alphanumeric characters.", rule.Severity);
            }

            return null;
        }
        
        /// <summary>
        /// Checks the validity of the <see cref="IShortNamedThing.ShortName"/> property
        /// </summary>
        /// <param name="shortNamedThing"></param>
        /// the subject <see cref="IShortNamedThing"/>
        /// <param name="rule">
        /// the corresponding <see cref="IRule"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/> when the rule is violated, or null when all is good
        /// </returns>
        private RuleCheckResult CheckShortNameValidityOfShortNamedThing(IShortNamedThing shortNamedThing, IRule rule)
        {
            if (Regex.IsMatch(shortNamedThing.ShortName, @"\w\s"))
            {
                var thing = shortNamedThing as Thing;
                return new RuleCheckResult(thing, rule.Id, $"The ShortName: {shortNamedThing.ShortName} is invalid. A shortName should not contain any whitespace", rule.Severity);
            }

            return null;
        }

        /// <summary>
        /// Verifies that the <see cref="Thing"/> is of the correct type
        /// </summary>
        /// <param name="thing">
        /// the subject <see cref="Thing"/>
        /// </param>
        /// <returns>
        /// an instance of <see cref="IShortNamedThing"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="IShortNamedThing"/>
        /// </exception>
        private IShortNamedThing VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var shortNamedThing = thing as IShortNamedThing;
            if (shortNamedThing == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an IShortNamedThing", nameof(thing));
            }

            return shortNamedThing;
        }
    }
}