// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogEntry.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    /// representation of an entry in a logbook
    /// Note 1: A LogEntry is a human written message that records succinctly what change was applied at what point in time to the SiteDirectory or to an EngineeringModel and optionally records information on why the change was applied.
    /// Note 2: A LogEntry could be categorized (see Category and CategorizableThing) e.g. to denote that a LogEntry contains a  "design rationale". This would later help with reporting or retrieving useful information from the logbook.
    /// </summary>
    public partial interface ILogEntry
    {
        /// <summary>
        /// Gets or sets the unique identifiers of the referenced AffectedDomainIid instances.
        /// </summary>
        /// <remarks>
        /// The list of affected Domains of Expertise that this LogEntry.
        /// </remarks>
        List<Guid> AffectedDomainIid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the referenced AffectedItemIid instances.
        /// </summary>
        /// <remarks>
        /// weak reference to zero or more items that are relevant to or affected by what is described in the content of this LogEntry
        /// Note: Each reference should be an <i>iid</i> of a Thing that exists when the log entry is created. The references are of type Uuid in order to support retaining log entries even when the referenced Thing is later deleted. An implementation of E-TM-10-25 shall support a mechanism to dereference items by Uuid and report when items can not (no longer) be dereferenced.
        /// </remarks>
        List<Guid> AffectedItemIid { get; set; }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// reference to the Person who logged this LogEntry
        /// </remarks>
        Guid? Author { get; set; }

        /// <summary>
        /// Gets or sets the Level.
        /// </summary>
        /// <remarks>
        /// level of this LogEntry
        /// Note: The <i>level</i> can be used to filter log entries. Also applications may provide a setting that switches on or off logging log entries of a certain level.
        /// </remarks>
        LogLevelKind Level { get; set; }

        /// <summary>
        /// Gets or sets the LogEntryChangelogItem.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.2.0")]
        List<Guid> LogEntryChangelogItem { get; set; }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
