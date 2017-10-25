// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializerHelper.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Utility method to convert a JSON token to a CDP4 type
    /// </summary>
    public static class SerializerHelper
    {
        /// <summary>
        /// Convert a string to a <see cref="ValueArray{T}"/>
        /// </summary>
        /// <typeparam name="T">The generic type of the <see cref="ValueArray{T}"/></typeparam>
        /// <param name="valueArrayString">The string to convert</param>
        /// <returns>The <see cref="ValueArray{T}"/></returns>
        public static ValueArray<T> ToValueArray<T>(string valueArrayString)
        {
            // remove the [ ]
            var parsed = valueArrayString.Replace("[", string.Empty).Replace("]", string.Empty);

            // remove double quote
            parsed = Regex.Replace(parsed, "[\\\"]", string.Empty);

            // get the values
            var values = parsed.Split(',').ToList();

            var returned = values.Select(m => (T)Convert.ChangeType(m.Trim(), typeof(T))).ToList();
            return new ValueArray<T>(returned);
        }

        /// <summary>
        /// Convert a <see cref="ValueArray{String}"/> to the JSON format
        /// </summary>
        /// <param name="valueArray">The <see cref="ValueArray{String}"/></param>
        /// <returns>The JSON string</returns>
        public static string ToJsonString(this ValueArray<string> valueArray)
        {
            var items = valueArray.ToList();
            for (var i = 0; i < items.Count; i++)
            {
                items[i] = string.Format("\"{0}\"", items[i]);
            }

            return string.Format("[{0}]", string.Join(",", items));
        }

        /// <summary>
        /// Serialize a <see cref="OrderedItem"/> to a <see cref="JObject"/>
        /// </summary>
        /// <param name="orderedItem">The <see cref="OrderedItem"/></param>
        /// <returns>The <see cref="JObject"/></returns>
        public static JObject ToJsonObject(this OrderedItem orderedItem)
        {
            var jsonObject = new JObject();
            jsonObject.Add("k", new JValue(orderedItem.K));

            if (orderedItem.M != null)
            {
                jsonObject.Add("m", new JValue(orderedItem.M));
            }

            jsonObject.Add("v", new JValue(orderedItem.V));
            return jsonObject;
        }

        /// <summary>
        /// Instantiate a <see cref="IEnumerable{OrderedItem}"/> from a <see cref="JToken"/>
        /// </summary>
        /// <param name="jsonToken">The <see cref="JToken"/></param>
        /// <returns>The <see cref="IEnumerable{OrderedItem}"/></returns>
        public static IEnumerable<OrderedItem> ToOrderedItemCollection(this JToken jsonToken)
        {
            var list = new List<OrderedItem>();
            foreach (var token in jsonToken)
            {
                var orderedItem = new OrderedItem
                {
                    K = token["k"].ToObject<long>(),
                    V = token["v"].ToString()
                };

                list.Add(orderedItem);
            }

            return list;
        }

        /// <summary>
        /// Assert Whether a <see cref="JToken"/> is null or empty
        /// </summary>
        /// <param name="token">The <see cref="JToken"/></param>
        /// <returns>True if the <see cref="JToken"/> is null or empty</returns>
        public static bool IsNullOrEmpty(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
