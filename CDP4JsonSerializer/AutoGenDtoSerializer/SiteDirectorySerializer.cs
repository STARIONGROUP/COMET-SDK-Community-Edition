// --------------------------------------------------------------------------------------------------------------------
// <copyright file "SiteDirectorySerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="SiteDirectorySerializer"/> class is to provide a <see cref="SiteDirectory"/> specific serializer
    /// </summary>
    public class SiteDirectorySerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "annotation", annotation => new JArray(annotation) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "createdOn", createdOn => new JValue(((DateTime)createdOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "defaultParticipantRole", defaultParticipantRole => new JValue(defaultParticipantRole) },
            { "defaultPersonRole", defaultPersonRole => new JValue(defaultPersonRole) },
            { "domain", domain => new JArray(domain) },
            { "domainGroup", domainGroup => new JArray(domainGroup) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "iid", iid => new JValue(iid) },
            { "lastModifiedOn", lastModifiedOn => new JValue(((DateTime)lastModifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "logEntry", logEntry => new JArray(logEntry) },
            { "model", model => new JArray(model) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "naturalLanguage", naturalLanguage => new JArray(naturalLanguage) },
            { "organization", organization => new JArray(organization) },
            { "participantRole", participantRole => new JArray(participantRole) },
            { "person", person => new JArray(person) },
            { "personRole", personRole => new JArray(personRole) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "siteReferenceDataLibrary", siteReferenceDataLibrary => new JArray(siteReferenceDataLibrary) },
        };

        /// <summary>
        /// Serialize the <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="siteDirectory">The <see cref="SiteDirectory"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(SiteDirectory siteDirectory)
        {
            var jsonObject = new JObject();
            jsonObject.Add("annotation", this.PropertySerializerMap["annotation"](siteDirectory.Annotation));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), siteDirectory.ClassKind)));
            jsonObject.Add("createdOn", this.PropertySerializerMap["createdOn"](siteDirectory.CreatedOn));
            jsonObject.Add("defaultParticipantRole", this.PropertySerializerMap["defaultParticipantRole"](siteDirectory.DefaultParticipantRole));
            jsonObject.Add("defaultPersonRole", this.PropertySerializerMap["defaultPersonRole"](siteDirectory.DefaultPersonRole));
            jsonObject.Add("domain", this.PropertySerializerMap["domain"](siteDirectory.Domain));
            jsonObject.Add("domainGroup", this.PropertySerializerMap["domainGroup"](siteDirectory.DomainGroup));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](siteDirectory.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](siteDirectory.ExcludedPerson));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](siteDirectory.Iid));
            jsonObject.Add("lastModifiedOn", this.PropertySerializerMap["lastModifiedOn"](siteDirectory.LastModifiedOn));
            jsonObject.Add("logEntry", this.PropertySerializerMap["logEntry"](siteDirectory.LogEntry));
            jsonObject.Add("model", this.PropertySerializerMap["model"](siteDirectory.Model));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](siteDirectory.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](siteDirectory.Name));
            jsonObject.Add("naturalLanguage", this.PropertySerializerMap["naturalLanguage"](siteDirectory.NaturalLanguage));
            jsonObject.Add("organization", this.PropertySerializerMap["organization"](siteDirectory.Organization));
            jsonObject.Add("participantRole", this.PropertySerializerMap["participantRole"](siteDirectory.ParticipantRole));
            jsonObject.Add("person", this.PropertySerializerMap["person"](siteDirectory.Person));
            jsonObject.Add("personRole", this.PropertySerializerMap["personRole"](siteDirectory.PersonRole));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](siteDirectory.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](siteDirectory.ShortName));
            jsonObject.Add("siteReferenceDataLibrary", this.PropertySerializerMap["siteReferenceDataLibrary"](siteDirectory.SiteReferenceDataLibrary));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="SiteDirectory"/> class.
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

            var siteDirectory = thing as SiteDirectory;
            if (siteDirectory == null)
            {
                throw new InvalidOperationException("The thing is not a SiteDirectory.");
            }

            return this.Serialize(siteDirectory);
        }
    }
}
