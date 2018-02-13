#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBase.cs" company="RHEA System S.A.">
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
    /// Extended part for the auto-generated <see cref="ParameterValueSetBase"/>
    /// </summary>
    public partial class ParameterValueSetBase : IValueSet
    {
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
                    throw new InvalidOperationException(string.Format("Unkown ParameterKindSwitch: {0}", this.ValueSwitch));
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

            var parameteroverride = this.Container as ParameterOverride;
            if (parameteroverride != null)
            {
                return parameteroverride.Owner;
            }

            throw new NullReferenceException("The Container of ParameterValueSetBase is not the right type or is null");
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

            if (this.Published.Count() != numberOfComponent)
            {
                errorList.Add(string.Format("Wrong number of values in the Published set for the option: {0}, state: {1}", (this.ActualOption == null) ? "-" : this.ActualOption.Name, (this.ActualState == null) ? "-" : this.ActualState.Name));
            }

            return errorList;
        }
    }
}