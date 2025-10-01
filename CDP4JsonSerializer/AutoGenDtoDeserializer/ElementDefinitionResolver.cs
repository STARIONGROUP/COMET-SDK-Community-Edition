// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionResolver.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common.Types;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ElementDefinitionResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.ElementDefinition"/>
    /// </summary>
    public static class ElementDefinitionResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.ElementDefinition"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.ElementDefinition"/> to instantiate</returns>
        public static CDP4Common.DTO.ElementDefinition FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the ElementDefinitionResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var elementDefinition = new CDP4Common.DTO.ElementDefinition(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("alias"u8, out var aliasProperty) && aliasProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in aliasProperty.EnumerateArray())
                {
                    elementDefinition.Alias.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("category"u8, out var categoryProperty) && categoryProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in categoryProperty.EnumerateArray())
                {
                    elementDefinition.Category.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("containedElement"u8, out var containedElementProperty) && containedElementProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in containedElementProperty.EnumerateArray())
                {
                    elementDefinition.ContainedElement.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("definition"u8, out var definitionProperty) && definitionProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in definitionProperty.EnumerateArray())
                {
                    elementDefinition.Definition.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    elementDefinition.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    elementDefinition.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("hyperLink"u8, out var hyperLinkProperty) && hyperLinkProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in hyperLinkProperty.EnumerateArray())
                {
                    elementDefinition.HyperLink.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale modifiedOn property of the elementDefinition {id} is null", elementDefinition.Iid);
                }
                else
                {
                    elementDefinition.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale name property of the elementDefinition {id} is null", elementDefinition.Iid);
                }
                else
                {
                    elementDefinition.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("organizationalParticipant"u8, out var organizationalParticipantProperty) && organizationalParticipantProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in organizationalParticipantProperty.EnumerateArray())
                {
                    elementDefinition.OrganizationalParticipant.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("owner"u8, out var ownerProperty))
            {
                if(ownerProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale owner property of the elementDefinition {id} is null", elementDefinition.Iid);
                }
                else
                {
                    elementDefinition.Owner = ownerProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("parameter"u8, out var parameterProperty) && parameterProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterProperty.EnumerateArray())
                {
                    elementDefinition.Parameter.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("parameterGroup"u8, out var parameterGroupProperty) && parameterGroupProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in parameterGroupProperty.EnumerateArray())
                {
                    elementDefinition.ParameterGroup.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("referencedElement"u8, out var referencedElementProperty) && referencedElementProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in referencedElementProperty.EnumerateArray())
                {
                    elementDefinition.ReferencedElement.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("shortName"u8, out var shortNameProperty))
            {
                if(shortNameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale shortName property of the elementDefinition {id} is null", elementDefinition.Iid);
                }
                else
                {
                    elementDefinition.ShortName = shortNameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Trace("The non-nullabale thingPreference property of the elementDefinition {id} is null", elementDefinition.Iid);
                }
                else
                {
                    elementDefinition.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return elementDefinition;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
