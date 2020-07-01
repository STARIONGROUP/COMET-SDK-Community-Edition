// --------------------------------------------------------------------------------------------------------------------
// <copyright file "CategorySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="CategorySerializer"/> class is to provide a <see cref="Category"/> specific serializer
    /// </summary>
    public class CategorySerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "isAbstract", isAbstract => new JValue(isAbstract) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "permissibleClass", permissibleClass => new JArray(permissibleClass) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "superCategory", superCategory => new JArray(superCategory) },
        };

        /// <summary>
        /// Serialize the <see cref="Category"/>
        /// </summary>
        /// <param name="category">The <see cref="Category"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Category category)
        {
            var jsonObject = new JObject();
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](category.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), category.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](category.Definition));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](category.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](category.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](category.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](category.Iid));
            jsonObject.Add("isAbstract", this.PropertySerializerMap["isAbstract"](category.IsAbstract));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](category.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](category.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](category.Name));
            jsonObject.Add("permissibleClass", this.PropertySerializerMap["permissibleClass"](category.PermissibleClass.Select(e => Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), e))));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](category.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](category.ShortName));
            jsonObject.Add("superCategory", this.PropertySerializerMap["superCategory"](category.SuperCategory));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Category"/> class.
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

            var category = thing as Category;
            if (category == null)
            {
                throw new InvalidOperationException("The thing is not a Category.");
            }

            return this.Serialize(category);
        }
    }
}
