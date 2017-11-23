// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetup.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="IterationSetup"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(EngineeringModelSetup), "IterationSetup")]
    public sealed partial class IterationSetup : Thing, IParticipantAffectedAccessThing, ITimeStampedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IterationSetup"/> class.
        /// </summary>
        public IterationSetup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IterationSetup"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public IterationSetup(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the FrozenOn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public DateTime? FrozenOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeleted.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced IterationIid.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid IterationIid { get; set; }

        /// <summary>
        /// Gets or sets the IterationNumber.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public int IterationNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SourceIterationSetup.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? SourceIterationSetup { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="IterationSetup"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.IterationSetup"/> from a <see cref="IterationSetup"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.IterationSetup"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.IterationSetup(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as IterationSetup;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            this.CreatedOn = original.CreatedOn;

            this.Description = original.Description;

            foreach (var guid in original.ExcludedDomain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedDomain.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedPerson)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedPerson.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            this.FrozenOn = original.FrozenOn;

            this.IsDeleted = original.IsDeleted;

            this.IterationIid = original.IterationIid;

            this.IterationNumber = original.IterationNumber;

            this.ModifiedOn = original.ModifiedOn;

            var copySourceIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.SourceIterationSetup);
            this.SourceIterationSetup = copySourceIterationSetup.Value == null ? original.SourceIterationSetup : copySourceIterationSetup.Value.Iid;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copySourceIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.SourceIterationSetup);
            if (copySourceIterationSetup.Key != null)
            {
                this.SourceIterationSetup = copySourceIterationSetup.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
