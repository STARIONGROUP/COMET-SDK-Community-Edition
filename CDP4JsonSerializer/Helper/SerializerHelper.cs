// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelper.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2026 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    using CDP4Common.Types;

    using CDP4JsonSerializer.Helper;

    /// <summary>
    /// Utility method to convert a JSON token to a CDP4 type
    /// </summary>
    public static class SerializerHelper
    {
        /// <summary>
        /// The maximum duration allowed for regular expression execution.
        /// </summary>
        private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Gets the format of the <see cref="DateTime"/> to use
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        /// <summary>
        /// The default <see cref="System.Text.Json.JsonSerializerOptions"/> instance for this class
        /// </summary>
        private static readonly JsonSerializerOptions JsonSerializerOptions;

        /// <summary>
        /// Regex used for conversion of Json value to string
        /// </summary>
        private static readonly Regex JsonToValueArrayRegex ;

        /// <summary>
        /// Regex used for conversion of HStore value to string
        /// </summary>
        private static readonly Regex HstoreToValueArrayRegex;

        /// <summary>
        /// The size of the buffer that is rented the first time a <see cref="ValueArray{String}"/> is written on a thread
        /// </summary>
        private const int InitialValueArrayBufferSize = 256;

        /// <summary>
        /// The size above which the thread-cached buffer is returned to the pool instead of being kept for the next <see cref="ValueArray{String}"/>
        /// </summary>
        private const int MaxCachedValueArrayBufferSize = 1024 * 1024;

        /// <summary>
        /// The <see cref="JsonWriterOptions"/> used to write the JSON array inside the value of a <see cref="ValueArray{String}"/> property.
        /// The encoder is the one of <see cref="JsonSerializerOptionsCreator.CreateNew"/>, so the escaping is the same as the one of
        /// <see cref="JsonSerializer.Serialize{TValue}(TValue, JsonSerializerOptions)"/> that was used before.
        /// </summary>
        private static readonly JsonWriterOptions ValueArrayWriterOptions = new()
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            Indented = false,
            SkipValidation = true
        };

        /// <summary>
        /// The buffer that receives the JSON array of a <see cref="ValueArray{String}"/>, cached per thread so that no allocation is needed per array
        /// </summary>
        [ThreadStatic] private static PooledByteBufferWriter valueArrayBuffer;

        /// <summary>
        /// The <see cref="Utf8JsonWriter"/> that writes the JSON array of a <see cref="ValueArray{String}"/> into <see cref="valueArrayBuffer"/>, cached per thread
        /// </summary>
        [ThreadStatic] private static Utf8JsonWriter valueArrayWriter;

        /// <summary>
        /// Creates the new instance of the <see cref="SerializerHelper"/> static class
        /// </summary>
        static SerializerHelper()
        {
            JsonSerializerOptions = JsonSerializerOptionsCreator.CreateNew();
            JsonToValueArrayRegex = new(@"^\[(.*)\]$", RegexOptions.Singleline, RegexTimeout);
            HstoreToValueArrayRegex = new(@"^\{(.*)\}$", RegexOptions.Singleline, RegexTimeout);
        }

        /// <summary>
        /// Convert a string to a <see cref="ValueArray{T}"/>
        /// </summary>
        /// <typeparam name="T">The generic type of the <see cref="ValueArray{T}"/></typeparam>
        /// <param name="valueArrayString">The string to convert</param>
        /// <returns>The <see cref="ValueArray{T}"/></returns>
        public static ValueArray<T> FromHstoreToValueArray<T>(string valueArrayString) =>
            ToValueArray<T>(valueArrayString, HstoreToValueArrayRegex);

        /// <summary>
        /// Convert a string to a <see cref="ValueArray{T}"/>
        /// </summary>
        /// <typeparam name="T">The generic type of the <see cref="ValueArray{T}"/></typeparam>
        /// <param name="valueArrayString">The string to convert</param>
        /// <returns>The <see cref="ValueArray{T}"/></returns>
        public static ValueArray<T> ToValueArray<T>(string valueArrayString) => ToValueArray<T>(valueArrayString, JsonToValueArrayRegex);

        /// <summary>
        /// Convert a <see cref="ValueArray{String}"/> to the JSON format
        /// </summary>
        /// <param name="valueArray">The <see cref="ValueArray{String}"/></param>
        /// <returns>The JSON string</returns>
        /// <remarks>
        /// When the value is written into a <see cref="Utf8JsonWriter"/>, use <see cref="WriteValueArray"/> instead: it produces the same
        /// bytes without creating this intermediate <see cref="string"/>.
        /// </remarks>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="valueArray"/> is null</exception>
        public static string ToJsonString(this ValueArray<string> valueArray)
        {
            if (valueArray == null)
            {
                throw new ArgumentNullException(nameof(valueArray));
            }

            var buffer = EncodeValueArray(valueArray);
            var segment = buffer.WrittenSegment;
            var json = Encoding.UTF8.GetString(segment.Array, segment.Offset, segment.Count);
            ReleaseValueArrayBuffer(buffer);

            return json;
        }

        /// <summary>
        /// Writes a <see cref="ValueArray{String}"/> as a property into an <see cref="Utf8JsonWriter"/>, without building an intermediate <see cref="string"/>.
        /// The value is a JSON string that contains the JSON array of the values, as prescribed by ECSS-E-TM-10-25 Annex C:
        /// the output is byte-for-byte the same as <c>writer.WriteString(utf8PropertyName, valueArray.ToJsonString())</c>.
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to</param>
        /// <param name="utf8PropertyName">The UTF-8 encoded name of the property</param>
        /// <param name="valueArray">The <see cref="ValueArray{String}"/> to write</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="writer"/> or <paramref name="valueArray"/> is null</exception>
        public static void WriteValueArray(this Utf8JsonWriter writer, ReadOnlySpan<byte> utf8PropertyName, ValueArray<string> valueArray)
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (valueArray == null)
            {
                throw new ArgumentNullException(nameof(valueArray));
            }

            var buffer = EncodeValueArray(valueArray);
            writer.WriteString(utf8PropertyName, buffer.WrittenSpan);
            ReleaseValueArrayBuffer(buffer);
        }

        /// <summary>
        /// Writes the JSON array of the values of a <see cref="ValueArray{String}"/> as UTF-8 into the buffer that is cached for the current thread
        /// </summary>
        /// <param name="valueArray">The <see cref="ValueArray{String}"/> to encode</param>
        /// <returns>The <see cref="PooledByteBufferWriter"/> that holds the encoded array; release it with <see cref="ReleaseValueArrayBuffer"/></returns>
        private static PooledByteBufferWriter EncodeValueArray(ValueArray<string> valueArray)
        {
            var buffer = valueArrayBuffer ??= new PooledByteBufferWriter(InitialValueArrayBufferSize);
            buffer.Clear();

            var arrayWriter = valueArrayWriter ??= new Utf8JsonWriter(buffer, ValueArrayWriterOptions);
            arrayWriter.Reset(buffer);

            arrayWriter.WriteStartArray();

            foreach (var value in valueArray)
            {
                arrayWriter.WriteStringValue(value);
            }

            arrayWriter.WriteEndArray();
            arrayWriter.Flush();

            return buffer;
        }

        /// <summary>
        /// Makes the thread-cached buffer available for the next <see cref="ValueArray{String}"/>, and drops it when a very large array has grown it
        /// </summary>
        /// <param name="buffer">The <see cref="PooledByteBufferWriter"/> returned by <see cref="EncodeValueArray"/></param>
        private static void ReleaseValueArrayBuffer(PooledByteBufferWriter buffer)
        {
            if (buffer.Capacity > MaxCachedValueArrayBufferSize)
            {
                valueArrayBuffer = null;
                buffer.Dispose();
                return;
            }

            buffer.Clear();
        }

        /// <summary>
        /// Writes an <see cref="OrderedItem"/> into an <see cref="Utf8JsonWriter"/>
        /// </summary>
        /// <param name="writer">The <see cref="Utf8JsonWriter"/></param>
        /// <param name="orderedItem">The <see cref="OrderedItem"/> to write</param>
        public static void WriteOrderedItem(this Utf8JsonWriter writer, OrderedItem orderedItem)
        {
            writer.WriteStartObject();
            writer.WriteNumber("k"u8, orderedItem.K);

            if (orderedItem.M != null)
            {
                writer.WriteNumber("m"u8, orderedItem.M.Value);
            }

            writer.WritePropertyName("v"u8);

            switch (orderedItem.V)
            {
                case string stringValue:
                    writer.WriteStringValue(stringValue);
                    break;
                case Guid guidValue:
                    writer.WriteStringValue(guidValue);
                    break;
                case bool boolValue:
                    writer.WriteBooleanValue(boolValue);
                    break;
                case int intValue:
                    writer.WriteNumberValue(intValue);
                    break;
                case long longValue:
                    writer.WriteNumberValue(longValue);
                    break;
                case double doubleValue:
                    writer.WriteNumberValue(doubleValue);
                    break;
                case float floatValue:
                    writer.WriteNumberValue(floatValue);
                    break;
                default:
                    throw new NotSupportedException($"The type {orderedItem.V.GetType().Name} is not supported for the {nameof(OrderedItem)} serialization");
            }

            writer.WriteEndObject();
        }

        /// <summary>
        /// Instantiate a <see cref="IEnumerable{OrderedItem}"/> from a <see cref="JsonElement"/>
        /// </summary>
        /// <param name="jsonToken">The <see cref="JsonElement"/></param>
        /// <returns>The <see cref="IEnumerable{OrderedItem}"/></returns>
        public static IEnumerable<OrderedItem> ToOrderedItemCollection(this JsonElement jsonToken)
        {
            var list = new List<OrderedItem>();

            foreach (var prop in jsonToken.EnumerateArray())
            {
                var valueProp = prop.GetProperty("v");
                var valueKind = valueProp.ValueKind;

                object valueToAssign = valueKind switch
                {
                    JsonValueKind.String => valueProp.GetString(),
                    JsonValueKind.Number => valueProp.GetInt32(),
                    _ => null
                };

                var keyProp = prop.GetProperty("k");
                valueKind = keyProp.ValueKind;

                var keyValue = valueKind switch
                {
                    JsonValueKind.String => long.Parse(keyProp.GetString()!),
                    JsonValueKind.Number => keyProp.GetInt64(),
                    _ => long.MinValue
                };

                var orderedItem = new OrderedItem
                {
                    K = keyValue,
                    V = valueToAssign
                };

                if (prop.TryGetProperty("m", out var value) && value.ValueKind != JsonValueKind.Null)
                {
                    orderedItem.M = value.GetInt64();
                }

                list.Add(orderedItem);
            }

            return list;
        }

        /// <summary>
        /// Convert a string to a <see cref="ValueArray{T}"/>
        /// </summary>
        /// <typeparam name="T">The generic type of the <see cref="ValueArray{T}"/></typeparam>
        /// <param name="valueArrayString">The string to convert</param>
        /// <param name="regex">The Regex use for conversion</param>
        /// <returns>The <see cref="ValueArray{T}"/></returns>
        private static ValueArray<T> ToValueArray<T>(string valueArrayString, Regex regex)
        {
            var arrayExtractResult = regex.Match(valueArrayString);
            var extractedArrayString = arrayExtractResult.Groups[1].Value;

            // match within 2 unescape double-quote the following content:
            // 1) (no special char \ or ") 0..* times
            // 2) (a pattern that starts with \ followed by any character (special included) and 0..* "non special" characters) 0..* times
            var valueExtractionRegex = new Regex(@"""([^""\\]*(\\.[^""\\]*)*)""", RegexOptions.Singleline, RegexTimeout);
            var test = valueExtractionRegex.Matches(extractedArrayString);

            var stringValues = new List<string>();

            foreach (Match match in test)
            {
                stringValues.Add(JsonSerializer.Deserialize<string>($"\"{match.Groups[1].Value}\""));
            }

            var convertedStringList = stringValues.Select(m => (T)Convert.ChangeType(m, typeof(T))).ToList();

            return new ValueArray<T>(convertedStringList);
        }

        /// <summary>
        /// Convert a <see cref="ValueArray{String}"/> to the HStore format
        /// </summary>
        /// <param name="valueArray">The <see cref="ValueArray{String}"/></param>
        /// <returns>The HStore string</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="valueArray"/> is null</exception>
        public static string ToHstoreString(ValueArray<string> valueArray)
        {
            if (valueArray == null)
            {
                throw new ArgumentNullException(nameof(valueArray));
            }

            var builder = new StringBuilder();
            builder.Append('{');
            var isFirst = true;

            foreach (var value in valueArray)
            {
                if (!isFirst)
                {
                    builder.Append(';');
                }

                builder.Append(JsonSerializer.Serialize(value, JsonSerializerOptions));
                isFirst = false;
            }

            builder.Append('}');

            return builder.ToString();
        }
    }
}
