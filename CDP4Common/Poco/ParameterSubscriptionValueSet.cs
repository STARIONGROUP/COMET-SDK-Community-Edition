#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSet.cs" company="RHEA System S.A.">
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
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterSubscriptionValueSet"/>
    /// </summary>
    public partial class ParameterSubscriptionValueSet : IModelCode, IValueSet
    {
        /// <summary>
        /// Returns the derived <see cref="Computed"/> value
        /// </summary>
        /// <returns>The <see cref="Computed"/> value</returns>
        protected ValueArray<string> GetDerivedComputed()
        {
            return this.SubscribedValueSet.Published;
        }

        /// <summary>
        /// Returns the derived <see cref="Reference"/> value
        /// </summary>
        /// <returns>The <see cref="Reference"/> value</returns>
        protected ValueArray<string> GetDerivedReference()
        {
            return this.SubscribedValueSet.Reference;
        }

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
                    throw new InvalidOperationException("Unkown ParameterKindSwitch");
            }
        }

        /// <summary>
        /// Returns the derived <see cref="ActualState"/> value
        /// </summary>
        /// <returns>The <see cref="ActualState"/> value</returns>
        protected ActualFiniteState GetDerivedActualState()
        {
            return this.SubscribedValueSet.ActualState;
        }

        /// <summary>
        /// Returns the derived <see cref="ActualOption"/> value
        /// </summary>
        /// <returns>The <see cref="ActualOption"/> value</returns>
        protected Option GetDerivedActualOption()
        {
            return this.SubscribedValueSet.ActualOption;
        }

        /// <summary>
        /// Returns the derived <see cref="Owner"/> value
        /// </summary>
        /// <returns>The <see cref="Owner"/> value</returns>
        protected DomainOfExpertise GetDerivedOwner()
        {
            var container = this.Container as ParameterSubscription;
            if (container == null)
            {
                throw new NullReferenceException("The container of ParameterSubscriptionValueSet is null");
            }

            return container.Owner;
        }

        /// <summary>
        /// Computes the model code of the current <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ParameterType.Shortname#.#Component.ParameterType.ShortName#\#Option.ShortName#\#ActualState.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="Parameter"/>
        /// </returns>
        public string ModelCode(int? componentIndex = null)
        {
            var parameterValueSet = this.SubscribedValueSet as ParameterValueSet;
            
            if (parameterValueSet != null)
            {
                return parameterValueSet.ModelCode(componentIndex);
            }

            var parameterOverrideValueSet = this.SubscribedValueSet as ParameterOverrideValueSet;
            if (parameterOverrideValueSet != null)
            {
                return parameterOverrideValueSet.ModelCode(componentIndex);
            }

            throw new NullReferenceException("The SubscribedValueSet is null");
        }

        /// <summary>
        /// Validate this <see cref="ParameterSubscriptionValueSet"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected override IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>(base.ValidatePocoProperties());

            var container = this.Container as ParameterSubscription;
            if (container == null || container.ParameterType == null)
            {
                return errorList;
            }

            var numberOfComponent = container.ParameterType.NumberOfValues;
            if (this.Manual.Count() != numberOfComponent)
            {
                errorList.Add(string.Format("Wrong number of values in the Manual set for the option: {0}, state: {1}", (this.ActualOption == null) ? "-" : this.ActualOption.Name, (this.ActualState == null) ? "-" : this.ActualState.Name));
            }

            if (this.Computed.Count() != numberOfComponent)
            {
                errorList.Add(string.Format("Wrong number of values in the Computed set for the option: {0}, state: {1}", (this.ActualOption == null) ? "-" : this.ActualOption.Name, (this.ActualState == null) ? "-" : this.ActualState.Name));
            }

            if (this.Reference.Count() != numberOfComponent)
            {
                errorList.Add(string.Format("Wrong number of values in the Reference set for the option: {0}, state: {1}", (this.ActualOption == null) ? "-" : this.ActualOption.Name, (this.ActualState == null) ? "-" : this.ActualState.Name));
            }

            return errorList;
        }

        /// <summary>
        /// Gets the formula assigned by the owner <see cref="DomainOfExpertise"/> of the associated <see cref="Parameter"/> or <see cref="ParameterOverride"/> 
        /// </summary>
        /// <remarks>
        /// Member of the <see cref="IValueSet"/> interface added for convenience which will always resturn a <see cref="ValueArray{String}"/> where all the components are null
        /// </remarks>
        public ValueArray<string> Formula
        {
            get
            {
                var parameterSubscription = (ParameterSubscription)this.Container;
                var valueArray = new string[parameterSubscription.ParameterType.NumberOfValues];
                var formula = new ValueArray<string>(valueArray, this);                
                return formula;
            }
        }
    }
}