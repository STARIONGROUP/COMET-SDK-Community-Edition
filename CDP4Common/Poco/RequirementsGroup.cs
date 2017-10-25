// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsGroup.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;

    /// <summary>
    /// Extended part for the auto-generated <see cref="RequirementsGroup"/>
    /// </summary>
    public partial class RequirementsGroup
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{RequirementsGroup}"/> with all the <see cref="RequirementsGroup"/> contained by 
        /// this <see cref="RequirementsGroup"/> and its children <see cref="RequirementsGroup"/>s
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{RequirementsGroup}"/> that is "contained" by the current <see cref="RequirementsGroup"/>
        /// </returns>
        public IEnumerable<RequirementsGroup> ContainedGroup()
        {
            var groups = new List<RequirementsGroup>();
            foreach (var group in this.Group)
            {
                groups.Add(group);
                groups.AddRange(group.ContainedGroup());
            }

            return groups;
        }
    }
}
