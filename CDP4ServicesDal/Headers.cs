// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Headers.cs" company="RHEA System S.A.">
//   Copyright (c) 2015-2018 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal
{
    /// <summary>
    /// Definition of header constants
    /// </summary>
    internal static class Headers
    {
        /// <summary>
        /// The header that is used to communicate the version of the server that is being used
        /// </summary>
        /// <remarks>
        /// The version is specified as a string with the following format: x.y.z
        /// </remarks>
        internal const string CDPServer = "CDP4-Server";

        /// <summary>
        /// The header that specifies the version of the CDP4Common library that is being used
        /// </summary>
        /// <remarks>
        /// The version is specified as a string with the following format: x.y.z
        /// </remarks>
        internal const string CDPCommon = "CDP4-Common";

        /// <summary>
        /// The header that specifies the ECCS-E-TM-10-25 protocol and it's version
        /// </summary>
        /// <remarks>
        /// the value shall have the following form: application/ecss-e-tm-10-25+json; version=x.y.z
        /// </remarks>
        internal const string ContentType = "Content-Type";

        /// <summary>
        /// The header that specifies that the client accepts CDP extensions.
        /// </summary>
        internal const string AcceptCdpVersion = "Accept-CDP";

        /// <summary>
        /// The header that specifies the version of CDP extensions that are accepted
        /// </summary>
        internal const string AcceptCdpVersionValue = "1.1.0";
    }
}
