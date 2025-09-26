// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanOperatorKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

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

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
