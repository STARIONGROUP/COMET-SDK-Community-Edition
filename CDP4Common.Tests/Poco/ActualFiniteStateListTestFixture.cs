#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateListTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

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