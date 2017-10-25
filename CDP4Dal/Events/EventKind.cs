// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Events
{
    /// <summary>
    /// Enumerates the types of events that can be published through the <see cref="CDPMessageBus"/>.
    /// </summary>
    public enum EventKind
    {
        /// <summary>
        /// Signifies that the object is removed
        /// </summary>
        Removed = -1,

        /// <summary>
        /// Signifies that the object is updated. Default value.
        /// </summary>        
        Updated = 0,

        /// <summary>
        /// Signifies that the object is added.
        /// </summary>
        Added = 1
    }
}
