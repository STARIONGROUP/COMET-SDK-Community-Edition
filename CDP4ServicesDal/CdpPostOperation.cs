// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="RHEA S.A.">
//   Copyright (c) 2015-2018 RHEA S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.MetaInfo;    
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal.Operations;
    using Newtonsoft.Json;

    /// <summary>
    /// The CDP POST operation
    /// </summary>
    /// <seealso cref="PostOperation" />
    internal class CdpPostOperation : PostOperation
    {
        /// <summary>
        /// The <see cref="IMetaDataProvider"/> used in the application
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="CdpPostOperation"/> class.
        /// </summary>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/></param>
        internal CdpPostOperation(IMetaDataProvider metaDataProvider)
        {
            this.metaDataProvider = metaDataProvider;
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to delete.
        /// </summary>
        [JsonProperty("_delete")]
        public override List<ClasslessDTO> Delete { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to create.
        /// </summary>
        [JsonProperty("_create")]
        public override List<CDP4Common.DTO.Thing> Create { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to update.
        /// </summary>
        [JsonProperty("_update")]
        public override List<ClasslessDTO> Update { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to copy.
        /// </summary>
        [JsonProperty("_copy")]
        public override List<ClasslessDTO> Copy { get; set; }

        /// <summary>
        /// Populate the current <see cref="PostOperation"/> with the content based on the 
        /// provided <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        /// The <see cref="Operation"/> that contains all the <see cref="Thing"/>s that need to be
        /// updated to the data-source
        /// </param>
        public override void ConstructFromOperation(Operation operation)
        {
            if (operation.ModifiedThing == null)
            {
                throw new ArgumentNullException("operation", "The operation may not be null");
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
                case OperationKind.Copy:
                    throw new NotImplementedException("Copy operation is not yet implemented");
                case OperationKind.Move:
                    throw new NotImplementedException("Move operation is not yet implemented");
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
                    if (key.Equals("Iid") || key.Equals("ClassKind"))
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
    }
}
