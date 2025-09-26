﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerListTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

            Assert.That(this.emailAddresses.Count, Is.EqualTo(1));
            Assert.That(this.emailAddresses.Single().Container, Is.EqualTo(this.person));
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

            Assert.That(this.emailAddresses.Count, Is.EqualTo(3));
            foreach (var email in this.emailAddresses)
            {
                Assert.That(email.Container, Is.EqualTo(this.person));
            }
        }

        [Test]
        public void VerifyThatGetSetAtIndexWorks()
        {
            this.emailAddresses.Add(new EmailAddress(Guid.NewGuid(), null, null));

            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.emailAddresses[0] = email;

            var returnedEmail = this.emailAddresses[0];

            Assert.That(returnedEmail.Container, Is.EqualTo(this.person));
            Assert.That(returnedEmail.Iid, Is.EqualTo(email.Iid));
        }

        [Test]
        public void VerifyThatContainerSetToClone()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            
            var clone = this.person.Clone(false);
            Assert.That(this.person, Is.SameAs(email.Container));

            clone.EmailAddress.Clear();
            clone.EmailAddress.Add(email);
            Assert.That(clone, Is.SameAs(email.Container));
        }

        [Test]
        public void VerifyThatGetIndexerThrowsExceptionWhenArgumentOutOfRange()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            var invalidIndex = this.person.EmailAddress.Count;

            Assert.That(() => email = this.person.EmailAddress[invalidIndex], Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void VerifyThatSetIndexerThrowsExceptionWhenArgumentOutOfRange()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);
            var invalidIndex = this.person.EmailAddress.Count;
            
            Assert.That(() => this.person.EmailAddress[invalidIndex] = email, Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void VerifyThatSetIndexerThrowsExceptionIfValueIsNull()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);

            Assert.That(() => this.person.EmailAddress[0] = null, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void VerifyThatIfContainedItemAddedMoreThatInvalidOperationExceptionIsThrown()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(email);

            var otheremail = new EmailAddress(Guid.NewGuid(), null, null);
            this.person.EmailAddress.Add(otheremail);

            Assert.That(() => this.person.EmailAddress.Add(email), Throws.TypeOf<InvalidOperationException>());

            Assert.That(() => this.person.EmailAddress[1] = email, Throws.TypeOf<InvalidOperationException>());
        }
    }
}