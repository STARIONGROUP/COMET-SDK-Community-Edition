﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueSetConverter.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    
    /// <summary>
    /// Converter used to associate a string value in the ValueArray to an object which type depend on the Parameter-type
    /// </summary>
    public static class ValueSetConverter
    {
        /// <summary>
        /// Convert an object to a string to post to the data-source
        /// </summary>
        /// <param name="value">The object to convert</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> associated to the value to convert</param>
        /// <returns>The string value</returns>
        public static string ToValueSetString(this object value, ParameterType parameterType)
        {
            if (parameterType == null)
            {
                throw new ArgumentNullException(nameof(parameterType));
            }

            if (value == null)
            {
                return "-";
            }

            if (value.ToString() == "-")
            {
                return "-";
            }

            if (value is bool)
            {
                var booleanValue = Convert.ToBoolean(value);
                return booleanValue ? "true" : "false";
            }

            if (value is float f)
            {
                return f.ToString(CultureInfo.InvariantCulture);
            }

            if (value is double d)
            {
                return d.ToString(CultureInfo.InvariantCulture);
            }

            if (value is string)
            {
                var stringValue = value.ToString();

                if (bool.TryParse(stringValue, out var booleanValue))
                {
                    return booleanValue ? "true" : "false";
                }

                if (parameterType is QuantityKind)
                {
                    // try parse double in any culture - allow the user to still use "." as separator
                    if (double.TryParse(stringValue, NumberStyles.Float, CultureInfo.InvariantCulture, out var doubleValue))
                    {
                        return doubleValue.ToString(CultureInfo.InvariantCulture);
                    }

                    // convert the comma separator to dot
                    if (double.TryParse(stringValue, NumberStyles.Float, CultureInfo.CurrentCulture, out doubleValue))
                    {
                        return doubleValue.ToString(CultureInfo.InvariantCulture);
                    }
                }

                return string.IsNullOrWhiteSpace(value.ToString()) ? "-" : value.ToString();
            }

            // single enum
            if (value is EnumerationValueDefinition enumValueDef)
            {
                return enumValueDef.ShortName;
            }

            // multi enum
            if (value is IEnumerable objects)
            {
                var enumList = objects.Cast<EnumerationValueDefinition>().ToList();
                return enumList.Count == 0 ? "-" : string.Join(Constants.PaddedMultiEnumSeparator, enumList.Select(x => x.ShortName));
            }

            // datetime
            if (value is DateTime datetime)
            {
                switch (parameterType.ClassKind)
                {
                    case ClassKind.DateTimeParameterType:
                        return datetime.ToString("yyyy-MM-ddTHH:mm:ss");
                    case ClassKind.DateParameterType:
                        return datetime.ToString("yyyy-MM-dd");
                    case ClassKind.TimeOfDayParameterType:
                        return datetime.ToString("HH:mm:ss");
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Convert to an object of the right type depending on the <see cref="ParameterType"/>
        /// </summary>
        /// <param name="value">The string value from the value-array</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> of the value</param>
        /// <returns>The associated object</returns>
        public static object ToValueSetObject(this string value, ParameterType parameterType)
        {
            // enum parameter type
            if (parameterType is EnumerationParameterType enumParameterType)
            {
                if (enumParameterType.AllowMultiSelect)
                {
                    var list = new List<EnumerationValueDefinition>();
                    var splitEnumString = value.Split(Constants.MultiValueEnumSeparator).Select(x => x.Trim());

                    list.AddRange(enumParameterType.ValueDefinition.Where(x => splitEnumString.Contains(x.ShortName)));
                    return list;
                }

                return enumParameterType.ValueDefinition.SingleOrDefault(x => x.ShortName == value.Trim());
            }

            // datetime
            switch (parameterType.ClassKind)
            {
                case ClassKind.BooleanParameterType:
                    return bool.TryParse(value, out var booleanValue) ? (bool?)booleanValue : null;

                case ClassKind.DateTimeParameterType:
                    var isDateTime = DateTime.TryParse(value, null, DateTimeStyles.RoundtripKind, out var datetime);
                    return isDateTime ? (DateTime?)datetime : null;
                
                case ClassKind.DateParameterType:
                    isDateTime = DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
                    return isDateTime ? (DateTime?)datetime : null;
                
                case ClassKind.TimeOfDayParameterType:
                    isDateTime = DateTime.TryParse(value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind | DateTimeStyles.NoCurrentDateDefault, out datetime);
                    return isDateTime ? (DateTime?)datetime : null;
            }

            return value ?? "-";
        }

        /// <summary>
        /// Convert a string value to a double according to ECSS-TM-10-25 rules.
        /// </summary>
        /// <param name="value">The <see cref="string"/> value</param>
        /// <param name="parameterType">The <see cref="ParameterType"/> used to </param>
        /// <param name="invariantNum">The converted <see cref="double"/></param>
        /// <returns>True if parsing was succesful, otherwise false.</returns>
        public static bool TryParseDouble(string value, ParameterType parameterType, out double invariantNum)
        {
            var calculatedValue = value;

            if (parameterType == null)
            {
                invariantNum = 0D;
                return false;
            }

            if (string.IsNullOrWhiteSpace(value) || value.Equals(DefaultObject(parameterType)))
            {
                invariantNum = 0D;
                return true;
            }

            calculatedValue = ToValueSetString(calculatedValue, parameterType);
 
            return double.TryParse(calculatedValue, NumberStyles.Any, CultureInfo.InvariantCulture, out invariantNum);
        }

        /// <summary>
        /// Return the default object associated to a <see cref="ParameterType"/>
        /// </summary>
        /// <param name="parameterType">The <see cref="ParameterType"/></param>
        /// <returns>The default object</returns>
        public static object DefaultObject(ParameterType parameterType)
        {
            switch (parameterType.ClassKind)
            {
                case ClassKind.EnumerationParameterType:
                case ClassKind.BooleanParameterType:
                case ClassKind.DateParameterType:
                case ClassKind.DateTimeParameterType:
                case ClassKind.TimeOfDayParameterType:
                    return null;
                default:
                    return "-";
            }
        }
    }
}
