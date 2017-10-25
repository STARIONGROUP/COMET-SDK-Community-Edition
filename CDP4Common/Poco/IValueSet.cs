// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IValueSet.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// The interface for the value-set of the <see cref="ParameterBase"/>
    /// </summary>
    public interface IValueSet
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
    }
}