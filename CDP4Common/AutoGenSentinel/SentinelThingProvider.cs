// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SentinelThingProvider.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated provider Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// A sentinel thing provider class
    /// </summary>
    public static class SentinelThingProvider
    {
        /// <summary>
        /// The dictionary that contains sentinel instances for all types of Thing
        /// </summary>
        private static readonly Dictionary<string, Thing> sentinelProvider = new Dictionary<string, Thing>();

        /// <summary>
        /// Initialize the static <see cref="SentinelThingProvider"/>
        /// </summary>
        static SentinelThingProvider()
        {
            sentinelProvider.Add("BooleanExpression", new AndExpression(Guid.Empty, null, null));
            sentinelProvider.Add("Category", new Category(Guid.Empty, null, null));
            sentinelProvider.Add("ChangeProposal", new ChangeProposal(Guid.Empty, null, null));
            sentinelProvider.Add("ChangeRequest", new ChangeRequest(Guid.Empty, null, null));
            sentinelProvider.Add("DiagramElementThing", new DiagramEdge(Guid.Empty, null, null));
            sentinelProvider.Add("DomainOfExpertise", new DomainOfExpertise(Guid.Empty, null, null));
            sentinelProvider.Add("ElementDefinition", new ElementDefinition(Guid.Empty, null, null));
            sentinelProvider.Add("EngineeringModelSetup", new EngineeringModelSetup(Guid.Empty, null, null));
            sentinelProvider.Add("FileType", new FileType(Guid.Empty, null, null));
            sentinelProvider.Add("IterationSetup", new IterationSetup(Guid.Empty, null, null));
            sentinelProvider.Add("MeasurementScale", new CyclicRatioScale(Guid.Empty, null, null));
            sentinelProvider.Add("MeasurementUnit", new DerivedUnit(Guid.Empty, null, null));
            sentinelProvider.Add("Parameter", new Parameter(Guid.Empty, null, null));
            sentinelProvider.Add("ParameterBase", new Parameter(Guid.Empty, null, null));
            sentinelProvider.Add("ParameterType", new ArrayParameterType(Guid.Empty, null, null));
            sentinelProvider.Add("ParameterValueSet", new ParameterValueSet(Guid.Empty, null, null));
            sentinelProvider.Add("ParameterValueSetBase", new ParameterOverrideValueSet(Guid.Empty, null, null));
            sentinelProvider.Add("Participant", new Participant(Guid.Empty, null, null));
            sentinelProvider.Add("ParticipantRole", new ParticipantRole(Guid.Empty, null, null));
            sentinelProvider.Add("Person", new Person(Guid.Empty, null, null));
            sentinelProvider.Add("QuantityKind", new DerivedQuantityKind(Guid.Empty, null, null));
            sentinelProvider.Add("ReferenceSource", new ReferenceSource(Guid.Empty, null, null));
            sentinelProvider.Add("Rule", new BinaryRelationshipRule(Guid.Empty, null, null));
            sentinelProvider.Add("ScaleValueDefinition", new ScaleValueDefinition(Guid.Empty, null, null));
            sentinelProvider.Add("SiteDirectoryThingReference", new SiteDirectoryThingReference(Guid.Empty, null, null));
            sentinelProvider.Add("Thing", new ActionItem(Guid.Empty, null, null));
            sentinelProvider.Add("UnitPrefix", new UnitPrefix(Guid.Empty, null, null));

            ResolveRequiredDependency();
        }

        /// <summary>
        /// Gets the sentinel instance of <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">A type of <see cref="Thing"/></typeparam>
        /// <returns>The sentinel instance</returns>
        public static T GetSentinel<T>() where T : Thing
        {
            Thing sentinel = null;
            if (!sentinelProvider.TryGetValue(typeof(T).Name, out sentinel))
            {
                throw new InvalidOperationException(string.Format("The sentinel instance of {0} was not found", typeof(T).Name));
            }

            return (T)sentinel;
        }

        /// <summary>
        /// Resolve the required dependency of the sentinels
        /// </summary>
        private static void ResolveRequiredDependency()
        {
            foreach (var thing in sentinelProvider.Values)
            {
                thing.ValidatePoco();
            }
        }
    }
}
