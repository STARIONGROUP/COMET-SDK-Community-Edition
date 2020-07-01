// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateList.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ActualFiniteStateList"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(Iteration), "ActualFiniteStateList")]
    public sealed partial class ActualFiniteStateList : Thing, INamedThing, IOptionDependentThing, IOwnedThing, IShortNamedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActualFiniteStateList"/> class.
        /// </summary>
        public ActualFiniteStateList()
        {
            this.ActualState = new List<Guid>();
            this.ExcludeOption = new List<Guid>();
            this.PossibleFiniteStateList = new List<OrderedItem>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActualFiniteStateList"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public ActualFiniteStateList(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ActualState = new List<Guid>();
            this.ExcludeOption = new List<Guid>();
            this.PossibleFiniteStateList = new List<OrderedItem>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ActualState instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ActualState { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced ExcludeOption instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ExcludeOption { get; set; }

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
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ActualFiniteStateList.Name"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ActualFiniteStateList.Name"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Owner { get; set; }

        /// <summary>
        /// Gets or sets the list of ordered unique identifiers of the referenced PossibleFiniteStateList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> PossibleFiniteStateList { get; set; }

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
            get { throw new InvalidOperationException("Forbidden Get value for the derived property ActualFiniteStateList.ShortName"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property ActualFiniteStateList.ShortName"); }
        }

        /// <summary>
        /// Gets the route for the current <see ref="ActualFiniteStateList"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ActualFiniteStateList"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ActualState);
                return containers;
            }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.ActualFiniteStateList"/> from a <see cref="ActualFiniteStateList"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.ActualFiniteStateList"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.ActualFiniteStateList(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as ActualFiniteStateList;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.ActualState)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ActualState.Add(copy.Value.Iid);
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

            foreach (var guid in original.ExcludeOption)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludeOption.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            this.ModifiedOn = original.ModifiedOn;

            var copyOwner = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Owner);
            this.Owner = copyOwner.Value == null ? original.Owner : copyOwner.Value.Iid;

            foreach (var orderedItem in original.PossibleFiniteStateList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                this.PossibleFiniteStateList.Add(new OrderedItem { K = orderedItem.K, V = copy.Value == null ? orderedItem.V : copy.Value.Iid });
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
