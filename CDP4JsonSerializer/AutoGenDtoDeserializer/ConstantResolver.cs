// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ConstantResolver"/> is to deserialize a JSON object to a <see cref="Constant"/>
    /// </summary>
    public static class ConstantResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Constant"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Constant"/> to instantiate</returns>
        public static CDP4Common.DTO.Constant FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var constant = new CDP4Common.DTO.Constant(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                constant.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                constant.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                constant.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                constant.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                constant.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                constant.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isDeprecated"].IsNullOrEmpty())
            {
                constant.IsDeprecated = jObject["isDeprecated"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                constant.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                constant.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                constant.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                constant.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                constant.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                constant.Value = SerializerHelper.ToValueArray<string>(jObject["value"].ToString());
            }

            return constant;
        }
    }
}
