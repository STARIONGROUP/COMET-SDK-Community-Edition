// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampledFunctionParameterTypeMetaInfo.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

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
    /// This a class that holds meta info for <see cref="SampledFunctionParameterType"/>.
    /// </summary>
    public partial class SampledFunctionParameterTypeMetaInfo : ISampledFunctionParameterTypeMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, IEnumerable<Guid>>>
        {
            { "Alias", sampledFunctionParameterType => sampledFunctionParameterType.Alias },
            { "Definition", sampledFunctionParameterType => sampledFunctionParameterType.Definition },
            { "DependentParameterType", sampledFunctionParameterType => sampledFunctionParameterType.DependentParameterType.ToIdList() },
            { "HyperLink", sampledFunctionParameterType => sampledFunctionParameterType.HyperLink },
            { "IndependentParameterType", sampledFunctionParameterType => sampledFunctionParameterType.IndependentParameterType.ToIdList() },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, IEnumerable<OrderedItem>>>
        {
            { "DependentParameterType", sampledFunctionParameterType => sampledFunctionParameterType.DependentParameterType },
            { "IndependentParameterType", sampledFunctionParameterType => sampledFunctionParameterType.IndependentParameterType },
        };

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>>
        {
            { "Alias", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.Alias != null, "The 'Alias' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "Category", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.Category != null, "The 'Category' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "Definition", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.Definition != null, "The 'Definition' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "DependentParameterType", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.DependentParameterType != null && item.DependentParameterType.Any(), "The 'DependentParameterType' property of a 'SampledFunctionParameterType' is mandatory and must have at least one entry.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "HyperLink", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.HyperLink != null, "The 'HyperLink' property of a 'SampledFunctionParameterType' is mandatory and cannot be null.") },
            { "IndependentParameterType", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.IndependentParameterType != null && item.IndependentParameterType.Any(), "The 'IndependentParameterType' property of a 'SampledFunctionParameterType' is mandatory and must have at least one entry.") },
            { "InterpolationPeriod", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => item.InterpolationPeriod != null && item.InterpolationPeriod.Any(), "The 'InterpolationPeriod' property of a 'SampledFunctionParameterType' is mandatory and must have at least one entry.") },
            { "Name", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => !string.IsNullOrWhiteSpace(item.Name), "The 'Name' property of a 'SampledFunctionParameterType' is mandatory and cannot be empty or null.") },
            { "ShortName", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => !string.IsNullOrWhiteSpace(item.ShortName), "The 'ShortName' property of a 'SampledFunctionParameterType' is mandatory and cannot be empty or null.") },
            { "Symbol", new DtoValidationHelper<CDP4Common.DTO.SampledFunctionParameterType>(item => !string.IsNullOrWhiteSpace(item.Symbol), "The 'Symbol' property of a 'SampledFunctionParameterType' is mandatory and cannot be empty or null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing sampledFunctionParameterType)
        {
            this.Validate(sampledFunctionParameterType, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing sampledFunctionParameterType, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.SampledFunctionParameterType)sampledFunctionParameterType);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing sampledFunctionParameterType)
        {
            return this.TryValidate(sampledFunctionParameterType, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing sampledFunctionParameterType, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.SampledFunctionParameterType)sampledFunctionParameterType));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing sampledFunctionParameterType, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'SampledFunctionParameterType'", propertyName));
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.SampledFunctionParameterType)sampledFunctionParameterType);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </summary>
        /// <param name="sampledFunctionParameterType">
        /// The <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing sampledFunctionParameterType, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'SampledFunctionParameterType'", propertyName));
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.SampledFunctionParameterType)sampledFunctionParameterType);
        }

        /// <summary>
        /// The CDP version property map.
        /// </summary>
        private readonly Dictionary<string, string> cdpVersionedProperties = new Dictionary<string, string>
        {
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
            { "Alias", new PropertyMetaInfo("Alias", "Alias", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Definition", new PropertyMetaInfo("Definition", "Definition", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DependentParameterType", new PropertyMetaInfo("DependentParameterType", "DependentParameterTypeAssignment", PropertyKind.OrderedList, AggregationKind.Composite, false, true, true, 1, "*", true) },
            { "HyperLink", new PropertyMetaInfo("HyperLink", "HyperLink", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "IndependentParameterType", new PropertyMetaInfo("IndependentParameterType", "IndependentParameterTypeAssignment", PropertyKind.OrderedList, AggregationKind.Composite, false, true, true, 1, "*", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="SampledFunctionParameterType"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.SampledFunctionParameterType, object>>
        {
            { "Alias", thing => thing.Alias },
            { "Category", thing => thing.Category },
            { "ClassKind", thing => thing.ClassKind },
            { "Definition", thing => thing.Definition },
            { "DegreeOfInterpolation", thing => thing.DegreeOfInterpolation },
            { "DependentParameterType", thing => thing.DependentParameterType },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "HyperLink", thing => thing.HyperLink },
            { "Iid", thing => thing.Iid },
            { "IndependentParameterType", thing => thing.IndependentParameterType },
            { "InterpolationPeriod", thing => thing.InterpolationPeriod },
            { "IsDeprecated", thing => thing.IsDeprecated },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Name", thing => thing.Name },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "ShortName", thing => thing.ShortName },
            { "Symbol", thing => thing.Symbol },
            { "ThingPreference", thing => thing.ThingPreference },
        };

        /// <summary>
        /// The property type map.
        /// </summary>
        /// <remarks>
        /// Contained properties are excluded for this map
        /// </remarks>
        private readonly Dictionary<string, PropertyMetaInfo> propertyTypeMap = new Dictionary<string, PropertyMetaInfo>
        {
            { "Category", new PropertyMetaInfo("Category", "Category", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "DegreeOfInterpolation", new PropertyMetaInfo("DegreeOfInterpolation", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "InterpolationPeriod", new PropertyMetaInfo("InterpolationPeriod", "string", PropertyKind.ValueArray, AggregationKind.None, false, true, true, 1, "*", true) },
            { "IsDeprecated", new PropertyMetaInfo("IsDeprecated", "bool", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Name", new PropertyMetaInfo("Name", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "NumberOfValues", new PropertyMetaInfo("NumberOfValues", "int", PropertyKind.Scalar, AggregationKind.None, true, false, true, 1, "1", false) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ShortName", new PropertyMetaInfo("ShortName", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Symbol", new PropertyMetaInfo("Symbol", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ThingPreference", new PropertyMetaInfo("ThingPreference", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "Alias", (value) => (Guid)value },
            { "Category", (value) => (Guid)value },
            { "Definition", (value) => (Guid)value },
            { "DependentParameterType", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "HyperLink", (value) => (Guid)value },
            { "IndependentParameterType", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.SampledFunctionParameterType, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.SampledFunctionParameterType, object>>
        {
            { "DegreeOfInterpolation", (sampledFunctionParameterType, value) => sampledFunctionParameterType.DegreeOfInterpolation = value == null ? (int?)null : (int)value },
            { "Iid", (sampledFunctionParameterType, value) => sampledFunctionParameterType.Iid = (Guid)value },
            { "InterpolationPeriod", (sampledFunctionParameterType, value) => sampledFunctionParameterType.InterpolationPeriod = (ValueArray<string>)value },
            { "IsDeprecated", (sampledFunctionParameterType, value) => sampledFunctionParameterType.IsDeprecated = (bool)value },
            { "ModifiedOn", (sampledFunctionParameterType, value) => sampledFunctionParameterType.ModifiedOn = (DateTime)value },
            { "Name", (sampledFunctionParameterType, value) => sampledFunctionParameterType.Name = value.ToString() },
            { "ShortName", (sampledFunctionParameterType, value) => sampledFunctionParameterType.ShortName = value.ToString() },
            { "Symbol", (sampledFunctionParameterType, value) => sampledFunctionParameterType.Symbol = value.ToString() },
            { "ThingPreference", (sampledFunctionParameterType, value) => sampledFunctionParameterType.ThingPreference = value == null ? (string)null : value.ToString() },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "ModelReferenceDataLibrary", new PropertyMetaInfo("ParameterType", "ParameterType", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "SiteReferenceDataLibrary", new PropertyMetaInfo("ParameterType", "ParameterType", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
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
            get { return "ParameterType"; }
        }

        /// <summary>
        /// Gets the CDP class version.
        /// </summary>
        public string ClassVersion
        {
            get { return "1.2.0"; }
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
        /// Returns the <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> containment property type from the supplied property name.
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
                throw new ArgumentException(string.Format("'{0}' is not a valid containment property of 'SampledFunctionParameterType'", propertyName));
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.SampledFunctionParameterType"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.SampledFunctionParameterType)updatableThing, value);

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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'SampledFunctionParameterType'", propertyName));
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
                throw new ArgumentException(string.Format("'{0}' is not a valid collection property of 'SampledFunctionParameterType'", propertyName));
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.SampledFunctionParameterType)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.SampledFunctionParameterType"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.SampledFunctionParameterType(guid, revisionNumber);
        }
    }
}
