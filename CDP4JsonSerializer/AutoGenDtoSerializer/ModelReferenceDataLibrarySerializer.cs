// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ModelReferenceDataLibrarySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ModelReferenceDataLibrarySerializer"/> class is to provide a <see cref="ModelReferenceDataLibrary"/> specific serializer
    /// </summary>
    public class ModelReferenceDataLibrarySerializer : IThingSerializer
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
        /// Serialize the <see cref="ModelReferenceDataLibrary"/>
        /// </summary>
        /// <param name="modelReferenceDataLibrary">The <see cref="ModelReferenceDataLibrary"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ModelReferenceDataLibrary modelReferenceDataLibrary)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](modelReferenceDataLibrary.Alias));
            jsonObject.Add("baseQuantityKind", this.PropertySerializerMap["baseQuantityKind"](modelReferenceDataLibrary.BaseQuantityKind));
            jsonObject.Add("baseUnit", this.PropertySerializerMap["baseUnit"](modelReferenceDataLibrary.BaseUnit));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), modelReferenceDataLibrary.ClassKind)));
            jsonObject.Add("constant", this.PropertySerializerMap["constant"](modelReferenceDataLibrary.Constant));
            jsonObject.Add("definedCategory", this.PropertySerializerMap["definedCategory"](modelReferenceDataLibrary.DefinedCategory));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](modelReferenceDataLibrary.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](modelReferenceDataLibrary.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](modelReferenceDataLibrary.ExcludedPerson));
            jsonObject.Add("fileType", this.PropertySerializerMap["fileType"](modelReferenceDataLibrary.FileType));
            jsonObject.Add("glossary", this.PropertySerializerMap["glossary"](modelReferenceDataLibrary.Glossary));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](modelReferenceDataLibrary.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](modelReferenceDataLibrary.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](modelReferenceDataLibrary.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](modelReferenceDataLibrary.Name));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](modelReferenceDataLibrary.ParameterType));
            jsonObject.Add("referenceSource", this.PropertySerializerMap["referenceSource"](modelReferenceDataLibrary.ReferenceSource));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](modelReferenceDataLibrary.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](modelReferenceDataLibrary.RevisionNumber));
            jsonObject.Add("rule", this.PropertySerializerMap["rule"](modelReferenceDataLibrary.Rule));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](modelReferenceDataLibrary.Scale));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](modelReferenceDataLibrary.ShortName));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](modelReferenceDataLibrary.Unit));
            jsonObject.Add("unitPrefix", this.PropertySerializerMap["unitPrefix"](modelReferenceDataLibrary.UnitPrefix));
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
                throw new ArgumentNullException("thing");
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
