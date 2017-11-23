// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteState.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
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
    /// A Data Transfer Object representation of the <see cref="ActualFiniteState"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ActualFiniteStateList), "ActualState")]
    public sealed partial class ActualFiniteState : Thing, INamedThing, IOwnedThing, IShortNamedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActualFiniteState"/> class.
        /// </summary>
        public ActualFiniteState()
        {
            this.PossibleState = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActualFiniteState"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public ActualFiniteState(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.PossibleState = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public ActualFiniteStateKind Kind { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public string Name
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ActualFiniteState.Name"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ActualFiniteState.Name"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public Guid Owner
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ActualFiniteState.Owner"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ActualFiniteState.Owner"); }
        }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced PossibleState instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> PossibleState { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// The ShortName property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        [XmlIgnore]
        public string ShortName
        {
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ActualFiniteState.ShortName"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ActualFiniteState.ShortName"); }
        }

        /// <summary>
        /// Gets the route for the current <see ref="ActualFiniteState"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.ActualFiniteState"/> from a <see cref="ActualFiniteState"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.ActualFiniteState"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.ActualFiniteState(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as ActualFiniteState;
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

            this.Kind = original.Kind;

            this.ModifiedOn = original.ModifiedOn;

            foreach (var guid in original.PossibleState)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.PossibleState.Add(copy.Value == null ? guid : copy.Value.Iid);
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
