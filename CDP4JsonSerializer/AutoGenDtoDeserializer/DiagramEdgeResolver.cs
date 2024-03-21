// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdgeResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramEdgeResolver"/> is to deserialize a JSON object to a <see cref="CDP4Common.DTO.DiagramEdge"/>
    /// </summary>
    public static class DiagramEdgeResolver
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Instantiate and deserialize the properties of a <see cref="CDP4Common.DTO.DiagramEdge"/>
        /// </summary>
        /// <param name="jsonElement">The <see cref="JsonElement"/> containing the data</param>
        /// <returns>The <see cref="CDP4Common.DTO.DiagramEdge"/> to instantiate</returns>
        public static CDP4Common.DTO.DiagramEdge FromJsonObject(JsonElement jsonElement)
        {
            if (!jsonElement.TryGetProperty("iid"u8, out var iid))
            {
                throw new DeSerializationException("the mandatory iid property is not available, the DiagramEdgeResolver cannot be used to deserialize this JsonElement");
            }
            
            var revisionNumberValue = 0;

            if (jsonElement.TryGetProperty("revisionNumber"u8, out var revisionNumber))
            {
                revisionNumberValue = revisionNumber.GetInt32();
            }

            var diagramEdge = new CDP4Common.DTO.DiagramEdge(iid.GetGuid(), revisionNumberValue);

            if (jsonElement.TryGetProperty("bounds"u8, out var boundsProperty) && boundsProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in boundsProperty.EnumerateArray())
                {
                    diagramEdge.Bounds.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("depictedThing"u8, out var depictedThingProperty))
            {
                if(depictedThingProperty.ValueKind == JsonValueKind.Null)
                {
                    diagramEdge.DepictedThing = null;
                }
                else
                {
                    diagramEdge.DepictedThing = depictedThingProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("diagramElement"u8, out var diagramElementProperty) && diagramElementProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in diagramElementProperty.EnumerateArray())
                {
                    diagramEdge.DiagramElement.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedDomain"u8, out var excludedDomainProperty) && excludedDomainProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedDomainProperty.EnumerateArray())
                {
                    diagramEdge.ExcludedDomain.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("excludedPerson"u8, out var excludedPersonProperty) && excludedPersonProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in excludedPersonProperty.EnumerateArray())
                {
                    diagramEdge.ExcludedPerson.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("localStyle"u8, out var localStyleProperty) && localStyleProperty.ValueKind != JsonValueKind.Null)
            {
                foreach(var element in localStyleProperty.EnumerateArray())
                {
                    diagramEdge.LocalStyle.Add(element.GetGuid());
                }
            }

            if (jsonElement.TryGetProperty("modifiedOn"u8, out var modifiedOnProperty))
            {
                if(modifiedOnProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale modifiedOn property of the diagramEdge {id} is null", diagramEdge.Iid);
                }
                else
                {
                    diagramEdge.ModifiedOn = modifiedOnProperty.GetDateTime();
                }
            }

            if (jsonElement.TryGetProperty("name"u8, out var nameProperty))
            {
                if(nameProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale name property of the diagramEdge {id} is null", diagramEdge.Iid);
                }
                else
                {
                    diagramEdge.Name = nameProperty.GetString();
                }
            }

            if (jsonElement.TryGetProperty("point"u8, out var pointProperty))
            {
                diagramEdge.Point.AddRange(pointProperty.ToOrderedItemCollection());
            }

            if (jsonElement.TryGetProperty("sharedStyle"u8, out var sharedStyleProperty))
            {
                if(sharedStyleProperty.ValueKind == JsonValueKind.Null)
                {
                    diagramEdge.SharedStyle = null;
                }
                else
                {
                    diagramEdge.SharedStyle = sharedStyleProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("source"u8, out var sourceProperty))
            {
                if(sourceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale source property of the diagramEdge {id} is null", diagramEdge.Iid);
                }
                else
                {
                    diagramEdge.Source = sourceProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("target"u8, out var targetProperty))
            {
                if(targetProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale target property of the diagramEdge {id} is null", diagramEdge.Iid);
                }
                else
                {
                    diagramEdge.Target = targetProperty.GetGuid();
                }
            }

            if (jsonElement.TryGetProperty("thingPreference"u8, out var thingPreferenceProperty))
            {
                if(thingPreferenceProperty.ValueKind == JsonValueKind.Null)
                {
                    Logger.Debug("The non-nullabale thingPreference property of the diagramEdge {id} is null", diagramEdge.Iid);
                }
                else
                {
                    diagramEdge.ThingPreference = thingPreferenceProperty.GetString();
                }
            }

            return diagramEdge;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
