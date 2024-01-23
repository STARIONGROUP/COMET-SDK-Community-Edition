// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDPMessageBus.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    using System.Reactive.Subjects;

#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif

    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    using Events;

    /// <summary>
    /// The CDP specific MessageBus implementation.
    /// </summary>
    /// <remarks>
    /// Be carefull with Lifetime scope for DI registration as the CDPMessageBus implements a publish/subscribe mechanism.
    /// The <see cref="ISession"/> Lifetime scope for DI registration should have the same lifetime scope as CDPMessageBus,
    /// otherwise publications and subscriptions might be made to different instances of CDPMessageBus which breaks the pub/sub pattern.
    /// </remarks>
#if NETFRAMEWORK
    [Export(typeof(ICDPMessageBus))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public sealed class CDPMessageBus : ICDPMessageBus
    {
        /// <summary>
        /// The <see cref="Dictionary{TKey,TValue}"/> holding the subscriptions.
        /// </summary>
        private readonly ConcurrentDictionary<EventTypeTarget, Lazy<CDPEventSubject>> messageBus = new ConcurrentDictionary<EventTypeTarget, Lazy<CDPEventSubject>>();

        /// <summary>
        /// Number of currently active Observables in the <see cref="messageBus"/>
        /// </summary>
        public int ActiveObservableCount => this.messageBus.Count;

        /// <summary>
        /// Total number of Calls that have been made to the Listen method
        /// during the lifetime of this instance of <see cref="CDPMessageBus"/>.
        /// </summary>
        public int ListenerCallCount { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="CDPMessageBus"/> is enabled or not
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="CDPMessageBus"/> class from being created.
        /// </summary>
        public CDPMessageBus()
        {
            this.IsEnabled = true;
        }

        /// <summary>
        /// Listen provides an Observable that will fire whenever a Message is
        /// provided for this object via RegisterMessageSource or SendMessage.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the message to listen to.
        /// </typeparam>
        /// <param name="target">
        /// The target <see cref="object"/> to subscribe to.
        /// </param>
        /// <param name="contract">
        /// A unique string to distinguish messages with
        /// identical types (i.e. "MyCoolViewModel") - if the message type is
        /// only used for one purpose, leave this as null.
        /// </param>
        /// <returns>
        /// An Observable representing the notifications posted to the
        /// message bus.
        /// </returns>
        public IObservable<T> Listen<T>(object target = null, string contract = null)
        {
            this.ListenerCallCount++;
            return this.GetOrAddObservable<T>(new EventTypeTarget(typeof(T), target));
        }

        /// <summary>
        /// Gets or adds (if not existent) the <see cref="IObservable{T}"/> to the <see cref="ConcurrentDictionary{TKey,TValue}"/>
        /// </summary>
        /// <param name="eventTypeTarget">
        /// The <see cref="EventTypeTarget"/> pertaining to this <see cref="IObservable{T}"/>.
        /// </param>
        /// <typeparam name="T">
        /// The <see cref="Thing"/> that has changed.
        /// </typeparam>
        /// <returns>
        /// The <see cref="IObservable{T}"/> connected to the target.
        /// </returns>
        private IObservable<T> GetOrAddObservable<T>(EventTypeTarget eventTypeTarget)
        {
            var cdpEventSubject = this.messageBus.GetOrAdd(
                eventTypeTarget,
                arg => new Lazy<CDPEventSubject>(() => this.ComposeEventSubject<T>(eventTypeTarget))).Value;

            return (IObservable<T>)cdpEventSubject.Observable;
        }

        /// <summary>
        /// Composes the observable subject of the <see cref="EventTypeTarget"/>
        /// </summary>
        /// <param name="eventTypeTarget">
        /// The <see cref="EventTypeTarget"/> to create the <see cref="Subject{T}"/> from
        /// </param>
        /// <typeparam name="T">
        /// The <see cref="Thing"/> POCO
        /// </typeparam>
        /// <returns>
        /// The <see cref="CDPEventSubject"/> describing the subscription.
        /// </returns>
        private CDPEventSubject ComposeEventSubject<T>(EventTypeTarget eventTypeTarget)
        {
            var subject = new Subject<T>();

            var observable = Observable.Create<T>(o => new CompositeDisposable(subject.Subscribe(o), this.CreateDisposableFromEvent(eventTypeTarget))).Publish().RefCount();

            return new CDPEventSubject(subject, observable);
        }

        /// <summary>
        /// Creates a <see cref="IDisposable"/> object from the <see cref="EventTypeTarget"/> with the delegate to run once the
        /// object is disposed.
        /// </summary>
        /// <param name="eventTypeTarget">The <see cref="EventTypeTarget"/> to process.</param>
        /// <returns>The <see cref="IDisposable"/>.</returns>
        private IDisposable CreateDisposableFromEvent(EventTypeTarget eventTypeTarget)
        {
            return Disposable.Create(() => this.DisposableDelegate(eventTypeTarget));
        }

        /// <summary>
        /// The method that executes when <paramref name="eventTypeTarget"/> needs to be deisposed.
        /// </summary>
        /// <param name="eventTypeTarget">The <paramref name="eventTypeTarget"/> that the dispose needs to handle.</param>
        private void DisposableDelegate(EventTypeTarget eventTypeTarget)
        {
            this.messageBus.TryRemove(eventTypeTarget, out _);
        }

        /// <summary>
        /// Sends a single message using the specified Type and contract.
        /// Consider using RegisterMessageSource instead if you will be sending
        /// messages in response to other changes such as property changes
        /// or events.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the message to send.
        /// </typeparam>
        /// <param name="message">
        /// The actual event to send.
        /// </param>
        /// <param name="target">
        /// The target object that the notification belongs to.
        /// </param>
        /// <param name="contract">
        /// A unique string to distinguish messages with
        /// identical types (i.e. "MyCoolViewModel") - if the message type is
        /// only used for one purpose, leave this as null.
        /// </param>
        public void SendMessage<T>(T message, object target = null, string contract = null)
        {
            if (!this.IsEnabled)
            {
                return;
            }

            var getObservable = this.messageBus.TryGetValue(new EventTypeTarget(typeof(T), target), out var cdpEventSubject);

            if (getObservable)
            {
                ((Subject<T>)cdpEventSubject.Value.Subject).OnNext(message);
            }
        }

        /// <summary>
        /// Send the necessary messages about a <see cref="Thing"/> being changed. Includes the sending of a message with the embedded type change.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that has changed.
        /// </param>
        /// <param name="eventKind">
        /// The event kind.
        /// </param>
        public void SendObjectChangeEvent(Thing thing, EventKind eventKind)
        {
            // send the object message
            this.SendMessage(new ObjectChangedEvent(thing, eventKind), thing);

            // send the typeof messages
            this.SendTypedObjectChangeEvent(thing, eventKind);
        }

        /// <summary>
        /// Send the necessary messages about a <see cref="Thing"/>s type (and all supertpes) being changed.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that has changed.
        /// </param>
        /// <param name="eventKind">
        /// The event kind.
        /// </param>
        private void SendTypedObjectChangeEvent(Thing thing, EventKind eventKind)
        {
            foreach (var type in TypeResolver.GetAllSuperTypes(thing))
            {
                this.SendMessage(new ObjectChangedEvent(thing, eventKind), type);
            }
        }

        /// <summary>
        /// Clears all the subcriptions that exist on the Message Bus
        /// </summary>
        public void ClearSubscriptions()
        {
            this.messageBus.Clear();
        }

        /// <summary>
        /// On dispose, remove all subscriptions
        /// </summary>
        public void Dispose()
        {
            this.ClearSubscriptions();
        }
    }
}