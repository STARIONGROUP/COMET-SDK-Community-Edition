// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParameterValueSetSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParameterValueSetSerializer"/> class is to provide a <see cref="ParameterValueSet"/> specific serializer
    /// </summary>
    public class ParameterValueSetSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "actualOption", actualOption => new JValue(actualOption) },
            { "actualState", actualState => new JValue(actualState) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "computed", computed => new JValue(((ValueArray<string>)computed).ToJsonString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "formula", formula => new JValue(((ValueArray<string>)formula).ToJsonString()) },
            { "iid", iid => new JValue(iid) },
            { "manual", manual => new JValue(((ValueArray<string>)manual).ToJsonString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "published", published => new JValue(((ValueArray<string>)published).ToJsonString()) },
            { "reference", reference => new JValue(((ValueArray<string>)reference).ToJsonString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "valueSwitch", valueSwitch => new JValue(valueSwitch.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="ParameterValueSet"/>
        /// </summary>
        /// <param name="parameterValueSet">The <see cref="ParameterValueSet"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParameterValueSet parameterValueSet)
        {
            var jsonObject = new JObject();
            jsonObject.Add("actualOption", this.PropertySerializerMap["actualOption"](parameterValueSet.ActualOption));
            jsonObject.Add("actualState", this.PropertySerializerMap["actualState"](parameterValueSet.ActualState));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), parameterValueSet.ClassKind)));
            jsonObject.Add("computed", this.PropertySerializerMap["computed"](parameterValueSet.Computed));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](parameterValueSet.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](parameterValueSet.ExcludedPerson));
            jsonObject.Add("formula", this.PropertySerializerMap["formula"](parameterValueSet.Formula));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](parameterValueSet.Iid));
            jsonObject.Add("manual", this.PropertySerializerMap["manual"](parameterValueSet.Manual));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](parameterValueSet.ModifiedOn));
            jsonObject.Add("published", this.PropertySerializerMap["published"](parameterValueSet.Published));
            jsonObject.Add("reference", this.PropertySerializerMap["reference"](parameterValueSet.Reference));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](parameterValueSet.RevisionNumber));
            jsonObject.Add("valueSwitch", this.PropertySerializerMap["valueSwitch"](Enum.GetName(typeof(CDP4Common.EngineeringModelData.ParameterSwitchKind), parameterValueSet.ValueSwitch)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParameterValueSet"/> class.
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

            var parameterValueSet = thing as ParameterValueSet;
            if (parameterValueSet == null)
            {
                throw new InvalidOperationException("The thing is not a ParameterValueSet.");
            }

            return this.Serialize(parameterValueSet);
        }
    }
}
