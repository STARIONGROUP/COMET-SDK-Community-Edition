// --------------------------------------------------------------------------------------------------------------------
// <copyright file="INameMetaData.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Composition
{
    using System.ComponentModel.Composition;

    /// <summary>
    /// The purpose of the <see cref="INameMetaData"/> interface is to define a Name property to be
    /// used in conjunction with a custom <see cref="ExportAttribute"/>
    /// </summary>
    public interface INameMetaData
    {
        /// <summary>
        /// Gets a human readable name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets a human readable description
        /// </summary>
        string Description { get; }
    }
}
