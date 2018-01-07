// -------------------------------------------------------------------------------------------------
// <copyright file="SessionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2015 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

using System.Linq;

namespace CDP4WspDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    using CDP4Common.MetaInfo;
    using CDP4Dal;
    using CDP4Dal.DAL;
    using Moq;
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
            this.uri = new Uri("https://cdp4services-test.rheagroup.com");
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
        [Category("WSP_dependent")]
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