// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRule.cs" company="RHEA System S.A.">
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
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="BinaryRelationshipRule"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Rule")]
    public partial class BinaryRelationshipRule : Rule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationshipRule"/> class.
        /// </summary>
        public BinaryRelationshipRule()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryRelationshipRule"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public BinaryRelationshipRule(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the ForwardRelationshipName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ForwardRelationshipName { get; set; }

        /// <summary>
        /// Gets or sets the InverseRelationshipName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string InverseRelationshipName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced RelationshipCategory.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid RelationshipCategory { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SourceCategory.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid SourceCategory { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced TargetCategory.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid TargetCategory { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="BinaryRelationshipRule"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Get all Reference Properties by their Name and id's of instance values
        /// </summary>
        /// <returns>A dictionary of string (Name) and a collections of Guid's (id's of instance values)</returns>
        public override IDictionary<string, IEnumerable<Guid>> GetReferenceProperties()
        {
            var dictionary = new Dictionary<string, IEnumerable<Guid>>();

            dictionary.Add("Alias", this.Alias);

            dictionary.Add("Definition", this.Definition);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            dictionary.Add("HyperLink", this.HyperLink);

            if (this.RelationshipCategory != default)
            {
                dictionary.Add("RelationshipCategory", new [] { this.RelationshipCategory });
            }

            if (this.SourceCategory != default)
            {
                dictionary.Add("SourceCategory", new [] { this.SourceCategory });
            }

            if (this.TargetCategory != default)
            {
                dictionary.Add("TargetCategory", new [] { this.TargetCategory });
            }

            return dictionary;
        }

        /// <summary>
        /// Tries to remove references to id's if they exist in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids to remove references for.</param>
        /// <param name="errors">The errors collected while trying to remove references</param>
        /// <returns>True if no errors were found while trying to remove references</returns>
        public override bool TryRemoveReferences(IEnumerable<Guid> ids, out List<string> errors)
        {
            errors = new List<string>();
            var referencedProperties = this.GetReferenceProperties();
            var addModelErrors = !ids.Contains(this.Iid);
            var result = true;

            foreach (var id in ids)
            {
                var foundProperty = referencedProperties.Where(x => x.Value.Contains(id)).ToList();

                if (foundProperty.Any())
                {
                    foreach (var kvp in foundProperty)
                    {
                        switch (kvp.Key)
                        {
                            case "Alias":
                                this.Alias.Remove(id);
                                break;

                            case "Definition":
                                this.Definition.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "HyperLink":
                                this.HyperLink.Remove(id);
                                break;

                            case "RelationshipCategory":
                                if (addModelErrors)
                                {
                                    errors.Add($"Remove reference '{id}' from RelationshipCategory property is not allowed.");
                                }
                                break;

                            case "SourceCategory":
                                if (addModelErrors)
                                {
                                    errors.Add($"Remove reference '{id}' from SourceCategory property is not allowed.");
                                }
                                break;

                            case "TargetCategory":
                                if (addModelErrors)
                                {
                                    errors.Add($"Remove reference '{id}' from TargetCategory property is not allowed.");
                                }
                                break;
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.BinaryRelationshipRule"/> from a <see cref="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.BinaryRelationshipRule"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.BinaryRelationshipRule(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as BinaryRelationshipRule;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Alias)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Alias.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Definition)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
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

            this.ForwardRelationshipName = original.ForwardRelationshipName;

            foreach (var guid in original.HyperLink)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.HyperLink.Add(copy.Value.Iid);
            }

            this.InverseRelationshipName = original.InverseRelationshipName;

            this.IsDeprecated = original.IsDeprecated;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            var copyRelationshipCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.RelationshipCategory);
            this.RelationshipCategory = copyRelationshipCategory.Value == null ? original.RelationshipCategory : copyRelationshipCategory.Value.Iid;

            this.ShortName = original.ShortName;

            var copySourceCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.SourceCategory);
            this.SourceCategory = copySourceCategory.Value == null ? original.SourceCategory : copySourceCategory.Value.Iid;

            var copyTargetCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.TargetCategory);
            this.TargetCategory = copyTargetCategory.Value == null ? original.TargetCategory : copyTargetCategory.Value.Iid;

            this.ThingPreference = original.ThingPreference;
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyRelationshipCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.RelationshipCategory);
            if (copyRelationshipCategory.Key != null)
            {
                this.RelationshipCategory = copyRelationshipCategory.Value.Iid;
                hasChanges = true;
            }

            var copySourceCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.SourceCategory);
            if (copySourceCategory.Key != null)
            {
                this.SourceCategory = copySourceCategory.Value.Iid;
                hasChanges = true;
            }

            var copyTargetCategory = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.TargetCategory);
            if (copyTargetCategory.Key != null)
            {
                this.TargetCategory = copyTargetCategory.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
