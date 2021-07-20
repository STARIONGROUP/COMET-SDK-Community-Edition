// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

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
    /// A Data Transfer Object representation of the <see cref="QuantityKind"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public abstract partial class QuantityKind : ScalarParameterType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityKind"/> class.
        /// </summary>
        protected QuantityKind()
        {
            this.PossibleScale = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityKind"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected QuantityKind(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.PossibleScale = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced AllPossibleScale instances.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The AllPossibleScale property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public List<Guid> AllPossibleScale
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property QuantityKind.AllPossibleScale"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.AllPossibleScale"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultScale.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid DefaultScale { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced PossibleScale instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> PossibleScale { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The QuantityDimensionExponent property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public List<OrderedItem> QuantityDimensionExponent
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property QuantityKind.QuantityDimensionExponent"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.QuantityDimensionExponent"); }
        }

        /// <summary>
        /// Gets or sets the QuantityDimensionExpression.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The QuantityDimensionExpression property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public string QuantityDimensionExpression
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property QuantityKind.QuantityDimensionExpression"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.QuantityDimensionExpression"); }
        }

        /// <summary>
        /// Gets or sets the QuantityDimensionSymbol.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string QuantityDimensionSymbol { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="QuantityKind"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
