// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdge.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="DiagramEdge"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementContainer), "DiagramElement")]
    public sealed partial class DiagramEdge : DiagramElementThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramEdge"/> class.
        /// </summary>
        public DiagramEdge()
        {
            this.Point = new List<OrderedItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramEdge"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public DiagramEdge(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Point = new List<OrderedItem>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Point instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> Point { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Source.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Source { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Target.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Target { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="DiagramEdge"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagramEdge"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Point);
                return containers;
            }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.DiagramData.DiagramEdge"/> from a <see cref="DiagramEdge"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.DiagramData.DiagramEdge"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.DiagramData.DiagramEdge(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as DiagramEdge;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Bounds)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Bounds.Add(copy.Value.Iid);
            }

            var copyDepictedThing = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DepictedThing);
            this.DepictedThing = copyDepictedThing.Value == null ? original.DepictedThing : copyDepictedThing.Value.Iid;

            foreach (var guid in original.DiagramElement)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.DiagramElement.Add(copy.Value.Iid);
            }

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

            foreach (var guid in original.LocalStyle)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.LocalStyle.Add(copy.Value.Iid);
            }

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            foreach (var orderedItem in original.Point)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", orderedItem.V));
                }
                this.Point.Add(new OrderedItem { K = orderedItem.K, V = copy.Value.Iid });
            }

            var copySharedStyle = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.SharedStyle);
            this.SharedStyle = copySharedStyle.Value == null ? original.SharedStyle : copySharedStyle.Value.Iid;

            var copySource = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Source);
            this.Source = copySource.Value == null ? original.Source : copySource.Value.Iid;

            var copyTarget = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Target);
            this.Target = copyTarget.Value == null ? original.Target : copyTarget.Value.Iid;
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
