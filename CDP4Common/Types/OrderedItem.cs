// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedItem.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
