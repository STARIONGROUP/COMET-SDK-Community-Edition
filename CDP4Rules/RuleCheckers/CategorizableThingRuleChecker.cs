// <copyright file="CategorizableThingRuleChecker.cs" company="Starion Group S.A.">
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
    using CDP4Common.SiteDirectoryData;

    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="CategorizableThingRuleChecker"/> is to execute the rules for instances of type <see cref="ICategorizableThing"/>
    /// </summary>
    [RuleChecker(typeof(ICategorizableThing))]
    public class CategorizableThingRuleChecker : RuleChecker
    {
        /// <summary>
        /// Checks whether a referenced <see cref="IDeprecatableThing"/> is deprecated
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="PrefixedUnit"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="PrefixedUnit"/>
        /// </exception>
        [Rule("MA-0500")]
        public IEnumerable<RuleCheckResult> ChecksWhetherAReferencedDeprecatableThingIsDeprecated(Thing thing)
        {
            var categorizableThing = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var deprecatableThing = thing as IDeprecatableThing;
            if (deprecatableThing != null && !deprecatableThing.IsDeprecated)
            {
                foreach (var category in categorizableThing.Category)
                {
                    if (category.IsDeprecated)
                    {
                        var result = new RuleCheckResult(thing, rule.Id,
                            $"The referenced Category {category.Iid}:{category.ShortName} of ICategorizableThing.Category is deprecated",
                            SeverityKind.Warning);
                        results.Add(result);
                    }
                }
            }
            else
            {
                foreach (var category in categorizableThing.Category)
                {
                    if (category.IsDeprecated)
                    {
                        var result = new RuleCheckResult(thing, rule.Id,
                            $"The referenced Category {category.Iid}:{category.ShortName} of ICategorizableThing.Category is deprecated",
                            SeverityKind.Warning);
                        results.Add(result);
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Checks whether the <see cref="ICategorizableThing"/> is not a member of the same category more
        /// than once, including through sub-classing of categories 
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ICategorizableThing"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ICategorizableThing"/>
        /// </exception>
        [Rule("MA-0300")]
        public IEnumerable<RuleCheckResult> CheckWhetherThereAreNoDuplicateCategoriesAreDefined(Thing thing)
        {
            var categorizableThing = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            //find if there are any duplicates:
            List<Category> duplicates = categorizableThing.Category.GroupBy(s => s).SelectMany(grp => grp.Skip(1)).Distinct().ToList();
            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(r => r.Iid));
                var duplicateShortNames = string.Join(",", duplicates.Select(r => r.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The CategorizableThing is a member of the following Categories: {duplicateIdentifiers}; with shortNames: {duplicateShortNames} more than once", SeverityKind.Warning);
                results.Add(result);
            }

            // verify whether a CategorizableThing is a member of a category and its supercategory by means of the Category property.
            duplicates = new List<Category>();
            foreach (var category in categorizableThing.Category.ToList())
            {
                foreach (var superCategory in category.AllSuperCategories())
                {
                    if (categorizableThing.Category.Any(x => x.Iid == superCategory.Iid))
                    {
                        duplicates.Add(category);
                        duplicates.Add(superCategory);
                    }
                }
            }
            duplicates = duplicates.Distinct().ToList();
            if (duplicates.Any())
            {
                var duplicateIdentifiers = string.Join(",", duplicates.Select(r => r.Iid));
                var duplicateShortNames = string.Join(",", duplicates.Select(r => r.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The CategorizableThing is a member of the following Categories: {duplicateIdentifiers}; with shortNames: {duplicateShortNames} more than once", SeverityKind.Warning);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether the <see cref="ICategorizableThing"/> is not a member of an abstract category
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="ICategorizableThing"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ICategorizableThing"/>
        /// </exception>
        [Rule("MA-0310")]
        public IEnumerable<RuleCheckResult> ChecksWheterACategorizableThingIsNotAMemberOfAnAbstractCategory(Thing thing)
        {
            var categorizableThing = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);

            var abstractCategories = categorizableThing.Category.Where(c => c.IsAbstract);
            if (abstractCategories.Any())
            {
                var abstractIdentifiers = string.Join(",", abstractCategories.Select(r => r.Iid));
                var abstractShortNames = string.Join(",", abstractCategories.Select(r => r.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The CategorizableThing is a member of the following abstract Categories: {abstractIdentifiers}; with shortNames: {abstractShortNames}", SeverityKind.Error);
                results.Add(result);
            }

            return results;
        }

        /// <summary>
        /// Checks whether a referenced <see cref="Category"/> is the in chain of Reference Data Libraries
        /// </summary>
        /// <param name="thing"></param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleCheckResult}"/> which is empty when no rule violations are encountered.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ICategorizableThing"/>
        /// </exception>
        [Rule("MA-0200")]
        public IEnumerable<RuleCheckResult> CheckWhetherReferencedCategoryIsInChainOfRdls(Thing thing)
        {
            var categorizableThing = this.VerifyThingArgument(thing);

            var results = new List<RuleCheckResult>();
            var ruleAttribute = System.Reflection.MethodBase.GetCurrentMethod().GetCustomAttribute<RuleAttribute>();
            var rule = StaticRuleProvider.QueryRules().Single(r => r.Id == ruleAttribute.Id);
            
            var referenceDataLibrary = (ReferenceDataLibrary)thing.GetContainerOfType(typeof(ReferenceDataLibrary));
            if (referenceDataLibrary != null)
            {
                var result = this.CheckWhetherCategoriesOfCategorizableThingAreInTheChainOfRdls(categorizableThing, referenceDataLibrary, rule);

                if (result != null)
                {
                    results.Add(result);
                }
            }

            var engineeringModel = (EngineeringModel) thing.GetContainerOfType(typeof(EngineeringModel));
            if (engineeringModel != null)
            {
                var modelReferenceDataLibrary = engineeringModel.EngineeringModelSetup.RequiredRdl.First();

                var result = this.CheckWhetherCategoriesOfCategorizableThingAreInTheChainOfRdls(categorizableThing, modelReferenceDataLibrary, rule);

                if (result != null)
                {
                    results.Add(result);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks whether the categories that a <see cref="ICategorizableThing"/> is a member of are in the chain of <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> whose member <see cref="Category"/> are checked
        /// </param>
        /// <param name="referenceDataLibrary">
        /// The <see cref="ReferenceDataLibrary"/> that is used as leaf for the chain of <see cref="ReferenceDataLibrary"/>
        /// </param>
        /// <param name="rule">
        /// The <see cref="IRule"/> that is being checked
        /// </param>
        /// <returns>
        /// an instance of <see cref="RuleCheckResult"/> if a rule is violated, null if no rule is violated.
        /// </returns>
        private RuleCheckResult CheckWhetherCategoriesOfCategorizableThingAreInTheChainOfRdls(ICategorizableThing categorizableThing, ReferenceDataLibrary referenceDataLibrary, IRule rule)
        {
            var thing = categorizableThing as Thing;
            var outOfChainOfRdlCategories = new List<Category>();

            foreach (var category in categorizableThing.Category)
            {
                if (!referenceDataLibrary.IsCategoryInChainOfRdls(category))
                {
                    outOfChainOfRdlCategories.Add(category);
                }
            }

            if (outOfChainOfRdlCategories.Any())
            {
                var categoryIdentifiers = string.Join(",", outOfChainOfRdlCategories.Select(r => r.Iid));
                var categoryShortNames = string.Join(",", outOfChainOfRdlCategories.Select(r => r.ShortName));

                var result = new RuleCheckResult(thing, rule.Id, $"The ICategorizableThing is a member of Categories that are not in the chain of Reference Data Libraries: {categoryIdentifiers}:{categoryShortNames}", SeverityKind.Error);
                return result;
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
        /// an instance of <see cref="ICategorizableThing"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when <paramref name="thing"/> is null
        /// </exception>
        /// <exception cref="ArgumentException">
        /// thrown when <paramref name="thing"/> is not an <see cref="ICategorizableThing"/>
        /// </exception>
        private ICategorizableThing VerifyThingArgument(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            var categorizableThing = thing as ICategorizableThing;
            if (categorizableThing == null)
            {
                throw new ArgumentException($"{nameof(thing)} with Iid:{thing.Iid} is not an ICategorizableThing", nameof(thing));
            }

            return categorizableThing;
        }
    }
}