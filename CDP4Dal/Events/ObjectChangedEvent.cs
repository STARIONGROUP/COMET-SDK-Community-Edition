// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectChangedEvent.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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