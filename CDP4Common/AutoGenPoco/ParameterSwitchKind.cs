#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSwitchKind.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// enumeration datatype that defines the possible switch settings to select a value in a ParameterValueSet or a ParameterSubscriptionValueSetNote: In this concurrent engineering model all parameters (see Parameter and ParameterOverride) and parameter subscriptions (see ParameterSubscription) have 3 possible values:  <i>computed</i>, <i>manual</i> and <i>reference</i>, and a <i>valueSwitch</i> to select the actual value to be used for modelling purposes. The <i>computed</i> value is the value as computed by the owner (DomainOfExpertise) of a Parameter or ParameterOverride, or in case of a ParameterSubscription it is derived from the referenced <i>published</i> value (see Publication and ParameterSubscriptionValueSet). The <i>manual</i> value is a literal value set by the owner of a Parameter, ParameterOverride or ParameterSubscription. Finally, the <i>reference</i> value is another value to be used as a reference in comparisons. Such values would typically be imported from another source than the current EngineeringModel.
    /// </summary>
    public enum ParameterSwitchKind
    {
        /// <summary>
        /// assertion that the computed value of a Parameter, ParameterOverride or ParameterSubscription will be used as the actual value
        /// </summary>
        COMPUTED,

        /// <summary>
        /// assertion that the manual value of a Parameter, ParameterOverride or ParameterSubscription will be used as the actual value
        /// </summary>
        MANUAL,

        /// <summary>
        /// assertion that the reference value of a Parameter, ParameterOverride or ParameterSubscription will be used as the actual value
        /// </summary>
        REFERENCE,
    }
}
