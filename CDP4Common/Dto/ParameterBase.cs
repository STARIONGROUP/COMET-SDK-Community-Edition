// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The extended part of the auto-generated <see cref="ParameterBase"/>
    /// </summary>
    public partial class ParameterBase
    {
        /// <summary>
        /// Gets the <see cref="Guid"/> of the value-sets of this <see cref="ParameterBase"/>
        /// </summary>
        /// <remarks>
        /// This is a convenience method to retrieve <see cref="Parameter.ValueSet"/>, 
        /// <see cref="ParameterOverride.ValueSet"/> or <see cref="ParameterSubscription.ValueSet"/>
        /// </remarks>
        public IEnumerable<Guid> ValueSets
        {
            get
            {
                var parameter = this as Parameter;
                if (parameter != null)
                {
                    return parameter.ValueSet;
                }

                var parameterOverride = this as ParameterOverride;
                if (parameterOverride != null)
                {
                    return parameterOverride.ValueSet;
                }

                var subscription = (ParameterSubscription)this;
                return subscription.ValueSet;
            }
        }
    }
}