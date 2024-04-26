// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IXtraReportHandler.cs" company="Starion Group S.A.">
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

namespace CDP4Reporting.ReportScript
{
    using System.Collections.Generic;

    using CDP4Reporting.Parameters;

    /// <summary>
    /// Defines the properties and methods of the <see cref="IXtraReportHandler{TReport, TParameter}"/> interface
    /// </summary>
    /// <typeparam name="TReport">
    /// The report type, which typically is a DevExpress XtraReport class for a specific platform
    /// </typeparam>
    /// <typeparam name="TParameter">
    /// The report parameter type, which typically is a DevExpress Parameter class for a specific platform
    /// </typeparam>
    public interface IXtraReportHandler<out TReport, TParameter> where TReport : class where TParameter : class
    {
        /// <summary>
        /// Gets the <see cref="TReport"/>, which typically is a DevExpress XtraReport class for a specific platform
        /// </summary>
        TReport Report { get; }

        /// <summary>
        /// Sets the <see cref="TReport"/>'s DataSource
        /// </summary>
        /// <param name="dataSourceName">The name of the DataSource</param>
        /// <param name="dataSource">The datasource as an <see cref="object"/></param>
        void SetReportDataSource(string dataSourceName, object dataSource);

        /// <summary>
        /// Sets the <see cref="TReport"/>'s filterstring property
        /// </summary>
        /// <param name="filterString"></param>
        void SetReportFilterString(string filterString);

        /// <summary>
        /// Gets the currently available report parameters
        /// </summary>
        /// <returns>An <see cref="IEnumerable{T}"/> of type <see cref="TParameter"/></returns>
        IEnumerable<TParameter> GetCurrentParameters();

        /// <summary>
        /// Gets a <see cref="Dictionary{string,object}"/> of previously set values of report parameters.
        /// </summary>
        /// <returns>The <see cref="Dictionary{string,object}"/> </returns>
        Dictionary<string, object> GetPreviouslySetValues();

        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> of type <see cref="string"/> that contains all unchanged report parameters
        /// </summary>
        /// <param name="reportingParameters"></param>
        /// <returns>the <see cref="IEnumerable{T}"/> of type <see cref="string"/></returns>
        IEnumerable<string> GetUnChangedParameters(IEnumerable<IReportingParameter> reportingParameters);

        /// <summary>
        /// Removes a report parameter from the report if it already exists.
        /// </summary>
        /// <param name="reportParameter">The <see cref="TParameter"/></param>
        void RemoveParameterIfExists(TParameter reportParameter);

        /// <summary>
        /// Sets the default values all dynamic report parameter based on an <see cref="IReportingParameter"/>
        /// </summary>
        /// <param name="reportingParameter">The <see cref="IReportingParameter"/></param>
        void SetParameterDefaultValues(IReportingParameter reportingParameter);

        /// <summary>
        /// Sets the default value for a specific report parameter <see cref="TParameter"/>
        /// </summary>
        /// <param name="parameter">The <see cref="TParameter"/></param>
        /// <param name="value">The new value for the report parameter</param>
        void SetParameterDefaultValue(TParameter parameter, object value);

        /// <summary>
        /// Adds a new report parameter to the report
        /// </summary>
        /// <param name="newReportParameter">The <see cref="TParameter"/></param>
        void AddParameter(TParameter newReportParameter);

        /// <summary>
        /// Gets a new <see cref="TParameter"/> based on an <see cref="IReportingParameter"/>
        /// </summary>
        /// <param name="reportingParameter">The <see cref="IReportingParameter"/></param>
        /// <param name="parameterIsVisible">Boolean indicating if the report parameter is visible and edittable for the user in the report</param>
        /// <returns>The <see cref="TParameter"/></returns>
        TParameter GetNewParameter(IReportingParameter reportingParameter, bool parameterIsVisible);

        /// <summary>
        /// Sets all data for a lookup <see cref="TParameter"/> based on an <see cref="IReportingParameter"/>
        /// </summary>
        /// <param name="newReportParameter">The <see cref="TParameter"/></param>
        /// <param name="reportingParameter">The <see cref="IReportingParameter"/></param>
        void SetParameterStaticLookUpList(TParameter newReportParameter, IReportingParameter reportingParameter);

        /// <summary>
        /// Sets a <see cref="TParameter"/>'s visibility property
        /// </summary>
        /// <param name="newReportParameter">The <see cref="TParameter"/></param>
        /// <param name="reportingParameterVisible">A boolean indicating that the <see cref="TParameter"/> is visible and edittable to the user</param>
        void SetParameterVisibility(TParameter newReportParameter, bool reportingParameterVisible);
    }
}
