// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteReferenceDataLibrarySerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Serializer class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
    public class SiteReferenceDataLibrarySerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
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
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](siteReferenceDataLibrary.Alias));
            jsonObject.Add("baseQuantityKind", this.PropertySerializerMap["baseQuantityKind"](siteReferenceDataLibrary.BaseQuantityKind));
            jsonObject.Add("baseUnit", this.PropertySerializerMap["baseUnit"](siteReferenceDataLibrary.BaseUnit));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteReferenceDataLibrary.ClassKind)));
            jsonObject.Add("constant", this.PropertySerializerMap["constant"](siteReferenceDataLibrary.Constant));
            jsonObject.Add("definedCategory", this.PropertySerializerMap["definedCategory"](siteReferenceDataLibrary.DefinedCategory));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](siteReferenceDataLibrary.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteReferenceDataLibrary.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteReferenceDataLibrary.ExcludedPerson));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](siteReferenceDataLibrary.FileType));
            jsonObject.Add("glossary", this.PropertySerializerMap["glossary"](siteReferenceDataLibrary.Glossary));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](siteReferenceDataLibrary.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteReferenceDataLibrary.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](siteReferenceDataLibrary.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteReferenceDataLibrary.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](siteReferenceDataLibrary.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](siteReferenceDataLibrary.ParameterType));
            jsonObject.Add("referenceSource", this.PropertySerializerMap["referenceSource"](siteReferenceDataLibrary.ReferenceSource));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](siteReferenceDataLibrary.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteReferenceDataLibrary.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](siteReferenceDataLibrary.Rule));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](siteReferenceDataLibrary.Scale));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](siteReferenceDataLibrary.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](siteReferenceDataLibrary.Unit));
            jsonObject.Add("unitPrefix", this.PropertySerializerMap["unitPrefix"](siteReferenceDataLibrary.UnitPrefix));
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
                throw new ArgumentNullException("thing");
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
