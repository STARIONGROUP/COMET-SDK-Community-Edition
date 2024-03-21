// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibraryResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
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
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System.Text.Json;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ModelReferenceDataLibraryResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>
    /// </summary>
    public static class ModelReferenceDataLibraryResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ModelReferenceDataLibrary"/> to instantiate</returns>
        public static CDP4Common.DTO.ModelReferenceDataLibrary FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ModelReferenceDataLibraryResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var modelReferenceDataLibrary = new CDP4Common.DTO.ModelReferenceDataLibrary(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("baseQuantityKind"u8, out var baseQuantityKindProperty))
            {
                modelReferenceDataLibrary.BaseQuantityKind.AddRange(baseQuantityKindProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("baseUnit"u8, out var baseUnitProperty) && baseUnitProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in baseUnitProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.BaseUnit.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("constant"u8, out var constantProperty) && constantProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in constantProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Constant.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definedCategory"u8, out var definedCategoryProperty) && definedCategoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definedCategoryProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.DefinedCategory.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("fileType"u8, out var fileTypeProperty) && fileTypeProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in fileTypeProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.FileType.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("glossary"u8, out var glossaryProperty) && glossaryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in glossaryProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Glossary.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the modelReferenceDataLibrary {id} is null", modelReferenceDataLibrary.Iid);
                }
                else
                {
                    modelReferenceDataLibrary.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the modelReferenceDataLibrary {id} is null", modelReferenceDataLibrary.Iid);
                }
                else
                {
                    modelReferenceDataLibrary.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("parameterType"u8, out var parameterTypeProperty) && parameterTypeProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterTypeProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.ParameterType.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("referenceSource"u8, out var referenceSourceProperty) && referenceSourceProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in referenceSourceProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.ReferenceSource.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("requiredRdl"u8, out var requiredRdlProperty))
            {
                if(requiredRdlProperty.ValueKind == JsonValueKind.Null)
                {
                    modelReferenceDataLibrary.RequiredRdl = null;
                }
                else
                {
                    modelReferenceDataLibrary.RequiredRdl = requiredRdlProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("rule"u8, out var ruleProperty) && ruleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in ruleProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Rule.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("scale"u8, out var scaleProperty) && scaleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in scaleProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Scale.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the modelReferenceDataLibrary {id} is null", modelReferenceDataLibrary.Iid);
                }
                else
                {
                    modelReferenceDataLibrary.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the modelReferenceDataLibrary {id} is null", modelReferenceDataLibrary.Iid);
                }
                else
                {
                    modelReferenceDataLibrary.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("unit"u8, out var unitProperty) && unitProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in unitProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.Unit.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("unitPrefix"u8, out var unitPrefixProperty) && unitPrefixProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in unitPrefixProperty.EnumerateArray())
                {
                    modelReferenceDataLibrary.UnitPrefix.Add(element.GetGuid());
                }
            }

            return modelReferenceDataLibrary;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
