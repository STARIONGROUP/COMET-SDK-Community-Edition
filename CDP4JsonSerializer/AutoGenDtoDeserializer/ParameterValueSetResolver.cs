// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// The purpose of the <see cref="ParameterValueSetResolver"/> is to deserialize a JSON object to a <see cref="ParameterValueSet"/>
    /// </summary>
    public static class ParameterValueSetResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterValueSet"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterValueSet FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterValueSet = new CDP4Common.DTO.ParameterValueSet(iid, revisionNumber);

            if (!jObject["actualOption"].IsNullOrEmpty())
            {
                parameterValueSet.ActualOption = jObject["actualOption"].ToObject<Guid?>();
            }

            if (!jObject["actualState"].IsNullOrEmpty())
            {
                parameterValueSet.ActualState = jObject["actualState"].ToObject<Guid?>();
            }

            if (!jObject["computed"].IsNullOrEmpty())
            {
                parameterValueSet.Computed = SerializerHelper.ToValueArray<string>(jObject["computed"].ToString());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterValueSet.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterValueSet.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["formula"].IsNullOrEmpty())
            {
                parameterValueSet.Formula = SerializerHelper.ToValueArray<string>(jObject["formula"].ToString());
            }

            if (!jObject["manual"].IsNullOrEmpty())
            {
                parameterValueSet.Manual = SerializerHelper.ToValueArray<string>(jObject["manual"].ToString());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterValueSet.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["published"].IsNullOrEmpty())
            {
                parameterValueSet.Published = SerializerHelper.ToValueArray<string>(jObject["published"].ToString());
            }

            if (!jObject["reference"].IsNullOrEmpty())
            {
                parameterValueSet.Reference = SerializerHelper.ToValueArray<string>(jObject["reference"].ToString());
            }

            if (!jObject["thingPreference"].IsNullOrEmpty())
            {
                parameterValueSet.ThingPreference = jObject["thingPreference"].ToObject<string>();
            }

            if (!jObject["valueSwitch"].IsNullOrEmpty())
            {
                parameterValueSet.ValueSwitch = jObject["valueSwitch"].ToObject<ParameterSwitchKind>();
            }

            return parameterValueSet;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
