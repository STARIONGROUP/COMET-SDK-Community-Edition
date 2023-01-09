// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataCollectorRow.cs" company="RHEA System S.A.">
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
    using System.Runtime.Serialization;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Abstract base class from which all row representations for a <see cref="DataCollectorNodesCreator{T}"/> need to derive.
    /// </summary>
    public abstract class DataCollectorRow
    {
        /// <summary>
        /// The associated <see cref="ElementBase"/>.
        /// </summary>
        [IgnoreDataMember]
        public ElementBase ElementBase { get; set; }

        /// <summary>
        /// The associated <see cref="NestedElement"/>.
        /// </summary>
        [IgnoreDataMember]
        public NestedElement NestedElement { get; set; }

        /// <summary>
        /// Flag indicating whether the row matches the filtered criteria defined in <see cref="CategoryDecompositionHierarchy"/>.
        /// Note that when this is false, all values will be null on the row.
        /// </summary>
        [IgnoreDataMember]
        public bool IsVisible { get; set; }

        /// <summary>
        /// The owner <see cref="DomainOfExpertise"/> of the associated <see cref="ElementBase"/>.
        /// </summary>
        [IgnoreDataMember]
        protected DomainOfExpertise ElementBaseOwner => this.ElementBase.Owner;
    }
}
