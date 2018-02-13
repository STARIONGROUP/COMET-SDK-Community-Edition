#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSource.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of an information source that can be referenced
    /// Note 1: The <i>name</i> property should be used to provide a descriptive human readable name of this ReferenceSource, e.g. the title of a book, a standard or an article. The <i>shortName</i> property should be used to provide a concise human readable identifier of this ReferenceSource, e.g. a standard identification code, an abbreviated reference such as in a paper or report.
    /// Note 2: A description of the information source may be given in the <i>content</i> property of an associated Definition. Alternative names may be given in associated Aliases. On-line references may be given in associated HyperLinks.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "ReferenceSource")]
    public sealed partial class ReferenceSource : DefinedThing, ICategorizableThing, IDeprecatableThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceSource"/> class.
        /// </summary>
        public ReferenceSource()
        {
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceSource"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public ReferenceSource(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// optional specification of the author or authors of this ReferenceSource
        /// Note: If there are multiple authors, the author names should be separated by commas.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets a list of Category.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Categories of which this CategorizableThing is a member
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Category> Category { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets the Language.
        /// </summary>
        /// <remarks>
        /// optional specification of the natural language code that this     ReferenceSource     is     written     in
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the PublicationYear.
        /// </summary>
        /// <remarks>
        /// optional year of publication of this ReferenceSource
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public int? PublicationYear { get; set; }

        /// <summary>
        /// Gets or sets the PublishedIn.
        /// </summary>
        /// <remarks>
        /// optional reference to another ReferenceSource than this ReferenceSource,     in     which     this     ReferenceSource     is     published
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ReferenceSource PublishedIn { get; set; }

        /// <summary>
        /// Gets or sets the Publisher.
        /// </summary>
        /// <remarks>
        /// optional reference to the Organization that is the publisher of this     ReferenceSource
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Organization Publisher { get; set; }

        /// <summary>
        /// Gets or sets the VersionDate.
        /// </summary>
        /// <remarks>
        /// optional date of release of this version of this ReferenceSource
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public DateTime? VersionDate { get; set; }

        /// <summary>
        /// Gets or sets the VersionIdentifier.
        /// </summary>
        /// <remarks>
        /// optional identifier denoting the version of this ReferenceSource
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string VersionIdentifier { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ReferenceSource"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ReferenceSource"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ReferenceSource)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ReferenceSource"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ReferenceSource"/>.
        /// </returns>
        public new ReferenceSource Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ReferenceSource)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ReferenceSource"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ReferenceSource"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ReferenceSource;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ReferenceSource POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Author = dto.Author;
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsDeprecated = dto.IsDeprecated;
            this.Language = dto.Language;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.PublicationYear = dto.PublicationYear;
            this.PublishedIn = (dto.PublishedIn.HasValue) ? this.Cache.Get<ReferenceSource>(dto.PublishedIn.Value, dto.IterationContainerId) : null;
            this.Publisher = (dto.Publisher.HasValue) ? this.Cache.Get<Organization>(dto.Publisher.Value, dto.IterationContainerId) : null;
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.VersionDate = dto.VersionDate;
            this.VersionIdentifier = dto.VersionIdentifier;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ReferenceSource"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ReferenceSource(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Author = this.Author;
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsDeprecated = this.IsDeprecated;
            dto.Language = this.Language;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.PublicationYear = this.PublicationYear;
            dto.PublishedIn = this.PublishedIn != null ? (Guid?)this.PublishedIn.Iid : null;
            dto.Publisher = this.Publisher != null ? (Guid?)this.Publisher.Iid : null;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.VersionDate = this.VersionDate;
            dto.VersionIdentifier = this.VersionIdentifier;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
