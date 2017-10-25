// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationResolver.cs" company="RHEA System S.A.">
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
    /// The purpose of the <see cref="IterationResolver"/> is to deserialize a JSON object to a <see cref="Iteration"/>
    /// </summary>
    public static class IterationResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="Iteration"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="Iteration"/> to instantiate</returns>
        public static CDP4Common.DTO.Iteration FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var iteration = new CDP4Common.DTO.Iteration(iid, revisionNumber);

            if (!jObject["actualFiniteStateList"].IsNullOrEmpty())
            {
                iteration.ActualFiniteStateList.AddRange(jObject["actualFiniteStateList"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["defaultOption"].IsNullOrEmpty())
            {
                iteration.DefaultOption = jObject["defaultOption"].ToObject<Guid?>();
            }

            if (!jObject["diagramCanvas"].IsNullOrEmpty())
            {
                iteration.DiagramCanvas.AddRange(jObject["diagramCanvas"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["domainFileStore"].IsNullOrEmpty())
            {
                iteration.DomainFileStore.AddRange(jObject["domainFileStore"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["element"].IsNullOrEmpty())
            {
                iteration.Element.AddRange(jObject["element"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                iteration.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                iteration.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["externalIdentifierMap"].IsNullOrEmpty())
            {
                iteration.ExternalIdentifierMap.AddRange(jObject["externalIdentifierMap"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["goal"].IsNullOrEmpty())
            {
                iteration.Goal.AddRange(jObject["goal"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["iterationSetup"].IsNullOrEmpty())
            {
                iteration.IterationSetup = jObject["iterationSetup"].ToObject<Guid>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                iteration.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["option"].IsNullOrEmpty())
            {
                iteration.Option.AddRange(jObject["option"].ToOrderedItemCollection());
            }

            if (!jObject["possibleFiniteStateList"].IsNullOrEmpty())
            {
                iteration.PossibleFiniteStateList.AddRange(jObject["possibleFiniteStateList"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["publication"].IsNullOrEmpty())
            {
                iteration.Publication.AddRange(jObject["publication"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["relationship"].IsNullOrEmpty())
            {
                iteration.Relationship.AddRange(jObject["relationship"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["requirementsSpecification"].IsNullOrEmpty())
            {
                iteration.RequirementsSpecification.AddRange(jObject["requirementsSpecification"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["ruleVerificationList"].IsNullOrEmpty())
            {
                iteration.RuleVerificationList.AddRange(jObject["ruleVerificationList"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["sharedDiagramStyle"].IsNullOrEmpty())
            {
                iteration.SharedDiagramStyle.AddRange(jObject["sharedDiagramStyle"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["sourceIterationIid"].IsNullOrEmpty())
            {
                iteration.SourceIterationIid = jObject["sourceIterationIid"].ToObject<Guid?>();
            }

            if (!jObject["stakeholder"].IsNullOrEmpty())
            {
                iteration.Stakeholder.AddRange(jObject["stakeholder"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["stakeholderValue"].IsNullOrEmpty())
            {
                iteration.StakeholderValue.AddRange(jObject["stakeholderValue"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["stakeholderValueMap"].IsNullOrEmpty())
            {
                iteration.StakeholderValueMap.AddRange(jObject["stakeholderValueMap"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["topElement"].IsNullOrEmpty())
            {
                iteration.TopElement = jObject["topElement"].ToObject<Guid?>();
            }

            if (!jObject["valueGroup"].IsNullOrEmpty())
            {
                iteration.ValueGroup.AddRange(jObject["valueGroup"].ToObject<IEnumerable<Guid>>());
            }

            return iteration;
        }
    }
}
