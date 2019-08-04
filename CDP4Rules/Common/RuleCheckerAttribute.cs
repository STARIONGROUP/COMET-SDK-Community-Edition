// <copyright file="RuleCheckerAttribute.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RuleCheckerAttribute"/> is to decorate classes that can execute
    /// rules for a specific <see cref="Type"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class RuleCheckerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleCheckerAttribute"/> class
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> that this attributed rule is applicable to.
        /// </param>
        public RuleCheckerAttribute(Type type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Gets or sets the associated <see cref="Type"/>
        /// </summary>
        public Type Type { get; set; }
    }
}
