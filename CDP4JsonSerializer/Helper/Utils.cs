// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Helper
{
    using System;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A utility class that supplies common functionalities to the Serializer.
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// The capitalize first character.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If supplied input is null or empty
        /// </exception>
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("string can't be empty!");
            }

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
            return string.Format("{0}{1}", input.First().ToString(CultureInfo.InvariantCulture).ToUpper(), input.Substring(1));
#else
            return string.Format("{0}{1}", input.First().ToString().ToUpper(), input.Substring(1));
#endif

        }

        /// <summary>
        /// Lowercase the first character of a string.
        /// </summary>
        /// <param name="input">
        /// The input.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If supplied input is null or empty
        /// </exception>
        public static string LowercaseFirstLetter(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("string can't be empty!");
            }
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
            return string.Format("{0}{1}", input.First().ToString(CultureInfo.InvariantCulture).ToLower(), input.Substring(1));
#else
            return string.Format("{0}{1}", input.First().ToString().ToLower(), input.Substring(1));
#endif
        }
    }
}