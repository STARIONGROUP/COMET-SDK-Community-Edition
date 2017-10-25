// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CitationTestFixture.cs" company="RHEA System S.A.">
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
    /// suite of tests for the <see cref="Category"/>
    /// </summary>
    [TestFixture]
    public class CitationTestFixture
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
        public void VerifyThatGetRequiredRdlsWorks()
        {
            var srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var mrdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            var srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);

            var source = new ReferenceSource(Guid.NewGuid(), this.cache, this.uri);

            mrdl.RequiredRdl = srdl1;
            srdl2.RequiredRdl = srdl1;

            mrdl.ReferenceSource.Add(source);
            var citation = new Citation(Guid.NewGuid(), this.cache, this.uri);
            citation.Source = source;

            Assert.IsTrue(citation.RequiredRdls.Contains(srdl1));
            Assert.IsTrue(citation.RequiredRdls.Contains(mrdl));
            Assert.IsFalse(citation.RequiredRdls.Contains(srdl2));
        }
    }
}
