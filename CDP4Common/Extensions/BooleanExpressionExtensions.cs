// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionExtensions.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    }
}