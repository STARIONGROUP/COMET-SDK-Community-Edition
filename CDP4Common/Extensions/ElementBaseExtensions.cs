// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementBaseExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2023 Starion Group S.A.
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

    /// <summary>
    /// Extension methods for the <see cref="ElementBase"/> class.
    /// </summary>
    public static class ElementBaseExtensions
    {
        /// <summary>
        /// Filters the <paramref name="elements"/> by the <paramref name="state"/>
        /// </summary>
        /// <param name="elements">
        /// the elements to filter
        /// </param>
        /// <param name="state">
        /// the state used to filter
        /// </param>
        /// <returns>
        /// the filtered elements
        /// </returns>
        public static IEnumerable<ElementBase> FilterByState(this IEnumerable<ElementBase> elements, ActualFiniteState state)
        {
            var filteredElements = new List<ElementBase>();

            foreach (var element in elements)
            {
                if (element is ElementDefinition elementDefinition)
                {
                    elementDefinition.Parameter.ForEach(p =>
                    {
                        p.ValueSet.ForEach(v =>
                        {
                            if (v.ActualState != null && v.ActualState == state)
                            {
                                filteredElements.Add(element);
                            }
                        });
                    });
                }
                else if (element is ElementUsage elementUsage)
                {
                    if (elementUsage.ParameterOverride.Any())
                    {
                        elementUsage.ParameterOverride.ForEach(p =>
                        {
                            p.ValueSet.ForEach(v =>
                            {
                                if (v.ActualState != null && v.ActualState == state)
                                {
                                    filteredElements.Add(element);
                                }
                            });
                        });
                    }

                    elementUsage.ElementDefinition.Parameter.ForEach(p =>
                    {
                        p.ValueSet.ForEach(v =>
                        {
                            if (v.ActualState != null && v.ActualState == state)
                            {
                                filteredElements.Add(element);
                            }
                        });
                    });
                }
            }

            return filteredElements;
        }
    }
}
