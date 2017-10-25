// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramCanvasResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramCanvasResolver"/> is to deserialize a JSON object to a <see cref="DiagramCanvas"/>
    /// </summary>
    public static class DiagramCanvasResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DiagramCanvas"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DiagramCanvas"/> to instantiate</returns>
        public static CDP4Common.DTO.DiagramCanvas FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var diagramCanvas = new CDP4Common.DTO.DiagramCanvas(iid, revisionNumber);

            if (!jObject["bounds"].IsNullOrEmpty())
            {
                diagramCanvas.Bounds.AddRange(jObject["bounds"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["createdOn"].IsNullOrEmpty())
            {
                diagramCanvas.CreatedOn = jObject["createdOn"].ToObject<DateTime>();
            }

            if (!jObject["diagramElement"].IsNullOrEmpty())
            {
                diagramCanvas.DiagramElement.AddRange(jObject["diagramElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                diagramCanvas.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                diagramCanvas.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                diagramCanvas.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                diagramCanvas.Name = jObject["name"].ToObject<string>();
            }

            return diagramCanvas;
        }
    }
}
