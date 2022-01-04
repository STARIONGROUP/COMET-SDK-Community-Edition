// <copyright file="PersonRuleChecker.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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
    /// The purpose of the <see cref="PersonRuleChecker"/> is to execute the rules for instances of type <see cref="Person"/>
    /// </summary>
    [RuleChecker(typeof(Person))]
    public class PersonRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Person"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Person"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var person = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (person.IsDeprecated)
            {
                return results;
            }

            if (person.Organization != null && person.Organization.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced Organization {person.Organization.Iid}:{person.Organization.ShortName} of Person.Organization is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            if (person.DefaultDomain != null && person.DefaultDomain.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced DomainOfExpertise {person.DefaultDomain.Iid}:{person.DefaultDomain.ShortName} of Person.DefaultDomain is deprecated",
                    SeverityKind.Warning);
                results.Add(result);
            }

            if (person.Role != null && person.Role.IsDeprecated)
            {
                var result = new RuleCheckResult(thing, rule.Id,
                    $"The referenced PersonRole {person.Role.Iid}:{person.Role.ShortName} of Person.Role is deprecated",
                    SeverityKind.Warning);
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
        /// an instance of <see cref="Person"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Person"/>
        /// </exception>
        private Person VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var person = thing as Person;
            if (person == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an Person", nameof(thing));
            }

            return person;
        }
    }
}