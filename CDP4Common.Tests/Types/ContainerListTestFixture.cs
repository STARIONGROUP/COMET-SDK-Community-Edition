// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerListTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
        private ContainerList<EmailAddress> emailAdresses; 
            
        [SetUp]
        public void Setup()
        {
            this.person = new Person(Guid.NewGuid(), null, null);
            this.emailAdresses = new ContainerList<EmailAddress>(this.person);
        }

        [TearDown]
        public void TearDown()
        {
            this.emailAdresses.Clear();
        }

        [Test]
        public void VerifyThatAddWorks()
        {
            var email = new EmailAddress(Guid.NewGuid(), null, null);

            this.emailAdresses.Add(email);

            Assert.AreEqual(1, this.emailAdresses.Count);
            Assert.AreEqual(this.person, this.emailAdresses.Single().Container);
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

            this.emailAdresses.AddRange(emails);

            Assert.AreEqual(3, this.emailAdresses.Count);
            foreach (var email in this.emailAdresses)
            {
                Assert.AreEqual(this.person, email.Container);
            }
        }

        [Test]
        public void VerifyThatGetSetAtIndexWorks()
        {
            this.emailAdresses.Add(new EmailAddress(Guid.NewGuid(), null, null));

            var email = new EmailAddress(Guid.NewGuid(), null, null);
            this.emailAdresses[0] = email;

            var returnedEmail = this.emailAdresses[0];

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