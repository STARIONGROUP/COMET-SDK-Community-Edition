// --------------------------------------------------------------------------------------------------------------------
// <copyright file "EngineeringModelSetupSerializer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
//
//    This file is part of CDP4-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
    public class EngineeringModelSetupSerializer : BaseThingSerializer, IThingSerializer
    {
        /// <summary>
        /// The map containing the serialization methods
        /// </summary>
        private readonly Dictionary<string, Func<object, JToken>> propertySerializerMap = new Dictionary<string, Func<object, JToken>>
        {
            { "activeDomain", activeDomain => new JArray(activeDomain) },
            { "alias", alias => new JArray(alias) },
            { "classKind", classKind => new JValue(classKind.ToString()) },
            { "defaultOrganizationalParticipant", defaultOrganizationalParticipant => new JValue(defaultOrganizationalParticipant) },
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
            { "organizationalParticipant", organizationalParticipant => new JArray(organizationalParticipant) },
            { "participant", participant => new JArray(participant) },
            { "requiredRdl", requiredRdl => new JArray(requiredRdl) },
            { "revisionNumber", revisionNumber => new JValue(revisionNumber) },
            { "shortName", shortName => new JValue(shortName) },
            { "sourceEngineeringModelSetupIid", sourceEngineeringModelSetupIid => new JValue(sourceEngineeringModelSetupIid) },
            { "studyPhase", studyPhase => new JValue(studyPhase.ToString()) },
            { "thingPreference", thingPreference => new JValue(thingPreference) },
        };

        /// <summary>
        /// Serialize the <see cref="EngineeringModelSetup"/>
        /// </summary>
        /// <param name="engineeringModelSetup">The <see cref="EngineeringModelSetup"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        private JObject Serialize(EngineeringModelSetup engineeringModelSetup)
        {
            var jsonObject = new JObject();
            jsonObject.Add("activeDomain", this.PropertySerializerMap["activeDomain"](engineeringModelSetup.ActiveDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("alias", this.PropertySerializerMap["alias"](engineeringModelSetup.Alias.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("classKind", this.PropertySerializerMap["classKind"](Enum.GetName(typeof(CDP4Common.CommonData.ClassKind), engineeringModelSetup.ClassKind)));
            jsonObject.Add("defaultOrganizationalParticipant", this.PropertySerializerMap["defaultOrganizationalParticipant"](engineeringModelSetup.DefaultOrganizationalParticipant));
            jsonObject.Add("definition", this.PropertySerializerMap["definition"](engineeringModelSetup.Definition.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("engineeringModelIid", this.PropertySerializerMap["engineeringModelIid"](engineeringModelSetup.EngineeringModelIid));
            jsonObject.Add("excludedDomain", this.PropertySerializerMap["excludedDomain"](engineeringModelSetup.ExcludedDomain.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("excludedPerson", this.PropertySerializerMap["excludedPerson"](engineeringModelSetup.ExcludedPerson.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("hyperLink", this.PropertySerializerMap["hyperLink"](engineeringModelSetup.HyperLink.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("iid", this.PropertySerializerMap["iid"](engineeringModelSetup.Iid));
            jsonObject.Add("iterationSetup", this.PropertySerializerMap["iterationSetup"](engineeringModelSetup.IterationSetup.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("kind", this.PropertySerializerMap["kind"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.EngineeringModelKind), engineeringModelSetup.Kind)));
            jsonObject.Add("modifiedOn", this.PropertySerializerMap["modifiedOn"](engineeringModelSetup.ModifiedOn));
            jsonObject.Add("name", this.PropertySerializerMap["name"](engineeringModelSetup.Name));
            jsonObject.Add("organizationalParticipant", this.PropertySerializerMap["organizationalParticipant"](engineeringModelSetup.OrganizationalParticipant.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("participant", this.PropertySerializerMap["participant"](engineeringModelSetup.Participant.OrderBy(x => x, this.guidComparer)));
            jsonObject.Add("requiredRdl", this.PropertySerializerMap["requiredRdl"](engineeringModelSetup.RequiredRdl));
            jsonObject.Add("revisionNumber", this.PropertySerializerMap["revisionNumber"](engineeringModelSetup.RevisionNumber));
            jsonObject.Add("shortName", this.PropertySerializerMap["shortName"](engineeringModelSetup.ShortName));
            jsonObject.Add("sourceEngineeringModelSetupIid", this.PropertySerializerMap["sourceEngineeringModelSetupIid"](engineeringModelSetup.SourceEngineeringModelSetupIid));
            jsonObject.Add("studyPhase", this.PropertySerializerMap["studyPhase"](Enum.GetName(typeof(CDP4Common.SiteDirectoryData.StudyPhaseKind), engineeringModelSetup.StudyPhase)));
            jsonObject.Add("thingPreference", this.PropertySerializerMap["thingPreference"](engineeringModelSetup.ThingPreference));
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
                throw new ArgumentNullException($"The {nameof(thing)} may not be null.", nameof(thing));
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
