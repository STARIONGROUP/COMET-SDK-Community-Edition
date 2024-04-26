// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataCollector.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2023 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
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

namespace CDP4Reporting.DynamicTableChecker
{
    using System.Collections.Generic;

    /// <summary>
    /// The <see cref="DynamicTableCellsCollector"/> manages a list of definitions used to create table cells that are
    /// added dynamically to a exisitng table in a report definition.
    /// </summary>
    public class DynamicTableCellsCollector : IDynamicTableCellsCollector
    {
        /// <summary>
        /// Gets all Dynamic table cell definitions
        /// </summary>
        public Dictionary<string, ICollection<DynamicTableCell>> DynamicTableCells { get; } = new Dictionary<string,  ICollection<DynamicTableCell>>();

        /// <summary>
        /// Add a static value to the <see cref="DynamicTableCells"/> property 
        /// </summary>
        /// <param name="tableName">The name of the Table in the report</param>
        /// <param name="value">The value that should be displayed in the table cell.</param>
        /// A <see cref="DynamicTableCell"/>
        public DynamicTableCell AddValueTableCell(string tableName, string value)
        {
            return this.AddExpressionTableCell(tableName, $"'{value}'");
        }

        /// <summary>
        /// Add a bindable field to the <see cref="DynamicTableCells"/> property
        /// </summary>
        /// <param name="tableName">The name of the Table in the report</param>
        /// <param name="fieldName">The name of the datasource's field that will be displayed in the table cell.</param>
        /// A <see cref="DynamicTableCell"/>
        public DynamicTableCell AddFieldTableCell(string tableName, string fieldName)
        {
            return this.AddExpressionTableCell(tableName, $"[{fieldName}]");
        }

        /// <summary>
        /// Add an expression to the <see cref="DynamicTableCells"/> property
        /// </summary>
        /// <param name="tableName">The name of the Table in the report</param>
        /// <param name="expression">The expression that will be used to display text in the table cell.</param>
        /// A <see cref="DynamicTableCell"/>
        public DynamicTableCell AddExpressionTableCell(string tableName, string expression)
        {
            if (!this.DynamicTableCells.ContainsKey(tableName))
            {
                this.DynamicTableCells.Add(tableName, new List<DynamicTableCell>());
            }

            var dynamicTableCell = new DynamicTableCell(expression);

            this.DynamicTableCells[tableName].Add(dynamicTableCell);

            return dynamicTableCell;
        }
    }
}
