// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    /// A Data Transfer Object representation of the <see cref="ReferenceDataLibrary"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class ReferenceDataLibrary : DefinedThing, IParticipantAffectedAccessThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
        /// </summary>
        protected ReferenceDataLibrary()
        {
            this.BaseQuantityKind = new List<OrderedItem>();
            this.BaseUnit = new List<Guid>();
            this.Constant = new List<Guid>();
            this.DefinedCategory = new List<Guid>();
            this.FileType = new List<Guid>();
            this.Glossary = new List<Guid>();
            this.ParameterType = new List<Guid>();
            this.ReferenceSource = new List<Guid>();
            this.Rule = new List<Guid>();
            this.Scale = new List<Guid>();
            this.Unit = new List<Guid>();
            this.UnitPrefix = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceDataLibrary"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ReferenceDataLibrary(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.BaseQuantityKind = new List<OrderedItem>();
            this.BaseUnit = new List<Guid>();
            this.Constant = new List<Guid>();
            this.DefinedCategory = new List<Guid>();
            this.FileType = new List<Guid>();
            this.Glossary = new List<Guid>();
            this.ParameterType = new List<Guid>();
            this.ReferenceSource = new List<Guid>();
            this.Rule = new List<Guid>();
            this.Scale = new List<Guid>();
            this.Unit = new List<Guid>();
            this.UnitPrefix = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the list of ordered unique identifiers of the referenced BaseQuantityKind instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<OrderedItem> BaseQuantityKind { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced BaseUnit instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> BaseUnit { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Constant instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Constant { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DefinedCategory instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> DefinedCategory { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained FileType instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> FileType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Glossary instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Glossary { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ParameterType instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ParameterType { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ReferenceSource instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ReferenceSource { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced RequiredRdl.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public virtual Guid? RequiredRdl { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Rule instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Rule { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Scale instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Scale { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Unit instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> Unit { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained UnitPrefix instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> UnitPrefix { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ReferenceDataLibrary"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Constant);
                containers.Add(this.DefinedCategory);
                containers.Add(this.FileType);
                containers.Add(this.Glossary);
                containers.Add(this.ParameterType);
                containers.Add(this.ReferenceSource);
                containers.Add(this.Rule);
                containers.Add(this.Scale);
                containers.Add(this.Unit);
                containers.Add(this.UnitPrefix);
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

            dictionary.Add("Alias", this.Alias);

            dictionary.Add("BaseUnit", this.BaseUnit);

            dictionary.Add("Constant", this.Constant);

            dictionary.Add("DefinedCategory", this.DefinedCategory);

            dictionary.Add("Definition", this.Definition);

            dictionary.Add("ExcludedDomain", this.ExcludedDomain);

            dictionary.Add("ExcludedPerson", this.ExcludedPerson);

            dictionary.Add("FileType", this.FileType);

            dictionary.Add("Glossary", this.Glossary);

            dictionary.Add("HyperLink", this.HyperLink);

            dictionary.Add("ParameterType", this.ParameterType);

            dictionary.Add("ReferenceSource", this.ReferenceSource);

            if (this.RequiredRdl != null)
            {
                dictionary.Add("RequiredRdl", new [] { this.RequiredRdl.Value });
            }

            dictionary.Add("Rule", this.Rule);

            dictionary.Add("Scale", this.Scale);

            dictionary.Add("Unit", this.Unit);

            dictionary.Add("UnitPrefix", this.UnitPrefix);

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

                            case "BaseUnit":
                                this.BaseUnit.Remove(id);
                                break;

                            case "Constant":
                                this.Constant.Remove(id);
                                break;

                            case "DefinedCategory":
                                this.DefinedCategory.Remove(id);
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

                            case "FileType":
                                this.FileType.Remove(id);
                                break;

                            case "Glossary":
                                this.Glossary.Remove(id);
                                break;

                            case "HyperLink":
                                this.HyperLink.Remove(id);
                                break;

                            case "ParameterType":
                                this.ParameterType.Remove(id);
                                break;

                            case "ReferenceSource":
                                this.ReferenceSource.Remove(id);
                                break;

                            case "RequiredRdl":
                                this.RequiredRdl = null;
                                break;

                            case "Rule":
                                this.Rule.Remove(id);
                                break;

                            case "Scale":
                                this.Scale.Remove(id);
                                break;

                            case "Unit":
                                this.Unit.Remove(id);
                                break;

                            case "UnitPrefix":
                                this.UnitPrefix.Remove(id);
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
                    case "Alias":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Alias.Remove(toBeRemoved);
                        } 
                        break;

                    case "BaseUnit":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.BaseUnit.Remove(toBeRemoved);
                        } 
                        break;

                    case "Constant":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Constant.Remove(toBeRemoved);
                        } 
                        break;

                    case "DefinedCategory":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.DefinedCategory.Remove(toBeRemoved);
                        } 
                        break;

                    case "Definition":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Definition.Remove(toBeRemoved);
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

                    case "FileType":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.FileType.Remove(toBeRemoved);
                        } 
                        break;

                    case "Glossary":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Glossary.Remove(toBeRemoved);
                        } 
                        break;

                    case "HyperLink":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.HyperLink.Remove(toBeRemoved);
                        } 
                        break;

                    case "ParameterType":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ParameterType.Remove(toBeRemoved);
                        } 
                        break;

                    case "ReferenceSource":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.ReferenceSource.Remove(toBeRemoved);
                        } 
                        break;

                    case "RequiredRdl":
                        if (referencedProperty.Value.Except(ids).Any())
                        {
                            this.RequiredRdl = null;
                        }
                        break;

                    case "Rule":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Rule.Remove(toBeRemoved);
                        } 
                        break;

                    case "Scale":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Scale.Remove(toBeRemoved);
                        } 
                        break;

                    case "Unit":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.Unit.Remove(toBeRemoved);
                        } 
                        break;

                    case "UnitPrefix":
                        foreach (var toBeRemoved in referencedProperty.Value.Except(ids).ToList())
                        {
                            this.UnitPrefix.Remove(toBeRemoved);
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
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
