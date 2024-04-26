// <copyright file="CategoryRuleChecker.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="CategoryRuleChecker"/> is to execute the rules for instances of type <see cref="Category"/>
    /// </summary>
    [RuleChecker(typeof(Category))]
    public class CategoryRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether the <see cref="Category"/> ShortName is case-sensitive unique within its containing <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Category"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Category"/>
        /// </exception>
        [Rule("MA-0720")]
        public IEnumerable<RuleCheckResult> CheckWhetherTheCategoryShortNameIsUniqueInTheContainerRdl(Thing thing)
        {
            var category = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)thing.Container;

            var duplicates = referenceDataLibrary.DefinedCategory.Where(p => p.ShortName == category.ShortName && p.Iid != category.Iid);

            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(p => p.Iid));
                var duplicateShortNames = string.Join(",", duplicates.Select(p => p.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The Category does not have a unique ShortNames in the container Reference Data Library - {duplicateIdentifiers}:{duplicateShortNames}", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether the <see cref="Category"/> Name is case-sensitive unique within its containing <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Category"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="Category"/>
        /// </exception>
        [Rule("MA-0730")]
        public IEnumerable<RuleCheckResult> CheckWhetherTheCategoryNameIsUniqueInTheContainerRdl(Thing thing)
        {
            var category = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)thing.Container;

            var duplicates = referenceDataLibrary.DefinedCategory.Where(p => p.Name == category.Name && p.Iid != category.Iid);

            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(p => p.Iid));
                var duplicateShortNames = string.Join(",", duplicates.Select(p => p.Name));

                var result = new RuleCheckResult(thing, rule.Id, $"The Category does not have a unique Names in the container Reference Data Library - {duplicateIdentifiers}:{duplicateShortNames}", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="Category"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="Category"/>
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
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedCategoryIsInChainOfRdls(Thing thing)
        {
            var category = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var referenceDataLibrary = (ReferenceDataLibrary)category.Container;

            foreach (var superCategory in category.SuperCategory)
            {
                if (!referenceDataLibrary.IsCategoryInChainOfRdls(superCategory))
                {
                    var result = new RuleCheckResult(thing, rule.Id, $"The superCategory {superCategory.Iid}:{superCategory.ShortName} of {category.Iid}:{category.ShortName} is not in the chain of Reference Data Libraries", SeverityKind.Error);
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
        /// an instance of <see cref="BinaryRelationshipRule"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="BinaryRelationshipRule"/>
        /// </exception>
        private Category VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing),$"The {nameof(thing)} may not be null");
            }

            var category = thing as Category;
            if (category == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an Category", nameof(thing));
            }

            return category;
        }
    }
}