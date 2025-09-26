﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMetaDataProvider.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Utility class that responsible for providing meta-data for any Thing.
    /// </summary>
    public interface IMetaDataProvider
    {
        /// <summary>
        /// Returns a meta info instance based on the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// A meta info instance.
        /// </returns>
        /// <exception cref="System.TypeLoadException">
        /// If type name not supported
        /// </exception>
        IMetaInfo GetMetaInfo(string typeName);

        /// <summary>
        /// Get the base type name of the supplied type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The base type or the same type name if class is the inheritance root.
        /// </returns>
        string BaseType(string typeName);

        /// <summary>
        /// Get the class version for the passed in type name.
        /// </summary>
        /// <param name="typeName">
        /// The type name.
        /// </param>
        /// <returns>
        /// The version string.
        /// </returns>
        string GetClassVersion(string typeName);

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
        string GetPropertyVersion(string typeName, string propertyName);

        /// <summary>
        /// Queries the supported model versions
        /// </summary>
        /// <returns>
        /// A collection of supported model versions represented as a <see cref="Version"/> object
        /// </returns>
        IEnumerable<Version> QuerySupportedModelVersions();

        /// <summary>
        /// Queries the supported model versions and returns the highest version number
        /// </summary>
        /// <returns>
        /// The highest supported model <see cref="Version"/> 
        /// </returns>
        Version GetMaxSupportedModelVersion();
    }
}