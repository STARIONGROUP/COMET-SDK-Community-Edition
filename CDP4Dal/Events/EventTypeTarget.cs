// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventTypeTarget.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
