// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecureStringExtensions.cs" company="RHEA System S.A.">
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