// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectChangedEvent.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.Events
{
    using CDP4Common.CommonData;

    /// <summary>
    /// The purpose of the <see cref="ObjectChangedEvent"/> is to notify an observer
    /// that the referenced <see cref="Thing"/> has changed in some way and what that change is.
    /// </summary>
    public class ObjectChangedEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectChangedEvent"/> class.
        /// </summary>
        /// <param name="thing">
        /// The payload <see cref="Thing"/>.
        /// </param>
        /// <param name="eventKind">
        /// The event kind.
        /// </param>
        public ObjectChangedEvent(Thing thing, EventKind eventKind)
        {
            this.ChangedThing = thing;
            this.EventKind = eventKind;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectChangedEvent"/> class.
        /// </summary>
        /// <param name="thing">
        /// The payload <see cref="Thing"/>
        /// </param>
        public ObjectChangedEvent(Thing thing)
        {
            this.ChangedThing = thing;
            this.EventKind = EventKind.Updated;
        }

        /// <summary>
        /// Gets or sets the changed <see cref="Thing"/>
        /// </summary>
        public Thing ChangedThing { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="EventKind"/> to be transported.
        /// </summary>
        public EventKind EventKind { get; set; }
    }
}