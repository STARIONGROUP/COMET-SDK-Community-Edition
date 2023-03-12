// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValueSet.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// The interface for the value-set of the <see cref="ParameterBase"/>
    /// </summary>
    public interface IValueSet : IModelCode
    {
        /// <summary>
        /// Gets the reference to the actual <see cref="ActualFiniteState"/> to which this <see cref="IValueSet"/> pertains
        /// </summary>
        ActualFiniteState ActualState { get; }

        /// <summary>
        /// Gets the reference to the actual <see cref="Option"/> to which this <see cref="IValueSet"/> pertains
        /// </summary>
        Option ActualOption { get; }

        /// <summary>
        /// Gets the value manually set for this <see cref="IValueSet"/>
        /// </summary>
        ValueArray<string> Manual { get; }

        /// <summary>
        /// Gets the computed value for this <see cref="IValueSet"/>
        /// </summary>
        ValueArray<string> Computed { get; }

        /// <summary>
        /// Gets the reference value for this <see cref="IValueSet"/>
        /// </summary>
        ValueArray<string> Reference { get; }

        /// <summary>
        /// Gets the actual value used for this <see cref="IValueSet"/> which depends on this <see cref="ValueSwitch"/>
        /// </summary>
        ValueArray<string> ActualValue { get; }

        /// <summary>
        /// Gets the formula assigned by the owner <see cref="DomainOfExpertise"/> of the associated <see cref="Parameter"/> or <see cref="ParameterOverride"/> 
        /// </summary>
        ValueArray<string> Formula { get; }

        /// <summary>
        /// Gets or sets the <see cref="ParameterSwitchKind"/> that determines the actual value to use for this <see cref="IValueSet"/>
        /// </summary>
        ParameterSwitchKind ValueSwitch { get; set; }

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Manual"/> to proper amount of slots and default value of "-"
        /// </summary>
        void ResetManual();

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Computed"/> to proper amount of slots and default value of "-"
        /// </summary>
        void ResetComputed();

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Reference"/> to proper amount of slots and default value of "-"
        /// </summary>
        void ResetReference();

        /// <summary>
        /// Resets the <see cref="ValueArray{T}"/> of the <see cref="Formula"/> to proper amount of slots and default value of "-"
        /// </summary>
        void ResetFormula();
    }
}