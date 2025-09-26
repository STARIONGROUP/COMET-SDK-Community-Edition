// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetMetaInfo.cs" company="Starion Group S.A.">
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
    /// This a class that holds meta info for <see cref="ParameterValueSet"/>.
    /// </summary>
    public partial class ParameterValueSetMetaInfo : IParameterValueSetMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, IEnumerable<Guid>>>();

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>>
        {
            { "Computed", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.Computed != null && item.Computed.Any(), "The 'Computed' property of a 'ParameterValueSet' is mandatory and must have at least one entry.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'ParameterValueSet' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'ParameterValueSet' is mandatory and cannot be null.") },
            { "Formula", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.Formula != null && item.Formula.Any(), "The 'Formula' property of a 'ParameterValueSet' is mandatory and must have at least one entry.") },
            { "Manual", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.Manual != null && item.Manual.Any(), "The 'Manual' property of a 'ParameterValueSet' is mandatory and must have at least one entry.") },
            { "Published", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.Published != null && item.Published.Any(), "The 'Published' property of a 'ParameterValueSet' is mandatory and must have at least one entry.") },
            { "Reference", new DtoValidationHelper<CDP4Common.DTO.ParameterValueSet>(item => item.Reference != null && item.Reference.Any(), "The 'Reference' property of a 'ParameterValueSet' is mandatory and must have at least one entry.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing parameterValueSet)
        {
            this.Validate(parameterValueSet, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing parameterValueSet, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.ParameterValueSet)parameterValueSet);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing parameterValueSet)
        {
            return this.TryValidate(parameterValueSet, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing parameterValueSet, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.ParameterValueSet)parameterValueSet));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.ParameterValueSet"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing parameterValueSet, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ParameterValueSet'");
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.ParameterValueSet)parameterValueSet);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </summary>
        /// <param name="parameterValueSet">
        /// The <see cref="CDP4Common.DTO.ParameterValueSet"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing parameterValueSet, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ParameterValueSet'");
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.ParameterValueSet)parameterValueSet);
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
        private readonly Dictionary<string, PropertyMetaInfo> containmentTypeMap = new Dictionary<string, PropertyMetaInfo>();

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="ParameterValueSet"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ParameterValueSet, object>>
        {
            { "Actor", thing => thing.Actor },
            { "ActualOption", thing => thing.ActualOption },
            { "ActualState", thing => thing.ActualState },
            { "ClassKind", thing => thing.ClassKind },
            { "Computed", thing => thing.Computed },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "Formula", thing => thing.Formula },
            { "Iid", thing => thing.Iid },
            { "Manual", thing => thing.Manual },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Published", thing => thing.Published },
            { "Reference", thing => thing.Reference },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "ThingPreference", thing => thing.ThingPreference },
            { "ValueSwitch", thing => thing.ValueSwitch },
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
            { "ActualOption", new PropertyMetaInfo("ActualOption", "Option", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ActualState", new PropertyMetaInfo("ActualState", "ActualFiniteState", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ActualValue", new PropertyMetaInfo("ActualValue", "string", PropertyKind.ValueArray, AggregationKind.None, true, true, true, 1, "*", false) },
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Computed", new PropertyMetaInfo("Computed", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Formula", new PropertyMetaInfo("Formula", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Manual", new PropertyMetaInfo("Manual", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Owner", new PropertyMetaInfo("Owner", "DomainOfExpertise", PropertyKind.Scalar, AggregationKind.None, true, false, true, 1, "1", false) },
            { "Published", new PropertyMetaInfo("Published", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "Reference", new PropertyMetaInfo("Reference", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ThingPreference", new PropertyMetaInfo("ThingPreference", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ValueSwitch", new PropertyMetaInfo("ValueSwitch", "CDP4Common.EngineeringModelData.ParameterSwitchKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.ParameterValueSet, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.ParameterValueSet, object>>
        {
            { "Actor", (parameterValueSet, value) => parameterValueSet.Actor = value == null ? (Guid?)null : (Guid)value },
            { "ActualOption", (parameterValueSet, value) => parameterValueSet.ActualOption = value == null ? (Guid?)null : (Guid)value },
            { "ActualState", (parameterValueSet, value) => parameterValueSet.ActualState = value == null ? (Guid?)null : (Guid)value },
            { "Computed", (parameterValueSet, value) => parameterValueSet.Computed = (ValueArray<string>)value },
            { "Formula", (parameterValueSet, value) => parameterValueSet.Formula = (ValueArray<string>)value },
            { "Iid", (parameterValueSet, value) => parameterValueSet.Iid = (Guid)value },
            { "Manual", (parameterValueSet, value) => parameterValueSet.Manual = (ValueArray<string>)value },
            { "ModifiedOn", (parameterValueSet, value) => parameterValueSet.ModifiedOn = (DateTime)value },
            { "Published", (parameterValueSet, value) => parameterValueSet.Published = (ValueArray<string>)value },
            { "Reference", (parameterValueSet, value) => parameterValueSet.Reference = (ValueArray<string>)value },
            { "ThingPreference", (parameterValueSet, value) => parameterValueSet.ThingPreference = value == null ? (string)null : value.ToString() },
            { "ValueSwitch", (parameterValueSet, value) => parameterValueSet.ValueSwitch = (ParameterSwitchKind)value },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "Parameter", new PropertyMetaInfo("ValueSet", "ParameterValueSet", PropertyKind.List, AggregationKind.Composite, false, false, true, 1, "*", true) },
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
            get { return "ParameterValueSetBase"; }
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
        /// Returns the <see cref="CDP4Common.DTO.ParameterValueSet"/> containment property type from the supplied property name.
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
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ParameterValueSet'");
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.ParameterValueSet"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.ParameterValueSet"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.ParameterValueSet"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.ParameterValueSet"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.ParameterValueSet)updatableThing, value);

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
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ParameterValueSet'");
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
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ParameterValueSet'");
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.ParameterValueSet)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.ParameterValueSet"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.ParameterValueSet(guid, revisionNumber);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
