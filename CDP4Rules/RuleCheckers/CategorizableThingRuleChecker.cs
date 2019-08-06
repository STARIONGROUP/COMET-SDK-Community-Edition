// <copyright file="CategorizableThingRuleChecker.cs" company="RHEA System S.A.">
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

namespace CDP4Rules.RuleCheckers
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;

    /// <summary>
    /// The purpose of the <see cref="CategorizableThingRuleChecker"/> is to execute the rules for instances of type <see cref="ICategorizableThing"/>
    /// </summary>
    [RuleChecker(typeof(ICategorizableThing))]
    public class CategorizableThingRuleChecker
    {
        /// <summary>
        /// Checks whether the <see cref="ICategorizableThing"/> is not a member of the same category more
        /// than once, including through sub-classing of categories 
        /// </summary>
        /// <param name="thing">
        /// The subject <see cref="IAnnotation"/>
        /// </param>
        /// <returns>
        /// A instance of <see cref="RuleCheckResult"/>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// thrown when <param name="thing"/> is not an <see cref="IAnnotation"/>
        /// </exception>
        [Rule("MA-003")]
        public RuleCheckResult CheckWhetherThereAreNoDuplicateCategoriesAreDefined(Thing thing)
        {
            throw new NotImplementedException();
        }
    }
}