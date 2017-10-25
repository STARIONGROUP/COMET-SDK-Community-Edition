// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataNoteResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="EngineeringModelDataNoteResolver"/> is to deserialize a JSON object to a <see cref="EngineeringModelDataNote"/>
    /// </summary>
    public static class EngineeringModelDataNoteResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="EngineeringModelDataNote"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="EngineeringModelDataNote"/> to instantiate</returns>
        public static CDP4Common.DTO.EngineeringModelDataNote FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var engineeringModelDataNote = new CDP4Common.DTO.EngineeringModelDataNote(iid, revisionNumber);

            if (!jObject["author"].IsNullOrEmpty())
            {
                engineeringModelDataNote.Author = jObject["author"].ToObject<Guid>();
            }

            if (!jObject["content"].IsNullOrEmpty())
            {
                engineeringModelDataNote.Content = jObject["content"].ToObject<string>();
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                engineeringModelDataNote.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["discussion"].IsNullOrEmpty())
            {
                engineeringModelDataNote.Discussion.AddRange(jObject["discussion"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                engineeringModelDataNote.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                engineeringModelDataNote.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["languageCode"].IsNullOrEmpty())
            {
                engineeringModelDataNote.LanguageCode = jObject["languageCode"].ToObject<string>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                engineeringModelDataNote.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["primaryAnnotatedThing"].IsNullOrEmpty())
            {
                engineeringModelDataNote.PrimaryAnnotatedThing = jObject["primaryAnnotatedThing"].ToObject<Guid?>();
            }

            if (!jObject["relatedThing"].IsNullOrEmpty())
            {
                engineeringModelDataNote.RelatedThing.AddRange(jObject["relatedThing"].ToObject<IEnumerable<Guid>>());
            }

            return engineeringModelDataNote;
        }
    }
}
