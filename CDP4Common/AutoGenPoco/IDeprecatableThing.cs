// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDeprecatableThing.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Authors: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov, Smiechowski Nathanael
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
// <summary>
//   This is an auto-generated POCO Interface. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.CommonData
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// thing that can be deprecated, meaning it is declared to be obsolescent
    /// Note: Deprecation is used on objects that become obsolescent and should no longer be used, but cannot be deleted because that would potentially invalidate existing (e.g. archived) datasets that still reference such data. Typically this is the case for instances contained by a SiteDirectory and by ReferenceDataLibraries.
    /// </summary>
    public partial interface IDeprecatableThing
    {
        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        bool IsDeprecated { get; set; }
    }
}
