// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Extended part for the auto-generated <see cref="Category"/>
    /// </summary>
    public partial class Category
    {
        /// <summary>
        /// Queries the full hierarchy of super categories of the current <see cref="Category"/>
        /// and returns those as an <see cref="IEnumerable{Category}"/>
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{Category}"/>
        /// </returns>
        public IEnumerable<Category> AllSuperCategories()
        {
            var supercategories = new List<Category>();

            foreach (var category in this.SuperCategory)
            {
                var all = category.AllSuperCategories();

                supercategories.Add(category);

                supercategories.AddRange(all);                                
            }

            return supercategories;
        }

        /// <summary>
        /// Queries the full hierarchy of categories that are derived categories of the current <see cref="Category"/>
        /// and returns those as an <see cref="IEnumerable{Category}"/>
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{Category}"/>
        /// </returns>
        public IEnumerable<Category> AllDerivedCategories()
        {
            var categories = this.Cache.Select(x => x.Value)
                    .Where(lazy => lazy.Value.ClassKind == ClassKind.Category)
                    .Select(lazy => lazy.Value)
                    .Cast<Category>().ToList();

            foreach (var category in categories)
            {
                if (category.SuperCategory.Contains(this))
                {
                    yield return category;

                    foreach (var subcategory in category.AllDerivedCategories(categories))
                    {
                        yield return subcategory;
                    }
                }
            }
        }

        /// <summary>
        /// Queries the full hierarchy of categories that are derived categories of the current <see cref="Category"/>
        /// and returns those as an <see cref="IEnumerable{Category}"/>
        /// </summary>
        /// <param name="categories">
        /// The <see cref="List{Category}"/> that may contain derived <see cref="Category"/> instances
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{Category}"/> that contains the <see cref="Category"/> instances that are derived from the current <see cref="Category"/>
        /// </returns>
        private IEnumerable<Category> AllDerivedCategories(List<Category> categories)
        {
            foreach (var category in categories.Where(category => category.SuperCategory.Contains(this)))
            {
                yield return category;

                foreach (var subcategory in category.AllDerivedCategories(categories))
                {
                    yield return subcategory;
                }
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                return this.ComputeRequiredRdls();
            }
        }

        /// <summary>
        /// Queries all the <see cref="ICategorizableThing"/>s that have been categorized with the current <see cref="Category"/>
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{ICategorizableThing}"/>
        /// </returns>
        public IEnumerable<ICategorizableThing> CategorizedThings()
        {
            var categorizableThings = this.Cache.Select(x => x.Value)
                .Where(lazy => lazy.Value is ICategorizableThing)
                .Select(lazy => lazy.Value)
                .Cast<ICategorizableThing>().ToList();
            
            if (categorizableThings.Count == 0)
            {
                yield break;
            }

            var categories = this.AllSuperCategories().ToList();
            categories.Add(this);

            foreach (var categorizableThing in categorizableThings)
            {
                foreach (var category in categorizableThing.Category)
                {
                    if (categorizableThing.Category.Contains(category))
                    {
                        yield return categorizableThing;
                        break;
                    }
                }
            }
        }
    }
}


