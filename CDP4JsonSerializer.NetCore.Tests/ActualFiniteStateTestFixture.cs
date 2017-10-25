// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests
{
    using System;
    using System.IO;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using NUnit.Framework;

    using ActualFiniteState = CDP4Common.DTO.ActualFiniteState;

    /// <summary>
    /// Suite of tests for the <see cref="CDP4JsonSerializer.ActualFiniteState"/>
    /// </summary>
    [TestFixture]
    public  class ActualFiniteStateTestFixture
    {
        private Guid possibleStateId_1;
        private Guid possibleStateId_2;
        private Guid actualFiniteStateId;
        private CDP4Common.DTO.ActualFiniteState actualFiniteState;
        
        [SetUp]
        public void SetUp()
        {
            this.possibleStateId_1 = Guid.Parse("1d208dff-d9fb-4abe-83d1-83b70eb2e9e9");
            this.possibleStateId_2 = Guid.Parse("2d208dff-d9fb-4abe-83d1-83b70eb2e9e9");
            this.actualFiniteStateId = Guid.Parse("b31df883-6c03-4401-bcd9-da729f87df55");
            this.actualFiniteState = new ActualFiniteState(this.actualFiniteStateId, 1)
                                         {
                                             ModifiedOn =  DateTime.Parse("1976-08-20T12:01:02"),
                                             Kind = ActualFiniteStateKind.FORBIDDEN
                                         };
            this.actualFiniteState.PossibleState.Add(this.possibleStateId_1);
            this.actualFiniteState.PossibleState.Add(this.possibleStateId_2);
        }

        [Test]
        public void VerifyThatExpectedJsonIsReturned()
        {
            var serializer = new Cdp4JsonSerializer(new MetaDataProvider(), new Version("1.1.0"));

            var expectedResult = "{\"iid\":\"b31df883-6c03-4401-bcd9-da729f87df55\",\"revisionNumber\":1,\"classKind\":\"ActualFiniteState\",\"modifiedOn\":\"1976-08-20T12:01:02.000Z\",\"possibleState\":[\"1d208dff-d9fb-4abe-83d1-83b70eb2e9e9\",\"2d208dff-d9fb-4abe-83d1-83b70eb2e9e9\"],\"kind\":\"FORBIDDEN\",\"excludedDomain\":[],\"excludedPerson\":[]}";

            using (var stream = new MemoryStream())
            {
                serializer.SerializeToStream(this.actualFiniteState, stream);
                stream.Position = 0;

                using (var reader = new StreamReader(stream))
                {
                    var result = reader.ReadToEnd();
                    Console.WriteLine(result);
                    Assert.AreEqual(expectedResult.Length, result.Length);
                }
            }
        }
    }
}
