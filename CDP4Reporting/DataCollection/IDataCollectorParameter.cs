// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataCollectorParameter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.DataCollection
{
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The interface that defines members of implementing classes of <see cref="IDataCollectorParameter"/>
    /// </summary>
    public interface IDataCollectorParameter
    {
        /// <summary>
        /// Gets a flag that indicates whether this instance has <see cref="IValueSet"/>s.
        /// </summary>
        bool HasValueSets { get; }

        /// <summary>
        /// Gets a flag that indicates that a parameter also collects parent values up a tree of <see cref="CategoryDecompositionHierarchy"/>s
        /// </summary>
        bool CollectParentValues { get; }

        /// <summary>
        /// Gets or sets the associated field name prefix in the result Data Object.
        /// </summary>
        string ParentValuePrefix { get; set; }

        /// <summary>
        /// The ValueSets of the associated object.
        /// The <see cref="IEnumerable{T}"/>s of the associated object/>.
        /// </summary>
        IEnumerable<IValueSet> ValueSets { get; set; }
    }
}
