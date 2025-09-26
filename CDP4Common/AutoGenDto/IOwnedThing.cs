// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOwnedThing.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections.Generic;
    using CDP4Common.CommonData;

    /// <summary>
    /// representation of a Thing that has a single DomainOfExpertise as an owner
    /// </summary>
    public partial interface IOwnedThing
    {
        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to a DomainOfExpertise that is the owner of this OwnedThing
        /// Note: Ownership in this data model implies the responsibility for the presence and content of this OwnedThing. The owner is always a DomainOfExpertise. The Participant or Participants representing an owner DomainOfExpertise are thus responsible for (i.e. take ownership of) a coherent set of concerns in a concurrent engineering activity.
        /// </remarks>
        Guid Owner { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
