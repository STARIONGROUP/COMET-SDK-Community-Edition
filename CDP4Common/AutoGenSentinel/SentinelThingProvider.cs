// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SentinelThingProvider.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
            sentinelProvider.Add("DiagramElementThing", new ArchitectureElement(Guid.Empty, null, null));
            sentinelProvider.Add("DomainOfExpertise", new DomainOfExpertise(Guid.Empty, null, null));
            sentinelProvider.Add("ElementDefinition", new ElementDefinition(Guid.Empty, null, null));
            sentinelProvider.Add("EngineeringModelSetup", new EngineeringModelSetup(Guid.Empty, null, null));
            sentinelProvider.Add("FileType", new FileType(Guid.Empty, null, null));
            sentinelProvider.Add("IterationSetup", new IterationSetup(Guid.Empty, null, null));
            sentinelProvider.Add("MeasurementScale", new CyclicRatioScale(Guid.Empty, null, null));
            sentinelProvider.Add("MeasurementUnit", new DerivedUnit(Guid.Empty, null, null));
            sentinelProvider.Add("Organization", new Organization(Guid.Empty, null, null));
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
