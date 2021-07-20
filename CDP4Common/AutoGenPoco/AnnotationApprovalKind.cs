// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnnotationApprovalKind.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
{
    /// <summary>
    /// Enumeration datatype that defines the possible states of an Approval item
    /// </summary>
    public enum AnnotationApprovalKind
    {
        /// <summary>
        /// Assertion that the annotation was accepted
        /// </summary>
        ACCEPTED,

        /// <summary>
        /// Assertion that the annotation was rejected
        /// </summary>
        REJECTED,

        /// <summary>
        /// Assertion that the annotation was withdrawn
        /// </summary>
        WITHDRAWN,
    }
}
