// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayParser.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Extension class for <see cref="ValueArray{T}"/>
    /// </summary>
    public static class ValueArrayParser
    {
        /// <summary>
        /// The string pattern to retrieve the content of an array
        /// </summary>
        private const string valueArrayPattern = @"\{([^)]*)\}";

        /// <summary>
        /// The delimiter between two elements of the array
        /// </summary>
        private const string delimiter = ";";

        /// <summary>
        /// The exception message when a string does not comply with the non-string value array format
        /// </summary>
        private const string nonStringArgumentExceptionMessage = "The value array shall start with a \"{\" and end with a \"}\". The values shall be delimited by a \";\".\nExample: {1;2;3}";

        /// <summary>
        /// Parses a string into a <see cref="ValueArray{Int32}"/>
        /// </summary>
        /// <param name="stringArray">The <see cref="string"/> to parse</param>
        /// <param name="valueArray">The result of the parsing</param>
        /// <param name="error">The potential error message</param>
        /// <returns>true if the parsing succeeded</returns>
        public static bool TryParseToIntValueArray(this string stringArray, out ValueArray<int> valueArray, out string error)
        {
            if (string.IsNullOrWhiteSpace(stringArray))
            {
                error = "The string is null or blank.";
                valueArray = null;
                return false;
            }

            var matches = Regex.Matches(stringArray, valueArrayPattern);
            if (matches.Count != 1)
            {
                error = nonStringArgumentExceptionMessage;
                valueArray = null;
                return false;
            }

            var content = matches[0].Groups[1].Value;
            var stringValues = content.Split(delimiter.ToCharArray());

            if (!stringValues.Any())
            {
                error = nonStringArgumentExceptionMessage;
                valueArray = null;
                return false;
            }

            var intResults = new List<int>();
            foreach (var stringValue in stringValues)
            {
                int result;
                if (!Int32.TryParse(stringValue, out result))
                {
                    error = "The content of the array are not integer values";
                    valueArray = null;
                    return false;
                }

                intResults.Add(result);
            }

            error = string.Empty;
            valueArray = new ValueArray<int>(intResults);
            return true;
        }
    }
}