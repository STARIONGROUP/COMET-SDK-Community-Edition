// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBase.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ParameterValueSetBase"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class ParameterValueSetBase : Thing, IOwnedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueSetBase"/> class.
        /// </summary>
        protected ParameterValueSetBase()
        {
            this.Computed = new ValueArray<string>();
            this.Formula = new ValueArray<string>();
            this.Manual = new ValueArray<string>();
            this.Published = new ValueArray<string>();
            this.Reference = new ValueArray<string>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueSetBase"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ParameterValueSetBase(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Computed = new ValueArray<string>();
            this.Formula = new ValueArray<string>();
            this.Manual = new ValueArray<string>();
            this.Published = new ValueArray<string>();
            this.Reference = new ValueArray<string>();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ActualOption.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? ActualOption { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ActualState.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? ActualState { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The ActualValue property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public ValueArray<string> ActualValue
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterValueSetBase.ActualValue"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterValueSetBase.ActualValue"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ValueArray<string> Computed { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ValueArray<string> Formula { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ValueArray<string> Manual { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public Guid Owner
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterValueSetBase.Owner"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterValueSetBase.Owner"); }
        }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ValueArray<string> Published { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ValueArray<string> Reference { get; set; }

        /// <summary>
        /// Gets or sets the ValueSwitch.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual ParameterSwitchKind ValueSwitch { get; set; }
    }
}
