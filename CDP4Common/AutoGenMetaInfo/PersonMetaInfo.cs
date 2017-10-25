// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonMetaInfo.cs" company="RHEA System S.A.">
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
    /// This a class that holds meta info for <see cref="Person"/>.
    /// </summary>
    public partial class PersonMetaInfo : IPersonMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.Person, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Person, IEnumerable<Guid>>>
        {
            { "EmailAddress", person => person.EmailAddress },
            { "TelephoneNumber", person => person.TelephoneNumber },
            { "UserPreference", person => person.UserPreference },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.Person, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Person, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.Person"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.Person>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.Person>>
        {
            { "EmailAddress", new DtoValidationHelper<CDP4Common.DTO.Person>(item => item.EmailAddress != null, "The 'EmailAddress' property of a 'Person' is mandatory and cannot be null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.Person>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'Person' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.Person>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'Person' is mandatory and cannot be null.") },
            { "GivenName", new DtoValidationHelper<CDP4Common.DTO.Person>(item => !string.IsNullOrWhiteSpace(item.GivenName), "The 'GivenName' property of a 'Person' is mandatory and cannot be empty or null.") },
            { "ShortName", new DtoValidationHelper<CDP4Common.DTO.Person>(item => !string.IsNullOrWhiteSpace(item.ShortName), "The 'ShortName' property of a 'Person' is mandatory and cannot be empty or null.") },
            { "Surname", new DtoValidationHelper<CDP4Common.DTO.Person>(item => !string.IsNullOrWhiteSpace(item.Surname), "The 'Surname' property of a 'Person' is mandatory and cannot be empty or null.") },
            { "TelephoneNumber", new DtoValidationHelper<CDP4Common.DTO.Person>(item => item.TelephoneNumber != null, "The 'TelephoneNumber' property of a 'Person' is mandatory and cannot be null.") },
            { "UserPreference", new DtoValidationHelper<CDP4Common.DTO.Person>(item => item.UserPreference != null, "The 'UserPreference' property of a 'Person' is mandatory and cannot be null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing person)
        {
            this.Validate(person, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing person, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.Person)person);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing person)
        {
            return this.TryValidate(person, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing person, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.Person)person));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.Person"/>.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Person"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Person"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing person, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Person'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.Person)person);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.Person"/>.
        /// </summary>
        /// <param name="person">
        /// The <see cref="CDP4Common.DTO.Person"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.Person"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing person, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Person'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.Person)person);
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
            { "EmailAddress", new PropertyMetaInfo("EmailAddress", "EmailAddress", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "TelephoneNumber", new PropertyMetaInfo("TelephoneNumber", "TelephoneNumber", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "UserPreference", new PropertyMetaInfo("UserPreference", "UserPreference", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="Person"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.Person, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.Person, object>>
        {
            { "ClassKind", thing => thing.ClassKind },
            { "DefaultDomain", thing => thing.DefaultDomain },
            { "DefaultEmailAddress", thing => thing.DefaultEmailAddress },
            { "DefaultTelephoneNumber", thing => thing.DefaultTelephoneNumber },
            { "EmailAddress", thing => thing.EmailAddress },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "GivenName", thing => thing.GivenName },
            { "Iid", thing => thing.Iid },
            { "IsActive", thing => thing.IsActive },
            { "IsDeprecated", thing => thing.IsDeprecated },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Organization", thing => thing.Organization },
            { "OrganizationalUnit", thing => thing.OrganizationalUnit },
            { "Password", thing => thing.Password },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "Role", thing => thing.Role },
            { "Salt", thing => thing.Salt },
            { "ShortName", thing => thing.ShortName },
            { "Surname", thing => thing.Surname },
            { "TelephoneNumber", thing => thing.TelephoneNumber },
            { "UserPreference", thing => thing.UserPreference },
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
            { "DefaultDomain", new PropertyMetaInfo("DefaultDomain", "DomainOfExpertise", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "DefaultEmailAddress", new PropertyMetaInfo("DefaultEmailAddress", "EmailAddress", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "DefaultTelephoneNumber", new PropertyMetaInfo("DefaultTelephoneNumber", "TelephoneNumber", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "GivenName", new PropertyMetaInfo("GivenName", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "IsActive", new PropertyMetaInfo("IsActive", "bool", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "IsDeprecated", new PropertyMetaInfo("IsDeprecated", "bool", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Name", new PropertyMetaInfo("Name", "string", PropertyKind.Scalar, AggregationKind.None, true, false, true, 1, "1", false) },
            { "Organization", new PropertyMetaInfo("Organization", "Organization", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "OrganizationalUnit", new PropertyMetaInfo("OrganizationalUnit", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "Password", new PropertyMetaInfo("Password", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Role", new PropertyMetaInfo("Role", "PersonRole", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "Salt", new PropertyMetaInfo("Salt", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ShortName", new PropertyMetaInfo("ShortName", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Surname", new PropertyMetaInfo("Surname", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "EmailAddress", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "TelephoneNumber", (value) => (Guid)value },
            { "UserPreference", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.Person, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.Person, object>>
        {
            { "DefaultDomain", (person, value) => person.DefaultDomain = value == null ? (Guid?)null : (Guid)value },
            { "DefaultEmailAddress", (person, value) => person.DefaultEmailAddress = value == null ? (Guid?)null : (Guid)value },
            { "DefaultTelephoneNumber", (person, value) => person.DefaultTelephoneNumber = value == null ? (Guid?)null : (Guid)value },
            { "GivenName", (person, value) => person.GivenName = value.ToString() },
            { "Iid", (person, value) => person.Iid = (Guid)value },
            { "IsActive", (person, value) => person.IsActive = (bool)value },
            { "IsDeprecated", (person, value) => person.IsDeprecated = (bool)value },
            { "ModifiedOn", (person, value) => person.ModifiedOn = (DateTime)value },
            { "Organization", (person, value) => person.Organization = value == null ? (Guid?)null : (Guid)value },
            { "OrganizationalUnit", (person, value) => person.OrganizationalUnit = value == null ? (string)null : value.ToString() },
            { "Password", (person, value) => person.Password = value == null ? (string)null : value.ToString() },
            { "Role", (person, value) => person.Role = value == null ? (Guid?)null : (Guid)value },
            { "Salt", (person, value) => person.Salt = value == null ? (string)null : value.ToString() },
            { "ShortName", (person, value) => person.ShortName = value.ToString() },
            { "Surname", (person, value) => person.Surname = value.ToString() },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "SiteDirectory", new PropertyMetaInfo("Person", "Person", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets a value indicating whether this type should be deprecated upon Delete.
        /// </summary>
        public bool IsDeprecatableThing
        {
            get
            {
                return true;
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
            get { return "Thing"; }
        }

        /// <summary>
        /// Gets the CDP class version.
        /// </summary>
        public string ClassVersion
        {
            get { return null; }
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
        /// Returns the <see cref="CDP4Common.DTO.Person"/> containment property type from the supplied property name.
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
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'Person'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.Person"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.Person"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.Person"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.Person"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.Person"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.Person"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.Person)updatableThing, value);

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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'Person'", propertyName));
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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'Person'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.Person)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.Person"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.Person(guid, revisionNumber);
        }
    }
}
