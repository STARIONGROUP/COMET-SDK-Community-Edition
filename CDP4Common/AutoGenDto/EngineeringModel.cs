// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModel.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="EngineeringModel"/> class.
    /// </summary>
    [DataContract]
    public sealed partial class EngineeringModel : TopContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModel"/> class.
        /// </summary>
        public EngineeringModel()
        {
            this.Book = new List<OrderedItem>();
            this.CommonFileStore = new List<Guid>();
            this.GenericNote = new List<Guid>();
            this.Iteration = new List<Guid>();
            this.LogEntry = new List<Guid>();
            this.ModellingAnnotation = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModel"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public EngineeringModel(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Book = new List<OrderedItem>();
            this.CommonFileStore = new List<Guid>();
            this.GenericNote = new List<Guid>();
            this.Iteration = new List<Guid>();
            this.LogEntry = new List<Guid>();
            this.ModellingAnnotation = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Book instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> Book { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained CommonFileStore instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> CommonFileStore { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced EngineeringModelSetup.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid EngineeringModelSetup { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained GenericNote instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> GenericNote { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Iteration instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Iteration { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained LogEntry instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> LogEntry { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ModellingAnnotation instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ModellingAnnotation { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="EngineeringModel"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModel"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Book);
                containers.Add(this.CommonFileStore);
                containers.Add(this.GenericNote);
                containers.Add(this.Iteration);
                containers.Add(this.LogEntry);
                containers.Add(this.ModellingAnnotation);
                return containers;
            }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.EngineeringModel"/> from a <see cref="EngineeringModel"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.EngineeringModel"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.EngineeringModel(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as EngineeringModel;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var orderedItem in original.Book)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", orderedItem.V));
                }
                this.Book.Add(new OrderedItem { K = orderedItem.K, V = copy.Value.Iid });
            }

            foreach (var guid in original.CommonFileStore)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.CommonFileStore.Add(copy.Value.Iid);
            }

            var copyEngineeringModelSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.EngineeringModelSetup);
            this.EngineeringModelSetup = copyEngineeringModelSetup.Value == null ? original.EngineeringModelSetup : copyEngineeringModelSetup.Value.Iid;

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

            foreach (var guid in original.GenericNote)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.GenericNote.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Iteration)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Iteration.Add(copy.Value.Iid);
            }

            this.LastModifiedOn = original.LastModifiedOn;

            foreach (var guid in original.LogEntry)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.LogEntry.Add(copy.Value.Iid);
            }

            foreach (var guid in original.ModellingAnnotation)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ModellingAnnotation.Add(copy.Value.Iid);
            }

            this.ModifiedOn = original.ModifiedOn;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            return hasChanges;
        }
    }
}
