#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WSPPostOperation.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace CDP4WspDal
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
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// The object containing the form of the official WSP post request 
    /// </summary>
    public class WspPostOperation : PostOperation
    {
        /// <summary>
        /// The <see cref="IMetaDataProvider"/> used in the application
        /// </summary>
        private readonly IMetaDataProvider metaDataProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="WspPostOperation"/> class
        /// </summary>
        /// <param name="metaDataProvider">The <see cref="IMetaDataProvider"/></param>
        public WspPostOperation(IMetaDataProvider metaDataProvider)
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
        public override List<Thing> Create { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to update.
        /// </summary>
        [JsonProperty("_update")]
        public override List<ClasslessDTO> Update { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to copy.
        /// </summary>
        [JsonIgnore]
        public override List<ClasslessDTO> Copy { get; set; }

        /// <summary>
        /// Populate this <see cref="WspPostOperation"/> with the correct setup for the OCDT protocol
        /// </summary>
        /// <param name="operation">
        /// The operation.
        /// </param>
        public override void ConstructFromOperation(Operation operation)
        {
            if (operation.ModifiedThing == null)
            {
                throw new ArgumentNullException("operation");
            }

            if (operation.OperationKind == OperationKind.Update && operation.OriginalThing == null)
            {
                throw new ArgumentException(
                    "When OperationKind is an Update the OriginalThing of the operation may not be null");
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
                    throw new NotSupportedException("The WSP Post operations do not support a Copy");
                case OperationKind.Move:
                    throw new NotSupportedException("The WSP Post operations do not support a Move");
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
