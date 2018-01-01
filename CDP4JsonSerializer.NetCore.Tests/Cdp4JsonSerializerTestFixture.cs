// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4JsonSerializerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System  S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests
{
    using System;
    using System.IO;
    using CDP4Common.CommonData;
    using CDP4Common.MetaInfo;
    using CDP4JsonSerializer.Tests.Helper;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Cdp4JsonSerializer"/> class
    /// </summary>
    [TestFixture]
    public class Cdp4JsonSerializerTestFixture
    {
        [Test]
        public void Verify_serializestream_throws_exception_when_metadata_and_version_not_set()
        {
            var definition = new Definition();

            using (var stream = new MemoryStream())
            {
                var cdp4JsonSerializer = new Cdp4JsonSerializer();

                Assert.Throws<InvalidOperationException>(() => cdp4JsonSerializer.SerializeToStream(definition, stream));

                Assert.Throws<InvalidOperationException>(() => cdp4JsonSerializer.SerializeToStream(definition, stream, false));
            }
        }

        [Test]
        public void Verify_that_serializestream_null_parameters_throws_exception()
        {
            var metadataprovider = new MetaDataProvider();

            var cdp4JsonSerializer = new Cdp4JsonSerializer();
            cdp4JsonSerializer.Initialize(metadataprovider, new Version(1,0,0));
            
            Assert.Throws<ArgumentNullException>(() => cdp4JsonSerializer.SerializeToStream(null, null));
        }

        [Test]
        public void Verify_that_thing_serializestream_null_parameters_throws_exception()
        {
            var metadataprovider = new MetaDataProvider();

            var cdp4JsonSerializer = new Cdp4JsonSerializer();
            cdp4JsonSerializer.Initialize(metadataprovider, new Version(1, 0, 0));

            Definition definition = null;
            Assert.Throws<ArgumentNullException>(() => cdp4JsonSerializer.SerializeToStream(definition, null, false));

            definition = new Definition();
            Assert.Throws<ArgumentNullException>(() => cdp4JsonSerializer.SerializeToStream(definition, null, false));
        }

        [Test]
        public void Verify_serializestring_throws_exception_when_metadata_and_version_not_set()
        {
            var definition = new Definition();
            
            var cdp4JsonSerializer = new Cdp4JsonSerializer();

            Assert.Throws<InvalidOperationException>(() => cdp4JsonSerializer.SerializeToString(definition, false));
        }

        [Test]
        public void Verify_that_deserialize_throws_exception()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/SiteDirectory.json"));
            var cdp4JsonSerializer = new Cdp4JsonSerializer();
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                Assert.Throws<InvalidOperationException>(() => cdp4JsonSerializer.Deserialize(stream));
            }
        }
    }
}
