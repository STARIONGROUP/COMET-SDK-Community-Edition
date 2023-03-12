// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INestedElementTreeGenerator.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="NestedElementTreeGenerator"/> class is to generate the <see cref="NestedElement"/>s
    /// and <see cref="NestedParameter"/>s for an <see cref="Option"/> where the <see cref="NestedParameter"/>s
    /// are owned by a specific <see cref="DomainOfExpertise"/>
    /// </summary>
    /// <remarks>
    /// The <see cref="NestedParameter"/>s represent the owned <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s,
    /// and <see cref="ParameterSubscription"/>s. Each <see cref="ParameterTypeComponent"/> of a <see cref="CompoundParameterType"/> is 
    /// represented by a unique <see cref="NestedParameter"/>.
    /// </remarks>
    public interface INestedElementTreeGenerator
    {
        /// <summary>
        /// Creates the <see cref="NestedParameter"/>s in a flat list from <see cref="NestedElement"/>s list for the of <see cref="NestedElement"/>s.
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedParameter"/>s flat list is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedParameter"/>s flat list needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/> that contains the generated <see cref="NestedParameter"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        IEnumerable<NestedParameter> GetNestedParameters(Option option, DomainOfExpertise domainOfExpertise, bool updateOption = false);
        
        /// <summary>
        /// Creates the <see cref="NestedParameter"/>s in a flat list from <see cref="NestedElement"/>s list for the of <see cref="NestedElement"/>s.
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedParameter"/>s flat list is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/> that contains the generated <see cref="NestedParameter"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        IEnumerable<NestedParameter> GetNestedParameters(Option option, bool updateOption = false);

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        IEnumerable<NestedElement> Generate(Option option, DomainOfExpertise domainOfExpertise, bool updateOption = false);

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        IEnumerable<NestedElement> Generate(Option option, bool updateOption = false);

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        IEnumerable<NestedElement> GenerateNestedElements(Option option, DomainOfExpertise domainOfExpertise, ElementDefinition rootElement, bool updateOption = false);

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        IEnumerable<NestedElement> GenerateNestedElements(Option option, ElementDefinition rootElement, bool updateOption = false);
        
        /// <summary>
        /// Get <see cref="NestedElement.ShortName"/> for an <see cref="ElementUsage"/> 
        /// </summary>
        /// <param name="elementUsage">The <see cref="ElementUsage"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns>The <see cref="NestedElement.ShortName"/> if found, otherwise null</returns>
        string GetNestedElementPath(ElementUsage elementUsage, Option option);

        /// <summary>
        /// Get <see cref="NestedParameter.Path"/> for a <see cref="ParameterBase"/> 
        /// </summary>
        /// <param name="parameterBase">The <see cref="ParameterBase"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns>The <see cref="NestedParameter.Path"/> if found, otherwise null</returns>
        string GetNestedParameterPath(ParameterBase parameterBase, Option option);

        /// <summary>
        /// Get <see cref="NestedParameter.Path"/> for a <see cref="ParameterBase"/> 
        /// </summary>
        /// <param name="parameterBase">The <see cref="ParameterBase"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="actualFiniteState">Get the <see cref="NestedParameter.Path"/> from a specific <see cref="ActualFiniteState"/></param>
        /// <returns>The <see cref="NestedParameter.Path"/> if found, otherwise null</returns>
        string GetNestedParameterPath(ParameterBase parameterBase, Option option, ActualFiniteState actualFiniteState);
    }
}
