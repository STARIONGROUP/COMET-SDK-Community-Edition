// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CodeCompilerBase.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Reporting.ReportScript
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// abstract baseclass for <see cref="ICodeCompiler"/> implementations
    /// </summary>
    public abstract class CodeCompilerBase : ICodeCompiler
    {
        /// <summary>
        /// Gets or sets an <see cref="Action{T}"/> of type <see cref="string"/> that is invoked when user output is needed during compilation or data retrieval
        /// </summary>
        protected Action<string> onOutput { get; private set; }

        /// <summary>
        /// Creates a new instance of the 
        /// </summary>
        /// <param name="onOutput"></param>
        protected CodeCompilerBase(Action<string> onOutput)
        {
            this.onOutput = onOutput;
        }

        /// <summary>
        /// Compiles source code and returns the <see cref="CompilerResults"/>
        /// </summary>
        /// <param name="source">The source code</param>
        /// <param name="assemblies"><see cref="IEnumerable{T}"/> of type <see cref="string"/> that holds locations of the referenced assemblies</param>
        /// <returns>The <see cref="CompilerResults"/></returns>
        public abstract CompilerResults Compile(string source, IEnumerable<string> assemblies);
    }
}
