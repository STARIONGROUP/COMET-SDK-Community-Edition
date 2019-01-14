#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibrary.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using CDP4Common.CommonData;

    public abstract partial class ReferenceDataLibrary
    {
        /// <summary>
        /// Gets the chain of required Rdl for this <see cref="ReferenceDataLibrary"/>
        /// </summary>
        /// <returns>An iterator of the chain of required Rdl</returns>
        public IEnumerable<ReferenceDataLibrary> GetRequiredRdls()
        {
            var requiredRdl = this.RequiredRdl;
            while (requiredRdl != null)
            {
                yield return requiredRdl;
                requiredRdl = requiredRdl.RequiredRdl;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains 
        /// the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                requiredRdls.UnionWith(this.GetRequiredRdls());
                return requiredRdls;
            }
        }

        /// <summary>
        /// Gets the aggragation of all required <see cref="ReferenceDataLibrary"/> besides the current one
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> AggregatedReferenceDataLibrary
        {
            get
            {
                yield return this;
                foreach (var rdl in this.GetRequiredRdls())
                {
                    yield return rdl;
                }
            }
        }
    }
}