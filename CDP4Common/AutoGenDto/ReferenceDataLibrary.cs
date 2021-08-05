// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="ReferenceDataLibrary"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class ReferenceDataLibrary : DefinedThing, IParticipantAffectedAccessThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
        /// </summary>
        protected ReferenceDataLibrary()
        {
            this.BaseQuantityKind = new List<OrderedItem>();
            this.BaseUnit = new List<Guid>();
            this.Constant = new List<Guid>();
            this.DefinedCategory = new List<Guid>();
            this.FileType = new List<Guid>();
            this.Glossary = new List<Guid>();
            this.ParameterType = new List<Guid>();
            this.ReferenceSource = new List<Guid>();
            this.Rule = new List<Guid>();
            this.Scale = new List<Guid>();
            this.Unit = new List<Guid>();
            this.UnitPrefix = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ReferenceDataLibrary(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.BaseQuantityKind = new List<OrderedItem>();
            this.BaseUnit = new List<Guid>();
            this.Constant = new List<Guid>();
            this.DefinedCategory = new List<Guid>();
            this.FileType = new List<Guid>();
            this.Glossary = new List<Guid>();
            this.ParameterType = new List<Guid>();
            this.ReferenceSource = new List<Guid>();
            this.Rule = new List<Guid>();
            this.Scale = new List<Guid>();
            this.Unit = new List<Guid>();
            this.UnitPrefix = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of ordered unique identifiers of the referenced BaseQuantityKind instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<OrderedItem> BaseQuantityKind { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced BaseUnit instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> BaseUnit { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Constant instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Constant { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DefinedCategory instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> DefinedCategory { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained FileType instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> FileType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Glossary instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Glossary { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ParameterType instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ReferenceSource instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ReferenceSource { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced RequiredRdl.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? RequiredRdl { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Rule instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Rule { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Scale instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Scale { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Unit instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Unit { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained UnitPrefix instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> UnitPrefix { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ReferenceDataLibrary"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Constant);
                containers.Add(this.DefinedCategory);
                containers.Add(this.FileType);
                containers.Add(this.Glossary);
                containers.Add(this.ParameterType);
                containers.Add(this.ReferenceSource);
                containers.Add(this.Rule);
                containers.Add(this.Scale);
                containers.Add(this.Unit);
                containers.Add(this.UnitPrefix);
                return containers;
            }
        }
    }
}
