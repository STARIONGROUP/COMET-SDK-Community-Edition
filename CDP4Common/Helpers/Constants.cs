// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Common.Helpers
{
    using System;

    /// <summary>
    /// The constant class used in the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The enumeration value separator when multi enumerations may be selected
        /// </summary>
        public const char MultiValueEnumSeparator = '|';

        /// <summary>
        /// The padded multi enumeration separator
        /// </summary>
        public const string PaddedMultiEnumSeparator = " | ";

        /// <summary>
        /// The uri path separator
        /// </summary>
        public const string UriPathSeparator = "/";

        /// <summary>
        /// The uri path separator character
        /// </summary>
        public const char UriPathSeparatorChar = '/';

        /// <summary>
        /// The length of the guid represented in a uri
        /// </summary>
        public const int UriGuidLength = 32;

        /// <summary>
        /// The <see cref="Guid"/> pattern used in the response from a data-source
        /// </summary>
        public const string UriGuidPattern = @"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}";
    }
}