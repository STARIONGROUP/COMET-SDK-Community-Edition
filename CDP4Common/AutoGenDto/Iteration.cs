// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iteration.cs" company="Starion Group S.A.">
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
    /// A Data Transfer Object representation of the <see cref="Iteration"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(EngineeringModel), "Iteration")]
    public partial class Iteration : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Iteration"/> class.
        /// </summary>
        public Iteration()
        {
            this.ActualFiniteStateList = new List<Guid>();
            this.DiagramCanvas = new List<Guid>();
            this.DomainFileStore = new List<Guid>();
            this.Element = new List<Guid>();
            this.ExternalIdentifierMap = new List<Guid>();
            this.Goal = new List<Guid>();
            this.Option = new List<OrderedItem>();
            this.PossibleFiniteStateList = new List<Guid>();
            this.Publication = new List<Guid>();
            this.Relationship = new List<Guid>();
            this.RequirementsSpecification = new List<Guid>();
            this.RuleVerificationList = new List<Guid>();
            this.SharedDiagramStyle = new List<Guid>();
            this.Stakeholder = new List<Guid>();
            this.StakeholderValue = new List<Guid>();
            this.StakeholderValueMap = new List<Guid>();
            this.ValueGroup = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Iteration"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public Iteration(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ActualFiniteStateList = new List<Guid>();
            this.DiagramCanvas = new List<Guid>();
            this.DomainFileStore = new List<Guid>();
            this.Element = new List<Guid>();
            this.ExternalIdentifierMap = new List<Guid>();
            this.Goal = new List<Guid>();
            this.Option = new List<OrderedItem>();
            this.PossibleFiniteStateList = new List<Guid>();
            this.Publication = new List<Guid>();
            this.Relationship = new List<Guid>();
            this.RequirementsSpecification = new List<Guid>();
            this.RuleVerificationList = new List<Guid>();
            this.SharedDiagramStyle = new List<Guid>();
            this.Stakeholder = new List<Guid>();
            this.StakeholderValue = new List<Guid>();
            this.StakeholderValueMap = new List<Guid>();
            this.ValueGroup = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ActualFiniteStateList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ActualFiniteStateList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultOption.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultOption { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DiagramCanvas instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> DiagramCanvas { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DomainFileStore instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> DomainFileStore { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Element instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Element { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ExternalIdentifierMap instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ExternalIdentifierMap { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Goal instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Goal { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced IterationSetup.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid IterationSetup { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Option instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> Option { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained PossibleFiniteStateList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> PossibleFiniteStateList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Publication instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Publication { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Relationship instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Relationship { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RequirementsSpecification instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RequirementsSpecification { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RuleVerificationList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RuleVerificationList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained SharedDiagramStyle instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> SharedDiagramStyle { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SourceIterationIid.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? SourceIterationIid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Stakeholder instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Stakeholder { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained StakeholderValue instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> StakeholderValue { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained StakeholderValueMap instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> StakeholderValueMap { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced TopElement.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? TopElement { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ValueGroup instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ValueGroup { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="Iteration"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Iteration"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ActualFiniteStateList);
                containers.Add(this.DiagramCanvas);
                containers.Add(this.DomainFileStore);
                containers.Add(this.Element);
                containers.Add(this.ExternalIdentifierMap);
                containers.Add(this.Goal);
                containers.Add(this.Option);
                containers.Add(this.PossibleFiniteStateList);
                containers.Add(this.Publication);
                containers.Add(this.Relationship);
                containers.Add(this.RequirementsSpecification);
                containers.Add(this.RuleVerificationList);
                containers.Add(this.SharedDiagramStyle);
                containers.Add(this.Stakeholder);
                containers.Add(this.StakeholderValue);
                containers.Add(this.StakeholderValueMap);
                containers.Add(this.ValueGroup);
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

            dictionary.Add("ActualFiniteStateList", this.ActualFiniteStateList);

            if (this.DefaultOption != null)
            {
                dictionary.Add("DefaultOption", new [] { this.DefaultOption.Value });
            }

            dictionary.Add("DiagramCanvas", this.DiagramCanvas);

            dictionary.Add("DomainFileStore", this.DomainFileStore);

            dictionary.Add("Element", this.Element);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            dictionary.Add("ExternalIdentifierMap", this.ExternalIdentifierMap);

            dictionary.Add("Goal", this.Goal);

            if (this.IterationSetup != null)
            {
                dictionary.Add("IterationSetup", new [] { this.IterationSetup });
            }

            dictionary.Add("PossibleFiniteStateList", this.PossibleFiniteStateList);

            dictionary.Add("Publication", this.Publication);

            dictionary.Add("Relationship", this.Relationship);

            dictionary.Add("RequirementsSpecification", this.RequirementsSpecification);

            dictionary.Add("RuleVerificationList", this.RuleVerificationList);

            dictionary.Add("SharedDiagramStyle", this.SharedDiagramStyle);

            dictionary.Add("Stakeholder", this.Stakeholder);

            dictionary.Add("StakeholderValue", this.StakeholderValue);

            dictionary.Add("StakeholderValueMap", this.StakeholderValueMap);

            if (this.TopElement != null)
            {
                dictionary.Add("TopElement", new [] { this.TopElement.Value });
            }

            dictionary.Add("ValueGroup", this.ValueGroup);

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
                            case "ActualFiniteStateList":
                                this.ActualFiniteStateList.Remove(id);
                                break;

                            case "DefaultOption":
                                this.DefaultOption = null;
                                break;

                            case "DiagramCanvas":
                                this.DiagramCanvas.Remove(id);
                                break;

                            case "DomainFileStore":
                                this.DomainFileStore.Remove(id);
                                break;

                            case "Element":
                                this.Element.Remove(id);
                                break;

                            case "ExcludedDomain":
                                this.ExcludedDomain.Remove(id);
                                break;

                            case "ExcludedPerson":
                                this.ExcludedPerson.Remove(id);
                                break;

                            case "ExternalIdentifierMap":
                                this.ExternalIdentifierMap.Remove(id);
                                break;

                            case "Goal":
                                this.Goal.Remove(id);
                                break;

                            case "IterationSetup":
                                if (addModelErrors)
                                {
                                    errors.Add($"Removed reference '{id}' from IterationSetup property results in inconsistent Iteration.");
                                    result = false;
                                }
                                break;

                            case "PossibleFiniteStateList":
                                this.PossibleFiniteStateList.Remove(id);
                                break;

                            case "Publication":
                                this.Publication.Remove(id);
                                break;

                            case "Relationship":
                                this.Relationship.Remove(id);
                                break;

                            case "RequirementsSpecification":
                                this.RequirementsSpecification.Remove(id);
                                break;

                            case "RuleVerificationList":
                                this.RuleVerificationList.Remove(id);
                                break;

                            case "SharedDiagramStyle":
                                this.SharedDiagramStyle.Remove(id);
                                break;

                            case "Stakeholder":
                                this.Stakeholder.Remove(id);
                                break;

                            case "StakeholderValue":
                                this.StakeholderValue.Remove(id);
                                break;

                            case "StakeholderValueMap":
                                this.StakeholderValueMap.Remove(id);
                                break;

                            case "TopElement":
                                this.TopElement = null;
                                break;

                            case "ValueGroup":
                                this.ValueGroup.Remove(id);
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
                    case "ActualFiniteStateList":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ActualFiniteStateList.Remove(toBeRemoved);
                        } 
                        break;

                    case "DefaultOption":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.DefaultOption = null;
                        }
                        break;

                    case "DiagramCanvas":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.DiagramCanvas.Remove(toBeRemoved);
                        } 
                        break;

                    case "DomainFileStore":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.DomainFileStore.Remove(toBeRemoved);
                        } 
                        break;

                    case "Element":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Element.Remove(toBeRemoved);
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

                    case "ExternalIdentifierMap":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ExternalIdentifierMap.Remove(toBeRemoved);
                        } 
                        break;

                    case "Goal":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Goal.Remove(toBeRemoved);
                        } 
                        break;

                    case "IterationSetup":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            errors.Add($"Removed reference '{referencedProperty.Key}' from IterationSetup property results in inconsistent Iteration.");
                            result = false;
                        }
                        break;

                    case "PossibleFiniteStateList":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.PossibleFiniteStateList.Remove(toBeRemoved);
                        } 
                        break;

                    case "Publication":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Publication.Remove(toBeRemoved);
                        } 
                        break;

                    case "Relationship":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Relationship.Remove(toBeRemoved);
                        } 
                        break;

                    case "RequirementsSpecification":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.RequirementsSpecification.Remove(toBeRemoved);
                        } 
                        break;

                    case "RuleVerificationList":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.RuleVerificationList.Remove(toBeRemoved);
                        } 
                        break;

                    case "SharedDiagramStyle":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.SharedDiagramStyle.Remove(toBeRemoved);
                        } 
                        break;

                    case "Stakeholder":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Stakeholder.Remove(toBeRemoved);
                        } 
                        break;

                    case "StakeholderValue":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.StakeholderValue.Remove(toBeRemoved);
                        } 
                        break;

                    case "StakeholderValueMap":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.StakeholderValueMap.Remove(toBeRemoved);
                        } 
                        break;

                    case "TopElement":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.TopElement = null;
                        }
                        break;

                    case "ValueGroup":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ValueGroup.Remove(toBeRemoved);
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
                    case "IterationSetup":
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
                    case "IterationSetup":
                        if (kvp.Value.Except(ids).Any())
                        {
                            result = true;
                        }
                        break;

                    case "Option":
                        if (!kvp.Value.Intersect(ids).Any())
                        {
                            result = true;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.Iteration"/> from a <see cref="Iteration"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.Iteration"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.Iteration(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as Iteration;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.ActualFiniteStateList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.ActualFiniteStateList.Add(copy.Value.Iid);
            }

            var copyDefaultOption = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultOption);
            this.DefaultOption = copyDefaultOption.Value == null ? original.DefaultOption : copyDefaultOption.Value.Iid;

            foreach (var guid in original.DiagramCanvas)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.DiagramCanvas.Add(copy.Value.Iid);
            }

            foreach (var guid in original.DomainFileStore)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.DomainFileStore.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Element)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Element.Add(copy.Value.Iid);
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

            foreach (var guid in original.ExternalIdentifierMap)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.ExternalIdentifierMap.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Goal)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Goal.Add(copy.Value.Iid);
            }

            var copyIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.IterationSetup);
            this.IterationSetup = copyIterationSetup.Value == null ? original.IterationSetup : copyIterationSetup.Value.Iid;

            this.ModifiedOn = original.ModifiedOn;

            foreach (var orderedItem in original.Option)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {orderedItem.V}");
                }
                this.Option.Add(new OrderedItem { K = orderedItem.K, V = copy.Value.Iid });
            }

            foreach (var guid in original.PossibleFiniteStateList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.PossibleFiniteStateList.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Publication)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Publication.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Relationship)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Relationship.Add(copy.Value.Iid);
            }

            foreach (var guid in original.RequirementsSpecification)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.RequirementsSpecification.Add(copy.Value.Iid);
            }

            foreach (var guid in original.RuleVerificationList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.RuleVerificationList.Add(copy.Value.Iid);
            }

            foreach (var guid in original.SharedDiagramStyle)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.SharedDiagramStyle.Add(copy.Value.Iid);
            }

            this.SourceIterationIid = original.SourceIterationIid;

            foreach (var guid in original.Stakeholder)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.Stakeholder.Add(copy.Value.Iid);
            }

            foreach (var guid in original.StakeholderValue)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.StakeholderValue.Add(copy.Value.Iid);
            }

            foreach (var guid in original.StakeholderValueMap)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.StakeholderValueMap.Add(copy.Value.Iid);
            }

            this.ThingPreference = original.ThingPreference;

            var copyTopElement = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.TopElement);
            this.TopElement = copyTopElement.Value == null ? original.TopElement : copyTopElement.Value.Iid;

            foreach (var guid in original.ValueGroup)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException($"The copy could not be found for {guid}");
                }

                this.ValueGroup.Add(copy.Value.Iid);
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

            var copyIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.IterationSetup);
            if (copyIterationSetup.Key != null)
            {
                this.IterationSetup = copyIterationSetup.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
