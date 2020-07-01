// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataNote.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="EngineeringModelDataNote"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(EngineeringModel), "GenericNote")]
    public sealed partial class EngineeringModelDataNote : EngineeringModelDataAnnotation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataNote"/> class.
        /// </summary>
        public EngineeringModelDataNote()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataNote"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public EngineeringModelDataNote(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets the route for the current <see ref="EngineeringModelDataNote"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.ReportingData.EngineeringModelDataNote"/> from a <see cref="EngineeringModelDataNote"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.ReportingData.EngineeringModelDataNote"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.ReportingData.EngineeringModelDataNote(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as EngineeringModelDataNote;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            var copyAuthor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Author);
            this.Author = copyAuthor.Value == null ? original.Author : copyAuthor.Value.Iid;

            this.Content = original.Content;

            this.CreatedOn = original.CreatedOn;

            foreach (var guid in original.Discussion)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Discussion.Add(copy.Value.Iid);
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

            this.LanguageCode = original.LanguageCode;

            this.ModifiedOn = original.ModifiedOn;

            var copyPrimaryAnnotatedThing = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.PrimaryAnnotatedThing);
            this.PrimaryAnnotatedThing = copyPrimaryAnnotatedThing.Value == null ? original.PrimaryAnnotatedThing : copyPrimaryAnnotatedThing.Value.Iid;

            foreach (var guid in original.RelatedThing)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.RelatedThing.Add(copy.Value.Iid);
            }
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
