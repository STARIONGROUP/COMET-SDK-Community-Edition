// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;

    /// <summary>
    /// The extended class for <see cref="RequirementsContainer"/>
    /// </summary>
    public abstract partial class RequirementsContainer
    {
        /// <summary>
        /// Returns all the <see cref="RequirementsGroup"/> that are contained
        /// by the current <see cref="RequirementsContainer"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{RequirementsGroup}"/>
        /// </returns>
        public IEnumerable<RequirementsGroup> GetAllContainedGroups()
        {
            foreach (var group in this.Group)
            {
                var containedGroups = group.GetAllContainedGroups();
                foreach (var requirementsGroup in containedGroups)
                {
                    yield return requirementsGroup;
                }

                yield return group;
            }
        }

        /// <summary>
        /// Gets the shortname path of the current <see cref="RequirementsGroup"/> delimited
        /// by the <paramref name="delimeter"/> character
        /// </summary>
        /// <param name="delimeter">
        /// The delimeter that is used to separate the parts of the path
        /// </param>
        /// <returns>
        /// A string that concatenates the shortnames of all the <see cref="RequirementsContainer"/> of the
        /// current <see cref="RequirementsContainer"/>
        /// </returns>
        public string Path(char delimeter = '.')
        {
            var container = this.Container as RequirementsContainer;
            
            if (container != null)
            {
                return string.Format("{0}{1}{2}", container.Path(delimeter), delimeter, this.ShortName);
            }

            return this.ShortName;
        }
    }
}