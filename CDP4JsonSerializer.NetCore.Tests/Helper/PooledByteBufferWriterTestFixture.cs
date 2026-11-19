// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PooledByteBufferWriterTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4JsonSerializer.Tests.Helper
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.Json;

    using CDP4JsonSerializer.Helper;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="PooledByteBufferWriter"/> class
    /// </summary>
    [TestFixture]
    public class PooledByteBufferWriterTestFixture
    {
        [Test]
        public void VerifyThatConstructorRejectsNonPositiveCapacity()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new PooledByteBufferWriter(0), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => new PooledByteBufferWriter(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
            });
        }

        [Test]
        public void VerifyThatNewWriterIsEmpty()
        {
            using var writer = new PooledByteBufferWriter(16);

            Assert.Multiple(() =>
            {
                Assert.That(writer.WrittenCount, Is.EqualTo(0));
                Assert.That(writer.Capacity, Is.GreaterThanOrEqualTo(16));
                Assert.That(writer.WrittenSpan.Length, Is.EqualTo(0));
                Assert.That(writer.WrittenSegment.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void VerifyThatAdvanceTracksWrittenBytes()
        {
            using var writer = new PooledByteBufferWriter(16);

            var span = writer.GetSpan(3);
            span[0] = 1;
            span[1] = 2;
            span[2] = 3;
            writer.Advance(3);

            Assert.That(writer.WrittenCount, Is.EqualTo(3));
            Assert.That(writer.WrittenSpan.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3 }));

            var memory = writer.GetMemory(2);
            memory.Span[0] = 4;
            memory.Span[1] = 5;
            writer.Advance(2);

            var segment = writer.WrittenSegment;

            Assert.Multiple(() =>
            {
                Assert.That(writer.WrittenCount, Is.EqualTo(5));
                Assert.That(segment.Offset, Is.EqualTo(0));
                Assert.That(segment.Count, Is.EqualTo(5));
                Assert.That(segment.ToArray(), Is.EqualTo(new byte[] { 1, 2, 3, 4, 5 }));
            });
        }

        [Test]
        public void VerifyThatAdvanceRejectsInvalidCounts()
        {
            using var writer = new PooledByteBufferWriter(16);

            Assert.Multiple(() =>
            {
                Assert.That(() => writer.Advance(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(() => writer.Advance(writer.Capacity + 1), Throws.TypeOf<ArgumentOutOfRangeException>());
                Assert.That(writer.WrittenCount, Is.EqualTo(0));
            });
        }

        [Test]
        public void VerifyThatAdvanceAcceptsTheFullCapacity()
        {
            using var writer = new PooledByteBufferWriter(16);
            var capacity = writer.Capacity;

            Assert.That(() => writer.Advance(capacity), Throws.Nothing);

            Assert.Multiple(() =>
            {
                Assert.That(writer.WrittenCount, Is.EqualTo(capacity));
                Assert.That(writer.Capacity, Is.EqualTo(capacity));
                Assert.That(writer.WrittenSegment.Count, Is.EqualTo(capacity));
                Assert.That(() => writer.Advance(1), Throws.TypeOf<ArgumentOutOfRangeException>());
            });
        }

        [Test]
        public void VerifyThatAdvanceAndWrittenSegmentAfterDisposeThrowObjectDisposedException()
        {
            var writer = new PooledByteBufferWriter(16);
            writer.GetSpan(4);
            writer.Advance(4);

            writer.Dispose();

            Assert.Multiple(() =>
            {
                Assert.That(() => writer.Advance(0), Throws.TypeOf<ObjectDisposedException>());
                Assert.That(() => writer.Advance(1), Throws.TypeOf<ObjectDisposedException>());
                Assert.That(() => writer.WrittenSegment, Throws.TypeOf<ObjectDisposedException>());
            });
        }

        [Test]
        public void VerifyThatBufferGrowsAndKeepsWrittenBytes()
        {
            using var writer = new PooledByteBufferWriter(16);
            var initialCapacity = writer.Capacity;
            var payload = Enumerable.Range(0, 1000).Select(i => (byte)(i % 251)).ToArray();
            var offset = 0;

            while (offset < payload.Length)
            {
                var chunk = Math.Min(7, payload.Length - offset);
                var span = writer.GetSpan(chunk);

                Assert.That(span.Length, Is.GreaterThanOrEqualTo(chunk));

                payload.AsSpan(offset, chunk).CopyTo(span);
                writer.Advance(chunk);
                offset += chunk;
            }

            Assert.Multiple(() =>
            {
                Assert.That(writer.Capacity, Is.GreaterThan(initialCapacity));
                Assert.That(writer.WrittenCount, Is.EqualTo(payload.Length));
                Assert.That(writer.WrittenSpan.ToArray(), Is.EqualTo(payload));
            });
        }

        [Test]
        public void VerifyThatSizeHintIsHonoured()
        {
            using var writer = new PooledByteBufferWriter(16);

            Assert.Multiple(() =>
            {
                Assert.That(writer.GetSpan(5000).Length, Is.GreaterThanOrEqualTo(5000));
                Assert.That(writer.GetMemory(20000).Length, Is.GreaterThanOrEqualTo(20000));
                Assert.That(writer.GetSpan().Length, Is.GreaterThanOrEqualTo(1));
                Assert.That(writer.GetMemory().Length, Is.GreaterThanOrEqualTo(1));
                Assert.That(writer.GetSpan(-5).Length, Is.GreaterThanOrEqualTo(1));
            });
        }

        [Test]
        public void VerifyThatClearResetsWrittenCountButKeepsCapacity()
        {
            using var writer = new PooledByteBufferWriter(16);
            writer.GetSpan(100);
            writer.Advance(100);
            var capacity = writer.Capacity;

            writer.Clear();

            Assert.Multiple(() =>
            {
                Assert.That(writer.WrittenCount, Is.EqualTo(0));
                Assert.That(writer.Capacity, Is.EqualTo(capacity));
                Assert.That(writer.WrittenSpan.Length, Is.EqualTo(0));
            });
        }

        [Test]
        public void VerifyThatDisposeReturnsBufferAndIsIdempotent()
        {
            var writer = new PooledByteBufferWriter(16);
            writer.GetSpan(4);
            writer.Advance(4);

            writer.Dispose();

            Assert.Multiple(() =>
            {
                Assert.That(writer.WrittenCount, Is.EqualTo(0));
                Assert.That(writer.Capacity, Is.EqualTo(0));
                Assert.That(writer.WrittenSpan.Length, Is.EqualTo(0));
                Assert.That(() => writer.Dispose(), Throws.Nothing);
                Assert.That(() => writer.GetSpan(1), Throws.TypeOf<ObjectDisposedException>());
                Assert.That(() => writer.GetMemory(1), Throws.TypeOf<ObjectDisposedException>());
            });
        }

        [Test]
        public void VerifyThatUtf8JsonWriterCanWriteBeyondInitialCapacityAndReuseTheBuffer()
        {
            using var buffer = new PooledByteBufferWriter(8);
            var values = Enumerable.Range(0, 500).Select(i => $"value {i}").ToArray();

            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStartArray();

                foreach (var value in values)
                {
                    writer.WriteStringValue(value);
                }

                writer.WriteEndArray();
            }

            var segment = buffer.WrittenSegment;
            var json = Encoding.UTF8.GetString(segment.Array, segment.Offset, segment.Count);

            Assert.That(JsonSerializer.Deserialize<string[]>(json), Is.EqualTo(values));

            buffer.Clear();

            using (var writer = new Utf8JsonWriter(buffer))
            {
                writer.WriteStringValue("x");
            }

            Assert.That(Encoding.UTF8.GetString(buffer.WrittenSpan.ToArray()), Is.EqualTo("\"x\""));
        }
    }
}
