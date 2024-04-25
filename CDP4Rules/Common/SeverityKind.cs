// <copyright file="SeverityKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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
    /// <summary>
    /// Enumeration data type that defines the degree of impact defined by <see cref="RuleAttribute"/> and
    /// returned as part of a <see cref="RuleCheckResult"/>
    /// </summary>
    public enum SeverityKind
    {
        /// <summary>
        /// Designation that there is no impact
        /// </summary>
        None,

        /// <summary>
        /// Designation that there is an informational impact
        /// </summary>
        Info,

        /// <summary>
        /// Designation that there is an warning impact
        /// </summary>
        Warning,

        /// <summary>
        /// Designation that there is an error impact
        /// </summary>
        Error,
    }
}
