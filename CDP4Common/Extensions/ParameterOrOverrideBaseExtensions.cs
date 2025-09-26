// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOrOverrideBaseExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension methods for <see cref="ParameterOrOverrideBase"/>
    /// </summary>
    public static class ParameterOrOverrideBaseExtensions
    {
        /// <summary>
        /// Queries all <see cref="ParameterSubscription" /> owned by a given <see cref="DomainOfExpertise" />
        /// contained into a collection of <see cref="ParameterOrOverrideBase" />
        /// </summary>
        /// <param name="parameterOrOverrideBases">The collection of <see cref="ParameterOrOverrideBase" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public static IEnumerable<ParameterSubscription> QueryOwnedParameterSubscriptions(this IEnumerable<ParameterOrOverrideBase> parameterOrOverrideBases,
            DomainOfExpertise domain)
        {
            return parameterOrOverrideBases.Where(x => x.Owner.Iid != domain.Iid)
                .SelectMany(x => x.ParameterSubscription.Where(p => p.Owner.Iid == domain.Iid));
        }

        /// <summary>
        /// Queries all owned <see cref="ParameterOrOverrideBase" /> contained into a collection of
        /// <see cref="ParameterOrOverrideBase" />
        /// that contains <see cref="ParameterSubscription" /> of other <see cref="DomainOfExpertise" />
        /// </summary>
        /// <param name="parameterOrOverrideBases">The collection of <see cref="ParameterOrOverrideBase" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public static IEnumerable<ParameterOrOverrideBase> QuerySubscribedParameterByOthers(this IEnumerable<ParameterOrOverrideBase> parameterOrOverrideBases,
            DomainOfExpertise domain)
        {
            return parameterOrOverrideBases.Where(x => x.Owner.Iid == domain.Iid
                                                       && x.ParameterSubscription.Any(p => p.Owner.Iid != domain.Iid));
        }
    }
}
