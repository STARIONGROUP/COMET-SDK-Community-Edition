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

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ConversionBasedUnit"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public abstract partial class ConversionBasedUnit : MeasurementUnit
    {
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
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ConversionBasedUnit(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the ConversionFactor.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string ConversionFactor { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ReferenceUnit.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid ReferenceUnit { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ConversionBasedUnit"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
