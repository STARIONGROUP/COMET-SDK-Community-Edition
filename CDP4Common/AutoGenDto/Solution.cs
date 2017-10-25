// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Solution.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="Solution"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(ReviewItemDiscrepancy), "Solution")]
    public sealed partial class Solution : GenericAnnotation, IOwnedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> class.
        /// </summary>
        public Solution()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public Solution(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Author.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Author { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Owner { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="Solution"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.ReportingData.Solution"/> from a <see cref="Solution"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.ReportingData.Solution"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.ReportingData.Solution(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as Solution;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            var copyAuthor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Author);
            this.Author = copyAuthor.Value == null ? original.Author : copyAuthor.Value.Iid;

            this.Content = original.Content;

            this.CreatedOn = original.CreatedOn;

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

            this.LanguageCode = original.LanguageCode;

            this.ModifiedOn = original.ModifiedOn;

            var copyOwner = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Owner);
            this.Owner = copyOwner.Value == null ? original.Owner : copyOwner.Value.Iid;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyAuthor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.Author);
            if (copyAuthor.Key != null)
            {
                this.Author = copyAuthor.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
