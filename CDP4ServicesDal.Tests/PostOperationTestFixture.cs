// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDeserializerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using CDP4Common;
    using CDP4Common.MetaInfo;
    using CDP4JsonSerializer;
    using CDP4Dal.Operations;
    using CDP4ServicesDal.Tests.Helper;
    using Newtonsoft.Json;
    using NUnit.Framework;

    [TestFixture]
    public class PostOperationTestFixture
    {
        private Cdp4JsonSerializer serializer;

        [SetUp]
        public void Setup()
        {
            var metamodel = new MetaDataProvider();
            this.serializer = new Cdp4JsonSerializer(metamodel, new Version(1, 1, 0));
        }

        [Test]
        public void Verify_that_deserialization_of_Post_Operation_does_not_throw_an_exception()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/PostOperation.json"));
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                Assert.DoesNotThrow(() => this.serializer.Deserialize<TestPostOperation>(stream));
            }
        }

        private class TestPostOperation : PostOperation
        {
            public override void ConstructFromOperation(Operation operation)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Gets or sets the collection of DTOs to delete.
            /// </summary>
            [JsonProperty("_delete")]
            public override List<ClasslessDTO> Delete { get; set; }

            /// <summary>
            /// Gets or sets the collection of DTOs to create.
            /// </summary>
            [JsonProperty("_create")]
            public override List<CDP4Common.DTO.Thing> Create { get; set; }

            /// <summary>
            /// Gets or sets the collection of DTOs to update.
            /// </summary>
            [JsonProperty("_update")]
            public override List<ClasslessDTO> Update { get; set; }

            /// <summary>
            /// Gets or sets the collection of DTOs to update.
            /// </summary>
            [JsonProperty("_copy")]
            public override List<ClasslessDTO> Copy { get; set; }
        }
    }
}
