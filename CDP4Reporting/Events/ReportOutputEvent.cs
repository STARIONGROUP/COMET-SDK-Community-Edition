// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReportOutputEvent.cs" company="Starion Group S.A.">
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

namespace CDP4Reporting.Events
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// The purpose of the <see cref="ReportOutputEvent"/> is to notify an observer
    /// that a text should be added to the report designer's output panel.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ReportOutputEvent
    {
        /// <summary>
        /// The output to be added to the Output panel
        /// </summary>
        public string Output { get; }

        /// <summary>
        /// Creates a new instance of the <see cref="ReportOutputEvent"/> class
        /// </summary>
        /// <param name="output">
        /// The output to be added to the Output panel
        /// </param>
        public ReportOutputEvent(string output)
        {
            this.Output = output;
        }
    }
}
