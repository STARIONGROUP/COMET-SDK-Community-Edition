// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WspQueryAttributes.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL
{
    using System.Collections.Generic;

    /// <summary>
    /// The base query attributes
    /// </summary>
    public class DalQueryAttributes : IQueryAttributes
    {
        /// <summary>
        /// Gets or sets the revision number.
        /// </summary>
        public int? RevisionNumber { get; set; }

        /// <summary>
        /// Converts all values of this <see cref="DalQueryAttributes"/> class to a uri attributes string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> in the form ?param1=value1 seperated by an ampersand.
        /// </returns>
        public override string ToString()
        {
            var attributeString = this.JoinAttributes();
            return string.IsNullOrEmpty(attributeString) ? string.Empty : string.Format("?{0}", attributeString);
        }

        /// <summary>
        /// Joins the attributes into a single string
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> with all the attributes separated by a ampersand.
        /// </returns>
        public virtual string JoinAttributes()
        {
            var attributeList = new List<string>();

            if (this.RevisionNumber != null)
            {
                attributeList.Add(string.Format("revisionNumber={0}", this.RevisionNumber));
            }

            if (attributeList.Count == 0)
            {
                return string.Empty;
            }

            var joined = string.Join("&", attributeList);
            return joined;
        }
    }
}
