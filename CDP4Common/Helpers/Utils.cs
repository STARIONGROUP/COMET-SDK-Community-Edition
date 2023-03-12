// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// The static class that contains utility methods
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Extension method that extract the ordered Ids as a list of GUID from the passed in IEnumerable of <see cref="OrderedItem"/>.
        /// </summary>
        /// <param name="orderedList">
        /// The ordered list of Guids.
        /// </param>
        /// <returns>
        /// A list instance with the extracted Guids.
        /// </returns>
        public static IEnumerable<Guid> ToIdList(this IEnumerable<OrderedItem> orderedList)
        {
            return orderedList.Select(x => (Guid)x.V);
        }
        
        /// <summary>
        /// Format a string using only the alpha numerical characters and underscore
        /// </summary>
        /// <param name="shortName">The string to format</param>
        /// <returns>The formatted string</returns>
        /// <remarks>
        /// This is used to format the <see cref="ParameterTypeComponent"/>'s short-name for a better readability
        /// </remarks>
        public static string FormatComponentShortName(string shortName)
        {
            if (string.IsNullOrWhiteSpace(shortName))
            {
                return string.Empty;
            }

            var regex = new Regex("[^a-zA-Z0-9]+");

            // Replace all non alpha-numerical character by underscore
            var formatString = regex.Replace(shortName, "_");

            // remove the formatted string from its potential leading and trailing underscore
            return Regex.Replace(formatString, "^_+|_+$", string.Empty);
        }
    }
}