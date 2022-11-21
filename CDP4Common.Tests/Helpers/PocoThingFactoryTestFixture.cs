// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PocoThingFactoryTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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

namespace CDP4Common.Tests.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="PocoThingFactory"/> class.
    /// </summary>
    [TestFixture]
    public class PocoThingFactoryTestFixture
    {
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        public Iteration iteration;
        private PossibleFiniteStateList possibleFiniteStateList;
        private List<PossibleFiniteState> possibleStates;
        private List<OrderedItem> orderedItems;
        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;
        private PossibleFiniteState possibleState3;
        private OrderedItem orderedItem1;
        private OrderedItem orderedItem2;
        private OrderedItem orderedItem3;

        [SetUp]
        public void SetUp ()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();
            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null);

            this.possibleFiniteStateList = new PossibleFiniteStateList(Guid.NewGuid(), this.cache, null);
            this.iteration.PossibleFiniteStateList.Add(this.possibleFiniteStateList);

            this.possibleStates = new List<PossibleFiniteState>();

            this.possibleState1 = new PossibleFiniteState(Guid.NewGuid(), this.cache, null);
            this.possibleState2 = new PossibleFiniteState(Guid.NewGuid(), this.cache, null);
            this.possibleState3 = new PossibleFiniteState(Guid.NewGuid(), this.cache, null);

            this.cache.AddOrUpdate(
                new CacheKey(this.possibleState1.Iid, this.iteration.Iid),
                new Lazy<Thing>(() => this.possibleState1), 
                (key, oldValue) => oldValue);

            this.cache.AddOrUpdate(
                new CacheKey(this.possibleState2.Iid, this.iteration.Iid),
                new Lazy<Thing>(() => this.possibleState2), 
                (key, oldValue) => oldValue);

            this.cache.AddOrUpdate(
                new CacheKey(this.possibleState3.Iid, this.iteration.Iid),
                new Lazy<Thing>(() => this.possibleState3), 
                (key, oldValue) => oldValue);

            this.possibleStates.AddRange( new []
            {
                this.possibleState1, 
                this.possibleState2, 
                this.possibleState3
            });

            this.orderedItems = new List<OrderedItem>();

            this.orderedItem1 = new OrderedItem
            {
                K = 1,
                V = this.possibleState1.Iid
            };

            this.orderedItem2 = new OrderedItem
            {
                K = 2,
                V = this.possibleState2.Iid
            };

            this.orderedItem3 = new OrderedItem
            {
                K = 3,
                V = this.possibleState3.Iid
            };

            this.orderedItems.AddRange( new []
            {
                this.orderedItem1, 
                this.orderedItem2, 
                this.orderedItem3
            });
        }

        [Test]
        public void Verify_that_ResolveList_works()
        {
            Assert.DoesNotThrow(() => this.possibleFiniteStateList.PossibleState.ResolveList(this.orderedItems, this.iteration.Iid, this.cache));
            Assert.That(this.possibleFiniteStateList.PossibleState.Count, Is.EqualTo(3));
            CollectionAssert.AreEqual(this.possibleFiniteStateList.PossibleState.Select(x => x.Iid), this.orderedItems.OrderBy(x => x.K).Select(x => x.V));
        }

        [Test]
        public void Verify_that_ResolveList_throws_on_duplicate_keys()
        {
            this.orderedItem3.K = 2;

            var exception = Assert.Throws<ModelErrorException>(
                () => this.possibleFiniteStateList.PossibleState.ResolveList(this.orderedItems, this.iteration.Iid, this.cache));

            Assert.That(exception.Message.ToUpper(), Contains.Substring("The key already exists".ToUpper()));
        }
    }
}
