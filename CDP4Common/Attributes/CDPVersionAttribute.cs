// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDPVersionAttribute.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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

namespace CDP4Common
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="CDPVersionAttribute"/> attribute is to decorate Classes and properties
    /// that constitute CDP4 extensions to the ECSS-E-TM-10-25A Annex A master model. 
    /// </summary>
    /// <remarks>
    /// A POCO or DTO Class or Property that is not decorated with this class is a vanila ECSS-E-TM-10-25 class or property.
    /// A vanila ECSS-E-TM-10-25A Annex Alass may have properties decorated with this attribute.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class CDPVersionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDPVersionAttribute"/> class.
        /// </summary>
        /// <param name="version">
        /// The version identifier
        /// </param>
        public CDPVersionAttribute(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new ArgumentNullException(version, "The version may not be null or empty");
            }

            this.Version = version;
        }

        /// <summary>
        /// Gets the version of the CDP4 data-model that the decorated
        /// class or property belongs to.
        /// </summary>
        public string Version { get; private set; }
    }
}