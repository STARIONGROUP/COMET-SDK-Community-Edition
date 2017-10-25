// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="ParticipantResolver"/> is to deserialize a JSON object to a <see cref="Participant"/>
    /// </summary>
    public static class ParticipantResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Participant"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Participant"/> to instantiate</returns>
        public static CDP4Common.DTO.Participant FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var participant = new CDP4Common.DTO.Participant(iid, revisionNumber);

            if (!jObject["domain"].IsNullOrEmpty())
            {
                participant.Domain.AddRange(jObject["domain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                participant.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                participant.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["isActive"].IsNullOrEmpty())
            {
                participant.IsActive = jObject["isActive"].ToObject<bool>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                participant.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["person"].IsNullOrEmpty())
            {
                participant.Person = jObject["person"].ToObject<Guid>();
            }

            if (!jObject["role"].IsNullOrEmpty())
            {
                participant.Role = jObject["role"].ToObject<Guid>();
            }

            if (!jObject["selectedDomain"].IsNullOrEmpty())
            {
                participant.SelectedDomain = jObject["selectedDomain"].ToObject<Guid>();
            }

            return participant;
        }
    }
}
