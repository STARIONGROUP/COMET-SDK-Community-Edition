// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IIterationDependentDataCollector.cs" company="RHEA System S.A.">
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

namespace CDP4Reporting.DataCollection
{
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;

    /// <summary>
    /// The interface used for classes that can be used in an <see cref="Iteration"/> dependent Report Script.
    /// Its main purpose is to provide commonly used objects to the script editor.
    /// </summary>
    public interface IIterationDependentDataCollector
    {
        /// <summary>
        /// Gets the <see cref="Iteration"/>
        /// </summary>
        Iteration Iteration { get; }

        /// <summary>
        /// Gets the <see cref="ISession"/>
        /// </summary>
        ISession Session { get; }

        /// <summary>
        /// Gets the <see cref="DomainOfExpertise"/>
        /// </summary>
        DomainOfExpertise DomainOfExpertise { get; }

        /// <summary>
        /// All currently open <see cref="ReferenceDataLibrary"/>s in this <see cref="Session"/>
        /// </summary>
        public IEnumerable<ReferenceDataLibrary> OpenReferenceDataLibraries { get; }

        /// <summary>
        /// The current <see cref="SiteDirectory"/>s in this <see cref="Session"/>
        /// </summary>
        public SiteDirectory SiteDirectory { get; }

        /// <summary>
        /// Initializes this DataCollector 
        /// </summary>
        /// <param name="iteration"></param>
        /// <param name="session"></param>
        void Initialize(Iteration iteration, ISession session);
    }
}
