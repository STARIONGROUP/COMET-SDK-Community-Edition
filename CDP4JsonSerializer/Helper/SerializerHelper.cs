// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelper.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Text.RegularExpressions;

    using CDP4Common.Types;

    /// <summary>
    /// Utility method to convert a JSON token to a CDP4 type
    /// </summary>
    public static class SerializerHelper
    {
        /// <summary>
        /// Gets the format of the <see cref="DateTime"/> to use
        /// </summary>
        public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        /// <summary>
        /// Regex used for conversion of Json value to string
        /// </summary>
        private static readonly Regex JsonToValueArrayRegex = new(@"^\[(.*)\]$", RegexOptions.Singleline);

        /// <summary>
        /// Regex used for conversion of HStore value to string
        /// </summary>
        private static readonly Regex HstoreToValueArrayRegex = new(@"^\{(.*)\}$", RegexOptions.Singleline);

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
        public static string ToJsonString(this ValueArray<string> valueArray)
        {
            var items = ValueArrayToStringList(valueArray);
            return $"[{string.Join(",", items)}]";
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
                var keyProp = prop.GetProperty("k");
                var valueKind = keyProp.ValueKind;
                var key = long.MinValue;

                if (valueKind == JsonValueKind.String)
                {
                    key = Convert.ToInt64(keyProp.GetString());
                }
                else if (valueKind == JsonValueKind.Number)
                {
                    key = keyProp.GetInt64();
                }

                var orderedItem = new OrderedItem
                {
                    K = key,
                    V = prop.GetProperty("v").GetString(),
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
            var valueExtractionRegex = new Regex(@"""([^""\\]*(\\.[^""\\]*)*)""", RegexOptions.Singleline);
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
        public static string ToHstoreString(ValueArray<string> valueArray)
        {
            var items = ValueArrayToStringList(valueArray);
            return $"{{{string.Join(";", items)}}}";
        }

        /// <summary>
        /// Escape double quote and backslash
        /// </summary>
        /// <param name="valueArray"></param>
        /// <returns>IEnumerable containing escaped strings</returns>
        private static IEnumerable<string> ValueArrayToStringList(ValueArray<string> valueArray)
        {
            var items = valueArray.ToList();

            for (var i = 0; i < items.Count; i++)
            {
                items[i] = $"{JsonSerializer.Serialize(items[i], SerializerOptions.Options)}";
            }

            return items;
        }
    }
}
