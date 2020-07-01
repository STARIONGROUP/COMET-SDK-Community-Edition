// --------------------------------------------------------------------------------------------------------------------
// <copyright file "UnitFactorSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="UnitFactorSerializer"/> class is to provide a <see cref="UnitFactor"/> specific serializer
    /// </summary>
    public class UnitFactorSerializer : IThingSerializer
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
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "unit", unit => new JValue(unit) },
        };

        /// <summary>
        /// Serialize the <see cref="UnitFactor"/>
        /// </summary>
        /// <param name="unitFactor">The <see cref="UnitFactor"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(UnitFactor unitFactor)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), unitFactor.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](unitFactor.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](unitFactor.ExcludedPerson));
            jsonObject.Add("exponent", this.PropertySerializerMap["exponent"](unitFactor.Exponent));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](unitFactor.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](unitFactor.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](unitFactor.RevisionNumber));
            jsonObject.Add("unit", this.PropertySerializerMap["unit"](unitFactor.Unit));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="UnitFactor"/> class.
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

            var unitFactor = thing as UnitFactor;
            if (unitFactor == null)
            {
                throw new InvalidOperationException("The thing is not a UnitFactor.");
            }

            return this.Serialize(unitFactor);
        }
    }
}
