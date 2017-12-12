// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Utils.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   Defines the static helper class that provides utilities to assist the Data Access Layer
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
