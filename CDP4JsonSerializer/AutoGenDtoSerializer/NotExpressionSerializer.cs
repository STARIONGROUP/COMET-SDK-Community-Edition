// --------------------------------------------------------------------------------------------------------------------
// <copyright file "NotExpressionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="NotExpressionSerializer"/> class is to provide a <see cref="NotExpression"/> specific serializer
    /// </summary>
    public class NotExpressionSerializer : IThingSerializer
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
            { "term", term => new JValue(term) },
        };

        /// <summary>
        /// Serialize the <see cref="NotExpression"/>
        /// </summary>
        /// <param name="notExpression">The <see cref="NotExpression"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(NotExpression notExpression)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), notExpression.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](notExpression.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](notExpression.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](notExpression.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](notExpression.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](notExpression.RevisionNumber));
            jsonObject.Add("term", this.PropertySerializerMap["term"](notExpression.Term));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="NotExpression"/> class.
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

            var notExpression = thing as NotExpression;
            if (notExpression == null)
            {
                throw new InvalidOperationException("The thing is not a NotExpression.");
            }

            return this.Serialize(notExpression);
        }
    }
}
