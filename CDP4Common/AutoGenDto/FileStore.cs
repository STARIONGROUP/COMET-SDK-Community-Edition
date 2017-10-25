// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileStore.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="FileStore"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class FileStore : Thing, INamedThing, IOwnedThing, ITimeStampedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FileStore"/> class.
        /// </summary>
        protected FileStore()
        {
            this.File = new List<Guid>();
            this.Folder = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileStore"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected FileStore(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.File = new List<Guid>();
            this.Folder = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained File instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> File { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Folder instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Folder { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid Owner { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="FileStore"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.File);
                containers.Add(this.Folder);
                return containers;
            }
        }
    }
}
