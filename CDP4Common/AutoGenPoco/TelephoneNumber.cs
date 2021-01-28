// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TelephoneNumber.cs" company="RHEA System S.A.">
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
    /// representation of a telephone number
    /// </summary>
    [Container(typeof(Person), "TelephoneNumber")]
    public sealed partial class TelephoneNumber : Thing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneNumber"/> class.
        /// </summary>
        public TelephoneNumber()
        {
            this.VcardType = new List<VcardTelephoneNumberKind>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TelephoneNumber"/> class.
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
        public TelephoneNumber(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.VcardType = new List<VcardTelephoneNumberKind>();
        }

        /// <summary>
        /// Gets or sets the Value.
        /// </summary>
        /// <remarks>
        /// representation of the actual telephone number of this TelephoneNumber
        /// Note: The value should follow the URI specification for international telephone numbers as defined in <a href="http://datatracker.ietf.org/doc/rfc3966/?include_text=1">IETF RFC 3966</a>. Hyphens may be used to improve human readability.
        /// Example: <i>vcardType</i> = VcardTelephoneNumberKind.WORK, <i>value</i> = "+31-71-5656565".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a list of VcardTelephoneNumberKind.
        /// </summary>
        /// <remarks>
        /// representation of the applicable vCard TYPE values
        /// Note: Zero or more vCard TYPE values can be associated to a single telephone number. See VcardTelephoneNumberKind for details.
        /// Example: VcardTelephoneNumberKind.WORK, VcardTelephoneNumberKind.VOICE, VcardTelephoneNumberKind.TEXT, VcardTelephoneNumberKind.CELL .
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<VcardTelephoneNumberKind> VcardType { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="TelephoneNumber"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="TelephoneNumber"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (TelephoneNumber)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.VcardType = new List<VcardTelephoneNumberKind>(this.VcardType);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="TelephoneNumber"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="TelephoneNumber"/>.
        /// </returns>
        public new TelephoneNumber Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (TelephoneNumber)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="TelephoneNumber"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Value))
            {
                errorList.Add("The property Value is null or empty.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="TelephoneNumber"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.TelephoneNumber;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current TelephoneNumber POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;
            this.Value = dto.Value;
            this.VcardType.ClearAndAddRange(dto.VcardType);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="TelephoneNumber"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.TelephoneNumber(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
            dto.ThingPreference = this.ThingPreference;
            dto.Value = this.Value;
            dto.VcardType.AddRange(this.VcardType);

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
