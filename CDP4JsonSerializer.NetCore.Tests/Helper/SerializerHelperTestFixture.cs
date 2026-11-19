// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelperTestFixture.cs" company="Starion Group S.A.">
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Helper
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.Json.Nodes;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;

    using CDP4JsonSerializer.Helper;

    using JetBrains.dotMemoryUnit;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="SerializerHelper"/> class.
    /// </summary>
    [TestFixture]
    public class SerializerHelperTestFixture
    {
        [Test]
        public void VerifyThatToJsonObjectOfOrderedItemReturnsJObject()
        {
            var uniqueIdentifier = Guid.NewGuid();

            var orderedItem = new OrderedItem();
            orderedItem.K = 1;
            orderedItem.V = uniqueIdentifier;

            var propertyInfo = orderedItem.GetType().GetProperty("M");

            object value = null;
            value = System.Convert.ChangeType(123, Nullable.GetUnderlyingType(propertyInfo.PropertyType));
            propertyInfo.SetValue(orderedItem, value);
            var stream = new MemoryStream();
            var utf8Writer = new Utf8JsonWriter(stream);
            utf8Writer.WriteOrderedItem(orderedItem);
            utf8Writer.Flush();
            stream.Position = 0;
            var ut8Reader = new Utf8JsonReader(stream.ToArray());

            var jObject = JsonObject.Create(JsonElement.ParseValue(ref ut8Reader));
            Assert.That(jObject.AsEnumerable().Count(), Is.EqualTo(3));

            jObject.TryGetPropertyValue("k", out var k);
            Assert.That(k, Is.Not.Null);

            jObject.TryGetPropertyValue("v", out var v);
            Assert.That(v, Is.Not.Null);

            jObject.TryGetPropertyValue("m", out var m);
            Assert.That(m, Is.Not.Null);
        }

        [Test]
        public void Verify_that_ParameterValueSet_is_serialized_and_deserialized()
        {
            var values = new List<string>();
            values.Add("this is a\nnewline");
            values.Add("this is another\nnewline");

            var engineeringModel = new EngineeringModel { Iid = Guid.Parse("5643764e-f880-44bf-90ae-361f6661ceae") };
            var iteration = new Iteration { Iid = Guid.Parse("f744ae63-cf36-4cc4-8d76-e83edd44f6d2") };
            var elementDefinition = new ElementDefinition { Iid = Guid.Parse("f7f173ea-a742-42a5-81f1-59da2f470f16") };
            var parameter = new Parameter { Iid = Guid.Parse("607764de-7598-4be2-9a95-34669de273e3") };

            var parameterValueSet = new ParameterValueSet
            {
                Iid = Guid.Parse("2366c662-b857-4313-85ea-51f9bf4588b1"), Manual = new ValueArray<string>(values)
            };

            engineeringModel.Iteration.Add(iteration);
            iteration.Element.Add(elementDefinition);
            elementDefinition.Parameter.Add(parameter);
            parameter.ValueSet.Add(parameterValueSet);

            var metadataprovider = new MetaDataProvider();
            var serializer = new Cdp4JsonSerializer(metadataprovider, new Version(1, 1, 0));

            var result = serializer.SerializeToString(parameterValueSet, false);

            var stream = StreamHelper.GenerateStreamFromString(result);
            var dtos = serializer.Deserialize(stream);
            var dto = dtos.Single() as CDP4Common.DTO.ParameterValueSet;

            Assert.That(dto.Manual, Is.EquivalentTo(values));
        }

        [Test]
        public void Verify_that_a_ValueArray_is_serialized_and_deserialized([ValueSource(nameof(TestStrings))] string input)
        {
            var valueArray = new ValueArray<string>(new List<string> { input });
            var json = valueArray.ToJsonString();
            var result = SerializerHelper.ToValueArray<string>(json);

            Assert.That(result, Is.EqualTo(valueArray), $"ValueArray creation failed for string \"{input}\".");

            var resultjson = result.ToJsonString();

            Assert.That(resultjson, Is.EqualTo(json), $"Json creation failed for string \"{input}\".");
        }

        [Test]
        public void VerifyThatToJsonStringMatchesLegacyFormat([ValueSource(nameof(ValueArrayCases))] string[] items)
        {
            var valueArray = new ValueArray<string>(items);

            Assert.That(valueArray.ToJsonString(), Is.EqualTo(LegacyToJsonString(items)));
        }

        [Test]
        public void VerifyThatWriteValueArrayMatchesWriteStringOfLegacyFormat([ValueSource(nameof(ValueArrayCases))] string[] items)
        {
            var valueArray = new ValueArray<string>(items);
            var legacyJson = LegacyToJsonString(items);

            var writerOptions = new[]
            {
                new JsonWriterOptions(),
                new JsonWriterOptions { Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping },
                new JsonWriterOptions { Indented = true }
            };

            foreach (var options in writerOptions)
            {
                var expected = WriteObject(options, writer => writer.WriteString("manual"u8, legacyJson));
                var actual = WriteObject(options, writer => writer.WriteValueArray("manual"u8, valueArray));

                Assert.That(actual, Is.EqualTo(expected), $"WriteValueArray differs from the legacy output for encoder {options.Encoder?.GetType().Name ?? "default"}, indented {options.Indented}");
            }
        }

        [Test]
        public void VerifyThatToHstoreStringMatchesLegacyFormat([ValueSource(nameof(ValueArrayCases))] string[] items)
        {
            var legacyOptions = JsonSerializerOptionsCreator.CreateNew();
            var expected = $"{{{string.Join(";", items.Select(x => JsonSerializer.Serialize(x, legacyOptions)))}}}";

            Assert.That(SerializerHelper.ToHstoreString(new ValueArray<string>(items)), Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatWriteValueArrayIsThreadSafe()
        {
            var cases = ValueArrayCases().ToList();
            var failures = 0;

            Parallel.For(0, 32, new ParallelOptions { MaxDegreeOfParallelism = 8 }, worker =>
            {
                for (var i = 0; i < 200; i++)
                {
                    var items = cases[(worker + i) % cases.Count];
                    var valueArray = new ValueArray<string>(items);
                    var legacyJson = LegacyToJsonString(items);

                    if (valueArray.ToJsonString() != legacyJson)
                    {
                        Interlocked.Increment(ref failures);
                    }

                    var expected = WriteObject(default, writer => writer.WriteString("value"u8, legacyJson));
                    var actual = WriteObject(default, writer => writer.WriteValueArray("value"u8, valueArray));

                    if (!actual.SequenceEqual(expected))
                    {
                        Interlocked.Increment(ref failures);
                    }
                }
            });

            Assert.That(failures, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatWriteValueArrayThrowsOnNullArguments()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            Assert.Multiple(() =>
            {
                Assert.That(() => ((Utf8JsonWriter)null).WriteValueArray("manual"u8, new ValueArray<string>()), Throws.ArgumentNullException);
                Assert.That(() => writer.WriteValueArray("manual"u8, null), Throws.ArgumentNullException);
                Assert.That(() => ((ValueArray<string>)null).ToJsonString(), Throws.ArgumentNullException);
                Assert.That(() => SerializerHelper.ToHstoreString(null), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void VerifyThatParameterValueSetValueArraysAreWrittenInLegacyFormat()
        {
            var manual = new[] { "1", "a\"b", "ünïcödé" };
            var computed = new[] { "-", "<tag>&'+", "back\\slash" };
            var reference = new[] { "1.5", "line\r\nbreak", "\t" };
            var published = new[] { "", "😀", "日本語" };
            var formula = new[] { "=2*(2+2)", "", "x" };

            var valueSet = new CDP4Common.DTO.ParameterValueSet(Guid.NewGuid(), 1)
            {
                Manual = new ValueArray<string>(manual),
                Computed = new ValueArray<string>(computed),
                Reference = new ValueArray<string>(reference),
                Published = new ValueArray<string>(published),
                Formula = new ValueArray<string>(formula),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };

            using (var document = JsonDocument.Parse(valueSet.ToJsonString()))
            {
                AssertValueArrays(document.RootElement, manual, computed, reference, published, formula);
            }

            var serializer = new Cdp4JsonSerializer(new MetaDataProvider(), new Version(1, 0, 0));

            using var stream = new MemoryStream();
            serializer.SerializeToStream(new[] { valueSet }, stream);

            var json = Encoding.UTF8.GetString(stream.ToArray());
            Assert.That(json, Does.Contain("\"manual\":" + JsonSerializer.Serialize(LegacyToJsonString(manual), JsonSerializerOptionsCreator.CreateNew())));

            using (var document = JsonDocument.Parse(json))
            {
                AssertValueArrays(document.RootElement[0], manual, computed, reference, published, formula);
            }
        }

        [Test]
        [DotMemoryUnit(CollectAllocations = true, FailIfRunWithoutSupport = false)]
        public void VerifyThatValueArraysDoNotAllocateIntermediateStrings()
        {
            const int count = 1000;
            var values = Enumerable.Range(0, 20).Select(i => $"value {i}").ToArray();

            var valueSets = Enumerable.Range(0, count)
                .Select(i => new CDP4Common.DTO.ParameterValueSet(Guid.NewGuid(), i)
                {
                    Manual = new ValueArray<string>(values),
                    Computed = new ValueArray<string>(values),
                    Reference = new ValueArray<string>(values),
                    Published = new ValueArray<string>(values),
                    Formula = new ValueArray<string>(values)
                })
                .ToList();

            using var stream = new MemoryStream(8192);
            using var writer = new Utf8JsonWriter(stream);

            // warm up: creates the thread-cached buffer and writer
            valueSets[0].SerializeThing(writer);
            writer.Flush();

            var checkPoint = dotMemory.Check();

            foreach (var valueSet in valueSets)
            {
                stream.SetLength(0);
                writer.Reset(stream);
                valueSet.SerializeThing(writer);
                writer.Flush();
            }

            dotMemory.Check(memory =>
            {
                var traffic = memory.GetTrafficFrom(checkPoint);

                TestContext.WriteLine($"{count} value sets: {traffic.AllocatedMemory.SizeInBytes} bytes, {traffic.Where(x => x.Type.Is<string>()).AllocatedMemory.ObjectsCount} strings allocated");

                Assert.That(traffic.Where(x => x.Type.Is<List<string>>()).AllocatedMemory.ObjectsCount, Is.EqualTo(0), "value arrays must not be copied into lists");
                Assert.That(traffic.Where(x => x.Type.Is<string>()).AllocatedMemory.ObjectsCount, Is.LessThan(4 * count), "only the enum and date ToString calls may allocate strings");
            });

            Assert.That(stream.Length, Is.GreaterThan(0));
        }

        [Test]
        public void VerifyThatVeryLargeValueArraysAreNotKeptInTheThreadCache()
        {
            var large = new ValueArray<string>(new[] { new string('x', 2 * 1024 * 1024) });
            var small = new ValueArray<string>(new[] { "a" });

            Assert.That(large.ToJsonString().Length, Is.EqualTo(2 * 1024 * 1024 + 4));
            Assert.That(small.ToJsonString(), Is.EqualTo("[\"a\"]"));

            var largeBytes = WriteObject(default, writer => writer.WriteValueArray("v"u8, large));
            Assert.That(largeBytes.Length, Is.GreaterThan(2 * 1024 * 1024));

            var expected = WriteObject(default, writer => writer.WriteString("v"u8, "[\"a\"]"));
            Assert.That(WriteObject(default, writer => writer.WriteValueArray("v"u8, small)), Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatOnlySmallBuffersAreKeptInTheThreadCache()
        {
            const int maxCachedSize = 64 * 1024;

            var medium = new ValueArray<string>(new[] { new string('x', 100 * 1024) });
            var small = new ValueArray<string>(new[] { "a" });

            Assert.That(medium.ToJsonString().Length, Is.EqualTo(100 * 1024 + 4));
            Assert.That(SerializerHelper.CachedValueArrayBufferCapacity, Is.EqualTo(0), "a buffer above the cap must go back to the pool after ToJsonString");

            Assert.That(small.ToJsonString(), Is.EqualTo("[\"a\"]"));
            Assert.That(SerializerHelper.CachedValueArrayBufferCapacity, Is.GreaterThan(0).And.LessThanOrEqualTo(maxCachedSize), "a small buffer must stay cached");

            WriteObject(default, writer => writer.WriteValueArray("v"u8, medium));
            Assert.That(SerializerHelper.CachedValueArrayBufferCapacity, Is.EqualTo(0), "a buffer above the cap must go back to the pool after WriteValueArray");

            WriteObject(default, writer => writer.WriteValueArray("v"u8, small));
            Assert.That(SerializerHelper.CachedValueArrayBufferCapacity, Is.GreaterThan(0).And.LessThanOrEqualTo(maxCachedSize), "a small buffer must stay cached");
        }

        [Test]
        public void VerifyThatValueArrayWriterRecoversAfterInvalidInput()
        {
            var invalid = new ValueArray<string>(new[] { "a\uD800b", "\uDC00" });
            var valid = new[] { "a" };

            try
            {
                invalid.ToJsonString();
            }
            catch (Exception exception)
            {
                TestContext.WriteLine($"lone surrogates are rejected with {exception.GetType().Name}");
            }

            Assert.That(new ValueArray<string>(valid).ToJsonString(), Is.EqualTo("[\"a\"]"));

            var expected = WriteObject(default, writer => writer.WriteString("v"u8, LegacyToJsonString(valid)));
            Assert.That(WriteObject(default, writer => writer.WriteValueArray("v"u8, new ValueArray<string>(valid))), Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatWriteValueArrayIsUsableAfterTheOuterWriterThrows()
        {
            var large = new ValueArray<string>(new[] { new string('x', 2 * 1024 * 1024) });
            var valid = new[] { "a" };

            using (var stream = new MemoryStream())
            using (var writer = new Utf8JsonWriter(stream))
            {
                // a property cannot be written outside of an object
                Assert.That(() => writer.WriteValueArray("v"u8, large), Throws.TypeOf<InvalidOperationException>());
            }

            Assert.That(SerializerHelper.CachedValueArrayBufferCapacity, Is.EqualTo(0), "the large buffer must go back to the pool when the outer writer throws");

            var expected = WriteObject(default, writer => writer.WriteString("v"u8, LegacyToJsonString(valid)));
            Assert.That(WriteObject(default, writer => writer.WriteValueArray("v"u8, new ValueArray<string>(valid))), Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatToValueArrayConvertsToTheRequestedType()
        {
            Assert.Multiple(() =>
            {
                Assert.That(SerializerHelper.ToValueArray<int>("[\"1\",\"2\",\"3\"]"), Is.EqualTo(new ValueArray<int>(new[] { 1, 2, 3 })));
                Assert.That(SerializerHelper.ToValueArray<long>("[\"9000000000\"]"), Is.EqualTo(new ValueArray<long>(new[] { 9000000000L })));
                Assert.That(SerializerHelper.ToValueArray<bool>("[\"true\",\"false\"]"), Is.EqualTo(new ValueArray<bool>(new[] { true, false })));
                Assert.That(SerializerHelper.ToValueArray<string>("[]"), Is.Empty);
                Assert.That(SerializerHelper.ToValueArray<string>("not an array"), Is.Empty);
                Assert.That(SerializerHelper.ToValueArray<string>("[\"a\", \"b\"]"), Is.EqualTo(new ValueArray<string>(new[] { "a", "b" })));
            });
        }

        [Test]
        public void VerifyThatHstoreStringRoundTrips()
        {
            var valueArray = new ValueArray<string>(new[] { "a\"b", "c;d", "ünïcödé", "", "back\\slash", "line\nbreak" });

            var hstore = SerializerHelper.ToHstoreString(valueArray);

            Assert.Multiple(() =>
            {
                Assert.That(hstore, Does.StartWith("{").And.EndsWith("}"));
                Assert.That(SerializerHelper.ToHstoreString(new ValueArray<string>()), Is.EqualTo("{}"));
                Assert.That(SerializerHelper.ToHstoreString(new ValueArray<string>(new[] { "x" })), Is.EqualTo("{\"x\"}"));
                Assert.That(SerializerHelper.FromHstoreToValueArray<string>(hstore), Is.EqualTo(valueArray));
                Assert.That(SerializerHelper.FromHstoreToValueArray<int>("{\"1\";\"2\"}"), Is.EqualTo(new ValueArray<int>(new[] { 1, 2 })));
                Assert.That(SerializerHelper.FromHstoreToValueArray<string>("{}"), Is.Empty);
            });
        }

        [Test]
        public void VerifyThatWriteOrderedItemSupportsAllValueTypes()
        {
            var guid = Guid.NewGuid();

            var cases = new (object Value, string ExpectedJson)[]
            {
                ("text", "\"text\""),
                (guid, $"\"{guid}\""),
                (true, "true"),
                (42, "42"),
                (42L, "42"),
                (1.5d, "1.5"),
                (2.5f, "2.5")
            };

            Assert.Multiple(() =>
            {
                foreach (var (value, expectedJson) in cases)
                {
                    var json = WriteOrderedItemToString(new OrderedItem { K = 7, V = value });
                    Assert.That(json, Is.EqualTo($"{{\"k\":7,\"v\":{expectedJson}}}"), $"unexpected JSON for a value of type {value.GetType().Name}");
                }

                Assert.That(WriteOrderedItemToString(new OrderedItem { K = 1, M = 2, V = "x" }), Is.EqualTo("{\"k\":1,\"m\":2,\"v\":\"x\"}"));
                Assert.That(() => WriteOrderedItemToString(new OrderedItem { K = 1, V = new DateTime(2020, 1, 1) }), Throws.TypeOf<NotSupportedException>());
            });
        }

        [Test]
        public void VerifyThatToOrderedItemCollectionReadsAllShapes()
        {
            const string json = "[{\"k\":1,\"v\":\"a\"},{\"k\":\"2\",\"m\":5,\"v\":3},{\"k\":4,\"m\":null,\"v\":true}]";

            using var document = JsonDocument.Parse(json);
            var items = document.RootElement.ToOrderedItemCollection().ToList();

            Assert.That(items, Has.Count.EqualTo(3));

            Assert.Multiple(() =>
            {
                Assert.That(items[0].K, Is.EqualTo(1));
                Assert.That(items[0].M, Is.Null);
                Assert.That(items[0].V, Is.EqualTo("a"));

                Assert.That(items[1].K, Is.EqualTo(2), "a key written as a string must be parsed");
                Assert.That(items[1].M, Is.EqualTo(5));
                Assert.That(items[1].V, Is.EqualTo(3));

                Assert.That(items[2].K, Is.EqualTo(4));
                Assert.That(items[2].M, Is.Null, "a null m must be ignored");
                Assert.That(items[2].V, Is.Null, "a value that is neither a string nor a number is not supported");
            });

            using var emptyDocument = JsonDocument.Parse("[]");
            Assert.That(emptyDocument.RootElement.ToOrderedItemCollection(), Is.Empty);
        }

        private static string WriteOrderedItemToString(OrderedItem orderedItem)
        {
            using var stream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(stream))
            {
                writer.WriteOrderedItem(orderedItem);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }

        private static void AssertValueArrays(JsonElement element, string[] manual, string[] computed, string[] reference, string[] published, string[] formula)
        {
            Assert.Multiple(() =>
            {
                Assert.That(element.GetProperty("manual").GetString(), Is.EqualTo(LegacyToJsonString(manual)));
                Assert.That(element.GetProperty("computed").GetString(), Is.EqualTo(LegacyToJsonString(computed)));
                Assert.That(element.GetProperty("reference").GetString(), Is.EqualTo(LegacyToJsonString(reference)));
                Assert.That(element.GetProperty("published").GetString(), Is.EqualTo(LegacyToJsonString(published)));
                Assert.That(element.GetProperty("formula").GetString(), Is.EqualTo(LegacyToJsonString(formula)));
            });
        }

        /// <summary>
        /// The implementation of <see cref="SerializerHelper.ToJsonString"/> before issue #422, used as the oracle for the wire format
        /// </summary>
        private static string LegacyToJsonString(IEnumerable<string> items)
        {
            var options = JsonSerializerOptionsCreator.CreateNew();
            return $"[{string.Join(",", items.Select(x => JsonSerializer.Serialize(x, options)))}]";
        }

        private static byte[] WriteObject(JsonWriterOptions options, Action<Utf8JsonWriter> write)
        {
            using var stream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(stream, options))
            {
                writer.WriteStartObject();
                write(writer);
                writer.WriteEndObject();
            }

            return stream.ToArray();
        }

        private static IEnumerable<string[]> ValueArrayCases()
        {
            yield return Array.Empty<string>();
            yield return new[] { "" };
            yield return new[] { "a", null, "b" };
            yield return new[] { "ünïcödé", "😀 emoji", "日本語" };
            yield return new[] { "<tag>&'+", "quote\" backslash\\ slash/" };
            yield return new[] { "\u0000\u001f control", "line\r\nbreak", char.ConvertFromUtf32(0x2028) + char.ConvertFromUtf32(0x2029) };
            yield return new[] { "a\uD800b", "\uDC00" };
            yield return TestStrings;

            foreach (var testString in TestStrings)
            {
                yield return new[] { testString };
            }
        }

        private const string JsonString =@"{""widget"": {
                ""debug"": ""on"",
                ""window"": {
                    ""title"": ""Sample Konfabulator Widget"",
                    ""name"": ""main_window"",
                    ""width"": 500,
                    ""height"": 500
                },
                ""image"": { 
                    ""src"": ""Images/Sun.png"",
                    ""name"": ""sun1"",
                    ""hOffset"": 250,
                    ""vOffset"": 250,
                    ""alignment"": ""center""
                },
                ""text"": {
                    ""data"": ""Click Here"",
                    ""size"": 36,
                    ""style"": ""bold"",
                    ""name"": ""text1"",
                    ""hOffset"": 250,
                    ""vOffset"": 100,
                    ""alignment"": ""center"",
                    ""onMouseUp"": ""sun1.opacity = (sun1.opacity / 100) * 90;""
                }
            }}";

        private const string XmlString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <bookstore>
                <book category=""cooking"">
                    <title lang=""en"">Everyday Italian</title>
                    <author>Giada De Laurentiis</author>
                    <year>2005</year>
                    <price>30.00</price>
                    <data><![CDATA[Within this Character Data block I can
                        use double dashes as much as I want (along with <, &, ', and "")
                        *and* %MyParamEntity; will be expanded to the text
                        ""Has been expanded"" ... however, I can't use
                        the CEND sequence.If I need to use CEND I must escape one of the
                        brackets or the greater-than sign using concatenated CDATA sections.
                        ]]></data>
                </book>
                <book category=""children"">
                    <title lang=""en"">Harry Potter</title>
                    <author>J K. Rowling</author>
                    <year>2005</year>
                    <price>29.99</price>
                </book>
                <book category=""web"">
                    <title lang=""en"">Learning XML</title>
                    <author>Erik T. Ray</author>
                    <year>2003</year>
                    <price>39.95</price>
                </book>
            </bookstore>";

        private static readonly string[] TestStrings =
        {
            "value with trailing spaces  ",
            "value with trailing space ",
            " value with leading spaces",
            "  value with leading space",
            "\t\t\tvalue with leading and trailing tabs \t",
            "\nvalue with leading and trailing linebreaks \r",
            "=2*(2+2)",
            "=2*\n(2+2)",
            "=2*\r(2+2)",
            "=2*\r\n(2+2)",
            "=2*\n\r(2+2)",
            "= 2 * \n ( 2 + 2 )",
            "=2*\b(2+2)",
            "=2*\f(2+2)",
            "=2*\t(2+2)",
            "Ar54WbBu + yhw - R:G!d)C!X_H % Vy ? V",
            "qm+L/{hp,qU[F\nnSyFymmZ\n+F(G/pP8@",
            "JSfJzH!U5:*wcnzT+{a5-L&+Xaq[g4",
            "EfRKJ[*A%uiM9MJ_h-z?9X(KYJQ/xL",
            "B_Dw+Tw.7g,.36]7(j8(k3/hxX,K_y",
            "qKt_C}@).D!ik.4W48ESR}w*VGvaub",
            "33CDr2NPZ[fJQ]p?aXT2L{giUUm}g#",
            "mpb-!ump7S{D)]Z9B@S([FXMRSq/9S",
            "D,VeZQRnV/}?}*qxMeX}N7*%R]!Tf/",
            "L$X7@P,JhcYM,-e4Z5,!ft.UbC[Y{n",
            "QWuAr.P$RUCf(NiV{7}tcwnia:.Fnp",
            "L%%t?cdpa?g#-PE4w6=[yU72Cgxz:f",
            ",GCeVX=$6R,(JJW[mLd4uF@{,Yr%NL",
            "i?5,/.G%D,M3im?8:,+ju}(CMh_E77",
            "}8Bn)rtS4BGTWThmT,=nu,q{[H?):9",
            "ScVmbHjSB[HS$8A*C{awPvvp{%@5Xr",
            "wy6bDVDuim}YLhB24=[y6!4vpM2pTw",
            "f:][.LfcN#(gH=Dq$6Lcp7TWQP7LH!",
            "!&.v8L44$ep69u+W-_5jq?DV@fi($H",
            "?_uB5Z(U$B6,cVPMPJv%q}d[+2PAMZ",
            "[_*q5d$U{qE7}r_7$fdf$h5yBFpPG+",
            XmlString,
            JsonString
        };
    }
}
