// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SessionTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4WspDal.Tests
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Dal;
    using CDP4Dal.DAL;

    using NUnit.Framework;
    
    using Thing = CDP4Common.DTO.Thing;

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

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("https://cdp4services-test.cdp4.org");
            this.credentials = new Credentials("admin", "pass", this.uri);

            this.tokenSource = new CancellationTokenSource();
        }

        [TearDown]
        public void TearDown()
        {
            CDPMessageBus.Current.ClearSubscriptions();
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
            this.session = new Session(dal, this.credentials);

            Assert.AreEqual(0, this.session.Assembler.Cache.Count); 
            
            await session.Open();

            Assert.AreNotEqual(0, this.session.Assembler.Cache.Count);
        }
    }
}