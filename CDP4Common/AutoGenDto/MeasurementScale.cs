// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeasurementScale.cs" company="RHEA System S.A.">
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
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="MeasurementScale"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public abstract partial class MeasurementScale : DefinedThing, IDeprecatableThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementScale"/> class.
        /// </summary>
        protected MeasurementScale()
        {
            this.MappingToReferenceScale = new List<Guid>();
            this.ValueDefinition = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementScale"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected MeasurementScale(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.MappingToReferenceScale = new List<Guid>();
            this.ValueDefinition = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsMaximumInclusive.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsMaximumInclusive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsMinimumInclusive.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsMinimumInclusive { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained MappingToReferenceScale instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> MappingToReferenceScale { get; set; }

        /// <summary>
        /// Gets or sets the MaximumPermissibleValue.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string MaximumPermissibleValue { get; set; }

        /// <summary>
        /// Gets or sets the MinimumPermissibleValue.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string MinimumPermissibleValue { get; set; }

        /// <summary>
        /// Gets or sets the NegativeValueConnotation.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string NegativeValueConnotation { get; set; }

        /// <summary>
        /// Gets or sets the NumberSet.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual NumberSetKind NumberSet { get; set; }

        /// <summary>
        /// Gets or sets the PositiveValueConnotation.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual string PositiveValueConnotation { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Unit.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid Unit { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ValueDefinition instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ValueDefinition { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="MeasurementScale"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="MeasurementScale"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.MappingToReferenceScale);
                containers.Add(this.ValueDefinition);
                return containers;
            }
        }
    }
}
