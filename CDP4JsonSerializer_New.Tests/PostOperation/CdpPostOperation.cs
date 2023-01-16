// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="RHEA System S.A.">
//   Copyright (c) 2016 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_SystemTextJson.Tests.Cdp4PostOperation
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