// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalQueryAttributes.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;

    /// <summary>
    /// The base query attributes
    /// </summary>
    public class DalQueryAttributes : IQueryAttributes
    {
        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        public int? RevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from revision number.
        /// </summary>
        public int? FromRevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from revision number.
        /// </summary>
        public int? ToRevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the from timestamp to get revisions.
        /// </summary>
        public DateTime? FromRevisionTimestamp { get; set; }

        /// <summary>
        /// Gets or sets the to timestamp to get revisions.
        /// </summary>
        public DateTime? ToRevisionTimestamp { get; set; }


        /// <summary>
        /// Converts all values of this <see cref="DalQueryAttributes"/> class to a uri attributes string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> in the form ?param1=value1 seperated by an ampersand.
        /// </returns>
        public override string ToString()
        {
            var attributeString = this.JoinAttributes();
            return string.IsNullOrEmpty(attributeString) ? string.Empty : $"?{attributeString}";
        }

        /// <summary>
        /// Joins the attributes into a single string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> with all the attributes separated by a ampersand.
        /// </returns>
        public virtual string JoinAttributes()
        {
            var attributeList = new List<string>();

            if (this.RevisionNumber != null)
            {
                attributeList.Add($"revisionNumber={this.RevisionNumber}");
            }

            if (this.FromRevisionNumber != null)
            {
                attributeList.Add($"revisionFrom={this.FromRevisionNumber}");
            }

            if (this.ToRevisionNumber != null)
            {
                attributeList.Add($"revisionTo={this.ToRevisionNumber}");
            }

            if (this.FromRevisionTimestamp != null)
            {
                attributeList.Add($"revisionFrom={this.FromRevisionTimestamp?.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }

            if (this.ToRevisionTimestamp != null)
            {
                attributeList.Add($"revisionTo={this.ToRevisionTimestamp?.ToString("yyyy-MM-ddTHH:mm:ss")}");
            }

            if (attributeList.Count == 0)
            {
                return string.Empty;
            }

            var joined = string.Join("&", attributeList);
            return joined;
        }
    }
}
