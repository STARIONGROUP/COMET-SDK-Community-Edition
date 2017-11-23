// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterType.cs" company="RHEA System S.A.">
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
    using System.Xml.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ParameterType"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public abstract partial class ParameterType : DefinedThing, ICategorizableThing, IDeprecatableThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterType"/> class.
        /// </summary>
        protected ParameterType()
        {
            this.Category = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterType"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ParameterType(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Category = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced Category instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the NumberOfValues.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The NumberOfValues property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public int NumberOfValues
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterType.NumberOfValues"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterType.NumberOfValues"); }
        }

        /// <summary>
        /// Gets or sets the Symbol.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string Symbol { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ParameterType"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
