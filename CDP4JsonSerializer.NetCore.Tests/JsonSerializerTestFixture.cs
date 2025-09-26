// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4JsonSerializer.Tests.Helper;

    using Newtonsoft.Json;

    using NUnit.Framework;

    using Dto = CDP4Common.DTO;
    using File = System.IO.File;

    [TestFixture]
    public class JsonSerializerTestFixture
    {
        private EngineeringModel engModel;
        private Book book1;
        private Book book2;
        private Section section1;
        private readonly Uri uri = new Uri("http://www.stariongroup.eu");
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();
        private IMetaDataProvider metadataprovider = new MetaDataProvider();
        private Cdp4JsonSerializer serializer;
        private SiteDirectory siteDir;
        private SiteReferenceDataLibrary rdl;
        private Category category1;
        private Category category2;

        [SetUp]
        public void Setup()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            this.siteDir = new SiteDirectory(Guid.NewGuid(), this.cache, this.uri);
            this.rdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            this.rdl.Container = this.siteDir;

            this.category1 = new Category(Guid.NewGuid(), this.cache, this.uri);
            this.category2 = new Category(Guid.NewGuid(), this.cache, this.uri);
            this.rdl.DefinedCategory.AddRange(new[] { this.category1, this.category2 });

            this.category1.PermissibleClass.AddRange(new[] { ClassKind.BinaryRelationship, ClassKind.ElementDefinition });
            this.category2.PermissibleClass.AddRange(new[] { ClassKind.BinaryRelationship, ClassKind.ElementDefinition, ClassKind.Page });
        }

        [Test]
        public void VerifyThatNullDatetimeSerializationWorks()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));
            var iterationsetup = new Dto.IterationSetup(Guid.NewGuid(), 1);

            iterationsetup.FrozenOn = null;

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { iterationsetup }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();
            Assert.That(txt, Does.Contain("\"frozenOn\":null"));
        }

        [Test]
        public void VerifyThatSerializeTimeCorrectly()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var sitedir = new Dto.SiteDirectory(Guid.NewGuid(), 1);

            sitedir.LastModifiedOn = DateTime.Parse("2222-02-02T22:22:22.222222");

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { sitedir }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();
                    
            Assert.That(txt, Does.Not.Contain("2222-02-02T22:22:22.222222"));
            Assert.That(txt, Does.Contain("2222-02-02T22:22:22.222Z"));
        }

        [Test]
        public void VerifyThatSpecialStringcharAreSerializedCorrectly()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var definition = new Dto.Definition(Guid.NewGuid(), 1);

            definition.Content = "abc \"hello world\"";

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { definition }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();

            Assert.That(txt, Does.Contain("abc \\\"hello world\\\""));
        }

        [Test]
        public void VerifyThatValueArrayAreSerializedCorrectly()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var parameterValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 1);
            var valuearray = new[] { "123", "abc" };

            parameterValueSet.Manual = new ValueArray<string>(valuearray);
            parameterValueSet.Computed = new ValueArray<string>(valuearray);
            parameterValueSet.Reference = new ValueArray<string>(valuearray);
            parameterValueSet.Published = new ValueArray<string>(valuearray);

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { parameterValueSet }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();

            // output:  "manual":"[\"123\",\"abc\"]"
            Assert.That(txt, Does.Contain("\"manual\":\"[\\\"123\\\",\\\"abc\\\"]\""));
        }

        [Test]
        public void VerifyThatValueArrayAreSerializedCorrectlyWithSpecialChar()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var parameterValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 1);
            var valuearray = new[] { "123\"(,)\"", "abc\\" };

            parameterValueSet.Manual = new ValueArray<string>(valuearray);
            parameterValueSet.Computed = new ValueArray<string>(valuearray);
            parameterValueSet.Reference = new ValueArray<string>(valuearray);
            parameterValueSet.Published = new ValueArray<string>(valuearray);

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { parameterValueSet }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();

            // output:  "manual":"[\"123\",\"abc\"]"
            Assert.That(txt, Does.Contain("\"manual\":\"[\\\"123\\\\\\\"(,)\\\\\\\"\\\",\\\"abc\\\\\\\\\\\"]\""));

            memoryStream.Position = 0;
            var thing = (Dto.ParameterValueSet)this.serializer.Deserialize(memoryStream).Single();
            Assert.That(parameterValueSet.Manual[0], Is.EqualTo(thing.Manual[0]));
            Assert.That(parameterValueSet.Manual[1], Is.EqualTo(thing.Manual[1]));

            Assert.That(parameterValueSet.Computed[0], Is.EqualTo(thing.Computed[0]));
            Assert.That(parameterValueSet.Computed[1], Is.EqualTo(thing.Computed[1]));

            Assert.That(parameterValueSet.Reference[0], Is.EqualTo(thing.Reference[0]));
            Assert.That(parameterValueSet.Reference[1], Is.EqualTo(thing.Reference[1]));

            Assert.That(parameterValueSet.Published[0], Is.EqualTo(thing.Published[0]));
            Assert.That(parameterValueSet.Published[1], Is.EqualTo(thing.Published[1]));
        }

        [Test]
        public void VerifyThatEnumAreSeserializeCorrectly()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var email = new Dto.EmailAddress(Guid.NewGuid(), 1);
            email.Value = "test";
            email.VcardType = 0;

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { email }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();
            Assert.That(txt, Does.Contain("WORK"));
        }

        [Test]
        public void VerifyThatEnumAreSeserializeCorrectly2()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var email = new Dto.EmailAddress(Guid.NewGuid(), 1);
            email.Value = "test";
            email.VcardType = VcardEmailAddressKind.HOME;

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { email }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();
            Assert.That(txt, Does.Contain("HOME"));
        }

        [Test]
        public void VerifyThatEnumAreSeserializeCorrectly3()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var email = new Dto.TelephoneNumber(Guid.NewGuid(), 1);
            email.Value = "test";
            email.VcardType.Add((VcardTelephoneNumberKind)5);
            email.VcardType.Add((VcardTelephoneNumberKind)4);

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(new[] { email }, memoryStream);
            memoryStream.Position = 0;

            using var reader = new StreamReader(memoryStream);

            var txt = reader.ReadToEnd();
            Assert.That(txt, Does.Contain("CELL"));
            Assert.That(txt, Does.Contain("FAX"));
        }

        [Test]
        public void VerifyThatSerializationOfDtosWorks()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 1, 0));

            this.engModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            this.book1 = new Book(Guid.NewGuid(), this.cache, this.uri);
            this.book2 = new Book(Guid.NewGuid(), this.cache, this.uri);
            this.section1 = new Section(Guid.NewGuid(), this.cache, this.uri);
            this.section1.ShortName = "SS1";

            this.engModel.Book.Add(this.book1);
            this.engModel.Book.Add(this.book2);
            this.book2.Section.Add(this.section1);

            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var ed = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            var parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri);
            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(), this.cache, this.uri);
            var valueset = new ParameterValueSet(Guid.NewGuid(), this.cache, this.uri);
            var subscriptionValueset = new ParameterSubscriptionValueSet(Guid.NewGuid(), this.cache, this.uri);
            var valuearrayvalues = new[] { "123", "456", "789.0" };

            valueset.Manual = new ValueArray<string>(valuearrayvalues);
            valueset.Reference = new ValueArray<string>(valuearrayvalues);
            valueset.Computed = new ValueArray<string>(valuearrayvalues);
            valueset.Formula = new ValueArray<string>(valuearrayvalues);
            valueset.Published = new ValueArray<string>(valuearrayvalues);

            subscriptionValueset.Manual = new ValueArray<string>(valuearrayvalues);

            this.engModel.Iteration.Add(iteration);
            iteration.Element.Add(ed);
            ed.Parameter.Add(parameter);
            parameter.ValueSet.Add(valueset);
            parameter.ParameterSubscription.Add(parameterSubscription);
            parameterSubscription.ValueSet.Add(subscriptionValueset);

            var list = new List<Dto.Thing>
            {
                this.engModel.ToDto(),
                this.book1.ToDto(),
                this.book2.ToDto(),
                this.section1.ToDto(),
                iteration.ToDto(),
                ed.ToDto(),
                parameter.ToDto(),
                parameterSubscription.ToDto(),
                valueset.ToDto(),
                subscriptionValueset.ToDto()
            };

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(list, memoryStream);

            // necessary
            memoryStream.Position = 0;

            var resDtos = this.serializer.Deserialize(memoryStream).ToList();

            Assert.That(resDtos.Count, Is.EqualTo(10));

            var resEngineeringModel = resDtos.OfType<Dto.EngineeringModel>().Single();
            var resBook2 = resDtos.OfType<Dto.Book>().Single(x => x.Iid == this.book2.Iid);
            var resSection = resDtos.OfType<Dto.Section>().Single();
            var resSubscriptionValueset = resDtos.OfType<Dto.ParameterSubscriptionValueSet>().Single();

            Assert.That(this.section1.ShortName, Is.EqualTo(resSection.ShortName));
            Assert.That(resBook2.Section.Any(x => x.V.ToString() == this.section1.Iid.ToString()), Is.True);
            Assert.That(resEngineeringModel.Book.Any(x => x.V.ToString() == this.book1.Iid.ToString()), Is.True);
            Assert.That(resEngineeringModel.Book.Any(x => x.V.ToString() == this.book2.Iid.ToString()), Is.True);
            Assert.That(resSubscriptionValueset.Manual, Is.EqualTo(new ValueArray<string>(valuearrayvalues)));
        }

        [Test]
        public void VerifyThatSerializationofOperationsWorks()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 1, 0));

            var postoperation = new TestPostOperation();
            this.engModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            this.book1 = new Book(Guid.NewGuid(), this.cache, this.uri);
            this.book2 = new Book(Guid.NewGuid(), this.cache, this.uri);
            this.section1 = new Section(Guid.NewGuid(), this.cache, this.uri);
            this.section1.ShortName = "SS1";

            this.engModel.Book.Add(this.book1);
            this.engModel.Book.Add(this.book2);
            this.book2.Section.Add(this.section1);

            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            var ed = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            var parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri);
            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(), this.cache, this.uri);
            var valueset = new ParameterValueSet(Guid.NewGuid(), this.cache, this.uri);
            var subscriptionValueset = new ParameterSubscriptionValueSet(Guid.NewGuid(), this.cache, this.uri);
            var valuearrayvalues = new[] { "123", "456", "789.0" };

            valueset.Manual = new ValueArray<string>(valuearrayvalues);
            valueset.Reference = new ValueArray<string>(valuearrayvalues);
            valueset.Computed = new ValueArray<string>(valuearrayvalues);
            valueset.Formula = new ValueArray<string>(valuearrayvalues);
            valueset.Published = new ValueArray<string>(valuearrayvalues);

            subscriptionValueset.Manual = new ValueArray<string>(valuearrayvalues);
            subscriptionValueset.SubscribedValueSet = valueset;

            this.engModel.Iteration.Add(iteration);
            iteration.Element.Add(ed);
            ed.Parameter.Add(parameter);
            parameter.ValueSet.Add(valueset);
            parameter.ParameterSubscription.Add(parameterSubscription);
            parameterSubscription.ValueSet.Add(subscriptionValueset);

            postoperation.Update.Add(ClasslessDtoFactory.FullFromThing(this.metadataprovider, subscriptionValueset.ToDto()));
            postoperation.Update.Add(ClasslessDtoFactory.FullFromThing(this.metadataprovider, parameterSubscription.ToDto()));
            postoperation.Create.Add(valueset.ToDto());
            postoperation.Delete.Add(ClasslessDtoFactory.FullFromThing(this.metadataprovider, ed.ToDto()));

            using var memoryStream = new MemoryStream();

            this.serializer.SerializeToStream(postoperation, memoryStream);

            // necessary
            memoryStream.Position = 0;

            var result = this.serializer.Deserialize<TestPostOperation>(memoryStream);
            Assert.That(result.Delete.Count, Is.EqualTo(1));
            Assert.That(result.Create.Count, Is.EqualTo(1));
            Assert.That(result.Update.Count, Is.EqualTo(2));

            var subscriptionValueSetClasslessDto =
                result.Update.Single(x => x["Iid"].ToString() == subscriptionValueset.Iid.ToString());

            var valueArray = (ValueArray<string>)subscriptionValueSetClasslessDto["Manual"];
                
            Assert.That(subscriptionValueSetClasslessDto["Iid"] is Guid, Is.True);
            Assert.That(subscriptionValueSetClasslessDto["ClassKind"] is ClassKind, Is.True);

            Assert.That(valueArray.Count, Is.EqualTo(3));
            Assert.That(valueArray[0], Is.EqualTo("123"));
            Assert.That(valueArray[1], Is.EqualTo("456"));
            Assert.That(valueArray[2], Is.EqualTo("789.0"));
        }

        [Test]
        public void VerifyThatSerializeThingToStringWorks()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 1, 0));

            this.engModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            this.book1 = new Book(Guid.NewGuid(), this.cache, this.uri) { Name = "name", ShortName = null };
            this.book2 = new Book(Guid.NewGuid(), this.cache, this.uri) { Name = "name", ShortName = "shortname" };
            this.section1 = new Section(Guid.NewGuid(), this.cache, this.uri) { Name = "name", ShortName = "SS1" };

            this.engModel.Book.Add(this.book1);
            this.engModel.Book.Add(this.book2);
            this.book2.Section.Add(this.section1);

            var serializeShallow = this.serializer.SerializeToString(this.engModel, false);

            var serializeDeep = this.serializer.SerializeToString(this.engModel, true);

            Assert.That(serializeDeep.Length > serializeShallow.Length, Is.True);
        }

        [Test]
        public void VerifyThatSerializeGiveSameInput()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/jsonTestSample.json")).Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Trim();
            IReadOnlyList<Dto.Thing> result;

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                result = this.serializer.Deserialize(stream).ToList();
            }

            using (var stream = new MemoryStream())
            {
                this.serializer.SerializeToStream(result, stream);
                stream.Position = 0;

                using var reader = new StreamReader(stream);

                var serializerResult = reader.ReadToEnd().Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Trim();
                    
                Assert.That(response.Length, Is.EqualTo(serializerResult.Length));
            }
        }

        [Test]
        public void VerifyThatValueSetDeserializationIsCorrectForStringThatRepresentEscapeCharacters()
        {
            var engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            var iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            engineeringModel.Iteration.Add(iteration);

            var elementDefinition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri);
            iteration.Element.Add(elementDefinition);

            var parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri);
            elementDefinition.Parameter.Add(parameter);

            var parameterValueSet = new ParameterValueSet(Guid.Parse("049abaf8-d550-44b1-b32b-aa4b358f5d73"), this.cache, this.uri);
            parameter.ValueSet.Add(parameterValueSet);

            parameterValueSet.ValueSwitch = ParameterSwitchKind.MANUAL;
            parameterValueSet.Manual = new ValueArray<string>(new[] { @"a\rb", @"a\tb", @"a\nb" });

            var serializedParameterValueSet = this.serializer.SerializeToString(parameterValueSet, false);

            IReadOnlyList<Dto.Thing> result;

            using (var stream = StreamHelper.GenerateStreamFromString(serializedParameterValueSet))
            {
                result = this.serializer.Deserialize(stream).ToList();
            }

            using (var stream = new MemoryStream())
            {
                this.serializer.SerializeToStream(result, stream);
                stream.Position = 0;

                using var reader = new StreamReader(stream);

                var serializerResult = reader.ReadToEnd().Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).Replace(" ", string.Empty).Trim();
                    
                Assert.That(serializedParameterValueSet.Length, Is.EqualTo(serializerResult.Length));
            }
        }

        [Test]
        public void Verify_that_raw_10_25_Category_PermissibleClasses_Are_Serialized_Correctly_for_raw_10_25_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category1.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass.Except(new[] { ClassKind.Page })));
        }

        [Test]
        public void Verify_that_cdp_extension_Category_PermissibleClasses_Are_Serialized_Correctly_for_raw_10_25_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 0, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category2.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass.Except(new[] { ClassKind.Page })));
        }

        [Test]
        public void Verify_that_raw_10_25_Category_PermissibleClasses_Are_Serialized_Correctly_for_cdp_extension_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 1, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category1.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass.Except(new[] { ClassKind.Page })));
        }

        [Test]
        public void Verify_that_cdp_extension_Category_PermissibleClasses_Are_Serialized_Correctly_for_cdp_extension_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 1, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category2.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass));
        }

        [Test]
        public void Verify_that_raw_10_25_Category_PermissibleClasses_Are_Serialized_Correctly_for_higher_version_cdp_extension_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 2, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category1.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass.Except(new[] { ClassKind.Page })));
        }

        [Test]
        public void Verify_that_cdp_extension_Category_PermissibleClasses_Are_Serialized_Correctly_for_higher_version_cdp_extension_ModelVersion()
        {
            this.serializer = new Cdp4JsonSerializer(this.metadataprovider, new Version(1, 2, 0));

            var stream = new MemoryStream();
            this.serializer.SerializeToStream(new[] { this.category2.ToDto() }, stream);
            stream.Position = 0;
            var deserializeResult = this.serializer.Deserialize(stream);

            Assert.That((deserializeResult.First(x => x is Dto.Category) as Dto.Category).PermissibleClass, Is.EquivalentTo(this.category2.PermissibleClass));
        }

        [Test]
        [Category("Performance")]
        public void PerformanceTest()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/bigmodel.json"));
            IReadOnlyList<Dto.Thing> result;

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                result = this.serializer.Deserialize(stream).ToList();
            }

            var stopwatch = Stopwatch.StartNew();

            for (var i = 0; i < 10; i++)
            {
                using var stream = new MemoryStream();

                Assert.That(() => this.serializer.SerializeToStream(result, stream), Throws.Nothing);
            }

            // code generated implementation about 40% performance improved compared to Newtonsoft generic implementation
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }

        private class TestPostOperation
        {
            /// <summary>
            /// Gets or sets the collection of DTOs to delete.
            /// </summary>
            [JsonProperty("_delete")]
            public List<ClasslessDTO> Delete { get; set; }

            /// <summary>
            /// Gets or sets the collection of DTOs to create.
            /// </summary>
            [JsonProperty("_create")]
            public List<Dto.Thing> Create { get; set; }

            /// <summary>
            /// Gets or sets the collection of DTOs to update.
            /// </summary>
            [JsonProperty("_update")]
            public List<ClasslessDTO> Update { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="TestPostOperation"/> class.
            /// </summary>
            public TestPostOperation()
            {
                this.Delete = new List<ClasslessDTO>();
                this.Create = new List<Dto.Thing>();
                this.Update = new List<ClasslessDTO>();
            }
        }
    }
}
