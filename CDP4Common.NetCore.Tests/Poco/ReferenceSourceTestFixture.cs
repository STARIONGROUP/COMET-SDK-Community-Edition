// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceSourceTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Concurrent;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// suite of tests for the <see cref="ReferenceSource"/> class.
    /// </summary>
    [TestFixture]
    public class ReferenceSourceTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();
        }

        [Test]
        public void VerifyThatGetRequiredRdlsReturnsExpectedResults()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl1_1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);

            var referenceSource = new ReferenceSource(Guid.NewGuid(), this.cache, this.uri);

            srdl1_1.RequiredRdl = srdl1;
            mrdl.RequiredRdl = srdl1_1;
            srdl2.RequiredRdl = srdl1;

            mrdl.ReferenceSource.Add(referenceSource);

            var requiredRdls = referenceSource.RequiredRdls.ToList();

            Assert.IsTrue(requiredRdls.Contains(mrdl));
            Assert.IsTrue(requiredRdls.Contains(srdl1_1));
            Assert.IsTrue(requiredRdls.Contains(srdl1));

            Assert.IsFalse(requiredRdls.Contains(srdl2));
        }
    }
}
