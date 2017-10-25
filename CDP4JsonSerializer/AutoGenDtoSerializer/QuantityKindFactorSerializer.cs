// --------------------------------------------------------------------------------------------------------------------
// <copyright file "QuantityKindFactorSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="QuantityKindFactorSerializer"/> class is to provide a <see cref="QuantityKindFactor"/> specific serializer
    /// </summary>
    public class QuantityKindFactorSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "exponent", exponent => new JValue(exponent) },
            { "iid", iid => new JValue(iid) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "quantityKind", quantityKind => new JValue(quantityKind) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="QuantityKindFactor"/>
        /// </summary>
        /// <param name="quantityKindFactor">The <see cref="QuantityKindFactor"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(QuantityKindFactor quantityKindFactor)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), quantityKindFactor.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](quantityKindFactor.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](quantityKindFactor.ExcludedPerson));
            jsonObject.Add("exponent", this.PropertySerializerMap["exponent"](quantityKindFactor.Exponent));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](quantityKindFactor.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](quantityKindFactor.ModifiedOn));
            jsonObject.Add("quantityKind", this.PropertySerializerMap["quantityKind"](quantityKindFactor.QuantityKind));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](quantityKindFactor.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="QuantityKindFactor"/> class.
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

            var quantityKindFactor = thing as QuantityKindFactor;
            if (quantityKindFactor == null)
            {
                throw new InvalidOperationException("The thing is not a QuantityKindFactor.");
            }

            return this.Serialize(quantityKindFactor);
        }
    }
}
