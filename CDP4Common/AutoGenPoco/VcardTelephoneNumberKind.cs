// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VcardTelephoneNumberKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// <a id="ParameterValueKind">enumeration datatype that represents</a> the possible values for a vCard telephone numberNote: The values are defined in the vCard format specification in <a href="http://datatracker.ietf.org/doc/rfc6350/?include_text=1">IETF RFC 6350</a>.
    /// </summary>
    public enum VcardTelephoneNumberKind
    {
        /// <summary>
        /// indication that a telephone number is for professional use
        /// </summary>
        WORK,

        /// <summary>
        /// indication that a telephone number is for private or home use
        /// </summary>
        HOME,

        /// <summary>
        /// indication of a voice telephone number
        /// </summary>
        VOICE,

        /// <summary>
        /// indication that the telephone number supports text messages (SMS)
        /// </summary>
        TEXT,

        /// <summary>
        /// indication of a facsimile telephone number
        /// </summary>
        FAX,

        /// <summary>
        /// indication of a cellular or mobile telephone number
        /// </summary>
        CELL,

        /// <summary>
        /// indication of a paging device telephone number
        /// </summary>
        PAGER,

        /// <summary>
        /// indication of a telecommunication device for people with hearing or speech difficulties
        /// </summary>
        TEXTPHONE,

        /// <summary>
        /// indication of a video conferencing telephone number
        /// </summary>
        VIDEO,
    }
}
