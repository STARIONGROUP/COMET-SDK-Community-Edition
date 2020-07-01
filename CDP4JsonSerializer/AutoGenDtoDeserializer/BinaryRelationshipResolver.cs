// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// The purpose of the <see cref="BinaryRelationshipResolver"/> is to deserialize a JSON object to a <see cref="BinaryRelationship"/>
    /// </summary>
    public static class BinaryRelationshipResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="BinaryRelationship"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="BinaryRelationship"/> to instantiate</returns>
        public static CDP4Common.DTO.BinaryRelationship FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var binaryRelationship = new CDP4Common.DTO.BinaryRelationship(iid, revisionNumber);

            if (!jObject["category"].IsNullOrEmpty())
            {
                binaryRelationship.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                binaryRelationship.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                binaryRelationship.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                binaryRelationship.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                binaryRelationship.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameterValue"].IsNullOrEmpty())
            {
                binaryRelationship.ParameterValue.AddRange(jObject["parameterValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["source"].IsNullOrEmpty())
            {
                binaryRelationship.Source = jObject["source"].ToObject<Guid>();
            }

            if (!jObject["target"].IsNullOrEmpty())
            {
                binaryRelationship.Target = jObject["target"].ToObject<Guid>();
            }

            return binaryRelationship;
        }
    }
}
