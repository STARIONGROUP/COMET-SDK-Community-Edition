﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.Cdp4PostOperation
{
    using System.Collections.Generic;

    using CDP4Common;
    using CDP4Common.DTO;

    using Newtonsoft.Json;

    /// <summary>
    /// A CdpPostOperation class used for testing purposes
    /// </summary>
    public class CdpPostOperation
    {
        [JsonProperty("_delete")]
        public List<ClasslessDTO> Delete { get; set; }

        [JsonProperty("_create")]
        public List<Thing> Create { get; set; }

        [JsonProperty("_update")]
        public List<ClasslessDTO> Update { get; set; }

        [JsonProperty("_copy")]
        public List<ClasslessDTO> Copy { get; set; }
    }
}