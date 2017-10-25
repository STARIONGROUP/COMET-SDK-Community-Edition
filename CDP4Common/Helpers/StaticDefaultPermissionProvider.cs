// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticDefaultPermissionProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using CommonData;

    /// <summary>
    /// A static utility class to retrieve the default permission for a <see cref="Thing"/>
    /// </summary>
    public static class StaticDefaultPermissionProvider
    {
        /// <summary>
        /// The <see cref="DefaultPermissionProvider"/>
        /// </summary>
        private static DefaultPermissionProvider provider = new DefaultPermissionProvider();

        /// <summary>
        /// Return the default <see cref="ParticipantAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="ParticipantAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="ParticipantAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public static ParticipantAccessRightKind GetDefaultParticipantPermission(string typeName)
        {
            return provider.GetDefaultParticipantPermission(typeName);
        }

        /// <summary>
        /// Return the default <see cref="PersonAccessRightKind"/> for the supplied type.
        /// </summary>
        /// <param name="typeName">
        /// The type name for which the <see cref="PersonAccessRightKind"/> is to be returned.
        /// </param>
        /// <returns>
        /// The default <see cref="PersonAccessRightKind"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If type not found, this should never happen
        /// </exception>
        public static PersonAccessRightKind GetDefaultPersonPermission(string typeName)
        {
            return provider.GetDefaultPersonPermission(typeName);
        }
    }
}
