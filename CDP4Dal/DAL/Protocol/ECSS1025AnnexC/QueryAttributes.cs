// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueryAttributes.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.DAL.ECSS1025AnnexC
{
    using System.Collections.Generic;

    /// <summary>
    /// The ECSS 1025 Annex C request query attributes. Appended to the query if required
    /// </summary>
    public class QueryAttributes : DalQueryAttributes
    {
        /// <summary>
        /// Gets or sets the <see cref="ExtentQueryAttribute"/> of the query.
        /// </summary>
        public ExtentQueryAttribute? Extent { get; set; }

        /// <summary>
        /// Gets or sets whether to query the include reference data.
        /// </summary>
        public bool? IncludeReferenceData { get; set; }

        /// <summary>
        /// Gets or sets whether to include all containers.
        /// </summary>
        public bool? IncludeAllContainers { get; set; }

        /// <summary>
        /// Gets or sets whether to include the file data.
        /// </summary>
        public bool? IncludeFileData { get; set; }

        /// <summary>
        /// Converts all values of this <see cref="QueryAttributes"/> class to a uri attributes string
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
        public override string JoinAttributes()
        {
            var attributeList = new List<string>();

            if (this.Extent != null)
            {
                attributeList.Add(string.Format("extent={0}", this.Extent));
            }

            if (this.IncludeReferenceData != null)
            {
                attributeList.Add(string.Format("includeReferenceData={0}", this.IncludeReferenceData.ToString().ToLower()));
            }

            if (this.IncludeAllContainers != null)
            {
                attributeList.Add(string.Format("includeAllContainers={0}", this.IncludeAllContainers.ToString().ToLower()));
            }

            if (this.IncludeFileData != null)
            {
                attributeList.Add(string.Format("includeFileData={0}", this.IncludeFileData.ToString().ToLower()));
            }

            // include the base attributelist
            var baseJoinedAttributes = base.JoinAttributes();
            if (!string.IsNullOrEmpty(baseJoinedAttributes))
            {
                attributeList.Add(baseJoinedAttributes);
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
