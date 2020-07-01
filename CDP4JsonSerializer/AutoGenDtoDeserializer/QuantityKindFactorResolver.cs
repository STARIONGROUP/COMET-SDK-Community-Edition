#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKindFactorResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="QuantityKindFactorResolver"/> is to deserialize a JSON object to a <see cref="QuantityKindFactor"/>
    /// </summary>
    public static class QuantityKindFactorResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="QuantityKindFactor"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="QuantityKindFactor"/> to instantiate</returns>
        public static CDP4Common.DTO.QuantityKindFactor FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var quantityKindFactor = new CDP4Common.DTO.QuantityKindFactor(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                quantityKindFactor.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                quantityKindFactor.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["exponent"].IsNullOrEmpty())
            {
                quantityKindFactor.Exponent = jObject["exponent"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                quantityKindFactor.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["quantityKind"].IsNullOrEmpty())
            {
                quantityKindFactor.QuantityKind = jObject["quantityKind"].ToObject<Guid>();
            }

            return quantityKindFactor;
        }
    }
}
