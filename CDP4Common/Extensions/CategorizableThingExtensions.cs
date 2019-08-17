// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategorizableThingExtensions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using NLog;

    /// <summary>
    /// Extension methods for <see cref="ICategorizableThing"/>
    /// </summary>
    public static class CategorizableThingExtensions
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Queries the <see cref="ICategorizableThing"/> and checks whether it is a member of the 
        /// supplied <see cref="Category"/>, this includes membership of the sub <see cref="Category"/> instances
        /// of the provided <see cref="Category"/>
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> instance that is being queried.
        /// </param>
        /// <param name="category">
        /// The <see cref="Category"/> that the <see cref="ICategorizableThing"/> may be a member of.
        /// </param>
        /// <returns>
        /// returns true if the <see cref="ICategorizableThing"/> is a member of the <paramref name="category"/>, including it's 
        /// sub <see cref="Category"/> instances. Returns false if the <see cref="ICategorizableThing"/> is not a member
        /// of the <paramref name="category"/> nor any of it's sub <see cref="Category"/> instances.
        /// </returns>
        public static bool IsMemberOfCategory(this ICategorizableThing categorizableThing, Category category)
        {
            var memberOfCategories = categorizableThing.GetAllCategories();

            var categoriesToCheck = category.AllDerivedCategories().ToList();
            categoriesToCheck.Add(category);

            foreach (var memberOfCategory in memberOfCategories)
            {
                if (categoriesToCheck.Contains(memberOfCategory))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries all the super categories of the categories of an <see cref="ICategorizableThing"/>
        /// and returns the categories and all the super categories up the inheritance chain. Duplicate categories
        /// are removed from the result.
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> that is to be queried for all its categories and its super categories.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Category}"/> that contains all the categories, duplicates are removed.
        /// </returns>
        /// <remarks>
        /// If the <paramref name="categorizableThing"/> is an <see cref="ElementUsage"/> the returned <see cref="Category"/> instances
        /// include those of the referenced <see cref="ElementDefinition"/>.
        /// </remarks>
        public static IEnumerable<Category> GetAllCategories(this ICategorizableThing categorizableThing, bool removeDuplicates = true)
        {
            var allCategories = new List<Category>();

            var elementUsage = categorizableThing as ElementUsage;
            if (elementUsage != null)
            {
                var elementDefinition = elementUsage.ElementDefinition;
                if (elementDefinition != null)
                {
                    allCategories.AddRange(elementDefinition.Category);
                }
            }

            allCategories.AddRange(categorizableThing.Category);

            var result = new List<Category>();

            foreach (var category in allCategories)
            {
                foreach (var c in category.AllSuperCategories())
                {
                    result.Add(c);
                }

                result.Add(category);
            }

            if (removeDuplicates)
            {
                return result.Distinct();
            }
            else
            {
                return result;
            }
        }

        /// <summary>
        /// Queries all the super categories of the categories of an <see cref="ICategorizableThing"/>
        /// and returns the categories and all the super categories up the inheritance chain.
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> that is to be queried for all its categories and its super categories.
        /// </param>
        /// <returns>
        /// the short names of the categories and super categories concatenated as a string
        /// </returns>
        public static string GetAllCategoryShortNames(this ICategorizableThing categorizableThing)
        {
            var allCategories = categorizableThing.GetAllCategories();
            return allCategories.Aggregate(string.Empty, (current, cat) => $"{current} {cat.ShortName}").Trim();
        }
        
        /// <summary>
        /// Determines whether the provided <see cref="Category"/> is in the chain of <see cref="ReferenceDataLibrary"/>
        /// of the <see cref="ICategorizableThing"/>
        /// </summary>
        /// <param name="categorizableThing">
        /// The <see cref="ICategorizableThing"/> for which is being determined whether it may be categorized using the provided <see cref="Category"/>
        /// </param>
        /// <param name="category">
        /// The <see cref="Category"/> that may or may not be in the chain-of-rdls of the <see cref="ICategorizableThing"/>
        /// </param>
        /// <returns>
        /// returns true when the <see cref="Category"/> is in the chain-of-rdls of the <see cref="ICategorizableThing"/>
        /// </returns>
        /// <remarks>
        /// even though <see cref="DomainOfExpertise"/> and <see cref="SiteLogEntry"/> are <see cref="ICategorizableThing"/> these 
        /// classes are outside the scope of any chain-of-rdls. For these two types true is always returned.
        /// </remarks>
        public static bool IsCategoryInChainOfRdls(this ICategorizableThing categorizableThing, Category category)
        {
            if (categorizableThing is DomainOfExpertise)
            {
                return true;
            }

            if (categorizableThing is SiteLogEntry)
            {
                return true;
            }

            var thing = categorizableThing as Thing;
                        
            if (thing.TopContainer is EngineeringModel engineeringModel)
            {
                var requiredRdl = engineeringModel.EngineeringModelSetup.RequiredRdl.Single();
                return requiredRdl.QueryCategoriesFromChainOfRdls().Contains(category);                
            }

            var containerRdl = thing.GetContainerOfType<ReferenceDataLibrary>();
            return containerRdl.QueryCategoriesFromChainOfRdls().Contains(category);
        }
    }
}