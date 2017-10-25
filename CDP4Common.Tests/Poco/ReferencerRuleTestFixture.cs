// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferencerRuleTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ReferencerRule"/> class
    /// </summary>
    [TestFixture]
    public class ReferencerRuleTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;
        private Iteration iteration;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
        }

        [Test]
        public void VerifyThatTheVerifyMethodThrowsNotSupportedException()
        {
            var rule = new ReferencerRule(Guid.NewGuid(), this.cache, this.uri);
            Assert.Throws<NotSupportedException>(() => rule.Verify(this.iteration));
        }
    }
}
