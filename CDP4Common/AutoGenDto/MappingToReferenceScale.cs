// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MappingToReferenceScale.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="MappingToReferenceScale"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(MeasurementScale), "MappingToReferenceScale")]
    public sealed partial class MappingToReferenceScale : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingToReferenceScale"/> class.
        /// </summary>
        public MappingToReferenceScale()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MappingToReferenceScale"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public MappingToReferenceScale(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DependentScaleValue.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid DependentScaleValue { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ReferenceScaleValue.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid ReferenceScaleValue { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="MappingToReferenceScale"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.MappingToReferenceScale"/> from a <see cref="MappingToReferenceScale"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.MappingToReferenceScale"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.MappingToReferenceScale(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as MappingToReferenceScale;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            var copyDependentScaleValue = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DependentScaleValue);
            this.DependentScaleValue = copyDependentScaleValue.Value == null ? original.DependentScaleValue : copyDependentScaleValue.Value.Iid;

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

            var copyReferenceScaleValue = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.ReferenceScaleValue);
            this.ReferenceScaleValue = copyReferenceScaleValue.Value == null ? original.ReferenceScaleValue : copyReferenceScaleValue.Value.Iid;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyDependentScaleValue = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.DependentScaleValue);
            if (copyDependentScaleValue.Key != null)
            {
                this.DependentScaleValue = copyDependentScaleValue.Value.Iid;
                hasChanges = true;
            }

            var copyReferenceScaleValue = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.ReferenceScaleValue);
            if (copyReferenceScaleValue.Key != null)
            {
                this.ReferenceScaleValue = copyReferenceScaleValue.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
