// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryDataAnnotation.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(SiteDirectory), "Annotation")]
    public partial class SiteDirectoryDataAnnotation : GenericAnnotation
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NONE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectoryDataAnnotation"/> class.
        /// </summary>
        public SiteDirectoryDataAnnotation()
        {
            this.Discussion = new ContainerList<SiteDirectoryDataDiscussionItem>(this);
            this.RelatedThing = new ContainerList<SiteDirectoryThingReference>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectoryDataAnnotation"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="CacheKey"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public SiteDirectoryDataAnnotation(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Discussion = new ContainerList<SiteDirectoryDataDiscussionItem>(this);
            this.RelatedThing = new ContainerList<SiteDirectoryThingReference>(this);
        }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// The author of the annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Person Author { get; set; }

        /// <summary>
        /// Gets or sets a list of contained SiteDirectoryDataDiscussionItem.
        /// </summary>
        /// <remarks>
        /// The discussion related to this annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SiteDirectoryDataDiscussionItem> Discussion { get; protected set; }

        /// <summary>
        /// Gets or sets the PrimaryAnnotatedThing.
        /// </summary>
        /// <remarks>
        /// The reference of the primary Thing that is being annotated
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public SiteDirectoryThingReference PrimaryAnnotatedThing { get; set; }

        /// <summary>
        /// Gets or sets a list of contained SiteDirectoryThingReference.
        /// </summary>
        /// <remarks>
        /// The reference of the things that are related to this annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SiteDirectoryThingReference> RelatedThing { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="SiteDirectoryDataAnnotation"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Discussion);
                containers.Add(this.RelatedThing);
                return containers;
            }
        }

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();
            dictionary.Add("Author", new [] { this.Author?.Iid ?? Guid.Empty });
            dictionary.Add("Discussion", this.Discussion.Select(x => x.Iid));
            dictionary.Add("ExcludedDomain", this.ExcludedDomain.Select(x => x.Iid));
            dictionary.Add("ExcludedPerson", this.ExcludedPerson.Select(x => x.Iid));
            dictionary.Add("PrimaryAnnotatedThing", new [] { this.PrimaryAnnotatedThing?.Iid ?? Guid.Empty });
            dictionary.Add("RelatedThing", this.RelatedThing.Select(x => x.Iid));

            return dictionary;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to any of the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to search for.</param>
        /// <returns>True is any of the id's in <paramref name="ids"/> is found in this instance's reference properties.</returns>
        public override bool HasMandatoryReferenceToAny(IEnumerable<Guid> ids)
        {
            var result = false;

            if (!ids.Any())
            {
                return false;
            }

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Author":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;

                    case "PrimaryAnnotatedThing":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to an id that cannot be found in the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The HashSet of Guids to search for.</param>
        /// <returns>True is the id in this instance's mandatory reference properties is not found in in <paramref name="ids"/>.</returns>
        public override bool HasMandatoryReferenceNotIn(HashSet<Guid> ids)
        {
            var result = false;

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Author":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;

                    case "PrimaryAnnotatedThing":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="SiteDirectoryDataAnnotation"/>
        /// </summary>
        /// <remarks>
        /// This does not include the contained <see cref="Thing"/>s, the contained <see cref="Thing"/>s
        /// are exposed via the <see cref="ContainerLists"/> property
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerable{Thing}"/>
        /// </returns>
        public override IEnumerable<Thing> QueryReferencedThings()
        {
            foreach (var thing in base.QueryReferencedThings())
            {
                yield return thing;
            }

            if (this.Author != null)
            {
                yield return this.Author;
            }

            if (this.PrimaryAnnotatedThing != null)
            {
                yield return this.PrimaryAnnotatedThing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteDirectoryDataAnnotation"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteDirectoryDataAnnotation"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (SiteDirectoryDataAnnotation)this.MemberwiseClone();
            clone.Discussion = cloneContainedThings ? new ContainerList<SiteDirectoryDataDiscussionItem>(clone) : new ContainerList<SiteDirectoryDataDiscussionItem>(this.Discussion, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.RelatedThing = cloneContainedThings ? new ContainerList<SiteDirectoryThingReference>(clone) : new ContainerList<SiteDirectoryThingReference>(this.RelatedThing, clone);

            if (cloneContainedThings)
            {
                clone.Discussion.AddRange(this.Discussion.Select(x => x.Clone(true)));
                clone.RelatedThing.AddRange(this.RelatedThing.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="SiteDirectoryDataAnnotation"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="SiteDirectoryDataAnnotation"/>.
        /// </returns>
        public new SiteDirectoryDataAnnotation Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (SiteDirectoryDataAnnotation)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="SiteDirectoryDataAnnotation"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Author == null || this.Author.Iid == Guid.Empty)
            {
                errorList.Add("The property Author is null.");
                this.Author = SentinelThingProvider.GetSentinel<Person>();
                this.sentinelResetMap["Author"] = () => this.Author = null;
            }

            if (this.PrimaryAnnotatedThing == null || this.PrimaryAnnotatedThing.Iid == Guid.Empty)
            {
                errorList.Add("The property PrimaryAnnotatedThing is null.");
                this.PrimaryAnnotatedThing = SentinelThingProvider.GetSentinel<SiteDirectoryThingReference>();
                this.sentinelResetMap["PrimaryAnnotatedThing"] = () => this.PrimaryAnnotatedThing = null;
            }

            var relatedThingCount = this.RelatedThing.Count();
            if (relatedThingCount < 1)
            {
                errorList.Add("The number of elements in the property RelatedThing is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="SiteDirectoryDataAnnotation"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.SiteDirectoryDataAnnotation;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current SiteDirectoryDataAnnotation POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.Author = this.Cache.Get<Person>(dto.Author, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Person>();
            this.Content = dto.Content;
            this.CreatedOn = dto.CreatedOn;
            this.Discussion.ResolveList(dto.Discussion, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LanguageCode = dto.LanguageCode;
            this.ModifiedOn = dto.ModifiedOn;
            this.PrimaryAnnotatedThing = this.Cache.Get<SiteDirectoryThingReference>(dto.PrimaryAnnotatedThing, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<SiteDirectoryThingReference>();
            this.RelatedThing.ResolveList(dto.RelatedThing, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="SiteDirectoryDataAnnotation"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.SiteDirectoryDataAnnotation(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.Author = this.Author != null ? this.Author.Iid : Guid.Empty;
            dto.Content = this.Content;
            dto.CreatedOn = this.CreatedOn;
            dto.Discussion.AddRange(this.Discussion.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LanguageCode = this.LanguageCode;
            dto.ModifiedOn = this.ModifiedOn;
            dto.PrimaryAnnotatedThing = this.PrimaryAnnotatedThing != null ? this.PrimaryAnnotatedThing.Iid : Guid.Empty;
            dto.RelatedThing.AddRange(this.RelatedThing.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
