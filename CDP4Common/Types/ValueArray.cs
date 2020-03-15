// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArray.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System.Globalization;
    using System.Text;
    using CDP4Common.CommonData;
    using CDP4Common.Polyfills;

    /// <summary>
    /// The <see cref="ValueArray{T}"/> class is a collection of a given class type where its order is fixed, and that 
    /// it can be represented by a simple array structure.
    /// </summary>
    /// <typeparam name="T"> The <see cref="Thing"/> contained by the Value Array.
    /// </typeparam>
    public class ValueArray<T> : IEnumerable<T>
    {
        /// <summary>
        /// The underlying collection of items.
        /// </summary>
        private readonly List<T> items;

        /// <summary>
        /// The container of this <see cref="ValueArray{T}"/>
        /// </summary>
        private Thing container;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueArray{T}"/> class.
        /// </summary>
        public ValueArray()
        {
            this.items = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueArray{T}"/> class.
        /// </summary>
        /// <param name="container">The container of this <see cref="ValueArray{T}"/></param>
        public ValueArray(Thing container)
        {
            this.container = container;
            this.items = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueArray{T}"/> class.
        /// </summary>
        /// <param name="initializationCollection">
        /// Collection to initialize this <see cref="Collection{T}"/>.
        /// </param>
        public ValueArray(IEnumerable<T> initializationCollection)
        {
            this.items = initializationCollection == null ? new List<T>() : new List<T>(initializationCollection);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValueArray{T}"/> class.
        /// </summary>
        /// <param name="initializationCollection">
        /// Collection to initialize this <see cref="Collection{T}"/>.
        /// </param>
        /// <param name="container">The container of this <see cref="ValueArray{T}"/></param>
        public ValueArray(IEnumerable<T> initializationCollection, Thing container)
        {
            this.items = initializationCollection == null ? new List<T>() : new List<T>(initializationCollection);
            this.container = container;
        }
        
        /// <summary>
        /// Gets the type of the items of this collection.
        /// </summary>
        public Type ItemType
        {
            get { return typeof(T); }
        }

        /// <summary>
        /// Gets or sets the value of the item associated with the specified index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index of the item to get or set.
        /// </param>
        /// <returns>
        /// The value of the item with the specified index.
        /// </returns>
        public T this[int index]
        {
            get { return this.items[index]; }
            set { this.items[index] = value; }
        }

        /// <summary>
        /// Returns an enumerator that iterates through this collection.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator{T}"/>.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through this collection.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerator"/>.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        /// <summary>
        /// Returns a string representation of the <see cref="ValueArray{T}"/>
        /// </summary>
        /// <returns>The string representation</returns>
        public override string ToString()
        {
            if (this.items.Count == 0)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            sb.Append("{");
            for (var i = 0; i < this.items.Count ; i++)
            {
                if (typeof(T).QueryIsAssignableFrom(typeof(string)))
                {
                    sb.Append("\"");
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", this.items[i]);
                    sb.Append("\"");
                }
                else
                {
                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}", this.items[i]);
                }

                if (i != this.items.Count - 1)
                {
                    sb.Append("; ");
                }
            }

            sb.Append("}");
            return sb.ToString();
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ValueArray{T}"/>
        /// </summary>
        public int Count {
            get
            {
                {
                    return this.items.Count;
                }
            }
        }
    }
}