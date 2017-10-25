// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="RHEA System System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The constant class used in the application
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// The enumeration value separator when multi enumerations may be selected
        /// </summary>
        public const char MultiValueEnumSeparator = '|';

        /// <summary>
        /// The padded multi enumeration separator
        /// </summary>
        public const string PaddedMultiEnumSeparator = " | ";

        /// <summary>
        /// The uri path separator
        /// </summary>
        public const string UriPathSeparator = "/";

        /// <summary>
        /// The uri path separator character
        /// </summary>
        public const char UriPathSeparatorChar = '/';

        /// <summary>
        /// The length of the guid represented in a uri
        /// </summary>
        public const int UriGuidLength = 32;

        /// <summary>
        /// The <see cref="Guid"/> pattern used in the response from a data-source
        /// </summary>
        public const string UriGuidPattern = @"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}";
    }
}