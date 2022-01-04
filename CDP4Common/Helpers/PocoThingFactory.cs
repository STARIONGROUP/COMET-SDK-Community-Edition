// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PocoThingFactory.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;
    
    using NLog;

    /// <summary>
    /// Provides static method to instantiate and resolve the properties of all <see cref="Thing"/>s stored in a cache.
    /// Provides internal static helper methods to resolve the properties of a thing.
    /// </summary>
    public static class PocoThingFactory
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Resolve the POCO <see cref="Thing"/>'s properties using the assiciated DTO <see cref="DTO.Thing"/>'s properties
        /// </summary>
        /// <param name="dto">the associated DTO <see cref="DTO.Thing"/> that contains the data</param>
        /// <param name="poco">The <see cref="Thing"/></param>
        public static void ResolveDependencies(DTO.Thing dto, Thing poco)
        {
            poco.ResetSentinel();
            poco.ResolveProperties(dto);
        }

        /// <summary>
        /// Get the cached POCO <see cref="Thing"/>s  for the associated DTO <see cref="DTO.Thing"/>s and resolve their properties
        /// </summary>
        /// <param name="dtoThings">the associated DTO <see cref="DTO.Thing"/>s with the data</param>
        /// <param name="cache">the cache containing the <see cref="Thing"/>s</param>
        public static void ResolveDependencies(IEnumerable<DTO.Thing> dtoThings, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache)
        {
            foreach (var dtoThing in dtoThings)
            {
                var cacheKey = new CacheKey(dtoThing.Iid, dtoThing.IterationContainerId);

                if (cache.TryGetValue(cacheKey, out var associatedLazyPoco))
                {
                    var associatedPoco = associatedLazyPoco.Value;
                    ResolveDependencies(dtoThing, associatedPoco);
                }
            }
        }

        /// <summary>
        /// Resolve the <see cref="ContainerList{T}"/> from a <see cref="IEnumerable{Guid}"/> that represent the ids of the contained <see cref="Thing"/>s
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Thing"/></typeparam>
        /// <param name="list">The <see cref="ContainerList{T}"/> to resolve</param>
        /// <param name="guidList">The source <see cref="IEnumerable{Guid}"/></param>
        /// <param name="iterationId">The potential <see cref="Iteration"/> container id of the contained <see cref="Thing"/>s</param>
        /// <param name="cache">The cache that stores the <see cref="Thing"/>s</param>
        internal static void ResolveList<T>(this ContainerList<T> list, IEnumerable<Guid> guidList, Guid? iterationId, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache) where T : Thing
        {
            list.Clear();

            foreach (var guid in guidList)
            {
                if (cache.TryGet(guid, iterationId, out T thing))
                {
                    thing.ChangeKind = ChangeKind.None;
                    list.Add(thing);
                }
            }
        }

        /// <summary>
        /// Resolve the <see cref="OrderedItemList{T}"/> from a <see cref="IEnumerable{OrderedItem}"/> that shall represent an ordered list of <see cref="Guid"/>
        /// </summary>
        /// <typeparam name="T">A type of <see cref="Thing"/></typeparam>
        /// <param name="list">The ordered list to resolve</param>
        /// <param name="orderedItemList">The source <see cref="IEnumerable{OrderedItem}"/></param>
        /// <param name="iterationId">The potential <see cref="Iteration"/>'id at the top of the containment tree</param>
        /// <param name="cache">The cache that stores the <see cref="Thing"/>s</param>
        internal static void ResolveList<T>(this OrderedItemList<T> list, IEnumerable<OrderedItem> orderedItemList, Guid? iterationId, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache) where T : Thing
        {
            list.Clear();
            var orderedList = new List<OrderedItem>();

            foreach (var item in orderedItemList)
            {
                if (!Guid.TryParse(item.V.ToString(), out var guid))
                {
                    logger.Error("The ordered item does not represent a Thing.");
                    continue;
                }

                if (cache.TryGet(guid, iterationId, out T thing))
                {
                    var ordereditem = new OrderedItem {K = item.K, V = thing};
                    orderedList.Add(ordereditem);

                    if (list.IsComposite)
                    {
                        thing.ChangeKind = ChangeKind.None;
                    }
                }
            }

            list.AddOrderedItems(orderedList);
        }

        /// <summary>
        /// Resolve the <see cref="List{T}"/> from a <see cref="IEnumerable{Guid}"/>
        /// </summary>
        /// <typeparam name="T">A type of <see cref="Thing"/></typeparam>
        /// <param name="list">The <see cref="List{T}"/> to resolve</param>
        /// <param name="guidList">The <see cref="IEnumerable{Guid}"/> that contains the <see cref="Guid"/>s of the <see cref="Thing"/>s that shall be contained in <paramref name="list"/></param>
        /// <param name="iterationId">The <see cref="Iteration"/> <see cref="Guid"/> at the top of the containment tree</param>
        /// <param name="cache">The cache that stores the <see cref="Thing"/>s</param>
        internal static void ResolveList<T>(this List<T> list, IEnumerable<Guid> guidList, Guid? iterationId, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache) where T : Thing
        {
            list.Clear();

            foreach (var guid in guidList)
            {
                if (cache.TryGet(guid, iterationId, out T thing))
                {
                    list.Add(thing);
                }
            }
        }

        /// <summary>
        /// Clear and add the item of a source <see cref="IEnumerable{T}"/> to a <see cref="List{T}"/>
        /// </summary>
        /// <typeparam name="T">A type</typeparam>
        /// <param name="list">The <see cref="List{T}"/></param>
        /// <param name="sourceList">The source <see cref="IEnumerable{T}"/></param>
        internal static void ClearAndAddRange<T>(this List<T> list, IEnumerable<T> sourceList)
        {
            list.Clear();
            list.AddRange(sourceList);
        }

        /// <summary>
        /// Clear and add to the <see cref="OrderedItemList{T}"/> from a <see cref="IEnumerable{OrderedItem}"/>
        /// </summary>
        /// <typeparam name="T">The generic type of the <see cref="OrderedItemList{T}"/>. This should be a primitive type that matches the value of the <see cref="DTO.Thing"/>'s <see cref="IEnumerable{OrderedItem}"/></typeparam>
        /// <param name="list">The <see cref="OrderedItemList{T}"/> to resolve</param>
        /// <param name="orderedItemList">The source <see cref="IEnumerable{OrderedItem}"/></param>
        internal static void ClearAndAddRange<T>(this OrderedItemList<T> list, IEnumerable<OrderedItem> orderedItemList)
        {
            list.Clear();
            list.AddOrderedItems(orderedItemList);
        }
        
        /// <summary>
        /// Try to get the <see cref="Thing"/> of type <see cref="Thing"/> corresponding to the given <paramref name="itemIid"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Thing"/> to get</typeparam>
        /// <param name="cache">The cache that stores the <see cref="Thing"/>s</param>
        /// <param name="itemIid">The id of the <see cref="Thing"/> to retrieve</param>
        /// <param name="iterationId">The potential iteration id the item to retrieve is contained in</param>
        /// <param name="thing">The returned <see cref="Thing"/> of type <see cref="Thing"/></param>
        /// <returns>True if the operation succeeds</returns>
        internal static bool TryGet<T>(this ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Guid itemIid, Guid? iterationId, out T thing) where T : Thing
        {
            thing = cache.Get<T>(itemIid, iterationId);
            return thing != null;
        }

        /// <summary>
        /// Get the <see cref="Thing"/> of type <see cref="Thing"/> corresponding to the given <paramref name="itemIid"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Thing"/> to get</typeparam>
        /// <param name="cache">The cache that stores the <see cref="Thing"/>s</param>
        /// <param name="itemIid">The id of the <see cref="Thing"/> to retrieve</param>
        /// <param name="iterationId">The potential iteration id the item to retrieve is contained in</param>
        /// <returns>The <see cref="Thing"/> of type <see cref="Thing"/></returns>
        /// <remarks>
        /// A 2 steps approach is necessary to retrieve a thing 
        /// as in some cases it is not possible to know if the <see cref="Thing"/> is contained in an iteration or not.
        /// </remarks>
        internal static T Get<T>(this ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Guid itemIid, Guid? iterationId) where T : Thing
        {
            // try with the iteration id
            var key = new CacheKey(itemIid, iterationId);
            var thing = cache.Get<T>(key);

            if (thing != null)
            {
                return thing;
            }

            // try without iteration id
            if (iterationId != null)
            {
                key = new CacheKey(itemIid, null);
                thing = cache.Get<T>(key);

                if (thing != null)
                {
                    return thing;
                }
            }

            // Get the first one if any whatever the iterationId might be
            var firstKey = cache.Keys.FirstOrDefault(k => k.Thing == itemIid);

            if (firstKey.Thing != Guid.Empty && firstKey.Iteration != null)
            {
                return cache.Get<T>(firstKey);
            }

            logger.Debug("The {0} was not found in the cache: {1}", typeof(T).Name, key.Thing);
            return null;
        }

        /// <summary>
        /// Get the <see cref="Thing"/> of type <see cref="Thing"/> with the given <paramref name="key"/>
        /// </summary>
        /// <typeparam name="T">The type of <see cref="Thing"/></typeparam>
        /// <param name="cache">The cache that stores all the things</param>
        /// <param name="key">The key</param>
        /// <returns>The casted <see cref="Thing"/></returns>
        private static T Get<T>(this ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, CacheKey key) where T : Thing
        {
            var result = cache.TryGetValue(key, out var lazy);

            if (!result)
            {
                return null;
            }

            var thing = lazy.Value;

            if (!(thing is T))
            {
                logger.Error("The thing found in the cache with the key is not of the right type, cached id: {0}, {1}", thing.CacheKey.Thing, thing.CacheKey.Iteration);
                return null;
            }

            return (T)thing;
        }
    }
}