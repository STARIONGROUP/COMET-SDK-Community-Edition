﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReportingParameters.cs" company="RHEA System S.A.">
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

namespace CDP4Reporting.Parameters
{
    using System.Collections.Generic;

    using CDP4Reporting.DataCollection;

    /// <summary>
    /// Interface to be used in the Code editor of <see cref="Views.ReportDesigner"/>.
    /// </summary>
    public interface IReportingParameters
    {
        /// <summary>
        /// Creates a list of report reporting parameter that should dynamically be added to the 
        /// Report Designer's report parameter list.
        /// </summary>
        /// <param name="dataSource">
        /// The already calculated datasource.
        /// </param>
        /// <param name="dataCollector">
        /// The <see cref="IDataCollector"/> used for creating the dataSource.
        /// </param>
        /// <returns>An <see cref="IEnumerable{IReportingParameter}"/></returns>
        IEnumerable<IReportingParameter> CreateParameters(object dataSource, IDataCollector dataCollector);

        /// <summary>
        /// Creates a filterString to be user as a report filter expression.
        /// </summary>
        /// <param name="reportingParameters">
        /// The <see cref="IEnumerable{IReportingParameter}"/>.
        /// </param>
        /// <returns>
        /// The filter expression.
        /// </returns>
        string CreateFilterString(IEnumerable<IReportingParameter> reportingParameters);
    }
}