#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WSPPostOperationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
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

namespace CDP4WspDal.Tests.Operations
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;    
    using CDP4Common.Types;
    using CDP4Dal.Operations;
    using CDP4WspDal;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="WspPostOperation"/>
    /// </summary>
    [TestFixture]
    public class WSPPostOperationTestFixture
    {
        private Uri uri;

        /// <summary>
        /// The <see cref="WspPostOperation"/> that is the subject of the test fixture
        /// </summary>
        private WspPostOperation wspPostOperation;

        [SetUp]
        public void Setup()
        {
            this.uri = new Uri("http://test.com");

            this.wspPostOperation = new WspPostOperation(new MetaDataProvider());
        }

        [TearDown]
        public void TearDown()
        {
            this.uri = null;
            this.wspPostOperation = null;
        }

        [Test]
        public void VerifyThatConstructorCreatesDeleteCreateAndUpdateContainers()
        {
            Assert.AreEqual(0, this.wspPostOperation.Create.Count);
            Assert.AreEqual(0, this.wspPostOperation.Delete.Count);
            Assert.AreEqual(0, this.wspPostOperation.Update.Count);
        }

        [Test]
        public void VerifyThatAnUpdateOfUnchangedThingIsFilteredOut()
        {
            var simpleUnit = new SimpleUnit(Guid.NewGuid(), 1);
            var operation = new Operation(simpleUnit, simpleUnit, OperationKind.Update);
            this.wspPostOperation.ConstructFromOperation(operation);

            Assert.IsEmpty(this.wspPostOperation.Create);
            Assert.IsEmpty(this.wspPostOperation.Update);
            Assert.IsEmpty(this.wspPostOperation.Delete);

            var person1 = new Person(Guid.NewGuid(), 1);
            var person1update = new Person(person1.Iid, 1);
            person1update.TelephoneNumber.Add(Guid.NewGuid());
            var operation2 = new Operation(person1, person1update, OperationKind.Update);
            this.wspPostOperation.ConstructFromOperation(operation2);

            Assert.IsEmpty(this.wspPostOperation.Create);
            Assert.IsNotEmpty(this.wspPostOperation.Update);
            Assert.IsEmpty(this.wspPostOperation.Delete);
        }

        [Test]
        public void VerifyThatExceptionIsThrownWhenModifiedThingIsNotProvided()
        {
            var simpleUnit = new SimpleUnit(Guid.NewGuid(), 1);
            var operation = new Operation(simpleUnit, null, OperationKind.Delete);
            Assert.Throws<ArgumentNullException>(() => this.wspPostOperation.ConstructFromOperation(operation)) ;
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenOperationIsUpdateAndOriginalThingIsNull()
        {
            var simpleUnit = new SimpleUnit(Guid.NewGuid(), 1);
            var operation = new Operation(null, simpleUnit, OperationKind.Update);
            Assert.Throws<ArgumentException>(() => this.wspPostOperation.ConstructFromOperation(operation));
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenOperationIsCopy()
        {
            var simpleUnit = new SimpleUnit(Guid.NewGuid(), 1);
            var operation = new Operation(null, simpleUnit, OperationKind.Copy);
            Assert.Throws<NotSupportedException>(() => this.wspPostOperation.ConstructFromOperation(operation));
        }

        [Test]
        public void VerifyThatExceptionIsThrowWhenOperationIsMove()
        {
            var simpleUnit = new SimpleUnit(Guid.NewGuid(), 1);
            var operation = new Operation(null, simpleUnit, OperationKind.Move);
            Assert.Throws<NotSupportedException>(() => this.wspPostOperation.ConstructFromOperation(operation));
        }

        [Test]
        public void VerifyThatOperationIsCorrectlyComputedFromArrayParameterTypeUpdate()
        {
            var array1 = new ArrayParameterType(Guid.NewGuid(), 1);
            var array2 = new ArrayParameterType(Guid.NewGuid(), 1);

            array1.Dimension.Add(new OrderedItem { K = 123, V = 1 });
            array1.Dimension.Add(new OrderedItem { K = 456, V = 1 });
            array1.Dimension.Add(new OrderedItem { K = 789, V = 1 });

            array2.Dimension.Add(new OrderedItem { K = 1234, V = 1 });
            array2.Dimension.Add(new OrderedItem { K = 4567, V = 1 });
            array2.Dimension.Add(new OrderedItem { K = 7890, V = 1 });

            var operation = new Operation(array1, array2, OperationKind.Update);
            this.wspPostOperation.ConstructFromOperation(operation);
            var updatedClasslessdto = this.wspPostOperation.Update.SingleOrDefault();
            Assert.IsNotNull(updatedClasslessdto);

            object outValue;
            Assert.IsTrue(updatedClasslessdto.TryGetValue("Dimension", out outValue));
            var orderedItems = (IEnumerable)outValue;
            var orderedItemList = orderedItems.Cast<OrderedItem>().ToList();

            Assert.AreEqual(1234, orderedItemList[0].K);
            Assert.AreEqual(4567, orderedItemList[1].K);
            Assert.AreEqual(7890, orderedItemList[2].K);
        }

        [Test]
        public void VerifyThatOperationIsCorrectlyComputedFromArrayParameterTypeUpdateGuid()
        {
            var array1 = new ArrayParameterType(Guid.NewGuid(), 1);
            var array2 = new ArrayParameterType(Guid.NewGuid(), 1);

            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            var guid3 = Guid.NewGuid();

            array1.Dimension.Add(new OrderedItem { K = 123, V = guid1 });
            array1.Dimension.Add(new OrderedItem { K = 456, V = guid2 });
            array1.Dimension.Add(new OrderedItem { K = 789, V = guid3 });

            array2.Dimension.Add(new OrderedItem { K = 1234, V = guid1 });
            array2.Dimension.Add(new OrderedItem { K = 4567, V = guid2 });
            array2.Dimension.Add(new OrderedItem { K = 7890, V = guid3 });

            var operation = new Operation(array1, array2, OperationKind.Update);
            this.wspPostOperation.ConstructFromOperation(operation);
            var updatedClasslessdto = this.wspPostOperation.Update.SingleOrDefault();
            Assert.IsNotNull(updatedClasslessdto);

            object outValue;
            Assert.IsTrue(updatedClasslessdto.TryGetValue("Dimension", out outValue));
            var orderedItems = (IEnumerable)outValue;
            var orderedItemList = orderedItems.Cast<OrderedItem>().ToList();

            Assert.AreEqual(123, orderedItemList[0].K);
            Assert.AreEqual(456, orderedItemList[1].K);
            Assert.AreEqual(789, orderedItemList[2].K);

            Assert.AreEqual(1234, orderedItemList[0].M);
            Assert.AreEqual(4567, orderedItemList[1].M);
            Assert.AreEqual(7890, orderedItemList[2].M);

            Assert.AreEqual(guid1, orderedItemList[0].V);
            Assert.AreEqual(guid2, orderedItemList[1].V);
            Assert.AreEqual(guid3, orderedItemList[2].V);
        }
    }
}
