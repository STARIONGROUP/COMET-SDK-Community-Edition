#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iteration.cs" company="RHEA System S.A.">
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Hand-coded part for the auto-generated <see cref="Iteration"/> class.
    /// </summary>
    public partial class Iteration
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> that contains the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Iteration"/> 
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var engineeringModelSetup = (EngineeringModelSetup)this.IterationSetup.Container;
                var requiredModelReferenceDataLibrary = engineeringModelSetup.RequiredRdl.Single();
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);                
                requiredRdls.Add(requiredModelReferenceDataLibrary);
                requiredRdls.UnionWith(requiredModelReferenceDataLibrary.GetRequiredRdls());
                return requiredRdls;
            }
        }
    }
}
