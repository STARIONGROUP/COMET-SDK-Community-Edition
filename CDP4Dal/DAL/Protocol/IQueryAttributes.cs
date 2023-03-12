// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryAttributes.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Dal.DAL
{
    using System;

    /// <summary>
    /// The UriQueryAttributes interface.
    /// </summary>
    public interface IQueryAttributes
    {
        /// <summary>
        /// Converts all values of this <see cref="IQueryAttributes"/> class to a uri attributes string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> in the form ?param1=value1 seperated by an ampersand.
        /// </returns>
        string ToString();

        /// <summary>
        /// Joins the attributes into a single string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> with all the attributes seperated by a ampersand.
        /// </returns>
        string JoinAttributes();

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        int? RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from revision number.
        /// </summary>
        int? FromRevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from revision number.
        /// </summary>
        int? ToRevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from timestamp to get revisions.
        /// </summary>
        DateTime? FromRevisionTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the to timestamp to get revisions.
        /// </summary>
        DateTime? ToRevisionTimestamp { get; set; }
    }
}