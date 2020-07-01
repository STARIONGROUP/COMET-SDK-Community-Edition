// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EngineeringModelSetupSerializer.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelSetupSerializer"/> class is to provide a <see cref="EngineeringModelSetup"/> specific serializer
    /// </summary>
    public class EngineeringModelSetupSerializer : IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "activeDomain", activeDomain => new JArray(activeDomain) },
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "definition", definition => new JArray(definition) },
            { "engineeringModelIid", engineeringModelIid => new JValue(engineeringModelIid) },
            { "excludedDomain", excludedDomain => new JArray(excludedDomain) },
            { "excludedPerson", excludedPerson => new JArray(excludedPerson) },
            { "hyperLink", hyperLink => new JArray(hyperLink) },
            { "iid", iid => new JValue(iid) },
            { "iterationSetup", iterationSetup => new JArray(iterationSetup) },
            { "kind", kind => new JValue(kind.ToString()) },
            { "modifiedOn", modifiedOn => new JValue(((DateTime)modifiedOn).ToString("yyyy-MM-ddTHH:mm:ss.fffZ")) },
            { "name", name => new JValue(name) },
            { "participant", participant => new JArray(participant) },
            { "requiredRdl", requiredRdl => new JArray(requiredRdl) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "sourceEngineeringModelSetupIid", sourceEngineeringModelSetupIid => new JValue(sourceEngineeringModelSetupIid) },
            { "studyPhase", studyPhase => new JValue(studyPhase.ToString()) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="engineeringModelSetup">The <see cref="EngineeringModelSetup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EngineeringModelSetup engineeringModelSetup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("activeDomain", this.PropertySerializerMap["activeDomain"](engineeringModelSetup.ActiveDomain));
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](engineeringModelSetup.Alias));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), engineeringModelSetup.ClassKind)));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](engineeringModelSetup.Definition));
            jsonObject.Add("engineeringModelIid", this.PropertySerializerMap["engineeringModelIid"](engineeringModelSetup.EngineeringModelIid));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](engineeringModelSetup.ExcludedDomain));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](engineeringModelSetup.ExcludedPerson));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](engineeringModelSetup.HyperLink));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](engineeringModelSetup.Iid));
            jsonObject.Add("iterationSetup", this.PropertySerializerMap["iterationSetup"](engineeringModelSetup.IterationSetup));
            jsonObject.Add("kind", this.PropertySerializerMap["kind"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.EngineeringModelKind), engineeringModelSetup.Kind)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](engineeringModelSetup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](engineeringModelSetup.Name));
            jsonObject.Add("participant", this.PropertySerializerMap["participant"](engineeringModelSetup.Participant));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](engineeringModelSetup.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](engineeringModelSetup.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](engineeringModelSetup.ShortName));
            jsonObject.Add("sourceEngineeringModelSetupIid", this.PropertySerializerMap["sourceEngineeringModelSetupIid"](engineeringModelSetup.SourceEngineeringModelSetupIid));
            jsonObject.Add("studyPhase", this.PropertySerializerMap["studyPhase"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.StudyPhaseKind), engineeringModelSetup.StudyPhase)));
            return jsonObject;
        }

        /// <summary>
        /// Gets the map containing the serialization method for each property of the <see cref="EngineeringModelSetup"/> class.
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

            var engineeringModelSetup = thing as EngineeringModelSetup;
            if (engineeringModelSetup == null)
            {
                throw new InvalidOperationException("The thing is not a EngineeringModelSetup.");
            }

            return this.Serialize(engineeringModelSetup);
        }
    }
}
