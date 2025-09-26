﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Assembler.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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
// --------------------------------------------------------------------------------------------------------------------
namespace CDP4Dal
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using Events;
    
    using NLog;

    using Dto = CDP4Common.DTO.Thing;

    /// <summary>
    /// The Assembler orchestrates the interaction with the IDAL and the related Cache
    /// </summary>
    public class Assembler
    {
        /// <summary>
        /// The <see cref="Uri"/> associated with this assembler
        /// </summary>
        public readonly Uri IDalUri;

        /// <summary>
        /// The <see cref="ICDPMessageBus"/> to use
        /// </summary>
        private readonly ICDPMessageBus messageBus;

        /// <summary>
        /// The current logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The lock object
        /// </summary>
        private SemaphoreSlim threadLock = new SemaphoreSlim(1);

        /// <summary>
        /// The unique <see cref="SiteDirectory"/>
        /// </summary>
        private SiteDirectory siteDirectory;

        /// <summary>
        /// The list of <see cref="Thing"/> marked for deletion
        /// </summary>
        private List<Thing> thingsMarkedForDeletion;

        /// <summary>
        /// The <see cref="List{Dto}"/> not completely resolved that are in the cache
        /// </summary>
        private List<Dto> unresolvedDtos;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assembler"/> class.
        /// </summary>
        /// <param name="uri">the <see cref="Uri"/> associated with this <see cref="Assembler"/></param>
        /// <param name="messageBus">
        /// The instance of <see cref="ICDPMessageBus"/>
        /// </param>
        public Assembler(Uri uri, ICDPMessageBus messageBus)
        {
            Utils.AssertNotNull(uri, "The Uri may not be mull");

            Utils.AssertNotNull(messageBus, "The MessageBus may not be mull");

            this.Cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();
            this.unresolvedDtos = new List<Dto>();
            this.IDalUri = uri;
            this.messageBus = messageBus;
        }

        /// <summary>
        /// Gets the Cache that contains all the <see cref="Thing"/>s
        /// </summary>
        public ConcurrentDictionary<CacheKey, Lazy<Thing>> Cache { get; private set; }

        /// <summary>
        /// Gets or sets the list of <see cref="CDP4Common.DTO.Thing"/> to update
        /// </summary>
        private List<CDP4Common.DTO.Thing> DtoThingToUpdate { get; set; }
        
        /// <summary>
        /// Synchronize the Cache give an IEnumerable of DTO <see cref="Thing"/>
        /// </summary>
        /// <param name="dtoThings">
        /// the DTOs
        /// </param>
        /// <param name="activeMessageBus">
        /// An optional value indicating whether the <see cref="ICDPMessageBus"/> should publish <see cref="ObjectChangedEvent"/> or not.
        /// The default value is true
        /// </param>
        /// <returns>
        /// The <see cref="Task"/> that can be awaited.
        /// </returns>
        public async Task Synchronize(IEnumerable<CDP4Common.DTO.Thing> dtoThings, bool activeMessageBus = true)
        {
            if (dtoThings == null)
            {
                throw new ArgumentNullException(nameof(dtoThings), $"The {nameof(dtoThings)} may not be null");
            }

            await this.threadLock.WaitAsync().ConfigureAwait(false);

            try
            {
                var synchronizeStopWatch = Stopwatch.StartNew();

                logger.Info("Start Synchronization of {0}", this.IDalUri);

                var existentGuid =
                    new Dictionary<CacheKey, int>(this.Cache.ToDictionary(x => x.Value.Value.CacheKey, y => y.Value.Value.RevisionNumber));

                this.CheckPartitionDependentContainmentContainerIds(dtoThings);

                this.UpdateThingRevisions(dtoThings, out var uncachedOrUpdatedOrNewerThingRevisions);

                this.thingsMarkedForDeletion = new List<Thing>();

                logger.Trace("Starting Clean-up Unused references");
                var startwatch = Stopwatch.StartNew();

                this.DtoThingToUpdate = dtoThings.ToList();

                // Add the unresolved thing to the things to resolved in case it is possible to fully resolve them with the current update
                // an example would be Citation contained by SiteDirectory where its Source is contained by a Rdl that is not loaded yet
                var unresolvedThingToUpdate = this.unresolvedDtos.Where(x => !this.DtoThingToUpdate.Select(y => y.Iid).Contains(x.Iid));
                this.DtoThingToUpdate.AddRange(unresolvedThingToUpdate);
                this.unresolvedDtos.Clear();

                if (!this.Cache.IsEmpty)
                {
                    // marks things for deletion
                    this.ComputeThingsToRemoveInUpdatedThings();
                    startwatch.Stop();
                    logger.Trace("Clean up Unused references took {0} [ms]", startwatch.ElapsedMilliseconds);
                }

                logger.Trace("Start Updating cache");
                startwatch = Stopwatch.StartNew();
                this.AddOrUpdateTheCache(uncachedOrUpdatedOrNewerThingRevisions);
                startwatch.Stop();
                logger.Trace("Updating cache took {0} [ms]", startwatch.ElapsedMilliseconds);

                logger.Trace("Start Resolving properties");
                startwatch = Stopwatch.StartNew();
                PocoThingFactory.ResolveDependencies(uncachedOrUpdatedOrNewerThingRevisions, this.Cache);
                startwatch.Stop();
                logger.Trace("Resolving properties took {0} [ms]", startwatch.ElapsedMilliseconds);

                // validate POCO's
                logger.Trace("Start validating Things");
                startwatch = Stopwatch.StartNew();
                foreach (var dtoThing in this.DtoThingToUpdate)
                {
                    var cacheKey = new CacheKey(dtoThing.Iid, dtoThing.IterationContainerId);
                    var succeed = this.Cache.TryGetValue(cacheKey, out var updatedLazyThing);

                    if (succeed)
                    {
                        var thingObject = updatedLazyThing.Value;                     
                        thingObject.ValidatePoco();

                        // add to the list of unresolved dtos if there is an error
                        if (thingObject.ValidationErrors.Any())
                        {
                            this.unresolvedDtos.Add(dtoThing);
                        }
                    }
                }
                
                startwatch.Stop();
                logger.Trace("Validating {0} Things took {1} [ms]", this.DtoThingToUpdate.Count, startwatch.ElapsedMilliseconds);

                // message added and updated POCO's
                if (activeMessageBus)
                {
                    logger.Trace("Start Messaging");
                    startwatch = Stopwatch.StartNew();

                    var messageCounter = 0;

                    foreach (var dtoThing in uncachedOrUpdatedOrNewerThingRevisions)
                    {
                        var cacheKey = new CacheKey(dtoThing.Iid, dtoThing.IterationContainerId);
                        var succeed = this.Cache.TryGetValue(cacheKey, out var updatedLazyThing);
                        
                        if (succeed)
                        {
                            var thingObject = updatedLazyThing.Value;
                            
                            if (!existentGuid.TryGetValue(cacheKey, out var cacheThingRevisionNumber))
                            {
                                this.messageBus.SendObjectChangeEvent(thingObject, EventKind.Added);
                                messageCounter++;
                            }
                            else
                            {
                                if (dtoThing.RevisionNumber > cacheThingRevisionNumber)
                                {
                                    // send event if revision number has increased from the old cached version
                                    this.messageBus.SendObjectChangeEvent(thingObject, EventKind.Updated);
                                    messageCounter++;
                                }
                                else if (dtoThing.RevisionNumber < cacheThingRevisionNumber)
                                {
                                    if (this.Cache.TryGetValue(cacheKey, out var cacheThing))
                                    {
                                        // send event if revision number is lower. That means that the original cached item was changed (revision was added!)                                        ICDPMessageBus.Current.SendObjectChangeEvent(cacheThing.Value, EventKind.Updated);
                                        this.messageBus.SendObjectChangeEvent(cacheThing.Value, EventKind.Updated);
                                        messageCounter++;
                                    }
                                }
                            }
                        }
                    }

                    startwatch.Stop();
                    logger.Trace("Messaging {0} Things took {1} [ms]", messageCounter, startwatch.ElapsedMilliseconds);
                }

                logger.Trace("Start Deleting things");
                startwatch = Stopwatch.StartNew();

                foreach (var markedThing in this.thingsMarkedForDeletion.Where(x => x.ChangeKind == ChangeKind.Delete))
                {
                    this.RemoveThingFromCache(markedThing);
                }
                
                var deletedIterationSetups = this.DtoThingToUpdate.OfType<CDP4Common.DTO.IterationSetup>().Where(x => x.IsDeleted).ToList();
                var deletedModelSetups = this.thingsMarkedForDeletion.OfType<EngineeringModelSetup>().ToList();
                this.thingsMarkedForDeletion.Clear();

                if (deletedIterationSetups.Any())
                {
                    foreach (var deletedIterationSetup in deletedIterationSetups)
                    {
                        this.MarkAndDelete(deletedIterationSetup.IterationIid);
                    }
                }

                if (deletedModelSetups.Any())
                {
                    foreach (var deletedModelSetup in deletedModelSetups)
                    {
                        this.MarkAndDelete(deletedModelSetup.EngineeringModelIid);
                    }
                }

                startwatch.Stop();
                logger.Trace("Deleting things took {0} [ms]", startwatch.ElapsedMilliseconds);

                this.DtoThingToUpdate.Clear();
                
                if (this.siteDirectory == null)
                {
                    var keyvaluepair = this.Cache.Single(item => item.Value.Value.ClassKind == ClassKind.SiteDirectory);
                    this.siteDirectory = (SiteDirectory)keyvaluepair.Value.Value;
                }

                logger.Info("Finish Synchronization of {0} in {1} [ms]", this.IDalUri, synchronizeStopWatch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                logger.Error(e);
            }
            finally
            {
                this.threadLock.Release();
                logger.Trace("Assembler thread released");
            }
        }
        
        /// <summary>
        /// For each DTO that is coming from the data-source, create a clone of the associated cached POCO
        /// and store this clone in the <see cref="Thing.Revisions"/> dictionary if it is a newer revision.
        /// For older revisions, store the revision in the cached POCO's <see cref="Thing.Revisions"/> property'
        /// </summary>
        /// <param name="dtoThings">
        /// the DTO's coming from the data-source
        /// </param>
        /// <param name="uncachedOrUpdatedOrNewThingRevisions">A list that contains <see cref="CDP4Common.DTO.Thing"/>s that are </param>
        /// <remarks>
        /// If the revision of the DTO is smaller that the revision of the the cached POCO, it is a DTO that represents
        /// the state of a DTO from the past. It will be added to the cached POCO's <see cref="Thing.Revisions"/> property
        /// </remarks>
        private void UpdateThingRevisions(IEnumerable<CDP4Common.DTO.Thing> dtoThings, out IList<CDP4Common.DTO.Thing> uncachedOrUpdatedOrNewThingRevisions)
        {
            // create and store a shallow clone of the a current cached Thing
            var revisionCloneWatch = Stopwatch.StartNew();
            uncachedOrUpdatedOrNewThingRevisions= new List<CDP4Common.DTO.Thing>(dtoThings);

            foreach (var dto in dtoThings)
            {
                var cacheKey = new CacheKey(dto.Iid, dto.IterationContainerId);

                if (this.Cache.TryGetValue(cacheKey, out var currentCachedThing))
                {
                    var currentThing = currentCachedThing.Value;

                    if (dto.RevisionNumber > currentThing.RevisionNumber)
                    {
                        if (!currentThing.Revisions.ContainsKey(currentThing.RevisionNumber))
                        {
                            currentThing.Revisions.Add(currentThing.RevisionNumber, currentThing.Clone(false));
                            logger.Trace("Revision {0} added to Revisions of {1}:{2}", currentThing.RevisionNumber, currentThing.ClassKind, currentThing.Iid);
                        }
                        else
                        {
                            logger.Trace("Revision {0} of Thing {1}:{2} already exists in the Thing.Revisions cache", currentThing.RevisionNumber, currentThing.ClassKind, currentThing.Iid);
                        }

                        continue;
                    }

                    if (dto.RevisionNumber == currentThing.RevisionNumber)
                    {
                        logger.Trace("A DTO with revision {0} equal to the revision of the existing POCO {1}:{2}:{3} has been identified; The data-source has sent a revision of an object that is already present in the cache", 
                            dto.RevisionNumber, currentThing.ClassKind, currentThing.CacheKey.Thing, currentThing.CacheKey.Iteration);

                        continue;
                    }

                    if (dto.RevisionNumber < currentThing.RevisionNumber)
                    {
                        uncachedOrUpdatedOrNewThingRevisions.Remove(dto);
                        //Add the found DTO to the currentThing's Revisions property
                        var poco = dto.InstantiatePoco(this.Cache, this.IDalUri);
                        PocoThingFactory.ResolveDependencies(dto, poco);

                        if (!currentThing.Revisions.ContainsKey(dto.RevisionNumber))
                        {
                            currentThing.Revisions.Add(dto.RevisionNumber, poco);
                            logger.Trace("Revision {0} added to Revisions of {1}:{2}", dto.RevisionNumber, currentThing.ClassKind, currentThing.Iid);
                        }
                        else
                        {
                            logger.Trace("Revision {0} of Thing {1}:{2} already exists in the Thing.Revisions cache", currentThing.RevisionNumber, currentThing.ClassKind, currentThing.Iid);
                        }
                    }
                }
            }

            logger.Info("Updating Thing.Revisions took {0} [ms]", revisionCloneWatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Clears the cache and sends removed event for the following classes:
        /// <see cref="EngineeringModel"/>, <see cref="EngineeringModelSetup"/>, <see cref="Iteration"/>, <see cref="IterationSetup"/>
        /// </summary>
        /// <returns>The <see cref="Task"/></returns>
        public async Task Clear()
        {
            await this.threadLock.WaitAsync().ConfigureAwait(false);
            try
            {
                var iterations =
                    this.Cache.Select(x => x.Value)
                        .Where(lazy => lazy.Value.ClassKind == ClassKind.Iteration)
                        .Select(lazy => lazy.Value)
                        .Cast<Iteration>();

                foreach (var iteration in iterations)
                {
                    if (iteration.IterationSetup != null)
                    {
                        this.messageBus.SendObjectChangeEvent(iteration.IterationSetup, EventKind.Removed);
                        logger.Trace("IterationSetup with iid {0} removed", iteration.IterationSetup.Iid);
                    }

                    this.messageBus.SendObjectChangeEvent(iteration, EventKind.Removed);
                    logger.Trace("Iteration with iid {0} removed", iteration.Iid);
                }

                var models =
                    this.Cache.Select(x => x.Value)
                        .Where(lazy => lazy.Value.ClassKind == ClassKind.EngineeringModel)
                        .Select(lazy => lazy.Value)
                        .Cast<EngineeringModel>();

                foreach (var model in models)
                {
                    if (model.EngineeringModelSetup != null)
                    {
                        this.messageBus.SendObjectChangeEvent(model.EngineeringModelSetup, EventKind.Removed);
                        logger.Trace("EngineeringModelSetup with iid {0} removed", model.EngineeringModelSetup.Iid);
                    }

                    this.messageBus.SendObjectChangeEvent(model, EventKind.Removed);
                    logger.Trace("Model with iid {0} removed", model.Iid);
                }

                this.siteDirectory = null;
                this.Cache.Clear();
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            finally
            {
                this.threadLock.Release();
            }
        }

        /// <summary>
        /// Close a <see cref="ReferenceDataLibrary"/> by clearing all its contained elements
        /// </summary>
        /// <param name="rdl">The <see cref="ReferenceDataLibrary"/> to close</param>
        /// <returns>The async <see cref="Task"/></returns>
        public async Task CloseRdl(ReferenceDataLibrary rdl)
        {
            await this.threadLock.WaitAsync().ConfigureAwait(false);
            try
            {
                var startwatch = Stopwatch.StartNew();
                this.thingsMarkedForDeletion = new List<Thing>();
                foreach (var category in rdl.DefinedCategory)
                {
                    this.RecursivelyMarksForRemoval(category);
                }

                foreach (var parameterType in rdl.ParameterType)
                {
                    this.RecursivelyMarksForRemoval(parameterType);
                }

                foreach (var measurementScale in rdl.Scale)
                {
                    this.RecursivelyMarksForRemoval(measurementScale);
                }

                foreach (var unitPrefix in rdl.UnitPrefix)
                {
                    this.RecursivelyMarksForRemoval(unitPrefix);
                }

                foreach (var measurementUnit in rdl.Unit)
                {
                    this.RecursivelyMarksForRemoval(measurementUnit);
                }

                foreach (var filetype in rdl.FileType)
                {
                    this.RecursivelyMarksForRemoval(filetype);
                }

                foreach (var glossary in rdl.Glossary)
                {
                    this.RecursivelyMarksForRemoval(glossary);
                }

                foreach (var referenceSource in rdl.ReferenceSource)
                {
                    this.RecursivelyMarksForRemoval(referenceSource);
                }

                foreach (var rule in rdl.Rule)
                {
                    this.RecursivelyMarksForRemoval(rule);
                }

                foreach (var constant in rdl.Constant)
                {
                    this.RecursivelyMarksForRemoval(constant);
                }

                rdl.DefinedCategory.Clear();
                rdl.ParameterType.Clear();
                rdl.Scale.Clear();
                rdl.UnitPrefix.Clear();
                rdl.Unit.Clear();
                rdl.FileType.Clear();
                rdl.Glossary.Clear();
                rdl.ReferenceSource.Clear();
                rdl.Rule.Clear();
                rdl.Constant.Clear();
                rdl.BaseQuantityKind.Clear();
                rdl.BaseUnit.Clear();

                foreach (var thing in this.thingsMarkedForDeletion)
                {
                    this.RemoveThingFromCache(thing);
                }

                this.messageBus.SendObjectChangeEvent(rdl, EventKind.Updated);

                this.thingsMarkedForDeletion.Clear();
                logger.Trace("Finish closing of {0} ({1}) in {2} [ms]", rdl.Name, this.IDalUri, startwatch.ElapsedMilliseconds);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            finally
            {
                this.threadLock.Release();
            }
        }

        /// <summary>
        /// Close a <see cref="ReferenceDataLibrary"/> by clearing all its contained elements
        /// </summary>
        /// <param name="iterationSetup">
        /// The <see cref="IterationSetup"/> to close
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task CloseIterationSetup(IterationSetup iterationSetup)
        {
            await this.threadLock.WaitAsync().ConfigureAwait(false);
            try
            {
                Lazy<Thing> lazyIteration;
                var cacheKey = new CacheKey(iterationSetup.IterationIid, null);

                if (!this.Cache.TryGetValue(cacheKey, out lazyIteration))
                {
                    this.threadLock.Release();
                    return;
                }

                var iteration = lazyIteration.Value as Iteration;
                if (iteration == null)
                {
                    this.threadLock.Release();
                    return;
                }

                // Delete from the cache all things contained by the iteration without blocking the UI
                await this.ClearFromCacheThingsContainedByIteration(iteration);
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            finally
            {
                this.threadLock.Release();
            }
        }

        /// <summary>
        /// Clear from cache things contained by iteration.
        /// </summary>
        /// <param name="iteration">
        /// The iteration.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        private async Task ClearFromCacheThingsContainedByIteration(Iteration iteration)
        {
            var startwatch = Stopwatch.StartNew();

            this.thingsMarkedForDeletion = new List<Thing>();
            this.RecursivelyMarksForRemoval(iteration);
            foreach (var thing in this.thingsMarkedForDeletion)
            {
                this.RemoveThingFromCache(thing);
            }

            this.thingsMarkedForDeletion.Clear();
            logger.Trace("Finish closing iteration {0} ({1}) in {2} [ms]", iteration.Iid, this.IDalUri, startwatch.ElapsedMilliseconds);
        }

        /// <summary>
        /// Retrieves the single <see cref="SiteDirectory"/> of this <see cref="Assembler"/>
        /// </summary>
        /// <returns>The <see cref="SiteDirectory"/></returns>
        public SiteDirectory RetrieveSiteDirectory()
        {
            return this.siteDirectory;
        }
        
        /// <summary>
        /// Checks the status of the updated <see cref="Dto"/>s in the Cache
        /// </summary>
        private void ComputeThingsToRemoveInUpdatedThings()
        {
            foreach (var dtoThing in this.DtoThingToUpdate)
            {
                this.ComputeThingsToRemove(dtoThing);
            }
        }

        /// <summary>
        /// Removes <see cref="Thing"/>s part of a composition with the <see cref="Thing"/> associated to the <see cref="CDP4Common.DTO.Thing"/> if the references are no longer in the updated <see cref="CDP4Common.DTO.Thing"/>
        /// </summary>
        /// <param name="dtoThing">the <see cref="CDP4Common.DTO.Thing"/> to check</param>
        private void ComputeThingsToRemove(Dto dtoThing)
        {
            Lazy<Thing> cachedLazyThing;
            var cacheKey = new CacheKey(dtoThing.Iid, dtoThing.IterationContainerId);
            if (!this.Cache.TryGetValue(cacheKey, out cachedLazyThing))
            {
                return;
            }

            var dtoContainedGuid = this.ComputeContainedGuid(dtoThing);
            var pocoContainedThing = this.ComputeContainedThing(cachedLazyThing.Value);

            var thingsToRemove = pocoContainedThing.Where(poco => !dtoContainedGuid.Contains(poco.Iid)).ToList();
            foreach (var thing in thingsToRemove)
            {
                // isPersistent
                this.RecursivelyMarksForRemoval(thing);
            }
        }

        /// <summary>
        /// Get the non-persistent property type in a <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/></param>
        /// <returns>An <see cref="List{Type}"/> containing the type of <see cref="Thing"/>s that are not persistent in the <paramref name="thing"/></returns>
        private List<Type> ComputeNonPersistentPropertyType(Thing thing)
        {
            var nonPersistentType = new List<Type>();

            var propInfos = thing.GetType().GetProperties();
            foreach (var propertyInfo in propInfos)
            {
                if(!propertyInfo.IsDefined(typeof(UmlInformationAttribute)))
                {
                    continue;
                }

                var metadata = propertyInfo.GetCustomAttribute<UmlInformationAttribute>();
                if (metadata.Aggregation == AggregationKind.Composite && !metadata.IsPersistent)
                {
                    nonPersistentType.Add(propertyInfo.PropertyType.GetGenericArguments().Single());
                }
            }

            return nonPersistentType;
        }

        /// <summary>
        /// Compute the contained <see cref="Guid"/> for a <see cref="Dto"/>
        /// </summary>
        /// <param name="dto">The <see cref="Dto"/> to compute</param>
        /// <returns>An <see cref="List{Guid}"/> containing all the contained <see cref="Guid"/></returns>
        private List<Guid> ComputeContainedGuid(Dto dto)
        {
            var containedGuid = new List<Guid>();
            foreach (var container in dto.ContainerLists)
            {
                foreach (var obj in container)
                {
                    var orderedItem = obj as OrderedItem;
                    if (orderedItem != null)
                    {
                        containedGuid.Add(new Guid(orderedItem.V.ToString()));
                    }
                    else
                    {
                        containedGuid.Add((Guid)obj);
                    }
                }
            }

            return containedGuid;
        }

        /// <summary>
        /// Compute the contained <see cref="Thing"/> for a <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to compute</param>
        /// <returns>An <see cref="List{Thing}"/> containing all the contained <see cref="Thing"/></returns>
        private List<Thing> ComputeContainedThing(Thing thing)
        {
            var containedGuid = new List<Thing>();
            var nonPersistentType = this.ComputeNonPersistentPropertyType(thing);

            foreach (var container in thing.ContainerLists)
            {
                var type = container.GetType();
                var genericType = type.GetGenericArguments().Single();
                if (nonPersistentType.Contains(genericType))
                {
                    // non-persistent things are not added
                    continue;
                }

                containedGuid.AddRange(from Thing containedThing in container select containedThing);
            }

            return containedGuid;
        }

        /// <summary>
        /// Recursively marks a <see cref="Thing"/> for removal and all its contained <see cref="Thing"/>
        /// </summary>
        /// <param name="thingToRemove">the <see cref="Thing"/> to remove</param>
        private void RecursivelyMarksForRemoval(Thing thingToRemove)
        {
            foreach (var containerList in thingToRemove.ContainerLists)
            {
                foreach (Thing thing in containerList)
                {
                    this.RecursivelyMarksForRemoval(thing);
                }
            }

            // marks thing for deletion
            thingToRemove.ChangeKind = ChangeKind.Delete;
            this.thingsMarkedForDeletion.Add(thingToRemove);
        }

        /// <summary>
        /// Remove a <see cref="Thing"/> from the cache
        /// </summary>
        /// <param name="thingToRemove">The <see cref="Thing"/> to remove</param>
        /// <returns>True if the operation succeeded</returns>
        private bool RemoveThingFromCache(Thing thingToRemove)
        {
            var succeed = this.Cache.TryRemove(thingToRemove.CacheKey, out var outLazy);
            if (succeed)
            {
                if (outLazy.Value is Relationship relationship)
                {
                    relationship.CleanReferencedThingRelationship();
                }

                this.messageBus.SendObjectChangeEvent(outLazy.Value, EventKind.Removed);
            }

            logger.Trace("Remove of thing with Iid {0} succeeded : {1}", thingToRemove, succeed);
            return succeed;
        }

        /// <summary>
        /// Add/Update a set of {key, value} in the cache with POCO which referenced properties have not been resolved yet
        /// </summary>
        /// <param name="dtoThings">the DTO <see cref="Thing"/> with data</param>
        private void AddOrUpdateTheCache(IEnumerable<CDP4Common.DTO.Thing> dtoThings)
        {
            var dtolist = dtoThings.ToList();

            foreach (var dto in dtolist)
            {
                if (dto.Iid == Guid.Empty)
                {
                    throw new ArgumentException($"Cannot add DTO with a Guid.Empty reference to the Cache: {dto.ClassKind}");
                }

                var cacheKey = new CacheKey(dto.Iid, dto.IterationContainerId);

                this.Cache.AddOrUpdate(cacheKey, new Lazy<Thing>(() => dto.InstantiatePoco(this.Cache, this.IDalUri)), (key, oldValue) => oldValue);
            }
        }

        /// <summary>
        /// Delete all <see cref="Thing"/>s contained the <see cref="Thing"/> with the given <see cref="Guid"/>
        /// </summary>
        /// <param name="guid">The <see cref="Guid"/></param>
        /// <remarks>
        /// This is used to delete <see cref="Iteration"/> and <see cref="EngineeringModel"/> when thei respective setup was deleted
        /// </remarks>
        private void MarkAndDelete(Guid guid)
        {
            Lazy<Thing> lazy;
            if (this.Cache.TryGetValue(new CacheKey(guid, null), out lazy))
            {
                this.thingsMarkedForDeletion.Clear();
                this.RecursivelyMarksForRemoval(lazy.Value);
                foreach (var markedThing in this.thingsMarkedForDeletion)
                {
                    this.RemoveThingFromCache(markedThing);
                }

                this.thingsMarkedForDeletion.Clear();
            }
        }

        /// <summary>
        /// Checks <see cref="Dto.IterationContainerId"/> property for ClassKinds mentioned in <see cref="PartitionDependentContainmentClassType"/>.
        /// </summary>
        /// <param name="dtoThings">
        /// the DTO's coming from the data-source
        /// </param>
        /// <remarks>
        /// This is part of a temporary solution of dealing with <see cref="Folder"/>, <see cref="File"/> and <see cref="FileRevision"/> <see cref="Dto"/>s.
        /// </remarks>
        private void CheckPartitionDependentContainmentContainerIds(IEnumerable<Dto> dtoThings)
        {
            var dtoList = dtoThings.ToList();
            var checkDtos = dtoList.Where(x => PartitionDependentContainmentClassType.EngineeringModelAndIterationClassKindArray.Contains(x.ClassKind));

            foreach (var dto in checkDtos)
            {
                if (dto.IterationContainerId != null)
                {
                    switch (dto.ClassKind)
                    {
                        case ClassKind.Folder:
                            this.CheckIterationContainerIdForCommonFileStoreRelatedDto(dto, dtoList);
                            break;
                        case ClassKind.File:
                            this.CheckIterationContainerIdForCommonFileStoreRelatedDto(dto, dtoList);
                            break;
                        case ClassKind.FileRevision:
                            this.CheckIterationContainerIdForCommonFileStoreRelatedDto(dto, dtoList);
                            break;
                        default:
                            throw new ArgumentException($"Unsupported PartitionDependentContainmentClassType found: {dto.ClassKind}");
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a <see cref="Dto"/> exists within a CommonFileStore.
        /// It uses data from <see cref="Dto"/>s coming from the data-source, or from the Cache.
        /// </summary>
        /// <param name="dto">The <see cref="CommonFileStore"/> related <see cref="Dto"/></param>
        /// <param name="dtoThings">List of all <see cref="Dto"/>s coming from the data-source</param>
        /// <remarks>
        /// This is part of a temporary solution of dealing with <see cref="Folder"/>, <see cref="File"/> and <see cref="FileRevision"/> <see cref="Dto"/>s.
        /// </remarks>
        private void CheckIterationContainerIdForCommonFileStoreRelatedDto(Dto dto, IReadOnlyList<Dto> dtoThings)
        {
            if (dto.IterationContainerId == null)
            {
                return;
            }

            var findDtoIid = dto.Iid;

            if (dto is CDP4Common.DTO.FileRevision revision)
            {
                if (!this.TryGetFileIid(revision, dtoThings, out findDtoIid))
                {
                    return;
                }
            }

            if (dtoThings.Where(x => x.ClassKind == ClassKind.CommonFileStore)
                .Cast<CDP4Common.DTO.CommonFileStore>()
                .Any(x => x.Folder.Any(y => y == findDtoIid) || x.File.Any(y => y == findDtoIid)))
            {
                dto.IterationContainerId = null;
            }
            else if (this.Cache.Values.Where(x => x.Value.ClassKind == ClassKind.CommonFileStore)
                .Select(x => x.Value)
                .Cast<CommonFileStore>()
                .Any(x => x.Folder.Any(y => y.Iid == findDtoIid) || x.File.Any(y => y.Iid == findDtoIid)))
            {
                dto.IterationContainerId = null;
            }
        }

        /// <summary>
        /// Finds the <see cref="CDP4Common.DTO.File"/>'s Iid property from <see cref="Dto"/>s coming from the data-source, or from the Cache
        /// </summary>
        /// <param name="fileRevision">The <see cref="FileRevision"/></param>
        /// <param name="dtoThings">List of all &lt;see cref="Dto"/&gt;s coming from the data-source</param>
        /// <param name="guid">If found, this contains the <see cref="CDP4Common.DTO.File"/>'s Iid</param>
        /// <returns>True if found, otherwise false.</returns>
        /// <remarks>
        /// This is part of a temporary solution of dealing with <see cref="Folder"/>, <see cref="File"/> and <see cref="FileRevision"/> <see cref="Dto"/>s.
        /// </remarks>
        private bool TryGetFileIid(CDP4Common.DTO.FileRevision fileRevision, IReadOnlyList<Dto> dtoThings, out Guid guid)
        {
            guid = Guid.Empty;

            if (dtoThings.Where(x => x.ClassKind == ClassKind.File)
                    .Cast<CDP4Common.DTO.File>()
                    .SingleOrDefault(x => x.FileRevision.Any(y => y == fileRevision.Iid)) is CDP4Common.DTO.File file)
            {
                guid = file.Iid;
                return true;
            }

            if (this.Cache.Values.Where(x => x.Value.ClassKind == ClassKind.File)
                .Select(x => x.Value)
                .Cast<File>()
                .SingleOrDefault(x => x.FileRevision.Any(y => y.Iid == fileRevision.Iid)) is File cachedFile)
            {
                guid = cachedFile.Iid;
                return true;
            }

            return false;
        }
    }
}