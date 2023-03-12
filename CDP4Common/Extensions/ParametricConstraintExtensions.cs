// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintExtensions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.Extensions
{
    using System.Linq;
    using System.Text;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// This class contains methods for specific ParametricConstraint related functionality 
    /// </summary>
    public static class ParametricConstraintExtensions
    {
        /// <summary>
        /// Creates a string that represents a tree of (nested) <see cref="BooleanExpression"/>s for a <see cref="ParametricConstraint"/>.
        /// </summary>
        /// <param name="parametricConstraint">The <see cref="ParametricConstraint"/> for which the tree will be built</param>
        /// <returns>A <see cref="string"/> that represents the <see cref="BooleanExpression"/> tree</returns>
        public static string ToExpressionString(this ParametricConstraint parametricConstraint)
        {
            var stringBuilder = new StringBuilder();

            var expressions = parametricConstraint.Expression.GetTopLevelExpressions();

            if (expressions.Any())
            {
                foreach (var expression in expressions)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(" AND ");
                    }

                    stringBuilder.Append(expression.ToExpressionString());
                }
            }

            return stringBuilder.ToString();
        }
    }
}