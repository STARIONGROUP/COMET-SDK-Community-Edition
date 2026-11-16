// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ByteArrayBufferWriter.cs" company="Starion Group S.A.">
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
    using System.Buffers;

    /// <summary>
    /// A minimal <see cref="IBufferWriter{T}"/> backed by a growing byte array. It is used by the tests on every
    /// target framework, because <c>ArrayBufferWriter&lt;T&gt;</c> is not public on net48 and netstandard2.0.
    /// </summary>
    public class ByteArrayBufferWriter : IBufferWriter<byte>
    {
        /// <summary>
        /// The backing buffer
        /// </summary>
        private byte[] buffer = new byte[256];

        /// <summary>
        /// Gets the number of bytes that have been written
        /// </summary>
        public int WrittenCount { get; private set; }

        /// <summary>
        /// Gets a copy of the bytes that have been written
        /// </summary>
        public byte[] WrittenBytes
        {
            get
            {
                var result = new byte[this.WrittenCount];
                Array.Copy(this.buffer, 0, result, 0, this.WrittenCount);
                return result;
            }
        }

        /// <summary>
        /// Resets the writer so that it can be reused
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
        /// Grows the backing buffer when fewer than <paramref name="sizeHint"/> bytes are available
        /// </summary>
        /// <param name="sizeHint">The minimum number of bytes that must be available</param>
        private void EnsureCapacity(int sizeHint)
        {
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
            Array.Resize(ref this.buffer, newSize);
        }
    }
}
