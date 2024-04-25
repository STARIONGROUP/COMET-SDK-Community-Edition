// <copyright file="IRuleCheckerEngine.cs" company="Starion Group S.A.">
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

namespace CDP4Rules
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Rules.Common;

    /// <summary>
    /// Definition of the <see cref="IRuleCheckerEngine"/> interface that is used to execute the <see cref="RuleChecker"/> on
    /// the provided <see cref="Thing"/>s.
    /// </summary>
    public interface IRuleCheckerEngine
    {
        /// <summary>
        /// Runs the <see cref="RuleCheckerEngine"/> on the provided <see cref="Thing"/>s
        /// </summary>
        /// <param name="things">
        /// The <see cref="Thing"/>s that need to be checked
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{RuleCheckResult}"/>
        /// </returns>
        IEnumerable<RuleCheckResult> Run(IEnumerable<Thing> things);
    }
}