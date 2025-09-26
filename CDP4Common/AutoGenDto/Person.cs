// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Starion Group S.A.">
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
    /// A Data Transfer Object representation of the <see cref="Person"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(SiteDirectory), "Person")]
    public partial class Person : Thing, IDeprecatableThing, INamedThing, IShortNamedThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        {
            this.EmailAddress = new List<Guid>();
            this.TelephoneNumber = new List<Guid>();
            this.UserPreference = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public Person(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.EmailAddress = new List<Guid>();
            this.TelephoneNumber = new List<Guid>();
            this.UserPreference = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultDomain.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultDomain { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultEmailAddress.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultEmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultTelephoneNumber.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultTelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained EmailAddress instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the GivenName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string GivenName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public bool IsDeprecated { get; set; }

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
            get { throw new InvalidOperationException("Forbidden Get value for the derived property Person.Name"); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property Person.Name"); }
        }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Organization.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? Organization { get; set; }

        /// <summary>
        /// Gets or sets the OrganizationalUnit.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string OrganizationalUnit { get; set; }

        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced Role.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? Role { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets the Surname.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public string Surname { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained TelephoneNumber instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> TelephoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained UserPreference instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> UserPreference { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="Person"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Person"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.EmailAddress);
                containers.Add(this.TelephoneNumber);
                containers.Add(this.UserPreference);
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

            if (this.DefaultDomain != null)
            {
                dictionary.Add("DefaultDomain", new [] { this.DefaultDomain.Value });
            }

            if (this.DefaultEmailAddress != null)
            {
                dictionary.Add("DefaultEmailAddress", new [] { this.DefaultEmailAddress.Value });
            }

            if (this.DefaultTelephoneNumber != null)
            {
                dictionary.Add("DefaultTelephoneNumber", new [] { this.DefaultTelephoneNumber.Value });
            }

            dictionary.Add("EmailAddress", this.EmailAddress);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            if (this.Organization != null)
            {
                dictionary.Add("Organization", new [] { this.Organization.Value });
            }

            if (this.Role != null)
            {
                dictionary.Add("Role", new [] { this.Role.Value });
            }

            dictionary.Add("TelephoneNumber", this.TelephoneNumber);

            dictionary.Add("UserPreference", this.UserPreference);

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
                            case "DefaultDomain":
                                this.DefaultDomain = null;
                                break;

                            case "DefaultEmailAddress":
                                this.DefaultEmailAddress = null;
                                break;

                            case "DefaultTelephoneNumber":
                                this.DefaultTelephoneNumber = null;
                                break;

                            case "EmailAddress":
                                this.EmailAddress.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "Organization":
                                this.Organization = null;
                                break;

                            case "Role":
                                this.Role = null;
                                break;

                            case "TelephoneNumber":
                                this.TelephoneNumber.Remove(id);
                                break;

                            case "UserPreference":
                                this.UserPreference.Remove(id);
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
                    case "DefaultDomain":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.DefaultDomain = null;
                        }
                        break;

                    case "DefaultEmailAddress":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.DefaultEmailAddress = null;
                        }
                        break;

                    case "DefaultTelephoneNumber":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.DefaultTelephoneNumber = null;
                        }
                        break;

                    case "EmailAddress":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.EmailAddress.Remove(toBeRemoved);
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

                    case "Organization":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.Organization = null;
                        }
                        break;

                    case "Role":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.Role = null;
                        }
                        break;

                    case "TelephoneNumber":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.TelephoneNumber.Remove(toBeRemoved);
                        } 
                        break;

                    case "UserPreference":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.UserPreference.Remove(toBeRemoved);
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
                }
            }

            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.Person"/> from a <see cref="Person"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.Person"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.Person(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as Person;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            var copyDefaultDomain = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultDomain);
            this.DefaultDomain = copyDefaultDomain.Value == null ? original.DefaultDomain : copyDefaultDomain.Value.Iid;

            var copyDefaultEmailAddress = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultEmailAddress);
            this.DefaultEmailAddress = copyDefaultEmailAddress.Value == null ? original.DefaultEmailAddress : copyDefaultEmailAddress.Value.Iid;

            var copyDefaultTelephoneNumber = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultTelephoneNumber);
            this.DefaultTelephoneNumber = copyDefaultTelephoneNumber.Value == null ? original.DefaultTelephoneNumber : copyDefaultTelephoneNumber.Value.Iid;

            foreach (var guid in original.EmailAddress)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.EmailAddress.Add(copy.Value.Iid);
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

            this.GivenName = original.GivenName;

            this.IsActive = original.IsActive;

            this.IsDeprecated = original.IsDeprecated;

            this.ModifiedOn = original.ModifiedOn;

            var copyOrganization = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Organization);
            this.Organization = copyOrganization.Value == null ? original.Organization : copyOrganization.Value.Iid;

            this.OrganizationalUnit = original.OrganizationalUnit;

            this.Password = original.Password;

            var copyRole = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.Role);
            this.Role = copyRole.Value == null ? original.Role : copyRole.Value.Iid;

            this.ShortName = original.ShortName;

            this.Surname = original.Surname;

            foreach (var guid in original.TelephoneNumber)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.TelephoneNumber.Add(copy.Value.Iid);
            }

            this.ThingPreference = original.ThingPreference;

            foreach (var guid in original.UserPreference)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.UserPreference.Add(copy.Value.Iid);
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
