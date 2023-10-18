// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibraryMetaInfo.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    /// This a class that holds meta info for <see cref="ModelReferenceDataLibrary"/>.
    /// </summary>
    public partial class ModelReferenceDataLibraryMetaInfo : IModelReferenceDataLibraryMetaInfo
    {
        /// <summary>
        /// The containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, IEnumerable<Guid>>> containmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, IEnumerable<Guid>>>
        {
            { "Alias", modelReferenceDataLibrary => modelReferenceDataLibrary.Alias },
            { "Constant", modelReferenceDataLibrary => modelReferenceDataLibrary.Constant },
            { "DefinedCategory", modelReferenceDataLibrary => modelReferenceDataLibrary.DefinedCategory },
            { "Definition", modelReferenceDataLibrary => modelReferenceDataLibrary.Definition },
            { "FileType", modelReferenceDataLibrary => modelReferenceDataLibrary.FileType },
            { "Glossary", modelReferenceDataLibrary => modelReferenceDataLibrary.Glossary },
            { "HyperLink", modelReferenceDataLibrary => modelReferenceDataLibrary.HyperLink },
            { "ParameterType", modelReferenceDataLibrary => modelReferenceDataLibrary.ParameterType },
            { "ReferenceSource", modelReferenceDataLibrary => modelReferenceDataLibrary.ReferenceSource },
            { "Rule", modelReferenceDataLibrary => modelReferenceDataLibrary.Rule },
            { "Scale", modelReferenceDataLibrary => modelReferenceDataLibrary.Scale },
            { "Unit", modelReferenceDataLibrary => modelReferenceDataLibrary.Unit },
            { "UnitPrefix", modelReferenceDataLibrary => modelReferenceDataLibrary.UnitPrefix },
        };

        /// <summary>
        /// The ordered containment property value map.
        /// </summary>
        private readonly Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, IEnumerable<OrderedItem>>> orderedContainmentPropertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, IEnumerable<OrderedItem>>>();

        /// <summary>
        /// The validation rules that should pass for an instance of <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </summary>
        private readonly Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>> validationRules = new Dictionary<string, DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>>
        {
            { "Alias", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Alias != null, "The 'Alias' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "BaseQuantityKind", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.BaseQuantityKind != null, "The 'BaseQuantityKind' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "BaseUnit", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.BaseUnit != null, "The 'BaseUnit' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Constant", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Constant != null, "The 'Constant' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "DefinedCategory", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.DefinedCategory != null, "The 'DefinedCategory' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Definition", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Definition != null, "The 'Definition' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "ExcludedDomain", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.ExcludedDomain != null, "The 'ExcludedDomain' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "ExcludedPerson", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.ExcludedPerson != null, "The 'ExcludedPerson' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "FileType", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.FileType != null, "The 'FileType' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Glossary", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Glossary != null, "The 'Glossary' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "HyperLink", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.HyperLink != null, "The 'HyperLink' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Name", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => !string.IsNullOrWhiteSpace(item.Name), "The 'Name' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be empty or null.") },
            { "ParameterType", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.ParameterType != null, "The 'ParameterType' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "ReferenceSource", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.ReferenceSource != null, "The 'ReferenceSource' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Rule", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Rule != null, "The 'Rule' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "Scale", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Scale != null, "The 'Scale' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "ShortName", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => !string.IsNullOrWhiteSpace(item.ShortName), "The 'ShortName' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be empty or null.") },
            { "Unit", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.Unit != null, "The 'Unit' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
            { "UnitPrefix", new DtoValidationHelper<CDP4Common.DTO.ModelReferenceDataLibrary>(item => item.UnitPrefix != null, "The 'UnitPrefix' property of a 'ModelReferenceDataLibrary' is mandatory and cannot be null.") },
        };

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing modelReferenceDataLibrary)
        {
            this.Validate(modelReferenceDataLibrary, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="CDP4Common.DTO.Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <exception cref="Cdp4ModelValidationException">
        /// If any validation rule failed.
        /// </exception>
        public void Validate(CDP4Common.DTO.Thing modelReferenceDataLibrary, Func<string, bool> validateProperty)
        {
            foreach (var applicableRule in this.validationRules.Where(x => validateProperty(x.Key)))
            {
                applicableRule.Value.Validate((CDP4Common.DTO.ModelReferenceDataLibrary)modelReferenceDataLibrary);
            }
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing modelReferenceDataLibrary)
        {
            return this.TryValidate(modelReferenceDataLibrary, x => true);
        }

        /// <summary>
        /// Validates the supplied <see cref="Thing"/> by running the business validation rules as per its meta info definition class.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.Thing"/> for which to run the validation rules.
        /// </param>
        /// <param name="validateProperty">
        /// The validate Property.
        /// </param>
        /// <returns>
        /// True if all validation rules have passed or if none are defined.
        /// </returns>
        public bool TryValidate(CDP4Common.DTO.Thing modelReferenceDataLibrary, Func<string, bool> validateProperty)
        {
            var applicableValidationRules = this.validationRules.Where(x => validateProperty(x.Key)).Select(x => x.Value);

            return applicableValidationRules.All(applicableRule => applicableRule.TryValidate((CDP4Common.DTO.ModelReferenceDataLibrary)modelReferenceDataLibrary));
        }

        /// <summary>
        /// Returns the containment property value for the supplied <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of containment <see cref="Guid"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </exception>
        public IEnumerable<Guid> GetContainmentIds(CDP4Common.DTO.Thing modelReferenceDataLibrary, string propertyName)
        {
            if (!this.containmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ModelReferenceDataLibrary'");
            }

            return this.containmentPropertyValueMap[propertyName]((CDP4Common.DTO.ModelReferenceDataLibrary)modelReferenceDataLibrary);
        }

        /// <summary>
        /// Returns the ordered containment property value for the supplied <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </summary>
        /// <param name="modelReferenceDataLibrary">
        /// The <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> for which to return the containment property value.
        /// </param>
        /// <param name="propertyName">
        /// Name of the containment property for which to return the value.
        /// </param>
        /// <returns>
        /// A collection of ordered containment <see cref="OrderedItem"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// If the property name is not supported for the <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </exception>
        public IEnumerable<OrderedItem> GetOrderedContainmentIds(CDP4Common.DTO.Thing modelReferenceDataLibrary, string propertyName)
        {
            if (!this.orderedContainmentPropertyValueMap.ContainsKey(propertyName))
            {
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ModelReferenceDataLibrary'");
            }

            return this.orderedContainmentPropertyValueMap[propertyName]((CDP4Common.DTO.ModelReferenceDataLibrary)modelReferenceDataLibrary);
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
            { "Alias", new PropertyMetaInfo("Alias", "Alias", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Constant", new PropertyMetaInfo("Constant", "Constant", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "DefinedCategory", new PropertyMetaInfo("DefinedCategory", "Category", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Definition", new PropertyMetaInfo("Definition", "Definition", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "FileType", new PropertyMetaInfo("FileType", "FileType", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Glossary", new PropertyMetaInfo("Glossary", "Glossary", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "HyperLink", new PropertyMetaInfo("HyperLink", "HyperLink", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "ParameterType", new PropertyMetaInfo("ParameterType", "ParameterType", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "ReferenceSource", new PropertyMetaInfo("ReferenceSource", "ReferenceSource", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Rule", new PropertyMetaInfo("Rule", "Rule", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Scale", new PropertyMetaInfo("Scale", "MeasurementScale", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "Unit", new PropertyMetaInfo("Unit", "MeasurementUnit", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
            { "UnitPrefix", new PropertyMetaInfo("UnitPrefix", "UnitPrefix", PropertyKind.List, AggregationKind.Composite, false, false, true, 0, "*", true) },
        };

        /// <summary>
        /// Gets the <see cref="PropertyMetaInfo"/> for the <see cref="ModelReferenceDataLibrary"/> class
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
        private readonly Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, object>> propertyValueMap = new Dictionary<string, Func<CDP4Common.DTO.ModelReferenceDataLibrary, object>>
        {
            { "Actor", thing => thing.Actor },
            { "Alias", thing => thing.Alias },
            { "BaseQuantityKind", thing => thing.BaseQuantityKind },
            { "BaseUnit", thing => thing.BaseUnit },
            { "ClassKind", thing => thing.ClassKind },
            { "Constant", thing => thing.Constant },
            { "DefinedCategory", thing => thing.DefinedCategory },
            { "Definition", thing => thing.Definition },
            { "ExcludedDomain", thing => thing.ExcludedDomain },
            { "ExcludedPerson", thing => thing.ExcludedPerson },
            { "FileType", thing => thing.FileType },
            { "Glossary", thing => thing.Glossary },
            { "HyperLink", thing => thing.HyperLink },
            { "Iid", thing => thing.Iid },
            { "ModifiedOn", thing => thing.ModifiedOn },
            { "Name", thing => thing.Name },
            { "ParameterType", thing => thing.ParameterType },
            { "ReferenceSource", thing => thing.ReferenceSource },
            { "RequiredRdl", thing => thing.RequiredRdl },
            { "RevisionNumber", thing => thing.RevisionNumber },
            { "Rule", thing => thing.Rule },
            { "Scale", thing => thing.Scale },
            { "ShortName", thing => thing.ShortName },
            { "ThingPreference", thing => thing.ThingPreference },
            { "Unit", thing => thing.Unit },
            { "UnitPrefix", thing => thing.UnitPrefix },
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
            { "BaseQuantityKind", new PropertyMetaInfo("BaseQuantityKind", "QuantityKind", PropertyKind.OrderedList, AggregationKind.None, false, true, true, 0, "*", true) },
            { "BaseUnit", new PropertyMetaInfo("BaseUnit", "MeasurementUnit", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ClassKind", new PropertyMetaInfo("ClassKind", "CDP4Common.CommonData.ClassKind", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ExcludedDomain", new PropertyMetaInfo("ExcludedDomain", "DomainOfExpertise", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "ExcludedPerson", new PropertyMetaInfo("ExcludedPerson", "Person", PropertyKind.List, AggregationKind.None, false, false, true, 0, "*", true) },
            { "Iid", new PropertyMetaInfo("Iid", "Guid", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ModifiedOn", new PropertyMetaInfo("ModifiedOn", "DateTime", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "Name", new PropertyMetaInfo("Name", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "RequiredRdl", new PropertyMetaInfo("RequiredRdl", "SiteReferenceDataLibrary", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
            { "RevisionNumber", new PropertyMetaInfo("RevisionNumber", "int", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ShortName", new PropertyMetaInfo("ShortName", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 1, "1", true) },
            { "ThingPreference", new PropertyMetaInfo("ThingPreference", "string", PropertyKind.Scalar, AggregationKind.None, false, false, true, 0, "1", true) },
        };

        /// <summary>
        /// The collection property value deserialization map.
        /// </summary>
        private readonly Dictionary<string, Func<object, object>> collectionPropertyValueDeserializationMap = new Dictionary<string, Func<object, object>>
        {
            { "Alias", (value) => (Guid)value },
            { "BaseQuantityKind", (value) => (Guid)value },
            { "BaseUnit", (value) => (Guid)value },
            { "Constant", (value) => (Guid)value },
            { "DefinedCategory", (value) => (Guid)value },
            { "Definition", (value) => (Guid)value },
            { "ExcludedDomain", (value) => (Guid)value },
            { "ExcludedPerson", (value) => (Guid)value },
            { "FileType", (value) => (Guid)value },
            { "Glossary", (value) => (Guid)value },
            { "HyperLink", (value) => (Guid)value },
            { "ParameterType", (value) => (Guid)value },
            { "ReferenceSource", (value) => (Guid)value },
            { "Rule", (value) => (Guid)value },
            { "Scale", (value) => (Guid)value },
            { "Unit", (value) => (Guid)value },
            { "UnitPrefix", (value) => (Guid)value },
        };

        /// <summary>
        /// The property value assignment map.
        /// </summary>
        private readonly Dictionary<string, Action<CDP4Common.DTO.ModelReferenceDataLibrary, object>> propertyValueAssignmentMap = new Dictionary<string, Action<CDP4Common.DTO.ModelReferenceDataLibrary, object>>
        {
            { "Actor", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.Actor = value == null ? (Guid?)null : (Guid)value },
            { "Iid", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.Iid = (Guid)value },
            { "ModifiedOn", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.ModifiedOn = (DateTime)value },
            { "Name", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.Name = value.ToString() },
            { "RequiredRdl", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.RequiredRdl = value == null ? (Guid?)null : (Guid)value },
            { "ShortName", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.ShortName = value.ToString() },
            { "ThingPreference", (modelReferenceDataLibrary, value) => modelReferenceDataLibrary.ThingPreference = value == null ? (string)null : value.ToString() },
        };

        /// <summary>
        /// The possible container property map.
        /// </summary>
        private readonly Dictionary<string, PropertyMetaInfo> possibleContainerProperties = new Dictionary<string, PropertyMetaInfo>
        {
            { "EngineeringModelSetup", new PropertyMetaInfo("RequiredRdl", "ModelReferenceDataLibrary", PropertyKind.List, AggregationKind.Composite, false, false, true, 1, "1", true) },
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
            get { return "ReferenceDataLibrary"; }
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
        /// Returns the <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> containment property type from the supplied property name.
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
                throw new ArgumentException($"'{propertyName}' is not a valid containment property of 'ModelReferenceDataLibrary'");
            }

            return this.containmentTypeMap[propertyName];
        }

        /// <summary>
        /// Returns the <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> property type from the supplied property name.
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
        /// Returns the container property for the supplied type name is a possible container for <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </summary>
        /// <param name="typeName">
        /// Name of the type for which to check if it is a container of <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </param>
        /// <param name="containerProperty">
        /// Supplied container property info instance that will be set if the supplied type name is a container of <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>.
        /// </param>
        /// <returns>
        /// True if the supplied typeName is a container for <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> and sets the container property name.
        /// </returns>
        public bool TryGetContainerProperty(string typeName, out PropertyMetaInfo containerProperty)
        {
            var isContainer = this.possibleContainerProperties.ContainsKey(typeName);
            containerProperty = isContainer ? this.possibleContainerProperties[typeName] : null;
            
            return isContainer;
        }

        /// <summary>
        /// Check if the supplied property name for <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> is scalar.
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

            this.propertyValueAssignmentMap[propertyName]((CDP4Common.DTO.ModelReferenceDataLibrary)updatableThing, value);

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
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ModelReferenceDataLibrary'");
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
                throw new ArgumentException($"'{propertyName}' is not a valid collection property of 'ModelReferenceDataLibrary'");
            }

            return this.propertyValueMap[propertyName]((CDP4Common.DTO.ModelReferenceDataLibrary)thing);
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
        /// Instantiates a <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>
        /// </summary>
        /// <returns>
        /// The instantiated <see cref="CDP4Common.DTO.Thing"/>
        /// </returns>
        public CDP4Common.DTO.Thing InstantiateDto(Guid guid, int revisionNumber)
        {
            return new CDP4Common.DTO.ModelReferenceDataLibrary(guid, revisionNumber);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
