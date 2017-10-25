// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// Extended part for the auto-generated <see cref="Person"/>
    /// </summary>
    public partial class Person
    {
        /// <summary>
        /// Returns the <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            return string.Format("{0} {1}", this.GivenName, this.Surname);
        }
    }
}