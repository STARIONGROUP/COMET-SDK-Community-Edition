#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal
{
    using System;
    using CDP4Dal.Operations;

    /// <summary>
    /// The static helper class that provides utilities to assist the Data Access Layer
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// Asserts that the uri is following the http or https schema.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the <see cref="Uri"/> is not either a HTTP or a HTTPS schema, this exception is thrown.
        /// </exception>
        public static void AssertUriIsHttpOrHttpsSchema(Uri uri)
        {
            if (!(uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
            {
                throw new ArgumentException(string.Format("Invalid URI scheme for: {0}", uri));
            }
        }

        /// <summary>
        /// Asserts that the uri is following the file schema.
        /// </summary>
        /// <param name="uri">
        /// The uri.
        /// </param>
        /// <exception cref="ArgumentException">
        /// If the <see cref="Uri"/> is not File schema, this exception is thrown.
        /// </exception>
        public static void AssertUriIsFileSchema(Uri uri)
        {
            if (uri.Scheme != Uri.UriSchemeFile)
            {
                throw new ArgumentException(string.Format("Invalid URI scheme for: {0}", uri));
            }
        }

        /// <summary>
        /// Asserts that the supplied <see cref="object"/> is not null and throws a <see cref="NullReferenceException"/> if it is.
        /// </summary>
        /// <param name="thing">The object which should not be null</param>
        public static void AssertNotNull(object thing)
        {
            if (thing == null)
            {
                throw new NullReferenceException("The object cannot be null");
            }
        }

        /// <summary>
        /// Asserts that the supplied <see cref="object"/> is not null and throws a <see cref="ArgumentNullException"/> if it is.
        /// </summary>
        /// <param name="thing">The object which should not be null </param>
        public static void AssertArgumentNotNull(object thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException("The argument cannot be null");
            }
        }

        /// <summary>
        /// Asserts that the supplied <see cref="object"/> is not null and throws a <see cref="NullReferenceException"/> if it is.
        /// </summary>
        /// <param name="thing">
        /// The object which should not be null
        /// </param>
        /// <param name="message">
        /// The error message that will be used as error message on the thrown <see cref="NullReferenceException"/>
        /// </param>
        public static void AssertNotNull(object thing, string message)
        {
            if (thing == null)
            {
                throw new NullReferenceException(message);
            }
        }

        /// <summary>
        /// Converts the first character of the string to an upper case letter.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> with the transformed first letter.
        /// </returns>
        public static string CapitalizeFirstLetter(string input)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("The input string may not be null or empty.");
            }
            
            // Return char and concat substring.
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        /// <summary>
        /// Converts the first character of the string to a lower case letter.
        /// </summary>
        /// <param name="input">
        /// The input string.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> with the transformed first letter.
        /// </returns>
        public static string LowerCaseFirstLetter(string input)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("The input string may not be null or empty.");
            }

            // Return char and concat substring.
            return char.ToLower(input[0]) + input.Substring(1);
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
    }
}
