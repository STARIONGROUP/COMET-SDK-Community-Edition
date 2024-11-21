// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.Dto;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    /// <summary>
    /// The CDP POST operation
    /// </summary>
    /// <seealso cref="PostOperation" />
    internal class CdpPostOperation : PostOperation
    {
        /// <summary>
        /// The property name that stores the unique identifier of a <see cref="CDP4Common.DTO.Thing"/>
        /// </summary>
        private const string IID_KEY = "Iid";

        /// <summary>
        /// The property name that stores the classkind of a <see cref="CDP4Common.DTO.Thing"/>
        /// </summary>
        private const string CLASSKIND_KEY = "ClassKind";

        /// <summary>
        /// The <see cref="IMetaDataProvider"/> used in the application
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// The <see cref="ISession"/>
        /// </summary>
        private readonly ISession session;

        /// <summary>
        /// Initializes a new instance of the <see cref="CdpPostOperation"/> class.
        /// </summary>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/></param>
        /// <param name="session">The <see cref="ISession"/></param>
        internal CdpPostOperation(IMetaDataProvider metaDataProvider, ISession session)
        {
            this.metaDataProvider = metaDataProvider;
            this.session = session;
        }

        /// <summary>
        /// Populate the current <see cref="PostOperation"/> with the content based on the 
        /// provided <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        /// The <see cref="Operation"/> that contains all the <see cref="CDP4Common.DTO.Thing"/>s that need to be
        /// updated to the data-source
        /// </param>
        public override void ConstructFromOperation(Operation operation)
        {
            if (operation.ModifiedThing == null)
            {
                throw new ArgumentNullException(nameof(operation), "The operation may not be null");
            }

            switch (operation.OperationKind)
            {
                case OperationKind.Create:
                    this.Create.Add(operation.ModifiedThing);
                    break;
                case OperationKind.Delete:
                    this.Delete.Add(ClasslessDtoFactory.FromThing(this.metaDataProvider, operation.ModifiedThing));
                    break;
                case OperationKind.Update:
                    this.ResolveUpdate(operation);
                    break;
                case OperationKind.Move:
                    throw new NotImplementedException();
                default:
                    this.ResolveCopy(operation);
                    break;
            }
        }

        /// <summary>
        /// Resolves the Update container of the <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        private void ResolveUpdate(Operation operation)
        {
            var original = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, operation.OriginalThing);
            var modifiedFull = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, operation.ModifiedThing);
            var modified = ClasslessDtoFactory.FullFromThing(this.metaDataProvider, operation.ModifiedThing);

            var listsToDelete = new Dictionary<string, IEnumerable<object>>();
            var listsToAdd = new Dictionary<string, IEnumerable<object>>();

            foreach (var key in original.Keys)
            {
                var originalIenumerable = original[key] as IEnumerable;

                if (originalIenumerable != null && originalIenumerable.GetType().IsGenericType)
                {
                    var modifiedIenumerable = (IEnumerable)modifiedFull[key];

                    // value array case
                    if (originalIenumerable is ValueArray<string>)
                    {
                        var originalValue = (ValueArray<string>)originalIenumerable;
                        var modifiedValue = (ValueArray<string>)modifiedIenumerable;

                        if (originalValue.ToString() == modifiedValue.ToString())
                        {
                            modified.Remove(key);
                        }
                    }
                    else
                    {
                        var possibleAdditions = new List<object>();

                        List<object> originalProperty;
                        List<object> modifiedProperty;

                        var genericTypeArgument = original[key].GetType().GenericTypeArguments[0];

                        if (genericTypeArgument == typeof(Guid) || genericTypeArgument == typeof(ClassKind) || genericTypeArgument == typeof(VcardTelephoneNumberKind))
                        {
                            originalProperty = originalIenumerable.Cast<object>().ToList();
                            modifiedProperty = modifiedIenumerable.Cast<object>().ToList();
                        }
                        else if (genericTypeArgument == typeof(OrderedItem))
                        {
                            originalProperty = originalIenumerable.Cast<object>().ToList();
                            modifiedProperty = modifiedIenumerable.Cast<object>().ToList();

                            var originalPropertyOrdered = ((List<OrderedItem>)original[key]).ToList();
                            var modifiedPropertyOrdered = ((List<OrderedItem>)modifiedFull[key]).ToList();

                            // move property using intersection
                            var sameItems = originalPropertyOrdered.Intersect(modifiedPropertyOrdered);

                            foreach (var sameItem in sameItems)
                            {
                                var orItem = originalPropertyOrdered.Find(o => o.V.Equals(sameItem.V));
                                var modItem = modifiedPropertyOrdered.Find(m => m.V.Equals(sameItem.V));

                                if (orItem.K != modItem.K)
                                {
                                    modItem.MoveItem(orItem.K, modItem.K);
                                    possibleAdditions.Add(modItem);
                                }
                            }
                        }
                        else
                        {
                            // either way remove key in case the generic type is not one of the expected ones
                            modified.Remove(key);
                            continue;
                        }

                        possibleAdditions.AddRange(modifiedProperty.Except(originalProperty).ToList());

                        if (possibleAdditions.Count > 0)
                        {
                            // this part will be added to the update
                            listsToAdd.Add(key, possibleAdditions);
                        }

                        var possibleDeletions = originalProperty.Except(modifiedProperty).ToList();

                        if (possibleDeletions.Count > 0)
                        {
                            // this part will be added to the delete
                            listsToDelete.Add(key, possibleDeletions);
                        }

                        // either way remove key
                        modified.Remove(key);
                    }
                }
                else
                {
                    // whatever outputs here has to be an update
                    // remove the properties that have not changed
                    if (key.Equals(IID_KEY) || key.Equals(CLASSKIND_KEY))
                    {
                        continue;
                    }

                    if (original[key] == null)
                    {
                        if (original[key] == modifiedFull[key])
                        {
                            modified.Remove(key);
                        }
                    }
                    else
                    {
                        if (original[key].Equals(modifiedFull[key]))
                        {
                            modified.Remove(key);
                        }
                    }
                }
            }

            if (listsToDelete.Count > 0)
            {
                var deleteDto = ClasslessDtoFactory.FromThing(this.metaDataProvider, operation.ModifiedThing);

                foreach (var kvp in listsToDelete)
                {
                    deleteDto.Add(kvp.Key, kvp.Value);
                }

                // add a delete container
                // Add to the list of deleted thing, WSP will compute what references were removed for the current Thing
                // example: a category was removed from an ElementDefinition => add a operation in the Delete Operation with the removed category
                this.Delete.Add(deleteDto);
            }

            if (listsToAdd.Count > 0)
            {
                var updateDto = modified;

                foreach (var kvp in listsToAdd)
                {
                    updateDto.Add(kvp.Key, kvp.Value);
                }
            }

            // if more than just Iid and Classkind have changed then add it to update 
            if (modified.Count > 2)
            {
                this.Update.Add(modified);
            }
        }

        /// <summary>
        /// Resolves the copy operations
        /// </summary>
        /// <param name="operation">The <see cref="Operation"/></param>
        private void ResolveCopy(Operation operation)
        {
            if (!operation.OperationKind.IsCopyOperation())
            {
                return;
            }

            var options = new CopyInfoOptions
            {
                CopyKind = CopyKind.Deep,
                KeepOwner = operation.OperationKind == OperationKind.Copy || operation.OperationKind == OperationKind.CopyKeepValues,
                KeepValues = operation.OperationKind == OperationKind.CopyKeepValues || operation.OperationKind == OperationKind.CopyKeepValuesChangeOwner
            };

            var sourcepoco = operation.OriginalThing.QuerySourceThing();
            var sourceIteration = sourcepoco.GetContainerOfType<Iteration>();

            var source = new CopySource
            {
                Thing = new CopyReference { Iid = operation.OriginalThing.Iid, ClassKind = operation.OriginalThing.ClassKind },
                TopContainer = new CopyReference { Iid = sourcepoco.TopContainer.Iid, ClassKind = sourcepoco.TopContainer.ClassKind },
                IterationId = sourceIteration?.Iid
            };

            var poco = operation.ModifiedThing.QuerySourceThing();

            if (poco.Container == null)
            {
                throw new InvalidOperationException("The container cannot be null.");
            }

            var targetIteration = poco.GetContainerOfType<Iteration>();

            var target = new CopyTarget
            {
                Container = new CopyReference { Iid = poco.Container.Iid, ClassKind = poco.Container.ClassKind },
                TopContainer = new CopyReference { Iid = poco.TopContainer.Iid, ClassKind = poco.TopContainer.ClassKind },
                IterationId = targetIteration?.Iid
            };

            var copyInfo = new CopyInfo
            {
                Source = source,
                Target = target,
                Options = options
            };

            if (targetIteration != null)
            {
                var participation = this.session.OpenIterations.FirstOrDefault(x => x.Key.Iid == targetIteration.Iid).Value;
                copyInfo.ActiveOwner = participation.Item1?.Iid ?? Guid.Empty;
            }

            this.Copy.Add(copyInfo);
        }
    }
}
