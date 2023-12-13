// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelSetup.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="EngineeringModelSetup"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(SiteDirectory), "Model")]
    public partial class EngineeringModelSetup : DefinedThing, IParticipantAffectedAccessThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelSetup"/> class.
        /// </summary>
        public EngineeringModelSetup()
        {
            this.ActiveDomain = new List<Guid>();
            this.IterationSetup = new List<Guid>();
            this.OrganizationalParticipant = new List<Guid>();
            this.Participant = new List<Guid>();
            this.RequiredRdl = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelSetup"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public EngineeringModelSetup(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ActiveDomain = new List<Guid>();
            this.IterationSetup = new List<Guid>();
            this.OrganizationalParticipant = new List<Guid>();
            this.Participant = new List<Guid>();
            this.RequiredRdl = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced ActiveDomain instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ActiveDomain { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultOrganizationalParticipant.
        /// </summary>
        [CDPVersion("1.2.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultOrganizationalParticipant { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced EngineeringModelIid.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid EngineeringModelIid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained IterationSetup instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> IterationSetup { get; set; }

        /// <summary>
        /// Gets or sets the Kind.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public EngineeringModelKind Kind { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained OrganizationalParticipant instances.
        /// </summary>
        [CDPVersion("1.2.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> OrganizationalParticipant { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Participant instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Participant { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RequiredRdl instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RequiredRdl { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SourceEngineeringModelSetupIid.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? SourceEngineeringModelSetupIid { get; set; }

        /// <summary>
        /// Gets or sets the StudyPhase.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public StudyPhaseKind StudyPhase { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="EngineeringModelSetup"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModelSetup"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.IterationSetup);
                containers.Add(this.OrganizationalParticipant);
                containers.Add(this.Participant);
                containers.Add(this.RequiredRdl);
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

            dictionary.Add("ActiveDomain", this.ActiveDomain);

            dictionary.Add("Alias", this.Alias);

            if (this.DefaultOrganizationalParticipant != null)
            {
                dictionary.Add("DefaultOrganizationalParticipant", new [] { this.DefaultOrganizationalParticipant.Value });
            }

            dictionary.Add("Definition", this.Definition);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            dictionary.Add("HyperLink", this.HyperLink);

            dictionary.Add("IterationSetup", this.IterationSetup);

            dictionary.Add("OrganizationalParticipant", this.OrganizationalParticipant);

            dictionary.Add("Participant", this.Participant);

            dictionary.Add("RequiredRdl", this.RequiredRdl);

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
                            case "ActiveDomain":
                                if (addModelErrors && this.ActiveDomain.Count == 1)
                                {
                                    errors.Add($"Removing reference '{id}' from ActiveDomain property results in inconsistent EngineeringModelSetup.");
                                    result = false;
                                }
                                this.ActiveDomain.Remove(id);
                                break;

                            case "Alias":
                                this.Alias.Remove(id);
                                break;

                            case "DefaultOrganizationalParticipant":
                                this.DefaultOrganizationalParticipant = null;
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

                            case "IterationSetup":
                                if (addModelErrors && this.IterationSetup.Count == 1)
                                {
                                    errors.Add($"Removing reference '{id}' from IterationSetup property results in inconsistent EngineeringModelSetup.");
                                    result = false;
                                }
                                this.IterationSetup.Remove(id);
                                break;

                            case "OrganizationalParticipant":
                                this.OrganizationalParticipant.Remove(id);
                                break;

                            case "Participant":
                                if (addModelErrors && this.Participant.Count == 1)
                                {
                                    errors.Add($"Removing reference '{id}' from Participant property results in inconsistent EngineeringModelSetup.");
                                    result = false;
                                }
                                this.Participant.Remove(id);
                                break;

                            case "RequiredRdl":
                                if (addModelErrors && this.RequiredRdl.Count == 1)
                                {
                                    errors.Add($"Removing reference '{id}' from RequiredRdl property results in inconsistent EngineeringModelSetup.");
                                    result = false;
                                }
                                this.RequiredRdl.Remove(id);
                                break;
                        }
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.SiteDirectoryData.EngineeringModelSetup"/> from a <see cref="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.SiteDirectoryData.EngineeringModelSetup"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.SiteDirectoryData.EngineeringModelSetup(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as EngineeringModelSetup;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.ActiveDomain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ActiveDomain.Add(copy.Value == null ? guid : copy.Value.Iid);
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

            var copyDefaultOrganizationalParticipant = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultOrganizationalParticipant);
            this.DefaultOrganizationalParticipant = copyDefaultOrganizationalParticipant.Value == null ? original.DefaultOrganizationalParticipant : copyDefaultOrganizationalParticipant.Value.Iid;

            foreach (var guid in original.Definition)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Definition.Add(copy.Value.Iid);
            }

            this.EngineeringModelIid = original.EngineeringModelIid;

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

            foreach (var guid in original.HyperLink)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.HyperLink.Add(copy.Value.Iid);
            }

            foreach (var guid in original.IterationSetup)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.IterationSetup.Add(copy.Value.Iid);
            }

            this.Kind = original.Kind;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            foreach (var guid in original.OrganizationalParticipant)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.OrganizationalParticipant.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Participant)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Participant.Add(copy.Value.Iid);
            }

            foreach (var guid in original.RequiredRdl)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.RequiredRdl.Add(copy.Value.Iid);
            }

            this.ShortName = original.ShortName;

            this.SourceEngineeringModelSetupIid = original.SourceEngineeringModelSetupIid;

            this.StudyPhase = original.StudyPhase;

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

            var copyDefaultOrganizationalParticipant = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.DefaultOrganizationalParticipant);
            if (copyDefaultOrganizationalParticipant.Key != null)
            {
                this.DefaultOrganizationalParticipant = copyDefaultOrganizationalParticipant.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
