// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompilationErrors.cs" company="RHEA System S.A.">
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

namespace CDP4Reporting.ReportScript
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// CLass that holds information about compilation errors
    /// </summary>
    public class CompilationErrors : List<string>
    {
        /// <summary>
        /// Gets a value indicating if errors were thrown during compilation
        /// </summary>
        public bool HasErrors => this.Any();

        /// <summary>
        /// Creates a new instance of the <see cref="CompilationErrors"/> class
        /// </summary>
        /// <param name="errors">A <see cref="List{T}"/> of type <see cref="string"/> that hold all errors thrown during compilation</param>
        public CompilationErrors(List<string> errors)
        {
            if (errors?.Any() ?? false)
            {
                this.AddRange(errors);
            }
        }

        /// <summary>
        /// Returns a string that contains all compilation errors
        /// </summary>
        /// <returns>A string that contains all compilation errors</returns>
        public override string ToString() => this.HasErrors ? string.Join("\n", this) : string.Empty;
    }
}
