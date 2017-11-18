// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WspCopyOperationHandler.cs" company="RHEA System S.A.">
//   Copyright (c) 2015 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4WspDal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.Operations;
    using CDP4Dal;
    using CDP4Dal.Permission;
    using Poco = CDP4Common.CommonData.Thing;

    /// <summary>
    /// The class that modify a copy <see cref="Operation"/> into multiple create <see cref="Operation"/>s
    /// </summary>
    internal class WspCopyOperationHandler
    {
        /// <summary>
        /// The <see cref="Enumerable"/>'s cast method
        /// </summary>
        private static readonly MethodInfo CastMethod = typeof(Enumerable).GetMethod("Cast");

        /// <summary>
        /// The <see cref="ISession"/> associated
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// A <see cref="Dictionary{Poco, Poco}"/> that map the original <see cref="Poco"/> to the copied version
        /// </summary>
        private Dictionary<Poco, Poco> copyThingMap;

        /// <summary>
        /// A list of <see cref="Guid"/> of the copyable <see cref="Thing"/>s
        /// </summary>
        private List<Guid> copyableIds;

        /// <summary>
        /// The list of <see cref="Operation"/> to create
        /// </summary>
        private List<Operation> operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="WspCopyOperationHandler"/> class
        /// </summary>
        /// <param name="session">The <see cref="ISession"/></param>
        public WspCopyOperationHandler(ISession session)
        {
            this.session = session;
        }

        /// <summary>
        /// Gets the <see cref="IReadOnlyDictionary{Poco, Poco}"/> that map the original <see cref="Poco"/> to the copied version
        /// </summary>
        public IReadOnlyDictionary<Thing, Thing> CopyThingMap
        {
            get { return this.copyThingMap; }
        } 

        /// <summary>
        /// Modify the <see cref="OperationContainer"/> if it contains copy <see cref="Operation"/>
        /// </summary>
        /// <param name="operationContainer">The <see cref="OperationContainer"/> to modify</param>
        public void ModifiedCopyOperation(OperationContainer operationContainer)
        {
            var operationsToAdd = new List<Operation>();

            var copyOperationCount = operationContainer.Operations.Count(x => x.OperationKind.IsCopyOperation());
            if (copyOperationCount > 1)
            {
                // TODO: support this if needed
                throw new NotSupportedException("Only one copy operation per transaction is supported.");
            }

            var copyOperation = operationContainer.Operations.SingleOrDefault(x => x.OperationKind.IsCopyOperation());
            if (copyOperation == null)
            {
                return;
            }

            this.ComputeOperations(copyOperation);
            operationsToAdd.AddRange(this.operations);

            foreach (var operation in operationsToAdd)
            {
                operationContainer.AddOperation(operation);
            }

            // remove the copy operations
            operationContainer.RemoveOperation(copyOperation);

            // update the update iteration operation
            var iterationOperation = operationContainer.Operations.Single(x => x.OperationKind == OperationKind.Update);
            var updatedIteration = iterationOperation.ModifiedThing.QuerySourceThing();
            var originalIteration = iterationOperation.OriginalThing.QuerySourceThing();

            operationContainer.RemoveOperation(iterationOperation);
            operationContainer.AddOperation(new Operation(originalIteration.ToDto(), updatedIteration.ToDto(), OperationKind.Update));
        }

        /// <summary>
        /// Compute a set of <see cref="IEnumerable{Operation}"/> from a copy <see cref="Operation"/>
        /// </summary>
        /// <param name="copyOperation">The copy <see cref="Operation"/></param>
        private void ComputeOperations(Operation copyOperation)
        {
            this.copyThingMap = new Dictionary<Poco, Poco>();
            this.copyableIds = new List<Guid>();
            this.operations = new List<Operation>();

            var copyDto = copyOperation.ModifiedThing;
            var copyPoco = copyDto.QuerySourceThing();

            var originalDto = copyOperation.OriginalThing;
            var originalPoco = originalDto.QuerySourceThing();
            
            if (copyPoco.TopContainer.ClassKind != ClassKind.EngineeringModel)
            {
                throw new InvalidOperationException("The copy operation on WSP is only implemented for things contained by EngineeringModel.");
            }

            this.copyThingMap.Add(originalPoco, copyPoco);

            // compute the things to copy
            var copyPermissionHelper = new CopyPermissionHelper(this.session, copyOperation.OperationKind.IsCopyChangeOwnerOperation());
            var copyPermissionResult = copyPermissionHelper.ComputeCopyPermission(originalPoco, copyPoco.Container);

            // Add all contained objects
            this.copyableIds.AddRange(copyPermissionResult.CopyableThings.Select(c => c.Iid).ToList());
            if (this.copyableIds.Contains(originalPoco.Iid))
            {
                var updatedIteration = copyPoco.GetContainerOfType<Iteration>();

                this.CreatePocoCopy(copyPoco, updatedIteration);

                // modify the references to point to the copy thing
                this.ModifyReferences();
                if (copyOperation.OperationKind.IsCopyChangeOwnerOperation())
                {
                    this.ChangeOwner(updatedIteration);
                }

                this.CreateOperations();
            }
        }

        /// <summary>
        /// Creates the deep copy of the <see cref="ElementUsage"/> to write
        /// </summary>
        /// <param name="usage">The <see cref="ElementUsage"/></param>
        /// <param name="targetIteration">The clone of the target <see cref="Iteration"/></param>
        /// <remarks>
        /// In this case, the usage's <see cref="ElementDefinition"/> is created first
        /// </remarks>
        private void CreatePocoCopy(ElementUsage usage, Iteration targetIteration)
        {
            if (this.copyThingMap.ContainsKey(usage.ElementDefinition) == false)
            {
                // create a copy of its element definition
                var usageDefinitionClone = usage.ElementDefinition.Clone(false);
                usageDefinitionClone.Iid = Guid.NewGuid();

                this.CreatePocoCopy(usageDefinitionClone, targetIteration);

                // add to the target iteration clone
                targetIteration.Element.Add(usageDefinitionClone);
                this.copyThingMap.Add(usage.ElementDefinition, usageDefinitionClone);
            }

            this.CreatePocoCopy((Poco)usage, targetIteration);
        }

        /// <summary>
        /// Creates the deep copy of the <see cref="Poco"/> to write
        /// </summary>
        /// <param name="poco">The <see cref="Poco"/> to copy</param>
        /// <param name="targetIteration">The clone of the target <see cref="Iteration"/></param>
        private void CreatePocoCopy(Poco poco, Iteration targetIteration)
        {
            foreach (var containerList in poco.ContainerLists)
            {
                var updatedContainerList = new List<Poco>();
                foreach (Poco containedPoco in containerList)
                {
                    if (!this.copyableIds.Contains(containedPoco.Iid))
                    {
                        continue;
                    }

                    var clone = containedPoco.Clone(false);
                    clone.Iid = Guid.NewGuid();

                    switch (clone.ClassKind)
                    {
                        case ClassKind.ElementUsage:
                            this.CreatePocoCopy((ElementUsage)clone, targetIteration);
                            break;
                        default:
                            this.CreatePocoCopy(clone, targetIteration);
                            break;
                    }

                    this.copyThingMap.Add(containedPoco, clone);
                    updatedContainerList.Add(clone);
                }

                // clear the list
                var containerListType = containerList.GetType();
                var genericType = containerListType.GetGenericArguments().Single();

                var clearMethod = containerListType.GetMethod("Clear");
                clearMethod.Invoke(containerList, null);

                if (!updatedContainerList.Any())
                {
                    continue;
                }

                // Add items
                var castContainerList = CastMethod.MakeGenericMethod(genericType)
                    .Invoke(null, new object[] { updatedContainerList });

                var addRangeMethod = containerListType.GetMethod("AddRange");
                addRangeMethod.Invoke(containerList, new[] { castContainerList });
            }
        }

        /// <summary>
        /// Creates a <see cref="IEnumerable{Operation}"/> associated to a <see cref="CDP4Common.CommonData.Thing"/> to copy
        /// </summary>
        private void CreateOperations()
        {
            foreach (var copy in this.copyThingMap.Values)
            {
                var operation = new Operation(null, copy.ToDto(), OperationKind.Create);
                this.operations.Add(operation);
            }
        }

        #region Modify References
        /// <summary>
        /// Modify the references for a <see cref="Poco"/> and all its contained elements
        /// </summary>
        private void ModifyReferences()
        {
            foreach (var copy in this.copyThingMap.Values)
            {
                switch (copy.ClassKind)
                {
                    case ClassKind.ElementUsage:
                        this.ModifyReferences((ElementUsage)copy);
                        break;
                    case ClassKind.Parameter:
                        this.ModifyReferences((Parameter)copy);
                        break;
                    case ClassKind.ParameterGroup:
                        this.ModifyReferences((ParameterGroup)copy);
                        break;
                    case ClassKind.ParameterOverride:
                        this.ModifyReferences((ParameterOverride)copy);
                        break;
                }
            }
        }

        /// <summary>
        /// Modify the references for the copied <see cref="ElementUsage"/>
        /// </summary>
        /// <param name="usage">The <see cref="ElementUsage"/></param>
        private void ModifyReferences(ElementUsage usage)
        {
            // There shall be a definition in the things to copy
            var copy = (ElementDefinition)this.copyThingMap[usage.ElementDefinition];

            usage.ElementDefinition = copy;
            usage.ExcludeOption.Clear();
        }

        /// <summary>
        /// Modify the references for the copied <see cref="Parameter"/>
        /// </summary>
        /// <param name="parameter">The <see cref="Parameter"/></param>
        private void ModifyReferences(Parameter parameter)
        {
            parameter.StateDependence = null;
            if (parameter.Group == null)
            {
                return;
            }

            // if the group cannot be copied, set to null
            Poco groupCopy;
            this.copyThingMap.TryGetValue(parameter.Group, out groupCopy);
            parameter.Group = this.copyThingMap.TryGetValue(parameter.Group, out groupCopy)
                ? (ParameterGroup)groupCopy
                : null;
        }

        /// <summary>
        /// Modify the references for the copied <see cref="ParameterGroup"/>
        /// </summary>
        /// <param name="group">The <see cref="ParameterGroup"/></param>
        private void ModifyReferences(ParameterGroup group)
        {
            if (group.ContainingGroup == null)
            {
                return;
            }

            // if the group cannot be copied, set to null
            Poco groupCopy;
            this.copyThingMap.TryGetValue(group.ContainingGroup, out groupCopy);
            group.ContainingGroup = this.copyThingMap.TryGetValue(group.ContainingGroup, out groupCopy)
                ? (ParameterGroup)groupCopy
                : null;
        }

        /// <summary>
        /// Modify the references for the copied <see cref="ParameterOverride"/>
        /// </summary>
        /// <param name="parameterOverride">The <see cref="ParameterOverride"/></param>
        private void ModifyReferences(ParameterOverride parameterOverride)
        {
            // if an override is copied, the parameter it overrides shall be in the list of copied elements
            var copy = (Parameter)this.copyThingMap[parameterOverride.Parameter];
            parameterOverride.Parameter = copy;
        }
        #endregion

        /// <summary>
        /// Changes the <see cref="CDP4Common.DTO.DomainOfExpertise"/> for all <see cref="IOwnedThing"/>s in the current copy operation
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> into which the <see cref="Thing"/>s are copied.</param>
        private void ChangeOwner(Iteration iteration)
        {
            var activeDomain = this.session.OpenIterations.Single(x => x.Key.Iid == iteration.Iid).Value.Item1;
            if (activeDomain == null)
            {
                throw new InvalidOperationException("The active domain is null. The copy operation cannot be performed.");
            }

            var ownedThings = this.copyThingMap.Values.OfType<IOwnedThing>().ToList();
            foreach (var ownedThing in ownedThings)
            {
                // the owner of a subscription shall not be set to the active one
                if (ownedThing is ParameterSubscription)
                {
                    continue;
                }

                ownedThing.Owner = activeDomain;
            }
        }
    }
}