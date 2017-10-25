// -------------------------------------------------------------------------------------------------
// <copyright file="ThingTransaction.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common.Operations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Extensions;
    using CDP4Common.Helpers;
    using CDP4Common.MetaInfo;
    using CDP4Common.Polyfills;
    using CDP4Common.SiteDirectoryData;
    using CommonData;
    using Types;

    /// <summary>
    /// The Transaction class contains all requests for the creations, updates, deletions of things
    /// </summary>
    public class ThingTransaction : IThingTransaction
    {
        #region Fields
        
        /// <summary>
        /// The parent <see cref="ThingTransaction"/>
        /// </summary>
        private readonly ThingTransaction parentTransaction;

        /// <summary>
        /// The clone of the <see cref="Thing"/> associated with the current <see cref="ThingTransaction"/>
        /// </summary>
        private readonly Thing associatedClone;

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
        #endregion

        #region Constructors

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
        /// <remarks>
        /// In the context of sub-transactions, this constructor shall be used for the root-transaction
        /// </remarks>
        public ThingTransaction(TransactionContext transactionContext, Thing clone = null)
        {
            if (transactionContext == null)
            {
                throw new ArgumentNullException("transactionContext", "The transactionContext may not be null");
            }

            this.TransactionContext = transactionContext;
            
            this.addedThing = new List<Thing>();
            this.updatedThing = new Dictionary<Thing, Thing>();
            this.deletedThing = new List<Thing>();
            this.copiedThing = new Dictionary<Tuple<Thing, Thing>, OperationKind>();

            if (clone != null)
            {
                this.associatedClone = clone;
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
        /// The parent <see cref="ThingTransaction"/>
        /// </param>
        /// <param name="containerClone">
        /// The container <see cref="Thing"/> for the current added or updated operation
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
        public ThingTransaction(Thing clone, ThingTransaction parentTransaction, Thing containerClone)
        {
            if (clone == null)
            {
                throw new ArgumentNullException("clone", "The clone may not be null.");
            }
            
            this.TransactionContext = parentTransaction.TransactionContext;

            this.addedThing = new List<Thing>();
            this.updatedThing = new Dictionary<Thing, Thing>();
            this.deletedThing = new List<Thing>();
            this.associatedClone = clone;

            this.parentTransaction = parentTransaction;
            this.CreateOrUpdate(clone);

            if (this.parentTransaction != null)
            {
                this.InitializeSubTransaction(this, containerClone);
            }
            else
            {
                //TODO: figure out why this is unreacheable
                if (containerClone == null)
                {
                    throw new ArgumentNullException("containerClone", "The containerClone may not be null");
                }

                this.CreateOrUpdate(containerClone);
                this.UpdateContainer(clone, containerClone);
            }
        }
        #endregion

        #region Public properties

        public TransactionContext TransactionContext { get; private set; }

        /// <summary>
        /// Gets the Added <see cref="Thing"/>s
        /// </summary>
        public IEnumerable<Thing> AddedThing
        {
            get { return this.addedThing; }
        }

        /// <summary>
        /// Gets the deleted <see cref="Thing"/>s
        /// </summary>
        public IEnumerable<Thing> DeletedThing
        {
            get { return this.deletedThing; }
        }

        /// <summary>
        /// Gets the Updated <see cref="Thing"/>s where the Key is the original <see cref="Thing"/> and the value the cloned <see cref="Thing"/>
        /// </summary>
        public IReadOnlyDictionary<Thing, Thing> UpdatedThing
        {
            get { return this.updatedThing; }
        }

        /// <summary>
        /// Gets the copied <see cref="Thing"/>s
        /// </summary>
        public IReadOnlyDictionary<Tuple<Thing, Thing>, OperationKind> CopiedThing
        {
            get { return this.copiedThing; }
        }
        #endregion

        #region Public Methods

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
                throw new ArgumentNullException("clone", "The clone may not be null");
            }

            if (clone is TopContainer || clone is Iteration)
            {
                throw new InvalidOperationException("The creation of a TopContainer or an Iteration is not allowed.");
            }

            if (clone.Cache != null)
            {
                if (clone.Iid != Guid.Empty && clone.Cache.Any(x => Equals(x.Key, clone.CacheId)))
                {
                    throw new InvalidOperationException("The clone is an original thing present in the cache.");
                }
            }

            if (this.addedThing.Contains(clone))
            {
                return;
            }

            if (clone.Iid == Guid.Empty)
            {
                clone.Iid = Guid.NewGuid();
            }

            clone.ChangeKind = ChangeKind.Create;

            this.addedThing.Add(clone);

            if (this.parentTransaction == null && containerClone != null)
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
                throw new ArgumentNullException("clone", "The clone may not be null");
            }

            if(this.updatedThing.Values.Any(x => x == clone) || this.addedThing.Any(x => x == clone))
            {
                return;
            }

            if(this.updatedThing.Values.Any(x => x.Iid == clone.Iid) || this.addedThing.Any(x => x.Iid == clone.Iid))
            {
                return;
            }

            var updatedthing = this.GetUpdatedThing(clone);
            if(updatedthing != null)
            {
                if (clone.Iid == Guid.Empty)
                {
                    throw new ArgumentOutOfRangeException("clone", "The iid cannot be null.");
                }

                clone.ChangeKind = ChangeKind.Update;
                this.updatedThing.Add(updatedthing, clone);
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
                throw new ArgumentNullException("clone");
            }
            
            if (this.deletedThing.Any(x => x.Iid == clone.Iid))
            {
                return;
            }

            // Verify that a new clone is passed - reference check - only copy allowed
            var previousUpdatedReference = this.GetUpdatedThing(clone);

            if (previousUpdatedReference != null && clone is IDeprecatableThing)
            {
                throw new NotImplementedException("Delete of Deprecatable thing is not implemented.");
            }

            if (this.parentTransaction != null)
            {
                if (containerClone == null)
                {
                    throw new ArgumentNullException("containerClone",
                        "the clone of the container is mandatory in a dialog context.");
                }

                if (previousUpdatedReference != null)
                {
                    // remove potential reference from the list of updated thing in the current transaction
                    var updatedThingKey = this.updatedThing.Keys.SingleOrDefault(x => x.Iid == clone.Iid);
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
                    var thingInAddedList = this.addedThing.SingleOrDefault(x => x.Iid == clone.Iid);
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
                throw new ArgumentNullException("containerDestinationClone", "The containerDestinationClone may not be null");
            }

            this.Copy(clone, operationKind);
            this.AddCloneToContainer(clone, containerDestinationClone);
            this.CreateOrUpdate(containerDestinationClone);
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
                throw new ArgumentNullException("clone", "The clone may not be null");
            }

            if (!operationKind.IsCopyOperation())
            {
                throw new ArgumentException("The copy operation may only be performed with Copy or CopyDefaultValuesChangeOwner or CopyKeepValues or CopyKeepValuesChangeOwner", nameof(operationKind));
            }
            
            var original = this.GetUpdatedThing(clone);

            // setting a new iid for the copy
            clone.Iid = Guid.NewGuid();
            var originalCopyPair = new Tuple<Thing, Thing>(original, clone);

            if (this.copiedThing.ContainsKey(originalCopyPair))
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
                throw new ArgumentNullException("thing");
            }

            if (thing.Iid == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException("thing", "The iid cannot be null.");
            }

            var clone = this.updatedThing.Values.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            clone = this.addedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            return null;
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
                throw new ArgumentNullException("thing", "The thing may not be null");
            }

            if (thing.Iid == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException("thing", "The iid may not be the empty Guid.");
            }

            var allAddedThing = this.GetAllAddedThings().ToList();
            var clone = allAddedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            var allUpdatedThing = this.GetAllUpdatedThings().ToList();
            clone = allUpdatedThing.SingleOrDefault(x => x.Iid == thing.Iid);
            if (clone != null)
            {
                return clone;
            }

            return null;
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
            if (this.parentTransaction == null)
            {
                throw new InvalidOperationException("This method shall only be called on a sub-transaction.");
            }

            // also update thing of the same type as it may be that one of the container in the current sub-transaction was changed 
            // to a thing which is not in the normal "chain of operations".
            if (clone == null)
            {
                throw new ArgumentNullException("clone");
            }

            if (containerclone == null)
            {
                throw new ArgumentNullException("containerclone");
            }

            this.UpdateContainer(clone, containerclone, nextThing);

            // update the reference of possible other clones of the same type which were added when a contained item 
            // of the current associatedClone was updated to another one
            var rootClone = GetOperationRootClone();
            var cloneTypeToUpdate = this.associatedClone.GetContainerInformation().Item1;

            foreach (
                var addedthing in
                    this.addedThing.Where(
                        x => x != this.associatedClone && x.GetContainerInformation().Item1 == cloneTypeToUpdate))
            {
                if (!addedthing.IsContainedBy(rootClone.Iid))
                {
                    // no need to update the container as it cannot be accessed through the current chain of operations
                    continue;
                }

                // the clone should have been added
                var containerOfaddedthing = this.GetClone(addedthing.Container);
                if (containerOfaddedthing == null)
                {
                    throw new TransactionException("could not find the corresponding clone for the container of the added thing added outside the chain of transaction.");
                }

                this.UpdateContainer(addedthing, containerOfaddedthing);
            }

            foreach (
                var updatedthing in
                    this.updatedThing.Values.Where(
                        x => x != this.associatedClone && x.GetContainerInformation().Item1 == cloneTypeToUpdate))
            {
                if (!updatedthing.IsContainedBy(rootClone.Iid))
                {
                    // no need to update the container as it cannot be access through the current chain of operations
                    continue;
                }

                // the clone should have been added
                var containerOfupdatedthing = this.GetClone(updatedthing.Container);
                if (containerOfupdatedthing == null)
                {
                    throw new TransactionException(
                        "could not find the corresponding clone for the container of the updated thing added outside the chain of transaction.");
                }

                this.UpdateContainer(updatedthing, containerOfupdatedthing);
            }

            this.parentTransaction.Merge(this);
        }

        /// <summary>
        /// Finalizes all operations that happened during this <see cref="IThingTransaction"/>
        /// </summary>
        /// <returns>The <see cref="OperationContainer"/></returns>
        public OperationContainer FinalizeTransaction()
        {
            if (this.parentTransaction != null)
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
        #endregion

        #region Private Methods
        
        /// <summary>
        /// Get the last version of a specified <see cref="Thing"/> registered in the current chain of operations which <paramref name="clone"/> is an update of.
        /// </summary>
        /// <param name="clone">The new version of a <see cref="Thing"/></param>
        /// <returns>The last version of a <see cref="Thing"/> which <paramref name="clone"/> is an update of</returns>
        private Thing GetUpdatedThing(Thing clone)
        {
            // case1: the updated thing is already in the transaction as an updated thing
            var allUpdatedThings = this.GetAllUpdatedThings().ToList();

            var updatedthing = allUpdatedThings.SingleOrDefault(x => x.Iid == clone.Iid);
            if(updatedthing != null)
            {
                if (updatedthing == clone)
                {
                    throw new InvalidOperationException("The clone and its previous version cannot be the same.");
                }

                return updatedthing;
            }

            // case2: the updated thing is already in the transaction as an added thing
            var allAddedThings = this.GetAllAddedThings().ToList();
            updatedthing = allAddedThings.SingleOrDefault(x => x.Iid == clone.Iid);
            if (updatedthing != null)
            {
                if (updatedthing == clone)
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
            var lazy = clone.Cache.SingleOrDefault(x => Equals(x.Key, clone.CacheId)).Value;
            if (lazy == null)
            {
                return null;
            }

            // case4: the updated thing is the original
            updatedthing = lazy.Value;
            if (updatedthing == clone)
            {
                throw new InvalidOperationException("The transaction only accepts clones.");
            }

            return updatedthing;
        }

        /// <summary>
        /// Get all the added <see cref="Thing"/> in the current chain of transaction
        /// </summary>
        /// <returns>An enumeration of all the added things</returns>
        private IEnumerable<Thing> GetAllAddedThings()
        {
            var allAddedThing = this.addedThing.ToList();
            if (this.parentTransaction != null)
            {
                this.PopulateAllAddedThingsList(this.parentTransaction, allAddedThing);
            }

            return allAddedThing;
        }

        /// <summary>
        /// Populates the list of all the added things in a specified transaction
        /// </summary>
        /// <param name="transaction">The <see cref="ThingTransaction"/></param>
        /// <param name="allAddedThing">The list containing all the added things</param>
        private void PopulateAllAddedThingsList(ThingTransaction transaction, List<Thing> allAddedThing)
        {
            var thingsToAdd = transaction.addedThing.Where(x => allAddedThing.All(y => y.Iid != x.Iid));
            allAddedThing.AddRange(thingsToAdd);
            if (transaction.parentTransaction != null)
            {
                this.PopulateAllAddedThingsList(transaction.parentTransaction, allAddedThing);
            }
        }

        /// <summary>
        /// Get all the updated <see cref="Thing"/> in the current chain of transaction
        /// </summary>
        /// <returns>An enumeration of all the updated things</returns>
        private IEnumerable<Thing> GetAllUpdatedThings()
        {
            var allUpdatedThings = this.updatedThing.Values.ToList();
            if (this.parentTransaction != null)
            {
                this.PopulateAllUpdatedThingsList(this.parentTransaction, allUpdatedThings);
            }

            return allUpdatedThings;
        }

        /// <summary>
        /// Populates the list of all the updated things in a specified transaction
        /// </summary>
        /// <param name="transaction">The specified <see cref="ThingTransaction"/></param>
        /// <param name="allUpdatedThing">The list of all the updated things to populate</param>
        private void PopulateAllUpdatedThingsList(ThingTransaction transaction, List<Thing> allUpdatedThing)
        {
            var thingsToAdd = transaction.updatedThing.Values.Where(x => allUpdatedThing.All(y => y.Iid != x.Iid));
            allUpdatedThing.AddRange(thingsToAdd);
            if (transaction.parentTransaction != null)
            {
                this.PopulateAllUpdatedThingsList(transaction.parentTransaction, allUpdatedThing);
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

                var index = (int)findIndexMethod.Invoke(containerList, new object[] { predicate });
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
            var containers = this.addedThing.Concat(this.updatedThing.Values);
            
            var thingType = thing.GetType();

            Thing originalThing = null;
            if (thing.Cache != null && thing.Cache.ContainsKey(thing.CacheId))
            {
                Lazy<Thing> lazyThing;
                var result = thing.Cache.TryGetValue(thing.CacheId, out lazyThing);
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
        /// Initialize a <see cref="ThingTransaction"/> from its parent transaction
        /// </summary>
        /// <param name="subTransaction">The <see cref="ThingTransaction"/> to initialize</param>
        /// <param name="containerClone">The <see cref="Thing"/> that is supposed to contain the <see cref="associatedClone"/>. May be null at initialization</param>
        private void InitializeSubTransaction(ThingTransaction subTransaction, Thing containerClone)
        {
            var containerType = this.associatedClone.GetContainerInformation().Item1;

            if (containerClone != null)
            {
                var currentContainertype = containerClone.GetType();
                if (!containerType.QueryIsAssignableFrom(currentContainertype))
                {
                    throw new InvalidOperationException("The specified container is not allowed as a container.");
                }

                if (this.parentTransaction.addedThing.Contains(containerClone))
                {
                    subTransaction.addedThing.Add(containerClone);
                }
                else if (this.parentTransaction.updatedThing.Values.Contains(containerClone))
                {
                    var keyvalue = this.parentTransaction.updatedThing.Single(x => x.Value == containerClone);
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
                if (clone.IsContainedBy(transaction.associatedClone.Iid))
                {
                    continue;
                }

                // add a new clone if newContainerClone is not contained by the current operation's chain of clones
                var containerType = transaction.associatedClone.GetType();
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
            var rootClone = this.associatedClone;
            var parent = this.parentTransaction;
            while (parent != null)
            {
                rootClone = parent.associatedClone ?? rootClone;
                parent = parent.parentTransaction;
            }

            return rootClone;
        }

        /// <summary>
        /// Gets the chain of <see cref="ThingTransaction"/> for the current one
        /// </summary>
        /// <returns>The chain of <see cref="ThingTransaction"/></returns>
        private IEnumerable<ThingTransaction> GetChainOfSubTransactions()
        {
            var parent = this.parentTransaction;
            while (parent != null)
            {
                yield return parent;
                parent = parent.parentTransaction;
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
                throw new TransactionException(string.Format("The property {0} could not be found", containerInformation.Item2));
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
        private void Merge(IThingTransaction subTransaction)
        {
            // replace or add all element in addedThing
            foreach (var thing in subTransaction.AddedThing)
            {
                if (this.addedThing.Contains(thing))
                {
                    continue;
                }

                var existingThing = this.addedThing.SingleOrDefault(t => t.Iid == thing.Iid);
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
                if (this.updatedThing.ContainsKey(keyValuePair.Key))
                {
                    var parentKeyValue = this.updatedThing.Single(x => x.Key == keyValuePair.Key);
                    if (parentKeyValue.Value != keyValuePair.Value)
                    {
                        throw new InvalidOperationException("2 clones have been created for the same thing.");
                    }

                    continue;
                }

                // check if the key in a sub-transaction correspond to a value in the current one
                var existingKeyValue = this.updatedThing.SingleOrDefault(x => x.Value == keyValuePair.Key);
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
        #endregion

        #region Finalization operations
        /// <summary>
        /// Create the <see cref="Operation"/>s related to the creation of new <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateNewThingOperation(OperationContainer operationContainer)
        {
            foreach (var thing in this.addedThing)
            {
                operationContainer.AddOperation(new Operation(null, thing.ToDto(), OperationKind.Create));
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the update of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateUpdatedThingOperation(OperationContainer operationContainer)
        {
            foreach (var keyValue in this.updatedThing)
            {
                operationContainer.AddOperation(new Operation(keyValue.Key.ToDto(), keyValue.Value.ToDto(), OperationKind.Update));
            }
        }

        /// <summary>
        /// Create the <see cref="Operation"/>s related to the deletion of <see cref="Thing"/>s
        /// </summary>
        /// <param name="operationContainer">The returned <see cref="OperationContainer"/></param>
        private void CreateDeletedThingOperation(OperationContainer operationContainer)
        {
            foreach (var thing in this.deletedThing)
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
            foreach (var pair in this.copiedThing)
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
        private void CreateMovethingOperation(OperationContainer operationContainer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the unique <see cref="TopContainer.RevisionNumber"/> of this Transaction
        /// </summary>
        /// <returns>The <see cref="TopContainer.RevisionNumber"/></returns>
        private int GetTopContainerRevisionNumber()
        {
            var things = new List<Thing>(this.addedThing);
            things.AddRange(this.updatedThing.Keys);
            things.AddRange(this.deletedThing);

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
            var markedForDeletion = this.deletedThing.ToList();
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
            var updatedThingKey = this.updatedThing.Keys.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
            if (updatedThingKey != null)
            {
                this.updatedThing.Remove(updatedThingKey);
            }

            // remove from the list of added thing 
            var thingInAddedList = this.addedThing.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
            if (thingInAddedList != null)
            {
                this.addedThing.Remove(thingInAddedList);
            }

            // remove the thing as deleted if it is not cached
            if (!thingToRemove.IsCached())
            {
                var thingInDeletedList = this.deletedThing.SingleOrDefault(x => x.Iid == thingToRemove.Iid);
                if (thingInDeletedList != null)
                {
                    this.deletedThing.Remove(thingInDeletedList);
                }
            }
        }

        #endregion
    }
}