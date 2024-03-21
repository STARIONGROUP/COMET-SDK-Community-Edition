// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer.Tests.Cdp4PostOperation
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    using CDP4Common;
    using CDP4Common.DTO;

    /// <summary>
    /// A CdpPostOperation class used for testing purposes
    /// </summary>
    public class CdpPostOperation
    {
        [JsonPropertyName("_delete")]
        public List<ClasslessDTO> Delete { get; set; }

        [JsonPropertyName("_create")]
        public List<Thing> Create { get; set; }

        [JsonPropertyName("_update")]
        public List<ClasslessDTO> Update { get; set; }

        [JsonPropertyName("_copy")]
        public List<ClasslessDTO> Copy { get; set; }
    }
}
