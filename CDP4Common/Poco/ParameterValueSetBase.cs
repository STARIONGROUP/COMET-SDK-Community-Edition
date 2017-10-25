// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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