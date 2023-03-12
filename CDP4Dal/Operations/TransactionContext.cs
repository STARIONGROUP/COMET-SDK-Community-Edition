// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionContext.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.Operations
{
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose if the <see cref="TransactionContext"/> class is to provide a wrapper around types that can be used
    /// as context in a <see cref="ThingTransaction"/>. An ECSS-E-TM-10-25 data-source only accepts transactions on either
    /// a <see cref="SiteDirectory"/> and an <see cref="Iteration"/>.
    /// </summary>
    public class TransactionContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionContext"/> class.
        /// </summary>
        /// <param name="siteDirectory">
        /// The <see cref="SiteDirectory"/> that is the <see cref="Context"/> of the current <see cref="TransactionContext"/>
        /// </param>
        internal TransactionContext(SiteDirectory siteDirectory)
        {
            this.Context = siteDirectory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionContext"/> class.
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is the <see cref="Context"/> of the current <see cref="TransactionContext"/>
        /// </param>
        internal TransactionContext(Iteration iteration)
        {
            this.Context = iteration;
        }

        /// <summary>
        /// Gets the <see cref="Thing"/> that represents the context of the current <see cref="TransactionContext"/>
        /// </summary>
        /// <remarks>
        /// The context can only a <see cref="SiteDirectory"/> or <see cref="Iteration"/>
        /// </remarks>
        public Thing Context { get; private set; }

        /// <summary>
        /// Returns the route of the current <see cref="Context"/>
        /// </summary>
        /// <returns>
        /// A string that represents the a route
        /// </returns>
        /// <example>
        /// /SiteDirectory/{iid}
        /// /EngineeringModel/{iid}/iteration/{iid}
        /// </example>
        public string ContextRoute()
        {
            return this.Context.Route;
        }
    }
}
