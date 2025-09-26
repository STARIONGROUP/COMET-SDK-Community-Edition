// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExternalIdentifierMap.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    /// A Data Transfer Object representation of the <see cref="ExternalIdentifierMap"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(Iteration), "ExternalIdentifierMap")]
    public partial class ExternalIdentifierMap : Thing, INamedThing, IOwnedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalIdentifierMap"/> class.
        /// </summary>
        public ExternalIdentifierMap()
        {
            this.Correspondence = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExternalIdentifierMap"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public ExternalIdentifierMap(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Correspondence = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Correspondence instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Correspondence { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ExternalFormat.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? ExternalFormat { get; set; }

        /// <summary>
        /// Gets or sets the ExternalModelName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ExternalModelName { get; set; }

        /// <summary>
        /// Gets or sets the ExternalToolName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ExternalToolName { get; set; }

        /// <summary>
        /// Gets or sets the ExternalToolVersion.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ExternalToolVersion { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Owner.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid Owner { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="ExternalIdentifierMap"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ExternalIdentifierMap"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Correspondence);
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

            dictionary.Add("Correspondence", this.Correspondence);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            if (this.ExternalFormat != null)
            {
                dictionary.Add("ExternalFormat", new [] { this.ExternalFormat.Value });
            }

            if (this.Owner != null)
            {
                dictionary.Add("Owner", new [] { this.Owner });
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
                            case "Correspondence":
                                this.Correspondence.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "ExternalFormat":
                                this.ExternalFormat = null;
                                break;

                            case "Owner":
                                if (addModelErrors)
                                {
                                    errors.Add($"Removed reference '{id}' from Owner property results in inconsistent ExternalIdentifierMap.");
                                    result = false;
                                }
                                break;
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Tries to remove references to id's if they don't exist in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The collection of Guids</param>
        /// <param name="errors">The errors collected while trying to remove references</param>
        /// <returns>True if no errors were found while trying to remove references</returns>
        public override bool TryRemoveReferencesNotIn(IEnumerable<Guid> ids, out List<string> errors)
        {
            errors = new List<string>();
            var result = true;

            foreach (var referencedProperty in this.GetReferenceProperties())
            {
                switch (referencedProperty.Key)
                {
                    case "Correspondence":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Correspondence.Remove(toBeRemoved);
                        } 
                        break;

                    case "ExcludedDomain":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ExcludedDomain.Remove(toBeRemoved);
                        } 
                        break;

                    case "ExcludedPerson":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ExcludedPerson.Remove(toBeRemoved);
                        } 
                        break;

                    case "ExternalFormat":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.ExternalFormat = null;
                        }
                        break;

                    case "Owner":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            errors.Add($"Removed reference '{referencedProperty.Key}' from Owner property results in inconsistent ExternalIdentifierMap.");
                            result = false;
                        }
                        break;
                }
            }
            
            return result;
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
                    case "Owner":
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
        /// Checks if this instance has mandatory references to an id that cannot be found in the id's in a collection of id's (Guid's)
        /// </summary>
        /// <param name="ids">The HashSet of Guids to search for.</param>
        /// <returns>True is the id in this instance's mandatory reference properties is not found in in <paramref name="ids"/>.</returns>
        public override bool HasMandatoryReferenceNotIn(HashSet<Guid> ids)
        {
            var result = false;

            foreach (var kvp in this.GetReferenceProperties())
            {
                switch (kvp.Key)
                {
                    case "Owner":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.ExternalIdentifierMap"/> from a <see cref="ExternalIdentifierMap"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.ExternalIdentifierMap"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.ExternalIdentifierMap(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as ExternalIdentifierMap;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Correspondence)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Correspondence.Add(copy.Value.Iid);
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

            var copyExternalFormat = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.ExternalFormat);
            this.ExternalFormat = copyExternalFormat.Value == null ? original.ExternalFormat : copyExternalFormat.Value.Iid;

            this.ExternalModelName = original.ExternalModelName;

            this.ExternalToolName = original.ExternalToolName;

            this.ExternalToolVersion = original.ExternalToolVersion;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            var copyOwner = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Owner);
            this.Owner = copyOwner.Value == null ? original.Owner : copyOwner.Value.Iid;

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

            var copyExternalFormat = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.ExternalFormat);
            if (copyExternalFormat.Key != null)
            {
                this.ExternalFormat = copyExternalFormat.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
