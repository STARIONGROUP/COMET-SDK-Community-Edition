// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICategorizableThing.cs" company="RHEA System S.A.">
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
    /// representation of a Thing that can be categorized to be a member of a       user-defined       Category
    /// Note 1: Categorization using Categories establishes a runtime       classification       mechanism,       that       can       be       used       to       classify       architectural       elements,       parameter       types,       etc.,       and       form       the       basis       for       view       definitions,       filter       operations       and       validation       rules.
    /// Note 2: Categories are (pre)defined in ReferenceDataLibraries.
    /// Note 3: Assignment of a given Category to the <i>category</i> property       of       a       CategorizableThing       asserts       that       it       is       a       member       of       the       given       Category.
    /// </summary>
    public partial interface ICategorizableThing
    {
        /// <summary>
        /// Gets or sets the unique identifiers of the referenced Category instances.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Categories of which this CategorizableThing is a member
        /// </remarks>
        List<Guid> Category { get; set; }
    }
}
