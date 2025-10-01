// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonElementExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4JsonSerializer.Extensions
{
    using System.Collections.Generic;
    using System.Text.Json;

    using CDP4Common;
    using CDP4Common.Dto;
    using CDP4Common.DTO;

    using CDP4DalCommon.Protocol.Operations;

    /// <summary>
    /// Extension class for <see cref="System.Text.Json.JsonElement"/>
    /// </summary>
    public static class JsonElementExtensions
    {
        /// <summary>
        /// Deserialize the content of the <see cref="System.Text.Json.JsonElement"/> to the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation"/>
        /// </summary>
        /// <param name="element">The <see cref="System.Text.Json.JsonElement"/></param>
        /// <param name="postOperation">The <see cref="CDP4DalCommon.Protocol.Operations.PostOperation"/> that will receive new value properties</param>
        /// <param name="serializerOptions">The <see cref="System.Text.Json.JsonSerializerOptions"/></param>
        public static void DeserializePostOperation(this JsonElement element, PostOperation postOperation, JsonSerializerOptions serializerOptions)
        {
            if (element.TryGetProperty("_delete", out var deleteElement))
            {
                postOperation.Delete = deleteElement.Deserialize<List<ClasslessDTO>>(serializerOptions);
            }

            if (element.TryGetProperty("_create", out var createElement))
            {
                postOperation.Create = createElement.Deserialize<List<Thing>>(serializerOptions);
            }

            if (element.TryGetProperty("_update", out var updateElement))
            {
                postOperation.Update = updateElement.Deserialize<List<ClasslessDTO>>(serializerOptions);
            }

            if (element.TryGetProperty("_copy", out var copyElement))
            {
                postOperation.Copy = copyElement.Deserialize<List<CopyInfo>>(serializerOptions);
            }
        }
    }
}
