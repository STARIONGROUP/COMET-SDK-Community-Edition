// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IQueryAttributes.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   The UriQueryAttributes interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL
{
    /// <summary>
    /// The UriQueryAttributes interface.
    /// </summary>
    public interface IQueryAttributes
    {
        /// <summary>
        /// Converts all values of this <see cref="IQueryAttributes"/> class to a uri attributes string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> in the form ?param1=value1 seperated by an ampersand.
        /// </returns>
        string ToString();

        /// <summary>
        /// Joins the attributes into a single string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> with all the attributes seperated by a ampersand.
        /// </returns>
        string JoinAttributes();

        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        int? RevisionNumber { get; set; }
    }
}