// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrExpression.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.EngineeringModelData
{
    using System.Collections.Generic;

    /// <summary>
    /// Extended part for the auto-generated <see cref="OrExpression"/>
    /// </summary>
    public partial class OrExpression
    {
        /// <summary>
        /// Gets the representation of the <see cref="OrExpression"/> as a string
        /// </summary>
        public override string StringValue => "OR";

        /// <summary>
        /// Gets the expressions that are direct children of this class
        /// </summary>
        /// <returns><see cref="IReadOnlyList{BooleanExpression}"/> containing <see cref="BooleanExpression"/>s that are direct children of this class</returns>
        public override IReadOnlyList<BooleanExpression> GetMyExpressions() => this.Term;
    }
}