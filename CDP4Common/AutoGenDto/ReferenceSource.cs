// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSource.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ReferenceSource"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "ReferenceSource")]
    public sealed partial class ReferenceSource : DefinedThing, ICategorizableThing, IDeprecatableThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceSource"/> class.
        /// </summary>
        public ReferenceSource()
        {
            this.Category = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceSource"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public ReferenceSource(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Category = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced Category instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the Language.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the PublicationYear.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public int? PublicationYear { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced PublishedIn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? PublishedIn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Publisher.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? Publisher { get; set; }

        /// <summary>
        /// Gets or sets the VersionDate.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public DateTime? VersionDate { get; set; }

        /// <summary>
        /// Gets or sets the VersionIdentifier.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string VersionIdentifier { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ReferenceSource"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.ReferenceSource"/> from a <see cref="ReferenceSource"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.ReferenceSource"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.ReferenceSource(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as ReferenceSource;
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

            this.Author = original.Author;

            foreach (var guid in original.Category)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.Category.Add(copy.Value == null ? guid : copy.Value.Iid);
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

            this.Language = original.Language;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            this.PublicationYear = original.PublicationYear;

            var copyPublishedIn = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.PublishedIn);
            this.PublishedIn = copyPublishedIn.Value == null ? original.PublishedIn : copyPublishedIn.Value.Iid;

            var copyPublisher = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Publisher);
            this.Publisher = copyPublisher.Value == null ? original.Publisher : copyPublisher.Value.Iid;

            this.ShortName = original.ShortName;

            this.ThingPreference = original.ThingPreference;

            this.VersionDate = original.VersionDate;

            this.VersionIdentifier = original.VersionIdentifier;
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

            var copyPublishedIn = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.PublishedIn);
            if (copyPublishedIn.Key != null)
            {
                this.PublishedIn = copyPublishedIn.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
