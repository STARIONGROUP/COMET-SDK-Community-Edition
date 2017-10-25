// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElement.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
    }
}