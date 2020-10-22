// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Publication.cs" company="RHEA System S.A.">
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
    /// representation of a saved state within an Iteration where all <i>computed</i> values of the ParameterValueSets of a selected set of Parameters and ParameterOverrides are published to (i.e. copied to) the <i>published</i> values
    /// Note: The purpose of publishing Publications is to isolate all Participants that hold a ParameterSubscription on a particular Parameter or ParameterOverride from continuous (and potential disruptive) changes to the <i>computed</i> values of those ParameterSubscriptions. The <i>computed</i> values in the ParameterSubscriptionValueSets of ParameterSubscriptions are updated to the latest <i>actualValue</i> in the ParameterValueSets of the corresponding Parameter or ParameterOverride only at the point in time when a Publication takes place. This mechanism allows the owners, i.e. Participant(s) representing the owner DomainOfExpertise, of Parameters and ParameterOverrides to freely experiment with their parameter values without disrupting the other Participants.
    /// </summary>
    [Container(typeof(Iteration), "Publication")]
    public sealed partial class Publication : Thing, ITimeStampedThing
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
        /// Initializes a new instance of the <see cref="Publication"/> class.
        /// </summary>
        public Publication()
        {
            this.Domain = new List<DomainOfExpertise>();
            this.PublishedParameter = new List<ParameterOrOverrideBase>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Publication"/> class.
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
        public Publication(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Domain = new List<DomainOfExpertise>();
            this.PublishedParameter = new List<ParameterOrOverrideBase>();
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
        /// Gets or sets a list of DomainOfExpertise.
        /// </summary>
        /// <remarks>
        /// references to the domain(s) of expertise that are the owner(s) of one or more <i>publishedParameter</i>
        /// Note: When a client is sending data to the server, the presence of a DomainOfExpertise in the set signifies a request to publish all Parameters and ParameterOverrides owned by that DomainOfExpertise. Upon receipt of the result of the actual publication transaction from the server, <i>domain</i> will contain the set of actual DomainOfExpertise that had at least one ParameterValueSet of an owned Parameter or ParameterOverride published.
        /// Note 2: The server will process the union of Parameters and ParameterOverrides as requested through the <i>domain </i>and <i>publishedParameter</i> properties.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<DomainOfExpertise> Domain { get; set; }

        /// <summary>
        /// Gets or sets a list of ParameterOrOverrideBase.
        /// </summary>
        /// <remarks>
        /// references to the Parameters and ParameterOverrides published in this Publication
        /// Note 1: When a client is sending data to the server, the presence of a Parameter or ParameterOverride in the set signifies a request to publish that Parameter or ParameterOverride. Upon receipt of the result of the actual publication transaction from the server, <i>publishedParameter</i> will contain the set of actual Parameters and ParameterOverrides that had at least one ParameterValueSet published.
        /// Note 2: The server will process the union of Parameters and ParameterOverrides as requested through the <i>domain </i>and <i>publishedParameter</i> properties.
        /// Note 3: The server will only publish Parameters and ParameterOverrides that have at least one ParameterValueSet where the <i>actualValue</i> differs from the <i>published</i> value.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<ParameterOrOverrideBase> PublishedParameter { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Publication"/>
        /// </summary>
        /// <remarks>
        /// this does not include the contained <see cref="Thing"/>s, the contained <see cref="Thing"/>s
        /// are exposed via the <see cref="ContainerLists"/> method
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

            foreach (var thing in this.PublishedParameter)
            {
                yield return thing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Publication"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Publication"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Publication)this.MemberwiseClone();
            clone.Domain = new List<DomainOfExpertise>(this.Domain);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.PublishedParameter = new List<ParameterOrOverrideBase>(this.PublishedParameter);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Publication"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Publication"/>.
        /// </returns>
        public new Publication Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Publication)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Publication"/>.
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
        /// Resolve the properties of the current <see cref="Publication"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Publication;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current Publication POCO.", dtoThing.GetType()));
            }

            this.CreatedOn = dto.CreatedOn;
            this.Domain.ResolveList(dto.Domain, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.PublishedParameter.ResolveList(dto.PublishedParameter, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Publication"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Publication(this.Iid, this.RevisionNumber);

            dto.CreatedOn = this.CreatedOn;
            dto.Domain.AddRange(this.Domain.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.PublishedParameter.AddRange(this.PublishedParameter.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
