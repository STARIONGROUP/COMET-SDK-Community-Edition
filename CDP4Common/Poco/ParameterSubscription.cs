// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscription.cs" company="Starion Group S.A.">
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

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterSubscription"/>
    /// </summary>
    public partial class ParameterSubscription : IModelCode
    {
        /// <summary>
        /// Returns the derived <see cref="ParameterType"/> value
        /// </summary>
        /// <returns>The <see cref="ParameterType"/> value</returns>
        protected ParameterType GetDerivedParameterType()
        {
            var parameter = this.Container as Parameter;
            if (parameter != null)
            {
                return parameter.ParameterType;
            }

            var parameterOverride = this.Container as ParameterOverride;
            if (parameterOverride != null)
            {
                return parameterOverride.ParameterType;
            }

            throw new ContainmentException($"{this} is not contained by a valid Parameter or ParameterOverride");
        }

        /// <summary>
        /// Returns the derived <see cref="Scale"/> value
        /// </summary>
        /// <returns>The <see cref="Scale"/> value</returns>
        protected MeasurementScale GetDerivedScale()
        {
            return ((ParameterBase)this.Container).Scale;
        }

        /// <summary>
        /// Returns the derived <see cref="StateDependence"/> value
        /// </summary>
        /// <returns>The <see cref="StateDependence"/> value</returns>
        protected ActualFiniteStateList GetDerivedStateDependence()
        {
            return ((ParameterBase)this.Container).StateDependence;
        }

        /// <summary>
        /// Returns the derived <see cref="IsOptionDependent"/> value
        /// </summary>
        /// <returns>The <see cref="IsOptionDependent"/> value</returns>
        protected bool GetDerivedIsOptionDependent()
        {
            return ((ParameterOrOverrideBase)this.Container).IsOptionDependent;
        }

        /// <summary>
        /// Returns the derived <see cref="Group"/> value
        /// </summary>
        /// <returns>The <see cref="Group"/> value</returns>
        protected ParameterGroup GetDerivedGroup()
        {
            return ((ParameterBase)this.Container).Group;
        }

        /// <summary>
        /// Computes the model code of the current <see cref="ParameterSubscription"/>
        /// </summary>
        /// <param name="componentIndex">
        /// This parameter is ignored when computing the model code of a <see cref="ParameterSubscription"/>
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ParameterType.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="Parameter"/>
        /// </returns>
        public override string ModelCode(int? componentIndex = null)
        {
            var parameterOrOverrideBase = (ParameterOrOverrideBase)this.Container;
            return parameterOrOverrideBase.ModelCode(componentIndex);
        }

        /// <summary>
        /// Validate this <see cref="ParameterSubscription"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected override IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>(base.ValidatePocoProperties());
            if (this.IsOptionDependent)
            {
                var iteration = this.GetContainerOfType<Iteration>();
                if (this.StateDependence != null)
                {
                    foreach (Option option in iteration.Option)
                    {
                        foreach (var actualState in this.StateDependence.ActualState.Where(x => x.Kind == ActualFiniteStateKind.MANDATORY))
                        {
                            var valueSets = this.ValueSet.Where(vs => vs.ActualOption == option && vs.ActualState == actualState).ToList();
                            errorList.AddRange(this.ValidateValueSets(valueSets, option, actualState));
                        }
                    }
                }
                else
                {
                    foreach (Option option in iteration.Option)
                    {
                        var valueSets = this.ValueSet.Where(vs => vs.ActualOption == option).ToList();
                        errorList.AddRange(this.ValidateValueSets(valueSets, option, null));
                    }
                }
            }
            else
            {
                if (this.StateDependence != null)
                {
                    foreach (var actualState in this.StateDependence.ActualState.Where(x => x.Kind == ActualFiniteStateKind.MANDATORY))
                    {
                        var valueSets = this.ValueSet.Where(vs => vs.ActualState == actualState).ToList();
                        errorList.AddRange(this.ValidateValueSets(valueSets, null, actualState));
                    }
                }
                else
                {
                    var valuesets = this.ValueSet.ToList();
                    errorList.AddRange(this.ValidateValueSets(valuesets, null, null));
                }
            }

            return errorList;
        }

        /// <summary>
        /// Validate the value-sets of this <see cref="ParameterSubscription"/> for an option and state if applicable
        /// </summary>
        /// <param name="valueSets">The <see cref="ParameterSubscriptionValueSet"/>s found for the corresponding option and state</param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="state">The <see cref="ActualFiniteState"/></param>
        /// <returns>a list of error messages</returns>
        private IEnumerable<string> ValidateValueSets(IEnumerable<ParameterSubscriptionValueSet> valueSets, Option option, ActualFiniteState state)
        {
            var errorList = new List<string>();
            var valuesets = valueSets.ToList();
            if (valuesets.Count == 0)
            {
                errorList.Add($"No value-set was found for the option {((option == null) ? "-" : option.Name)} and state {((state == null) ? "-" : state.Name)}");
            }
            else if (valuesets.Count > 1)
            {
                errorList.Add($"Duplicated value-sets were found for the option {((option == null) ? "-" : option.Name)} and state {((state == null) ? "-" : state.Name)}");
            }
            else
            {
                var valueset = valuesets.Single();
                errorList.AddRange(valueset.ValidationErrors);
            }

            return errorList;
        }
    }
}