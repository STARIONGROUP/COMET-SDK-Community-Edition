#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionValueSetResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
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
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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
    /// The purpose of the <see cref="ParameterSubscriptionValueSetResolver"/> is to deserialize a JSON object to a <see cref="ParameterSubscriptionValueSet"/>
    /// </summary>
    public static class ParameterSubscriptionValueSetResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ParameterSubscriptionValueSet"/> to instantiate</returns>
        public static CDP4Common.DTO.ParameterSubscriptionValueSet FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var parameterSubscriptionValueSet = new CDP4Common.DTO.ParameterSubscriptionValueSet(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["manual"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.Manual = SerializerHelper.ToValueArray<string>(jObject["manual"].ToString());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["subscribedValueSet"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.SubscribedValueSet = jObject["subscribedValueSet"].ToObject<Guid>();
            }

            if (!jObject["valueSwitch"].IsNullOrEmpty())
            {
                parameterSubscriptionValueSet.ValueSwitch = jObject["valueSwitch"].ToObject<ParameterSwitchKind>();
            }

            return parameterSubscriptionValueSet;
        }
    }
}
