// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// enumeration datatype that defines the possible kinds of ActualFiniteState
    /// </summary>
    public enum ActualFiniteStateKind
    {
        /// <summary>
        /// assertion that an ActualFiniteState is mandatory, i.e. shall be used as an actualState on a ParameterValueSet or ParameterSubscriptionValueSet for a Parameter that has a <i>stateDependence</i> on the ActualFiniteStateList that contains the ActualFiniteState
        /// </summary>
        MANDATORY,

        /// <summary>
        /// assertion that an ActualFiniteState is forbidden, i.e. shall be not used as an actualState on a ParameterValueSet or ParameterSubscriptionValueSet for a Parameter that has a <i>stateDependence</i> on the ActualFiniteStateList that contains the ActualFiniteState
        /// </summary>
        FORBIDDEN,
    }
}
