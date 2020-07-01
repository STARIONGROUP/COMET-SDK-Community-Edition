// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThing.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="DefinedThing"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class DefinedThing : Thing, INamedThing, IShortNamedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedThing"/> class.
        /// </summary>
        protected DefinedThing()
        {
            this.Alias = new List<Guid>();
            this.Definition = new List<Guid>();
            this.HyperLink = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedThing"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected DefinedThing(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Alias = new List<Guid>();
            this.Definition = new List<Guid>();
            this.HyperLink = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Alias instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Alias { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Definition instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Definition { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained HyperLink instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> HyperLink { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string ShortName { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DefinedThing"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Alias);
                containers.Add(this.Definition);
                containers.Add(this.HyperLink);
                return containers;
            }
        }
    }
}
