// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParticipantSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParticipantSerializer"/> class is to provide a <see cref="Participant"/> specific serializer
    /// </summary>
    public class ParticipantSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "domain", domain => new JArray(domain) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isActive", isActive => new JValue(isActive) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "person", person => new JValue(person) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "role", role => new JValue(role) },
            { "selectedDomain", selectedDomain => new JValue(selectedDomain) },
        };

        /// <summary>
        /// Serialize the <see cref="Participant"/>
        /// </summary>
        /// <param name="participant">The <see cref="Participant"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(Participant participant)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), participant.ClassKind)));
            jsonObject.Add("domain", this.PropertySerializerMap["domain"](participant.Domain));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](participant.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](participant.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](participant.Iid));
            jsonObject.Add("isActive", this.PropertySerializerMap["isActive"](participant.IsActive));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](participant.ModifiedOn));
            jsonObject.Add("person", this.PropertySerializerMap["person"](participant.Person));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](participant.RevisionNumber));
            jsonObject.Add("role", this.PropertySerializerMap["role"](participant.Role));
            jsonObject.Add("selectedDomain", this.PropertySerializerMap["selectedDomain"](participant.SelectedDomain));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="Participant"/> class.
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

            var participant = thing as Participant;
            if (participant == null)
            {
                throw new InvalidOperationException("The thing is not a Participant.");
            }

            return this.Serialize(participant);
        }
    }
}
