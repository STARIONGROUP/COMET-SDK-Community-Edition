// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdpPostOperation.cs" company="RHEA System S.A.">
//   Copyright (c) 2016 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer_New.Tests.Cdp4PostOperation
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