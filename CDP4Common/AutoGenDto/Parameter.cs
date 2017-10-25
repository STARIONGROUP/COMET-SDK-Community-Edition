// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="RHEA System S.A.">
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
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="Parameter"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ElementDefinition), "Parameter")]
    public sealed partial class Parameter : ParameterOrOverrideBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        public Parameter()
        {
            this.ValueSet = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Parameter"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public Parameter(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ValueSet = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether AllowDifferentOwnerOfOverride.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool AllowDifferentOwnerOfOverride { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether ExpectsOverride.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool ExpectsOverride { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced RequestedBy.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? RequestedBy { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ValueSet instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ValueSet { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="Parameter"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Parameter"/>.
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
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.Parameter"/> from a <see cref="Parameter"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.Parameter"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.Parameter(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as Parameter;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            this.AllowDifferentOwnerOfOverride = original.AllowDifferentOwnerOfOverride;

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

            this.ExpectsOverride = original.ExpectsOverride;

            var copyGroup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Group);
            this.Group = copyGroup.Value == null ? original.Group : copyGroup.Value.Iid;

            this.IsOptionDependent = original.IsOptionDependent;

            this.ModifiedOn = original.ModifiedOn;

            var copyOwner = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Owner);
            this.Owner = copyOwner.Value == null ? original.Owner : copyOwner.Value.Iid;

            foreach (var guid in original.ParameterSubscription)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ParameterSubscription.Add(copy.Value.Iid);
            }

            var copyParameterType = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.ParameterType);
            this.ParameterType = copyParameterType.Value == null ? original.ParameterType : copyParameterType.Value.Iid;

            var copyRequestedBy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.RequestedBy);
            this.RequestedBy = copyRequestedBy.Value == null ? original.RequestedBy : copyRequestedBy.Value.Iid;

            var copyScale = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Scale);
            this.Scale = copyScale.Value == null ? original.Scale : copyScale.Value.Iid;

            var copyStateDependence = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.StateDependence);
            this.StateDependence = copyStateDependence.Value == null ? original.StateDependence : copyStateDependence.Value.Iid;

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

            var copyParameterType = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.ParameterType);
            if (copyParameterType.Key != null)
            {
                this.ParameterType = copyParameterType.Value.Iid;
                hasChanges = true;
            }

            var copyScale = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.Scale);
            if (copyScale.Key != null)
            {
                this.Scale = copyScale.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
