// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateComparerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.Comparers
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;    
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ActualFiniteStateComparer"/> class
    /// </summary>
    [TestFixture]
    public class ActualFiniteStateComparerTestFixture
    {
        private readonly Uri uri = new Uri("http://sdk.cdp4.org");
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;

        private ActualFiniteStateComparer comparer;

        private PossibleFiniteStateList possibleFiniteStateList_1;
        private PossibleFiniteState possibleFiniteState_1_1;
        private PossibleFiniteState possibleFiniteState_1_2;

        private PossibleFiniteStateList possibleFiniteStateList_2;
        private PossibleFiniteState possibleFiniteState_2_1;
        private PossibleFiniteState possibleFiniteState_2_2;

        private ActualFiniteStateList actualFiniteStateList;
        private ActualFiniteState actualFiniteState_1;
        private ActualFiniteState actualFiniteState_2;
        private ActualFiniteState actualFiniteState_3;
        private ActualFiniteState actualFiniteState_4;
        
        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            this.possibleFiniteStateList_1 = new PossibleFiniteStateList(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteState_1_1 = new PossibleFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteState_1_2 = new PossibleFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteStateList_1.PossibleState.Add(this.possibleFiniteState_1_1);
            this.possibleFiniteStateList_1.PossibleState.Add(this.possibleFiniteState_1_2);

            this.possibleFiniteStateList_2 = new PossibleFiniteStateList(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteState_2_1 = new PossibleFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteState_2_2 = new PossibleFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.possibleFiniteStateList_2.PossibleState.Add(this.possibleFiniteState_2_1);
            this.possibleFiniteStateList_2.PossibleState.Add(this.possibleFiniteState_2_2);

            this.actualFiniteStateList = new ActualFiniteStateList(Guid.NewGuid(), this.cache, this.uri);
            this.actualFiniteStateList.PossibleFiniteStateList.Insert(1, this.possibleFiniteStateList_1);
            this.actualFiniteState_1 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.actualFiniteState_1.PossibleState.Add(this.possibleFiniteState_1_1);
            this.actualFiniteState_2 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.actualFiniteState_2.PossibleState.Add(this.possibleFiniteState_1_2);
            this.actualFiniteState_3 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.actualFiniteState_3.PossibleState.Add(this.possibleFiniteState_2_1);
            this.actualFiniteState_4 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);
            this.actualFiniteState_4.PossibleState.Add(this.possibleFiniteState_2_2);
            this.actualFiniteStateList.ActualState.Add(this.actualFiniteState_1);
            this.actualFiniteStateList.ActualState.Add(this.actualFiniteState_2);
            this.actualFiniteStateList.ActualState.Add(this.actualFiniteState_3);
            this.actualFiniteStateList.ActualState.Add(this.actualFiniteState_4);

            this.comparer = new ActualFiniteStateComparer();
        }

        [Test]
        public void Verify_that_when_containers_are_not_the_same_exception_is_thrown()
        {
            var otherActualFiniteStateList = new ActualFiniteStateList(Guid.NewGuid(), this.cache, this.uri);
            var otherActualFiniteState = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);

            otherActualFiniteStateList.ActualState.Add(otherActualFiniteState);

            Assert.That(() => this.comparer.Compare(this.actualFiniteState_1, otherActualFiniteState), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Verify_that_when_states_are_the_same_result_is_zero()
        {
            var result = this.comparer.Compare(this.actualFiniteState_1, this.actualFiniteState_1);
            Assert.That(0, Is.EqualTo(result));
        }

        [Test]
        public void Verify_that_when_actualstates_contain_no_possiblestates_zero_is_returned()
        {
            this.actualFiniteState_1.PossibleState.Clear();
            this.actualFiniteState_2.PossibleState.Clear();

            var result = this.comparer.Compare(this.actualFiniteState_1, this.actualFiniteState_2);

            Assert.That(0, Is.EqualTo(result));
        }

        [Test]
        public void Verify_that_when_actualstate1_is_smaller_than_actualstate2_a_negative_number_is_returned()
        {
            var result = this.comparer.Compare(this.actualFiniteState_1, this.actualFiniteState_2);

            Assert.That(result, Is.Negative);
        }
    }
}