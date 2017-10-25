// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramObjectResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramObjectResolver"/> is to deserialize a JSON object to a <see cref="DiagramObject"/>
    /// </summary>
    public static class DiagramObjectResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DiagramObject"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DiagramObject"/> to instantiate</returns>
        public static CDP4Common.DTO.DiagramObject FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var diagramObject = new CDP4Common.DTO.DiagramObject(iid, revisionNumber);

            if (!jObject["bounds"].IsNullOrEmpty())
            {
                diagramObject.Bounds.AddRange(jObject["bounds"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["depictedThing"].IsNullOrEmpty())
            {
                diagramObject.DepictedThing = jObject["depictedThing"].ToObject<Guid?>();
            }

            if (!jObject["diagramElement"].IsNullOrEmpty())
            {
                diagramObject.DiagramElement.AddRange(jObject["diagramElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["documentation"].IsNullOrEmpty())
            {
                diagramObject.Documentation = jObject["documentation"].ToObject<string>();
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                diagramObject.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                diagramObject.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["localStyle"].IsNullOrEmpty())
            {
                diagramObject.LocalStyle.AddRange(jObject["localStyle"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                diagramObject.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                diagramObject.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["resolution"].IsNullOrEmpty())
            {
                diagramObject.Resolution = jObject["resolution"].ToObject<float>();
            }

            if (!jObject["sharedStyle"].IsNullOrEmpty())
            {
                diagramObject.SharedStyle = jObject["sharedStyle"].ToObject<Guid?>();
            }

            return diagramObject;
        }
    }
}
