// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleParameterValue.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="SimpleParameterValue"/>
    /// </summary>
    public partial class SimpleParameterValue
    {
        /// <summary>
        /// Returns the <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as SimpleParameterizableThing;
            if (container == null)
            {
                throw new NullReferenceException("Container of SimpleParameterValue is null");
            }

            return container.Owner;
        }
    }
}