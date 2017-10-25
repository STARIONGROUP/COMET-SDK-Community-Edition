// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.EngineeringModelData;
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
            
            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(this.actualFiniteState.Name);
            });
        }

        [Test]        
        public void VerifyThatNullContainerThrowException2()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);

            Assert.Throws<NullReferenceException>(() =>
            {
                Console.WriteLine(this.actualFiniteState.ShortName);
            });
        }

        [Test]        
        public void VerifyThatNullContainerThrowException3()
        {
            this.actualFiniteState = new ActualFiniteState(Guid.NewGuid(), null, null);
            Assert.Throws<NullReferenceException>(() =>
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