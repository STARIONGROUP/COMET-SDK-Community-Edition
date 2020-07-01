// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PossibleFiniteStateListResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="PossibleFiniteStateListResolver"/> is to deserialize a JSON object to a <see cref="PossibleFiniteStateList"/>
    /// </summary>
    public static class PossibleFiniteStateListResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="PossibleFiniteStateList"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="PossibleFiniteStateList"/> to instantiate</returns>
        public static CDP4Common.DTO.PossibleFiniteStateList FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var possibleFiniteStateList = new CDP4Common.DTO.PossibleFiniteStateList(iid, revisionNumber);

            if (!jObject["alias"].IsNullOrEmpty())
            {
                possibleFiniteStateList.Alias.AddRange(jObject["alias"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["category"].IsNullOrEmpty())
            {
                possibleFiniteStateList.Category.AddRange(jObject["category"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultState"].IsNullOrEmpty())
            {
                possibleFiniteStateList.DefaultState = jObject["defaultState"].ToObject<Guid?>();
            }

            if (!jObject["definition"].IsNullOrEmpty())
            {
                possibleFiniteStateList.Definition.AddRange(jObject["definition"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                possibleFiniteStateList.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                possibleFiniteStateList.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["hyperLink"].IsNullOrEmpty())
            {
                possibleFiniteStateList.HyperLink.AddRange(jObject["hyperLink"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                possibleFiniteStateList.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                possibleFiniteStateList.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["owner"].IsNullOrEmpty())
            {
                possibleFiniteStateList.Owner = jObject["owner"].ToObject<Guid>();
            }

            if (!jObject["possibleState"].IsNullOrEmpty())
            {
                possibleFiniteStateList.PossibleState.AddRange(jObject["possibleState"].ToOrderedItemCollection());
            }

            if (!jObject["shortName"].IsNullOrEmpty())
            {
                possibleFiniteStateList.ShortName = jObject["shortName"].ToObject<string>();
            }

            return possibleFiniteStateList;
        }
    }
}
