// --------------------------------------------------------------------------------------------------------------------
// <copyright file "ParticipantPermissionSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParticipantPermissionSerializer"/> class is to provide a <see cref="ParticipantPermission"/> specific serializer
    /// </summary>
    public class ParticipantPermissionSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "accessRight", accessRight => new JValue(accessRight.ToString()) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "isDeprecated", isDeprecated => new JValue(isDeprecated) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "objectClass", objectClass => new JValue(objectClass.ToString()) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="ParticipantPermission"/>
        /// </summary>
        /// <param name="participantPermission">The <see cref="ParticipantPermission"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(ParticipantPermission participantPermission)
        {
            var jsonObject = new JObject();
            jsonObject.Add("accessRight", this.PropertySerializerMap["accessRight"](Enum.GetName(typeof(CDP4Common.CommonData.ParticipantAccessRightKind), participantPermission.AccessRight)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), participantPermission.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](participantPermission.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](participantPermission.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](participantPermission.Iid));
            jsonObject.Add("isDeprecated", this.PropertySerializerMap["isDeprecated"](participantPermission.IsDeprecated));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](participantPermission.ModifiedOn));
            jsonObject.Add("objectClass", this.PropertySerializerMap["objectClass"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), participantPermission.ObjectClass)));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](participantPermission.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="ParticipantPermission"/> class.
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

            var participantPermission = thing as ParticipantPermission;
            if (participantPermission == null)
            {
                throw new InvalidOperationException("The thing is not a ParticipantPermission.");
            }

            return this.Serialize(participantPermission);
        }
    }
}
