// <copyright file="RuleCheckResult.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.Common
{
    using CDP4Common.CommonData;

    /// <summary>
    /// The purpose of the <see cref="RuleCheckResult"/> class is to encapsulate the results of a rule checker
    /// </summary>
    public class RuleCheckResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCheckResult"/> class
        /// </summary>
        /// <param name="thing">
        /// a reference to te <see cref="Thing"/> that has been checked by a Rule
        /// </param>
        /// <param name="id">
        /// the identifier or code of the Rule that may have been broken
        /// </param>
        /// <param name="description">
        /// the description of the Rule that may have been broken
        /// </param>
        /// <param name="severity">
        /// the <see cref="SeverityKind"/>
        /// </param>
        public RuleCheckResult(Thing thing, string id, string description, SeverityKind severity)
        {
            this.Thing = thing;
            this.Id = id;
            this.Description = description;
            this.Severity = severity;
        }

        /// <summary>
        /// Gets or sets a reference to te <see cref="Thing"/> that has been checked by a Rule
        /// </summary>
        public Thing Thing { get; set; }

        /// <summary>
        /// Gets or sets the identifier or code of the Rule that may have been broken
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the description of the Rule that may have been broken
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="SeverityKind"/>
        /// </summary>
        public SeverityKind Severity { get; set; }
    }
}