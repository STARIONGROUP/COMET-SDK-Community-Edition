// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpression.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using System.Linq;

    using CDP4Common.Extensions;

    /// <summary>
    /// Extended part for the auto-generated <see cref="BooleanExpression"/>
    /// </summary>
    public abstract partial class BooleanExpression
    {
        /// <summary>
        /// Gets the representation of the <see cref="BooleanExpression"/> as a string
        /// </summary>
        public abstract string StringValue { get; }

        /// <summary>
        /// Gets the expressions that are direct children of me or are "free" at the toplevel of the <see cref="BooleanExpression"/> tree.
        /// "Free" means not set as a child of another <see cref="BooleanExpression"/>.
        /// </summary>
        /// <returns><see cref="IReadOnlyList{T}"/> containing <see cref="BooleanExpression"/>s that are direct children of the class in the <see cref="myself"/> parameter or that are not set as a child for another <see cref="BooleanExpression"/></returns>
        public IReadOnlyList<BooleanExpression> GetMyAndFreeExpressions()
        {
            var myExpressions = new List<BooleanExpression>();

            myExpressions.AddRange(this.GetMyExpressions());

            if (this.Container is ParametricConstraint parametricConstraint)
            {
                myExpressions.AddRange(parametricConstraint.Expression.GetTopLevelExpressions().OfType<RelationalExpression>().Where(x => !myExpressions.Contains(x)));
            }

            return myExpressions.ToList();
        }

        /// <summary>
        /// Gets the expressions that are direct children of this class
        /// </summary>
        /// <returns><see cref="IReadOnlyList{BooleanExpression}"/> containing <see cref="BooleanExpression"/>s that are direct children of this class</returns>
        protected abstract IReadOnlyList<BooleanExpression> GetMyExpressions();

        /// <summary>
        /// Gets all descendant expressions of this class
        /// </summary>
        /// <returns><see cref="IReadOnlyList{BooleanExpression}"/> containing <see cref="BooleanExpression"/>s all descendant expressions of this class</returns>
        public IReadOnlyList<BooleanExpression> GetMeAndMyDescendantExpressions()
        {
            var myDescendants = new List<BooleanExpression>();

            this.TryAddMeAndMyDescendants(myDescendants);

            return myDescendants.ToList();
        }

        /// <summary>
        /// Add a<see cref="BooleanExpression"/> to a list if it is not allready contained in that list
        /// </summary>
        /// <param name="expressions"><see cref="ICollection{BooleanExpression}"/> where the <see cref="BooleanExpression"/> should be added to if not allready there</param>
        private void TryAddMeAndMyDescendants(ICollection<BooleanExpression> expressions)
        {
            if (expressions.Contains(this))
            {
                return;
            }

            expressions.Add(this);
            foreach (var expression in this.GetMyExpressions())
            {
                expression.TryAddMeAndMyDescendants(expressions);
            }
        }
    }
}