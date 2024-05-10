// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBase.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    
    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterValueSetBase"/>
    /// </summary>
    public partial class ParameterValueSetBase : IValueSet
    {
        /// <summary>
        /// the size of the <see cref="ValueArray{T}"/> that is determined by the numberOfValues of the referenced <see cref="ParameterType"/>
        /// </summary>
        private int valueArraySize = 0;

        /// <summary>
        /// Returns the derived <see cref="ActualValue"/> value
        /// </summary>
        /// <returns>The <see cref="ActualValue"/> value</returns>
        protected ValueArray<string> GetDerivedActualValue()
        {
            switch (this.ValueSwitch)
            {
                case ParameterSwitchKind.COMPUTED:
                    return this.Computed;

                case ParameterSwitchKind.MANUAL:
                    return this.Manual;

                case ParameterSwitchKind.REFERENCE:
                    return this.Reference;

                default:
                    throw new InvalidOperationException($"Unknown ParameterKindSwitch: {this.ValueSwitch}");
            }
        }

        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var parameter = this.Container as Parameter;
            if (parameter != null)
            {
                return parameter.Owner;
            }

            var parameterOverride = this.Container as ParameterOverride;
            if (parameterOverride != null)
            {
                return parameterOverride.Owner;
            }

            throw new ContainmentException("The Container of ParameterValueSetBase is not the right type or is null");
        }

        /// <summary>
        /// Validate this <see cref="ParameterValueSetBase"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected override IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>(base.ValidatePocoProperties());

            var container = this.Container as ParameterOrOverrideBase;
            if (container == null || container.ParameterType == null)
            {
                return errorList;
            }

            var numberOfComponent = container.ParameterType.NumberOfValues;

            // validate number of values for sampled funtion parameter type
            if(container.ParameterType is SampledFunctionParameterType sampledFunctionParameterType)
            {
                if (this.Manual.Count % numberOfComponent != 0)
                {
                    errorList.Add($"Wrong number of values in the Manual set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
                }

                if (this.Computed.Count % numberOfComponent != 0)
                {
                    errorList.Add($"Wrong number of values in the Computed set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
                }

                if (this.Reference.Count % numberOfComponent != 0)
                {
                    errorList.Add($"Wrong number of values in the Reference set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
                }

                if (this.Published.Count % numberOfComponent != 0)
                {
                    errorList.Add($"Wrong number of values in the Published set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
                }

                return errorList;
            }

            if (this.Manual.Count != numberOfComponent)
            {
                errorList.Add($"Wrong number of values in the Manual set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
            }

            if (this.Computed.Count != numberOfComponent)
            {
                errorList.Add($"Wrong number of values in the Computed set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
            }

            if (this.Reference.Count != numberOfComponent)
            {
                errorList.Add($"Wrong number of values in the Reference set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
            }

            if (this.Published.Count != numberOfComponent)
            {
                errorList.Add($"Wrong number of values in the Published set for the option: {((this.ActualOption == null) ? "-" : this.ActualOption.Name)}, state: {((this.ActualState == null) ? "-" : this.ActualState.Name)}");
            }

            return errorList;
        }

        /// <summary>
        /// Queries the <see cref="ParameterType"/> of the container <see cref="Parameter"/> or <see cref="ParameterOverride"/>
        /// </summary>
        public abstract ParameterType QueryParameterType();

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Manual"/> to proper amount of slots and default value of "-"
        /// </summary>
        public void ResetManual()
        {
            if (this.valueArraySize == 0)
            {
                var parameterType = this.QueryParameterType();
                this.valueArraySize = parameterType.NumberOfValues;
            }

            this.Manual = ValueArrayUtils.CreateDefaultValueArray(this.valueArraySize);
        }

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Computed"/> to proper amount of slots and default value of "-"
        /// </summary>
        public void ResetComputed()
        {
            if (this.valueArraySize == 0)
            {
                var parameterType = this.QueryParameterType();
                this.valueArraySize = parameterType.NumberOfValues;
            }

            this.Computed = ValueArrayUtils.CreateDefaultValueArray(this.valueArraySize);
        }

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Reference"/> to proper amount of slots and default value of "-"
        /// </summary>
        public void ResetReference()
        {
            if (this.valueArraySize == 0)
            {
                var parameterType = this.QueryParameterType();
                this.valueArraySize = parameterType.NumberOfValues;
            }

            this.Reference = ValueArrayUtils.CreateDefaultValueArray(this.valueArraySize);
        }

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Formula"/> to proper amount of slots and default value of "-"
        /// </summary>
        public void ResetFormula()
        {
            if (this.valueArraySize == 0)
            {
                var parameterType = this.QueryParameterType();
                this.valueArraySize = parameterType.NumberOfValues;
            }

            this.Formula = ValueArrayUtils.CreateDefaultValueArray(this.valueArraySize);
        }

        /// <summary>
        /// Queries the model code of the current <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ParameterType.ShortName#.#Component.ParameterType.ShortName#\#Option.ShortName#\#ActualState.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ParameterValueSetBase"/>
        /// </returns>
        public abstract string ModelCode(int? componentIndex = null);
    }
}