﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="Starion Group S.A.">
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension for the <see cref="Parameter"/> class
    /// </summary>
    public partial class Parameter : IModelCode
    {
        /// <summary>
        /// Computes the model code of the current <see cref="Parameter"/>
        /// </summary>
        /// <param name="componentIndex">
        /// This parameter is ignored when computing the model code of a <see cref="Parameter"/>
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
            var elementDefinition = (ElementDefinition)this.Container;

            if (elementDefinition == null)
            {
                throw new ContainmentException($"The container ElementDefinition of Parameter with iid {this.Iid} is null, the model code cannot be computed.");
            }

            var compoundParameterType = this.ParameterType as CompoundParameterType;
            if (compoundParameterType == null && componentIndex > 0)
            {
                throw new ArgumentException("The value must be 0 if the ParameterType is not a CompoundParameterType", nameof(componentIndex));
            }

            if (compoundParameterType != null && componentIndex != null)
            {
                var component = Utils.FormatComponentShortName(compoundParameterType.Component[componentIndex.Value].ShortName);
                return $"{elementDefinition.ShortName}.{compoundParameterType.ShortName}.{component}";
            }

            return $"{elementDefinition.ShortName}.{this.ParameterType.ShortName}";
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Parameter"/> can be published.
        /// </summary>
        public override bool CanBePublished
        {
            get { return this.ValueSet.Any(vs => !vs.ActualValue.SequenceEqual(vs.Published)); }
        }

        /// <summary>
        /// Validate this <see cref="Parameter"/> with custom rules
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
                            var valuesets = this.ValueSet.Where(vs => vs.ActualOption == option && vs.ActualState == actualState).ToList();
                            errorList.AddRange(this.ValidateValueSets(valuesets, option, actualState));
                        }
                    }
                }
                else
                {
                    foreach (Option option in iteration.Option)
                    {
                        var valuesets = this.ValueSet.Where(vs => vs.ActualOption == option).ToList();
                        errorList.AddRange(this.ValidateValueSets(valuesets, option, null));
                    }
                }
            }
            else
            {
                if (this.StateDependence != null)
                {
                    foreach (var actualState in this.StateDependence.ActualState.Where(x => x.Kind == ActualFiniteStateKind.MANDATORY))
                    {
                        var valuesets = this.ValueSet.Where(vs => vs.ActualState == actualState).ToList();
                        errorList.AddRange(this.ValidateValueSets(valuesets, null, actualState));
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
        /// Validate the value-sets of this <see cref="Parameter"/> for an option and state if applicable
        /// </summary>
        /// <param name="valueSets">The <see cref="ParameterValueSet"/>s found for the corresponding option and state</param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="state">The <see cref="ActualFiniteState"/></param>
        /// <returns>a list of error messages</returns>
        private IEnumerable<string> ValidateValueSets(IEnumerable<ParameterValueSet> valueSets, Option option, ActualFiniteState state)
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