#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanOperatorKind.cs" company="RHEA System S.A.">
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
    /// <summary>
    /// enumeration datatype that represents a simple set of boolean operatorsNote: For an explanation of the operators see <a href="http://en.wikipedia.org/wiki/Boolean_algebra#Basic_operations">WikipediaBoolean_algebra Basic_operations</a>.
    /// </summary>
    public enum BooleanOperatorKind
    {
        /// <summary>
        /// conjunction boolean operatorNote: When both operands are true then the result is true, otherwise false.
        /// </summary>
        AND,

        /// <summary>
        /// disjunction boolean operatorNote: When at least one operand is true then the result is true,otherwise false.
        /// </summary>
        OR,

        /// <summary>
        /// exclusive or boolean operatorNote: When one operand is true and the other is false then the result istrue, when both operands are true or both are false then the result isfalse.
        /// </summary>
        XOR,
    }
}
