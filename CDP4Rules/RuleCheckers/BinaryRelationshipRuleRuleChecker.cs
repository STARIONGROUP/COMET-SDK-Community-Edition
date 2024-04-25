// <copyright file="BinaryRelationshipRuleRuleChecker.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="BinaryRelationshipRuleRuleChecker"/> is to execute the rules for instances of type <see cref="BinaryRelationshipRule"/>
    /// </summary>
    [RuleChecker(typeof(BinaryRelationshipRule))]
    public class BinaryRelationshipRuleRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="Category"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="BinaryRelationshipRule"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="BinaryRelationshipRule"/>
        /// </exception>
        [Rule("MA-0200")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedCategoriesAreInChainOfRdls(Thing thing)
        {
            var binaryRelationshipRule = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)binaryRelationshipRule.Container;
            
            if (!referenceDataLibrary.IsCategoryInChainOfRdls(binaryRelationshipRule.RelationshipCategory))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The BinaryRelationshipRule.RelationshipCategory {binaryRelationshipRule.RelationshipCategory.Iid}:{binaryRelationshipRule.RelationshipCategory.ShortName} of {binaryRelationshipRule.Iid}:{binaryRelationshipRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            if (!referenceDataLibrary.IsCategoryInChainOfRdls(binaryRelationshipRule.SourceCategory))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The BinaryRelationshipRule.SourceCategory {binaryRelationshipRule.SourceCategory.Iid}:{binaryRelationshipRule.SourceCategory.ShortName} of {binaryRelationshipRule.Iid}:{binaryRelationshipRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
                results.Add(result);
            }

            if (!referenceDataLibrary.IsCategoryInChainOfRdls(binaryRelationshipRule.TargetCategory))
            {
                var result = new RuleCheckResult(thing, rule.Id, $"The BinaryRelationshipRule.TargetCategory {binaryRelationshipRule.TargetCategory.Iid}:{binaryRelationshipRule.TargetCategory.ShortName} of {binaryRelationshipRule.Iid}:{binaryRelationshipRule.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
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
        /// an instance of <see cref="BinaryRelationshipRule"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="BinaryRelationshipRule"/>
        /// </exception>
        private BinaryRelationshipRule VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var binaryRelationshipRule = thing as BinaryRelationshipRule;
            if (binaryRelationshipRule == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an BinaryRelationshipRule", nameof(thing));
            }

            return binaryRelationshipRule;
        }
    }
}