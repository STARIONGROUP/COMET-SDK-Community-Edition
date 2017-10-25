// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameterResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
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
    /// The purpose of the <see cref="NestedParameterResolver"/> is to deserialize a JSON object to a <see cref="NestedParameter"/>
    /// </summary>
    public static class NestedParameterResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="NestedParameter"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="NestedParameter"/> to instantiate</returns>
        public static CDP4Common.DTO.NestedParameter FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var nestedParameter = new CDP4Common.DTO.NestedParameter(iid, revisionNumber);

            if (!jObject["actualState"].IsNullOrEmpty())
            {
                nestedParameter.ActualState = jObject["actualState"].ToObject<Guid?>();
            }

            if (!jObject["actualValue"].IsNullOrEmpty())
            {
                nestedParameter.ActualValue = jObject["actualValue"].ToObject<string>();
            }

            if (!jObject["associatedParameter"].IsNullOrEmpty())
            {
                nestedParameter.AssociatedParameter = jObject["associatedParameter"].ToObject<Guid>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                nestedParameter.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                nestedParameter.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["formula"].IsNullOrEmpty())
            {
                nestedParameter.Formula = jObject["formula"].ToObject<string>();
            }

            if (!jObject["isVolatile"].IsNullOrEmpty())
            {
                nestedParameter.IsVolatile = jObject["isVolatile"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                nestedParameter.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                nestedParameter.Owner = jObject["owner"].ToObject<Guid>();
            }

            return nestedParameter;
        }
    }
}
