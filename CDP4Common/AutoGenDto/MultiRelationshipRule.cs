// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRule.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="MultiRelationshipRule"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Rule")]
    public sealed partial class MultiRelationshipRule : Rule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiRelationshipRule"/> class.
        /// </summary>
        public MultiRelationshipRule()
        {
            this.RelatedCategory = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiRelationshipRule"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public MultiRelationshipRule(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.RelatedCategory = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the MaxRelated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public int MaxRelated { get; set; }

        /// <summary>
        /// Gets or sets the MinRelated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public int MinRelated { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced RelatedCategory instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RelatedCategory { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced RelationshipCategory.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid RelationshipCategory { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="MultiRelationshipRule"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.MultiRelationshipRule"/> from a <see cref="MultiRelationshipRule"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.MultiRelationshipRule"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.MultiRelationshipRule(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as MultiRelationshipRule;
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

            this.MaxRelated = original.MaxRelated;

            this.MinRelated = original.MinRelated;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            foreach (var guid in original.RelatedCategory)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.RelatedCategory.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            var copyRelationshipCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.RelationshipCategory);
            this.RelationshipCategory = copyRelationshipCategory.Value == null ? original.RelationshipCategory : copyRelationshipCategory.Value.Iid;

            this.ShortName = original.ShortName;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            for (var i = 0; i < this.RelatedCategory.Count; i++)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.RelatedCategory[i]);
                if (copy.Key != null)
                {
                    this.RelatedCategory[i] = copy.Value.Iid;
                    hasChanges = true;
                }
            }

            var copyRelationshipCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.RelationshipCategory);
            if (copyRelationshipCategory.Key != null)
            {
                this.RelationshipCategory = copyRelationshipCategory.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
