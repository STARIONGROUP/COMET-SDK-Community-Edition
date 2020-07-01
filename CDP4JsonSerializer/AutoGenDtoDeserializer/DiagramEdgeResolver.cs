// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramEdgeResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="DiagramEdgeResolver"/> is to deserialize a JSON object to a <see cref="DiagramEdge"/>
    /// </summary>
    public static class DiagramEdgeResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="DiagramEdge"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="DiagramEdge"/> to instantiate</returns>
        public static CDP4Common.DTO.DiagramEdge FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var diagramEdge = new CDP4Common.DTO.DiagramEdge(iid, revisionNumber);

            if (!jObject["bounds"].IsNullOrEmpty())
            {
                diagramEdge.Bounds.AddRange(jObject["bounds"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["depictedThing"].IsNullOrEmpty())
            {
                diagramEdge.DepictedThing = jObject["depictedThing"].ToObject<Guid?>();
            }

            if (!jObject["diagramElement"].IsNullOrEmpty())
            {
                diagramEdge.DiagramElement.AddRange(jObject["diagramElement"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                diagramEdge.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                diagramEdge.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["localStyle"].IsNullOrEmpty())
            {
                diagramEdge.LocalStyle.AddRange(jObject["localStyle"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                diagramEdge.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                diagramEdge.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["point"].IsNullOrEmpty())
            {
                diagramEdge.Point.AddRange(jObject["point"].ToOrderedItemCollection());
            }

            if (!jObject["sharedStyle"].IsNullOrEmpty())
            {
                diagramEdge.SharedStyle = jObject["sharedStyle"].ToObject<Guid?>();
            }

            if (!jObject["source"].IsNullOrEmpty())
            {
                diagramEdge.Source = jObject["source"].ToObject<Guid>();
            }

            if (!jObject["target"].IsNullOrEmpty())
            {
                diagramEdge.Target = jObject["target"].ToObject<Guid>();
            }

            return diagramEdge;
        }
    }
}
