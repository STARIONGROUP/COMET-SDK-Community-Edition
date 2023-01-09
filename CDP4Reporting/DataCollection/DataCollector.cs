// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollector.cs" company="RHEA System S.A.">
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
    using System.Diagnostics.CodeAnalysis;

    using CDP4Reporting.DynamicTableChecker;

    /// <summary>
    /// The abstract base class that implements the <see cref="IDataCollector"/>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class DataCollector : IDataCollector
    {
        /// <summary>
        /// The <see cref="IDynamicTableCellsCollector"/> that contains data about table cells that can be added dynamically to the report.
        /// </summary>
        public IDynamicTableCellsCollector DynamicTableCellsCollector { get; } = new DynamicTableCellsCollector();

        /// <summary>
        /// Creates a new data collection instance.
        /// </summary>
        /// <returns>
        /// An object instance.
        /// </returns>
        public abstract object CreateDataObject();
    }
}
