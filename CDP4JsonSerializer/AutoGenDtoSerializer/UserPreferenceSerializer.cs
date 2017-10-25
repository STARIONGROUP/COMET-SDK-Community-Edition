// --------------------------------------------------------------------------------------------------------------------
// <copyright file "UserPreferenceSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UserPreferenceSerializer"/> class is to provide a <see cref="UserPreference"/> specific serializer
    /// </summary>
    public class UserPreferenceSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "value", value => new JValue(value) },
        };

        /// <summary>
        /// Serialize the <see cref="UserPreference"/>
        /// </summary>
        /// <param name="userPreference">The <see cref="UserPreference"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(UserPreference userPreference)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), userPreference.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](userPreference.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](userPreference.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](userPreference.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](userPreference.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](userPreference.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](userPreference.ShortName));
            jsonObject.Add("value", this.PropertySerializerMap["value"](userPreference.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="UserPreference"/> class.
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

            var userPreference = thing as UserPreference;
            if (userPreference == null)
            {
                throw new InvalidOperationException("The thing is not a UserPreference.");
            }

            return this.Serialize(userPreference);
        }
    }
}
