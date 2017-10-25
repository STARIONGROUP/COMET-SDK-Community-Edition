// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalType.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Composition
{
    /// <summary>
    /// Defines the type of data access layer to allow distinguishing features between them
    /// </summary>
    public enum DalType
    {
        /// <summary>
        /// A data access layer that required a http or https connection to an external server
        /// </summary>
        Web,

        /// <summary>
        /// A data access layer that assumes a local file storage system
        /// </summary>
        File
    }
}
