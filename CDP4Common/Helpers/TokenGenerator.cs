// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenGenerator.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System.Security.Cryptography;

    /// <summary>
    /// The purpose of the <see cref="TokenGenerator"/> is to generate a random token that
    /// is used to match log statements
    /// </summary>
    public static class TokenGenerator
    {
        /// <summary>
        /// Generates a random string that is used as a token in log statements to match log statements related to the 
        /// processing of one request
        /// </summary>
        /// <returns>
        /// random token</returns>
        public static string GenerateRandomToken()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                byte[] data = new byte[6];
                randomNumberGenerator.GetBytes(data);
                var result = BitConverter.ToString(data).Replace("-", string.Empty);
                return result;
            }
        }
    }
}