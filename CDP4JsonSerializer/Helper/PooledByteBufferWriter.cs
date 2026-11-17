// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PooledByteBufferWriter.cs" company="Starion Group S.A.">
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

namespace CDP4JsonSerializer.Helper
{
    using System;
    using System.Buffers;

    /// <summary>
    /// An <see cref="IBufferWriter{T}"/> over a byte array rented from <see cref="ArrayPool{T}.Shared"/>.
    /// It replaces <c>ArrayBufferWriter&lt;byte&gt;</c>, which is not public on net48 and netstandard2.0,
    /// and lets a <see cref="System.Text.Json.Utf8JsonWriter"/> be reused without allocating per write.
    /// </summary>
    internal sealed class PooledByteBufferWriter : IBufferWriter<byte>, IDisposable
    {
        /// <summary>
        /// The rented buffer, null once disposed
        /// </summary>
        private byte[] buffer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PooledByteBufferWriter"/> class
        /// </summary>
        /// <param name="initialCapacity">The minimum size of the first rented buffer</param>
        public PooledByteBufferWriter(int initialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialCapacity));
            }

            this.buffer = ArrayPool<byte>.Shared.Rent(initialCapacity);
        }

        /// <summary>
        /// Gets the number of bytes written so far
        /// </summary>
        public int WrittenCount { get; private set; }

        /// <summary>
        /// Gets the size of the rented buffer, 0 once disposed
        /// </summary>
        public int Capacity => this.buffer?.Length ?? 0;

        /// <summary>
        /// Gets the written bytes as a <see cref="ReadOnlySpan{T}"/>. The span is only valid until the next write or <see cref="Clear"/>.
        /// </summary>
        public ReadOnlySpan<byte> WrittenSpan => new ReadOnlySpan<byte>(this.buffer, 0, this.WrittenCount);

        /// <summary>
        /// Gets the written bytes as an <see cref="ArraySegment{T}"/>. The segment is only valid until the next write or <see cref="Clear"/>.
        /// </summary>
        public ArraySegment<byte> WrittenSegment => new ArraySegment<byte>(this.buffer, 0, this.WrittenCount);

        /// <summary>
        /// Forgets the written bytes so that the buffer can be written again from the start
        /// </summary>
        public void Clear()
        {
            this.WrittenCount = 0;
        }

        /// <inheritdoc />
        public void Advance(int count)
        {
            if (count < 0 || this.WrittenCount + count > this.buffer.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            this.WrittenCount += count;
        }

        /// <inheritdoc />
        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            this.EnsureCapacity(sizeHint);
            return new Memory<byte>(this.buffer, this.WrittenCount, this.buffer.Length - this.WrittenCount);
        }

        /// <inheritdoc />
        public Span<byte> GetSpan(int sizeHint = 0)
        {
            this.EnsureCapacity(sizeHint);
            return new Span<byte>(this.buffer, this.WrittenCount, this.buffer.Length - this.WrittenCount);
        }

        /// <summary>
        /// Returns the rented buffer to the pool
        /// </summary>
        public void Dispose()
        {
            var rented = this.buffer;

            if (rented == null)
            {
                return;
            }

            this.buffer = null;
            this.WrittenCount = 0;
            ArrayPool<byte>.Shared.Return(rented);
        }

        /// <summary>
        /// Rents a larger buffer when fewer than <paramref name="sizeHint"/> bytes are available
        /// </summary>
        /// <param name="sizeHint">The minimum number of bytes that must be available after the written bytes</param>
        private void EnsureCapacity(int sizeHint)
        {
            if (this.buffer == null)
            {
                throw new ObjectDisposedException(nameof(PooledByteBufferWriter));
            }

            if (sizeHint < 1)
            {
                sizeHint = 1;
            }

            var available = this.buffer.Length - this.WrittenCount;

            if (sizeHint <= available)
            {
                return;
            }

            var newSize = Math.Max(this.buffer.Length * 2, this.WrittenCount + sizeHint);
            var newBuffer = ArrayPool<byte>.Shared.Rent(newSize);

            Buffer.BlockCopy(this.buffer, 0, newBuffer, 0, this.WrittenCount);
            ArrayPool<byte>.Shared.Return(this.buffer);
            this.buffer = newBuffer;
        }
    }
}
