// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Requirement.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;

    /// <summary>
    /// The extended class for <see cref="Requirement"/>
    /// </summary>
    public partial class Requirement
    {
        /// <summary>
        /// Gets the shortname path of the current <see cref="Requirement"/> delimited
        /// by the <paramref name="delimeter"/> character. The shortname path is computed along 
        /// the virtual containment of the "container" groups
        /// </summary>
        /// <param name="delimeter">
        /// The delimeter that is used to separate the parts of the path
        /// </param>
        /// <returns>
        /// A string that concatenates the shortnames of all the <see cref="RequirementsContainer"/> of the
        /// current <see cref="RequirementsContainer"/>
        /// </returns>
        public string GroupPath(char delimeter = '.')
        {
            if (this.Container == null)
            {
                throw new InvalidOperationException("The GroupPath can only be computed when the container property is not null");
            }

            if (this.Group == null)
            {
                var requirementsSpecification = (RequirementsSpecification)this.Container;
                return string.Format("{0}{1}{2}", requirementsSpecification.ShortName, delimeter, this.ShortName);
            }

            var groupPath = this.Group.Path(delimeter);
            return string.Format("{0}{1}{2}", groupPath, delimeter, this.ShortName);
        }
    }
}
