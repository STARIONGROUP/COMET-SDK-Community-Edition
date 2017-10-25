// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinitionResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DefinitionResolver"/> is to deserialize a JSON object to a <see cref="Definition"/>
    /// </summary>
    public static class DefinitionResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Definition"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Definition"/> to instantiate</returns>
        public static CDP4Common.DTO.Definition FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var definition = new CDP4Common.DTO.Definition(iid, revisionNumber);

            if (!jObject["citation"].IsNullOrEmpty())
            {
                definition.Citation.AddRange(jObject["citation"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                definition.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["example"].IsNullOrEmpty())
            {
                definition.Example.AddRange(jObject["example"].ToOrderedItemCollection());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                definition.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                definition.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                definition.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                definition.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["note"].IsNullOrEmpty())
            {
                definition.Note.AddRange(jObject["note"].ToOrderedItemCollection());
            }

            return definition;
        }
    }
}
