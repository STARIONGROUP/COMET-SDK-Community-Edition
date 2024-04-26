// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelationalOperatorKindMethods.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
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
    /// <summary>
    /// Extension methods for the <see cref="RelationalOperatorKind"/> enum
    /// </summary>
    public static class RelationalOperatorKindMethods
    {
        /// <summary>
        /// Extension method that converts a <see cref="RelationalOperatorKind"/> to a readable string
        /// </summary>
        /// <param name="value"><see cref="RelationalOperatorKind"/> to convert</param>
        /// <returns>String that contains a scientific representation of the <see cref="RelationalOperatorKind"/></returns>
        public static string ToScientificNotationString(this RelationalOperatorKind value)
        {
            switch (value)
            {
                case RelationalOperatorKind.EQ:
                    return "=";

                case RelationalOperatorKind.GE:
                    return "≥";

                case RelationalOperatorKind.GT:
                    return ">";

                case RelationalOperatorKind.LT:
                    return "<";

                case RelationalOperatorKind.LE:
                    return "≤";

                case RelationalOperatorKind.NE:
                    return "≠";

                default:
                    return value.ToString();
            }
        }
    }
}