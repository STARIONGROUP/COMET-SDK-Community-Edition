// --------------------------------------------------------------------------------------------------------------------
// <copyright file "IdCorrespondenceSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IdCorrespondenceSerializer"/> class is to provide a <see cref="IdCorrespondence"/> specific serializer
    /// </summary>
    public class IdCorrespondenceSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "externalId", externalId => new JValue(externalId) },
            { "iid", iid => new JValue(iid) },
            { "internalThing", internalThing => new JValue(internalThing) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="IdCorrespondence"/>
        /// </summary>
        /// <param name="idCorrespondence">The <see cref="IdCorrespondence"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(IdCorrespondence idCorrespondence)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), idCorrespondence.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](idCorrespondence.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](idCorrespondence.ExcludedPerson));
            jsonObject.Add("externalId", this.PropertySerializerMap["externalId"](idCorrespondence.ExternalId));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](idCorrespondence.Iid));
            jsonObject.Add("internalThing", this.PropertySerializerMap["internalThing"](idCorrespondence.InternalThing));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](idCorrespondence.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](idCorrespondence.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="IdCorrespondence"/> class.
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

            var idCorrespondence = thing as IdCorrespondence;
            if (idCorrespondence == null)
            {
                throw new InvalidOperationException("The thing is not a IdCorrespondence.");
            }

            return this.Serialize(idCorrespondence);
        }
    }
}
