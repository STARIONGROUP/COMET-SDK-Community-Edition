// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReportingParameter.cs" company="RHEA System S.A.">
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface to be used in the Code editor of <see cref="Views.ReportDesigner"/>.
    /// </summary>
    public interface IReportingParameter
    {
        /// <summary>
        /// Gets or sets the name of the <see cref="IReportingParameter"/>.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets the "calculated" parameter name to be used in the <see cref="Views.ReportDesigner"/>.
        /// </summary>
        string ParameterName { get; }

        /// <summary>
        /// Gets or sets the <see cref="Type"/> of the parameter.
        /// </summary>
        Type Type { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the report parameter.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Gets a <see cref="Dictionary{TKey,TValue}"/> that contains lookup values for a drop down report parameter.
        /// </summary>
        Dictionary<object, string> LookUpValues { get; }

        /// <summary>
        /// Gets or sets the default value of the report parameter.
        /// </summary>
        object DefaultValue { get; set; }

        /// <summary>
        /// Gets or sets the filterexpression to be used for this report parameter.
        /// </summary>
        string FilterExpression { get; set; }

        /// <summary>
        /// Indicates wether the <see cref="DefaultValue"/> should forcibly be written to existing report parameters
        /// </summary>
        bool ForceDefaultValue { get; set; }

        /// <summary>
        /// Gets or sets a value wheter multiple values should be selectable from the list of lookup values
        /// </summary>
        bool IsMultiValue { get; set; }

        /// <summary>
        /// Adds a lookup value to the <see cref="LookUpValues"/> property.
        /// </summary>
        /// <param name="value">
        /// The value. Could be any data type.
        /// </param>
        /// <param name="displayValue"
        /// >The display value in the report designer.
        /// </param>
        /// <returns>
        /// The <see cref="IReportingParameter"/>.
        /// </returns>
        IReportingParameter AddLookupValue(object value, string displayValue);
    }
}
