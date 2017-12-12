// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows;
    using CDP4Common.EngineeringModelData;    
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
        /// <param name="shortname">The string to format</param>
        /// <returns>The formatted string</returns>
        /// <remarks>
        /// This is used to format the <see cref="ParameterTypeComponent"/>'s short-name for a better readability
        /// </remarks>
        public static string FormatComponentShortname(string shortname)
        {
            if (string.IsNullOrWhiteSpace(shortname))
            {
                return string.Empty;
            }

            var regex = new Regex("[^a-zA-Z0-9]+");

            // Replace all non alpha-numerical character by underscore
            var formatstring = regex.Replace(shortname, "_");

            // remove the formatted string from its potential leading and trailing underscore
            return Regex.Replace(formatstring, "^_+|_+$", string.Empty);
        }
    }
}