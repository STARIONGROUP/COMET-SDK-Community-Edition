// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKind.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="DerivedQuantityKind"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public sealed partial class DerivedQuantityKind : QuantityKind
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DerivedQuantityKind"/> class.
        /// </summary>
        public DerivedQuantityKind()
        {
            this.QuantityKindFactor = new List<OrderedItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivedQuantityKind"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public DerivedQuantityKind(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.QuantityKindFactor = new List<OrderedItem>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained QuantityKindFactor instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> QuantityKindFactor { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="DerivedQuantityKind"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DerivedQuantityKind"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.QuantityKindFactor);
                return containers;
            }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.DerivedQuantityKind"/> from a <see cref="DerivedQuantityKind"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.DerivedQuantityKind"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.DerivedQuantityKind(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as DerivedQuantityKind;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Alias)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Alias.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Category)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.Category.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            var copyDefaultScale = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultScale);
            this.DefaultScale = copyDefaultScale.Value == null ? original.DefaultScale : copyDefaultScale.Value.Iid;

            foreach (var guid in original.Definition)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Definition.Add(copy.Value.Iid);
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

            foreach (var guid in original.HyperLink)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.HyperLink.Add(copy.Value.Iid);
            }

            this.IsDeprecated = original.IsDeprecated;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            foreach (var guid in original.PossibleScale)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.PossibleScale.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            this.QuantityDimensionSymbol = original.QuantityDimensionSymbol;

            foreach (var orderedItem in original.QuantityKindFactor)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", orderedItem.V));
                }
                this.QuantityKindFactor.Add(new OrderedItem { K = orderedItem.K, V = copy.Value.Iid });
            }

            this.ShortName = original.ShortName;

            this.Symbol = original.Symbol;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            for (var i = 0; i < this.Category.Count; i++)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.Category[i]);
                if (copy.Key != null)
                {
                    this.Category[i] = copy.Value.Iid;
                    hasChanges = true;
                }
            }

            var copyDefaultScale = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.DefaultScale);
            if (copyDefaultScale.Key != null)
            {
                this.DefaultScale = copyDefaultScale.Value.Iid;
                hasChanges = true;
            }

            for (var i = 0; i < this.PossibleScale.Count; i++)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.PossibleScale[i]);
                if (copy.Key != null)
                {
                    this.PossibleScale[i] = copy.Value.Iid;
                    hasChanges = true;
                }
            }

            return hasChanges;
        }
    }
}
