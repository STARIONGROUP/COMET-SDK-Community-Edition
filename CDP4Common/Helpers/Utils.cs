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
    using CDP4Common.Operations;
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
        /// Assert whether an <see cref="OperationKind"/> is a copy operation
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation</returns>
        public static bool IsCopyOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.Copy ||
                   operationKind == OperationKind.CopyDefaultValuesChangeOwner ||
                   operationKind == OperationKind.CopyKeepValues ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
        }

        /// <summary>
        /// Assert whether an <see cref="OperationKind"/> is a copy operation that changes the owner of a <see cref="IOwnedThing"/>
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation that changes the owner</returns>
        public static bool IsCopyChangeOwnerOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.CopyDefaultValuesChangeOwner ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
        }

        /// <summary>
        /// Assert whether an <see cref="OperationKind"/> is a copy operation that keeps the original values of a <see cref="ParameterBase"/>
        /// </summary>
        /// <param name="operationKind">The <see cref="OperationKind"/></param>
        /// <returns>A value indicating whether it is a copy operation that keeps the original values of a <see cref="ParameterBase"/></returns>
        public static bool IsCopyKeepOriginalValuesOperation(this OperationKind operationKind)
        {
            return operationKind == OperationKind.CopyKeepValues ||
                   operationKind == OperationKind.CopyKeepValuesChangeOwner;
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