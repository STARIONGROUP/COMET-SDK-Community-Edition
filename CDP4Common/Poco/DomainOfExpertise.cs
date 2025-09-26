// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertise.cs" company="Starion Group S.A.">
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

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System.Linq;
    using EngineeringModelData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="DomainOfExpertise"/>
    /// </summary>
    public partial class DomainOfExpertise
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DomainOfExpertise"/> can be published based on the
        /// provided <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">
        /// The iteration to perform the check on.
        /// </param>
        /// <returns>
        /// True if this <see cref="DomainOfExpertise"/> has <see cref="ParameterOrOverrideBase"/>s that can be published.
        /// </returns>
        public bool CanBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Any(parameterBase => parameterBase.CanBePublished);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParameters(Iteration iteration)
        {
            var parameters = iteration.Element.SelectMany(element => element.Parameter).Where(parameter => parameter.Owner == this);
            var parameterOverrides = iteration.Element.SelectMany(ele => ele.ContainedElement).SelectMany(usage => usage.ParameterOverride).Where(parameterOverride => parameterOverride.Owner == this);

            return parameters.Concat<ParameterOrOverrideBase>(parameterOverrides);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/> that can be published.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns that can be published.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParametersThatCanBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Where(p => p.CanBePublished);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/> to be published.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns that can be published.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParametersToBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Where(p => p.CanBePublished && p.ToBePublished);
        }
    }
}