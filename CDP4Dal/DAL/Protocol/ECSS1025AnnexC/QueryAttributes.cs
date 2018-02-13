#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryAttributes.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal.DAL.ECSS1025AnnexC
{
    using System.Collections.Generic;

    /// <summary>
    /// The ECSS 1025 Annex C request query attributes. Appended to the query if required
    /// </summary>
    public class QueryAttributes : DalQueryAttributes
    {
        /// <summary>
        /// Gets or sets the <see cref="ExtentQueryAttribute"/> of the query.
        /// </summary>
        public ExtentQueryAttribute? Extent { get; set; }

        /// <summary>
        /// Gets or sets whether to query the include reference data.
        /// </summary>
        public bool? IncludeReferenceData { get; set; }

        /// <summary>
        /// Gets or sets whether to include all containers.
        /// </summary>
        public bool? IncludeAllContainers { get; set; }

        /// <summary>
        /// Gets or sets whether to include the file data.
        /// </summary>
        public bool? IncludeFileData { get; set; }

        /// <summary>
        /// Converts all values of this <see cref="QueryAttributes"/> class to a uri attributes string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> in the form ?param1=value1 seperated by an ampersand.
        /// </returns>
        public override string ToString()
        {
            var attributeString = this.JoinAttributes();
            return string.IsNullOrEmpty(attributeString) ? string.Empty : string.Format("?{0}", attributeString);
        }

        /// <summary>
        /// Joins the attributes into a single string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> with all the attributes separated by a ampersand.
        /// </returns>
        public override string JoinAttributes()
        {
            var attributeList = new List<string>();

            if (this.Extent != null)
            {
                attributeList.Add(string.Format("extent={0}", this.Extent));
            }

            if (this.IncludeReferenceData != null)
            {
                attributeList.Add(string.Format("includeReferenceData={0}", this.IncludeReferenceData.ToString().ToLower()));
            }

            if (this.IncludeAllContainers != null)
            {
                attributeList.Add(string.Format("includeAllContainers={0}", this.IncludeAllContainers.ToString().ToLower()));
            }

            if (this.IncludeFileData != null)
            {
                attributeList.Add(string.Format("includeFileData={0}", this.IncludeFileData.ToString().ToLower()));
            }

            // include the base attributelist
            var baseJoinedAttributes = base.JoinAttributes();
            if (!string.IsNullOrEmpty(baseJoinedAttributes))
            {
                attributeList.Add(baseJoinedAttributes);
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
