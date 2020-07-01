// --------------------------------------------------------------------------------------------------------------------
// <copyright file "AndExpressionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="AndExpressionSerializer"/> class is to provide a <see cref="AndExpression"/> specific serializer
    /// </summary>
    public class AndExpressionSerializer : IThingSerializer
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
            { "term", term => new JArray(term) },
        };

        /// <summary>
        /// Serialize the <see cref="AndExpression"/>
        /// </summary>
        /// <param name="andExpression">The <see cref="AndExpression"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(AndExpression andExpression)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), andExpression.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](andExpression.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](andExpression.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](andExpression.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](andExpression.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](andExpression.RevisionNumber));
            jsonObject.Add("term", this.PropertySerializerMap["term"](andExpression.Term));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="AndExpression"/> class.
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

            var andExpression = thing as AndExpression;
            if (andExpression == null)
            {
                throw new InvalidOperationException("The thing is not a AndExpression.");
            }

            return this.Serialize(andExpression);
        }
    }
}
