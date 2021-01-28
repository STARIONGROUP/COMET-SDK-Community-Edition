// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Participant.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Authors: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov, Smiechowski Nathanael
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
    /// representation of a participant in the team working in a concurrent engineering activity on an EngineeringModel
    /// </summary>
    [Container(typeof(EngineeringModelSetup), "Participant")]
    public sealed partial class Participant : Thing, IParticipantAffectedAccessThing
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
        /// Initializes a new instance of the <see cref="Participant"/> class.
        /// </summary>
        public Participant()
        {
            this.Domain = new List<DomainOfExpertise>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Participant"/> class.
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
        public Participant(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Domain = new List<DomainOfExpertise>();
        }

        /// <summary>
        /// Gets or sets a list of DomainOfExpertise.
        /// </summary>
        /// <remarks>
        /// references to the domains of expertise (set of DomainOfExpertise) that this Participant may represent
        /// Note: At any moment in a session in an E-TM-10-25 compliant environment a Participant is actively representing one DomainOfExpertise only, see the <i>selectedDomain</i> property. If more than one DomainOfExpertise is specified, he or she may select any of those DomainOfExpertises to switch to, at any time during the session.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<DomainOfExpertise> Domain { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        /// <remarks>
        /// assertion whether this Participant is active in the current
        /// EngineeringModel
        /// Note: This allows to set Participants that already started as member of a
        /// concurrent engineering team in an inactive role. Once created a
        /// Participant cannot be deleted without precautions because this may render
        /// earlier created data incomplete.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Person.
        /// </summary>
        /// <remarks>
        /// reference to the Person that is this Participant
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Person Person { get; set; }

        /// <summary>
        /// Gets or sets the Role.
        /// </summary>
        /// <remarks>
        /// reference to the ParticipantRole assigned to this Participant
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParticipantRole Role { get; set; }

        /// <summary>
        /// Gets or sets the SelectedDomain.
        /// </summary>
        /// <remarks>
        /// active DomainOfExpertise selected by this Participant
        /// Note: The selectedDomain must be one from the set of DomainOfExpertise specified in the <i>domain</i> property of this Participant.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public DomainOfExpertise SelectedDomain { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Participant"/>
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

            foreach (var thing in this.Domain)
            {
                yield return thing;
            }

            if (this.Person != null)
            {
                yield return this.Person;
            }

            if (this.Role != null)
            {
                yield return this.Role;
            }

            if (this.SelectedDomain != null)
            {
                yield return this.SelectedDomain;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Participant"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Participant"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Participant)this.MemberwiseClone();
            clone.Domain = new List<DomainOfExpertise>(this.Domain);
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
        /// Creates and returns a copy of this <see cref="Participant"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Participant"/>.
        /// </returns>
        public new Participant Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Participant)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Participant"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var domainCount = this.Domain.Count();
            if (domainCount < 1)
            {
                errorList.Add("The number of elements in the property Domain is wrong. It should be at least 1.");
            }

            if (this.Person == null || this.Person.Iid == Guid.Empty)
            {
                errorList.Add("The property Person is null.");
                this.Person = SentinelThingProvider.GetSentinel<Person>();
                this.sentinelResetMap["Person"] = () => this.Person = null;
            }

            if (this.Role == null || this.Role.Iid == Guid.Empty)
            {
                errorList.Add("The property Role is null.");
                this.Role = SentinelThingProvider.GetSentinel<ParticipantRole>();
                this.sentinelResetMap["Role"] = () => this.Role = null;
            }

            if (this.SelectedDomain == null || this.SelectedDomain.Iid == Guid.Empty)
            {
                errorList.Add("The property SelectedDomain is null.");
                this.SelectedDomain = SentinelThingProvider.GetSentinel<DomainOfExpertise>();
                this.sentinelResetMap["SelectedDomain"] = () => this.SelectedDomain = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="Participant"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Participant;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current Participant POCO.", dtoThing.GetType()));
            }

            this.Domain.ResolveList(dto.Domain, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.IsActive = dto.IsActive;
            this.ModifiedOn = dto.ModifiedOn;
            this.Person = this.Cache.Get<Person>(dto.Person, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Person>();
            this.RevisionNumber = dto.RevisionNumber;
            this.Role = this.Cache.Get<ParticipantRole>(dto.Role, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParticipantRole>();
            this.SelectedDomain = this.Cache.Get<DomainOfExpertise>(dto.SelectedDomain, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Participant"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Participant(this.Iid, this.RevisionNumber);

            dto.Domain.AddRange(this.Domain.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.IsActive = this.IsActive;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Person = this.Person != null ? this.Person.Iid : Guid.Empty;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Role = this.Role != null ? this.Role.Iid : Guid.Empty;
            dto.SelectedDomain = this.SelectedDomain != null ? this.SelectedDomain.Iid : Guid.Empty;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
