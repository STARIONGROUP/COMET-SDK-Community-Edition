// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IThingSerializer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.DTO;
    using Newtonsoft.Json.Linq;

    public interface IThingSerializer
    {
        /// <summary>
        /// Gets the map containing the serialization method for each property
        /// </summary>
        IReadOnlyDictionary<string, Func<object, JToken>> PropertySerializerMap { get; }

        /// <summary>
        /// Serialize the <see cref="Thing"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to serialize</param>
        /// <returns>The <see cref="JObject"/></returns>
        JObject Serialize(Thing thing);
    }
}