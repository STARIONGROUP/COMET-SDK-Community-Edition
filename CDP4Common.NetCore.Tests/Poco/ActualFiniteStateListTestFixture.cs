// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateListTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
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

        [SetUp]
        public void Setup()
        {
            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);

            this.possibleList1 = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "list1", ShortName = "1" };
            this.possibleList2 = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "list2", ShortName = "2" };

            this.actualList.PossibleFiniteStateList.Add(this.possibleList1);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList2);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.model = new EngineeringModel(Guid.NewGuid(), null, null);

            this.model.Iteration.Add(this.iteration);
            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList1);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList2);
        }

        [Test]
        public void VerifyName()
        {
            Assert.AreEqual("list1 → list2", this.actualList.Name);
        }

        [Test]
        public void VerifyShortName()
        {
            Assert.AreEqual("1.2", this.actualList.ShortName);
        }
    }
}