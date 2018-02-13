#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILogEntry.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
    }
}
