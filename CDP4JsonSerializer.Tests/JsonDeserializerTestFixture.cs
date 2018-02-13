#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDeserializerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4JsonSerializer.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;
    using CDP4JsonSerializer.Tests.Helper;
    using CDP4JsonSerializer;
    using Newtonsoft.Json;
    using NUnit.Framework;
    using File = System.IO.File;
    using ParameterSubscriptionValueSet = CDP4Common.DTO.ParameterSubscriptionValueSet;
    using PossibleFiniteStateList = CDP4Common.DTO.PossibleFiniteStateList;

    /// <summary>
    /// Suite of tests for the <see cref="JsonDeserializer"/> class
    /// </summary>
    [TestFixture]
    public class JsonDeserializerTestFixture
    {
        private Cdp4JsonSerializer serializer;

        [SetUp]
        public void Setup()
        {
            var metamodel = new MetaDataProvider();
            this.serializer = new Cdp4JsonSerializer(metamodel, new Version(1, 1, 0));
        }

        [Test]
        public void VerifyThatDeserializingSpecialCharWorks()
        {
            var response = "[{\"citation\":[],\"classKind\":\"Definition\",\"content\":\"abc \\\"hello world\\\"\",\"example\":[],\"iid\":\"2fa9d296-37e6-4bc3-9710-ad6b93327792\",\"languageCode\":null,\"note\":[],\"revisionNumber\":1}]";
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returnedTested = this.serializer.Deserialize(stream);
                var def = returnedTested.OfType<CDP4Common.DTO.Definition>().Single();
                Assert.AreEqual("abc \"hello world\"", def.Content);
            }
        }

        [Test]
        public void VerifyThatDeserealizerParsesSiteDirectoryResponse()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory,  "TestData/SiteDirectory.json"));

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returnedTested = this.serializer.Deserialize(stream);
                Assert.AreEqual(445, returnedTested.Count());
            }
        }

        [Test]
        public void VerifyDeserializeOrderedItemWorks()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/LOFT_EngineeringModel.json"));
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returned = this.serializer.Deserialize(stream);
                var statelist = (CDP4Common.DTO.PossibleFiniteStateList)returned.First(dto => dto.ClassKind == ClassKind.PossibleFiniteStateList);

                Assert.IsNotEmpty(statelist.PossibleState);
            }
        }

        [Test]
        public void VerifyThatOrderedItemIntWorks()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/LOFT_EngineeringModel.json"));

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returned = this.serializer.Deserialize(stream);

                var arrayPt = (CDP4Common.DTO.ArrayParameterType)returned.First(dto => dto.ClassKind == ClassKind.ArrayParameterType);

                Assert.IsNotEmpty(arrayPt.Dimension);
                Assert.AreNotEqual(1, arrayPt.Dimension.Count);
            }
        }

        [Test]
        public void VerifyThatDeserializeValueArrayWorks()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/LOFT_EngineeringModel.json"));
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returned = this.serializer.Deserialize(stream);
                var valueset = (CDP4Common.DTO.ParameterValueSet)returned.First(dto => dto.ClassKind == ClassKind.ParameterValueSet);
                Assert.IsNotEmpty(valueset.Manual);
            }
        }

        [Test]
        public void VerifyThatDeserializeBigModelWorks()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/bigmodel.json"));
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                Assert.DoesNotThrow(() => this.serializer.Deserialize(stream));
            }
        }

        [Test]
        public void VerifyThatValueArrayConverterWorks()
        {
            var returned = CDP4JsonSerializer.SerializerHelper.ToValueArray<string>("[\"1\", \"2\", \"3\"]");
            Assert.AreEqual(returned[0], "1");
            Assert.AreEqual(returned[1], "2");
            Assert.AreEqual(returned[2], "3");
        }

        [Test]
        public void VerifyThatDeserializeWorksOnAnyType()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/jsonTestSample.json")).Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Trim();
            IReadOnlyList<CDP4Common.DTO.Thing> result;
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                result = this.serializer.Deserialize(stream).ToList();
            }

            var valueset = result.OfType<ParameterSubscriptionValueSet>().Single();
            Assert.AreEqual(valueset.Iid, new Guid("049abaf8-d550-44b1-b32b-aa4b358f5d73"));
            Assert.AreEqual(valueset.RevisionNumber, 2679);
            Assert.AreEqual(valueset.ValueSwitch, ParameterSwitchKind.MANUAL);
            Assert.AreEqual(valueset.SubscribedValueSet, new Guid("049abaf8-d550-44b1-b32b-c74b308f5d73"));
            Assert.AreEqual(valueset.Manual[0], "123");
            Assert.AreEqual(valueset.Manual[1], "456");
            Assert.AreEqual(valueset.Manual[2], "789");

            var pfsl = result.OfType<PossibleFiniteStateList>().Single();
            Assert.AreEqual(pfsl.Iid, new Guid("049abaf8-d550-44b1-b32b-c74b158f5d73"));
            Assert.AreEqual(pfsl.RevisionNumber, 2679);
            Assert.AreEqual(pfsl.Name, "test");
            Assert.AreEqual(pfsl.ShortName, "test1");
            Assert.AreEqual(pfsl.Alias.Count, 0);
            Assert.AreEqual(pfsl.Definition.Count, 0);
            Assert.AreEqual(pfsl.HyperLink.Single(), new Guid("049abaf8-d550-44b1-b32b-c74b333f5d73"));
            Assert.AreEqual(pfsl.Category.Count, 0);
            Assert.AreEqual(pfsl.Owner, new Guid("049abaf8-d550-44b1-3333-c74b358f5d73"));
            Assert.IsNull(pfsl.DefaultState);
            Assert.AreEqual(pfsl.PossibleState[0].K, 123);
            Assert.AreEqual(pfsl.PossibleState[0].V, "049abaf8-9850-44b1-b32b-c74b358f5d73");
            Assert.AreEqual(pfsl.PossibleState[1].K, 456);
            Assert.AreEqual(pfsl.PossibleState[1].V, "04978af8-d550-44b1-b32b-c74b358f5d73");

            var arrayPt = result.OfType<ArrayParameterType>().Single();
            Assert.AreEqual(arrayPt.Iid, new Guid("049abaf8-d550-44b1-b32b-c74b358a5d73"));
            Assert.AreEqual(arrayPt.RevisionNumber, 2679);
            Assert.AreEqual(arrayPt.Name, "array");
            Assert.AreEqual(arrayPt.ShortName, "array1");
            Assert.AreEqual(arrayPt.Alias.Count, 0);
            Assert.AreEqual(arrayPt.Definition.Count, 0);
            Assert.AreEqual(arrayPt.HyperLink.Count, 0);
            Assert.AreEqual(arrayPt.Category[0], new Guid("049abaf8-d550-44b1-b32b-c74ab58f5d73"));
            Assert.AreEqual(arrayPt.Category[1], new Guid("0cdabaf8-d550-44b1-b32b-c74b358f5d73"));
            Assert.AreEqual(arrayPt.Symbol, "symbol");
            Assert.AreEqual(arrayPt.Component[0].K, 123);
            Assert.AreEqual(arrayPt.Component[0].V, "049ab098-d550-44b1-b32b-c74b358f5d73");
            Assert.IsFalse(arrayPt.IsFinalized);
            Assert.IsFalse(arrayPt.IsDeprecated);
            Assert.IsTrue(arrayPt.IsTensor);
            Assert.AreEqual(arrayPt.Dimension[0].K, 1);
            Assert.AreEqual(arrayPt.Dimension[1].K, 2);
            Assert.AreEqual(arrayPt.Dimension[2].K, 3);
            Assert.AreEqual(arrayPt.Dimension[1].V, "2");
            Assert.AreEqual(arrayPt.Dimension[0].V, "1");
            Assert.AreEqual(arrayPt.Dimension[2].V, "3");
        }
    }
}
