#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActualFiniteStateTestFixture.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4JsonSerializer_New.Tests
{
    using System;
    using System.IO;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using NUnit.Framework;

    using ActualFiniteState = CDP4Common.DTO.ActualFiniteState;

    /// <summary>
    /// Suite of tests for the <see cref="CDP4JsonSerializer_New.ActualFiniteState"/>
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
            var serializer = new CDP4JsonSerializer(new MetaDataProvider(), new Version("1.1.0"));

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
