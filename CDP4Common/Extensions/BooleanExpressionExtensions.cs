// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionExtensions.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// This class contains methods for specific BooleanExpression related functionality 
    /// </summary>
    public static class BooleanExpressionExtensions
    {
        /// <summary>
        /// Gets the expressions that are toplevel for this list of <see cref="BooleanExpression"/>
        /// </summary>
        /// <returns><see cref="IReadOnlyList{BooleanExpression}"/> containing top level <see cref="BooleanExpression"/>s</returns>
        public static IReadOnlyList<BooleanExpression> GetTopLevelExpressions(this IList<BooleanExpression> expressionList)
        {
            var notInTerms = new List<BooleanExpression>();

            foreach (var thingExpression in expressionList)
            {
                switch (thingExpression.ClassKind)
                {
                    case ClassKind.NotExpression:
                        if (thingExpression is NotExpression notExpression && !notInTerms.Contains(notExpression.Term))
                        {
                            notInTerms.Add(notExpression.Term);
                        }

                        break;

                    case ClassKind.AndExpression:
                        notInTerms.AddRange(((AndExpression)thingExpression).Term.Where(x => !notInTerms.Contains(x)));

                        break;

                    case ClassKind.OrExpression:
                        notInTerms.AddRange(((OrExpression)thingExpression).Term.Where(x => !notInTerms.Contains(x)));

                        break;

                    case ClassKind.ExclusiveOrExpression:
                        notInTerms.AddRange(((ExclusiveOrExpression)thingExpression).Term.Where(x => !notInTerms.Contains(x)));

                        break;
                }
            }

            return expressionList.Where(x => !notInTerms.Contains(x)).ToList();
        }

        /// <summary>
        /// Creates a string that represents a tree of (nested) <see cref="BooleanExpression"/>s.
        /// </summary>
        /// <param name="booleanExpression">The <see cref="BooleanExpression"/> for which the tree will be built</param>
        /// <param name="isTopLevel">Indicates that the current expression is a Top Level expression in the result <see cref="string"/>.</param>
        /// <returns>A <see cref="string"/> that represents the <see cref="BooleanExpression"/> tree</returns>
        public static string ToExpressionString(this BooleanExpression booleanExpression, bool isTopLevel = true)
        {
            var stringBuilder = new StringBuilder();

            booleanExpression.GetStringExpression(stringBuilder, isTopLevel);

            if (booleanExpression.ClassKind == ClassKind.NotExpression)
            {
                stringBuilder.Insert(0, $"{((NotExpression)booleanExpression).StringValue} ");
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Builds a string that represents the whole tree for the <see cref="BooleanExpression"/> of the given row.
        /// </summary>
        /// <param name="expression">The <see cref="BooleanExpression"/></param>
        /// <param name="stringBuilder">The <see cref="StringBuilder"/> to use.</param>
        /// <param name="isTopLevel">Indicates that the current expression is a Top Level expression in the result <see cref="string"/>.</param>
        private static void GetStringExpression(this BooleanExpression expression, StringBuilder stringBuilder, bool isTopLevel = false)
        {
            if (expression.ClassKind == ClassKind.RelationalExpression)
            {
                stringBuilder.Append("(");
                stringBuilder.Append(expression.StringValue.Trim());
                stringBuilder.Append(")");
            }
            else
            {
                if (!isTopLevel)
                {
                    stringBuilder.Append("(");
                }

                var expressions = expression.GetMyExpressions();

                foreach (var containedExpression in expressions)
                {
                    if (containedExpression.ClassKind == ClassKind.NotExpression)
                    {
                        stringBuilder.Append($" {expression.StringValue} (");

                        containedExpression.GetStringExpression(stringBuilder);
                    }
                    else
                    {
                        containedExpression.GetStringExpression(stringBuilder);

                        if (containedExpression != expressions.Last())
                        {
                            stringBuilder.Append($" {expression.StringValue} ");
                        }
                    }
                }

                if (!isTopLevel)
                {
                    stringBuilder.Append(")");
                }
            }
        }
    }
}