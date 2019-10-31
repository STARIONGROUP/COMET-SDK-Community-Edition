// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSet.cs" company="RHEA System S.A.">
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
    /// representation of the switch setting and all values for a ParameterOverride
    /// </summary>
    [Container(typeof(ParameterOverride), "ValueSet")]
    public sealed partial class ParameterOverrideValueSet : ParameterValueSetBase
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
        /// Initializes a new instance of the <see cref="ParameterOverrideValueSet"/> class.
        /// </summary>
        public ParameterOverrideValueSet()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterOverrideValueSet"/> class.
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
        public ParameterOverrideValueSet(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ActualOption.
        /// </summary>
        /// <remarks>
        /// reference to the actual Option to which this ParameterOverrideValueSet pertains, derived from the associated ParameterValueSet for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualOption property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override Option ActualOption
        {
            get { return this.GetDerivedActualOption(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverrideValueSet.ActualOption"); }
        }

        /// <summary>
        /// Gets or sets the ActualState.
        /// </summary>
        /// <remarks>
        /// reference to the ActualFiniteState to which this ParameterOverrideValueSet pertains, derived from the associated ParameterValueSet for convenience
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ActualState property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public override ActualFiniteState ActualState
        {
            get { return this.GetDerivedActualState(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterOverrideValueSet.ActualState"); }
        }

        /// <summary>
        /// Gets or sets the ParameterValueSet.
        /// </summary>
        /// <remarks>
        /// reference to the ParameterValueSet that this ParameterOverrideValueSet overrides
        /// Note: The <i>parameter</i> must be the same as the <i>container</i> of the referenced ParameterValueSet.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterValueSet ParameterValueSet { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterOverrideValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterOverrideValueSet"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ParameterOverrideValueSet)this.MemberwiseClone();
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
        /// Creates and returns a copy of this <see cref="ParameterOverrideValueSet"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterOverrideValueSet"/>.
        /// </returns>
        public new ParameterOverrideValueSet Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterOverrideValueSet)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterOverrideValueSet"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.ParameterValueSet == null || this.ParameterValueSet.Iid == Guid.Empty)
            {
                errorList.Add("The property ParameterValueSet is null.");
                this.ParameterValueSet = SentinelThingProvider.GetSentinel<ParameterValueSet>();
                this.sentinelResetMap["ParameterValueSet"] = () => this.ParameterValueSet = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ParameterOverrideValueSet"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ParameterOverrideValueSet;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ParameterOverrideValueSet POCO.", dtoThing.GetType()));
            }

            this.Computed = new ValueArray<string>(dto.Computed, this);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.Formula = new ValueArray<string>(dto.Formula, this);
            this.Manual = new ValueArray<string>(dto.Manual, this);
            this.ModifiedOn = dto.ModifiedOn;
            this.ParameterValueSet = this.Cache.Get<ParameterValueSet>(dto.ParameterValueSet, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterValueSet>();
            this.Published = new ValueArray<string>(dto.Published, this);
            this.Reference = new ValueArray<string>(dto.Reference, this);
            this.RevisionNumber = dto.RevisionNumber;
            this.ValueSwitch = dto.ValueSwitch;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ParameterOverrideValueSet"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ParameterOverrideValueSet(this.Iid, this.RevisionNumber);

            dto.Computed = new ValueArray<string>(this.Computed, this);
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.Formula = new ValueArray<string>(this.Formula, this);
            dto.Manual = new ValueArray<string>(this.Manual, this);
            dto.ModifiedOn = this.ModifiedOn;
            dto.ParameterValueSet = this.ParameterValueSet != null ? this.ParameterValueSet.Iid : Guid.Empty;
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
