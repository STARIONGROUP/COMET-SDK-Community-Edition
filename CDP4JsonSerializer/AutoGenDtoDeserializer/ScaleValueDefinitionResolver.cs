// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScaleValueDefinitionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ScaleValueDefinitionResolver"/> is to deserialize a JSON object to a <see cref="ScaleValueDefinition"/>
    /// </summary>
    public static class ScaleValueDefinitionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ScaleValueDefinition"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ScaleValueDefinition"/> to instantiate</returns>
        public static CDP4Common.DTO.ScaleValueDefinition FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var scaleValueDefinition = new CDP4Common.DTO.ScaleValueDefinition(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                scaleValueDefinition.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                scaleValueDefinition.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                scaleValueDefinition.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                scaleValueDefinition.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                scaleValueDefinition.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                scaleValueDefinition.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                scaleValueDefinition.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                scaleValueDefinition.ShortName = jObject["shortName"].ToObject<string>();
            }

            if (!jObject["value"].IsNullOrEmpty())
            {
                scaleValueDefinition.Value = jObject["value"].ToObject<string>();
            }

            return scaleValueDefinition;
        }
    }
}
