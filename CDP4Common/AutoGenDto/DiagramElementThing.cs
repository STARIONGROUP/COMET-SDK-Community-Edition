// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramElementThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="DiagramElementThing"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementContainer), "DiagramElement")]
    public abstract partial class DiagramElementThing : DiagramElementContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementThing"/> class.
        /// </summary>
        protected DiagramElementThing()
        {
            this.LocalStyle = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementThing"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected DiagramElementThing(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.LocalStyle = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DepictedThing.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? DepictedThing { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained LocalStyle instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> LocalStyle { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SharedStyle.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? SharedStyle { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="DiagramElementThing"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagramElementThing"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.LocalStyle);
                return containers;
            }
        }
    }
}
