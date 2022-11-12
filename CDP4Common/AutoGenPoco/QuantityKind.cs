// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    /// representation of a numerical ScalarParameterType
    /// Note 1: QuantityKind represents the VIM concept of "kind of quantity" that is defined as "aspect common to mutually comparable quantities".
    /// Note 2: In this data model a quantity is represented by a Parameter (or an associated ParameterOverride or ParameterSubscription), a Constant or a SimpleParameterValue. It is typed by a QuantityKind and has a numerical value as well as a reference to a MeasurementScale. See the definitions of the mentioned concepts for the details on how value and measurement scale are instantiated. Example: Length, mass, time, speed, diameter, electrical current, thermodynamic temperature and Rockwell hardness are all examples of QuantityKind.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "ParameterType")]
    public abstract partial class QuantityKind : ScalarParameterType
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
        /// Initializes a new instance of the <see cref="QuantityKind"/> class.
        /// </summary>
        protected QuantityKind()
        {
            this.PossibleScale = new List<MeasurementScale>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantityKind"/> class.
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
        protected QuantityKind(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.PossibleScale = new List<MeasurementScale>();
        }

        /// <summary>
        /// Gets or sets a list of MeasurementScale.
        /// </summary>
        /// <remarks>
        /// derived collection of all possible MeasurementScales on which values for this QuantityKind can be expressed
        /// Note: For a SimpleQuantityKind and a DerivedQuantityKind <i>allPossibleScale</i> contains the same MeasurementScales as <i>possibleScale</i>. For a SpecializedQuantityKind <i>allPossibleScale</i> contains the set of all <i>possibleScale</i> of the specific SpecializedQuantityKind and all of its <i>general</i> QuantityKind.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The AllPossibleScale property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public List<MeasurementScale> AllPossibleScale
        {
            get { return this.GetDerivedAllPossibleScale(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.AllPossibleScale"); }
        }

        /// <summary>
        /// Gets or sets the DefaultScale.
        /// </summary>
        /// <remarks>
        /// definition of the default MeasurementScale for this QuantityKind
        /// Note: The <i>defaultScale</i> must be a MeasurementScale in the collection <i>allPossibleScale</i> for this QuantityKind.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual MeasurementScale DefaultScale { get; set; }

        /// <summary>
        /// Gets or sets a list of MeasurementScale.
        /// </summary>
        /// <remarks>
        /// collection of MeasurementScales on which values for this QuantityKind can be expressed
        /// Note: For a SpecializedQuantityKind there may be zero possible scales, because it inherits the possible scales from its <i>general</i> QuantityKind. See also the <i>allPossibleScale</i> property.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual List<MeasurementScale> PossibleScale { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered String.
        /// </summary>
        /// <remarks>
        /// derived list of exponents that together with the actual base QuantityKinds define the physical dimension of this QuantityKind
        /// Note 1: The <a href="http://www.bipm.org/en/publications/guides/vim.html">International Vocabulary of Metrology (VIM)</a> defines "quantity dimension" as "expression of the dependence of a quantity on the base quantities of a system of quantities as a product of powers of factors corresponding to the base quantities, omitting any numerical factor."
        /// Note 2: There must be as many exponents as there as <i>baseQuantityKind</i> QuantityKinds in the dataset. The exponents are given in the same order as the ordered collection of <i>baseQuantityKind</i> QuantityKinds, enumerated starting from the top <i>requiredRdl</i> down to the ReferenceDataLibrary that contains this QuantityKind. Typically only the top SiteReferenceDataLibrary will have a non-empty <i>baseQuantityKind</i> collection.
        /// Note 3: The physical dimension of any QuantityKind can be derived through the algorithm that is defined in Section C.5.2.20 of <a href="http://www.omgsysml.org">SysML v1.2</a>. The actual physical dimension for a given QuantityKind depends on the choice of base QuantityKinds specified in the relevant (set of) ReferenceDataLibrary (or SystemOfQuantities in SysML).
        /// Example: In the International System of Quantities (ISQ) the quantity dimension of "force" is denoted by
        /// dim F = L.M.T<sup>-2</sup>,
        /// where "F" is the symbol for "force," and "L," "M," and "T" are the symbols for the ISQ base quantities "length", "mass", and "time" respectively.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The QuantityDimensionExponent property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: true, isNullable: false, isPersistent: false)]
        public OrderedItemList<string> QuantityDimensionExponent
        {
            get { return this.GetDerivedQuantityDimensionExponent(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.QuantityDimensionExponent"); }
        }

        /// <summary>
        /// Gets or sets the QuantityDimensionExpression.
        /// </summary>
        /// <remarks>
        /// derived symbolic expression of the physical dimension of this QuantityKind
        /// Note: This is the human readable version of product of powers formed by the <i>quantityDimensionSymbol</i> of each of the base QuantityKind and the corresponding <i>quantityDimensionExponent</i>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The QuantityDimensionExpression property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string QuantityDimensionExpression
        {
            get { return this.GetDerivedQuantityDimensionExpression(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property QuantityKind.QuantityDimensionExpression"); }
        }

        /// <summary>
        /// Gets or sets the QuantityDimensionSymbol.
        /// </summary>
        /// <remarks>
        /// definition of the symbol used to represent the physical dimension of a QuantityKind that is a <i>baseQuantityKind</i> as registered in the containing ReferenceDataLibrary
        /// Note: These base quantity kind symbols are used in the derivation of the <i>quantityDimensionExpression</i> property for all QuantityKinds.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string QuantityDimensionSymbol { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="QuantityKind"/>
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

            if (this.DefaultScale != null)
            {
                yield return this.DefaultScale;
            }

            foreach (var thing in this.PossibleScale)
            {
                yield return thing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="QuantityKind"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="QuantityKind"/>.
        /// </returns>
        public new QuantityKind Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (QuantityKind)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="QuantityKind"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.DefaultScale == null || this.DefaultScale.Iid == Guid.Empty)
            {
                errorList.Add("The property DefaultScale is null.");
                this.DefaultScale = SentinelThingProvider.GetSentinel<MeasurementScale>();
                this.sentinelResetMap["DefaultScale"] = () => this.DefaultScale = null;
            }

            return errorList;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
