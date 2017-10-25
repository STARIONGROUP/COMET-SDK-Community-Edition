// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;

    /// <summary>
    /// Static extension class to convert a string to a <see cref="SecureString"/> and a
    /// <see cref="SecureString"/> to a string
    /// </summary>
    public static class SecureStringExtensions
    {
        /// <summary>
        /// Convert the string to a <see cref="SecureString"/>
        /// </summary>
        /// <param name="unsecurestring">
        /// the string that needs to be converted
        /// </param>
        /// <returns>
        /// an instance of <see cref="SecureString"/> that is immutable
        /// </returns>
        public static SecureString ConvertToSecureString(this string unsecurestring)
        {
            if (string.IsNullOrEmpty(unsecurestring))
            {
                throw new ArgumentException("The unsecurestring string may not be null or empty.");
            }

            var secureString = new SecureString();
            foreach (var c in unsecurestring.ToCharArray())
            {
                secureString.AppendChar(c);
            }
            
            secureString.MakeReadOnly();

            return secureString;
        }

        /// <summary>
        /// Converts the <see cref="SecureString"/> to an unsecure string
        /// </summary>
        /// <param name="secureString">
        /// The <see cref="SecureString"/> to convert
        /// </param>
        /// <returns>
        /// the value of the <see cref="SecureString"/>
        /// </returns>
        public static string ConvertToUnsecureString(this SecureString secureString)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException("secureString");
            }

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(secureString);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}