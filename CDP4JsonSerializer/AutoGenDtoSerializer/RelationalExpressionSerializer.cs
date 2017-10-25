// --------------------------------------------------------------------------------------------------------------------
// <copyright file "RelationalExpressionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RelationalExpressionSerializer"/> class is to provide a <see cref="RelationalExpression"/> specific serializer
    /// </summary>
    public class RelationalExpressionSerializer : IThingSerializer
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
            { "parameterType", parameterType => new JValue(parameterType) },
            { "relationalOperator", relationalOperator => new JValue(relationalOperator.ToString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "scale", scale => new JValue(scale) },
            { "value", value => new JValue(((ValueArray<string>)value).ToJsonString()) },
        };

        /// <summary>
        /// Serialize the <see cref="RelationalExpression"/>
        /// </summary>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(RelationalExpression relationalExpression)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), relationalExpression.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](relationalExpression.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](relationalExpression.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](relationalExpression.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](relationalExpression.ModifiedOn));
            jsonObject.Add("parameterType", this.PropertySerializerMap["parameterType"](relationalExpression.ParameterType));
            jsonObject.Add("relationalOperator", this.PropertySerializerMap["relationalOperator"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.RelationalOperatorKind), relationalExpression.RelationalOperator)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](relationalExpression.RevisionNumber));
            jsonObject.Add("scale", this.PropertySerializerMap["scale"](relationalExpression.Scale));
            jsonObject.Add("value", this.PropertySerializerMap["value"](relationalExpression.Value));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="RelationalExpression"/> class.
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

            var relationalExpression = thing as RelationalExpression;
            if (relationalExpression == null)
            {
                throw new InvalidOperationException("The thing is not a RelationalExpression.");
            }

            return this.Serialize(relationalExpression);
        }
    }
}
