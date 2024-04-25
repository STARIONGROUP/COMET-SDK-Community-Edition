// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorStringParameter.cs" company="Starion Group S.A.">
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

namespace CDP4Reporting.DataCollection
{
    /// <summary>
    /// Abstract base class from which all string parameter columns
    /// for a <see cref="DataCollectorRow"/> need to derive.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the associated <see cref="DataCollectorRow"/>.
    /// </typeparam>
    public class DataCollectorStringParameter<T> : DataCollectorParameter<T, string>
        where T : DataCollectorRow, new()
    {
        /// <summary>
        /// Parses a parameter value as string.
        /// </summary>
        /// <param name="value">
        /// The parameter value to be parsed.
        /// </param>
        /// <returns>
        /// The parsed value.
        /// </returns>
        public override string Parse(string value)
        {
            return value;
        }
    }
}
