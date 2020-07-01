// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EmailAddressSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EmailAddressSerializer"/> class is to provide a <see cref="EmailAddress"/> specific serializer
    /// </summary>
    public class EmailAddressSerializer : IThingSerializer
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
            { "value", value => new JValue(value) },
            { "vcardType", vcardType => new JValue(vcardType.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="EmailAddress"/>
        /// </summary>
        /// <param name="emailAddress">The <see cref="EmailAddress"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EmailAddress emailAddress)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), emailAddress.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](emailAddress.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](emailAddress.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](emailAddress.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](emailAddress.ModifiedOn));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](emailAddress.RevisionNumber));
            jsonObject.Add("value", this.PropertySerializerMap["value"](emailAddress.Value));
            jsonObject.Add("vcardType", this.PropertySerializerMap["vcardType"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.VcardEmailAddressKind), emailAddress.VcardType)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EmailAddress"/> class.
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

            var emailAddress = thing as EmailAddress;
            if (emailAddress == null)
            {
                throw new InvalidOperationException("The thing is not a EmailAddress.");
            }

            return this.Serialize(emailAddress);
        }
    }
}
