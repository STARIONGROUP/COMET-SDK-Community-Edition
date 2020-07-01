// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSet.cs" company="RHEA System S.A.">
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
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// representation of the switch setting and all values for a Parameter
    /// </summary>
    [Container(typeof(Parameter), "ValueSet")]
    public sealed partial class ParameterValueSet : ParameterValueSetBase
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
        /// Initializes a new instance of the <see cref="ParameterValueSet"/> class.
        /// </summary>
        public ParameterValueSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValueSet"/> class.
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
        public ParameterValueSet(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterValueSet"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ParameterValueSet)this.MemberwiseClone();
            clone.Computed = new ValueArray<string>(this.Computed, this);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.Formula = new ValueArray<string>(this.Formula, this);
            clone.Manual = new ValueArray<string>(this.Manual, this);
            clone.Published = new ValueArray<string>(this.Published, this);
            clone.Reference = new ValueArray<string>(this.Reference, this);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterValueSet"/>.
        /// </returns>
        public new ParameterValueSet Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterValueSet)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterValueSet"/>.
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
        /// Resolve the properties of the current <see cref="ParameterValueSet"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ParameterValueSet;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ParameterValueSet POCO.", dtoThing.GetType()));
            }

            this.ActualOption = (dto.ActualOption.HasValue) ? this.Cache.Get<Option>(dto.ActualOption.Value, dto.IterationContainerId) : null;
            this.ActualState = (dto.ActualState.HasValue) ? this.Cache.Get<ActualFiniteState>(dto.ActualState.Value, dto.IterationContainerId) : null;
            this.Computed = new ValueArray<string>(dto.Computed, this);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.Formula = new ValueArray<string>(dto.Formula, this);
            this.Manual = new ValueArray<string>(dto.Manual, this);
            this.ModifiedOn = dto.ModifiedOn;
            this.Published = new ValueArray<string>(dto.Published, this);
            this.Reference = new ValueArray<string>(dto.Reference, this);
            this.RevisionNumber = dto.RevisionNumber;
            this.ValueSwitch = dto.ValueSwitch;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ParameterValueSet"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ParameterValueSet(this.Iid, this.RevisionNumber);

            dto.ActualOption = this.ActualOption != null ? (Guid?)this.ActualOption.Iid : null;
            dto.ActualState = this.ActualState != null ? (Guid?)this.ActualState.Iid : null;
            dto.Computed = new ValueArray<string>(this.Computed, this);
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.Formula = new ValueArray<string>(this.Formula, this);
            dto.Manual = new ValueArray<string>(this.Manual, this);
            dto.ModifiedOn = this.ModifiedOn;
            dto.Published = new ValueArray<string>(this.Published, this);
            dto.Reference = new ValueArray<string>(this.Reference, this);
            dto.RevisionNumber = this.RevisionNumber;
            dto.ValueSwitch = this.ValueSwitch;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
