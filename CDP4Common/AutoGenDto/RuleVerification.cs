// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerification.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="RuleVerification"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(RuleVerificationList), "RuleVerification")]
    public abstract partial class RuleVerification : Thing, INamedThing, IOwnedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RuleVerification"/> class.
        /// </summary>
        protected RuleVerification()
        {
            this.Violation = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleVerification"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected RuleVerification(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Violation = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the ExecutedOn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual DateTime? ExecutedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public Guid Owner
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property RuleVerification.Owner"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property RuleVerification.Owner"); }
        }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual RuleVerificationStatusKind Status { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Violation instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: false)]
        public virtual List<Guid> Violation { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="RuleVerification"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="RuleVerification"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Violation);
                return containers;
            }
        }
    }
}
