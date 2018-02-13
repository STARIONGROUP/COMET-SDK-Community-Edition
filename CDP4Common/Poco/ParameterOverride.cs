#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverride.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterOverride"/>
    /// </summary>
    public partial class ParameterOverride : IModelCode
    {
        /// <summary>
        /// Returns the derived <see cref="ParameterType"/> value
        /// </summary>
        /// <returns>The <see cref="ParameterType"/> value</returns>
        protected ParameterType GetDerivedParameterType()
        {
            return this.Parameter.ParameterType;
        }

        /// <summary>
        /// Returns the derived <see cref="IsOptionDependent"/> value
        /// </summary>
        /// <returns>The <see cref="IsOptionDependent"/> value</returns>
        protected bool GetDerivedIsOptionDependent()
        {
            return this.Parameter != null && this.Parameter.IsOptionDependent;
        }

        /// <summary>
        /// Returns the derived <see cref="Scale"/> value
        /// </summary>
        /// <returns>The <see cref="Scale"/> value</returns>
        protected MeasurementScale GetDerivedScale()
        {
            return this.Parameter.Scale;
        }

        /// <summary>
        /// Returns the derived <see cref="StateDependence"/> value
        /// </summary>
        /// <returns>The <see cref="StateDependence"/> value</returns>
        protected ActualFiniteStateList GetDerivedStateDependence()
        {
            return this.Parameter.StateDependence;
        }

        /// <summary>
        /// Returns the derived <see cref="Group"/> value
        /// </summary>
        /// <returns>The <see cref="Group"/> value</returns>
        protected ParameterGroup GetDerivedGroup()
        {
            return this.Parameter.Group;
        }

        /// <summary>
        /// Computes the model code of the current <see cref="ParameterOverride"/>
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ElementUsage.Shortname#.#Component.ParameterType.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ParameterOverride"/>
        /// </returns>
        public override string ModelCode(int? componentIndex = null)
        {
            var elementUsage = (ElementUsage)this.Container;

            if (elementUsage == null)
            {
                throw new ContainmentException(string.Format("The container ElementUsage of ParameterOverride with iid {0} is null, the model code cannot be computed.", this.Iid));
            }

            var compoundParameterType = this.GetDerivedParameterType() as CompoundParameterType;
            if (compoundParameterType == null && componentIndex > 0)
            {
                throw new ArgumentException("The value must be 0 if the ParameterType is not a CompoundParameterType", "componentIndex");
            }

            if (compoundParameterType != null && componentIndex != null)
            {
                var component = Utils.FormatComponentShortname(compoundParameterType.Component[componentIndex.Value].ShortName);
                return string.Format("{0}.{1}.{2}", elementUsage.ModelCode(), compoundParameterType.ShortName, component);
            }

            return string.Format("{0}.{1}", elementUsage.ModelCode(), this.GetDerivedParameterType().ShortName);
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="ParameterOverride"/> can be published.
        /// </summary>
        public override bool CanBePublished
        {
            get { return this.ValueSet.Any(vs => !vs.ActualValue.SequenceEqual(vs.Published)); }
        }

        /// <summary>
        /// Validate this <see cref="ParameterOverride"/> with custom rules
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
        /// Validate the value-sets of this <see cref="ParameterOverride"/> for an option and state if applicable
        /// </summary>
        /// <param name="valueSets">The <see cref="ParameterOverrideValueSet"/>s found for the corresponding option and state</param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="state">The <see cref="ActualFiniteState"/></param>
        /// <returns>a list of error messages</returns>
        private IEnumerable<string> ValidateValueSets(IEnumerable<ParameterOverrideValueSet> valueSets, Option option, ActualFiniteState state)
        {
            var errorList = new List<string>();
            var valuesets = valueSets.ToList();
            if (valuesets.Count == 0)
            {
                errorList.Add(string.Format("No value-set was found for the option {0} and state {1}", (option == null) ? "-" : option.Name, (state == null) ? "-" : state.Name));
            }
            else if (valuesets.Count > 1)
            {
                errorList.Add(string.Format("Duplicated value-sets were found for the option {0} and state {1}", (option == null) ? "-" : option.Name, (state == null) ? "-" : state.Name));
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
