// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelper.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Jaime Bernar
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

namespace CDP4JsonSerializer_SystemTextJson
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Text.Json;

    using CDP4Common.Types;
    using System.Text.Json.Nodes;
    using System.Text.Json.Serialization;

    /// <summary>
    /// Utility method to convert a JSON token to a CDP4 type
    /// </summary>
    public static class SerializerHelper
    {
        /// <summary>
        /// Regex used for conversion of Json value to string
        /// </summary>
        private static readonly Regex JsonToValueArrayRegex = new Regex(@"^\[(.*)\]$", RegexOptions.Singleline);
        
        /// <summary>
        /// Regex used for conversion of HStore value to string
        /// </summary>
        private static readonly Regex HstoreToValueArrayRegex = new Regex(@"^\{(.*)\}$", RegexOptions.Singleline);

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
        /// Serialize the <see cref="OrderedItem"/> to a <see cref="JsonObject"/>
        /// </summary>
        /// <param name="orderedItem">the <see cref="OrderedItem"/></param>
        /// <returns>the <see cref="JsonObject"/></returns>
        public static JsonObject ToJsonObject(this OrderedItem orderedItem)
        {
            var jsonObject = new JsonObject();                       

            jsonObject.Add("k", JsonValue.Create(orderedItem.K));

            if(orderedItem.M != null)
            {
                jsonObject.Add("m", JsonValue.Create(orderedItem.M));
            }

            jsonObject.Add("v", JsonValue.Create(orderedItem.V));
            return jsonObject;
        }

        /// <summary>
        /// Instantiate a <see cref="IEnumerable{OrderedItem}"/> from a <see cref="JsonElement"/>
        /// </summary>
        /// <param name="jsonToken">The <see cref="JsonElement"/></param>
        /// <returns>The <see cref="IEnumerable{OrderedItem}"/></returns>
        public static IEnumerable<OrderedItem> ToOrderedItemCollection(this JsonElement jsonToken)
        {
            var list = new List<OrderedItem>();
            foreach(var prop in jsonToken.EnumerateArray())
            {
                var orderedItem = new OrderedItem
                {
                    K = prop.GetProperty("k").GetInt64(),
                    V = prop.GetProperty("v").ToString(),
                };

                var move = prop.GetProperty("m");

                if (move.TryGetProperty("m", out var value))
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
                items[i] = $"{JsonSerializer.Serialize(items[i])}";
            }

            return items;
        }
    }
}
