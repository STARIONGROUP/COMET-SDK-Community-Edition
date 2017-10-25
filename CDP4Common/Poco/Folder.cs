// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Folder.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System.Text;

    /// <summary>
    /// Extended part for the auto-generated <see cref="Folder"/>
    /// </summary>
    public partial class Folder
    {
        /// <summary>
        /// Returns the derived <see cref="Path"/> value
        /// </summary>
        /// <returns>The <see cref="Path"/> value</returns>
        protected string GetDerivedPath()
        {
            var path = new StringBuilder();
            var containingFolder = this.ContainingFolder;

            while (containingFolder != null)
            {
                if (path.Length > 0)
                {
                    path.Insert(0, "/");
                }

                path.Insert(0, containingFolder.Name);
                containingFolder = containingFolder.ContainingFolder;
            }

            return path.ToString();
        }
    }
}