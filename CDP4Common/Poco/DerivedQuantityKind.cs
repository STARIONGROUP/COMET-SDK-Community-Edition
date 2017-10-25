// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;

    /// <summary>
    /// Extended part for the auto-generated <see cref="DerivedQuantityKind"/>
    /// </summary>
    public partial class DerivedQuantityKind
    {
        /// <summary>
        /// Validate this <see cref="DerivedQuantityKind"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected override IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>(base.ValidatePocoProperties());
            if (this.PossibleScale.Count == 0)
            {
                errorList.Add("The PossibleScale property is empty.");
            }

            return errorList;
        }
    }
}