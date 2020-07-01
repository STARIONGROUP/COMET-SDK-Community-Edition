// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SharedStyleResolver.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Resolver class. Any manual changes on this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    #pragma warning disable S1128
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using Newtonsoft.Json.Linq;
    #pragma warning restore S1128

    /// <summary>
    /// The purpose of the <see cref="SharedStyleResolver"/> is to deserialize a JSON object to a <see cref="SharedStyle"/>
    /// </summary>
    public static class SharedStyleResolver
    {
        /// <summary>
        /// Instantiate and deserialize the properties of a <paramref name="SharedStyle"/>
        /// </summary>
        /// <param name="jObject">The <see cref="JObject"/> containing the data</param>
        /// <returns>The <see cref="SharedStyle"/> to instantiate</returns>
        public static CDP4Common.DTO.SharedStyle FromJsonObject(JObject jObject)
        {
            var iid = jObject["iid"].ToObject<Guid>();
            var revisionNumber = jObject["revisionNumber"].IsNullOrEmpty() ? 0 : jObject["revisionNumber"].ToObject<int>();
            var sharedStyle = new CDP4Common.DTO.SharedStyle(iid, revisionNumber);

            if (!jObject["excludedDomain"].IsNullOrEmpty())
            {
                sharedStyle.ExcludedDomain.AddRange(jObject["excludedDomain"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["excludedPerson"].IsNullOrEmpty())
            {
                sharedStyle.ExcludedPerson.AddRange(jObject["excludedPerson"].ToObject<IEnumerable<Guid>>());
            }

            if (!jObject["fillColor"].IsNullOrEmpty())
            {
                sharedStyle.FillColor = jObject["fillColor"].ToObject<Guid?>();
            }

            if (!jObject["fillOpacity"].IsNullOrEmpty())
            {
                sharedStyle.FillOpacity = jObject["fillOpacity"].ToObject<float?>();
            }

            if (!jObject["fontBold"].IsNullOrEmpty())
            {
                sharedStyle.FontBold = jObject["fontBold"].ToObject<bool?>();
            }

            if (!jObject["fontColor"].IsNullOrEmpty())
            {
                sharedStyle.FontColor = jObject["fontColor"].ToObject<Guid?>();
            }

            if (!jObject["fontItalic"].IsNullOrEmpty())
            {
                sharedStyle.FontItalic = jObject["fontItalic"].ToObject<bool?>();
            }

            if (!jObject["fontName"].IsNullOrEmpty())
            {
                sharedStyle.FontName = jObject["fontName"].ToObject<string>();
            }

            if (!jObject["fontSize"].IsNullOrEmpty())
            {
                sharedStyle.FontSize = jObject["fontSize"].ToObject<float?>();
            }

            if (!jObject["fontStrokeThrough"].IsNullOrEmpty())
            {
                sharedStyle.FontStrokeThrough = jObject["fontStrokeThrough"].ToObject<bool?>();
            }

            if (!jObject["fontUnderline"].IsNullOrEmpty())
            {
                sharedStyle.FontUnderline = jObject["fontUnderline"].ToObject<bool?>();
            }

            if (!jObject["modifiedOn"].IsNullOrEmpty())
            {
                sharedStyle.ModifiedOn = jObject["modifiedOn"].ToObject<DateTime>();
            }

            if (!jObject["name"].IsNullOrEmpty())
            {
                sharedStyle.Name = jObject["name"].ToObject<string>();
            }

            if (!jObject["strokeColor"].IsNullOrEmpty())
            {
                sharedStyle.StrokeColor = jObject["strokeColor"].ToObject<Guid?>();
            }

            if (!jObject["strokeOpacity"].IsNullOrEmpty())
            {
                sharedStyle.StrokeOpacity = jObject["strokeOpacity"].ToObject<float?>();
            }

            if (!jObject["strokeWidth"].IsNullOrEmpty())
            {
                sharedStyle.StrokeWidth = jObject["strokeWidth"].ToObject<float?>();
            }

            if (!jObject["usedColor"].IsNullOrEmpty())
            {
                sharedStyle.UsedColor.AddRange(jObject["usedColor"].ToObject<IEnumerable<Guid>>());
            }

            return sharedStyle;
        }
    }
}
