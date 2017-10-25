// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectoryThingReferenceSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectoryThingReferenceSerializer"/> class is to provide a <see cref="SiteDirectoryThingReference"/> specific serializer
    /// </summary>
    public class SiteDirectoryThingReferenceSerializer : IThingSerializer
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
            { "referencedRevisionNumber", referencedRevisionNumber => new JValue(referencedRevisionNumber) },
            { "referencedThing", referencedThing => new JValue(referencedThing) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectoryThingReference"/>
        /// </summary>
        /// <param name="siteDirectoryThingReference">The <see cref="SiteDirectoryThingReference"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteDirectoryThingReference siteDirectoryThingReference)
        {
            var jsonObject = new JObject();
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectoryThingReference.ClassKind)));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectoryThingReference.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectoryThingReference.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteDirectoryThingReference.Iid));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectoryThingReference.ModifiedOn));
            jsonObject.Add("referencedRevisionNumber", this.PropertySerializerMap["referencedRevisionNumber"](siteDirectoryThingReference.ReferencedRevisionNumber));
            jsonObject.Add("referencedThing", this.PropertySerializerMap["referencedThing"](siteDirectoryThingReference.ReferencedThing));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectoryThingReference.RevisionNumber));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectoryThingReference"/> class.
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

            var siteDirectoryThingReference = thing as SiteDirectoryThingReference;
            if (siteDirectoryThingReference == null)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectoryThingReference.");
            }

            return this.Serialize(siteDirectoryThingReference);
        }
    }
}
