// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationSetup.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.SiteDirectoryData
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
    /// representation of the set-up information of an Iteration in the EngineeringModel associated with the EngineeringModelSetup that contains this IterationInfo
    /// Note 1: An iteration is a version of the associated EngineeringModel that was considered as one complete and coherent step in the development of the EngineeringModel in a concurrent engineering activity. The detailed definition and understanding of the meaning of a "complete and coherent" step depends on the organization and activity that develops the EngineeringModel.
    /// Note 2: In a concurrent engineering activity the engineering model for the system-of-interest is developed in a number of iterations, where in each iteration the problem specification in the form of the RequirementsSpecification and a design solution in the form of the Options and ElementDefinitions are elaborated and refined. With an iteration the engineering team strives to set one more step in the direction of achieving a converged definition that fulfills the objectives of their activity.
    /// </summary>
    [Container(typeof(EngineeringModelSetup), "IterationSetup")]
    public partial class IterationSetup : Thing, IParticipantAffectedAccessThing, ITimeStampedThing
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
        /// Initializes a new instance of the <see cref="IterationSetup"/> class.
        /// </summary>
        public IterationSetup()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IterationSetup"/> class.
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
        public IterationSetup(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

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
        /// Gets or sets the Description.
        /// </summary>
        /// <remarks>
        /// human readable description of the Iteration
        /// Note: The description should contain information that permits users to quickly select an Iteration that they are searching for.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the FrozenOn.
        /// </summary>
        /// <remarks>
        /// optional definition of the date and time when this Iteration was frozen, i.e. saved with the intention not to be modified thereafter
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public DateTime? FrozenOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeleted.
        /// </summary>
        /// <remarks>
        /// assertion whether the contents of this iteration have been deleted
        /// Note: Deleting the contents of an iteration means removing the Iteration (with <i>iid</i> equal to <i>iterationIid</i>) and all the objects it contains from the persistent data store. This is useful in order to support clean up of obsolete iterations. Of course by deleting all content data that capture the state of the EngineeringModel at the end of the affected Iteration will be lost, only the descriptive data in IterationSetup remains.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the IterationIid.
        /// </summary>
        /// <remarks>
        /// definition of the unique instance identifier of the Iteration in an EngineeringModel to which this IterationSetup pertains
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Guid IterationIid { get; set; }

        /// <summary>
        /// Gets or sets the IterationNumber.
        /// </summary>
        /// <remarks>
        /// number of the Iteration
        /// Note: In an implementation the number shall be assigned by the server. The first IterationSetup / Iteration that is created for an EngineeringModelSetup / EngineeringModel shall be 1. Any subsequent IterationSetup / Iteration shall be assigned the next number in the creation sequence.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public int IterationNumber { get; set; }

        /// <summary>
        /// Gets or sets the SourceIterationSetup.
        /// </summary>
        /// <remarks>
        /// Note 1: For the initial InterationSetup and Interation of an EngineeringModel, i.e. the first Iteration version, <i>sourceIterationSetup</i> is set to <i>null</i>, which means there was no source.
        /// Note 2: The <i>sourceIterationSetup</i> must be kept in sync with the <i>sourceIteration</i> property of EngineeringModel.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public IterationSetup SourceIterationSetup { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="IterationSetup"/>
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

            if (this.SourceIterationSetup != null)
            {
                yield return this.SourceIterationSetup;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="IterationSetup"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IterationSetup"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (IterationSetup)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="IterationSetup"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="IterationSetup"/>.
        /// </returns>
        public new IterationSetup Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (IterationSetup)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="IterationSetup"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Description))
            {
                errorList.Add("The property Description is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="IterationSetup"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.IterationSetup;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current IterationSetup POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.CreatedOn = dto.CreatedOn;
            this.Description = dto.Description;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.FrozenOn = dto.FrozenOn;
            this.IsDeleted = dto.IsDeleted;
            this.IterationIid = dto.IterationIid;
            this.IterationNumber = dto.IterationNumber;
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.SourceIterationSetup = (dto.SourceIterationSetup.HasValue) ? this.Cache.Get<IterationSetup>(dto.SourceIterationSetup.Value, dto.IterationContainerId) : null;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="IterationSetup"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.IterationSetup(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.CreatedOn = this.CreatedOn;
            dto.Description = this.Description;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.FrozenOn = this.FrozenOn;
            dto.IsDeleted = this.IsDeleted;
            dto.IterationIid = this.IterationIid;
            dto.IterationNumber = this.IterationNumber;
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.SourceIterationSetup = this.SourceIterationSetup != null ? (Guid?)this.SourceIterationSetup.Iid : null;
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
