#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDalMetaData.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
#endregion

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