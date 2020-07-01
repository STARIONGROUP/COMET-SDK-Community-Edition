// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevision.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    /// representation of a persisted revision of a File
    /// Note 1: The <i>name</i> property is used to denote the name of the FileRevision and therefore of the File, without any file type extension. So for a Microsoft Windows file the name contains the characters up to (but not including) the dot that separates the file name from the extension. The file type extension is stored in the associated FileType. Case is preserved in the file name.
    /// Note 2: The representation of the actual file content of a FileRevision depends on the implementation technology and is not modeled as an explicit property. It may differ between server and client applications. A server application (e.g. a combination of a web services processor and a persistent data store) may store the content partitioned into chunks for reasons of efficiency. A client application may implement an API that provides access to an instance of a retrieved file in a locally accessible file system. There is a FileContentType data type that can be used in code generation or implementation.
    /// </summary>
    [Container(typeof(File), "FileRevision")]
    public sealed partial class FileRevision : Thing, INamedThing, ITimeStampedThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRevision"/> class.
        /// </summary>
        public FileRevision()
        {
            this.FileType = new OrderedItemList<FileType>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileRevision"/> class.
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
        public FileRevision(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.FileType = new OrderedItemList<FileType>(this);
        }

        /// <summary>
        /// Gets or sets the ContainingFolder.
        /// </summary>
        /// <remarks>
        /// optional reference to the containing Folder
        /// Note: If the reference is undefined (or null) the File and FileRevision are considered to be contained by the containing FileStore at the top level.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Folder ContainingFolder { get; set; }

        /// <summary>
        /// Gets or sets the ContentHash.
        /// </summary>
        /// <remarks>
        /// SHA-1 hash code of the content (byte stream) of this FileRevision
        /// Note: The SHA-1 cryptographic hash is described in <a href="http://en.wikipedia.org/wiki/SHA-1">http://en.wikipedia.org/wiki/SHA-1</a>. It provides a unique hash to the file content of the FileRevision and was selected for future compatibility with a GIT (<a href="http://git-scm.com/">http://git-scm.com/</a>) version controlled file store. Implementations of E-TM-10-25 need to provide a way to associate a SHA-1 hash to the content of a file. Whether or not the content of two FileRevisions differs can then be determined by just comparing the SHA-1 hashes without the need for having access to the actual file content itself.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string ContentHash { get; set; }

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
        /// Gets or sets the Creator.
        /// </summary>
        /// <remarks>
        /// reference to the Participant who created this FileRevision
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Participant Creator { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered FileType.
        /// </summary>
        /// <remarks>
        /// reference to one or more FileTypes that define the type and format of this FileRevision
        /// Note: A file can have more than one FileType in order to support possible encryption and compression formats. The order in which the FileTypes are defined is the same as the order the formats were applied from the "inside out", i.e. the first FileType is the normal format of the content, e.g. text or Microsoft Excel, and the subsequent formats are the encryption and/or compression formats, e.g. public-key cryptography standard <a href="http://en.wikipedia.org/wiki/PKCS">PKCS#7</a> and zip.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<FileType> FileType { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// human readable character string in English by which something can be       referred       to
        /// Note: The implied LanguageCode of <i>name</i> is "en-GB".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Path.
        /// </summary>
        /// <remarks>
        /// full path name including folder path and type extension(s)
        /// Note: The path is derived to be the concatenation of the path of the containingFolder (if any) followed by a forward slash and the name of this FileRevision and then a dot separated concatenation of the extensions of the associated FileTypes. This yields a path that is similar to that of a "file://" URL starting from the containing FileStore.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Path property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string Path
        {
            get { return this.GetDerivedPath(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property FileRevision.Path"); }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="FileRevision"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="FileRevision"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (FileRevision)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.FileType = new OrderedItemList<FileType>(this.FileType, this);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="FileRevision"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="FileRevision"/>.
        /// </returns>
        public new FileRevision Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (FileRevision)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="FileRevision"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.ContentHash))
            {
                errorList.Add("The property ContentHash is null or empty.");
            }

            if (this.Creator == null || this.Creator.Iid == Guid.Empty)
            {
                errorList.Add("The property Creator is null.");
                this.Creator = SentinelThingProvider.GetSentinel<Participant>();
                this.sentinelResetMap["Creator"] = () => this.Creator = null;
            }

            var fileTypeCount = this.FileType.Count();
            if (fileTypeCount < 1)
            {
                errorList.Add("The number of elements in the property FileType is wrong. It should be at least 1.");
            }

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errorList.Add("The property Name is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="FileRevision"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.FileRevision;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current FileRevision POCO.", dtoThing.GetType()));
            }

            this.ContainingFolder = (dto.ContainingFolder.HasValue) ? this.Cache.Get<Folder>(dto.ContainingFolder.Value, dto.IterationContainerId) : null;
            this.ContentHash = dto.ContentHash;
            this.CreatedOn = dto.CreatedOn;
            this.Creator = this.Cache.Get<Participant>(dto.Creator, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Participant>();
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.FileType.ResolveList(dto.FileType, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RevisionNumber = dto.RevisionNumber;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="FileRevision"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.FileRevision(this.Iid, this.RevisionNumber);

            dto.ContainingFolder = this.ContainingFolder != null ? (Guid?)this.ContainingFolder.Iid : null;
            dto.ContentHash = this.ContentHash;
            dto.CreatedOn = this.CreatedOn;
            dto.Creator = this.Creator != null ? this.Creator.Iid : Guid.Empty;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.FileType.AddRange(this.FileType.ToDtoOrderedItemList());
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.RevisionNumber = this.RevisionNumber;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
