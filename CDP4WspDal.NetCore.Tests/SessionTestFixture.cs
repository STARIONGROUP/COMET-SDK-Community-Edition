// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4WspDal.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Dal;
    using CDP4Dal.DAL;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Session"/> class
    /// </summary>
    [TestFixture]
    public class SessionTestFixture
    {
        /// <summary>
        /// The uri of the mocked <see cref="IDal"/>
        /// </summary>
        private Uri uri;

        /// <summary>
        /// The <see cref="Session"/> object under test
        /// </summary>
        private Session session;

        private Credentials credentials;
        private CancellationTokenSource tokenSource;
        private CDPMessageBus messageBus;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("https://cdp4services-test.cdp4.org");
            this.credentials = new Credentials("admin", "pass", this.uri);
            this.messageBus = new CDPMessageBus();
            this.tokenSource = new CancellationTokenSource();
        }

        [TearDown]
        public void TearDown()
        {
            this.messageBus.ClearSubscriptions();
        }

        /// <summary>
        /// The test uncaught operation cancelled exception.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [Test]
        [Category("WebServicesDependent")]
        public async Task Verify_That_Session_Open_Populates_cache()
        {
            var dal = new WspDal();
            this.session = new Session(dal, this.credentials, this.messageBus);

            Assert.AreEqual(0, this.session.Assembler.Cache.Count);

            await this.session.Open();

            Assert.AreNotEqual(0, this.session.Assembler.Cache.Count);
        }
    }
}
