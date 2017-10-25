// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventTypeTarget.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   Qualified message type that can be published and subscribed to through this message hub.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Events
{
    using System;

    /// <summary>
    /// Qualified message type that can be published and subscribed to through this message hub.
    /// </summary>
    internal class EventTypeTarget
    {
        /// <summary>
        /// The message type.
        /// </summary>
        public readonly Type EventType;

        /// <summary>
        /// The qualifier.
        /// </summary>
        public readonly object Target;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventTypeTarget"/> struct.
        /// </summary>
        /// <param name="eventType">
        /// The event type.
        /// </param>
        /// <param name="target">
        /// Optional qualifier that can be used to make the message type more specific.
        /// </param>
        public EventTypeTarget(Type eventType, object target = null)
        {
            this.EventType = eventType;
            this.Target = target;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare to.</param>
        /// <returns>True if the objects fulfil certain criteria.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            
            return obj is EventTypeTarget && this.Equals((EventTypeTarget)obj);
        }

        /// <summary>
        /// Equality operator overload.
        /// </summary>
        /// <param name="other">
        /// The other object cast to <see cref="EventTypeTarget"/>.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/> indicating equality.
        /// </returns>
        public bool Equals(EventTypeTarget other)
        {
            return object.Equals(this.EventType, other.EventType) && object.Equals(this.Target, other.Target);
        }

        /// <summary>
        /// Gets the hash code of this instance of <see cref="EventTypeTarget"/>
        /// </summary>
        /// <returns>
        /// The <see cref="int"/> indicating the HashCode.
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.EventType != null ? this.EventType.GetHashCode() : 0) * 397) ^ (this.Target != null ? this.Target.GetHashCode() : 0);
            }
        }
    }
}
