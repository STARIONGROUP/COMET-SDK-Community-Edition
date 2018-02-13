#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnit.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="PrefixedUnit"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public sealed partial class PrefixedUnit : ConversionBasedUnit
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixedUnit"/> class.
        /// </summary>
        public PrefixedUnit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrefixedUnit"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public PrefixedUnit(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the ConversionFactor.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The ConversionFactor property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public override string ConversionFactor
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property PrefixedUnit.ConversionFactor"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.ConversionFactor"); }
        }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public override string Name
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property PrefixedUnit.Name"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.Name"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Prefix.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Prefix { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The ShortName property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public override string ShortName
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property PrefixedUnit.ShortName"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property PrefixedUnit.ShortName"); }
        }

        /// <summary>
        /// Gets the route for the current <see ref="PrefixedUnit"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.PrefixedUnit"/> from a <see cref="PrefixedUnit"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.PrefixedUnit"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.PrefixedUnit(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as PrefixedUnit;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Alias)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Alias.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Definition)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Definition.Add(copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedDomain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedDomain.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedPerson)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedPerson.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.HyperLink)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.HyperLink.Add(copy.Value.Iid);
            }

            this.IsDeprecated = original.IsDeprecated;

            this.ModifiedOn = original.ModifiedOn;

            var copyPrefix = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Prefix);
            this.Prefix = copyPrefix.Value == null ? original.Prefix : copyPrefix.Value.Iid;

            var copyReferenceUnit = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.ReferenceUnit);
            this.ReferenceUnit = copyReferenceUnit.Value == null ? original.ReferenceUnit : copyReferenceUnit.Value.Iid;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyPrefix = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.Prefix);
            if (copyPrefix.Key != null)
            {
                this.Prefix = copyPrefix.Value.Iid;
                hasChanges = true;
            }

            var copyReferenceUnit = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.ReferenceUnit);
            if (copyReferenceUnit.Key != null)
            {
                this.ReferenceUnit = copyReferenceUnit.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
