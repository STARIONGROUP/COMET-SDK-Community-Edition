// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPublishable.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// A class that implements the <see cref="IPublishable"/> interface exposes properties that
    /// determine whether the instance is publishable or it is to be published in the next iteration
    /// </summary>
    interface IPublishable
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="IPublishable"/> is to be published in the next publication.
        /// </summary>
        bool ToBePublished { get; set; }

        /// <summary>
        /// Gets a value indicating whether a <see cref="IPublishable"/> can be published.
        /// </summary>
        bool CanBePublished { get; }
    }
}
