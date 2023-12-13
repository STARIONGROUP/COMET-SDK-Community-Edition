// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectory.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="SiteDirectory"/> class.
    /// </summary>
    [DataContract]
    public partial class SiteDirectory : TopContainer, INamedThing, IShortNamedThing, ITimeStampedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectory"/> class.
        /// </summary>
        public SiteDirectory()
        {
            this.Annotation = new List<Guid>();
            this.Domain = new List<Guid>();
            this.DomainGroup = new List<Guid>();
            this.LogEntry = new List<Guid>();
            this.Model = new List<Guid>();
            this.NaturalLanguage = new List<Guid>();
            this.Organization = new List<Guid>();
            this.ParticipantRole = new List<Guid>();
            this.Person = new List<Guid>();
            this.PersonRole = new List<Guid>();
            this.SiteReferenceDataLibrary = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SiteDirectory"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public SiteDirectory(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.Annotation = new List<Guid>();
            this.Domain = new List<Guid>();
            this.DomainGroup = new List<Guid>();
            this.LogEntry = new List<Guid>();
            this.Model = new List<Guid>();
            this.NaturalLanguage = new List<Guid>();
            this.Organization = new List<Guid>();
            this.ParticipantRole = new List<Guid>();
            this.Person = new List<Guid>();
            this.PersonRole = new List<Guid>();
            this.SiteReferenceDataLibrary = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Annotation instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Annotation { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultParticipantRole.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultParticipantRole { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultPersonRole.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultPersonRole { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Domain instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Domain { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DomainGroup instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> DomainGroup { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained LogEntry instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> LogEntry { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Model instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Model { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained NaturalLanguage instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> NaturalLanguage { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Organization instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Organization { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ParticipantRole instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ParticipantRole { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Person instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Person { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained PersonRole instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> PersonRole { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained SiteReferenceDataLibrary instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> SiteReferenceDataLibrary { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="SiteDirectory"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="SiteDirectory"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Annotation);
                containers.Add(this.Domain);
                containers.Add(this.DomainGroup);
                containers.Add(this.LogEntry);
                containers.Add(this.Model);
                containers.Add(this.NaturalLanguage);
                containers.Add(this.Organization);
                containers.Add(this.ParticipantRole);
                containers.Add(this.Person);
                containers.Add(this.PersonRole);
                containers.Add(this.SiteReferenceDataLibrary);
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

            dictionary.Add("Annotation", this.Annotation);

            if (this.DefaultParticipantRole != null)
            {
                dictionary.Add("DefaultParticipantRole", new [] { this.DefaultParticipantRole.Value });
            }

            if (this.DefaultPersonRole != null)
            {
                dictionary.Add("DefaultPersonRole", new [] { this.DefaultPersonRole.Value });
            }

            dictionary.Add("Domain", this.Domain);

            dictionary.Add("DomainGroup", this.DomainGroup);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            dictionary.Add("LogEntry", this.LogEntry);

            dictionary.Add("Model", this.Model);

            dictionary.Add("NaturalLanguage", this.NaturalLanguage);

            dictionary.Add("Organization", this.Organization);

            dictionary.Add("ParticipantRole", this.ParticipantRole);

            dictionary.Add("Person", this.Person);

            dictionary.Add("PersonRole", this.PersonRole);

            dictionary.Add("SiteReferenceDataLibrary", this.SiteReferenceDataLibrary);

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
                            case "Annotation":
                                this.Annotation.Remove(id);
                                break;

                            case "DefaultParticipantRole":
                                this.DefaultParticipantRole = null;
                                break;

                            case "DefaultPersonRole":
                                this.DefaultPersonRole = null;
                                break;

                            case "Domain":
                                this.Domain.Remove(id);
                                break;

                            case "DomainGroup":
                                this.DomainGroup.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "LogEntry":
                                this.LogEntry.Remove(id);
                                break;

                            case "Model":
                                this.Model.Remove(id);
                                break;

                            case "NaturalLanguage":
                                this.NaturalLanguage.Remove(id);
                                break;

                            case "Organization":
                                this.Organization.Remove(id);
                                break;

                            case "ParticipantRole":
                                this.ParticipantRole.Remove(id);
                                break;

                            case "Person":
                                this.Person.Remove(id);
                                break;

                            case "PersonRole":
                                this.PersonRole.Remove(id);
                                break;

                            case "SiteReferenceDataLibrary":
                                this.SiteReferenceDataLibrary.Remove(id);
                                break;
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/> from a <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.SiteDirectory"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.SiteDirectory(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as SiteDirectory;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.Annotation)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Annotation.Add(copy.Value.Iid);
            }

            this.CreatedOn = original.CreatedOn;

            var copyDefaultParticipantRole = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultParticipantRole);
            this.DefaultParticipantRole = copyDefaultParticipantRole.Value == null ? original.DefaultParticipantRole : copyDefaultParticipantRole.Value.Iid;

            var copyDefaultPersonRole = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultPersonRole);
            this.DefaultPersonRole = copyDefaultPersonRole.Value == null ? original.DefaultPersonRole : copyDefaultPersonRole.Value.Iid;

            foreach (var guid in original.Domain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Domain.Add(copy.Value.Iid);
            }

            foreach (var guid in original.DomainGroup)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.DomainGroup.Add(copy.Value.Iid);
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

            this.LastModifiedOn = original.LastModifiedOn;

            foreach (var guid in original.LogEntry)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.LogEntry.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Model)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Model.Add(copy.Value.Iid);
            }

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            foreach (var guid in original.NaturalLanguage)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.NaturalLanguage.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Organization)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Organization.Add(copy.Value.Iid);
            }

            foreach (var guid in original.ParticipantRole)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.ParticipantRole.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Person)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Person.Add(copy.Value.Iid);
            }

            foreach (var guid in original.PersonRole)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.PersonRole.Add(copy.Value.Iid);
            }

            this.ShortName = original.ShortName;

            foreach (var guid in original.SiteReferenceDataLibrary)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.SiteReferenceDataLibrary.Add(copy.Value.Iid);
            }

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

            return hasChanges;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
