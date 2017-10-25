// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IPermissionService.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Permission
{
    using System.ComponentModel;
    using CDP4Common.CommonData;

    /// <summary>
    /// The interface for services that handle permissions
    /// </summary>
    public interface IPermissionService
    {
        /// <summary>
        /// Gets the <see cref="ISession"/> that these permission service are responsible for.
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// Returns whether a Read operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to read</param>
        /// <returns>True if a Read operation can be performed, false if not</returns>
        bool CanRead(Thing thing);

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to write</param>
        /// <returns>True if a Write operation can be performed, false it not</returns>
        bool CanWrite(Thing thing);

        /// <summary>
        /// Returns whether a Write operation can be performed by the active user on the current <see cref="ClassKind"/>
        /// based on the supplied <see cref="Container"/>. The <see cref="ClassKind"/> ultimately determines the access. This method is primarily used for
        /// creation of a certain <see cref="Thing"/>.
        /// </summary>
        /// <param name="classKind">The <see cref="ClassKind"/> that ultimately determines the permissions.</param>
        /// <param name="containerThing">The <see cref="Thing"/> to write to</param>
        /// <returns>True if Write operation can be performed.</returns>
        bool CanWrite(ClassKind classKind, Thing containerThing);
    }
}