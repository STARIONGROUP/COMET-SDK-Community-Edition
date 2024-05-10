// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticMetadataProvider.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Common.MetaInfo
{
    using System;

    /// <summary>
    /// The static metadata provider
    /// </summary>
    public static class StaticMetadataProvider
    {
        /// <summary>
        /// The <see cref="MetaDataProvider"/> instance for the application
        /// </summary>
        private static readonly MetaDataProvider provider = new MetaDataProvider();

        /// <summary>
        /// Returns a meta info instance based on the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// A meta info instance.
        /// </returns>
        /// <exception cref="TypeLoadException">
        /// If type name not supported
        /// </exception>
        public static IMetaInfo GetMetaInfo(string typeName)
        {
            return provider.GetMetaInfo(typeName);
        }

        /// <summary>
        /// Gets the <see cref="IMetaDataProvider"/>
        /// </summary>
        public static IMetaDataProvider GetMetaDataProvider
        {
            get { return provider; }
        }

        /// <summary>
        /// Get the base type name of the supplied type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The base type or the same type name if class is the inheritance root.
        /// </returns>
        public static string BaseType(string typeName)
        {
            return provider.BaseType(typeName);
        }

        /// <summary>
        /// Get the class version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public static string GetClassVersion(string typeName)
        {
            return provider.GetClassVersion(typeName);
        }

        /// <summary>
        /// Get the property version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        public static string GetPropertyVersion(string typeName, string propertyName)
        {
            return provider.GetPropertyVersion(typeName, propertyName);
        }
    }
}