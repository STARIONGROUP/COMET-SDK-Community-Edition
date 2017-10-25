// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOptionDependentThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Interface. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a Thing that can be included in or excluded from one or     more     Options
    /// </summary>
    public partial interface IOptionDependentThing
    {
        /// <summary>
        /// Gets or sets a list of Option.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Options from which this OptionDependentThing is excluded
        /// Note: By default all OptionDependentThings are included in all Options in an EngineeringModel. Only the exclusions are recorded in the data model because this is the most efficient way of storing and handling the option dependency. In client applications it may be more intuitive to show the included Options, but that is a simple transformation.
        /// </remarks>
        List<Option> ExcludeOption { get; set; }
    }
}
