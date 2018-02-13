#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedItem.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Types
{
    using System.Reflection;
    using CDP4Common.Polyfills;

    /// <summary>
    /// The ordered item. The <see cref="K"/> contains the ordered key and <see cref="V"/> the value
    /// </summary>
    public class OrderedItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderedItem"/> class.
        /// </summary>
        public OrderedItem()
        {
            this.M = null;
        }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        public long K { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object V { get; set; }

        /// <summary>
        /// Gets the move index
        /// </summary>
        public long? M { get; internal set; }

        /// <summary>
        /// Explicitly protect the <see cref="M"/> property by not allowing it to be set directly.
        /// </summary>
        /// <param name="originalIndex">The original index position of this <see cref="OrderedItem"/></param>
        /// <param name="newIndex">The new index position of this <see cref="OrderedItem"/></param>
        public void MoveItem(long originalIndex, long newIndex)
        {
            if (originalIndex == newIndex)
            {
                return;
            }

            this.K = originalIndex;

            this.M = newIndex;
        }

        /// <summary>
        /// The standard equality operator.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="object"/> to compare to.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> indicating whether the equality holds.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            var vType = this.V.GetType();
            if (vType.QueryIsPrimitive())
            {
                return this.PrimitiveEquals((OrderedItem)obj);
            }

            return obj.GetType() == this.GetType() && this.Equals((OrderedItem)obj);
        }

        /// <summary>
        /// Gets the hash code of this instance
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> indicating the hash code.
        /// </returns>
        public override int GetHashCode()
        {
            return this.V != null ? this.V.GetHashCode() : 0;
        }

        /// <summary>
        /// The standard equality operator. The object of type <see cref="OrderedItem"/> are considered equal if the values are equal.
        /// </summary>
        /// <param name="other">The <see cref="OrderedItem"/> being compared to this instance.</param>
        /// <returns>The <see cref="bool"/> indicating whether the equality holds.</returns>
        protected bool Equals(OrderedItem other)
        {
            return this.V.Equals(other.V);
        }

        /// <summary>
        /// The primitive equality operator. The object of type <see cref="OrderedItem"/> are considered equal if their key/value are equal.
        /// </summary>
        /// <param name="other">The <see cref="OrderedItem"/> being compared to this instance.</param>
        /// <returns>The <see cref="bool"/> indicating whether the equality holds.</returns>
        protected bool PrimitiveEquals(OrderedItem other)
        {
            return this.K.Equals(other.K) && this.V.Equals(other.V);
        }
    }
}
