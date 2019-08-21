// <copyright file="BinaryRelationshipRuleChecker.cs" company="RHEA System S.A.">
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

namespace CDP4Rules.RuleCheckers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="BinaryRelationshipRuleChecker"/> is to execute the rules for instances of type <see cref="BinaryRelationship"/>
    /// </summary>
    [RuleChecker(typeof(BinaryRelationship))]
    public class BinaryRelationshipRuleChecker
    {
        /// <summary>
        /// Checks whether the source and target of a <see cref="BinaryRelationship"/> are contained by the same iteration.
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="BinaryRelationship"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="BinaryRelationship"/>
        /// </exception>
        /// <exception cref="IncompleteModelException">
        /// thrown when source or target of the <see cref="BinaryRelationship"/> is null
        /// </exception>
        [Rule("MA-0510")]
        public IEnumerable<RuleCheckResult> CheckWhetherSourceAndTargetAreContainedByTheSameIteration(Thing thing)
        {
            var binaryRelationship = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            if (binaryRelationship.Source == null)
            {
                throw new IncompleteModelException("The Source property is null");
            }

            if (binaryRelationship.Target == null)
            {
                throw new IncompleteModelException("The Target property is null");
            }

            var sourceIteration = binaryRelationship.Source.GetContainerOfType(typeof(Iteration));
            if (sourceIteration == null)
            {
                var result = new RuleCheckResult(thing, rule.Id, "The source is not contained by an Iteration", SeverityKind.Warning);
                results.Add(result);
            }
            else
            {
                if (sourceIteration.Iid != binaryRelationship.Container.Iid)
                {
                    var result = new RuleCheckResult(thing, rule.Id, "The source of the BinaryRelationship is not contained by the same Iteration as the BinaryRelationship", SeverityKind.Warning);
                    results.Add(result);
                }
            }

            var targetIteration = binaryRelationship.Target.GetContainerOfType(typeof(Iteration));
            if (targetIteration == null)
            {
                var result = new RuleCheckResult(thing, rule.Id, "The target is not contained by an Iteration", SeverityKind.Warning);
                results.Add(result);
            }
            else
            {
                if (targetIteration.Iid != binaryRelationship.Container.Iid)
                {
                    var result = new RuleCheckResult(thing, rule.Id, "The target of the BinaryRelationship is not contained by the same Iteration as the BinaryRelationship", SeverityKind.Warning);
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
        /// an instance of <see cref="BinaryRelationship"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="BinaryRelationship"/>
        /// </exception>
        private BinaryRelationship VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null");
            }

            var binaryRelationship = thing as BinaryRelationship;
            if (binaryRelationship == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an IAnnotation");
            }

            return binaryRelationship;
        }
    }
}