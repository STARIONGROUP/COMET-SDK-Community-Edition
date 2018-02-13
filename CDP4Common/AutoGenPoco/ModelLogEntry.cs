#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelLogEntry.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    /// representation of a logbook entry for an EngineeringModel
    /// </summary>
    [Container(typeof(EngineeringModel), "LogEntry")]
    public sealed partial class ModelLogEntry : Thing, IAnnotation, ICategorizableThing, ILogEntry, ITimeStampedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NONE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelLogEntry"/> class.
        /// </summary>
        public ModelLogEntry()
        {
            this.AffectedItemIid = new List<Guid>();
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelLogEntry"/> class.
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
        public ModelLogEntry(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.AffectedItemIid = new List<Guid>();
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Gets or sets a list of Guid.
        /// </summary>
        /// <remarks>
        /// weak reference to zero or more items that are relevant to or affected by what is described in the content of this LogEntry
        /// Note: Each reference should be an <i>iid</i> of a Thing that exists when the log entry is created. The references are of type Uuid in order to support retaining log entries even when the referenced Thing is later deleted. An implementation of E-TM-10-25 shall support a mechanism to dereference items by Uuid and report when items can not (no longer) be dereferenced.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Guid> AffectedItemIid { get; set; }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// reference to the Person who logged this LogEntry
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Person Author { get; set; }

        /// <summary>
        /// Gets or sets a list of Category.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Categories of which this CategorizableThing is a member
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Category> Category { get; set; }

        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <remarks>
        /// textual content of the annotation expressed in the natural language as
        /// specified in <i>languageCode</i>
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        /// <remarks>
        /// Note 1: This implies that any value shall comply with the following (informative) ISO 8601 format "yyyy-mm-ddThh:mm:ss.sssZ".
        /// Note 2: All persistent date-and-time-stamps in this model shall be stored in UTC. When local calendar dates and clock times in a specific timezone are needed they shall be converted on the fly from and to UTC by client applications.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the LanguageCode.
        /// </summary>
        /// <remarks>
        /// code that defines the natural language in which the annotation is written
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string LanguageCode { get; set; }

        /// <summary>
        /// Gets or sets the Level.
        /// </summary>
        /// <remarks>
        /// level of this LogEntry
        /// Note: The <i>level</i> can be used to filter log entries. Also applications may provide a setting that switches on or off logging log entries of a certain level.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public LogLevelKind Level { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ModelLogEntry"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ModelLogEntry"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ModelLogEntry)this.MemberwiseClone();
            clone.AffectedItemIid = new List<Guid>(this.AffectedItemIid);
            clone.Category = new List<Category>(this.Category);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ModelLogEntry"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ModelLogEntry"/>.
        /// </returns>
        public new ModelLogEntry Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ModelLogEntry)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ModelLogEntry"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Content))
            {
                errorList.Add("The property Content is null or empty.");
            }

            if (string.IsNullOrWhiteSpace(this.LanguageCode))
            {
                errorList.Add("The property LanguageCode is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ModelLogEntry"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ModelLogEntry;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ModelLogEntry POCO.", dtoThing.GetType()));
            }

            this.AffectedItemIid.ClearAndAddRange(dto.AffectedItemIid);
            this.Author = (dto.Author.HasValue) ? this.Cache.Get<Person>(dto.Author.Value, dto.IterationContainerId) : null;
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Content = dto.Content;
            this.CreatedOn = dto.CreatedOn;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.LanguageCode = dto.LanguageCode;
            this.Level = dto.Level;
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ModelLogEntry"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ModelLogEntry(this.Iid, this.RevisionNumber);

            dto.AffectedItemIid.AddRange(this.AffectedItemIid);
            dto.Author = this.Author != null ? (Guid?)this.Author.Iid : null;
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Content = this.Content;
            dto.CreatedOn = this.CreatedOn;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.LanguageCode = this.LanguageCode;
            dto.Level = this.Level;
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;

            dto.IterationContainerId = this.CacheId.Item2;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
