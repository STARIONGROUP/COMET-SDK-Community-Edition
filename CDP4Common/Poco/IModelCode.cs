// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IModelCode.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    /// <summary>
    /// A class that implements the <see cref="IModelCode"/> interface exposes it's model-code. The model-code is much
    /// like the path a file in a file system, derived using short names of contained items.
    /// </summary>
    public interface IModelCode
    {
        /// <summary>
        /// Computes the model code of the current object
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> that represents the model code, valid separators are <code>.</code> and <code>/</code>
        /// </returns>
        string ModelCode(int? componentIndex = null);
    }
}
