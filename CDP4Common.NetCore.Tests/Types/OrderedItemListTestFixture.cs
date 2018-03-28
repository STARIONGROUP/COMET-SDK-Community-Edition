#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderedItemListTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Types
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using CommonData;
    using SiteDirectoryData;
    using CDP4Common.Types;
    using NUnit.Framework;

    [TestFixture]
    public class OrderedItemListTestFixture
    {
        private OrderedItemList<Thing> testList;
        
        private Person person;

        [SetUp]
        public void Setup()
        {
            this.person = new Person(Guid.NewGuid(), null, null);
            this.testList = new OrderedItemList<Thing>(container: null);
        }

        [TearDown]
        public void TearDown()
        {
            this.testList.Clear();
        }

        [Test]
        public void VerifyThatContainerSetToClone()
        {
            var list = new ActualFiniteStateList();
            var state = new ActualFiniteState();
            list.ActualState.Add(state);

            var clone = list.Clone(false);
            Assert.AreSame(list, state.Container);

            clone.ActualState.Clear();
            clone.ActualState.Add(state);

            Assert.AreSame(clone, state.Container);
        }

        [Test]
        public void VerifyThatAddWorks_NotCompositeList()
        {
            this.testList = new OrderedItemList<Thing>(this.person) { new EmailAddress(Guid.NewGuid(), null, null) };

            Assert.AreEqual(1, this.testList.Count);
            Assert.IsNull(this.testList[0].Container);
        }

        [Test]
        public void VerifyThatAddWorks_CompositeList()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true) { new EmailAddress(Guid.NewGuid(), null, null) };

            Assert.AreEqual(1, this.testList.Count);
            Assert.AreEqual(this.person, this.testList[0].Container);

            Assert.IsTrue((-20000000L < this.testList.SortedItems.First().Key) && (20000000L > this.testList.SortedItems.First().Key));
        }

        [Test]
        public void VerifyThatGetEnumeratorWork()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true) { new EmailAddress(Guid.NewGuid(), null, null) };
            foreach (var item in this.testList)
            {
                Assert.IsNotNull(item);
            }
        }

        [Test]
        public void VerifyThatRemoveWorks()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.testList = new OrderedItemList<Thing>(this.person, true) { email };

            this.testList.Remove(email);

            Assert.AreEqual(0, this.testList.Count);
        }

        [Test]
        public void VerifyThatClearWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);
            this.testList.Add(new EmailAddress(Guid.NewGuid(), null, null));
            this.testList.Add(new EmailAddress(Guid.NewGuid(), null, null));

            this.testList.Clear();
            Assert.AreEqual(0, this.testList.Count);
        }

        [Test]
        public void VerifyThatAddOrderedItemsWorks()
        {
            var listOrderedItem = new List<OrderedItem>();
            listOrderedItem.Add(new OrderedItem() { K = -2000, V = new EmailAddress(Guid.NewGuid(), null, null) });
            listOrderedItem.Add(new OrderedItem() { K = 500000, V = new Person(Guid.NewGuid(), null, null) });
            listOrderedItem.Add(new OrderedItem() { K = 10000000, V = new TelephoneNumber(Guid.NewGuid(), null, null) });

            this.testList = new OrderedItemList<Thing>(this.person, true);

            this.testList.AddOrderedItems(listOrderedItem);
            Assert.AreEqual(3, this.testList.Count);
        }

        [Test]
        public void VerifyThatAddRangeWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);

            var listItemToAdd = new List<Thing>();
            listItemToAdd.Add(new EmailAddress(Guid.NewGuid(), null, null));
            listItemToAdd.Add(new TelephoneNumber(Guid.NewGuid(), null, null));

            this.testList.AddRange(listItemToAdd);
            Assert.AreEqual(listItemToAdd.Count, this.testList.Count);
        }

        [Test]
        public void VerifyThatInsertWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);

            var listItemToAdd = new List<Thing>();
            listItemToAdd.Add(new EmailAddress(Guid.NewGuid(), null, null));
            listItemToAdd.Add(new TelephoneNumber(Guid.NewGuid(), null, null));

            this.testList.AddRange(listItemToAdd);

            var inserted = new Person(Guid.NewGuid(), null, null);
            this.testList.Insert(1, inserted);

            Assert.AreEqual(inserted, this.testList[1]);
            Assert.IsTrue(this.testList.SortedItems.Keys[1] > this.testList.SortedItems.Keys[0] && this.testList.SortedItems.Keys[2] > this.testList.SortedItems.Keys[1]);
        }

        [Test]
        public void VerifyThatContainsWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);
            var inserted = new Person(Guid.NewGuid(), null, null);

            testList.Add(inserted);

            Assert.IsTrue(this.testList.Contains(inserted));
        }

        [Test]
        public void VerifyThatCopyToWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);
            var inserted = new Person(Guid.NewGuid(), null, null);

            testList.Add(inserted);

            var array = new Thing[1];
            this.testList.CopyTo(array, 0);

            Assert.IsNotNull(array[0]);
        }

        [Test]
        public void VerifyThatToDtoListOrderedItemWorks()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);

            var email = new EmailAddress(Guid.NewGuid(), null, null);
            var tel = new TelephoneNumber(Guid.NewGuid(), null, null);

            this.testList.Add(email);
            this.testList.Add(tel);

            var dtoOrderedList = this.testList.ToDtoOrderedItemList().ToList();
            Assert.AreEqual(this.testList.Count, dtoOrderedList.Count());
            Assert.AreEqual(this.testList.SortedItems.Keys[0], dtoOrderedList[0].K);
            Assert.AreEqual(this.testList.SortedItems.Keys[1], dtoOrderedList[1].K);

            Assert.AreEqual(this.testList.SortedItems.Values[0].Iid, dtoOrderedList[0].V);
            Assert.AreEqual(this.testList.SortedItems.Values[1].Iid, dtoOrderedList[1].V);
        }

        [Test]
        public void VerifyThatOrderedItemWithPrimitiveVTypeMayBeAdded()
        {
            var orderedList = new OrderedItemList<int>(container:null);

            var orderedItem1 = new OrderedItem() { K = 1, V = "2" };
            orderedList.AddOrderedItems(new List<OrderedItem>(){orderedItem1});

            Assert.AreEqual(1, orderedList.Count);
        }

        [Test]
        public void VerifyThatAddNullThrowsException()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);
            
            Assert.Throws<ArgumentNullException>(() => this.testList.Add(null));
        }

        [Test]
        public void VerifyThatAddingWrongOrderedItemTypeThrowsException()
        {
            var listOrderedItem = new List<OrderedItem>();
            listOrderedItem.Add(new OrderedItem() { K = -2000, V = new EmailAddress(Guid.NewGuid(), null, null) });
            listOrderedItem.Add(new OrderedItem() { K = 500000, V = new Person(Guid.NewGuid(), null, null) });
            listOrderedItem.Add(new OrderedItem() { K = 10000000, V = "hello" });

            this.testList = new OrderedItemList<Thing>(this.person, true);

            Assert.Throws<NotSupportedException>(() => this.testList.AddOrderedItems(listOrderedItem));
        }

        [Test]
        public void VerifyThatIndexOfReturnsTheExpectpedIndex()
        {
            this.testList = new OrderedItemList<Thing>(this.person, true);
            var email_0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email_1 = new EmailAddress(Guid.NewGuid(), null, null);
            var email_2 = new EmailAddress(Guid.NewGuid(), null, null);
            var email_notcontained = new EmailAddress(Guid.NewGuid(), null, null);

            this.testList.Add(email_0);
            this.testList.Add(email_1);
            this.testList.Add(email_2);

            Assert.AreEqual(0, this.testList.IndexOf(email_0));
            Assert.AreEqual(1, this.testList.IndexOf(email_1));
            Assert.AreEqual(2, this.testList.IndexOf(email_2));

            Assert.AreEqual(-1, this.testList.IndexOf(email_notcontained));
        }

        [Test]
        public void VerifyThatSameItemCannotBeAddedTwice()
        {
            var list = new OrderedItemList<Thing>(this.person, true);
            var email_0 = new EmailAddress(Guid.NewGuid(), null, null);
            
            list.Add(email_0);
            
            Assert.Throws<InvalidOperationException>(() => list.Add(email_0));
        }

        [Test]
        public void VerifyThatArgumentOutOfRangeIsThrownWhenIndexIsOutOfRange()
        {
            var list = new OrderedItemList<Thing>(this.person, false);
            EmailAddress email;
            Assert.Throws<ArgumentOutOfRangeException>(() => email = (EmailAddress)list[-1]);

            email = new EmailAddress(Guid.NewGuid(), null, null);
            list.Add(email);
            var invalidIndex = list.Count;
            Assert.Throws<ArgumentOutOfRangeException>(() => email = (EmailAddress)list[invalidIndex]);

            Assert.Throws<ArgumentOutOfRangeException>(() => list[-1] = email);
            Assert.Throws<ArgumentOutOfRangeException>(() => list[invalidIndex] = email);
        }

        [Test]
        public void VerifyThatArgumentNullExceptionWhenNullIsSet()
        {
            var list = new OrderedItemList<Thing>(this.person, false);
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            list.Add(email);
            Assert.Throws<ArgumentNullException>(() => list[0] = null);
        }

        [Test]
        public void VerifyThatNullCannotBeInserted()
        {
            var list = new OrderedItemList<Thing>(this.person, false);
            Assert.Throws<ArgumentNullException>(() =>list.Insert(1, null));
        }

        [Test]
        public void VerifyThatIfInsertAtIndexGreaterThatCountItemIsAppendedToList()
        {
            var list = new OrderedItemList<Thing>(this.person, false);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);
            list.Add(email1);

            var index = list.Count + 1;
            var email2 = new EmailAddress(Guid.NewGuid(), null, null);
            list.Insert(index, email2);

            Assert.AreSame(email1, list[0]);
            Assert.AreSame(email2, list[1]);
        }

        [Test]
        public void VerifyThatSameItemCannotBeAddedTwiceBis()
        {
            var list = new OrderedItemList<Thing>(this.person, true);
            var email_0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email_1 = new EmailAddress(Guid.NewGuid(), null, null);

            list.Add(email_0);
            list.Add(email_1);

            Assert.Throws<InvalidOperationException>(() => list[0] = email_1);
        }

        [Test]
        public void VerifyThatMoveWorks()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);
            var email2 = new EmailAddress(Guid.NewGuid(), null, null);
            var email3 = new EmailAddress(Guid.NewGuid(), null, null);
            var email4 = new EmailAddress(Guid.NewGuid(), null, null);
            
            testlist.Add(email0);
            testlist.Add(email1);
            testlist.Add(email2);
            testlist.Add(email3);
            testlist.Add(email4);

            Assert.AreSame(email0, testlist[0]);
            Assert.AreSame(email1, testlist[1]);
            Assert.AreSame(email2, testlist[2]);
            Assert.AreSame(email3, testlist[3]);
            Assert.AreSame(email4, testlist[4]);

            // move 1st to last
            testlist.Move(0, 4);
            Assert.AreSame(email1, testlist[0]);
            Assert.AreSame(email2, testlist[1]);
            Assert.AreSame(email3, testlist[2]);
            Assert.AreSame(email4, testlist[3]);
            Assert.AreSame(email0, testlist[4]);

            // move last to first
            testlist.Move(4, 0);
            Assert.AreSame(email0, testlist[0]);
            Assert.AreSame(email1, testlist[1]);
            Assert.AreSame(email2, testlist[2]);
            Assert.AreSame(email3, testlist[3]);
            Assert.AreSame(email4, testlist[4]);

            // does not do anything
            testlist.Move(0, 0);
            Assert.AreSame(email0, testlist[0]);
            Assert.AreSame(email1, testlist[1]);
            Assert.AreSame(email2, testlist[2]);
            Assert.AreSame(email3, testlist[3]);
            Assert.AreSame(email4, testlist[4]);
        }

        [Test]
        public void VerifyThatMoveThrowsException()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);

            testlist.Add(email0);
            testlist.Add(email1);

            Assert.Throws<KeyNotFoundException>(() => testlist.Move(-1, 1));
        }

        [Test]
        public void VerifyThatMoveThrowsException2()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);

            testlist.Add(email0);
            testlist.Add(email1);

            Assert.Throws<KeyNotFoundException>(() => testlist.Move(2, 1));
        }

        [Test]
        public void VerifyThatMoveThrowsException3()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);

            testlist.Add(email0);
            testlist.Add(email1);

            Assert.Throws<KeyNotFoundException>(() => testlist.Move(0, -1));
        }

        [Test]
        public void VerifyThatMoveThrowsException4()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);

            testlist.Add(email0);
            testlist.Add(email1);

            Assert.Throws<KeyNotFoundException>(() => testlist.Move(0, 3));
        }

        [Test]
        public void VerifyThatFindIndexWorks()
        {
            var testlist = new OrderedItemList<Thing>(this.person, true);
            var email0 = new EmailAddress(Guid.NewGuid(), null, null);
            var email1 = new EmailAddress(Guid.NewGuid(), null, null);

            testlist.Add(email0);
            testlist.Add(email1);

            Assert.AreEqual(0, testlist.FindIndex(x => x.Iid == email0.Iid));
            Assert.AreEqual(-1, testlist.FindIndex(x => x.Iid == Guid.NewGuid()));
            Assert.Throws<ArgumentNullException>(() => testlist.FindIndex(null));
        }
    }
}
