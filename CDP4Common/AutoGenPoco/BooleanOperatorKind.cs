// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanOperatorKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
