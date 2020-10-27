// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpression.cs" company="RHEA System S.A.">
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
    /// representation of a mathematical equality or inequality defined by a ParameterType that acts as a variable, a relational operator and a value
    /// </summary>
    [Container(typeof(ParametricConstraint), "Expression")]
    public sealed partial class RelationalExpression : BooleanExpression
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
        /// Initializes a new instance of the <see cref="RelationalExpression"/> class.
        /// </summary>
        public RelationalExpression()
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelationalExpression"/> class.
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
        public RelationalExpression(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// specification of the parameter type that defines the free variable in this
        /// ParametricConstraint
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ParameterType ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the RelationalOperator.
        /// </summary>
        /// <remarks>
        /// specification of the relational operator
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public RelationalOperatorKind RelationalOperator { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// reference to the applicable MeasurementScale in case the parameterType is a QuantityKind
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public MeasurementScale Scale { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// specification of the parameter value
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public ValueArray<string> Value { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="RelationalExpression"/>
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

            if (this.ParameterType != null)
            {
                yield return this.ParameterType;
            }

            if (this.Scale != null)
            {
                yield return this.Scale;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="RelationalExpression"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="RelationalExpression"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (RelationalExpression)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.Value = new ValueArray<string>(this.Value, this);

            if (cloneContainedThings)
            {
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="RelationalExpression"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="RelationalExpression"/>.
        /// </returns>
        public new RelationalExpression Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (RelationalExpression)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="RelationalExpression"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.ParameterType == null || this.ParameterType.Iid == Guid.Empty)
            {
                errorList.Add("The property ParameterType is null.");
                this.ParameterType = SentinelThingProvider.GetSentinel<ParameterType>();
                this.sentinelResetMap["ParameterType"] = () => this.ParameterType = null;
            }

            var valueCount = this.Value.Count();
            if (valueCount < 1)
            {
                errorList.Add("The number of elements in the property Value is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="RelationalExpression"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.RelationalExpression;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current RelationalExpression POCO.", dtoThing.GetType()));
            }

            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.ParameterType = this.Cache.Get<ParameterType>(dto.ParameterType, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ParameterType>();
            this.RelationalOperator = dto.RelationalOperator;
            this.RevisionNumber = dto.RevisionNumber;
            this.Scale = (dto.Scale.HasValue) ? this.Cache.Get<MeasurementScale>(dto.Scale.Value, dto.IterationContainerId) : null;
            this.Value = new ValueArray<string>(dto.Value, this);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="RelationalExpression"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.RelationalExpression(this.Iid, this.RevisionNumber);

            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.ParameterType = this.ParameterType != null ? this.ParameterType.Iid : Guid.Empty;
            dto.RelationalOperator = this.RelationalOperator;
            dto.RevisionNumber = this.RevisionNumber;
            dto.Scale = this.Scale != null ? (Guid?)this.Scale.Iid : null;
            dto.Value = new ValueArray<string>(this.Value, this);

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
