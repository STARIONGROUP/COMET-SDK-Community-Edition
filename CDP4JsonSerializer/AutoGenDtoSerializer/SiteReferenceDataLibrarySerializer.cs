// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteReferenceDataLibrarySerializer.cs" company="Starion Group S.A.">
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
    /// The purpose of the <see cref="SiteReferenceDataLibrarySerializer"/> class is to provide a <see cref="SiteReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class SiteReferenceDataLibrarySerializer : BaseThingSerializer, IThingSerializer
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
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
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
        /// Serialize the <see cref="SiteReferenceDataLibrary"/>
        /// </summary>
        /// <param name="siteReferenceDataLibrary">The <see cref="SiteReferenceDataLibrary"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteReferenceDataLibrary siteReferenceDataLibrary)
        {
            var jsonObject = new JObject();
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

            var siteReferenceDataLibrary = thing as SiteReferenceDataLibrary;
            if (siteReferenceDataLibrary == null)
            {
                throw new InvalidOperationException("The thing is not a SiteReferenceDataLibrary.");
            }

            return this.Serialize(siteReferenceDataLibrary);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
