#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementBase.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;
    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ElementBase"/>
    /// </summary>
    public abstract partial class ElementBase : IPublishable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ElementBase"/> can be published.
        /// </summary>
        public abstract bool CanBePublished { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ElementBase"/> will be published in the next <see cref="Publication"/>.
        /// </summary>
        public abstract bool ToBePublished { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the 
        /// required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdl = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                foreach (var category in this.Category)
                {
                    requiredRdl.UnionWith(category.RequiredRdls);
                }

                return requiredRdl;
            }
        }
    }
}
