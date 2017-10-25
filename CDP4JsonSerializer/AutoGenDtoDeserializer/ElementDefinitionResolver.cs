// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ElementDefinitionResolver"/> is to deserialize a JSON object to a <see cref="ElementDefinition"/>
    /// </summary>
    public static class ElementDefinitionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="ElementDefinition"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="ElementDefinition"/> to instantiate</returns>
        public static CDP4Common.DTO.ElementDefinition FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var elementDefinition = new CDP4Common.DTO.ElementDefinition(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                elementDefinition.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                elementDefinition.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["containedElement"].IsNullOrEmpty())
            {
                elementDefinition.ContainedElement.AddRange(jObject["containedElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                elementDefinition.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                elementDefinition.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                elementDefinition.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                elementDefinition.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                elementDefinition.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                elementDefinition.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                elementDefinition.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["parameter"].IsNullOrEmpty())
            {
                elementDefinition.Parameter.AddRange(jObject["parameter"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["parameterGroup"].IsNullOrEmpty())
            {
                elementDefinition.ParameterGroup.AddRange(jObject["parameterGroup"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["referencedElement"].IsNullOrEmpty())
            {
                elementDefinition.ReferencedElement.AddRange(jObject["referencedElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                elementDefinition.ShortName = jObject["shortName"].ToObject<string>();
            }

            return elementDefinition;
        }
    }
}
