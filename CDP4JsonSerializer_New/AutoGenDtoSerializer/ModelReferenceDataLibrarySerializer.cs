// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ModelReferenceDataLibrarySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModelReferenceDataLibrarySerializer"/> class is to provide a <see cref="ModelReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class ModelReferenceDataLibrarySerializer : BaseThingSerializer, IThingSerializer
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
        /// Serialize the <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="modelReferenceDataLibrary">The <see cref="ModelReferenceDataLibrary"/> to serialize</param>
        /// <returns>The <see cref="JsonObject"/></returns>
        private JsonObject Serialize(ModelReferenceDataLibrary modelReferenceDataLibrary)
        {
            var jsonObject = new JsonObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](modelReferenceDataLibrary.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("baseQuantityKind", this.PropertySerializerMap["baseQuantityKind"](modelReferenceDataLibrary.BaseQuantityKind.OrderBy(x => x, this.orderedItemComparer)));
            jsonObject.Add("baseUnit", this.PropertySerializerMap["baseUnit"](modelReferenceDataLibrary.BaseUnit.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), modelReferenceDataLibrary.ClassKind)));
            jsonObject.Add("constant", this.PropertySerializerMap["constant"](modelReferenceDataLibrary.Constant.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("definedCategory", this.PropertySerializerMap["definedCategory"](modelReferenceDataLibrary.DefinedCategory.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](modelReferenceDataLibrary.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](modelReferenceDataLibrary.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](modelReferenceDataLibrary.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](modelReferenceDataLibrary.FileType.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("glossary", this.PropertySerializerMap["glossary"](modelReferenceDataLibrary.Glossary.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](modelReferenceDataLibrary.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](modelReferenceDataLibrary.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](modelReferenceDataLibrary.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](modelReferenceDataLibrary.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](modelReferenceDataLibrary.ParameterType.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("referenceSource", this.PropertySerializerMap["referenceSource"](modelReferenceDataLibrary.ReferenceSource.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](modelReferenceDataLibrary.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](modelReferenceDataLibrary.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](modelReferenceDataLibrary.Rule.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](modelReferenceDataLibrary.Scale.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](modelReferenceDataLibrary.ShortName));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](modelReferenceDataLibrary.ThingPreference));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](modelReferenceDataLibrary.Unit.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("unitPrefix", this.PropertySerializerMap["unitPrefix"](modelReferenceDataLibrary.UnitPrefix.OrderBy(x => x, this.guidComparer)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ModelReferenceDataLibrary"/> class.
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

            var modelReferenceDataLibrary = thing as ModelReferenceDataLibrary;
            if (modelReferenceDataLibrary == null)
            {
                throw new InvalidOperationException("The thing is not a ModelReferenceDataLibrary.");
            }

            return this.Serialize(modelReferenceDataLibrary);
        }
    }
}
