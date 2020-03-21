// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerListTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    public class ContainerListTestFixture
    {
        private Person person;
        private ContainerList<EmailAddress> emailAddresses; 
            
        [SetUp]
        public void Setup()
        {
            this.person = new Person(Guid.NewGuid(), null, null);
            this.emailAddresses = new ContainerList<EmailAddress>(this.person);
        }

        [TearDown]
        public void TearDown()
        {
            this.emailAddresses.Clear();
        }

        [Test]
        public void VerifyThatAddWorks()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);

            this.emailAddresses.Add(email);

            Assert.AreEqual(1, this.emailAddresses.Count);
            Assert.AreEqual(this.person, this.emailAddresses.Single().Container);
        }

        [Test]
        public void VerifyThatAddRangeWorks()
        {
            var emails = new List<EmailAddress>
            {
                new EmailAddress(Guid.NewGuid(), null, null),
                new EmailAddress(Guid.NewGuid(), null, null),
                new EmailAddress(Guid.NewGuid(), null, null)
            };

            this.emailAddresses.AddRange(emails);

            Assert.AreEqual(3, this.emailAddresses.Count);
            foreach (var email in this.emailAddresses)
            {
                Assert.AreEqual(this.person, email.Container);
            }
        }

        [Test]
        public void VerifyThatGetSetAtIndexWorks()
        {
            this.emailAddresses.Add(new EmailAddress(Guid.NewGuid(), null, null));

            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.emailAddresses[0] = email;

            var returnedEmail = this.emailAddresses[0];

            Assert.AreEqual(this.person, returnedEmail.Container);
            Assert.AreEqual(email.Iid, returnedEmail.Iid);
        }

        [Test]
        public void VerifyThatContainerSetToClone()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            
            var clone = this.person.Clone(false);
            Assert.AreSame(this.person, email.Container);

            clone.EmailAddress.Clear();
            clone.EmailAddress.Add(email);
            Assert.AreSame(clone, email.Container);
        }

        [Test]
        public void VerifyThatGetIndexerThrowsExceptionWhenArgumentOutOfRange()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            var invalidIndex = this.person.EmailAddress.Count;

            Assert.Throws<ArgumentOutOfRangeException>(() => email = this.person.EmailAddress[invalidIndex]);
        }

        [Test]
        public void VerifyThatSetIndexerThrowsExceptionWhenArgumentOutOfRange()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            var invalidIndex = this.person.EmailAddress.Count;
            
            Assert.Throws<ArgumentOutOfRangeException>(() => this.person.EmailAddress[invalidIndex] = email);
        }

        [Test]
        public void VerifyThatSetIndexerThrowsExceptionIfValueIsNull()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);

            Assert.Throws<ArgumentNullException>(() => this.person.EmailAddress[0] = null);
        }

        [Test]
        public void VerifyThatIfContainedItemAddedMoreThatInvalidOperationExceptionIsThrown()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);

            var otheremail = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(otheremail);

            Assert.Throws<InvalidOperationException>(() => this.person.EmailAddress.Add(email));

            Assert.Throws<InvalidOperationException>(() => this.person.EmailAddress[1] = email);
        }
    }
}