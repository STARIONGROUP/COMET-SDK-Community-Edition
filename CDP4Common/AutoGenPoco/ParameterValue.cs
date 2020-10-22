// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValue.cs" company="RHEA System S.A.">
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
    /// Representation of a single parameter with value.
    /// This is a generalization of the simple parameter value concept.
    /// </summary>
    [CDPVersion("1.1.0")]
    public abstract partial class ParameterValue : Thing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValue"/> class.
        /// </summary>
        protected ParameterValue()
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValue"/> class.
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
        protected ParameterValue(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Value = new ValueArray<string>(this);
        }

        /// <summary>
        /// Gets or sets the ParameterType.
        /// </summary>
        /// <remarks>
        /// Reference to the applicable ParameterType
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ParameterType ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the Scale.
        /// </summary>
        /// <remarks>
        /// Reference to the applicable MeasurementScale if the ParameterType is a QuantityKind
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual MeasurementScale Scale { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// The value
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual ValueArray<string> Value { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="ParameterValue"/>
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

            yield return this.ParameterType;

            yield return this.Scale;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ParameterValue"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ParameterValue"/>.
        /// </returns>
        public new ParameterValue Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ParameterValue)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ParameterValue"/>.
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
    }
}
