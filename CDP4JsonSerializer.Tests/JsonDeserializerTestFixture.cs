// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonDeserializerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET SDK Community Edition
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer.Tests.Helper;
    using CDP4JsonSerializer;

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
                Assert.That(def.Content, Is.EqualTo("abc \"hello world\""));
            }
        }

        [Test]
        public void VerifyThatDeserealizerParsesSiteDirectoryResponse()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory,  "TestData/SiteDirectory.json"));

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var returnedTested = this.serializer.Deserialize(stream);
                Assert.That(returnedTested.Count(), Is.EqualTo(445));
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

                Assert.That(statelist.PossibleState, Is.Not.Empty);
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

                Assert.That(arrayPt.Dimension, Is.Not.Empty);
                Assert.That(arrayPt.Dimension.Count, Is.Not.EqualTo(1));
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

                Assert.That(valueset.Manual, Is.Not.Empty);
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

            Assert.That(returned[0], Is.EqualTo("1"));
            Assert.That(returned[1], Is.EqualTo("2"));
            Assert.That(returned[2], Is.EqualTo("3"));
        }

        [Test]
        public void VerifyThatValueArrayConverterWorksSpecialChar()
        {
            var returned = CDP4JsonSerializer.SerializerHelper.ToValueArray<string>("[\"\\\"1,,,\\\",()\\\\\", \"2\\\"\", \"\\\"3\", \"testsimple\"]");

            Assert.That(returned[0], Is.EqualTo("\"1,,,\",()\\"));
            Assert.That(returned[1], Is.EqualTo("2\""));
            Assert.That(returned[2], Is.EqualTo("\"3"));
            Assert.That(returned[3], Is.EqualTo("testsimple"));
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

            Assert.That(valueset.Iid, Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-aa4b358f5d73")));
            Assert.That(valueset.RevisionNumber, Is.EqualTo(2679));
            Assert.That(valueset.ValueSwitch, Is.EqualTo(ParameterSwitchKind.MANUAL));
            Assert.That(valueset.SubscribedValueSet, Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-c74b308f5d73")));
            Assert.That(valueset.Manual[0], Is.EqualTo("123"));
            Assert.That(valueset.Manual[1], Is.EqualTo("456"));
            Assert.That(valueset.Manual[2], Is.EqualTo("789"));

            var pfsl = result.OfType<PossibleFiniteStateList>().Single();
            Assert.That(pfsl.Iid, Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-c74b158f5d73")));
            Assert.That(pfsl.RevisionNumber, Is.EqualTo(2679));
            Assert.That(pfsl.Name, Is.EqualTo("test"));
            Assert.That(pfsl.ShortName, Is.EqualTo("test1"));
            Assert.That(pfsl.Alias, Is.Empty);
            Assert.That(pfsl.Definition, Is.Empty);
            Assert.That(pfsl.HyperLink.Single(), Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-c74b333f5d73")));
            Assert.That(pfsl.Category, Is.Empty);
            Assert.That(pfsl.Owner, Is.EqualTo(new Guid("049abaf8-d550-44b1-3333-c74b358f5d73")));
            Assert.That(pfsl.DefaultState, Is.Null);
            Assert.That(pfsl.PossibleState[0].K, Is.EqualTo(123));
            Assert.That(pfsl.PossibleState[0].V, Is.EqualTo("049abaf8-9850-44b1-b32b-c74b358f5d73"));
            Assert.That(pfsl.PossibleState[1].K, Is.EqualTo(456));
            Assert.That(pfsl.PossibleState[1].V, Is.EqualTo("04978af8-d550-44b1-b32b-c74b358f5d73"));

            var arrayPt = result.OfType<ArrayParameterType>().Single();

            Assert.That(arrayPt.Iid, Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-c74b358a5d73")));
            Assert.That(arrayPt.RevisionNumber, Is.EqualTo(2679));
            Assert.That(arrayPt.Name, Is.EqualTo("array"));
            Assert.That(arrayPt.ShortName, Is.EqualTo("array1"));
            Assert.That(arrayPt.Alias, Is.Empty);
            Assert.That(arrayPt.Definition, Is.Empty);
            Assert.That(arrayPt.HyperLink, Is.Empty);
            Assert.That(arrayPt.Category[0], Is.EqualTo(new Guid("049abaf8-d550-44b1-b32b-c74ab58f5d73")));
            Assert.That(arrayPt.Category[1], Is.EqualTo(new Guid("0cdabaf8-d550-44b1-b32b-c74b358f5d73")));
            Assert.That(arrayPt.Symbol, Is.EqualTo("symbol"));
            Assert.That(arrayPt.Component[0].K, Is.EqualTo(123));
            Assert.That(arrayPt.Component[0].V, Is.EqualTo("049ab098-d550-44b1-b32b-c74b358f5d73"));
            Assert.That(arrayPt.IsFinalized, Is.False);
            Assert.That(arrayPt.IsDeprecated, Is.False);
            Assert.That(arrayPt.IsTensor, Is.True);
            Assert.That(arrayPt.Dimension[0].K, Is.EqualTo(1));
            Assert.That(arrayPt.Dimension[1].K, Is.EqualTo(2));
            Assert.That(arrayPt.Dimension[2].K, Is.EqualTo(3));
            Assert.That(arrayPt.Dimension[0].V, Is.EqualTo("1"));
            Assert.That(arrayPt.Dimension[1].V, Is.EqualTo("2"));
            Assert.That(arrayPt.Dimension[2].V, Is.EqualTo("3"));
        }
    }
}
