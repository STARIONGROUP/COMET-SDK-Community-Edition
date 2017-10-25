// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDPEventSubject.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   Representation of a subject-observable pair.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Events
{
    /// <summary>
    /// Representation of a subject-observable pair.
    /// </summary>
    internal class CDPEventSubject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDPEventSubject"/> struct.
        /// </summary>
        /// <param name="subject">
        /// The subject of the event.
        /// </param>
        /// <param name="observable">
        /// The observable that results from the event.
        /// </param>
        public CDPEventSubject(object subject, object observable)
        {
            this.Subject = subject;
            this.Observable = observable;
        }

        /// <summary>
        /// The subject.
        /// </summary>
        public readonly object Subject;

        /// <summary>
        /// The observable.
        /// </summary>
        public readonly object Observable;
    }
}
