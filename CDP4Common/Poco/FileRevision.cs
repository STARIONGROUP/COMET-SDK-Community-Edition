// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevision.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Text;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="FileRevision"/>
    /// </summary>
    public partial class FileRevision
    {
        /// <summary>
        /// Returns the derived <see cref="Path"/> value
        /// </summary>
        /// <returns>The <see cref="Path"/> value</returns>
        protected string GetDerivedPath()
        {
            var path = new StringBuilder();
            var containingFolder = this.ContainingFolder;
            if (containingFolder != null)
            {
                path.Append(containingFolder.Path);
                path.Append("/");
            }

            path.Append(this.ContainingFolder.Name);
            path.Append("/");
            path.Append(this.Name);

            foreach (FileType fileType in this.FileType)
            {
                path.Append(".");
                path.Append(fileType.Extension);
            }

            return path.ToString();
        }
    }
}