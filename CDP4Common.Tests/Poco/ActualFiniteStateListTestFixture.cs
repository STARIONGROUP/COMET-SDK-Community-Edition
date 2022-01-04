// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateListTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4Common.Tests.Poco
{
    using System;

    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    [TestFixture]
    public class ActualFiniteStateListTestFixture
    {
        private ActualFiniteStateList actualList;
        private Iteration iteration;
        private EngineeringModel model;

        private PossibleFiniteStateList possibleList1;
        private PossibleFiniteStateList possibleList2;
        private PossibleFiniteStateList possibleList3;

        [SetUp]
        public void Setup()
        {
            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);

            this.possibleList1 = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "list1", ShortName = "1" };
            this.possibleList2 = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "list2", ShortName = "2" };
            this.possibleList3 = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "list3", ShortName = "3" };

            this.actualList.PossibleFiniteStateList.Add(this.possibleList1);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList2);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList3);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.model = new EngineeringModel(Guid.NewGuid(), null, null);

            this.model.Iteration.Add(this.iteration);
            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList1);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList2);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList3);

            var ps11 = new PossibleFiniteState(Guid.NewGuid(), null, null) {ShortName = "11", Name = "11"};
            var ps12 = new PossibleFiniteState(Guid.NewGuid(), null, null) {ShortName = "12", Name = "12"};
            var ps21 = new PossibleFiniteState(Guid.NewGuid(), null, null) {ShortName = "21", Name = "21"};
            var ps22 = new PossibleFiniteState(Guid.NewGuid(), null, null) {ShortName = "22", Name = "22"};

            var ps31 = new PossibleFiniteState(Guid.NewGuid(), null, null) { ShortName = "31", Name = "31" };
            var ps32 = new PossibleFiniteState(Guid.NewGuid(), null, null) { ShortName = "32", Name = "32" };
            var ps33 = new PossibleFiniteState(Guid.NewGuid(), null, null) { ShortName = "33", Name = "33" };

            this.possibleList1.PossibleState.Add(ps11);
            this.possibleList1.PossibleState.Add(ps12);

            this.possibleList2.PossibleState.Add(ps21);
            this.possibleList2.PossibleState.Add(ps22);

            this.possibleList3.PossibleState.Add(ps31);
            this.possibleList3.PossibleState.Add(ps32);
            this.possibleList3.PossibleState.Add(ps33);

            var as1 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as2 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as3 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as4 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as5 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as6 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as7 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as8 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as9 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as10 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as11 = new ActualFiniteState(Guid.NewGuid(), null, null);
            var as12 = new ActualFiniteState(Guid.NewGuid(), null, null);

            as1.PossibleState.Add(ps11);
            as1.PossibleState.Add(ps21);
            as1.PossibleState.Add(ps31);

            as2.PossibleState.Add(ps11);
            as2.PossibleState.Add(ps21);
            as2.PossibleState.Add(ps32);

            as3.PossibleState.Add(ps11);
            as3.PossibleState.Add(ps21);
            as3.PossibleState.Add(ps33);

            as4.PossibleState.Add(ps11);
            as4.PossibleState.Add(ps22);
            as4.PossibleState.Add(ps31);

            as5.PossibleState.Add(ps11);
            as5.PossibleState.Add(ps22);
            as5.PossibleState.Add(ps32);

            as6.PossibleState.Add(ps11);
            as6.PossibleState.Add(ps22);
            as6.PossibleState.Add(ps33);

            as7.PossibleState.Add(ps12);
            as7.PossibleState.Add(ps21);
            as7.PossibleState.Add(ps31);

            as8.PossibleState.Add(ps12);
            as8.PossibleState.Add(ps21);
            as8.PossibleState.Add(ps32);

            as9.PossibleState.Add(ps12);
            as9.PossibleState.Add(ps21);
            as9.PossibleState.Add(ps33);

            as10.PossibleState.Add(ps12);
            as10.PossibleState.Add(ps22);
            as10.PossibleState.Add(ps31);

            as11.PossibleState.Add(ps12);
            as11.PossibleState.Add(ps22);
            as11.PossibleState.Add(ps32);

            as12.PossibleState.Add(ps12);
            as12.PossibleState.Add(ps22);
            as12.PossibleState.Add(ps33);

            this.actualList.ActualState.Add(as3);
            this.actualList.ActualState.Add(as12);
            this.actualList.ActualState.Add(as6);
            this.actualList.ActualState.Add(as2);
            this.actualList.ActualState.Add(as11);
            this.actualList.ActualState.Add(as5);
            this.actualList.ActualState.Add(as4);
            this.actualList.ActualState.Add(as1);
            this.actualList.ActualState.Add(as7);
            this.actualList.ActualState.Add(as10);
            this.actualList.ActualState.Add(as8);
            this.actualList.ActualState.Add(as9);
        }

        [Test]
        public void VerifyName()
        {
            Assert.That(this.actualList.Name, Is.EqualTo("list1 → list2 → list3"));
        }

        [Test]
        public void VerifyShortName()
        {
            Assert.That(this.actualList.ShortName, Is.EqualTo("1.2.3"));
        }

        [Test]
        public void VerifyOrderStateWorks()
        {
            Assert.That(this.actualList.ActualState[0].ShortName, Is.Not.EqualTo("11.21.31"));

            this.actualList.ActualState.Sort(new ActualFiniteStateComparer());
            var orderedStates = this.actualList.ActualState;

            Assert.That(orderedStates[0].ShortName, Is.EqualTo("11.21.31"));
            Assert.That(orderedStates[1].ShortName, Is.EqualTo("11.21.32"));
            Assert.That(orderedStates[2].ShortName, Is.EqualTo("11.21.33"));
            Assert.That(orderedStates[3].ShortName, Is.EqualTo("11.22.31"));
            Assert.That(orderedStates[4].ShortName, Is.EqualTo("11.22.32"));
            Assert.That(orderedStates[5].ShortName, Is.EqualTo("11.22.33"));
            Assert.That(orderedStates[6].ShortName, Is.EqualTo("12.21.31"));
            Assert.That(orderedStates[7].ShortName, Is.EqualTo("12.21.32"));
            Assert.That(orderedStates[8].ShortName, Is.EqualTo("12.21.33"));
            Assert.That(orderedStates[9].ShortName, Is.EqualTo("12.22.31"));
            Assert.That(orderedStates[10].ShortName, Is.EqualTo("12.22.32"));
            Assert.That(orderedStates[11].ShortName, Is.EqualTo("12.22.33"));
        }
    }
}