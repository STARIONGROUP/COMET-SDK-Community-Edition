// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeExtensions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.Exceptions;

    /// <summary>
    /// Extension class for <see cref="ParameterType" />
    /// </summary>
    public static class ParameterTypeExtensions
    {
        /// <summary>
        /// Retrieves inside a collection of <see cref="Thing" /> the association of a <see cref="ParameterType" />
        /// and <see cref="MeasurementScale" /> for a given <see cref="ParameterTypeComponent" />
        /// </summary>
        /// <param name="component">
        /// The <see cref="ParameterTypeComponent" /> that provides <see cref="Guid" />s to retrieve the
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <param name="things">
        /// A collection of <see cref="Thing" />s to be able to retrieve referenced
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <returns>The <see cref="ParameterType" /> and the <see cref="Guid"/> of the associated <see cref="MeasurementScale" /></returns>
        /// <exception cref="InvalidDataException">
        /// If the requested <see cref="ParameterType" /> is not present in the <paramref name="things" />
        /// </exception>
        public static (ParameterType parameterType, Guid? scaleId) QueryParameterTypeAndMeasurementScale(this ParameterTypeComponent component, IReadOnlyCollection<Thing> things)
        {
            var parameterType = things.OfType<ParameterType>().FirstOrDefault(x => x.Iid == component.ParameterType)
                                ?? throw new ThingNotFoundException($"The provided collection of Things does not contain a reference to the ParameterType {component.ParameterType}");

            return (parameterType, component.Scale);
        }

        /// <summary>
        /// Retrieves inside a collection of <see cref="Thing" /> the association of a <see cref="ParameterType" />
        /// and <see cref="MeasurementScale" /> for a given <see cref="IParameterTypeAssignment" />
        /// </summary>
        /// <param name="assignment">
        /// The <see cref="IParameterTypeAssignment" /> that provides <see cref="Guid" />s to retrieve the
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <param name="things">
        /// A collection of <see cref="Thing" />s to be able to retrieve referenced
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <returns>The <see cref="ParameterType" /> and the <see cref="Guid"/> of the associated <see cref="MeasurementScale" /></returns>
        /// <exception cref="InvalidDataException">
        /// If the requested <see cref="ParameterType" /> is not present in the <paramref name="things" />
        /// </exception>
        public static (ParameterType parameterType, Guid? scaleId) QueryParameterTypeAndMeasurementScale(this IParameterTypeAssignment assignment, IReadOnlyCollection<Thing> things)
        {
            var parameterType = things.OfType<ParameterType>().FirstOrDefault(x => x.Iid == assignment.ParameterType)
                                ?? throw new ThingNotFoundException($"The provided collection of Things does not contain a reference to the ParameterType {assignment.ParameterType}");

            return (parameterType, assignment.MeasurementScale);
        }

        /// <summary>
        /// Retrieves inside a collection of <see cref="Thing" /> all association of <see cref="ParameterType" />
        /// and <see cref="MeasurementScale" /> for a given <see cref="CompoundParameterType" />
        /// </summary>
        /// <param name="compoundParameterType">
        /// The <see cref="CompoundParameterType" /> that provides <see cref="Guid" />s to retrieve the
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <param name="things">
        /// A collection of <see cref="Thing" />s to be able to retrieve referenced
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <returns>The <see cref="ParameterType" /> and the <see cref="Guid"/> of the associated <see cref="MeasurementScale" /> association</returns>
        /// <exception cref="InvalidDataException">
        /// If referenced <see cref="ParameterTypeComponent" /> can not be retrieved
        /// </exception>
        public static IReadOnlyList<(ParameterType parameterType, Guid? scaleId)> QueryParameterTypesAndMeasurementScale(this CompoundParameterType compoundParameterType, IReadOnlyCollection<Thing> things)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "The provided collection of referenced Thing cannot be null");
            }

            var parameterTypesAndScale = new List<(ParameterType parameterType, Guid? scaleId)>();

            foreach (var componentId in compoundParameterType.Component.Select(x => x.V).OfType<Guid>())
            {
                var parameterTypeComponent = things.OfType<ParameterTypeComponent>()
                    .FirstOrDefault(x => x.Iid == componentId);

                if (parameterTypeComponent != null)
                {
                    parameterTypesAndScale.Add(parameterTypeComponent.QueryParameterTypeAndMeasurementScale(things));
                }
                else
                {
                    throw new ThingNotFoundException($"The provided collection of referenced Things does not contain the ParameterTypeComponent {componentId}");
                }
            }

            return parameterTypesAndScale;
        }

        /// <summary>
        /// Retrieves inside a collection of <see cref="Thing" /> all association of <see cref="ParameterType" />
        /// and <see cref="MeasurementScale" /> for a given <see cref="SampledFunctionParameterType" />
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="SampledFunctionParameterType" /> that provides <see cref="Guid" />s to retrieve the
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <param name="things">
        /// A collection of <see cref="Thing" />s to be able to retrieve referenced
        /// <see cref="ParameterType" /> and the <see cref="MeasurementScale" />, if applicable
        /// </param>
        /// <returns>The <see cref="ParameterType" /> and the <see cref="Guid"/> of the associated <see cref="MeasurementScale" /> association</returns>
        /// <exception cref="InvalidDataException">
        /// If referenced <see cref="IParameterTypeAssignment" /> can not be retrieved
        /// </exception>
        public static IReadOnlyList<(ParameterType parameterType, Guid? scaledId)> QueryParameterTypesAndMeasurementScale(this SampledFunctionParameterType sampledFunctionParameterType, IReadOnlyCollection<Thing> things)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "The provided collection of referenced Thing cannot be null");
            }

            var parameterTypesAndScale = new List<(ParameterType parameterType, Guid? scaleId)>();

            foreach (var independentId in sampledFunctionParameterType.IndependentParameterType.Select(x => x.V).OfType<Guid>())
            {
                var independentParameterTypeAssignment = things.OfType<IndependentParameterTypeAssignment>()
                    .FirstOrDefault(x => x.Iid == independentId);

                if (independentParameterTypeAssignment != null)
                {
                    parameterTypesAndScale.Add(independentParameterTypeAssignment.QueryParameterTypeAndMeasurementScale(things));
                }
                else
                {
                    throw new ThingNotFoundException($"The provided collection of referenced Things does not contain the IndependentParameterTypeAssignment {independentId}");
                }
            }

            foreach (var dependentId in sampledFunctionParameterType.DependentParameterType.Select(x => x.V).OfType<Guid>())
            {
                var dependentParameterTypeAssignment = things.OfType<DependentParameterTypeAssignment>()
                    .FirstOrDefault(x => x.Iid == dependentId);

                if (dependentParameterTypeAssignment != null)
                {
                    parameterTypesAndScale.Add(dependentParameterTypeAssignment.QueryParameterTypeAndMeasurementScale(things));
                }
                else
                {
                    throw new ThingNotFoundException($"The provided collection of referenced Things does not contain the DependentParameterTypeAssignment {dependentId}");
                }
            }

            return parameterTypesAndScale;
        }
    }
}
