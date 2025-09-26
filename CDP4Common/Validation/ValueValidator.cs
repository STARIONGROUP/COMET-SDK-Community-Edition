// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueValidator.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Validation
{
    using System;
    using System.Globalization;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ValueValidator"/> is to validate the value of a <see cref="Parameter"/> with respect to 
    /// it's referenced <see cref="ParameterType"/>. The default value is a hyphen "-", which is a valid value for all <see cref="ParameterType"/>s.
    /// </summary>
    /// <remarks>
    /// The <see cref="ValueValidator"/> uses the <see cref="CultureInfo.InvariantCulture"/>. 
    /// </remarks>
    public static class ValueValidator
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Validates the  to check whether the <paramref name="value"/> is valid with respect to the <paramref name="parameterType"/>
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="BooleanParameterType"/>
        /// </param>
        /// <param name="value">
        /// The value that is to be validated
        /// </param>
        /// <param name="measurementScale">
        /// The measurement Scale.
        /// </param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider"/> used to validate, if set to null <see cref="CultureInfo.CurrentCulture"/> will be used.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this ParameterType parameterType, object value, MeasurementScale measurementScale = null, IFormatProvider provider = null)
        {
            ValidationResult result;

            var stringValue = value as string;
            if (stringValue != null && stringValue == ObjectValueValidator.DefaultValue)
            {
                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
                return result;
            }

            var booleanParameter = parameterType as BooleanParameterType;
            if (booleanParameter != null)
            {
                return booleanParameter.Validate(value);
            }

            var dateParameterType = parameterType as DateParameterType;
            if (dateParameterType != null)
            {
                return dateParameterType.Validate(value);
            }

            var dateTimeParameterType = parameterType as DateTimeParameterType;
            if (dateTimeParameterType != null)
            {
                return dateTimeParameterType.Validate(value);
            }

            var enumerationParameterType = parameterType as EnumerationParameterType;
            if (enumerationParameterType != null)
            {
                return enumerationParameterType.Validate(value);
            }

            var quantityKind = parameterType as QuantityKind;
            if (quantityKind != null)
            {
                return quantityKind.Validate(measurementScale, value, provider);
            }

            var textParameterType = parameterType as TextParameterType;
            if (textParameterType != null)
            {
                return textParameterType.Validate(value);
            }

            var timeOfDayParameterType = parameterType as TimeOfDayParameterType;
            if (timeOfDayParameterType != null)
            {
                return timeOfDayParameterType.Validate(value);
            }
            
            throw new NotSupportedException($"The Validate method is not suported for parameterType: {parameterType}");
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is a <see cref="Boolean"/>
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="BooleanParameterType"/>
        /// </param>
        /// <param name="value">
        /// The value that is to be validated.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this BooleanParameterType parameterType, object value)
        {
            ValidationResult result;

            if (value is bool)
            {
                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
                return result;
            }

            if (value is int)
            {
                var intValue = (int)value;
                if (intValue == 0 || intValue == 1)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }

            var valueString = value as string;
            if (valueString != null)
            {
                var lowerCaseValue = valueString.ToLower();

                if (ObjectValueValidator.ValidBoolean.Contains(lowerCaseValue))
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }

                bool booleanResult = false;
                bool.TryParse(valueString, out booleanResult);

                if (booleanResult)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }

            result.ResultKind = ValidationResultKind.Invalid;
            result.Message = $"{value} is not a valid boolean, valid values are: {string.Join(",",ObjectValueValidator.ValidBoolean)}";
            return result;
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is a <see cref="DateTime"/> that does not contain any time data.
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="DateParameterType"/>
        /// </param>
        /// <param name="value">
        /// the string representation of a <see cref="DateTime"/> value that only contains date data and not any time data.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this DateParameterType parameterType, object value)
        {
            ValidationResult result;

            var stringValue = value as string;
            if (stringValue != null)
            {
                if (stringValue == ObjectValueValidator.DefaultValue)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }

                DateTime dateTime;
                var isDateTime = DateTime.TryParseExact(stringValue, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                if (isDateTime)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }

            try
            {
                var dateValue = Convert.ToDateTime(value);
                if (dateValue.Hour == 0 && dateValue.Minute == 0 && dateValue.Second == 0 && dateValue.Millisecond == 0)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            result.ResultKind = ValidationResultKind.Invalid;
            result.Message = $"{value} is not a valid Date, valid dates are specified in ISO 8601 YYYY-MM-DD";
            return result;
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is a <see cref="DateTime"/>
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="DateTimeParameterType"/>
        /// </param>        
        /// <param name="value">
        /// the string representation of a <see cref="DateTime"/> value
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this DateTimeParameterType parameterType, object value)
        {
            ValidationResult result;

            var stringValue = value as string;
            if (stringValue != null)
            {
                if (stringValue == ObjectValueValidator.DefaultValue)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }

                try
                {
                    var dateTime = DateTime.Parse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.None);
                    Logger.Debug("DateTimeParameterType {0} validated", dateTime);

                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
                catch (Exception ex)
                {
                    Logger.Debug(ex);

                    result.ResultKind = ValidationResultKind.Invalid;
                    result.Message = $"{stringValue} is not a valid DateTime, valid date-times are specified in ISO 8601, see http://www.w3.org/TR/xmlschema-2/#dateTime.";
                    return result;
                }
            }

            try
            {
                var dateValue = Convert.ToDateTime(value);
                Logger.Debug("DateTimeParameterType {0} validated", dateValue);

                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
                return result;
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            result.ResultKind = ValidationResultKind.Invalid;
            result.Message = $"{value} is not a valid DateTime, valid date-times are specified in ISO 8601, see http://www.w3.org/TR/xmlschema-2/#dateTime.";
            return result;
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is a valid <see cref="EnumerationValueDefinition"/> of the <see cref="EnumerationParameterType"/>
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="EnumerationParameterType"/>
        /// </param>
        /// <param name="value">
        /// the string representation of a <see cref="EnumerationValueDefinition"/> value
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this EnumerationParameterType parameterType, object value)
        {
            ValidationResult result;

            var stringValue = value as string;
            if (stringValue != null)
            {
                if (stringValue == ObjectValueValidator.DefaultValue)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }

                var values = stringValue.Split(Constants.MultiValueEnumSeparator);

                if (!parameterType.AllowMultiSelect && values.Count() > 1)
                {
                    result.ResultKind = ValidationResultKind.Invalid;
                    result.Message = $"The {parameterType.Name} Enumeration Parametertype does not allow multi-selection, multiple values seem to be selected";
                    return result;
                }

                foreach (var enumerationValue in values)
                {
                    var any = parameterType.ValueDefinition.Any(x => x.ShortName == enumerationValue.Trim());
                    if (!any)
                    {
                        var joinedShortnames = string.Empty;
                        var sortedItems = parameterType.ValueDefinition.SortedItems.Values;
                        foreach (var enumerationValueDefinition in sortedItems)
                        {
                            if (joinedShortnames == string.Empty)
                            {
                                joinedShortnames = enumerationValueDefinition.ShortName;
                            }
                            else
                            {
                                joinedShortnames = joinedShortnames + ", " + enumerationValueDefinition.ShortName;
                            }
                        }

                        result.ResultKind = ValidationResultKind.Invalid;
                        result.Message = $"The {parameterType.Name} Enumeration Parametertype does not contain the following value definition {enumerationValue}, allowed values are: {joinedShortnames}";
                        return result;
                    }
                }

                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
                return result;
            }

            result.ResultKind = ValidationResultKind.Invalid;
            result.Message = $"The {parameterType.Name} Enumeration Parametertype does not contain the following value definition {value}";
            return result;
        }

        /// <summary>
        /// Validates the  to check whether it is a <see cref="ScalarParameterType"/>
        /// </summary>
        /// <param name="quantityKind">
        /// A <see cref="QuantityKind"/>
        /// </param>
        /// <param name="scale">
        /// The <see cref="MeasurementScale"/>
        /// </param>
        /// <param name="value">
        /// The value that is to be validated.
        /// </param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider"/> used to validate, if set to null <see cref="CultureInfo.CurrentCulture"/> will be used.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this QuantityKind quantityKind, MeasurementScale scale, object value, IFormatProvider provider = null)
        {
            ValidationResult result;

            if (scale == null)
            {
                Logger.Error("The scale is null with a quantity kind as the parameter type.");
                result.ResultKind = ValidationResultKind.Invalid;
                result.Message = "The scale is null with a quantity kind as the parameter type.";
                return result;
            }

            var stringValue = value as string;
            if (stringValue != null && stringValue == ObjectValueValidator.DefaultValue)
            {
                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
                return result;
            }

            result = scale.Validate(value, provider);
            return result;
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is Text.
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="TextParameterType"/>
        /// </param>
        /// <param name="value">
        /// The string value that is to be validated.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this TextParameterType parameterType, object value)
        {
            ValidationResult result;

            if (value is string)
            {
                result.ResultKind = ValidationResultKind.Valid;
                result.Message = string.Empty;
            }
            else
            {
                result.ResultKind = ValidationResultKind.Invalid;
                result.Message = $"{value} is not a valid value for a Text Parameter Type";
            }

            return result;
        }

        /// <summary>
        /// Validates the <paramref name="value"/> to check whether it is a valid time of day.
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="TimeOfDayParameterType"/>
        /// </param>
        /// <param name="value">
        /// The string value that is to be validated.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this TimeOfDayParameterType parameterType, object value)
        {
            ValidationResult result;

            var stringValue = value as string;
            if (stringValue != null)
            {
                if (stringValue == ObjectValueValidator.DefaultValue)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }

                //// when DateTimeStyles.NoCurrentDateDefault is specified an no date part is specified, the date is assumed to be 1-1-1. If the
                //// date of the dateTime variable is not 1-1-1 the user provided an invalid date. The loophole here is that when a user provides a
                //// value that includes 1-1-1, it will be validated as being valid.

                DateTime dateTime;
                var isDateTime = DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind | DateTimeStyles.NoCurrentDateDefault, out dateTime);

                if (isDateTime && dateTime.Year == 1 && dateTime.Month == 1 && dateTime.Day == 1)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }

            try
            {
                var timeOfDayValue = Convert.ToDateTime(value);
                if (timeOfDayValue.Year == 1 && timeOfDayValue.Month == 1 && timeOfDayValue.Day == 1)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            try
            {
                var timeOfDayValue = Convert.ToDateTime(value);
                if (timeOfDayValue.Year == 1 && timeOfDayValue.Month == 1 && timeOfDayValue.Day == 1)
                {
                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            result.ResultKind = ValidationResultKind.Invalid;
            result.Message = $"{value} is not a valid Time of Day, for valid Time Of Day formats see http://www.w3.org/TR/xmlschema-2/#time.";
            return result;
        }

        /// <summary>
        /// Validates whether the provided value is valid with respect to the <see cref="MeasurementScale"/>
        /// </summary>
        /// <param name="measurementScale">
        /// The <see cref="MeasurementScale"/> 
        /// </param>
        /// <param name="value">
        /// The value that is to be validated
        /// </param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider"/> used to validate, if set to null <see cref="CultureInfo.CurrentCulture"/> will be used.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult"/> that carries the <see cref="ValidationResultKind"/> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this MeasurementScale measurementScale, object value, IFormatProvider provider = null)
        {
            ValidationResult result;

            bool isMaximumPermissibleValue;
            bool isMinimumPermissibleValue;

            var stringValue = value as string;

            switch (measurementScale.NumberSet)
            {
                case NumberSetKind.INTEGER_NUMBER_SET:

                    bool isInteger = false;
                    int integer = 0;

                    if (value is int)
                    {
                        isInteger = true;
                        integer = (int)value;
                    }

                    // the value parameter may be passed as a double, provided it has no digits after
                    // the decimal separator, we consider it may be a integer number
                    if (value is double)
                    {
                        var d = (double)value;
                        if (d % 1 == 0)
                        {
                            isInteger = true;
                            integer = (int)d;
                        }
                    }

                    if (stringValue != null)
                    {
                        isInteger = int.TryParse(stringValue, NumberStyles.Integer, null, out integer);
                    }

                    if (!isInteger)
                    {
                        result.ResultKind = ValidationResultKind.Invalid;
                        result.Message = $"{value.GetType().Name}:\"{value}\" is not a member of the INTEGER NUMBER SET";
                        return result;
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MaximumPermissibleValue))
                    {
                        int intMaximumPermissibleValue;
                        isMaximumPermissibleValue = int.TryParse(measurementScale.MaximumPermissibleValue, NumberStyles.Integer, null, out intMaximumPermissibleValue);
                        if (isMaximumPermissibleValue)
                        {
                            if (measurementScale.IsMaximumInclusive && integer > intMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{integer}\" is greater than the maximium permissible value of \"{intMaximumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMaximumInclusive && integer >= intMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{integer}\" is greater than or equal to the maximium permissible value of \"{intMaximumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MaximumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MaximumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MinimumPermissibleValue))
                    {
                        int intMinimumPermissibleValue;
                        isMinimumPermissibleValue = int.TryParse(measurementScale.MinimumPermissibleValue, NumberStyles.Integer, null, out intMinimumPermissibleValue);
                        if (isMinimumPermissibleValue)
                        {
                            if (measurementScale.IsMinimumInclusive && integer < intMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{integer}\" is smaller than the minimum permissible value of \"{intMinimumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMinimumInclusive && integer <= intMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{integer}\" is smaller than or equal to the minimum permissible value of \"{intMinimumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MinimumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MinimumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;

                case NumberSetKind.NATURAL_NUMBER_SET:

                    int natural = 0;
                    bool isNatural = false;

                    if (value is int)
                    {
                        isNatural = true;
                        natural = (int)value;
                    }

                    // the value parameter may be passed as a double, provided it has no digits after
                    // the decimal separator, we consider it may be a natural number
                    if (value is double)
                    {
                        var d = (double)value;
                        if (d % 1 == 0)
                        {
                            isNatural = true;
                            natural = (int)d;
                        }
                    }

                    if (stringValue != null)
                    {
                        isNatural = int.TryParse(stringValue, NumberStyles.Integer, null, out natural);
                    }

                    if (!isNatural)
                    {
                        result.ResultKind = ValidationResultKind.Invalid;
                        result.Message = $"{value.GetType().Name}:\"{value}\" is not a member of the NATURAL NUMBER SET";
                        return result;
                    }

                    if (natural < 0)
                    {
                        result.ResultKind = ValidationResultKind.Invalid;
                        result.Message = $"\"{value}\" is not a member of the NATURAL NUMBER SET";
                        return result;
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MaximumPermissibleValue))
                    {
                        int naturalMaximumPermissibleValue;
                        isMaximumPermissibleValue = int.TryParse(measurementScale.MaximumPermissibleValue, NumberStyles.Integer, null, out naturalMaximumPermissibleValue);
                        if (isMaximumPermissibleValue)
                        {
                            if (measurementScale.IsMaximumInclusive && natural > naturalMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{natural}\" is greater than the maximium permissible value of \"{naturalMaximumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMaximumInclusive && natural >= naturalMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{natural}\" is greater than or equal to the maximium permissible value of \"{naturalMaximumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MaximumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MaximumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MinimumPermissibleValue))
                    {
                        int naturalMinimumPermissibleValue;
                        isMinimumPermissibleValue = int.TryParse(measurementScale.MinimumPermissibleValue, NumberStyles.Integer, null, out naturalMinimumPermissibleValue);
                        if (isMinimumPermissibleValue)
                        {
                            if (measurementScale.IsMinimumInclusive && natural < naturalMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{natural}\" is smaller than the minimum permissible value of \"{naturalMinimumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMinimumInclusive && natural <= naturalMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{natural}\" is smaller than or equal to the minimum permissible value of \"{naturalMinimumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MinimumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MinimumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;

                case NumberSetKind.RATIONAL_NUMBER_SET:

                    Logger.Warn("RATIONAL NUMBER SET currently not validated and always returns ValidationResultKind.Valid");

                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = "RATIONAL NUMBER SET are not validated";
                    return result;

                case NumberSetKind.REAL_NUMBER_SET:

                    if (provider == null)
                    {
                        provider = CultureInfo.InvariantCulture;
                    }

                    double real = 0;
                    bool isReal = false;

                    // the real numbers include all the integers
                    if (value is int)
                    {
                        isReal = true;
                        real = Convert.ToDouble(value);
                    }

                    if (value is double)
                    {
                        isReal = true;
                        real = (double)value;
                    }

                    if (stringValue != null)
                    {
                        isReal = double.TryParse(stringValue, NumberStyles.Float, provider, out real);
                    }

                    if (!isReal)
                    {
                        result.ResultKind = ValidationResultKind.Invalid;
                        result.Message = $"{value.GetType().Name}:\"{value}\" is not a member of the REAL NUMBER SET";
                        return result;
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MaximumPermissibleValue))
                    {
                        double realMaximumPermissibleValue;
                        isMaximumPermissibleValue = double.TryParse(measurementScale.MaximumPermissibleValue, NumberStyles.Float, null, out realMaximumPermissibleValue);
                        if (isMaximumPermissibleValue)
                        {
                            if (measurementScale.IsMaximumInclusive && real > realMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{real}\" is greater than the maximium permissible value of \"{realMaximumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMaximumInclusive && real >= realMaximumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{real}\" is greater than or equal to the maximium permissible value of \"{realMaximumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MaximumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MaximumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(measurementScale.MinimumPermissibleValue))
                    {
                        double realMinimumPermissibleValue;
                        isMinimumPermissibleValue = double.TryParse(measurementScale.MinimumPermissibleValue, NumberStyles.Integer, null, out realMinimumPermissibleValue);
                        if (isMinimumPermissibleValue)
                        {
                            if (measurementScale.IsMinimumInclusive && real < realMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{real}\" is smaller than the minimum permissible value of \"{realMinimumPermissibleValue}\"";
                                return result;
                            }

                            if (!measurementScale.IsMinimumInclusive && real <= realMinimumPermissibleValue)
                            {
                                result.ResultKind = ValidationResultKind.OutOfBounds;
                                result.Message = $"The value \"{real}\" is smaller than or equal to the minimum permissible value of \"{realMinimumPermissibleValue}\"";
                                return result;
                            }
                        }
                        else
                        {
                            Logger.Warn("The MinimumPermissibleValue \"{0}\" of MeasurementScale \"{1}\" is not a member of the INTEGER NUMBER SET", measurementScale.MinimumPermissibleValue, measurementScale.Iid);
                        }
                    }

                    result.ResultKind = ValidationResultKind.Valid;
                    result.Message = string.Empty;
                    return result;

                default:
                    throw new Exception("Invalid NumberSetKind");
            }
        }
    }
}
