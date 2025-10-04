// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationModifier.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    using CDP4Dal;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    using ActualFiniteState = CDP4Common.DTO.ActualFiniteState;
    using PossibleFiniteStateList = CDP4Common.DTO.PossibleFiniteStateList;

    /// <summary>
    /// The purpose of the <see cref="OperationModifier"/> is to perform operations that
    /// are not performed directly by the server 
    /// </summary>
    internal class OperationModifier
    {
        /// <summary>
        /// The <see cref="ISession"/> associated
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationModifier"/> class
        /// </summary>
        /// <param name="session">The <see cref="ISession"/></param>
        public OperationModifier(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Modify the <see cref="OperationContainer"/> to compensate for operations 
        /// that should be performed by the data-source but is not by the WSP.
        /// </summary>
        /// <param name="operationContainer">The <see cref="OperationContainer"/> to modify</param>
        public void ModifyOperationContainer(OperationContainer operationContainer)
        {
            var operationsToAdd = new List<Operation>();

            foreach (var operation in operationContainer.Operations)
            {
                if (operation.OperationKind == OperationKind.Update)
                {
                    var possibleStateList = operation.ModifiedThing as PossibleFiniteStateList;

                    if (possibleStateList != null)
                    {
                        operationsToAdd.AddRange(this.ModifyActualStateKindOnDefaultPossibleStateUpdate(possibleStateList));
                    }
                }
            }

            foreach (var operation in operationsToAdd)
            {
                operationContainer.AddOperation(operation);
            }
        }

        /// <summary>
        /// Modify the <see cref="CDP4Common.DTO.ActualFiniteState.Kind"/> state of the potential new default actual state to "Mandatory"
        /// </summary>
        /// <param name="possibleFiniteStateList">The updated <see cref="PossibleFiniteStateList"/></param>
        /// <returns>A <see cref="IEnumerable{T}"/> of new <see cref="Operation"/>s</returns>
        private IEnumerable<Operation> ModifyActualStateKindOnDefaultPossibleStateUpdate(PossibleFiniteStateList possibleFiniteStateList)
        {
            var operations = new List<Operation>();
            var defaultStateId = possibleFiniteStateList.DefaultState;

            if (!defaultStateId.HasValue)
            {
                return operations;
            }

            // gets the actualList that uses the updated possible list
            var actualLists = this.session.Assembler.Cache.Select(x => x.Value)
                .Select(x => x.Value)
                .OfType<ActualFiniteStateList>()
                .Where(x => x.PossibleFiniteStateList.Select(pl => pl.Iid).Contains(possibleFiniteStateList.Iid))
                .ToList();

            foreach (var actualFiniteStateList in actualLists)
            {
                var possibleLists = actualFiniteStateList.PossibleFiniteStateList.Where(x => x.Iid != possibleFiniteStateList.Iid).ToList();

                if (possibleLists.Any(x => x.DefaultState == null))
                {
                    // one of the possible list has no default state
                    continue;
                }

                var defaultPossibleStatesIds = possibleLists.Select(x => x.DefaultState.Iid).ToList();
                defaultPossibleStatesIds.Add(defaultStateId.Value);

                // get the "default" actual state
                var defaultActualState =
                    actualFiniteStateList.ActualState.SingleOrDefault(
                        x =>
                            x.PossibleState.Select(ps => ps.Iid).Intersect(defaultPossibleStatesIds).Count() ==
                            defaultPossibleStatesIds.Count);

                if (defaultActualState == null || defaultActualState.Kind == ActualFiniteStateKind.MANDATORY)
                {
                    continue;
                }

                // the new default is forbidden, send update with mandatory
                var actualStateDto = (ActualFiniteState)defaultActualState.ToDto();
                actualStateDto.Kind = ActualFiniteStateKind.MANDATORY;
                var newOperation = new Operation(defaultActualState.ToDto(), actualStateDto, OperationKind.Update);
                operations.Add(newOperation);
            }

            return operations;
        }
    }
}
