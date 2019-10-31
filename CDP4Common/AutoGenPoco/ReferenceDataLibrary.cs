// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="RHEA System S.A.">
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
    /// named library that holds a set of (predefined) reference data that can be loaded at runtime and used in an EngineeringModel
    /// Note 1: An EngineeringModel may use one or more reference data libraries. Typically there would be 3 levels as follows:
    /// Note 2: One or more ReferenceDataLibraries hold the <i>system of quantities</i> that is defined in <a href="http://www.bipm.org/en/publications/guides/vim.html">VIM</a> as a "set of quantities together with a set of non-contradictory equations relating those quantities" and the system of units defined in <a href="http://www.bipm.org/en/publications/guides/vim.html">VIM</a> as "set of base units and derived units, together with their multiples and submultiples, defined in accordance with given rules, for a given system of quantities". E-TM-10-25 uses as a basis the International System of Quantities (ISQ) and the International System of Units as defined in ISO/IEC 80000. In addition measurement scales are explicitly defined, so that a fully self-described system is captured. Where needed this is extended with non-SI quantities, scales and units with explicit conversion relationships.
    /// Note 3: Instances contained by a ReferenceDataLibrary
    /// may not be deleted because that would potentially invalidate such libraries for earlier EngineeringModels or other ReferenceDataLibraries that reference them. Such instances may only be deprecated, see DeprecatableThing.
    /// </summary>
    public abstract partial class ReferenceDataLibrary : DefinedThing, IParticipantAffectedAccessThing
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
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
        /// </summary>
        protected ReferenceDataLibrary()
        {
            this.BaseQuantityKind = new OrderedItemList<QuantityKind>(this);
            this.BaseUnit = new List<MeasurementUnit>();
            this.Constant = new ContainerList<Constant>(this);
            this.DefinedCategory = new ContainerList<Category>(this);
            this.FileType = new ContainerList<FileType>(this);
            this.Glossary = new ContainerList<Glossary>(this);
            this.ParameterType = new ContainerList<ParameterType>(this);
            this.ReferenceSource = new ContainerList<ReferenceSource>(this);
            this.Rule = new ContainerList<Rule>(this);
            this.Scale = new ContainerList<MeasurementScale>(this);
            this.Unit = new ContainerList<MeasurementUnit>(this);
            this.UnitPrefix = new ContainerList<UnitPrefix>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
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
        protected ReferenceDataLibrary(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.BaseQuantityKind = new OrderedItemList<QuantityKind>(this);
            this.BaseUnit = new List<MeasurementUnit>();
            this.Constant = new ContainerList<Constant>(this);
            this.DefinedCategory = new ContainerList<Category>(this);
            this.FileType = new ContainerList<FileType>(this);
            this.Glossary = new ContainerList<Glossary>(this);
            this.ParameterType = new ContainerList<ParameterType>(this);
            this.ReferenceSource = new ContainerList<ReferenceSource>(this);
            this.Rule = new ContainerList<Rule>(this);
            this.Scale = new ContainerList<MeasurementScale>(this);
            this.Unit = new ContainerList<MeasurementUnit>(this);
            this.UnitPrefix = new ContainerList<UnitPrefix>(this);
        }

        /// <summary>
        /// Gets or sets a list of ordered QuantityKind.
        /// </summary>
        /// <remarks>
        /// collection of references to the QuantityKinds that are selected as a basis of the system of quantities defined in this ReferenceDataLibrary
        /// Note 1: This is a subset of the complete set of QuantityKinds. The base quantities define the basis for the quantity dimension of a kind of quantity.
        /// Note 2: If a QuantityKind is in this collection and thus a base QuantityKind, then this base QuantityKind is considered to be primary kind of quantity for the MeasurementUnit of the <i>defaultScale</i> MeasurementScale.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public virtual OrderedItemList<QuantityKind> BaseQuantityKind { get; set; }

        /// <summary>
        /// Gets or sets a list of MeasurementUnit.
        /// </summary>
        /// <remarks>
        /// specification of the base MeasurementUnits for the system of units
        /// defined in this ReferenceDataLibrary
        /// Note: A "base unit" is defined in [VIM] as a "measurement unit that is
        /// adopted by convention for a base quantity", i.e. it is the (preferred)
        /// unit in which base quantities of the associated system of quantities are
        /// expressed.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual List<MeasurementUnit> BaseUnit { get; set; }

        /// <summary>
        /// Gets or sets a list of contained Constant.
        /// </summary>
        /// <remarks>
        /// contained collection of Constants
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<Constant> Constant { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Category.
        /// </summary>
        /// <remarks>
        /// collection of defined, i.e. known, Categories
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<Category> DefinedCategory { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained FileType.
        /// </summary>
        /// <remarks>
        /// collection of defined, i.e. known, FileTypes
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<FileType> FileType { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Glossary.
        /// </summary>
        /// <remarks>
        /// contained collection of Glossaries
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<Glossary> Glossary { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ParameterType.
        /// </summary>
        /// <remarks>
        /// contained collection of ParameterTypes
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<ParameterType> ParameterType { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ReferenceSource.
        /// </summary>
        /// <remarks>
        /// contained collection of ReferenceSources
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<ReferenceSource> ReferenceSource { get; protected set; }

        /// <summary>
        /// Gets or sets the RequiredRdl.
        /// </summary>
        /// <remarks>
        /// optional reference to the required next higher level ReferenceDataLibrary
        /// Note: This property allows chaining an ordered list of ReferenceDataLibraries for use within an EngineeringModel. Its implementation shall have a similar effect as an "import" or "include" statement in a programming language. There shall not be any circular references in the list. This property is empty for the top level ReferenceDataLibrary.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual SiteReferenceDataLibrary RequiredRdl { get; set; }

        /// <summary>
        /// Gets or sets a list of contained Rule.
        /// </summary>
        /// <remarks>
        /// collection of defined, i.e. known, Rules
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<Rule> Rule { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained MeasurementScale.
        /// </summary>
        /// <remarks>
        /// contained collection of MeasurementScales
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<MeasurementScale> Scale { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained MeasurementUnit.
        /// </summary>
        /// <remarks>
        /// contained collection of MeasurementUnits
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<MeasurementUnit> Unit { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained UnitPrefix.
        /// </summary>
        /// <remarks>
        /// collection of zero or more UnitPrefix instances that define the prefixes for multiples and submultiples of (metric) MeasurementUnits
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<UnitPrefix> UnitPrefix { get; protected set; }

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

        /// <summary>
        /// Creates and returns a copy of this <see cref="ReferenceDataLibrary"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ReferenceDataLibrary"/>.
        /// </returns>
        public new ReferenceDataLibrary Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ReferenceDataLibrary)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ReferenceDataLibrary"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }
    }
}
