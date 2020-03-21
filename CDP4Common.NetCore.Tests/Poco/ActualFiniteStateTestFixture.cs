// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Poco
{
    using System;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class ActualFiniteStateTestFixture
    {
        private ActualFiniteState actualFiniteState;
        private ActualFiniteStateList actualList;
        private Iteration iteration;
        private EngineeringModel model;

        private PossibleFiniteStateList possibleList1;
        private PossibleFiniteStateList possibleList2;

        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;

        [SetUp]
        public void Setup()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualList.Owner = new DomainOfExpertise(Guid.NewGuid(), null, null);

            this.possibleList1 = new PossibleFiniteStateList(Guid.NewGuid(), null, null);
            this.possibleList2 = new PossibleFiniteStateList(Guid.NewGuid(), null, null);

            this.possibleState1 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate1", ShortName = "1" };
            this.possibleState2 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate2", ShortName = "2" };

            this.possibleList1.PossibleState.Add(this.possibleState1);
            this.possibleList2.PossibleState.Add(this.possibleState2);

            this.actualFiniteState.PossibleState.Add(this.possibleState1);
            this.actualFiniteState.PossibleState.Add(this.possibleState2);

            this.actualList.PossibleFiniteStateList.Add(this.possibleList1);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList2);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.model = new EngineeringModel(Guid.NewGuid(), null, null);

            this.model.Iteration.Add(this.iteration);
            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList1);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList2);
            this.actualList.ActualState.Add(this.actualFiniteState);
        }

        [Test]
        public void VerifyThatGetNameWorks()
        {
            Assert.IsNotNull(this.actualFiniteState.Name);
            Assert.IsNotEmpty(this.actualFiniteState.Name);
            Assert.AreEqual("possiblestate1 → possiblestate2", this.actualFiniteState.Name);
        }

        [Test]
        public void VerifyThatGetShortNameNameWorks()
        {
            Assert.IsNotNull(this.actualFiniteState.ShortName);
            Assert.IsNotEmpty(this.actualFiniteState.ShortName);
            Assert.AreEqual("1.2", this.actualFiniteState.ShortName);
        }

        [Test]
        public void VerifyThatGetOwnerWorks()
        {
            Assert.IsNotNull(this.actualFiniteState.Owner);
            Assert.IsTrue(Object.ReferenceEquals(this.actualList.Owner, this.actualFiniteState.Owner));
        }

        [Test]        
        public void VerifyThatNullContainerThrowException()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);
            
            Assert.Throws<ContainmentException>(() =>
            {
                Console.WriteLine(this.actualFiniteState.Name);
            });
        }

        [Test]        
        public void VerifyThatNullContainerThrowException2()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);

            Assert.Throws<ContainmentException>(() =>
            {
                Console.WriteLine(this.actualFiniteState.ShortName);
            });
        }

        [Test]        
        public void VerifyThatNullContainerThrowException3()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);
            Assert.Throws<ContainmentException>(() =>
            {
                Console.WriteLine(this.actualFiniteState.Owner);
            });
        }

        [Test]
        public void VerifyIsDefaultWorks()
        {
            Assert.IsFalse(this.actualFiniteState.IsDefault);
            this.possibleList1.DefaultState = this.possibleState1;

            Assert.IsFalse(this.actualFiniteState.IsDefault);
            this.possibleList2.DefaultState = this.possibleState2;
            Assert.IsTrue(this.actualFiniteState.IsDefault);
        }
    }
}