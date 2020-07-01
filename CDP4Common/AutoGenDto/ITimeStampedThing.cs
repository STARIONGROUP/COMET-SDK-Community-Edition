// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ITimeStampedThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Interface. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    #pragma warning disable S1128
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    #pragma warning restore S1128

    /// <summary>
    /// representation of a thing with a timestamp that records its creation time
    /// </summary>
    public partial interface ITimeStampedThing
    {
        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        /// <remarks>
        /// Note 1: This implies that any value shall comply with the following (informative) ISO 8601 format "yyyy-mm-ddThh:mm:ss.sssZ".
        /// Note 2: All persistent date-and-time-stamps in this model shall be stored in UTC. When local calendar dates and clock times in a specific timezone are needed they shall be converted on the fly from and to UTC by client applications.
        /// </remarks>
        DateTime CreatedOn { get; set; }
    }
}
