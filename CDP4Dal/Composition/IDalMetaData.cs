// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDalMetaData.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Composition
{
    /// <summary>
    /// The purpose of the <see cref="IDalMetaData"/> interface is to define a Name property to be
    /// used in conjunction with a custom <see cref="ExportAttribute"/>. This interface also carries the type of Dal it is used with.
    /// </summary>
    public interface IDalMetaData : INameMetaData
    {
        /// <summary>
        /// Gets the type of the object
        /// </summary>
        DalType DalType { get; }

        /// <summary>
        /// Gets the maximum CDP Model version that is supported
        /// </summary>
        string CDPVersion { get; }
    }
}