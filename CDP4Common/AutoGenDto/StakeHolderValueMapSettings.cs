// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapSettings.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="StakeHolderValueMapSettings"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(StakeHolderValueMap), "Settings")]
    public sealed partial class StakeHolderValueMapSettings : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StakeHolderValueMapSettings"/> class.
        /// </summary>
        public StakeHolderValueMapSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StakeHolderValueMapSettings"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public StakeHolderValueMapSettings(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced GoalToValueGroupRelationship.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? GoalToValueGroupRelationship { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced StakeholderValueToRequirementRelationship.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? StakeholderValueToRequirementRelationship { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ValueGroupToStakeholderValueRelationship.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? ValueGroupToStakeholderValueRelationship { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="StakeHolderValueMapSettings"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.StakeHolderValueMapSettings"/> from a <see cref="StakeHolderValueMapSettings"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.StakeHolderValueMapSettings"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.StakeHolderValueMapSettings(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as StakeHolderValueMapSettings;
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

            var copyGoalToValueGroupRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.GoalToValueGroupRelationship);
            this.GoalToValueGroupRelationship = copyGoalToValueGroupRelationship.Value == null ? original.GoalToValueGroupRelationship : copyGoalToValueGroupRelationship.Value.Iid;

            this.ModifiedOn = original.ModifiedOn;

            var copyStakeholderValueToRequirementRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.StakeholderValueToRequirementRelationship);
            this.StakeholderValueToRequirementRelationship = copyStakeholderValueToRequirementRelationship.Value == null ? original.StakeholderValueToRequirementRelationship : copyStakeholderValueToRequirementRelationship.Value.Iid;

            this.ThingPreference = original.ThingPreference;

            var copyValueGroupToStakeholderValueRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.ValueGroupToStakeholderValueRelationship);
            this.ValueGroupToStakeholderValueRelationship = copyValueGroupToStakeholderValueRelationship.Value == null ? original.ValueGroupToStakeholderValueRelationship : copyValueGroupToStakeholderValueRelationship.Value.Iid;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyGoalToValueGroupRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.GoalToValueGroupRelationship);
            if (copyGoalToValueGroupRelationship.Key != null)
            {
                this.GoalToValueGroupRelationship = copyGoalToValueGroupRelationship.Value.Iid;
                hasChanges = true;
            }

            var copyStakeholderValueToRequirementRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.StakeholderValueToRequirementRelationship);
            if (copyStakeholderValueToRequirementRelationship.Key != null)
            {
                this.StakeholderValueToRequirementRelationship = copyStakeholderValueToRequirementRelationship.Value.Iid;
                hasChanges = true;
            }

            var copyValueGroupToStakeholderValueRelationship = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.ValueGroupToStakeholderValueRelationship);
            if (copyValueGroupToStakeholderValueRelationship.Key != null)
            {
                this.ValueGroupToStakeholderValueRelationship = copyValueGroupToStakeholderValueRelationship.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
