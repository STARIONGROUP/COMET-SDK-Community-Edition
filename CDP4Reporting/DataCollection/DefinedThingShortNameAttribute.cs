// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThingShortNameAttribute.cs" company="RHEA System S.A.">
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

    using CDP4Common.CommonData;

    /// <summary>
    /// Attribute decorating implementations of <see cref="DataCollectorParameter{TRow,TValue}"/> or
    /// the associated <see cref="DefinedThing"/> short name.
    /// <see cref="DataCollectorCategory{T}"/> to mark the associated <see cref="DefinedThing"/> short name.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DefinedThingShortNameAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the short name of the associated <see cref="DefinedThing"/>.
        /// </summary>
        public string ShortName { get; private set; }

        /// <summary>
        /// Gets or sets the field name of the associated <see cref="DefinedThing"/>.
        /// </summary>
        public string FieldName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedThingShortNameAttribute"/> class.
        /// </summary>
        /// <param name="shortName">
        /// The short name of the associated <see cref="DefinedThing"/>.
        /// </param>
        public DefinedThingShortNameAttribute(string shortName)
        {
            this.Initialize(shortName, shortName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DefinedThingShortNameAttribute"/> class.
        /// </summary>
        /// <param name="shortName">
        /// The short name of the associated <see cref="DefinedThing"/>.
        /// </param>
        /// <param name="fieldName">
        /// The fieldname in the result Data Object.
        /// </param>
        public DefinedThingShortNameAttribute(string shortName, string fieldName)
        {
            this.Initialize(shortName, fieldName);
        }

        /// <summary>
        /// Initializes the <see cref="DefinedThingShortNameAttribute"/> class.
        /// </summary>
        /// <param name="shortName">
        /// The short name of the associated <see cref="DefinedThing"/>.
        /// </param>
        /// <param name="fieldName">
        /// The fieldname in the result Data Object.
        /// </param>
        private void Initialize(string shortName, string fieldName)
        {
            this.ShortName = shortName;
            this.FieldName = fieldName;
        }
    }
}
