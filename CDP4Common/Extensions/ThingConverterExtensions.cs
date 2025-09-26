// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingConverterExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Extensions
{
    using System;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    /// <summary>
    /// The purpose of the <see cref="ThingConverterExtensions"/> is to implement extra business logic for hand-coded serialization to
    /// decide to include or exclude classes from the serialization process
    /// </summary>
    public class ThingConverterExtensions
    {
        /// <summary>
        /// Asserts whether an object shall be serialized or not
        /// </summary>
        /// <param name="value">
        /// the <see cref="object"/> for which the serialization is to be asserted
        /// </param>
        /// <param name="metaDataProvider">
        /// The <see cref="CDP4Common.MetaInfo.IMetaDataProvider"/> used to provide meta data
        /// </param>
        /// <param name="version">
        /// The data model version to be used to determine whether a class shall be serialized or not
        /// </param>
        /// <returns>
        /// returns true when the object shall be serialzed, false if not
        /// </returns>
        public bool AssertSerialization(object value, IMetaDataProvider metaDataProvider, Version version)
        {
            if (value is PersonPermission personPermission)
            {
                var classVersion = new Version(metaDataProvider.GetClassVersion(personPermission.ObjectClass.ToString()));

                if (classVersion > version)
                {
                    return false;
                }
            }

            if (value is ParticipantPermission participantPermission)
            {
                var classVersion = new Version(metaDataProvider.GetClassVersion(participantPermission.ObjectClass.ToString()));

                if (classVersion > version)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks the <see cref="CDP4Common.DTO.Category"/>'s <see cref="CDP4Common.DTO.Category.PermissibleClass"/> property for <see cref="System.Version"/> compatibility
        /// </summary>
        /// <param name="value">
        /// the <see cref="object"/> for which the serialization is to be asserted
        /// </param>
        /// <param name="metaDataProvider">
        /// The <see cref="CDP4Common.MetaInfo.IMetaDataProvider"/> used to provide meta data
        /// </param>
        /// <param name="version">
        /// The data model version to be used to determine whether a class shall be serialized or not
        /// </param>
        public void CheckCategoryPermissibleClasses(object value, IMetaDataProvider metaDataProvider, Version version)
        {
            if (value is Category category)
            {
                var permissibleClasses = category.PermissibleClass.ToList();

                foreach (var permissibleClass in permissibleClasses)
                {
                    var permissibleClassVersion = new Version(metaDataProvider.GetClassVersion(permissibleClass.ToString()));

                    if (permissibleClassVersion <= version)
                    {
                        continue;
                    }

                    category.PermissibleClass.Remove(permissibleClass);
                }
            }
        }
    }
}
