// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueSetOperationCreator.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;

    using CDP4Dal;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    using Dto = CDP4Common.DTO;

    /// <summary>
    /// The class that compensate operations non performed directly by the WSP
    /// </summary>
    internal class ValueSetOperationCreator
    {
        /// <summary>
        /// The <see cref="ISession"/> associated
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueSetOperationCreator"/> class
        /// </summary>
        /// <param name="session">The <see cref="ISession"/>
        /// The 
        /// </param>
        public ValueSetOperationCreator(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Computes a <see cref="OperationContainer"/> that contains update operations on value-sets
        /// </summary>
        /// <param name="context">
        /// The route of the <see cref="CDP4Common.DTO.SiteDirectory"/> or <see cref="Iteration"/> for which the current <see cref="OperationContainer"/> is valid.
        /// </param>
        /// <param name="dtos">The returned <see cref="Dto.Thing"/>s</param>
        /// <param name="copyThingMap">The copy map containing the original <see cref="Thing"/> associated to their copy</param>
        /// <returns>The <see cref="OperationContainer"/></returns>
        public OperationContainer CreateValueSetsUpdateOperations(string context, IEnumerable<Dto.Thing> dtos, IReadOnlyDictionary<Thing, Thing> copyThingMap)
        {
            var dtolist = dtos.ToList();

            var topContainer = dtolist.SingleOrDefault(x => x is Dto.TopContainer);

            if (topContainer == null)
            {
                throw new InvalidOperationException("No Top container were found in the returned list of dtos.");
            }

            // Gets the parameter base which value set shall be updated
            var copyParameterBases = dtolist.OfType<Dto.ParameterBase>().ToList();
            var copyParameterBasesIds = copyParameterBases.Select(p => p.Iid).ToList();

            var valuesets = dtolist.Where(dto => dto.ClassKind == ClassKind.ParameterValueSet ||
                                                 dto.ClassKind == ClassKind.ParameterSubscriptionValueSet ||
                                                 dto.ClassKind == ClassKind.ParameterOverrideValueSet).ToList();

            this.ComputeRoutes(valuesets, dtolist);
            var valueSetsClones = valuesets.Select(dto => dto.DeepClone<Dto.Thing>()).ToList();

            // The original of the copy are normally in the map
            var originalParameterBases = copyThingMap.Where(x => copyParameterBasesIds.Contains(x.Value.Iid)).ToList();

            // set the values
            foreach (var copyPair in originalParameterBases)
            {
                var copyId = copyPair.Value.Iid;
                var originalParameter = (ParameterBase)copyPair.Key;
                var copyDto = copyParameterBases.Single(x => x.Iid == copyId);

                // value sets to update
                var copyValueSets = valueSetsClones.Where(x => copyDto.ValueSets.Contains(x.Iid)).ToList();
                var defaultValueSet = this.GetDefaultValueSet(originalParameter);

                if (defaultValueSet == null)
                {
                    continue;
                }

                this.SetValueSetValues(copyValueSets, defaultValueSet);
            }

            var operationContainer = new OperationContainer(context, topContainer.RevisionNumber);

            foreach (var valueSetsClone in valueSetsClones)
            {
                var valuesetToUpdate = valuesets.Single(x => x.Iid == valueSetsClone.Iid);
                var operation = new Operation(valuesetToUpdate, valueSetsClone, OperationKind.Update);
                operationContainer.AddOperation(operation);
            }

            return operationContainer;
        }

        /// <summary>
        /// Computes the routes of a set of <see cref="Dto.Thing"/>s contained in a bigger list
        /// </summary>
        /// <param name="dtos">The set of <see cref="Dto.Thing"/> to compute</param>
        /// <param name="dtolist">The list returned by the data-source</param>
        private void ComputeRoutes(IEnumerable<Dto.Thing> dtos, List<Dto.Thing> dtolist)
        {
            foreach (var valueset in dtos)
            {
                valueset.ResolveRoute(dtolist, this.session);
            }
        }

        /// <summary>
        /// Gets the <see cref="IValueSet"/> to copy
        /// </summary>
        /// <param name="parameterBase">The <see cref="ParameterBase"/> which <see cref="IValueSet"/> shall be copied</param>
        /// <returns>The default <see cref="IValueSet"/> to copy or null</returns>
        private IValueSet GetDefaultValueSet(ParameterBase parameterBase)
        {
            // single value set in original
            if (parameterBase.ValueSets.Count() == 1)
            {
                return parameterBase.ValueSets.Single();
            }

            if (parameterBase.IsOptionDependent && parameterBase.StateDependence != null)
            {
                return parameterBase.ValueSets.FirstOrDefault(x => x.ActualState.IsDefault && x.ActualOption.IsDefault);
            }

            if (parameterBase.StateDependence != null)
            {
                return parameterBase.ValueSets.FirstOrDefault(x => x.ActualState.IsDefault);
            }

            return parameterBase.ValueSets.FirstOrDefault(x => x.ActualOption.IsDefault);
        }

        /// <summary>
        /// Set the values of the copied <see cref="Dto.Thing"/>s representing value-sets
        /// </summary>
        /// <param name="things">The copied <see cref="Dto.Thing"/> representing a value-set</param>
        /// <param name="originalValueSet">The original <see cref="IValueSet"/> to copy</param>
        private void SetValueSetValues(IEnumerable<Dto.Thing> things, IValueSet originalValueSet)
        {
            foreach (var thing in things)
            {
                switch (thing.ClassKind)
                {
                    case ClassKind.ParameterValueSet:
                    case ClassKind.ParameterOverrideValueSet:
                        this.SetValueSetValues((Dto.ParameterValueSetBase)thing, (ParameterValueSetBase)originalValueSet);
                        break;
                    case ClassKind.ParameterSubscriptionValueSet:
                        this.SetValueSetValues((Dto.ParameterSubscriptionValueSet)thing, (ParameterSubscriptionValueSet)originalValueSet);
                        break;
                }
            }
        }

        /// <summary>
        /// Set the values of the <see cref="Dto.ParameterValueSetBase"/> with the values of a original <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="valueSet">The <see cref="Dto.ParameterValueSetBase"/></param>
        /// <param name="originalValueSet">The <see cref="ParameterValueSetBase"/></param>
        private void SetValueSetValues(Dto.ParameterValueSetBase valueSet, ParameterValueSetBase originalValueSet)
        {
            valueSet.Manual = originalValueSet.Manual;
            valueSet.Reference = originalValueSet.Reference;
            valueSet.ValueSwitch = originalValueSet.ValueSwitch;
            valueSet.Formula = originalValueSet.Formula;
            valueSet.Computed = originalValueSet.Computed;
        }

        /// <summary>
        /// Set the values of the <see cref="Dto.ParameterSubscriptionValueSet"/> with the values of a original <see cref="ParameterSubscriptionValueSet"/>
        /// </summary>
        /// <param name="valueSet">The <see cref="Dto.ParameterSubscriptionValueSet"/></param>
        /// <param name="originalValueSet">The <see cref="ParameterSubscriptionValueSet"/></param>
        private void SetValueSetValues(Dto.ParameterSubscriptionValueSet valueSet, ParameterSubscriptionValueSet originalValueSet)
        {
            valueSet.Manual = originalValueSet.Manual;
            valueSet.ValueSwitch = originalValueSet.ValueSwitch;
        }
    }
}
