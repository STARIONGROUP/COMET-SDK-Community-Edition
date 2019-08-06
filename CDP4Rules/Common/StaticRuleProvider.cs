// <copyright file="StaticRuleProvider.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;

    /// <summary>
    /// A static (singleton) provider for the available <see cref="IRule"/>s
    /// </summary>
    public class StaticRuleProvider
    {
        /// <summary>
        /// The <see cref="RuleProvider"/> instance for the application
        /// </summary>
        private static readonly RuleProvider provider = new RuleProvider();

        /// <summary>
        /// Queries the available <see cref="IRule"/>s.
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{IRule}"/>
        /// </returns>
        public static IEnumerable<IRule> QueryRules()
        {
            return provider.QueryRules();
        }
    }
}