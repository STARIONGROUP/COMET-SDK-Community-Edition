// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BehavioralParameterResolver.cs" company="RHEA System S.A.">
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
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="BehavioralParameterResolver"/> is to deserialize a JSON object to a <see cref="BehavioralParameter"/>
    /// </summary>
    public static class BehavioralParameterResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BehavioralParameter"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BehavioralParameter"/> to instantiate</returns>
        public static CDP4Common.DTO.BehavioralParameter FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var behavioralParameter = new CDP4Common.DTO.BehavioralParameter(iid, revisionNumber);

            if (!jObject["behavioralParameterKind"].IsNullOrEmpty())
            {
                behavioralParameter.BehavioralParameterKind = jObject["behavioralParameterKind"].ToObject<BehavioralParameterKind>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                behavioralParameter.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                behavioralParameter.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                behavioralParameter.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameter"].IsNullOrEmpty())
            {
                behavioralParameter.Parameter = jObject["parameter"].ToObject<Guid>();
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                behavioralParameter.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["variableName"].IsNullOrEmpty())
            {
                behavioralParameter.VariableName = jObject["variableName"].ToObject<string>();
            }

            return behavioralParameter;
        }
    }
}
