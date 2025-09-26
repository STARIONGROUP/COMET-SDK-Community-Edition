﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedItemList.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Types
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using CDP4Common.CommonData;
    using CDP4Common.Exceptions;

    using NLog;

    /// <summary>
    /// A CDP4 Ordered List
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the items to sort</typeparam>
    public class OrderedItemList<T> : ICollection<T>
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The default key interval to be used for initial spacing between keys of adjacent items,
        /// </summary>
        private const long DefaultKeyInterval = 100000000L;

        /// <summary>
        /// Random number generator used by the <see cref="ComputeSortKey"/> method
        /// </summary>
        private readonly Random random;

        /// <summary>
        /// The underlying sorted list of items.
        /// </summary>
        private readonly SortedList<long, T> sortedItems;

        /// <summary>
        /// backing field for the container of this <see cref="OrderedItemList{T}"/>
        /// </summary>
        public Thing Container { get; private set; }

        /// <summary>
        /// A value indicating that this <see cref="OrderedItemList{T}"/> is a container
        /// </summary>
        public bool IsComposite { get; private set; }

        /// <summary>
        /// The highest sort key currently in this <see cref="OrderedItemList{T}"/>.
        /// </summary>
        private long highestKey = -DefaultKeyInterval;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedItemList{T}"/> class
        /// </summary>
        /// <param name="container">The <see cref="Thing"/> that contains this <see cref="OrderedItemList{T}"/></param>
        /// <param name="isComposite">Value indicating whether the <see cref="System.Type"/> in this <see cref="OrderedItemList{T}"/> are part of a composition relationship</param>
        public OrderedItemList(Thing container, bool isComposite = false)
        {
            this.Container = container;
            this.sortedItems = new SortedList<long, T>();
            this.random = new Random(Guid.NewGuid().GetHashCode());
            this.IsComposite = isComposite;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedItemList{T}"/> class
        /// </summary>
        /// <param name="orderedItemList">The <see cref="OrderedItemList{T}"/> which values are copied</param>
        /// <param name="container">The owner of this <see cref="OrderedItemList{T}"/></param>
        public OrderedItemList(OrderedItemList<T> orderedItemList, Thing container)
        {
            this.Container = container;
            this.sortedItems = new SortedList<long, T>(orderedItemList.SortedItems);
            this.random = new Random(Guid.NewGuid().GetHashCode());
            this.IsComposite = orderedItemList.IsComposite;

            if (this.sortedItems.Any())
            {
                this.highestKey = this.sortedItems.Keys.Max();
            }
        }

        /// <summary>
        /// Queries the 0-based index of the item in the order list
        /// </summary>
        /// <param name="item">
        /// The item which is queried
        /// </param>
        /// <returns>
        /// the index of the queried item. When the item is not contained by the list "-1" is returned
        /// </returns>
        public int IndexOf(T item)
        {
            if (!this.sortedItems.ContainsValue(item))
            {
                return -1;
            }

            return this.sortedItems.IndexOfValue(item);
        }

        /// <summary>
        /// Retrieve the index of the item that matches the <see cref="Predicate{T}"/>
        /// </summary>
        /// <param name="match">The <see cref="Predicate{T}"/></param>
        /// <returns>The index of the item if there is a match, else -1</returns>
        public int FindIndex(Predicate<T> match)
        {
            this.ValidateValueForNull(match, "A match cannot be null");

            foreach (T item in this)
            {
                if (match.Invoke(item))
                {
                    return this.IndexOf(item);
                }
            }

            return -1;
        }

        /// <summary>
        /// Gets the number of items that are contained in this <see cref="OrderedItemList{T}"/>.
        /// </summary>
        public int Count
        {
            get { return this.sortedItems.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether this collection is read only.
        /// </summary>
        public bool IsReadOnly
        {
            get { return this.sortedItems.Values.IsReadOnly; }
        }

        /// <summary>
        /// Gets the underlying <see cref="SortedList{TKey,TValue}"/> of items.
        /// </summary>
        public SortedList<long, T> SortedItems
        {
            get { return this.sortedItems; }
        }

        /// <summary>
        /// Gets or sets the value of the item associated with the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the item to get or set.
        /// </param>
        /// <returns>
        /// The value of the item with the specified index (getter).
        /// </returns>
        [IndexerName("Item")]
        public T this[int index]
        {
            get
            {
                this.ValidateIndex(index);
                return this.sortedItems.Values[index];
            }

            set
            {
                this.ValidateIndex(index);
                this.ValidateValueForNull(value);

                if (value as Thing != null && this.IsComposite)
                {
                    (value as Thing).Container = this.Container;
                }

                if (value as Thing != null)
                {
                    this.ValidateItemForExistence(value);
                }

                var sortKey = this.sortedItems.ElementAt(index).Key;
                this.sortedItems[sortKey] = value;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through this collection.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.sortedItems.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through this collection.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return this.sortedItems.Values.GetEnumerator();
        }

        /// <summary>
        /// Adds the specified item to the end of this list.
        /// </summary>
        /// <param name="item">
        /// The item to be added.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="item"/> is null.
        /// </exception>
        public void Add(T item)
        {
            this.ValidateValueForNull(item);

            if (item is Thing)
            {
                this.ValidateItemForExistence(item);
            }

            var pocoThing = item as Thing;
            if (pocoThing != null && this.IsComposite)
            {
                pocoThing.Container = this.Container;
            }

            var newSortKey = this.ComputeSortKey(this.highestKey, this.highestKey + (2L * DefaultKeyInterval));
            this.sortedItems.Add(newSortKey, item);
            this.highestKey = newSortKey;
        }

        /// <summary>
        /// Adds the specified items to the end of this list.
        /// </summary>
        /// <param name="itemsToAdd">the items to add</param>
        public void AddRange(IEnumerable<T> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Add the <see cref="IEnumerable{T}"/> of <see cref="OrderedItem"/> keeping the same keys
        /// </summary>
        /// <param name="itemsToAdd">the items to add</param>
        public void AddOrderedItems(IEnumerable<OrderedItem> itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                try
                {
                    if (item.V is T)
                    {
                        this.Add(item.K, (T)item.V);
                    }
                    else
                    {
                        // Try to convert
                        var value = item.V.ToString();
                        var converter = TypeDescriptor.GetConverter(typeof(T));
                        var convertedValue = (T)converter.ConvertFromInvariantString(value);
                        this.Add(item.K, convertedValue);
                    }
                }
                catch (ArgumentException aex)
                {
                    logger.Error($"{aex.Message}\n\n {aex.StackTrace}");
                    throw new ModelErrorException($"Adding a sortKey to an OrderedItemList failed. Probably due to duplicate keys.\n{aex.Message}\n\n {aex.StackTrace}", aex);
                }
                catch (Exception ex)
                {
                    logger.Error($"{ex.Message}\n\n {ex.StackTrace}");
                    throw new ModelErrorException($"Adding a sortKey to an OrderedItemList failed. \n{ex.Message}\n\n {ex.StackTrace}", ex);
                }
            }
        }

        /// <summary>
        /// Inserts the specified item into this ordered set at the specified integer index.
        /// </summary>
        /// <param name="index">
        /// The index before which to insert the item.
        /// </param>
        /// <param name="item">
        /// The item to insert.
        /// </param>
        public void Insert(int index, T item)
        {
            this.ValidateValueForNull(item);

            if (index < this.Count)
            {
                var upperSortKey = this.sortedItems.Keys[index];
                long lowerSortKey;
                if (index == 0)
                {
                    lowerSortKey = upperSortKey - (2L * DefaultKeyInterval);
                }
                else
                {
                    lowerSortKey = this.sortedItems.Keys[index - 1];
                }

                this.Add(this.ComputeSortKey(lowerSortKey, upperSortKey), item);
            }
            else
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Move the position of an item to the specified index
        /// </summary>
        /// <param name="index">The index of the item to move</param>
        /// <param name="destinationIndex">The destination index</param>
        /// <remarks>
        /// The method will move every item between the two specified indexes
        /// </remarks>
        public void Move(int index, int destinationIndex)
        {
            this.ValidateIndex(index);
            this.ValidateIndex(destinationIndex);

            var minIndex = Math.Min(index, destinationIndex);
            var maxIndex = Math.Max(index, destinationIndex);

            var keyList = this.sortedItems.Keys.ToList().GetRange(minIndex, maxIndex - minIndex + 1);
            keyList.Sort();

            if (destinationIndex < index)
            {
                keyList.Reverse();
            }

            // Move all items between the 2 specified indexes
            var initialItem = this.sortedItems[keyList[0]];
            for (var i = 1; i < keyList.Count; i++)
            {
                var key = keyList[i];
                var previousKey = keyList[i - 1];

                var itemToMove = this.sortedItems[key];
                this.sortedItems[key] = default(T);
                this.sortedItems[previousKey] = itemToMove;
            }

            this.sortedItems[keyList.Last()] = initialItem;
        }

        /// <summary>
        /// Removes all items from this <see cref="OrderedItemList{T}"/>
        /// </summary>
        public void Clear()
        {
            this.sortedItems.Clear();
        }

        /// <summary>
        /// Asserts whether given item is contained in this list.
        /// </summary>
        /// <param name="item">
        /// The item to be asserted.
        /// </param>
        /// <returns>
        /// True when contained, otherwise false.
        /// </returns>
        public bool Contains(T item)
        {
            return this.sortedItems.ContainsValue(item);
        }

        /// <summary>
        /// Copies the entire <see cref="OrderedItemList{T}"/> to a compatible one-dimensional array, starting at the specified index of the target array.
        /// </summary>
        /// <param name="array">
        /// The array.
        /// </param>
        /// <param name="arrayIndex">
        /// The index.
        /// </param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            this.sortedItems.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of value in the collection.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> determining if the remove succeeded.
        /// </returns>
        public bool Remove(T item)
        {
            var indexOfFirstOccurrence = this.sortedItems.Values.IndexOf(item);
            if (indexOfFirstOccurrence == -1)
            {
                return false;
            }

            this.sortedItems.RemoveAt(indexOfFirstOccurrence);
            return true;
        }

        /// <summary>
        /// Converts this <see cref="OrderedItemList{T}"/> to a <see cref="IEnumerable{T}"/> of <see cref="OrderedItem"/> to be passed to the <see cref="DTO.Thing"/>
        /// </summary>
        /// <returns>The corresponding <see cref="IEnumerable{T}"/> of <see cref="OrderedItem"/></returns>
        public IEnumerable<OrderedItem> ToDtoOrderedItemList()
        {
            var dtoOrderedItems = new List<OrderedItem>();
            foreach (var item in this.sortedItems)
            {
                var orderedItem = new OrderedItem { K = item.Key };

                var thing = item.Value as Thing;
                if (thing != null)
                {
                    orderedItem.V = thing.Iid;
                }
                else
                {
                    orderedItem.V = item.Value;
                }

                dtoOrderedItems.Add(orderedItem);
            }

            return dtoOrderedItems;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="OrderedItemList{T}"/> that preserves order of each item.
        /// If the type T of the contained objects is <see cref="Thing"/> then a clone of each object is made with cloning all contained things, 
        /// otherwise the object will be passed to a new item. Be cautious about mutability.
        /// </summary>
        /// <param name="container">The <see cref="Thing"/> that contains this <see cref="OrderedItemList{T}"/> clone.</param>
        /// <returns>
        /// A cloned instance of <see cref="OrderedItemList{T}"/>.
        /// </returns>
        public OrderedItemList<T> Clone(Thing container)
        {
            var clonedOrderedItemList = new OrderedItemList<T>(container, this.IsComposite);
            clonedOrderedItemList.AddOrderedItems(this.sortedItems.Select(x => {
                var item = new OrderedItem() { K = x.Key };
                var value = x.Value as Thing;
                if (value != null)
                {
                    item.V = value.Clone(true);
                }
                else
                {
                    item.V = x.Value;
                }

                return item;
            }));

            return clonedOrderedItemList;
        }

        /// <summary>
        /// Compute a uniformly distributed random long sort key approximately in the middle between the given lower and upper sort keys.
        /// </summary>
        /// <param name="lowerSortKey">
        /// The lower sort key.
        /// </param>
        /// <param name="upperSortKey">
        /// The upper sort key.
        /// </param>
        /// <returns>
        /// The computed new sort key. The new key is guaranteed to be non-zero and not already in use in this ordered collection.
        /// </returns>
        private long ComputeSortKey(long lowerSortKey, long upperSortKey)
        {
            const long NumberOfBucketsInInterval = 5;
            const long NumberOfBucketsToMiddleBucket = NumberOfBucketsInInterval / 2;

            var interval = upperSortKey - lowerSortKey;
            var bucketSize = interval / NumberOfBucketsInInterval;
            var newSortKey = 0L;
            while (newSortKey == 0L || this.sortedItems.ContainsKey(newSortKey))
            {
                var randomOffset = this.random.Next(Convert.ToInt32(bucketSize));
                newSortKey = lowerSortKey + (NumberOfBucketsToMiddleBucket * bucketSize) + randomOffset;
            }

            return newSortKey;
        }

        /// <summary>
        /// Adds the specified item to this list with the given sort key.
        /// If the item is a <see cref="Thing"/> and its container is null, the container is set to the container of this list.
        /// </summary>
        /// <param name="sortKey">
        /// The sort key of the item to be added.
        /// </param>
        /// <param name="item">
        /// The item to be added.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see paramref="item"/> is null.
        /// </exception>
        private void Add(long sortKey, T item)
        {
            var domainObject = item as Thing;
            if (domainObject != null && this.IsComposite)
            {
                domainObject.Container = this.Container;
            }

            if (this.sortedItems.ContainsKey(sortKey))
            {
                throw new ArgumentException("The key already exists", "sortKey");
            }

            if (item is Thing)
            {
                if (this.sortedItems.Values.Contains(item))
                {
                    return;
                }
            }

            this.sortedItems.Add(sortKey, item);
            this.highestKey = Math.Max(sortKey, this.highestKey);
        }

        /// <summary>
        /// Validates a value for being null.
        /// </summary>
        /// <param name="value">
        /// The value to validate.
        /// </param>
        /// <param name="message">
        /// The message to pass to an exception if validation not passes.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <see paramref="value"/> is null.
        /// </exception>
        private void ValidateValueForNull(object value, string message = "An item cannot be null")
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }
        }

        /// <summary>
        /// Validates an index to be within an allowed range of the list of items.
        /// </summary>
        /// <param name="index">
        /// The value to validate.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <see paramref="index"/> is out of the allowed range.
        /// </exception>
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.sortedItems.Count)
            {
                var rangeMessage = this.sortedItems.Count == 0 ? "the list is empty" : $"valid range is 0 to { this.sortedItems.Count - 1}";
                throw new ArgumentOutOfRangeException(
                    "index",$"The index {index} does not exist in the OrderedItemList, {rangeMessage}");
            }
        }

        /// <summary>
        /// Validates whether an item is already in the list of items.
        /// </summary>
        /// <param name="item">
        /// The item to validate.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// Thrown when <see paramref="item"/> is already in the list.
        /// </exception>
        private void ValidateItemForExistence(T item)
        {
            if (this.sortedItems.Values.Contains(item))
            {
                var thing = item as Thing;
                var message = thing != null ? thing.Iid.ToString() : "An item is not a Thing. Incorrect use of validation.";
                throw new InvalidOperationException($"OrderedItemList already contains the item: {message}");
            }
        }
    }
}
