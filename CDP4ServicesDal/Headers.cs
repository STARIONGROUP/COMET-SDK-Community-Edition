// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Headers.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4ServicesDal
{
    /// <summary>
    /// Definition of header constants
    /// </summary>
    internal static class Headers
    {
        /// <summary>
        /// The header that is used to communicate the version of the server that is being used
        /// </summary>
        /// <remarks>
        /// The version is specified as a string with the following format: x.y.z
        /// </remarks>
        internal const string CDPServer = "CDP4-Server";

        /// <summary>
        /// The header that specifies the version of the CDP4Common library that is being used
        /// </summary>
        /// <remarks>
        /// The version is specified as a string with the following format: x.y.z
        /// </remarks>
        internal const string CDPCommon = "CDP4-Common";

        /// <summary>
        /// The header that is used to communicate the operation token that can be used on the server to correlate operations
        /// executed on the server to a request
        /// </summary>
        internal const string CDPToken = "CDP4-Token";

        /// <summary>
        /// The header that specifies the ECCS-E-TM-10-25 protocol and it's version
        /// </summary>
        /// <remarks>
        /// the value shall have the following form: application/ecss-e-tm-10-25+json; version=x.y.z
        /// </remarks>
        internal const string ContentType = "Content-Type";

        /// <summary>
        /// The header that specifies that the client accepts CDP extensions.
        /// </summary>
        internal const string AcceptCdpVersion = "Accept-CDP";

        /// <summary>
        /// The header that specifies the version of CDP extensions that are accepted
        /// </summary>
        internal const string AcceptCdpVersionValue = "1.1.0";
    }
}