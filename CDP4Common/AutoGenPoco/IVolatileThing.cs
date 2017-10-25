// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVolatileThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Interface. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.CommonData
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a thing that can be volatile
    /// Note: A volatile thing may or may not be persisted in a persistent data store, depending on the value of its <i>isVolatile</i> property. This serves to enable runtime-only use of such instances in a client application.
    /// </summary>
    public partial interface IVolatileThing
    {
        /// <summary>
        /// Gets or sets a value indicating whether IsVolatile.
        /// </summary>
        /// <remarks>
        /// Note: When an instance is marked volatile it will not be persisted in the persistent data store. This meant to allow for runtime-only use of such instances in a client application.
        /// </remarks>
        bool IsVolatile { get; set; }
    }
}
