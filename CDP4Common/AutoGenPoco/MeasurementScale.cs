// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeasurementScale.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a measurement scale to express quantity values for a numerical Parameter, i.e. a Parameter that is typed by a QuantityKind
    /// Note 1: MeasurementScale represents the VIM concept of "quantity-value scale" that is defined as "ordered set of quantity values of quantities of a given kind of quantity used in ranking, according to magnitude, quantities of that kind".
    /// Note 2: A MeasurementScale defines how to interpret the numerical value of a quantity or parameter. In this data model a distinction is made between a measurement scale and a measurement unit. A measurement unit is a reference quantity that defines how to interpret an interval of one on a measurement scale. A measurement scale defines in addition the kind of scale, and where necessary more characteristics to provide all information needed for mapping quantity values between different scales, as specified in the specializations of this class.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "Scale")]
    public abstract partial class MeasurementScale : DefinedThing, IDeprecatableThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementScale"/> class.
        /// </summary>
        protected MeasurementScale()
        {
            this.MappingToReferenceScale = new ContainerList<MappingToReferenceScale>(this);
            this.ValueDefinition = new ContainerList<ScaleValueDefinition>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementScale"/> class.
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
        protected MeasurementScale(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.MappingToReferenceScale = new ContainerList<MappingToReferenceScale>(this);
            this.ValueDefinition = new ContainerList<ScaleValueDefinition>(this);
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsMaximumInclusive.
        /// </summary>
        /// <remarks>
        /// Note: In other words this enables to define a closed or open upper end of the permissible value interval.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual bool IsMaximumInclusive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsMinimumInclusive.
        /// </summary>
        /// <remarks>
        /// assertion whether the minimum permissible value is included or not
        /// Note: In other words this enables to define a closed or open lower end of the permissible value interval.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual bool IsMinimumInclusive { get; set; }

        /// <summary>
        /// Gets or sets a list of contained MappingToReferenceScale.
        /// </summary>
        /// <remarks>
        /// reference to coincident quantity values on different but compatible MeasurementScales
        /// Note: This property would be defined for a dependent MeasurementScale with respect to a reference MeasurementScale in order to enable parameter value conversion from one scale to another. The MappingToReferenceScale defines the offset by which measurement values need to be shifted when converting values between OrdinalScales or IntervalScales.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<MappingToReferenceScale> MappingToReferenceScale { get; protected set; }

        /// <summary>
        /// Gets or sets the MaximumPermissibleValue.
        /// </summary>
        /// <remarks>
        /// optional definition of the maximum permissible value for quantities expressed on this MeasurementScale
        /// Note 1: If <i>isMaximumInclusive</i> is true, this implies that values expressed on this MeasurementScale must be less than or equal to <i>maximumPermissibleValue,</i> else if <i>isMaximumInclusive</i> is false, values must be less than <i>maximumPermissibleValue.</i>
        /// Note 2: The properties <i>maximumPermissibleValue </i>and <i>isMaximumInclusive</i> can be mapped onto the pair of XML Schema facets <a href="http://www.w3.org/TR/xmlschema-2/#rf-maxInclusive">maxInclusive</a> and <a href="http://www.w3.org/TR/xmlschema-2/#rf-maxExclusive">maxExclusive</a>.
        /// Note 3: If no <i>maximumPermissibleValue</i> is given, the maximum permissible quantity value is positive infinity.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string MaximumPermissibleValue { get; set; }

        /// <summary>
        /// Gets or sets the MinimumPermissibleValue.
        /// </summary>
        /// <remarks>
        /// optional definition of the minimum permissible quantity value expressed on this MeasurementScale
        /// Note 1: If <i>isMinimumInclusive</i> is true, this implies that values expressed on this MeasurementScale must be greater than or equal to <i>minimumPermissibleValue,</i> else if <i>isMinimumInclusive</i> is false, values must be greater than <i>minimumPermissibleValue.</i>
        /// Note 2: The properties <i>minimumPermissibleValue </i>and <i>isMinimumInclusive</i> can be mapped onto the pair of XML Schema facets <a href="http://www.w3.org/TR/xmlschema-2/#rf-minInclusive">minInclusive</a> and <a href="http://www.w3.org/TR/xmlschema-2/#rf-minExclusive">minExclusive</a>.
        /// Note 3: If no <i>minimumPermissibleValue</i> is given, the minimum permissible quantity value is negative infinity.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string MinimumPermissibleValue { get; set; }

        /// <summary>
        /// Gets or sets the NegativeValueConnotation.
        /// </summary>
        /// <remarks>
        /// optional connotation, i.e. special significance, of negative values for this MeasurementScale
        /// Example: See <i>positiveValueConnotation</i>.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string NegativeValueConnotation { get; set; }

        /// <summary>
        /// Gets or sets the NumberSet.
        /// </summary>
        /// <remarks>
        /// assertion that specifies the mathematical number set for values of this
        /// QuantityKind
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual NumberSetKind NumberSet { get; set; }

        /// <summary>
        /// Gets or sets the PositiveValueConnotation.
        /// </summary>
        /// <remarks>
        /// optional connotation, i.e. special significance, of positive values for this MeasurementScale
        /// Example: Suppose "latitude" (of a planet) is expressed on a RatioScale with the "degree" measurement unit. Then positive values by definition indicate a latitude on the northern hemisphere, and negative values indicate a latitude on the southern hemisphere. Therefore the positiveValueConnotation would be "North" and the negativeValueConnotation would be "South".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string PositiveValueConnotation { get; set; }

        /// <summary>
        /// Gets or sets the Unit.
        /// </summary>
        /// <remarks>
        /// reference to the measurement unit applicable to this MeasurementScale
        /// Note: The measurement unit defines the meaning of an interval of one on this MeasurementScale.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual MeasurementUnit Unit { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ScaleValueDefinition.
        /// </summary>
        /// <remarks>
        /// collection of particular values that are part of the definition of this MeasurementScale
        /// Example 1: On the thermodynamic temperature scale in kelvin, 0 kelvin is defined as the absolute zero temperature point and 273.15 kelvin is defined as the thermodynamic temperature of water at its triple point.
        /// Example 2: On the Beaufort wind force scale each of the numbers 1 to 12 has an associated specific textual definition, see OrdinalScale for the example.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<ScaleValueDefinition> ValueDefinition { get; protected set; }

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

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();

            dictionary.Add("Alias", this.Alias.Select(x => x.Iid));

            dictionary.Add("Definition", this.Definition.Select(x => x.Iid));

            dictionary.Add("ExcludedDomain", this.ExcludedDomain.Select(x => x.Iid));

            dictionary.Add("ExcludedPerson", this.ExcludedPerson.Select(x => x.Iid));

            dictionary.Add("HyperLink", this.HyperLink.Select(x => x.Iid));

            dictionary.Add("MappingToReferenceScale", this.MappingToReferenceScale.Select(x => x.Iid));

            if (this.Unit != null)
            {
                dictionary.Add("Unit", new [] { this.Unit.Iid });
            }

            dictionary.Add("ValueDefinition", this.ValueDefinition.Select(x => x.Iid));

            return dictionary;
        }

        /// <summary>
        /// Checks if this instance has mandatory references to any of the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to search for.</param>
        /// <returns>True is any of the id's in <paramref name="ids"/> is found in this instance's reference properties.</returns>
        public override bool HasMandatoryReferenceToAny(IEnumerable<Guid> ids)
        {
            var result = false;

            if (!ids.Any())
            {
                return false;
            }

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Unit":
                        if (ids.Intersect(kvp.Value).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="MeasurementScale"/>
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

            if (this.Unit != null)
            {
                yield return this.Unit;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="MeasurementScale"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="MeasurementScale"/>.
        /// </returns>
        public new MeasurementScale Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (MeasurementScale)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="MeasurementScale"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Unit == null || this.Unit.Iid == Guid.Empty)
            {
                errorList.Add("The property Unit is null.");
                this.Unit = SentinelThingProvider.GetSentinel<MeasurementUnit>();
                this.sentinelResetMap["Unit"] = () => this.Unit = null;
            }

            return errorList;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
