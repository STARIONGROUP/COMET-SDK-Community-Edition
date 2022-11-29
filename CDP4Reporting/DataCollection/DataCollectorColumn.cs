// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorColumn.cs" company="RHEA System S.A.">
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
    using System;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Abstract base class from which all columns for a <see cref="DataCollectorRow"/> need to derive.
    /// </summary>
    public abstract class DataCollectorColumn<T> where T : DataCollectorRow, new()
    {
        /// <summary>
        /// Gets the <see cref="DefinedThingShortNameAttribute"/> decorating the property described by <paramref name="propertyType"/>.
        /// </summary>
        /// <param name="propertyType">
        /// Describes the current property.
        /// </param>
        /// <returns>
        /// The <see cref="DefinedThingShortNameAttribute"/> decorating the current parameter class.
        /// </returns>
        protected static DefinedThingShortNameAttribute GetParameterAttribute(PropertyInfo propertyType)
        {
            var attr = Attribute
                .GetCustomAttributes(propertyType)
                .SingleOrDefault(attribute => attribute is DefinedThingShortNameAttribute);

            return attr as DefinedThingShortNameAttribute;
        }

        /// <summary>
        /// The <see cref="DataCollectorNode{T}"/> associated to this parameter.
        /// </summary>
        public DataCollectorNode<T> Node;

        /// <summary>
        /// Initializes a reported column based on the corresponding <see cref="DataCollectorNode{T}"/>
        /// associated with the current <see cref="DataCollectorRow"/>.
        /// </summary>
        /// <param name="node">
        /// The associated <see cref="DataCollectorNode{T}"/>.
        /// </param>
        /// <param name="propertyInfo">
        /// The <see cref="PropertyInfo"/> object for this <see cref="DataCollectorCategory{T}"/>'s usage in a class.
        /// </param>
        public abstract void Initialize(DataCollectorNode<T> node, PropertyInfo propertyInfo);

        /// <summary>
        /// Populates with data the <see cref="DataTable.Columns"/> associated with this object
        /// in the given <paramref name="row"/>.
        /// </summary>
        /// <param name="table">
        /// The <see cref="DataTable"/> to which the <paramref name="row"/> belongs to.
        /// </param>
        /// <param name="row">
        /// The <see cref="DataRow"/> to be populated.
        /// </param>
        public abstract void Populate(DataTable table, DataRow row);
    }
}
