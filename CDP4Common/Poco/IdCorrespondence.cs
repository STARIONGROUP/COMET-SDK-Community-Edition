// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdCorrespondence.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="IdCorrespondence"/>
    /// </summary>
    public partial class IdCorrespondence
    {
        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The derived <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as ExternalIdentifierMap;
            if (container == null)
            {
                throw new NullReferenceException("The container of IdCorrespondence is null");
            }

            return container.Owner;
        }

    }
}