﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QuantityKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="QuantityKind"/>
    /// </summary>
    public abstract partial class QuantityKind
    {
        /// <summary>
        /// Returns the derived <see cref="AllPossibleScale"/> value
        /// </summary>
        /// <returns>The <see cref="AllPossibleScale"/> value</returns>
        protected List<MeasurementScale> GetDerivedAllPossibleScale()
        {
            var allPossibleScale = new List<MeasurementScale>(this.PossibleScale);

            var specializedQuantityKind = this as SpecializedQuantityKind;
            while (specializedQuantityKind != null)
            {
                var generalQuantityKind = specializedQuantityKind.General;
                allPossibleScale = allPossibleScale.Union(generalQuantityKind.PossibleScale).ToList();
                specializedQuantityKind = generalQuantityKind as SpecializedQuantityKind;
            }

            return allPossibleScale;
        }

        /// <summary>
        /// Returns the derived <see cref="QuantityDimensionExponent"/> value
        /// </summary>
        /// <returns>The <see cref="QuantityDimensionExponent"/> value</returns>
        protected OrderedItemList<string> GetDerivedQuantityDimensionExponent()
        {
            throw new NotSupportedException("The QuantityDimensionExponent computation is not supported by the CDP");
        }

        /// <summary>
        /// Returns the derived <see cref="QuantityDimensionExpression"/> value
        /// </summary>
        /// <returns>The <see cref="QuantityDimensionExpression"/> value</returns>
        protected string GetDerivedQuantityDimensionExpression()
        {
            throw new NotSupportedException("The QuantityDimensionExpression computation is not supported by the CDP");
        }
    }
}