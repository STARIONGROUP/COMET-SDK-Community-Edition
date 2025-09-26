// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ReasonExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Net;

    using FluentResults;

    /// <summary>
    /// Extensions class for <see cref="IReason"/>
    /// </summary>
    public static class ReasonExtensions
    {
        /// <summary>
        /// Gets the identifier for a <see cref="IReason"/> that has been created by the current application
        /// </summary>
        public const string Cdp4CometReasonIdentifier = "CDP4CometReason";

        /// <summary>
        /// Add the current <see cref="Cdp4CometReasonIdentifier"/> to the Metadata of a <typeparamref name="TReason"/>
        /// </summary>
        /// <param name="reason">The <typeparamref name="TReason"/></param>
        /// <param name="statusCode">The <see cref="HttpStatusCode"/> to add more context about the <typeparamref name="TReason"/></param>
        /// <typeparam name="TReason">Any <see cref="IReason"/></typeparam>
        public static TReason AddReasonIdentifier<TReason>(this TReason reason, HttpStatusCode statusCode) where TReason : IReason
        {
            reason.Metadata[Cdp4CometReasonIdentifier] = statusCode;
            return reason;
        }
    }
}
