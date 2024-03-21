// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementUsageResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ElementUsage"/>
    /// </summary>
    public static class ElementUsageResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ElementUsage"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ElementUsage"/> to instantiate</returns>
        public static CDP4Common.DTO.ElementUsage FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ElementUsageResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var elementUsage = new CDP4Common.DTO.ElementUsage(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    elementUsage.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    elementUsage.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    elementUsage.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("elementDefinition"u8, out var elementDefinitionProperty))
            {
                if(elementDefinitionProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale elementDefinition property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.ElementDefinition = elementDefinitionProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    elementUsage.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    elementUsage.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludeOption"u8, out var excludeOptionProperty) && excludeOptionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludeOptionProperty.EnumerateArray())
                {
                    elementUsage.ExcludeOption.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    elementUsage.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("interfaceEnd"u8, out var interfaceEndProperty))
            {
                if(interfaceEndProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale interfaceEnd property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.InterfaceEnd = InterfaceEndKindDeserializer.Deserialize(interfaceEndProperty);
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale owner property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameterOverride"u8, out var parameterOverrideProperty) && parameterOverrideProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterOverrideProperty.EnumerateArray())
                {
                    elementUsage.ParameterOverride.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale shortName property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the elementUsage {id} is null", elementUsage.Iid);
                }
                else
                {
                    elementUsage.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return elementUsage;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
