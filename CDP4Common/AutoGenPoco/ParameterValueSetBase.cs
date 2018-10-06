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
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// abstract superclass representing the switch setting and values of a Parameter or ParameterOverride and serves as a common reference type for ParameterValueSet and ParameterOverrideValueSet
    /// </summary>
    public abstract partial class ParameterValueSetBase : Thing, IOwnedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueSetBase"/> class.
        /// </summary>
        protected ParameterValueSetBase()
        {
            this.Computed = new ValueArray<string>(this);
            this.Formula = new ValueArray<string>(this);
            this.Manual = new ValueArray<string>(this);
            this.Published = new ValueArray<string>(this);
            this.Reference = new ValueArray<string>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueSetBase"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        protected ParameterValueSetBase(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Computed = new ValueArray<string>(this);
            this.Formula = new ValueArray<string>(this);
            this.Manual = new ValueArray<string>(this);
            this.Published = new ValueArray<string>(this);
            this.Reference = new ValueArray<string>(this);
        }

        /// <summary>
        /// Gets or sets the ActualOption.
        /// </summary>
        /// <remarks>
        /// reference to the actual Option to which this ParameterValueSetBase pertains
        /// Note: This reference shall only be assigned for Parameters that have <i>isOptionDependent</i> set to true. Otherwise it shall be null.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Option ActualOption { get; set; }

        /// <summary>
        /// Gets or sets the ActualState.
        /// </summary>
        /// <remarks>
        /// reference to the ActualFiniteState to which this ParameterValueSet pertains
        /// Note: This reference shall only be assigned for Parameters and ParameterOverrides that have a <i>stateDependence</i> to an ActualFiniteStateList.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ActualFiniteState ActualState { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// derived actual value depending on the <i>valueSwitch</i> setting
        /// Note: The <i>actualValue</i> is derived in the following way:
        /// if <i>valueSwitch</i> is COMPUTED then <i>actualValue</i> is <i>computed;</i>
        /// if <i>valueSwitch</i> is MANUAL, then <i>actualValue</i> is <i>manual;</i>
        /// if <i>valueSwitch</i> is REFERENCE, then <i>actualValue</i> is <i>reference</i>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualValue property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public ValueArray<string> ActualValue
        {
            get { return this.GetDerivedActualValue(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterValueSetBase.ActualValue"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// computed parameter value
        /// Note: This is value of the associated Parameter as computed by the parameter's owner (DomainOfExpertise).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Computed { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// formula assigned by the owner (DomainOfExpertise) of the associated Parameter or ParameterOverride
        /// Note: The formula is needed to define a link into an external application (typically MS Excel) to retrieve the computed parameter value.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Formula { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// manually assigned parameter value
        /// Note: The <i>manual</i> value is typically used in the beginning of the modelling process, when computed and published values are not yet available, in order to enable starting computations with ParameterSubscriptions.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Manual { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// owner (DomainOfExpertise) derived from associated Parameter or ParameterOverride for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public DomainOfExpertise Owner
        {
            get { return this.GetDerivedOwner(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterValueSetBase.Owner"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// last published parameter value
        /// Note: At the time of Publication the <i>actualValue</i> (i.e. depending on the actual setting of the <i>valueSwitch</i> at Publication time) is copied to this <i>published</i> value. Subsequently the <i>published</i> value of this ParameterValueSet is the value that will appear in the derived <i>computed</i> value of ParameterSubscriptionValueSets that reference this ParameterValueSet.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Published { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// reference parameter value
        /// Note: The reference value is typically a value originating from outside the current EngineeringModel to be used as a reference to be compared with the (newly) computed value. However the reference values may be used for any purpose that is deemed useful by the users of the EngineeringModel.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Reference { get; set; }

        /// <summary>
        /// Gets or sets the ValueSwitch.
        /// </summary>
        /// <remarks>
        /// switch that determines which value is actually used
        /// Note: See ParameterSwitchKind for the description of the different possibilities.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ParameterSwitchKind ValueSwitch { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterValueSetBase"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterValueSetBase"/>.
        /// </returns>
        public new ParameterValueSetBase Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterValueSetBase)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterValueSetBase"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var computedCount = this.Computed.Count();
            if (computedCount < 1)
            {
                errorList.Add("The number of elements in the property Computed is wrong. It should be at least 1.");
            }

            var formulaCount = this.Formula.Count();
            if (formulaCount < 1)
            {
                errorList.Add("The number of elements in the property Formula is wrong. It should be at least 1.");
            }

            var manualCount = this.Manual.Count();
            if (manualCount < 1)
            {
                errorList.Add("The number of elements in the property Manual is wrong. It should be at least 1.");
            }

            var publishedCount = this.Published.Count();
            if (publishedCount < 1)
            {
                errorList.Add("The number of elements in the property Published is wrong. It should be at least 1.");
            }

            var referenceCount = this.Reference.Count();
            if (referenceCount < 1)
            {
                errorList.Add("The number of elements in the property Reference is wrong. It should be at least 1.");
            }

            return errorList;
        }
    }
}
