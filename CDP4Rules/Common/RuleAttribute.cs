// <copyright file="RuleAttribute.cs" company="RHEA System S.A.">
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
    using System;

    /// <summary>
    /// The purpose of the <see cref="RuleAttribute"/> is to decorate methods that check a particular rule and
    /// to describe that Rule
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class RuleAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of <see cref="RuleAttribute"/>
        /// </summary>
        /// <param name="id">
        /// The alpha-numeric unique identifier of
        /// </param>
        public RuleAttribute(string id)
        {
            this.Id = id;
        }

        /// <summary>
        /// Gets or sets the alpha-numeric unique identifier of
        /// </summary>
        public string Id { get; set; }
    }
}