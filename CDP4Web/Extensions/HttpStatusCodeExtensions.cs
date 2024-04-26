// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="HttpStatusCodeExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Web.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    /// <summary>
    /// Extension class for <see cref="HttpStatusCode"/>
    /// </summary>
    public static class HttpStatusCodeExtensions
    {
        /// <summary>
        /// Gets if the status code represents a server error
        /// </summary>
        /// <param name="statusCode">the status code</param>
        /// <returns>true if is a server error, false otherwise</returns>
        public static bool IsServerError(this HttpStatusCode statusCode)
        {
            var statusCodeValue = (int)statusCode;
            return statusCodeValue is >= 500 and < 600;
        }

        /// <summary>
        /// Gets if the status code represents a client error
        /// </summary>
        /// <param name="statusCode">the status code</param>
        /// <returns>true if is a client error, false otherwise</returns>
        public static bool IsClientError(this HttpStatusCode statusCode)
        {
            var statusCodeValue = (int)statusCode;
            return statusCodeValue is >= 400 and < 500;
        }

        /// <summary>
        /// Gets if the status code represents a success
        /// </summary>
        /// <param name="statusCode">the status code</param>
        /// <returns>true if is a sucess, false otherwise</returns>
        public static bool IsSuccess(this HttpStatusCode statusCode)
        {
            var statusCodeValue = (int)statusCode;
            return statusCodeValue is >= 200 and < 300;
        }

        /// <summary>
        /// Orders the collection by server errors, then by client errors and then by succeses 
        /// </summary>
        /// <param name="statusCodes">the collection of status codes</param>
        /// <returns>the ordered collection</returns>
        public static IEnumerable<HttpStatusCode> OrderByStatusCodeCategory(this IEnumerable<HttpStatusCode> statusCodes)
        {
            return statusCodes.OrderByDescending(x => x.IsServerError())
                .ThenByDescending(x => x.IsClientError())
                .ThenBy(x => x.IsSuccess());
        }
    }
}
