// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataAnnotation.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="EngineeringModelDataAnnotation"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    public abstract partial class EngineeringModelDataAnnotation : GenericAnnotation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataAnnotation"/> class.
        /// </summary>
        protected EngineeringModelDataAnnotation()
        {
            this.Discussion = new List<Guid>();
            this.RelatedThing = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataAnnotation"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected EngineeringModelDataAnnotation(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Discussion = new List<Guid>();
            this.RelatedThing = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Author.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid Author { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Discussion instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Discussion { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced PrimaryAnnotatedThing.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? PrimaryAnnotatedThing { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RelatedThing instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> RelatedThing { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModelDataAnnotation"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Discussion);
                containers.Add(this.RelatedThing);
                return containers;
            }
        }
    }
}
