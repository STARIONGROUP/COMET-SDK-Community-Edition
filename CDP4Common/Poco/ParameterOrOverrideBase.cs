// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOrOverrideBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// Extended part for the auto-generated <see cref="ActualFiniteState"/>
    /// </summary>
    public partial class ParameterOrOverrideBase : IPublishable
    {
        /// <summary>
        /// Backing field for the <see cref="ToBePublished"/> property.
        /// </summary>
        private bool toBePublished;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParameterOrOverrideBase"/> is to be published in the next publication.
        /// </summary>
        public bool ToBePublished
        {
            get
            {
                return this.CanBePublished && this.toBePublished;
            }

            set { this.toBePublished = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ParameterOrOverrideBase"/> can be published.
        /// </summary>
        public abstract bool CanBePublished { get; }
    }
}
