// -------------------------------------------------------------------------------------------------
// <copyright file="ContainerLevelKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    /// <summary>
    /// Enumeration that specifies at what level in the containment hierarchy an instance is located.
    /// </summary>
    public enum ContainerLevelKind
    {
        /// <summary>
        /// Assertion that the level cannot be set, this is applicable for Abstract classes
        /// </summary>
        Invalid,

        /// <summary>
        /// Assertion that it is not yet determined where the instance is located in the containment hierarchy.
        /// </summary>
        Inconclusive,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="SiteDirectoryData.SiteDirectory"/>
        /// </summary>
        SiteDirectory,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="EngineeringModelData.EngineeringModel"/>.
        /// </summary>
        /// <remarks>
        /// This exlcudes containment by <see cref="EngineeringModelData.Iteration"/>
        /// </remarks>
        EngineeringModel,

        /// <summary>
        /// Assertion that the instance is contained by a <see cref="EngineeringModelData.Iteration"/>.
        /// </summary>
        /// <remarks>
        /// This exlcudes containment by <see cref="EngineeringModelData.Iteration"/>
        /// </remarks>
        Iteration
    }
}
