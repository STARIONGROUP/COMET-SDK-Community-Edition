// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramObjectMetaInfo.cs" company="RHEA System S.A.">
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
    /// This a class that holds meta info for <see cref="DiagramObject"/>.
    /// </summary>
    public partial class DiagramObjectMetaInfo : IDiagramObjectMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.DiagramObject, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.DiagramObject, IEnumerable<Guid>>>
        {
            { "Bounds", diagramObject => diagramObject.Bounds },
            { "DiagramElement", diagramObject => diagramObject.DiagramElement },
            { "LocalStyle", diagramObject => diagramObject.LocalStyle },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.DiagramObject, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.DiagramObject, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.DiagramObject>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.DiagramObject>>
        {
            { "Bounds", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => item.Bounds != null, "The 'Bounds' property of a 'DiagramObject' is mandatory and cannot be null.") },
            { "DiagramElement", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => item.DiagramElement != null, "The 'DiagramElement' property of a 'DiagramObject' is mandatory and cannot be null.") },
            { "Documentation", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => !string.IsNullOrWhiteSpace(item.Documentation), "The 'Documentation' property of a 'DiagramObject' is mandatory and cannot be empty or null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'DiagramObject' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'DiagramObject' is mandatory and cannot be null.") },
            { "LocalStyle", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => item.LocalStyle != null, "The 'LocalStyle' property of a 'DiagramObject' is mandatory and cannot be null.") },
            { "Name", new DtoValidationHelper<CDP4Common.DTO.DiagramObject>(item => !string.IsNullOrWhiteSpace(item.Name), "The 'Name' property of a 'DiagramObject' is mandatory and cannot be empty or null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing diagramObject)
        {
            this.Validate(diagramObject, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing diagramObject, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.DiagramObject)diagramObject);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing diagramObject)
        {
            return this.TryValidate(diagramObject, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing diagramObject, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.DiagramObject)diagramObject));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.DiagramObject"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing diagramObject, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'DiagramObject'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.DiagramObject)diagramObject);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </summary>
        /// <param name="diagramObject">
        /// The <see cref="CDP4Common.DTO.DiagramObject"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing diagramObject, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'DiagramObject'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.DiagramObject)diagramObject);
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
            { "Bounds", new PropertyMetaInfo("Bounds", "Bounds", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "1", true) },
            { "DiagramElement", new PropertyMetaInfo("DiagramElement", "DiagramElementThing", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "LocalStyle", new PropertyMetaInfo("LocalStyle", "OwnedStyle", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="DiagramObject"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.DiagramObject, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.DiagramObject, object>>
        {
            { "Bounds", thing => thing.Bounds },
            { "ClassKind", thing => thing.ClassKind },
            { "DepictedThing", thing => thing.DepictedThing },
            { "DiagramElement", thing => thing.DiagramElement },
            { "Documentation", thing => thing.Documentation },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "Iid", thing => thing.Iid },
            { "LocalStyle", thing => thing.LocalStyle },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Name", thing => thing.Name },
            { "Resolution", thing => thing.Resolution },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "SharedStyle", thing => thing.SharedStyle },
        };

        /// <summary>
        /// The property type map.
        /// </summary>
        /// <remarks>
        /// Contained properties are excluded for this map
        /// </remarks>
        private readonly Dictionary<string, PropertyMetaInfo> propertyTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "DepictedThing", new PropertyMetaInfo("DepictedThing", "Thing", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "Documentation", new PropertyMetaInfo("Documentation", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Name", new PropertyMetaInfo("Name", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Resolution", new PropertyMetaInfo("Resolution", "float", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "SharedStyle", new PropertyMetaInfo("SharedStyle", "SharedStyle", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "Bounds", (value) => (Guid)value },
            { "DiagramElement", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "LocalStyle", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.DiagramObject, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.DiagramObject, object>>
        {
            { "DepictedThing", (diagramObject, value) => diagramObject.DepictedThing = value == null ? (Guid?)null : (Guid)value },
            { "Documentation", (diagramObject, value) => diagramObject.Documentation = value.ToString() },
            { "Iid", (diagramObject, value) => diagramObject.Iid = (Guid)value },
            { "ModifiedOn", (diagramObject, value) => diagramObject.ModifiedOn = (DateTime)value },
            { "Name", (diagramObject, value) => diagramObject.Name = value.ToString() },
            { "Resolution", (diagramObject, value) => diagramObject.Resolution = (float)value },
            { "SharedStyle", (diagramObject, value) => diagramObject.SharedStyle = value == null ? (Guid?)null : (Guid)value },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "DiagramCanvas", new PropertyMetaInfo("DiagramElement", "DiagramElementThing", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DiagramEdge", new PropertyMetaInfo("DiagramElement", "DiagramElementThing", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DiagramObject", new PropertyMetaInfo("DiagramElement", "DiagramElementThing", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
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
            get { return "DiagramShape"; }
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
        /// Returns the <see cref="CDP4Common.DTO.DiagramObject"/> containment property type from the supplied property name.
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
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'DiagramObject'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.DiagramObject"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.DiagramObject"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.DiagramObject"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.DiagramObject"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.DiagramObject)updatableThing, value);

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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'DiagramObject'", propertyName));
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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'DiagramObject'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.DiagramObject)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.DiagramObject"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.DiagramObject(guid, revisionNumber);
        }
    }
}
