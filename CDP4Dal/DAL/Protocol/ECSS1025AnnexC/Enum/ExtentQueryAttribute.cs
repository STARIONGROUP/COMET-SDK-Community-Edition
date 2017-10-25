// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtentQueryAttribute.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL.ECSS1025AnnexC
{
    /// <summary>
    /// The extent query attribute.
    /// </summary>
    public enum ExtentQueryAttribute
    {
        /// <summary>
        /// Forces the return of the querried object only
        /// </summary>
        shallow,

        /// <summary>
        /// Forces the return of the object and all objects it contains
        /// </summary>
        deep
    }
}
