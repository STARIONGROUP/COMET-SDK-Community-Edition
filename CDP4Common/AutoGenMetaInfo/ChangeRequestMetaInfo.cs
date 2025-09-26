// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeRequestMetaInfo.cs" company="Starion Group S.A.">
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

namespace CDP4Common.MetaInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Common.Validation;

    /// <summary>
    /// This a class that holds meta info for <see cref="ChangeRequest"/>.
    /// </summary>
    public partial class ChangeRequestMetaInfo : IChangeRequestMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, IEnumerable<Guid>>>
        {
            { "ApprovedBy", changeRequest => changeRequest.ApprovedBy },
            { "Discussion", changeRequest => changeRequest.Discussion },
            { "RelatedThing", changeRequest => changeRequest.RelatedThing },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ChangeRequest>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ChangeRequest>>
        {
            { "ApprovedBy", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.ApprovedBy != null, "The 'ApprovedBy' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "Category", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.Category != null, "The 'Category' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "Content", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => !string.IsNullOrWhiteSpace(item.Content), "The 'Content' property of a 'ChangeRequest' is mandatory and cannot be empty or null.") },
            { "Discussion", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.Discussion != null, "The 'Discussion' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "LanguageCode", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => !string.IsNullOrWhiteSpace(item.LanguageCode), "The 'LanguageCode' property of a 'ChangeRequest' is mandatory and cannot be empty or null.") },
            { "RelatedThing", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.RelatedThing != null, "The 'RelatedThing' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "ShortName", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => !string.IsNullOrWhiteSpace(item.ShortName), "The 'ShortName' property of a 'ChangeRequest' is mandatory and cannot be empty or null.") },
            { "SourceAnnotation", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => item.SourceAnnotation != null, "The 'SourceAnnotation' property of a 'ChangeRequest' is mandatory and cannot be null.") },
            { "Title", new DtoValidationHelper<CDP4Common.DTO.ChangeRequest>(item => !string.IsNullOrWhiteSpace(item.Title), "The 'Title' property of a 'ChangeRequest' is mandatory and cannot be empty or null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing changeRequest)
        {
            this.Validate(changeRequest, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing changeRequest, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.ChangeRequest)changeRequest);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing changeRequest)
        {
            return this.TryValidate(changeRequest, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing changeRequest, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.ChangeRequest)changeRequest));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.ChangeRequest"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing changeRequest, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ChangeRequest'");
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.ChangeRequest)changeRequest);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </summary>
        /// <param name="changeRequest">
        /// The <see cref="CDP4Common.DTO.ChangeRequest"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing changeRequest, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ChangeRequest'");
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.ChangeRequest)changeRequest);
        }

        /// <summary>
        /// The CDP version property map.
        /// </summary>
        private readonly Dictionary<string, string> cdpVersionedProperties = new Dictionary<string, string>
        {
            { "Actor", "1.3.0" },
            { "ExcludedDomain", "1.1.0" },
            { "ExcludedPerson", "1.1.0" },
            { "ModifiedOn", "1.1.0" },
            { "ThingPreference", "1.2.0" },
        };

        /// <summary>
        /// The containment property to type name map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> containmentTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ApprovedBy", new PropertyMetaInfo("ApprovedBy", "Approval", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Discussion", new PropertyMetaInfo("Discussion", "EngineeringModelDataDiscussionItem", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "RelatedThing", new PropertyMetaInfo("RelatedThing", "ModellingThingReference", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="ChangeRequest"/> class
        /// </summary>
        public IEnumerable<PropertyMetaInfo> Properties
        {
            get
            {
                foreach (var propertyMetaInfo in this.containmentTypeMap)
                {
                    yield return propertyMetaInfo.Value;
                }

                foreach (var propertyMetaInfo in this.propertyTypeMap)
                {
                    yield return propertyMetaInfo.Value;
                }
            }
        }

        /// <summary>
        /// The property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ChangeRequest, object>>
        {
            { "Actor", thing => thing.Actor },
            { "ApprovedBy", thing => thing.ApprovedBy },
            { "Author", thing => thing.Author },
            { "Category", thing => thing.Category },
            { "Classification", thing => thing.Classification },
            { "ClassKind", thing => thing.ClassKind },
            { "Content", thing => thing.Content },
            { "CreatedOn", thing => thing.CreatedOn },
            { "Discussion", thing => thing.Discussion },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "Iid", thing => thing.Iid },
            { "LanguageCode", thing => thing.LanguageCode },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Owner", thing => thing.Owner },
            { "PrimaryAnnotatedThing", thing => thing.PrimaryAnnotatedThing },
            { "RelatedThing", thing => thing.RelatedThing },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "ShortName", thing => thing.ShortName },
            { "SourceAnnotation", thing => thing.SourceAnnotation },
            { "Status", thing => thing.Status },
            { "ThingPreference", thing => thing.ThingPreference },
            { "Title", thing => thing.Title },
        };

        /// <summary>
        /// The property type map.
        /// </summary>
        /// <remarks>
        /// Contained properties are excluded for this map
        /// </remarks>
        private readonly Dictionary<string, PropertyMetaInfo> propertyTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "Actor", new PropertyMetaInfo("Actor", "Person", PropertyKind.Scalar, AggregationKind.None, false, false, false, 0, "1", false) },
            { "Author", new PropertyMetaInfo("Author", "Participant", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Category", new PropertyMetaInfo("Category", "Category", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Classification", new PropertyMetaInfo("Classification", "CDP4Common.ReportingData.AnnotationClassificationKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Content", new PropertyMetaInfo("Content", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "CreatedOn", new PropertyMetaInfo("CreatedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "LanguageCode", new PropertyMetaInfo("LanguageCode", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Owner", new PropertyMetaInfo("Owner", "DomainOfExpertise", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "PrimaryAnnotatedThing", new PropertyMetaInfo("PrimaryAnnotatedThing", "ModellingThingReference", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ShortName", new PropertyMetaInfo("ShortName", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "SourceAnnotation", new PropertyMetaInfo("SourceAnnotation", "ModellingAnnotationItem", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Status", new PropertyMetaInfo("Status", "CDP4Common.ReportingData.AnnotationStatusKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ThingPreference", new PropertyMetaInfo("ThingPreference", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "Title", new PropertyMetaInfo("Title", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "ApprovedBy", (value) => (Guid)value },
            { "Category", (value) => (Guid)value },
            { "Discussion", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "RelatedThing", (value) => (Guid)value },
            { "SourceAnnotation", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.ChangeRequest, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.ChangeRequest, object>>
        {
            { "Actor", (changeRequest, value) => changeRequest.Actor = value == null ? (Guid?)null : (Guid)value },
            { "Author", (changeRequest, value) => changeRequest.Author = (Guid)value },
            { "Classification", (changeRequest, value) => changeRequest.Classification = (AnnotationClassificationKind)value },
            { "Content", (changeRequest, value) => changeRequest.Content = value.ToString() },
            { "CreatedOn", (changeRequest, value) => changeRequest.CreatedOn = (DateTime)value },
            { "Iid", (changeRequest, value) => changeRequest.Iid = (Guid)value },
            { "LanguageCode", (changeRequest, value) => changeRequest.LanguageCode = value.ToString() },
            { "ModifiedOn", (changeRequest, value) => changeRequest.ModifiedOn = (DateTime)value },
            { "Owner", (changeRequest, value) => changeRequest.Owner = (Guid)value },
            { "PrimaryAnnotatedThing", (changeRequest, value) => changeRequest.PrimaryAnnotatedThing = value == null ? (Guid?)null : (Guid)value },
            { "ShortName", (changeRequest, value) => changeRequest.ShortName = value.ToString() },
            { "Status", (changeRequest, value) => changeRequest.Status = (AnnotationStatusKind)value },
            { "ThingPreference", (changeRequest, value) => changeRequest.ThingPreference = value == null ? (string)null : value.ToString() },
            { "Title", (changeRequest, value) => changeRequest.Title = value.ToString() },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "EngineeringModel", new PropertyMetaInfo("ModellingAnnotation", "ModellingAnnotationItem", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets a value indicating whether this type should be deprecated upon Delete.
        /// </summary>
        public bool IsDeprecatableThing
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this type is a top container.
        /// </summary>
        public bool IsTopContainer
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the base type name of this class.
        /// </summary>
        public string BaseType
        {
            get { return "ContractDeviation"; }
        }

        /// <summary>
        /// Gets the CDP class version.
        /// </summary>
        public string ClassVersion
        {
            get { return "1.1.0"; }
        }

        /// <summary>
        /// Get the data model version of the supplied property.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// The version number as specified property otherwise the default data model version.
        /// </returns>
        public string GetPropertyVersion(string propertyName)
        {
            return this.cdpVersionedProperties.ContainsKey(propertyName) ? this.cdpVersionedProperties[propertyName] : null;
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.ChangeRequest"/> containment property type from the supplied property name.
        /// </summary>
        /// <param name="propertyName">
        /// The containment property name.
        /// </param>
        /// <returns>
        /// The type name of the containment.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public PropertyMetaInfo GetContainmentType(string propertyName)
        {
            if (!this.containmentTypeMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ChangeRequest'");
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.ChangeRequest"/> property type from the supplied property name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <returns>
        /// The <see cref="PropertyMetaInfo"/> or null if it does not exist.
        /// </returns>
        public PropertyMetaInfo GetPropertyMetaInfo(string propertyName)
        {
            if (this.containmentTypeMap.ContainsKey(propertyName))
            {
                return this.containmentTypeMap[propertyName];
            }

            if (this.propertyTypeMap.ContainsKey(propertyName))
            {
                return this.propertyTypeMap[propertyName];
            }

            return null;
        }

        /// <summary>
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.ChangeRequest"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.ChangeRequest"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.ChangeRequest"/> is scalar.
        /// </summary>
        /// <param name="propertyName">
        /// Name of the property for which to check if it is scalar.
        /// </param>
        /// <returns>
        /// True if the supplied property name is a scalar property.
        /// </returns>
        public bool IsScalar(string propertyName)
        {
            if (this.propertyTypeMap.ContainsKey(propertyName))
            {
                var propertyInfo = this.propertyTypeMap[propertyName];
                return propertyInfo.PropertyKind == PropertyKind.Scalar || propertyInfo.PropertyKind == PropertyKind.ValueArray;
            }

            return false;
        }

        /// <summary>
        /// Apply the value update to the supplied property name of the updatable <see cref="CDP4Common.DTO.Thing"/> instance.
        /// </summary>
        /// <param name="updatableThing">
        /// The <see cref="CDP4Common.DTO.Thing"/> instance to which to apply the property value update.
        /// </param>
        /// <param name="propertyName">
        /// The property name of the <see cref="CDP4Common.DTO.Thing"/> to which to apply the value update.
        /// </param>
        /// <param name="value">
        /// The updated value to apply.
        /// </param>
        /// <returns>
        /// True if the value update was successfully applied.
        /// </returns>
        public bool ApplyPropertyUpdate(CDP4Common.DTO.Thing updatableThing, string propertyName, object value)
        {
            if (updatableThing == null || !this.IsScalar(propertyName))
            {
                return false;
            }

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.ChangeRequest)updatableThing, value);

            return true;
        }

        /// <summary>
        /// Returns a deserialized object from the supplied value string for the property name.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="value">
        /// The value to deserialize from its current string form.
        /// </param>
        /// <returns>
        /// A deserialized object from the supplied value.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public object DeserializeCollectionValue(string propertyName, object value)
        {
            if (!this.collectionPropertyValueDeserializationMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ChangeRequest'");
            }

            return this.collectionPropertyValueDeserializationMap[propertyName](value);
        }

        /// <summary>
        /// Returns the value of the property of a Thing
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="thing">
        /// The Thing object
        /// </param>
        /// <returns>
        /// The value of the property of a Thing
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Thing"/>.
        /// </exception>
        public object GetValue(string propertyName, CDP4Common.DTO.Thing thing)
        {
            if (!this.propertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ChangeRequest'");
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.ChangeRequest)thing);
        }

        /// <summary>
        /// Gets the collection of property names for a <see cref="Thing"/>
        /// </summary>
        public IEnumerable<string> GetPropertyNameCollection()
        {
            var collection = new List<string>(this.propertyTypeMap.Keys);
            collection.AddRange(this.containmentTypeMap.Keys);
            return collection;
        }

        /// <summary>
        /// Instantiates a <see cref="CDP4Common.DTO.ChangeRequest"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.ChangeRequest(guid, revisionNumber);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
