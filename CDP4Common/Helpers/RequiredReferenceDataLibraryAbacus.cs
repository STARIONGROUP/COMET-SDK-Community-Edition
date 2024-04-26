// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequiredReferenceDataLibraryAbacus.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="RequiredReferenceDataLibraryAbacus"/> is to compute the
    /// chain of Required <see cref="ReferenceDataLibrary"/>s
    /// </summary>
    internal static class RequiredReferenceDataLibraryAbacus
    {
        /// <summary>
        /// Computes the <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// an <see cref="IEnumerable{ReferenceDataLibrary}"/> of hte required <see cref="ReferenceDataLibrary"/>s for the current <see cref="Thing"/>
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// Thrown when this method is invoked on a class that is not directly contained by a <see cref="ReferenceDataLibrary"/>
        /// </exception>
        internal static IEnumerable<ReferenceDataLibrary> ComputeRequiredRdls(this Thing thing)
        {
            var rdl = thing.Container as ReferenceDataLibrary;
            if (rdl == null)
            {
                throw new InvalidOperationException("The ComputeRequiredRdls method may only be invoked on classes that are directly contained by a ReferenceDataLibrary");
            }

            var requiredRdls = new HashSet<ReferenceDataLibrary>();
            requiredRdls.Add(rdl);
            requiredRdls.UnionWith(rdl.GetRequiredRdls());
            return requiredRdls;
        }
    }
}