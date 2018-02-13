#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConversionBasedUnit.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
    /// abstract specialization of MeasurementUnit that represents a measurement unit that is defined with respect to another reference unit through an explicit conversion relation
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public abstract partial class ConversionBasedUnit : MeasurementUnit
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_SUPERCLASS;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionBasedUnit"/> class.
        /// </summary>
        protected ConversionBasedUnit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionBasedUnit"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        protected ConversionBasedUnit(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Gets or sets the ConversionFactor.
        /// </summary>
        /// <remarks>
        /// definition of the conversion factor in the unit conversion relation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string ConversionFactor { get; set; }

        /// <summary>
        /// Gets or sets the ReferenceUnit.
        /// </summary>
        /// <remarks>
        /// reference to the MeasurementUnit with respect to which this ConversionBasedUnit is defined
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual MeasurementUnit ReferenceUnit { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ConversionBasedUnit"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ConversionBasedUnit"/>.
        /// </returns>
        public new ConversionBasedUnit Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ConversionBasedUnit)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ConversionBasedUnit"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.ConversionFactor))
            {
                errorList.Add("The property ConversionFactor is null or empty.");
            }

            if (this.ReferenceUnit == null || this.ReferenceUnit.Iid == Guid.Empty)
            {
                errorList.Add("The property ReferenceUnit is null.");
                this.ReferenceUnit = SentinelThingProvider.GetSentinel<MeasurementUnit>();
                this.sentinelResetMap["ReferenceUnit"] = () => this.ReferenceUnit = null;
            }

            return errorList;
        }
    }
}
