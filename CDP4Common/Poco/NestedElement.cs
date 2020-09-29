// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElement.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="NestedElement"/>
    /// </summary>
    public partial class NestedElement
    {
        /// <summary>
        /// Returns the <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            var lastElementUsage = this.ElementUsage.LastOrDefault();
            return lastElementUsage == null ? this.RootElement.Name : lastElementUsage.Name;
        }

        /// <summary>
        /// Returns the <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            var shortNameComponents = new List<string> { this.RootElement.ShortName };

            foreach (ElementUsage usage in this.ElementUsage)
            {
                shortNameComponents.Add(usage.ShortName);
            }

            return string.Join(".", shortNameComponents);
        }

        /// <summary>
        /// Returns the <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            return this.ElementUsage.Count == 0 ? this.RootElement.Owner : this.ElementUsage.Last().Owner;
        }
        
        /// <summary>
        /// Gets a value indicating whether the current <see cref="NestedElement"/>
        /// is the root of the Nested tree.
        /// </summary>
        public bool IsRootElement { get; internal set; }

        /// <summary>
        /// The <see cref="ElementBase"/> representing a <see cref="NestedElement"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="ElementBase"/>.
        /// </returns>
        public ElementBase GetElementBase()
        {
            return this.IsRootElement
                ? (ElementBase)this.RootElement
                : this.ElementUsage.Last();
        }

        /// <summary>
        /// The <see cref="ElementDefinition"/> representing a <see cref="NestedElement"/>, if it exists.
        /// </summary>
        /// <returns>
        /// The <see cref="ElementDefinition"/>.
        /// </returns>
        public ElementDefinition GetElementDefinition()
        {
            var elementBase = this.GetElementBase();

            return elementBase as ElementDefinition ?? (elementBase as ElementUsage)?.ElementDefinition;
        }

        /// <summary>
        /// The <see cref="ElementUsage"/> representing a <see cref="NestedElement"/>, if it exists.
        /// </summary>
        /// <returns>
        /// The <see cref="ElementUsage"/>.
        /// </returns>
        public ElementUsage GetElementUsage()
        {
            return this.GetElementBase() as ElementUsage;
        }

        /// <summary>
        /// Asserts whether the <see cref="NestedElement"/>'s <see cref="ElementDefinition"/>, or <see cref="ElementUsage"/> is a member of the specific Category
        /// </summary>
        /// <param name="category">
        /// The <see cref="Category"/>.
        /// </param>
        /// <returns>
        /// True if the <see cref="NestedElement"/> is  a member of the <paramref name="category"/>, otherwise false.
        /// </returns>
        public bool IsMemberOfCategory(Category category)
        {
            var elementBase = this.GetElementBase();

            if (elementBase is ElementUsage elementUsage)
            {
                return elementUsage.IsMemberOfCategory(category, elementUsage.RequiredRdls);
            }

            if (elementBase is ElementDefinition elementDefinition)
            {
                return elementDefinition.IsMemberOfCategory(category, elementDefinition.RequiredRdls);
            }

            return false;
        }

        /// <summary>
        /// Get the children of a <see cref="NestedElement"/>.
        /// </summary>
        /// <param name="nestedElements">
        /// A list containing all <see cref="NestedElement"/>s.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> containing all children <see cref="NestedElement"/>s.
        /// </returns>
        public IEnumerable<NestedElement> GetChildren(List<NestedElement> nestedElements)
        {
            var level = this.ElementUsage.Count;

            var children = nestedElements.Where(ne => ne.ElementUsage.Count == level + 1);

            if (level > 0)
            {
                children = children.Where(ne =>
                    ne.ElementUsage[level - 1] == this.ElementUsage.LastOrDefault());
            }

            children = children.ToList();
            return children;
        }
    }
}
