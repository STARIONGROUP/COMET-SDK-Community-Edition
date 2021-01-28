// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserRuleVerification.cs" company="RHEA System S.A.">
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
    /// representation of the verification of a user-defined Rule in one of the required ReferenceDataLibraries
    /// </summary>
    [Container(typeof(RuleVerificationList), "RuleVerification")]
    public sealed partial class UserRuleVerification : RuleVerification
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRuleVerification"/> class.
        /// </summary>
        public UserRuleVerification()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRuleVerification"/> class.
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
        public UserRuleVerification(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// name derived from the <i>name</i> of the associated Rule
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override string Name
        {
            get { return this.GetDerivedName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property UserRuleVerification.Name"); }
        }

        /// <summary>
        /// Gets or sets the Rule.
        /// </summary>
        /// <remarks>
        /// reference to the Rule to be verified
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Rule Rule { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="UserRuleVerification"/>
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

            if (this.Rule != null)
            {
                yield return this.Rule;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="UserRuleVerification"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="UserRuleVerification"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (UserRuleVerification)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="UserRuleVerification"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="UserRuleVerification"/>.
        /// </returns>
        public new UserRuleVerification Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (UserRuleVerification)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="UserRuleVerification"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Rule == null || this.Rule.Iid == Guid.Empty)
            {
                errorList.Add("The property Rule is null.");
                this.Rule = SentinelThingProvider.GetSentinel<Rule>();
                this.sentinelResetMap["Rule"] = () => this.Rule = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="UserRuleVerification"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.UserRuleVerification;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current UserRuleVerification POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ExecutedOn = dto.ExecutedOn;
            this.IsActive = dto.IsActive;
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.Rule = this.Cache.Get<Rule>(dto.Rule, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<Rule>();
            this.Status = dto.Status;
            this.ThingPreference = dto.ThingPreference;
            this.Violation.ResolveList(dto.Violation, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="UserRuleVerification"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.UserRuleVerification(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ExecutedOn = this.ExecutedOn;
            dto.IsActive = this.IsActive;
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Rule = this.Rule != null ? this.Rule.Iid : Guid.Empty;
            dto.Status = this.Status;
            dto.ThingPreference = this.ThingPreference;
            dto.Violation.AddRange(this.Violation.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
