// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Operations
{
    using CDP4Common.DTO;

    /// <summary>
    /// The kind of <see cref="Operation"/> acting on the object.
    /// </summary>
    public enum OperationKind
    {
        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Create operation
        /// </summary>
        Create,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is an Update operation
        /// </summary>
        Update,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Delete operation
        /// </summary>
        Delete,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a Move operation
        /// </summary>
        Move,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "shift" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain default "-" values.
        /// A copy <see cref="IOwnedThing"/> shall keep its original owner
        /// </remarks>
        Copy,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "ctrl" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain original values.
        /// A copy <see cref="IOwnedThing"/> shall have its owner set to the active one in the target destination.
        /// </remarks>
        CopyKeepValuesChangeOwner,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "dry" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain default "-" values.
        /// A copy <see cref="IOwnedThing"/> shall have its owner set to the active one in the target destination.
        /// </remarks>
        CopyDefaultValuesChangeOwner,

        /// <summary>
        /// specifies that the <see cref="Operation"/> on the <see cref="Thing"/> is a "ctrl + shift" Copy operation
        /// </summary>
        /// <remarks>
        /// If <see cref="ParameterBase"/> are copied their value-sets shall contain the original values.
        /// A copy <see cref="IOwnedThing"/> shall keep its original owner
        /// </remarks>
        CopyKeepValues
    }
}