// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrefixedUnit.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// Extended part for the auto-generated <see cref="PrefixedUnit"/>
    /// </summary>
    public partial class PrefixedUnit
    {
        /// <summary>
        /// Returns the derived <see cref="ConversionFactor"/> value
        /// </summary>
        /// <returns>The <see cref="ConversionFactor"/> value</returns>
        protected string GetDerivedConversionFactor()
        {
            return this.Prefix == null ? string.Empty : this.Prefix.ConversionFactor;
        }

        /// <summary>
        /// Returns the derived <see cref="Name"/> value
        /// </summary>
        /// <returns>The <see cref="Name"/> value</returns>
        protected string GetDerivedName()
        {
            if (this.Prefix != null && this.ReferenceUnit != null)
            {
                return this.Prefix.Name + this.ReferenceUnit.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Returns the derived <see cref="ShortName"/> value
        /// </summary>
        /// <returns>The <see cref="ShortName"/> value</returns>
        protected string GetDerivedShortName()
        {
            if (this.Prefix != null && this.ReferenceUnit != null)
            {
                return this.Prefix.ShortName + this.ReferenceUnit.ShortName;
            }

            return string.Empty;
        }
    }
}