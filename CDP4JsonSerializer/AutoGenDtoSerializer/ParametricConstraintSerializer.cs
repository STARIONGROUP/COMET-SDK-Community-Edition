// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParametricConstraintSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParametricConstraintSerializer"/> class is to provide a <see cref="ParametricConstraint"/> specific serializer
    /// </summary>
    public class ParametricConstraintSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "expression", expression => new JArray(expression) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "topExpression", topExpression => new JValue(topExpression) },
        };

        /// <summary>
        /// Serialize the <see cref="ParametricConstraint"/>
        /// </summary>
        /// <param name="parametricConstraint">The <see cref="ParametricConstraint"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParametricConstraint parametricConstraint)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parametricConstraint.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parametricConstraint.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parametricConstraint.ExcludedPerson));
            jsonObject.Add("expression", this.PropertySerializerMap["expression"](parametricConstraint.Expression));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parametricConstraint.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parametricConstraint.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parametricConstraint.RevisionNumber));
            jsonObject.Add("topExpression", this.PropertySerializerMap["topExpression"](parametricConstraint.TopExpression));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParametricConstraint"/> class.
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

            var parametricConstraint = thing as ParametricConstraint;
            if (parametricConstraint == null)
            {
                throw new InvalidOperationException("The thing is not a ParametricConstraint.");
            }

            return this.Serialize(parametricConstraint);
        }
    }
}
