// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingTransaction.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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
//    Lesser General Public License for more details.copy
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Operations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using CDP4Common;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Extensions;
    using CDP4Common.Polyfills;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.CommonData;
    using CDP4Common.Types;

    using CDP4Dal.Exceptions;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The Transaction class contains all requests for the creations, updates, deletions of things
    /// </summary>
    public class ThingTransaction : IThingTransaction
    {
        /// <summary>
        /// The <see cref="ILogger"/> used to log
        /// </summary>
        private readonly ILogger<ThingTransaction> logger;

        /// <summary>
        /// Gets the added <see cref="Thing"/>s
        /// </summary>
        private readonly List<Thing> addedThing;

        /// <summary>
        /// Gets the updated <see cref="Thing"/>s
        /// </summary>
        private readonly Dictionary<Thing, Thing> updatedThing;

        /// <summary>
        /// Gets the deleted <see cref="Thing"/>s
        /// </summary>
        private readonly List<Thing> deletedThing;

        /// <summary>
        /// The list of copied <see cref="Thing"/>
        /// </summary>
        private readonly Dictionary<Tuple<Thing, Thing>, OperationKind> copiedThing;

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingTransaction"/> class
        /// </summary>
        /// <param name="transactionContext">
        /// The <see cref="SiteDirectory"/> or <see cref="Iteration"/> that represents the <see cref="Thing"/> the
        /// current <see cref="ThingTransaction"/> is operated on.
        /// </param>
        /// <param name="clone">
        /// In the context of sub-transactions:
        ///    The clone of the <see cref="Thing"/> associated with the root <see cref="ThingTransaction"/>.
        ///    This clone shall be the clone of the highest <see cref="Thing"/> in the chain of operations if not null.
        ///    The clone is added in the list of updated things if not null.
        /// In the context of a single transaction:
        ///    The clone of a <see cref="Thing"/> to add or update.
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        /// <remarks>
        /// In the context of sub-transactions, this constructor shall be used for the root-transaction
        /// </remarks>
        public ThingTransaction(TransactionContext transactionContext, Thing clone = null, ILoggerFactory loggerFactory = null)
        {
            this.logger = loggerFactory == null ? NullLogger<ThingTransaction>.Instance : loggerFactory.CreateLogger<ThingTransaction>();

            this.TransactionContext = 
                transactionContext ?? 
                throw new ArgumentNullException(nameof(transactionContext), $"The {nameof(transactionContext)} may not be null");
           
            this.addedThing = new List<Thing>();
            this.updatedThing = new Dictionary<Thing, Thing>();
            this.deletedThing = new List<Thing>();
            this.copiedThing = new Dictionary<Tuple<Thing, Thing>, OperationKind>();

            if (clone != null)
            {
                this.AssociatedClone = clone;
                this.CreateOrUpdate(clone);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingTransaction"/> class
        /// </summary>
        /// <param name="clone">
        /// The clone of the <see cref="Thing"/> to add or update
        /// </param>
        /// <param name="parentTransaction">
        /// The parent <see cref="IThingTransaction"/>
        /// </param>
        /// <param name="containerClone">
        /// The container <see cref="Thing"/> for the current added or updated operation
        /// </param>
        /// <param name="loggerFactory">
        /// The (injected) <see cref="ILoggerFactory"/> used to setup logging
        /// </param>
        /// <remarks>
        /// In the context of sub-transactions:
        ///    This constructor shall be used for sub-transactions.
        ///    The <paramref name="clone"/> is the associated clone for the current transaction.
        ///    The <paramref name="parentTransaction"/> shall not be null.
        ///    The <paramref name="containerClone"/> may be null.
        /// In the context of a single-transaction:
        ///    The <paramref name="clone"/> is added to the list of added or updated thing
        ///    <paramref name="parentTransaction"/> shall be null.
        ///    <paramref name="containerClone"/> shall not be null as it is added as well and updated with the clone.
        /// </remarks>
        public ThingTransaction(Thing clone, IThingTransaction parentTransaction, Thing containerClone, ILoggerFactory loggerFactory = null)
        {
            this.logger = loggerFactory == null ? NullLogger<ThingTransaction>.Instance : loggerFactory.CreateLogger<ThingTransaction>();

            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not be null.");
            }
            
            this.TransactionContext = parentTransaction.TransactionContext;

            this.addedThing = new List<Thing>();
            this.updatedThing = new Dictionary<Thing, Thing>();
            this.deletedThing = new List<Thing>();
            this.AssociatedClone = clone;

            this.ParentTransaction = parentTransaction;
            this.CreateOrUpdate(clone);

            if (this.ParentTransaction != null)
            {
                this.InitializeSubTransaction(this, containerClone);
            }
            else
            {
                //TODO: figure out why this is unreacheable
                if (containerClone == null)
                {
                    throw new ArgumentNullException(nameof(containerClone), $"The {nameof(containerClone)} may not be null");
                }

                this.CreateOrUpdate(containerClone);
                this.UpdateContainer(clone, containerClone);
            }
        }

        /// <summary>
        /// Gets the <see cref="TransactionContext"/>
        /// </summary>
        public IThingTransaction ParentTransaction { get; }

        /// <summary>
        /// Gets the <see cref="TransactionContext"/>
        /// </summary>
        public TransactionContext TransactionContext { get; }

        /// <summary>
        /// The clone of the <see cref="Thing"/> associated with the current <see cref="ThingTransaction"/>
        /// </summary>
        public Thing AssociatedClone { get; }

        /// <summary>
        /// Gets the Added <see cref="Thing"/>s
        /// </summary>
        public IEnumerable<Thing> AddedThing => this.addedThing;

        /// <summary>
        /// Gets the deleted <see cref="Thing"/>s
        /// </summary>
        public IEnumerable<Thing> DeletedThing => this.deletedThing;

        /// <summary>
        /// Gets the Updated <see cref="Thing"/>s where the Key is the original <see cref="Thing"/> and the value the cloned <see cref="Thing"/>
        /// </summary>
        public IReadOnlyDictionary<Thing, Thing> UpdatedThing => this.updatedThing;

        /// <summary>
        /// Gets the copied <see cref="Thing"/>s
        /// </summary>
        public IReadOnlyDictionary<Tuple<Thing, Thing>, OperationKind> CopiedThing => copiedThing;

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created in the current transaction
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to create
        /// </param>
        /// <param name="containerClone">
        /// The clone of the container in which <paramref name="clone"/> is added.
        /// This argument is not used in the context of sub-transactions.
        /// <remarks>
        /// The <paramref name="containerClone"/> is only updated in the context where there are no sub-transaction.
        /// </remarks>
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a <see cref="TopContainer"/> or <see cref="Iteration"/> is registered
        /// </exception>
        public void Create(Thing clone, Thing containerClone = null)
        {
            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not be null");
            }

            if (clone is TopContainer || clone is Iteration)
            {
                throw new InvalidOperationException("The creation of a TopContainer or an Iteration is not allowed.");
            }

            if (clone.Cache != null)
            {
                if (clone.Iid != Guid.Empty && clone.Cache.Any(x => Equals(x.Key, clone.CacheKey)))
                {
                    throw new InvalidOperationException("The clone is an original thing present in the cache.");
                }
            }

            if (this.AddedThing.Contains(clone))
            {
                return;
            }

            if (clone.Iid == Guid.Empty)
            {
                clone.Iid = Guid.NewGuid();
            }

            clone.ChangeKind = ChangeKind.Create;

            this.addedThing.Add(clone);

            if (this.ParentTransaction == null && containerClone != null)
            {
                this.UpdateContainer(clone, containerClone);
            }
        }

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created in the current transaction along with all its potential contained <see cref="Thing"/>s
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to create
        /// </param>
        /// <param name="containerClone">
        /// The clone of the container in which <paramref name="clone"/> is added. 
        /// <remarks>
        /// <paramref name="containerClone"/> is only updated in the context where there are no sub-transaction.
        /// </remarks>
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown if a <see cref="TopContainer"/> or <see cref="Iteration"/> is registered
        /// </exception>
        public void CreateDeep(Thing clone, Thing containerClone = null)
        {
            this.Create(clone, containerClone);
            this.RegisterContainedThings(clone, false);
        }

        /// <summary>
        /// Register a deep copy operations for the <see cref="Thing"/>
        /// </summary>
        /// <param name="deepClone">The <see cref="Thing"/> to copy</param>
        /// <param name="containerClone">The container</param>
        public void CopyDeep(Thing deepClone, Thing containerClone = null)
        {
            this.Create(deepClone, containerClone);
            this.RegisterContainedThings(deepClone, true);
        }

        /// <summary>
        /// Registers the provided <see cref="Thing"/> to be created or updated in the current transaction
        /// </summary>
        /// <param name="clone">The clone of the <see cref="Thing"/> to update</param>
        public void CreateOrUpdate(Thing clone)
        {
            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not be null");
            }

            if(this.UpdatedThing.Values.Any(x => x == clone) || this.AddedThing.Any(x => x == clone))
            {
                return;
            }

            if(this.UpdatedThing.Values.Any(x => x.Iid == clone.Iid) || this.AddedThing.Any(x => x.Iid == clone.Iid))
            {
                return;
            }

            var UpdatedThing = this.GetUpdatedThing(clone);
            if(UpdatedThing != null)
            {
                if (clone.Iid == Guid.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(clone), $"The Iid of the {nameof(clone)} cannot be null.");
                }

                clone.ChangeKind = ChangeKind.Update;
                this.updatedThing.Add(UpdatedThing, clone);
            }
            else
            {
                this.Create(clone);
            }
        }

        /// <summary>
        /// Registers the provided clone of a <see cref="Thing"/> as a deleted.
        /// </summary>
        /// <param name="clone">The clone of the <see cref="Thing"/> to delete</param>
        /// <param name="containerClone">The clone of the container (mandatory in dialogs)</param>
        public void Delete(Thing clone, Thing containerClone = null)
        {
            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not be null.");
            }
            
            if (this.DeletedThing.Any(x => x.Iid == clone.Iid))
            {
                return;
            }

            // Verify that a new clone is passed - reference check - only copy allowed
            var previousUpdatedReference = this.GetUpdatedThing(clone);

            if (previousUpdatedReference != null && clone is IDeprecatableThing)
            {
                throw new NotImplementedException("Delete of Deprecatable thing is not implemented.");
            }

            if (this.ParentTransaction != null)
            {
                if (containerClone == null)
                {
                    throw new ArgumentNullException(nameof(containerClone),
                        "the clone of the container is mandatory in a dialog context.");
                }

                if (previousUpdatedReference != null)
                {
                    // remove potential reference from the list of updated thing in the current transaction
                    var updatedThingKey = this.UpdatedThing.Keys.SingleOrDefault(x => x.Iid == clone.Iid);
                    if (updatedThingKey != null)
                    {
                        this.updatedThing.Remove(updatedThingKey);
                    }

                    // replace references
                    this.UpdateContainer(clone, containerClone);
                }
                else
                {
                    // remove from the list of added thing 
                    var thingInAddedList = this.AddedThing.SingleOrDefault(x => x.Iid == clone.Iid);
                    if (thingInAddedList != null)
                    {
                        this.addedThing.Remove(thingInAddedList);
                    }

                    this.RemoveThingFromContainer(clone);
                }
            }

            clone.ChangeKind = ChangeKind.Delete;
            this.deletedThing.Add(clone);
        }

        /// <summary>
        /// Registers the provided clone of a <see cref="Thing"/> as a copy with its destination
        /// </summary>
        /// <param name="clone">
        /// The <see cref="Thing"/> to copy
        /// </param>
        /// <param name="containerDestinationClone">
        /// The new container
        /// </param>
        /// <param name="operationKind">
        /// The <see cref="OperationKind"/> that specify the kind of copy operation
        /// </param>
        public void Copy(Thing clone, Thing containerDestinationClone, OperationKind operationKind)
        {
            if (!operationKind.IsCopyOperation())
            {
                throw new ArgumentException("The copy operation may only be performed with Copy or CopyDefaultValuesChangeOwner or CopyKeepValues or CopyKeepValuesChangeOwner", nameof(operationKind));
            }

            if (containerDestinationClone == null)
            {
                throw new ArgumentNullException(nameof(containerDestinationClone), $"The {nameof(containerDestinationClone)} may not be null");
            }

            this.Copy(clone, operationKind);
            clone.Container = containerDestinationClone;
        }

        /// <summary>
        /// Registers the provided clone of a <see cref="Thing"/> as a copy
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> to copy</param>
        /// <param name="operationKind">
        /// The <see cref="OperationKind"/> that specify the kind of copy operation
        /// </param>
        public void Copy(Thing clone, OperationKind operationKind)
        {
            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not be null");
            }

            if (!operationKind.IsCopyOperation())
            {
                throw new ArgumentException("The copy operation may only be performed with Copy or CopyDefaultValuesChangeOwner or CopyKeepValues or CopyKeepValuesChangeOwner", nameof(operationKind));
            }
            
            var original = this.GetUpdatedThing(clone);

            // setting a new iid for the copy
            clone.Iid = Guid.NewGuid();
            var originalCopyPair = new Tuple<Thing, Thing>(original, clone);

            if (this.CopiedThing.ContainsKey(originalCopyPair))
            {
                return;
            }
            
            // setting a new iid for the copy
            clone.Iid = Guid.NewGuid();
            this.copiedThing.Add(originalCopyPair, operationKind);
        }

        /// <summary>
        /// Get the clone of the <see cref="Thing"/> used in the current sub-<see cref="IThingTransaction"/> if any
        /// </summary>
        /// <param name="thing">the <see cref="Thing"/> which clone to get</param>
        /// <returns>The clone of the <see cref="Thing"/> used in the current transaction if it exists. Null otherwise</returns>
        public Thing GetClone(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null.");
            }

            if (thing.Iid == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(thing), $"The Iid of {nameof(thing)} may not be the empty Guid.");
            }

            var clone = this.UpdatedThing.Values.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            clone = this.AddedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            
            return clone;
        }

        /// <summary>
        /// Get the last clone of a specified <see cref="Thing"/> with a specific id in the current chain of operations
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>The last clone created if any, null otherwise</returns>
        public Thing GetLastCloneCreated(Thing thing)
        {
            if (thing == null)
            {
                throw new ArgumentNullException(nameof(thing), $"The {nameof(thing)} may not be null");
            }

            if (thing.Iid == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException(nameof(thing), $"The Iid of {nameof(thing)} may not be the empty Guid.");
            }

            var allAddedThing = this.GetAllAddedThings().ToList();
            var clone = allAddedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            var allUpdatedThing = this.GetAllUpdatedThings().ToList();
            clone = allUpdatedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            
            return clone;
        }

        /// <summary>
        /// Finalize the sub-transaction by resolving and updating the containers and by merging the current transaction into its parent.
        /// </summary>
        /// <param name="clone">The clone <see cref="Thing"/> to update</param>
        /// <param name="containerclone">The container</param>
        /// <param name="nextThing">
        /// The next (following) <see cref="Thing"/> in an <see cref="OrderedItemList{T}"/> where the new <see cref="Thing"/> is created
        /// if <paramref name="nextThing"/> is null, the <paramref name="clone"/> is appended to the list
        /// </param>
        /// <remarks>
        /// Calling this method for a root-transaction will not do anything.
        /// </remarks>
        public void FinalizeSubTransaction(Thing clone, Thing containerclone, Thing nextThing = null)
        {
            if (this.ParentTransaction == null)
            {
                throw new InvalidOperationException("This method shall only be called on a sub-transaction.");
            }

            // also update thing of the same type as it may be that one of the container in the current sub-transaction was changed 
            // to a thing which is not in the normal "chain of operations".
            if (clone == null)
            {
                throw new ArgumentNullException(nameof(clone), $"The {nameof(clone)} may not null.");
            }

            if (containerclone == null)
            {
                throw new ArgumentNullException(nameof(containerclone), $"The {nameof(containerclone)} may not be null.");
            }

            this.UpdateContainer(clone, containerclone, nextThing);

            // update the reference of possible other clones of the same type which were added when a contained item 
            // of the current AssociatedClone was updated to another one
            var rootClone = GetOperationRootClone();
            var cloneTypeToUpdate = this.AssociatedClone.GetContainerInformation().Item1;

            foreach (
                var addedThing in
                    this.AddedThing.Where(
                        x => x != this.AssociatedClone && x.GetContainerInformation().Item1 == cloneTypeToUpdate))
            {
                if (!addedThing.IsContainedBy(rootClone.Iid))
                {
                    // no need to update the container as it cannot be accessed through the current chain of operations
                    continue;
                }

                // the clone should have been added
                var containerOfAddedThing = this.GetClone(addedThing.Container);
                if (containerOfAddedThing == null)
                {
                    throw new TransactionException("could not find the corresponding clone for the container of the added thing added outside the chain of transaction.");
                }

                this.UpdateContainer(addedThing, containerOfAddedThing);
            }

            foreach (
                var updatedThing in
                    this.UpdatedThing.Values.Where(
                        x => x != this.AssociatedClone && x.GetContainerInformation().Item1 == cloneTypeToUpdate))
            {
                if (!updatedThing.IsContainedBy(rootClone.Iid))
                {
                    // no need to update the container as it cannot be access through the current chain of operations
                    continue;
                }

                // the clone should have been added
                var containerOfUpdatedThing = this.GetClone(updatedThing.Container);
                if (containerOfUpdatedThing == null)
                {
                    throw new TransactionException(
                        "could not find the corresponding clone for the container of the updated thing added outside the chain of transaction.");
                }

                this.UpdateContainer(updatedThing, containerOfUpdatedThing);
            }

            this.ParentTransaction.Merge(this);
        }

        /// <summary>
        /// Finalizes all operations that happened during this <see cref="IThingTransaction"/>
        /// </summary>
        /// <returns>The <see cref="OperationContainer"/></returns>
        public OperationContainer FinalizeTransaction()
        {
            if (this.ParentTransaction != null)
            {
                throw new InvalidOperationException("This shall only be possible for a root transaction.");
            }

            this.FilterOperationCausedByDelete();
            
            var context = this.TransactionContext.ContextRoute();
            var operationContainer = new OperationContainer(context, this.GetTopContainerRevisionNumber());

            this.CreateNewThingOperation(operationContainer);
            this.CreateUpdatedThingOperation(operationContainer);
            this.CreateDeletedThingOperation(operationContainer);
            this.CreateCopyThingOperation(operationContainer);

            return operationContainer;
        }

        /// <summary>
        /// Get all the files that need to be added to the DataStore accoring to the added/changed/deleted <see cref="Thing"/>s
        /// </summary>
        /// <returns>An Array of strings that contain the local paths in the context of the users' computer</returns>
        public string[] GetFiles()
        {
            var files = new List<string>();

            foreach (var thing in this.AddedThing.OfType<ILocalFile>().Union(this.UpdatedThing.OfType<ILocalFile>()).Where(x => x.LocalPath != null))
            {
                if (string.IsNullOrWhiteSpace(thing.ContentHash))
                {
                    throw new InvalidOperationException($"File {thing.LocalPath} cannot be saved because of an empty ContentHash" );
                }

                files.Add(thing.LocalPath);
            }

            return files.Any() ? files.Distinct().ToArray() : null;
        }

        /// <summary>
        /// Get the last version of a specified <see cref="Thing"/> registered in the current chain of operations which <paramref name="clone"/> is an update of.
        /// </summary>
        /// <param name="clone">The new version of a <see cref="Thing"/></param>
        /// <returns>The last version of a <see cref="Thing"/> which <paramref name="clone"/> is an update of</returns>
        private Thing GetUpdatedThing(Thing clone)
        {
            // case1: the updated thing is already in the transaction as an updated thing
            var allUpdatedThings = this.GetAllUpdatedThings().ToList();

            var updatedThing = allUpdatedThings.SingleOrDefault(x => x.Iid == clone.Iid);
            if(updatedThing != null)
            {
                if (updatedThing == clone)
                {
                    throw new InvalidOperationException("The clone and its previous version cannot be the same.");
                }

                return updatedThing;
            }

            // case2: the updated thing is already in the transaction as an added thing
            var allAddedThings = this.GetAllAddedThings().ToList();
            updatedThing = allAddedThings.SingleOrDefault(x => x.Iid == clone.Iid);
            if (updatedThing != null)
            {
                if (updatedThing == clone)
                {
                    throw new InvalidOperationException("The clone and its previous version cannot be the same.");
                }

                return null;
            }

            // case 2 bis
            // the updated thing is a new thing to be created, its cache may be null.
            if (clone.Cache == null)
            {
                return null;
            }

            // case3: the cache does not contain the key, its a new
            var lazy = clone.Cache.SingleOrDefault(x => Equals(x.Key, clone.CacheKey)).Value;
            if (lazy == null)
            {
                return null;
            }

            // case4: the updated thing is the original
            updatedThing = lazy.Value;
            if (updatedThing == clone)
            {
                throw new InvalidOperationException("The transaction only accepts clones.");
            }

            return updatedThing;
        }

        /// <summary>
        /// Get all the added <see cref="Thing"/> in the current chain of transaction
        /// </summary>
        /// <returns>An enumeration of all the added things</returns>
        private IEnumerable<Thing> GetAllAddedThings()
        {
            var allAddedThing = this.AddedThing.ToList();
            if (this.ParentTransaction != null)
            {
                this.PopulateAllAddedThingsList(this.ParentTransaction, allAddedThing);
            }

            return allAddedThing;
        }

        /// <summary>
        /// Populates the list of all the added things in a specified transaction
        /// </summary>
        /// <param name="transaction">The <see cref="ThingTransaction"/></param>
        /// <param name="allAddedThing">The list containing all the added things</param>
        private void PopulateAllAddedThingsList(IThingTransaction transaction, List<Thing> allAddedThing)
        {
            var thingsToAdd = transaction.AddedThing.Where(x => allAddedThing.All(y => y.Iid != x.Iid));
            allAddedThing.AddRange(thingsToAdd);
            if (transaction.ParentTransaction != null)
            {
                this.PopulateAllAddedThingsList(transaction.ParentTransaction, allAddedThing);
            }
        }

        /// <summary>
        /// Get all the updated <see cref="Thing"/> in the current chain of transaction
        /// </summary>
        /// <returns>An enumeration of all the updated things</returns>
        private IEnumerable<Thing> GetAllUpdatedThings()
        {
            var allUpdatedThings = this.UpdatedThing.Values.ToList();
            if (this.ParentTransaction != null)
            {
                this.PopulateAllUpdatedThingsList(this.ParentTransaction, allUpdatedThings);
            }

            return allUpdatedThings;
        }

        /// <summary>
        /// Populates the list of all the updated things in a specified transaction
        /// </summary>
        /// <param name="transaction">The specified <see cref="IThingTransaction"/></param>
        /// <param name="allUpdatedThing">The list of all the updated things to populate</param>
        private void PopulateAllUpdatedThingsList(IThingTransaction transaction, List<Thing> allUpdatedThing)
        {
            var thingsToAdd = transaction.UpdatedThing.Values.Where(x => allUpdatedThing.All(y => y.Iid != x.Iid));
            allUpdatedThing.AddRange(thingsToAdd);
            if (transaction.ParentTransaction != null)
            {
                this.PopulateAllUpdatedThingsList(transaction.ParentTransaction, allUpdatedThing);
            }
        }

        /// <summary>
        /// Update the <see cref="ContainerList{T}"/> property of the container
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to add</param>
        /// <param name="containerClone">The clone of the container <see cref="Thing"/></param>
        /// <param name="containerProperty">The <see cref="PropertyInfo"/> of the <see cref="ContainerList{T}"/></param>
        private void UpdateContainerList(Thing thing, Thing containerClone, PropertyInfo containerProperty)
        {
            var containerList = containerProperty.GetValue(containerClone);
           
            if (thing.Container != null && thing.Container.Iid == containerClone.Iid)
            {
                // replace the reference in the container list
                var findIndexMethod = containerProperty.PropertyType.GetMethod("FindIndex", new []{ typeof(Predicate<Thing>) });
                Predicate<Thing> predicate = x => x.Iid == thing.Iid;

                var index = (int)(findIndexMethod?.Invoke(containerList, new object[] { predicate })??-1);
                if (index != -1)
                {
                    // Get the indexer property, by default the indexer property name is "Item"
                    var indexerProperty = containerProperty.PropertyType.GetProperty("Item");
                    indexerProperty.SetValue(containerList, thing, new object[] { index });
                }
            }
            else
            {
                // add the thing to the container if new container
                var addMethod = containerProperty.PropertyType.GetMethod("Add");
                addMethod.Invoke(containerList, new object[] { thing });
            }

            this.CreateOrUpdate(containerClone);
        }

        /// <summary>
        /// Update the <see cref="OrderedItemList{T}"/> property of the container
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to add</param>
        /// <param name="containerClone">The clone of the container <see cref="Thing"/></param>
        /// <param name="nextThing">The <see cref="Thing"/> before which the new <see cref="Thing"/> is inserted</param>
        /// <param name="orderedListProperty">The <see cref="PropertyInfo"/> of the <see cref="OrderedItemList{T}"/></param>
        private void UpdateOrderedItemList(Thing thing, Thing containerClone, Thing nextThing, PropertyInfo orderedListProperty)
        {
            var containerList = orderedListProperty.GetValue(containerClone);

            if (thing.Container != null && thing.Container.Iid == containerClone.Iid)
            {
                // replace the reference in the container list as another reference of the thing to add is already in the list
                var findIndexMethod = orderedListProperty.PropertyType.GetMethod("FindIndex");

                Predicate<Thing> predicate = x => x.Iid == thing.Iid;

                var index = (int)findIndexMethod.Invoke(containerList, new object[] { predicate });
                if (index != -1)
                {
                    // Get the indexer property, by default the indexer property name is "Item"
                    var indexerProperty = orderedListProperty.PropertyType.GetProperty("Item");
                    indexerProperty.SetValue(containerList, thing, new object[] { index });
                }
            }
            else
            {
                if (nextThing == null)
                {
                    // normal add
                    var addMethod = orderedListProperty.PropertyType.GetMethod("Add");
                    addMethod.Invoke(containerList, new object[] {thing});
                }
                else
                {
                    // insert the new thing before nextThing
                    var indexOfMethod = orderedListProperty.PropertyType.GetMethod("IndexOf");

                    var index = indexOfMethod.Invoke(containerList, new object[] { nextThing }) as int?;
                    if (index == -1 || !index.HasValue)
                    {
                        throw new InvalidOperationException("The Thing before which the new item needs to be inserted does not exist.");
                    }

                    var insertMethod = orderedListProperty.PropertyType.GetMethod("Insert");
                    insertMethod.Invoke(containerList, new object[] { index.Value, thing });
                }
            }

            this.CreateOrUpdate(containerClone);
        }

        /// <summary>
        /// Remove the given <see cref="Thing"/> from its container in the current transaction
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to be remove from the containers</param>
        private void RemoveThingFromContainer(Thing thing)
        {
            var containers = this.AddedThing.Concat(this.UpdatedThing.Values);
            
            var thingType = thing.GetType();

            Thing originalThing = null;
            if (thing.Cache != null && thing.Cache.ContainsKey(thing.CacheKey))
            {
                var result = thing.Cache.TryGetValue(thing.CacheKey, out var lazyThing);
                originalThing = (result)? lazyThing.Value : null;
            }

            // Find in all the thing in the transaction the potential container that contains the current thing
            foreach (var container in containers)
            {
                if (originalThing != null)
                {
                    if (originalThing.Container.Iid == container.Iid)
                    {
                        // Dal will handle the removal on the original container
                        continue;
                    }
                }

                var containerType = container.GetType();

                var matchingPropertyInfos = containerType.GetProperties().Where(x =>
                    x.PropertyType.QueryIsGenericType() &&
                    (x.PropertyType.GetGenericTypeDefinition() == typeof(ContainerList<>) ||
                    x.PropertyType.GetGenericTypeDefinition() == typeof(OrderedItemList<>)) &&
                    x.PropertyType.GetGenericArguments().Single().QueryIsAssignableFrom(thingType)).ToList();

                foreach (var propertyInfo in matchingPropertyInfos)
                {
                    var removeMethod = propertyInfo.PropertyType.GetMethod("Remove");
                    var containerList = propertyInfo.GetValue(container) as IEnumerable;

                    Thing thingToRemove = null;
                    foreach (Thing containedThing in containerList)
                    {
                        if (containedThing.Iid == thing.Iid)
                        {
                            thingToRemove = containedThing;
                        }
                    }

                    if (thingToRemove == null)
                    {
                        continue;
                    }

                    var success = (bool)removeMethod.Invoke(containerList, new object[] { thingToRemove });
                    if (success)
                    {
                        thingToRemove.Container = null;
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Initialize a <see cref="IThingTransaction"/> from its parent transaction
        /// </summary>
        /// <param name="subTransaction">The <see cref="ThingTransaction"/> to initialize</param>
        /// <param name="containerClone">The <see cref="Thing"/> that is supposed to contain the <see cref="AssociatedClone"/>. May be null at initialization</param>
        private void InitializeSubTransaction(ThingTransaction subTransaction, Thing containerClone)
        {
            var containerType = this.AssociatedClone.GetContainerInformation().Item1;

            if (containerClone != null)
            {
                var currentContainertype = containerClone.GetType();
                if (!containerType.QueryIsAssignableFrom(currentContainertype))
                {
                    throw new InvalidOperationException("The specified container is not allowed as a container.");
                }

                if (this.ParentTransaction.AddedThing.Contains(containerClone))
                {
                    subTransaction.addedThing.Add(containerClone);
                }
                else if (this.ParentTransaction.UpdatedThing.Values.Contains(containerClone))
                {
                    var keyvalue = this.ParentTransaction.UpdatedThing.Single(x => x.Value == containerClone);
                    subTransaction.updatedThing.Add(keyvalue.Key, keyvalue.Value);
                }
                else
                {
                    throw new InvalidOperationException("The clone of the container is not in the parent transaction.");
                }
            }
        }

        /// <summary>
        /// Add a new chain of clones to the current transaction for the update of a thing outside of the current chain.
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> being updated outside the current chain</param>
        private void AddChainOfContainers(Thing clone)
        {
            var topOperationClone = this.GetOperationRootClone();
            if (!clone.IsContainedBy(topOperationClone.Iid))
            {
                return;
            }

            var chainOfTransactions = this.GetChainOfSubTransactions().ToList();

            // root is first
            chainOfTransactions.Reverse();

            // remove the root which does not contain an associated clone
            chainOfTransactions.RemoveAt(0);

            foreach (var transaction in chainOfTransactions)
            {
                if (clone.IsContainedBy(transaction.AssociatedClone.Iid))
                {
                    continue;
                }

                // add a new clone if newContainerClone is not contained by the current operation's chain of clones
                var containerType = transaction.AssociatedClone.GetType();
                var container = clone.GetContainerOfType(containerType);
                if (container == null)
                {
                    return;
                }

                // check if the container was already updated. create a new clone
                var containerClone = this.GetLastCloneCreated(container);
                containerClone = containerClone != null ? containerClone.Clone(false) : container.Clone(false);
                this.CreateOrUpdate(containerClone);
            }
        }

        /// <summary>
        /// Get the clone of the <see cref="Thing"/> at the root of all the current <see cref="ThingTransaction"/>s
        /// </summary>
        /// <returns>The clone of the <see cref="Thing"/> at the root of all the current <see cref="ThingTransaction"/>s</returns>
        private Thing GetOperationRootClone()
        {
            var rootClone = this.AssociatedClone;
            var parent = this.ParentTransaction;
            while (parent != null)
            {
                rootClone = parent.AssociatedClone ?? rootClone;
                parent = parent.ParentTransaction;
            }

            return rootClone;
        }

        /// <summary>
        /// Gets the chain of <see cref="ThingTransaction"/> for the current one
        /// </summary>
        /// <returns>The chain of <see cref="ThingTransaction"/></returns>
        private IEnumerable<IThingTransaction> GetChainOfSubTransactions()
        {
            var parent = this.ParentTransaction;
            while (parent != null)
            {
                yield return parent;
                parent = parent.ParentTransaction;
            }
        }

        /// <summary>
        /// Updates the container of the specified <see cref="Thing"/>
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> to ass or remove</param>
        /// <param name="containerclone">The container to update</param>
        /// <param name="nextThing">
        /// The next (following) <see cref="Thing"/> in an <see cref="OrderedItemList{T}"/> where the new <see cref="Thing"/> is created
        /// if <paramref name="nextThing"/> is null, the <paramref name="clone"/> is appended to the list
        /// </param>
        private void UpdateContainer(Thing clone, Thing containerclone, Thing nextThing = null)
        {
            var containerInformation = clone.GetContainerInformation();
            if (!containerInformation.Item1.IsInstanceOfType(containerclone))
            {
                throw new InvalidOperationException("The containerClone does not have the right type");
            }

            // remove the current thing from its previous container if it was changed from original
            if (clone.Container != null && clone.Container.Iid != containerclone.Iid)
            {
                this.RemoveThingFromContainer(clone);
                this.CreateOrUpdate(containerclone);
                this.AddChainOfContainers(containerclone);
            }

            this.AddCloneToContainer(clone, containerclone, nextThing);
        }

        /// <summary>
        /// Add the <paramref name="clone"/> to the <paramref name="containerclone"/>
        /// </summary>
        /// <param name="clone">The <see cref="Thing"/> to ass or remove</param>
        /// <param name="containerclone">The container to update</param>
        /// <param name="nextThing">
        /// The next (following) <see cref="Thing"/> in an <see cref="OrderedItemList{T}"/> where the new <see cref="Thing"/> is created
        /// if <paramref name="nextThing"/> is null, the <paramref name="clone"/> is appended to the list
        /// </param>
        private void AddCloneToContainer(Thing clone, Thing containerclone, Thing nextThing = null)
        {
            var containerInformation = clone.GetContainerInformation();
            if (!containerInformation.Item1.IsInstanceOfType(containerclone))
            {
                throw new InvalidOperationException("The containerClone does not have the right type");
            }

            // add/replace the clone to its container and add the container in the list of updated object
            var containerType = containerclone.GetType();
            var containerProperty = containerType.GetProperty(containerInformation.Item2);

            if (containerProperty == null)
            {
                throw new TransactionException($"The property {containerInformation.Item2} could not be found");
            }

            if (containerProperty.PropertyType.GetGenericTypeDefinition() == typeof(ContainerList<>))
            {
                this.UpdateContainerList(clone, containerclone, containerProperty);
            }
            else
            {
                // OrderedItemList
                this.UpdateOrderedItemList(clone, containerclone, nextThing, containerProperty);
            }
        }

        /// <summary>
        /// Merge the sub-transaction into the current <see cref="ThingTransaction"/>
        /// </summary>
        /// <param name="subTransaction">The sub-<see cref="IThingTransaction"/></param>
        public void Merge(IThingTransaction subTransaction)
        {
            // replace or add all element in AddedThing
            foreach (var thing in subTransaction.AddedThing)
            {
                if (this.AddedThing.Contains(thing))
                {
                    continue;
                }

                var existingThing = this.AddedThing.SingleOrDefault(t => t.Iid == thing.Iid);
                if (existingThing != null)
                {
                    // replace the current thing with the one from the sub-transaction
                    var index = this.addedThing.IndexOf(existingThing);
                    this.addedThing[index] = thing;
                }
                else
                {
                    this.addedThing.Add(thing);
                }
            }

            foreach (var keyValuePair in subTransaction.UpdatedThing)
            {
                if (this.UpdatedThing.ContainsKey(keyValuePair.Key))
                {
                    var parentKeyValue = this.UpdatedThing.Single(x => x.Key == keyValuePair.Key);
                    if (parentKeyValue.Value != keyValuePair.Value)
                    {
                        throw new InvalidOperationException("2 clones have been created for the same thing.");
                    }

                    continue;
                }

                // check if the key in a sub-transaction correspond to a value in the current one
                var existingKeyValue = this.UpdatedThing.SingleOrDefault(x => x.Value == keyValuePair.Key);
                if (existingKeyValue.Key != null)
                {
                    this.updatedThing[existingKeyValue.Key] = keyValuePair.Value;
                }
                else
                {
                    this.updatedThing.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

            foreach (var thing in subTransaction.DeletedThing)
            {
                this.deletedThing.Add(thing);
            }
        }

        /// <summary>
        /// Registers all contained <see cref="Thing"/> for a created <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> 
        /// to register along its contained thing
        /// </param>
        /// <param name="newId">
        /// Indicates whether the contained <see cref="Thing"/>s to be created should have a new ID
        /// </param>
        private void RegisterContainedThings(Thing thing, bool newId)
        {
            foreach (var containerList in thing.ContainerLists)
            {
                foreach (Thing containedThing in containerList)
                {
                    if (newId)
                    {
                        containedThing.Iid = Guid.NewGuid();
                    }

                    this.Create(containedThing);
                    this.RegisterContainedThings(containedThing, newId);
                }
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the creation of new <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateNewThingOperation(OperationContainer operationContainer)
        {
            foreach (var thing in this.AddedThing)
            {
                operationContainer.AddOperation(new Operation(null, thing.ToDto(), OperationKind.Create));
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the update of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">
        /// The returned <see cref="OperationContainer"/>
        /// </param>
        /// <remarks>
        /// this function makes use of the original <see cref="Thing"/> as it is stored in the cache, and the cloned <see cref="Thing"/> to populate
        /// the Update <see cref="Operation"/>. When the revision of the original <see cref="Thing"/> is higher than the revision of the cloned <see cref="Thing"/>, this
        /// means that the original <see cref="Thing"/> has been updated by a roundtip to the data-source while the current <see cref="ThingTransaction"/> was open.
        /// In this case the corresponding version of the 
        /// </remarks>
        private void CreateUpdatedThingOperation(OperationContainer operationContainer)
        {
            foreach (var keyValue in this.UpdatedThing)
            {
                Thing originalThing;

                // keyValue.Value - the clone that has been updated in the context of the transaction
                // keyValue.Key   - the original that is present in the cache

                if (keyValue.Value.RevisionNumber < keyValue.Key.RevisionNumber)
                {
                    this.logger.LogTrace("A newer revision {0} than the expected {1} of {2}:{3} exists in the Cache", keyValue.Key.RevisionNumber, keyValue.Value.RevisionNumber, keyValue.Key.ClassKind, keyValue.Key.Iid);

                    if (keyValue.Key.Revisions.TryGetValue(keyValue.Value.RevisionNumber, out originalThing))
                    {
                        this.logger.LogTrace("The matching revision {0} of {1}:{2} is used for the Update Operation", keyValue.Value.RevisionNumber, keyValue.Value.ClassKind, keyValue.Value.Iid);
                    }
                    else
                    {
                        this.logger.LogWarning("Revision {0} instead of revision {1} of {2}:{3} is used for the Update Operation", keyValue.Key.RevisionNumber, keyValue.Value.RevisionNumber, keyValue.Value.ClassKind, keyValue.Value.Iid);
                        originalThing = keyValue.Key;
                    }
                }
                else
                {
                    originalThing = keyValue.Key;
                }

                operationContainer.AddOperation(new Operation(originalThing.ToDto(), keyValue.Value.ToDto(), OperationKind.Update));
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the deletion of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateDeletedThingOperation(OperationContainer operationContainer)
        {
            foreach (var thing in this.DeletedThing)
            {
                var dto = thing.ToDto();
                operationContainer.AddOperation(new Operation(dto, dto, OperationKind.Delete));
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the copy of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateCopyThingOperation(OperationContainer operationContainer)
        {
            foreach (var pair in this.CopiedThing)
            {
                var originalCopy = pair.Key;
                var original = originalCopy.Item1.ToDto();
                var copy = originalCopy.Item2.ToDto();
                var copyOperationKind = pair.Value;

                if (copyOperationKind.IsCopyOperation())
                {
                    operationContainer.AddOperation(new Operation(original, copy, copyOperationKind));
                }                
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the moving of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateMoveThingOperation(OperationContainer operationContainer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the unique <see cref="TopContainer.RevisionNumber"/> of this Transaction
        /// </summary>
        /// <returns>The <see cref="TopContainer.RevisionNumber"/></returns>
        private int GetTopContainerRevisionNumber()
        {
            var things = new List<Thing>(this.AddedThing);
            things.AddRange(this.UpdatedThing.Keys);
            things.AddRange(this.DeletedThing);
            things.AddRange(this.CopiedThing.Select(x => x.Key.Item2));

            var distinctTopContainer = things.Select(x => x.TopContainer).DistinctBy(t => t.Iid).ToList();            
            if (distinctTopContainer.Count != 1)
            {
                throw new InvalidOperationException("multiple top container updates in one transaction, operation not allowed.");
            }

            return distinctTopContainer.Single().RevisionNumber;
        }

        /// <summary>
        /// Filter out update and added operations on <see cref="Thing"/>s contained by another <see cref="Thing"/> that is registered for delete
        /// </summary>
        private void FilterOperationCausedByDelete()
        {
            // filter out the added thing or updated thing that have been marked as deleted
            // filter out the contained thing of a deleted thing
            var markedForDeletion = this.DeletedThing.ToList();
            foreach (var thing in markedForDeletion)
            {
                var cloneType = thing.GetType();
                var containersInfo = cloneType.GetProperties().Where(x =>
                        x.PropertyType.QueryIsGenericType() &&
                        (x.PropertyType.GetGenericTypeDefinition() == typeof(ContainerList<>) ||
                        x.PropertyType.GetGenericTypeDefinition() == typeof(OrderedItemList<>)) &&
                         typeof(Thing).QueryIsAssignableFrom(x.PropertyType.GetGenericArguments().Single())).ToList();

                foreach (var containerInfo in containersInfo)
                {
                    var container = (IEnumerable)containerInfo.GetValue(thing);
                    foreach (Thing containedThing in container)
                    {
                        this.RemoveThingFromOperationLists(containedThing);
                    }
                }

                this.RemoveThingFromOperationLists(thing);
            }
        }

        /// <summary>
        /// Remove a <see cref="Thing"/> from the operation lists
        /// </summary>
        /// <param name="thingToRemove">The <see cref="Thing"/> to remove</param>
        private void RemoveThingFromOperationLists(Thing thingToRemove)
        {
            // remove it from the list of updated thing in the current transaction
            var updatedThingKey = this.UpdatedThing.Keys.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
            if (updatedThingKey != null)
            {
                this.updatedThing.Remove(updatedThingKey);
            }

            // remove from the list of added thing 
            var thingInAddedList = this.AddedThing.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
            if (thingInAddedList != null)
            {
                this.addedThing.Remove(thingInAddedList);
            }

            // remove the thing as deleted if it is not cached
            if (!thingToRemove.IsCached())
            {
                var thingInDeletedList = this.DeletedThing.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
                if (thingInDeletedList != null)
                {
                    this.deletedThing.Remove(thingInDeletedList);
                }
            }
        }
    }
}