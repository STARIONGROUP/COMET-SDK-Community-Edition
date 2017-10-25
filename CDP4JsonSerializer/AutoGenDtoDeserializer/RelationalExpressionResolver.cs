// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalExpressionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="RelationalExpressionResolver"/> is to deserialize a JSON object to a <see cref="RelationalExpression"/>
    /// </summary>
    public static class RelationalExpressionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="RelationalExpression"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="RelationalExpression"/> to instantiate</returns>
        public static CDP4Common.DTO.RelationalExpression FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var relationalExpression = new CDP4Common.DTO.RelationalExpression(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                relationalExpression.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                relationalExpression.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                relationalExpression.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["parameterType"].IsNullOrEmpty())
            {
                relationalExpression.ParameterType = jObject["parameterType"].ToObject<Guid>();
            }

            if (!jObject["relationalOperator"].IsNullOrEmpty())
            {
                relationalExpression.RelationalOperator = jObject["relationalOperator"].ToObject<RelationalOperatorKind>();
            }

            if (!jObject["scale"].IsNullOrEmpty())
            {
                relationalExpression.Scale = jObject["scale"].ToObject<Guid?>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                relationalExpression.Value = SerializerHelper.ToValueArray<string>(jObject["value"].ToString());
            }

            return relationalExpression;
        }
    }
}
