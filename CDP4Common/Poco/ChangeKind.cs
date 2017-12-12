// -------------------------------------------------------------------------------------------------
// <copyright file="ChangeKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    /// <summary>
    /// Enum to specify the edit status of a <see cref="Thing"/>
    /// </summary>
    public enum ChangeKind
    {
        /// <summary>
        /// The <see cref="Thing"/> is not being updated
        /// </summary>
        None = 0,

        /// <summary>
        /// The <see cref="Thing"/> is being deleted
        /// </summary>
        Delete = -1,

        /// <summary>
        /// The <see cref="Thing"/> is being updated
        /// </summary>
        Update = 1,

        /// <summary>
        /// The <see cref="Thing"/> is being created
        /// </summary>
        Create = 2
    }
}