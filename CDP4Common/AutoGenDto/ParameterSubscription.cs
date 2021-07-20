// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscription.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="ParameterSubscription"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ParameterOrOverrideBase), "ParameterSubscription")]
    public sealed partial class ParameterSubscription : ParameterBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSubscription"/> class.
        /// </summary>
        public ParameterSubscription()
        {
            this.ValueSet = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterSubscription"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public ParameterSubscription(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ValueSet = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Group.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Group property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: true, isPersistent: false)]
        [XmlIgnore]
        public override Guid? Group
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterSubscription.Group"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.Group"); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsOptionDependent.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The IsOptionDependent property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public override bool IsOptionDependent
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterSubscription.IsOptionDependent"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.IsOptionDependent"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ParameterType.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The ParameterType property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public override Guid ParameterType
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterSubscription.ParameterType"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.ParameterType"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Scale.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Scale property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: true, isPersistent: false)]
        [XmlIgnore]
        public override Guid? Scale
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterSubscription.Scale"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.Scale"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced StateDependence.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The StateDependence property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: true, isPersistent: false)]
        [XmlIgnore]
        public override Guid? StateDependence
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ParameterSubscription.StateDependence"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ParameterSubscription.StateDependence"); }
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ValueSet instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ValueSet { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ParameterSubscription"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ParameterSubscription"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ValueSet);
                return containers;
            }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.ParameterSubscription"/> from a <see cref="ParameterSubscription"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.ParameterSubscription"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.ParameterSubscription(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as ParameterSubscription;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
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

            this.ModifiedOn = original.ModifiedOn;

            var copyOwner = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Owner);
            this.Owner = copyOwner.Value == null ? original.Owner : copyOwner.Value.Iid;

            this.ThingPreference = original.ThingPreference;

            foreach (var guid in original.ValueSet)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ValueSet.Add(copy.Value.Iid);
            }
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            return hasChanges;
        }
    }
}
