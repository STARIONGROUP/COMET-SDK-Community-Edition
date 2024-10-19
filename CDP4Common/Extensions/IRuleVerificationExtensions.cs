// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IRuleVerificationExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Extensions
{
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension methods on <see cref="IRuleVerification"/>
    /// </summary>
    public static class IRuleVerificationExtensions
    {
        /// <summary>
        /// Returns a human readable string of a <see cref="Thing"/> to identify a <see cref="Thing"/> in RuleVerification text
        /// </summary>
        /// <param name="value">The <see cref="IRuleVerification"/> to check</param>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>The human readable identifier</returns>
        public static string GetHumanReadableIdentifier(this IRuleVerification value, Thing thing)
        {
            if (thing is ElementDefinition elementDefinition)
            {
                return elementDefinition.ModelCode();
            }

            if (thing is ElementUsage elementUsage)
            {
                return elementUsage.ModelCode();
            }

            if (thing is INamedThing namedThing)
            {
                return namedThing.Name;
            }

            if (thing is IShortNamedThing shortNamedThing)
            {
                return shortNamedThing.ShortName;
            }

            return thing.Iid.ToString();
        }
    }
}
