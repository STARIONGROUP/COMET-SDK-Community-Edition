// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModelReferenceDataLibrarySerializer.cs" company="Starion Group S.A.">
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.Types;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="ModelReferenceDataLibrarySerializer"/> class is to provide a <see cref="ModelReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class ModelReferenceDataLibrarySerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actor", actor => new JValue(actor) },
            { "alias", alias => new JArray(alias) },
            { "baseQuantityKind", baseQuantityKind => new JArray(((IEnumerable)baseQuantityKind).Cast<OrderedItem>().Select(x => x.ToJsonObject())) },
            { "baseUnit", baseUnit => new JArray(baseUnit) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "constant", constant => new JArray(constant) },
            { "definedCategory", definedCategory => new JArray(definedCategory) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "fileType", fileType => new JArray(fileType) },
            { "glossary", glossary => new JArray(glossary) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "parameterType", parameterType => new JArray(parameterType) },
            { "referenceSource", referenceSource => new JArray(referenceSource) },
            { "requiredRdl", requiredRdl => new JValue(requiredRdl) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "rule", rule => new JArray(rule) },
            { "scale", scale => new JArray(scale) },
            { "shortName", shortName => new JValue(shortName) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
            { "unit", unit => new JArray(unit) },
            { "unitPrefix", unitPrefix => new JArray(unitPrefix) },
        };

        /// <summary>
        /// Serialize the <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="modelReferenceDataLibrary">The <see cref="ModelReferenceDataLibrary"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ModelReferenceDataLibrary modelReferenceDataLibrary)
        {
            var jsonObject = new JObject();
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
        public IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap 
        {
            get { return this.propertySerializerMap; }
        }

        /// <summary>
        /// Serialize the <see cref="Thing"/> to JObject
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        public JObject Serialize(Thing thing)
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
