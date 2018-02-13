#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectory.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using CDP4Common.SiteDirectoryData;
    
    /// <summary>
    /// Extended part for the auto-generated <see cref="SiteDirectory"/>
    /// </summary>
    public partial class SiteDirectory
    {
        /// <summary>
        /// Gets the available <see cref="ReferenceDataLibrary"/> that are contained by the current <see cref="SiteDirectory"/> either
        /// directly as <see cref="SiteReferenceDataLibrary"/> or as <see cref="ModelReferenceDataLibrary"/> through the
        /// <see cref="EngineeringModelSetup"/> the <see cref="SiteDirectory"/> contains.
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{ReferenceDataLibrary}"/>
        /// </returns>
        public IEnumerable<ReferenceDataLibrary> AvailableReferenceDataLibraries()
        {
            foreach (var siteReferenceDataLibrary in this.SiteReferenceDataLibrary)
            {
                yield return siteReferenceDataLibrary;
            }

            foreach (var engineeringModelSetup in this.Model)
            {
                var rdl = engineeringModelSetup.RequiredRdl.SingleOrDefault();
                if (rdl != null)
                {
                    yield return rdl;
                }
            }
        }
    }
}
