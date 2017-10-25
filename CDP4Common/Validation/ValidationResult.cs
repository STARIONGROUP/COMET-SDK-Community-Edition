// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationResult.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Validation
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The compound result of <see cref="Parameter"/> value validation that carries the <see cref="ValidationResultKind"/> 
    /// and an optional message.
    /// </summary>
    public struct ValidationResult
    {
        /// <summary>
        /// The actual result of a validation
        /// </summary>
        public ValidationResultKind ResultKind;

        /// <summary>
        /// An optional message to provide more detail regarding the validation result. When the
        /// <see cref="ResultKind"/> is Valid the message is empty
        /// </summary>
        public string Message;
    }
}
