// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerProviderTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2026 Starion Group S.A.
//
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
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

namespace CDP4JsonSerializer.Tests
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    using CDP4Common;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;

    using CDP4JsonSerializer.Tests.Helper;

    using JetBrains.dotMemoryUnit;

    using NUnit.Framework;

    using Dto = CDP4Common.DTO;

    /// <summary>
    /// Suite of tests for the <see cref="SerializerProvider"/> class
    /// </summary>
    [TestFixture]
    public class SerializerProviderTestFixture
    {
        private Dto.ElementDefinition elementDefinition;
        private Dto.ParameterValueSet parameterValueSet;

        [SetUp]
        public void SetUp()
        {
            this.elementDefinition = new Dto.ElementDefinition(Guid.NewGuid(), 1)
            {
                Name = "Battery",
                ShortName = "BAT",
                Owner = Guid.NewGuid(),
                ModifiedOn = new DateTime(2025, 1, 2, 3, 4, 5, DateTimeKind.Utc)
            };

            this.elementDefinition.Alias.Add(Guid.NewGuid());
            this.elementDefinition.Alias.Add(Guid.NewGuid());
            this.elementDefinition.Category.Add(Guid.NewGuid());
            this.elementDefinition.ContainedElement.Add(Guid.NewGuid());
            this.elementDefinition.Parameter.Add(Guid.NewGuid());

            this.parameterValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2)
            {
                Manual = new ValueArray<string>(new[] { "1", "a\"b", "ünïcödé" }),
                Computed = new ValueArray<string>(new[] { "-", "-", "-" }),
                Reference = new ValueArray<string>(new[] { "1.5", "2.5", "3.5" }),
                Published = new ValueArray<string>(new[] { "1", "2", "3" }),
                Formula = new ValueArray<string>(new[] { "", "", "" }),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };
        }

        private IEnumerable<Dto.Thing> Things()
        {
            yield return this.elementDefinition;
            yield return this.parameterValueSet;
        }

        [Test]
        public void VerifyThatSerializeThingToWriterMatchesToJsonString()
        {
            foreach (var thing in this.Things())
            {
                using var stream = new MemoryStream();

                using (var writer = new Utf8JsonWriter(stream))
                {
                    thing.SerializeThing(writer);
                }

                Assert.That(Encoding.UTF8.GetString(stream.ToArray()), Is.EqualTo(thing.ToJsonString()));
            }
        }

        [Test]
        public void VerifyThatWriterCanBeReusedAcrossThings()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            for (var repeat = 0; repeat < 3; repeat++)
            {
                foreach (var thing in this.Things())
                {
                    stream.SetLength(0);
                    writer.Reset(stream);

                    thing.SerializeThing(writer);
                    writer.Flush();

                    Assert.That(Encoding.UTF8.GetString(stream.ToArray()), Is.EqualTo(thing.ToJsonString()));
                }
            }
        }

        [Test]
        public void VerifyThatSerializeThingToWriterDoesNotFlush()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            this.elementDefinition.SerializeThing(writer);

            Assert.That(stream.Length, Is.EqualTo(0));
            Assert.That(writer.BytesPending, Is.GreaterThan(0));

            writer.Flush();

            Assert.That(stream.Length, Is.GreaterThan(0));
        }

        [Test]
        public void VerifyThatSerializeThingToBufferWriterProducesUtf8Json()
        {
            foreach (var thing in this.Things())
            {
                var bufferWriter = new ByteArrayBufferWriter();

                thing.SerializeThing(bufferWriter);

                Assert.That(Encoding.UTF8.GetString(bufferWriter.WrittenBytes), Is.EqualTo(thing.ToJsonString()));
            }
        }

        [Test]
        public void VerifyThatJsonWriterOptionsAreHonoured()
        {
            var bufferWriter = new ByteArrayBufferWriter();

            this.elementDefinition.SerializeThing(bufferWriter, new JsonWriterOptions { Indented = true });

            var json = Encoding.UTF8.GetString(bufferWriter.WrittenBytes);

            Assert.That(json, Does.Contain("\n"));
            Assert.That(json, Is.Not.EqualTo(this.elementDefinition.ToJsonString()));

            using var document = JsonDocument.Parse(json);

            Assert.That(document.RootElement.GetProperty("iid").GetGuid(), Is.EqualTo(this.elementDefinition.Iid));
            Assert.That(document.RootElement.GetProperty("classKind").GetString(), Is.EqualTo("ElementDefinition"));
        }

        [Test]
        public void VerifyThatToJsonStringProducesExpectedJson()
        {
            using var elementDefinitionDocument = JsonDocument.Parse(this.elementDefinition.ToJsonString());
            var root = elementDefinitionDocument.RootElement;

            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("iid").GetGuid(), Is.EqualTo(this.elementDefinition.Iid));
                Assert.That(root.GetProperty("revisionNumber").GetInt32(), Is.EqualTo(1));
                Assert.That(root.GetProperty("classKind").GetString(), Is.EqualTo("ElementDefinition"));
                Assert.That(root.GetProperty("name").GetString(), Is.EqualTo("Battery"));
                Assert.That(root.GetProperty("shortName").GetString(), Is.EqualTo("BAT"));
                Assert.That(root.GetProperty("owner").GetGuid(), Is.EqualTo(this.elementDefinition.Owner));
                Assert.That(root.GetProperty("modifiedOn").GetString(), Is.EqualTo("2025-01-02T03:04:05.000Z"));
                Assert.That(root.GetProperty("alias").EnumerateArray().Select(x => x.GetGuid()), Is.EquivalentTo(this.elementDefinition.Alias));
                Assert.That(root.GetProperty("category").EnumerateArray().Select(x => x.GetGuid()), Is.EquivalentTo(this.elementDefinition.Category));
            });

            using var parameterValueSetDocument = JsonDocument.Parse(this.parameterValueSet.ToJsonString());
            root = parameterValueSetDocument.RootElement;

            Assert.Multiple(() =>
            {
                Assert.That(root.GetProperty("classKind").GetString(), Is.EqualTo("ParameterValueSet"));
                Assert.That(root.GetProperty("manual").GetString(), Is.EqualTo("[\"1\",\"a\\\"b\",\"ünïcödé\"]"));
                Assert.That(root.GetProperty("valueSwitch").GetString(), Is.EqualTo("MANUAL"));
            });
        }

        [Test]
        public void VerifyThatClasslessDtoOverloadsMatchToJsonString()
        {
            var classlessDto = ClasslessDtoFactory.FullFromThing(new MetaDataProvider(), this.elementDefinition);
            var expected = classlessDto.ToJsonString();

            Assert.That(expected, Does.Contain("\"classKind\":\"ElementDefinition\""));
            Assert.That(expected, Does.Contain($"\"iid\":\"{this.elementDefinition.Iid}\""));
            Assert.That(expected, Does.Contain("\"name\":\"Battery\""));

            using var stream = new MemoryStream();

            using (var writer = new Utf8JsonWriter(stream))
            {
                classlessDto.SerializeClasslessDto(writer);
            }

            Assert.That(Encoding.UTF8.GetString(stream.ToArray()), Is.EqualTo(expected));

            var bufferWriter = new ByteArrayBufferWriter();
            classlessDto.SerializeClasslessDto(bufferWriter);

            Assert.That(Encoding.UTF8.GetString(bufferWriter.WrittenBytes), Is.EqualTo(expected));
        }

        [Test]
        public void VerifyThatNullArgumentsThrow()
        {
            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);
            var bufferWriter = new ByteArrayBufferWriter();
            var classlessDto = ClasslessDtoFactory.FullFromThing(new MetaDataProvider(), this.elementDefinition);
            var version = new Version(1, 0, 0);

            Assert.Multiple(() =>
            {
                Assert.That(() => ((Dto.Thing)null).SerializeThing(writer), Throws.ArgumentNullException);
                Assert.That(() => ((Dto.Thing)null).SerializeThing(bufferWriter), Throws.ArgumentNullException);
                Assert.That(() => ((Dto.Thing)null).SerializeThing(writer, version), Throws.ArgumentNullException);
                Assert.That(() => ((Dto.Thing)null).ToJsonString(), Throws.ArgumentNullException);
                Assert.That(() => this.elementDefinition.SerializeThing((Utf8JsonWriter)null), Throws.ArgumentNullException);
                Assert.That(() => this.elementDefinition.SerializeThing((IBufferWriter<byte>)null), Throws.ArgumentNullException);
                Assert.That(() => this.elementDefinition.SerializeThing(writer, null), Throws.ArgumentNullException);

                Assert.That(() => ((ClasslessDTO)null).SerializeClasslessDto(writer), Throws.ArgumentNullException);
                Assert.That(() => ((ClasslessDTO)null).SerializeClasslessDto(bufferWriter), Throws.ArgumentNullException);
                Assert.That(() => ((ClasslessDTO)null).SerializeClasslessDto(writer, version), Throws.ArgumentNullException);
                Assert.That(() => ((ClasslessDTO)null).ToJsonString(), Throws.ArgumentNullException);
                Assert.That(() => classlessDto.SerializeClasslessDto((Utf8JsonWriter)null), Throws.ArgumentNullException);
                Assert.That(() => classlessDto.SerializeClasslessDto((IBufferWriter<byte>)null), Throws.ArgumentNullException);
                Assert.That(() => classlessDto.SerializeClasslessDto(writer, null), Throws.ArgumentNullException);
            });
        }

        [Test]
        [DotMemoryUnit(CollectAllocations = true, FailIfRunWithoutSupport = false)]
        public void VerifyThatReusedWriterAllocatesLessThanToJsonString()
        {
            const int count = 1000;

            var things = Enumerable.Range(0, count)
                .Select(i => new Dto.ElementDefinition(Guid.NewGuid(), i) { Name = $"Element {i}", ShortName = $"E{i}", Owner = Guid.NewGuid() })
                .ToList();

            using var stream = new MemoryStream(4096);
            using var writer = new Utf8JsonWriter(stream);

            // warm up both paths so that one-off allocations do not count
            things[0].SerializeThing(writer);
            writer.Flush();
            things[0].ToJsonString();

            long reusedWriterBytes = 0;
            long reusedWriterStrings = 0;

            var reusedWriterCheckPoint = dotMemory.Check();

            foreach (var thing in things)
            {
                stream.SetLength(0);
                writer.Reset(stream);
                thing.SerializeThing(writer);
                writer.Flush();
            }

            dotMemory.Check(memory =>
            {
                var traffic = memory.GetTrafficFrom(reusedWriterCheckPoint);
                reusedWriterBytes = traffic.AllocatedMemory.SizeInBytes;
                reusedWriterStrings = traffic.Where(x => x.Type.Is<string>()).AllocatedMemory.ObjectsCount;
            });

            var toJsonStringCheckPoint = dotMemory.Check();
            var totalLength = 0;

            foreach (var thing in things)
            {
                totalLength += thing.ToJsonString().Length;
            }

            dotMemory.Check(memory =>
            {
                var traffic = memory.GetTrafficFrom(toJsonStringCheckPoint);

                TestContext.WriteLine($"ToJsonString: {traffic.AllocatedMemory.SizeInBytes} bytes, reused writer: {reusedWriterBytes} bytes, for {totalLength} characters of JSON");

                Assert.That(traffic.Where(x => x.Type.Is<string>()).AllocatedMemory.ObjectsCount, Is.GreaterThanOrEqualTo(reusedWriterStrings + count));
                Assert.That(reusedWriterBytes, Is.LessThan(traffic.AllocatedMemory.SizeInBytes / 2));
            });

            Assert.That(totalLength, Is.GreaterThan(0));
        }
    }
}
