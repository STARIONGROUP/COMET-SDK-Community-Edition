// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehaviorResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
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
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="BehaviorResolver"/> is to deserialize a JSON object to a <see cref="Behavior"/>
    /// </summary>
    public static class BehaviorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Behavior"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Behavior"/> to instantiate</returns>
        public static CDP4Common.DTO.Behavior FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var behavior = new CDP4Common.DTO.Behavior(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                behavior.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["behavioralModelKind"].IsNullOrEmpty())
            {
                behavior.BehavioralModelKind = jObject["behavioralModelKind"].ToObject<BehavioralModelKind>();
            }

            if (!jObject["behavioralParameter"].IsNullOrEmpty())
            {
                behavior.BehavioralParameter.AddRange(jObject["behavioralParameter"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                behavior.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                behavior.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                behavior.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["file"].IsNullOrEmpty())
            {
                behavior.File = jObject["file"].ToObject<Guid?>();
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                behavior.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                behavior.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                behavior.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                behavior.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["script"].IsNullOrEmpty())
            {
                behavior.Script = jObject["script"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                behavior.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                behavior.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            return behavior;
        }
    }
}
