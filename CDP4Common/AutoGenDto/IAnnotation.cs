// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IAnnotation.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Interface. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    /// <summary>
    /// abstract supertype that represents information expressed in human-readable natural language
    /// Note: Multiple alternative annotations may be given in different natural languages.
    /// </summary>
    public partial interface IAnnotation
    {
        /// <summary>
        /// Gets or sets the Content.
        /// </summary>
        /// <remarks>
        /// textual content of the annotation expressed in the natural language as
        /// specified in <i>languageCode</i>
        /// </remarks>
        string Content { get; set; }

        /// <summary>
        /// Gets or sets the LanguageCode.
        /// </summary>
        /// <remarks>
        /// code that defines the natural language in which the annotation is written
        /// </remarks>
        string LanguageCode { get; set; }
    }
}
