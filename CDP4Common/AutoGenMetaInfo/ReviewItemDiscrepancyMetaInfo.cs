// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReviewItemDiscrepancyMetaInfo.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated MetaInfo class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.MetaInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Common.Validation;

    /// <summary>
    /// This a class that holds meta info for <see cref="ReviewItemDiscrepancy"/>.
    /// </summary>
    public partial class ReviewItemDiscrepancyMetaInfo : IReviewItemDiscrepancyMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, IEnumerable<Guid>>>
        {
            { "ApprovedBy", reviewItemDiscrepancy => reviewItemDiscrepancy.ApprovedBy },
            { "Discussion", reviewItemDiscrepancy => reviewItemDiscrepancy.Discussion },
            { "RelatedThing", reviewItemDiscrepancy => reviewItemDiscrepancy.RelatedThing },
            { "Solution", reviewItemDiscrepancy => reviewItemDiscrepancy.Solution },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>>
        {
            { "ApprovedBy", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.ApprovedBy != null, "The 'ApprovedBy' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "Category", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.Category != null, "The 'Category' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "Content", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => !string.IsNullOrWhiteSpace(item.Content), "The 'Content' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be empty or null.") },
            { "Discussion", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.Discussion != null, "The 'Discussion' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "LanguageCode", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => !string.IsNullOrWhiteSpace(item.LanguageCode), "The 'LanguageCode' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be empty or null.") },
            { "RelatedThing", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.RelatedThing != null, "The 'RelatedThing' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "ShortName", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => !string.IsNullOrWhiteSpace(item.ShortName), "The 'ShortName' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be empty or null.") },
            { "Solution", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.Solution != null, "The 'Solution' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "SourceAnnotation", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => item.SourceAnnotation != null, "The 'SourceAnnotation' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be null.") },
            { "Title", new DtoValidationHelper<CDP4Common.DTO.ReviewItemDiscrepancy>(item => !string.IsNullOrWhiteSpace(item.Title), "The 'Title' property of a 'ReviewItemDiscrepancy' is mandatory and cannot be empty or null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing reviewItemDiscrepancy)
        {
            this.Validate(reviewItemDiscrepancy, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing reviewItemDiscrepancy, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.ReviewItemDiscrepancy)reviewItemDiscrepancy);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing reviewItemDiscrepancy)
        {
            return this.TryValidate(reviewItemDiscrepancy, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing reviewItemDiscrepancy, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.ReviewItemDiscrepancy)reviewItemDiscrepancy));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing reviewItemDiscrepancy, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'ReviewItemDiscrepancy'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.ReviewItemDiscrepancy)reviewItemDiscrepancy);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </summary>
        /// <param name="reviewItemDiscrepancy">
        /// The <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing reviewItemDiscrepancy, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'ReviewItemDiscrepancy'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.ReviewItemDiscrepancy)reviewItemDiscrepancy);
        }

        /// <summary>
        /// The CDP version property map.
        /// </summary>
        private readonly Dictionary<string, string> cdpVersionedProperties = new Dictionary<string, string>
        {
            { "ExcludedDomain", "1.1.0" },
            { "ExcludedPerson", "1.1.0" },
            { "ModifiedOn", "1.1.0" },
        };

        /// <summary>
        /// The containment property to type name map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> containmentTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ApprovedBy", new PropertyMetaInfo("ApprovedBy", "Approval", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Discussion", new PropertyMetaInfo("Discussion", "EngineeringModelDataDiscussionItem", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "RelatedThing", new PropertyMetaInfo("RelatedThing", "ModellingThingReference", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Solution", new PropertyMetaInfo("Solution", "Solution", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="ReviewItemDiscrepancy"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ReviewItemDiscrepancy, object>>
        {
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
            { "Solution", thing => thing.Solution },
            { "SourceAnnotation", thing => thing.SourceAnnotation },
            { "Status", thing => thing.Status },
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
            { "Solution", (value) => (Guid)value },
            { "SourceAnnotation", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.ReviewItemDiscrepancy, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.ReviewItemDiscrepancy, object>>
        {
            { "Author", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Author = (Guid)value },
            { "Classification", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Classification = (AnnotationClassificationKind)value },
            { "Content", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Content = value.ToString() },
            { "CreatedOn", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.CreatedOn = (DateTime)value },
            { "Iid", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Iid = (Guid)value },
            { "LanguageCode", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.LanguageCode = value.ToString() },
            { "ModifiedOn", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.ModifiedOn = (DateTime)value },
            { "Owner", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Owner = (Guid)value },
            { "PrimaryAnnotatedThing", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.PrimaryAnnotatedThing = value == null ? (Guid?)null : (Guid)value },
            { "ShortName", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.ShortName = value.ToString() },
            { "Status", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Status = (AnnotationStatusKind)value },
            { "Title", (reviewItemDiscrepancy, value) => reviewItemDiscrepancy.Title = value.ToString() },
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
            get { return "ModellingAnnotationItem"; }
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
        /// Returns the <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> containment property type from the supplied property name.
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
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'ReviewItemDiscrepancy'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.ReviewItemDiscrepancy)updatableThing, value);

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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'ReviewItemDiscrepancy'", propertyName));
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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'ReviewItemDiscrepancy'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.ReviewItemDiscrepancy)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.ReviewItemDiscrepancy"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.ReviewItemDiscrepancy(guid, revisionNumber);
        }
    }
}
