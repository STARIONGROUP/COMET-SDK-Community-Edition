// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteReferenceDataLibrarySerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Jaime Bernar
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
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

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Nodes;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    /// <summary>
    /// The purpose of the <see cref="SiteReferenceDataLibrarySerializer"/> class is to provide a <see cref="SiteReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class SiteReferenceDataLibrarySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JsonValue>> propertySerializerMap = new Dictionary<string, Func<object, JsonValue>>
        {
            { "alias", alias => JsonValue.Create(alias) },
            { "baseQuantityKind", baseQuantityKind => JsonValue.Create(((IEnumerable)baseQuantityKind).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "baseUnit", baseUnit => JsonValue.Create(baseUnit) },
            { "classKind", classKind => JsonValue.Create(classKind.ToString()) },
            { "constant", constant => JsonValue.Create(constant) },
            { "definedCategory", definedCategory => JsonValue.Create(definedCategory) },
            { "definition", definition => JsonValue.Create(definition) },
            { "excludedDomain", excludedDomain => JsonValue.Create(excludedDomain) },
            { "excludedPerson", excludedPerson => JsonValue.Create(excludedPerson) },
            { "fileType", fileType => JsonValue.Create(fileType) },
            { "glossary", glossary => JsonValue.Create(glossary) },
            { "hyperLink", hyperLink => JsonValue.Create(hyperLink) },
            { "iid", iid => JsonValue.Create(iid) },
            { "isDeprecated", isDeprecated => JsonValue.Create(isDeprecated) },
            { "modifiedOn", modifiedOn => JsonValue.Create(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => JsonValue.Create(name) },
            { "parameterType", parameterType => JsonValue.Create(parameterType) },
            { "referenceSource", referenceSource => JsonValue.Create(referenceSource) },
            { "requiredRdl", requiredRdl => JsonValue.Create(requiredRdl) },
            { "revisionNumber", revisionNumber => JsonValue.Create(revisionNumber) },
            { "rule", rule => JsonValue.Create(rule) },
            { "scale", scale => JsonValue.Create(scale) },
            { "shortName", shortName => JsonValue.Create(shortName) },
            { "thingPreference", thingPreference => JsonValue.Create(thingPreference) },
            { "unit", unit => JsonValue.Create(unit) },
            { "unitPrefix", unitPrefix => JsonValue.Create(unitPrefix) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteReferenceDataLibrary"/>
        /// </summary>
        /// <param name="siteReferenceDataLibrary">The <see cref="SiteReferenceDataLibrary"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(SiteReferenceDataLibrary siteReferenceDataLibrary)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](siteReferenceDataLibrary.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("baseQuantityKind", this.PropertySerializerMap["baseQuantityKind"](siteReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("baseUnit", this.PropertySerializerMap["baseUnit"](siteReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteReferenceDataLibrary.ClassKind)));
            jsonObject.Add("constant", this.PropertySerializerMap["constant"](siteReferenceDataLibrary.Constant.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("definedCategory", this.PropertySerializerMap["definedCategory"](siteReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](siteReferenceDataLibrary.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](siteReferenceDataLibrary.FileType.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("glossary", this.PropertySerializerMap["glossary"](siteReferenceDataLibrary.Glossary.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](siteReferenceDataLibrary.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteReferenceDataLibrary.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](siteReferenceDataLibrary.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteReferenceDataLibrary.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](siteReferenceDataLibrary.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](siteReferenceDataLibrary.ParameterType.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("referenceSource", this.PropertySerializerMap["referenceSource"](siteReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](siteReferenceDataLibrary.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteReferenceDataLibrary.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](siteReferenceDataLibrary.Rule.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](siteReferenceDataLibrary.Scale.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](siteReferenceDataLibrary.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](siteReferenceDataLibrary.ThingPreference));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](siteReferenceDataLibrary.Unit.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("unitPrefix", this.PropertySerializerMap["unitPrefix"](siteReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteReferenceDataLibrary"/> class.
        /// </summary>
        public IReadOnlyDictionary<string, Func<object, JsonValue>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        public JsonObject Serialize(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
            }

            var siteReferenceDataLibrary = thing as SiteReferenceDataLibrary;
            if (siteReferenceDataLibrary == null)
            {
                throw new InvalidOperationException("The thing is not a SiteReferenceDataLibrary.");
            }

            return this.Serialize(siteReferenceDataLibrary);
        }
    }
}
