// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectValueValidator.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="ObjectValueValidator" /> is to validate value based on its representation. The default value is a hyphen "-"
    /// </summary>
    /// <remarks>
    /// The <see cref="ObjectValueValidator" /> uses the <see cref="CultureInfo.InvariantCulture" />.
    /// </remarks>
    public static class ObjectValueValidator
    {
        /// <summary>
        /// The default value that is valid for all value
        /// </summary>
        public const string DefaultValue = "-";

        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Valid <see cref="bool" /> values
        /// </summary>
        public static readonly string[] ValidBoolean = { "-", "true", "false", "True", "False", "1", "0" };

        /// <summary>
        /// Asserts that the current <see cref="DateTime" /> is a default <see cref="DateTime" /> (1-1-1)
        /// </summary>
        /// <param name="dateTime">The <see cref="DateTime" /> to check</param>
        /// <returns>True if the provided <see cref="DateTime" /> is a defualt <see cref="DateTime" /></returns>
        public static bool IsDefaultDate(this DateTime dateTime)
        {
            return dateTime.Year == 1 && dateTime.Month == 1 && dateTime.Day == 1;
        }

        /// <summary>
        /// Asserts that the current <paramref name="value" /> is a <see cref="string" /> equals to <see cref="DefaultValue" />
        /// </summary>
        /// <param name="value">The value to verify</param>
        /// <param name="castedString">The <paramref name="value" /> casted as <see cref="string" /> is applicable</param>
        /// <returns>True if the provided <paramref name="value" /> is equals to <see cref="DefaultValue" /></returns>
        public static bool IsDefaultString(this object value, out string castedString)
        {
            castedString = null;

            if (value is string stringValue)
            {
                castedString = stringValue;
            }

            return castedString == DefaultValue;
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected <see cref="bool" /> value and clean it if required
        /// </summary>
        /// <param name="value">The value that is to be validated for a <see cref="bool" />.</param>
        /// <param name="cleanedValue">The cleaned value (-/true/false)</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateBoolean(this object value, out string cleanedValue)
        {
            if (value.IsDefaultString(out var castedString))
            {
                cleanedValue = castedString;
                return ValidationResult.ValidResult();
            }

            switch (value)
            {
                case bool boolValue:
                    cleanedValue = boolValue.ToString().ToLower();
                    Logger.Debug("Boolean {0} validated", boolValue);
                    return ValidationResult.ValidResult();
                case int intValue when intValue == 0 || intValue == 1:
                    Logger.Debug("Boolean {0} validated", intValue);
                    cleanedValue = (intValue == 0 ? false.ToString() : true.ToString()).ToLower();
                    return ValidationResult.ValidResult();
                case string valueString:
                {
                    if (bool.TryParse(valueString, out var boolResult))
                    {
                        cleanedValue = boolResult.ToString().ToLower();
                        Logger.Debug("Boolean {0} validated", valueString);
                        return ValidationResult.ValidResult();
                    }

                    if (ValidBoolean.Contains(valueString))
                    {
                        cleanedValue = (valueString == "0" ? false.ToString() : true.ToString()).ToLower();
                        Logger.Debug("Boolean {0} validated", valueString);
                        return ValidationResult.ValidResult();
                    }

                    break;
                }
            }

            cleanedValue = null;

            return new ValidationResult
            {
                Message = $"'{value}' is not a valid boolean, valid values are: {string.Join(",", ValidBoolean)} or any representation of a boolean (true/false)",
                ResultKind = ValidationResultKind.Invalid
            };
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected <see cref="DateTime" /> that does not contain any time data and clean it if required
        /// </summary>
        /// <param name="value">The value that is to be validated for a <see cref="DateTime" /> value that only contains date data and not any time data.</param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 Date)</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateDate(this object value, out string cleanedValue)
        {
            if (value.IsDefaultString(out var castedString))
            {
                cleanedValue = castedString;
                return ValidationResult.ValidResult();
            }

            if (value is string stringValue && DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var date))
            {
                cleanedValue = date.ToString("yyyy-MM-dd");
                Logger.Debug("Date {0} validated", date);
                return ValidationResult.ValidResult();
            }

            try
            {
                var dateValue = Convert.ToDateTime(value, CultureInfo.InvariantCulture);

                if (dateValue.Hour == 0 && dateValue.Minute == 0 && dateValue.Second == 0 && dateValue.Millisecond == 0)
                {
                    cleanedValue = dateValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    Logger.Debug("Date {0} validated", dateValue);
                    return ValidationResult.ValidResult();
                }
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            cleanedValue = null;

            return new ValidationResult
            {
                ResultKind = ValidationResultKind.Invalid,
                Message = $"'{value}' is not a valid Date, valid dates are specified in ISO 8601 YYYY-MM-DD"
            };
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected <see cref="DateTime" />
        /// </summary>
        /// <param name="value">The value that is to be validated for a <see cref="DateTime" />.</param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 DateTime)</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateDateTime(this object value, out string cleanedValue)
        {
            if (value.IsDefaultString(out var castedString))
            {
                cleanedValue = castedString;
                return ValidationResult.ValidResult();
            }

            if (value is string stringValue && DateTime.TryParse(stringValue, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var dateTime))
            {
                cleanedValue = dateTime.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture);
                Logger.Debug("DateTime {0} validated", dateTime);
                return ValidationResult.ValidResult();
            }

            try
            {
                var dateTimeValue = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                cleanedValue = dateTimeValue.ToUniversalTime().ToString("o", CultureInfo.InvariantCulture);
                Logger.Debug("DateTime {0} validated", dateTimeValue);
                return ValidationResult.ValidResult();
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            cleanedValue = null;

            return new ValidationResult
            {
                ResultKind = ValidationResultKind.Invalid,
                Message = $"'{value}' is not a valid DateTime, valid date-times are specified in ISO 8601, see http://www.w3.org/TR/xmlschema-2/#dateTime."
            };
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected enumeration value
        /// </summary>
        /// <param name="value">The value that is to be validated for an enumeration.</param>
        /// <param name="allowedValues">A <see cref="IReadOnlyCollection{T}" /> of allowed values</param>
        /// <param name="cleanedValue">The cleaned value (-/enum value(s))</param>
        /// <param name="isMultiSelectAllowed">Asserts that the multi-selection of values is allowed or not</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateEnumeration(this object value, IReadOnlyCollection<string> allowedValues, bool isMultiSelectAllowed, out string cleanedValue)
        {
            if (value.IsDefaultString(out var castedString))
            {
                cleanedValue = castedString;
                return ValidationResult.ValidResult();
            }

            if (string.IsNullOrEmpty(castedString))
            {
                cleanedValue = null;

                return new ValidationResult
                {
                    ResultKind = ValidationResultKind.Invalid,
                    Message = $"The provided '{value}' is invalid for Enumeration value"
                };
            }

            var values = castedString.Split(Constants.MultiValueEnumSeparator);

            for (var valueIndex = 0; valueIndex < values.Length; valueIndex++)
            {
                values[valueIndex] = values[valueIndex].Trim();
            }

            if (!isMultiSelectAllowed && values.Length > 1)
            {
                cleanedValue = null;

                return new ValidationResult
                {
                    ResultKind = ValidationResultKind.Invalid,
                    Message = $"The provided '{castedString}' contains multiple values, which is not allowed for a single selection"
                };
            }

            var duplicates = values.GroupBy(x => x).Where(g => g.Count() > 1).ToList();

            if (duplicates.Count != 0)
            {
                cleanedValue = null;

                return new ValidationResult
                {
                    ResultKind = ValidationResultKind.Invalid,
                    Message = $"The provided '{castedString}' contains duplicate"
                };
            }

            if (Array.Exists(values, enumerationValue => allowedValues.Any(x => x.Trim() == enumerationValue)))
            {
                cleanedValue = string.Join($"{Constants.MultiValueEnumSeparator}", values);
                Logger.Debug("Enumeration {0} validated", castedString);
                return ValidationResult.ValidResult();
            }

            var joinedValues = string.Join(", ", allowedValues);
            cleanedValue = null;

            return new ValidationResult
            {
                ResultKind = ValidationResultKind.Invalid,
                Message = $"The provided '{castedString}' does not contain the following defined values {joinedValues}"
            };
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected numeric value that should be inline with the provided
        /// <see cref="NumberSetKind" />
        /// </summary>
        /// <param name="value">The value that is to be validated for a numeric.</param>
        /// <param name="numberSetKind">The <see cref="NumberSetKind" /> that defines validation rules</param>
        /// <param name="cleanedValue">The cleaned value (-/numeric)</param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        /// <remarks>The Validation rule DO NOT validate Minimal and Maximal permissible values</remarks>
        public static ValidationResult ValidateNumeric(this object value, NumberSetKind numberSetKind, out string cleanedValue, IFormatProvider provider = null)
        {
            if (value.IsDefaultString(out var castedString))
            {
                cleanedValue = castedString;
                return ValidationResult.ValidResult();
            }

            switch (numberSetKind)
            {
                case NumberSetKind.NATURAL_NUMBER_SET:
                    switch (value)
                    {
                        case int intValue when intValue >= 0:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, intValue);
                            cleanedValue = intValue.ToString();
                            return ValidationResult.ValidResult();
                        case double doubleValue when doubleValue % 1 == 0 && doubleValue >= 0:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, doubleValue);
                            cleanedValue = ((int)doubleValue).ToString(CultureInfo.InvariantCulture);
                            return ValidationResult.ValidResult();
                    }

                    if (!string.IsNullOrEmpty(castedString)
                        && int.TryParse(castedString, NumberStyles.Integer, null, out var intResult)
                        && intResult >= 0)
                    {
                        Logger.Debug("Numeric-{0} {1} validated", numberSetKind, castedString);
                        cleanedValue = castedString;
                        return ValidationResult.ValidResult();
                    }

                    cleanedValue = null;

                    return new ValidationResult
                    {
                        Message = $"The provided '{value}' is not a member of the NATURAL NUMBER SET",
                        ResultKind = ValidationResultKind.Invalid
                    };
                case NumberSetKind.INTEGER_NUMBER_SET:
                    switch (value)
                    {
                        case int intValue:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, intValue);
                            cleanedValue = intValue.ToString();
                            return ValidationResult.ValidResult();
                        case double doubleValue when doubleValue % 1 == 0:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, doubleValue);
                            cleanedValue = ((int)doubleValue).ToString(CultureInfo.InvariantCulture);
                            return ValidationResult.ValidResult();
                    }

                    if (!string.IsNullOrEmpty(castedString) && int.TryParse(castedString, NumberStyles.Integer, null, out _))
                    {
                        Logger.Debug("Numeric-{0} {1} validated", numberSetKind, castedString);
                        cleanedValue = castedString;
                        return ValidationResult.ValidResult();
                    }

                    cleanedValue = null;

                    return new ValidationResult
                    {
                        Message = $"The provided '{value}' is not a member of the INTEGER NUMBER SET",
                        ResultKind = ValidationResultKind.Invalid
                    };
                case NumberSetKind.RATIONAL_NUMBER_SET:
                    Logger.Warn("RATIONAL NUMBER SET currently not validated and always returns ValidationResultKind.Valid");
                    cleanedValue = value.ToString();

                    return new ValidationResult
                    {
                        ResultKind = ValidationResultKind.Valid,
                        Message = "RATIONAL NUMBER SET are not validated"
                    };
                case NumberSetKind.REAL_NUMBER_SET:
                    switch (value)
                    {
                        case int intValue:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, intValue);
                            cleanedValue = intValue.ToString();
                            return ValidationResult.ValidResult();
                        case double doubleValue:
                            Logger.Debug("Numeric-{0} {1} validated", numberSetKind, doubleValue);
                            cleanedValue = doubleValue.ToString(CultureInfo.InvariantCulture);
                            return ValidationResult.ValidResult();
                    }

                    if (!string.IsNullOrEmpty(castedString) && double.TryParse(castedString, NumberStyles.Float, provider, out var realResult))
                    {
                        Logger.Debug("Numeric-{0} {1} validated", numberSetKind, castedString);
                        cleanedValue = realResult.ToString(CultureInfo.InvariantCulture);
                        return ValidationResult.ValidResult();
                    }

                    cleanedValue = null;

                    return new ValidationResult
                    {
                        Message = $"The provided '{value}' is not a member of the REAL NUMBER SET",
                        ResultKind = ValidationResultKind.Invalid
                    };
                default:
                    throw new ArgumentOutOfRangeException(nameof(numberSetKind), numberSetKind, "Invalid NumberSetKind");
            }
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected text value
        /// </summary>
        /// <param name="value">The value that is to be validated for a text.</param>
        /// <param name="cleanedValue">The cleaned value (-/text)</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateText(this object value, out string cleanedValue)
        {
            if (!(value is string stringValue))
            {
                cleanedValue = null;

                return new ValidationResult
                {
                    ResultKind = ValidationResultKind.Invalid,
                    Message = $"The provided '{value}' is not a valid value for a Text"
                };
            }

            if (string.IsNullOrWhiteSpace(stringValue))
            {
                cleanedValue = null;

                return new ValidationResult
                {
                    ResultKind = ValidationResultKind.Invalid,
                    Message = "An empty text is not valid"
                };
            }

            cleanedValue = stringValue;
            Logger.Debug("Text {0} validated", stringValue);
            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validate the <paramref name="value" /> object for an expected Time of Day value
        /// </summary>
        /// <param name="value">The value that is to be validated for a Time of Day.</param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 Time)</param>
        /// <returns>The <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        public static ValidationResult ValidateTimeOfDay(this object value, out string cleanedValue)
        {
            if (value.IsDefaultString(out var parsedString))
            {
                cleanedValue = parsedString;
                return ValidationResult.ValidResult();
            }

            if (!string.IsNullOrEmpty(parsedString))
            {
                // when DateTimeStyles.NoCurrentDateDefault is specified an no date part is specified, the date is assumed to be 1-1-1. If the
                // date of the dateTime variable is not 1-1-1 the user provided an invalid date. The loophole here is that when a user provides a
                // value that includes 1-1-1, it will be validated as being valid.

                var isDateTime = DateTime.TryParse(parsedString, CultureInfo.InvariantCulture,  DateTimeStyles.NoCurrentDateDefault | DateTimeStyles.RoundtripKind, out var dateTime);

                if (isDateTime && dateTime.IsDefaultDate())
                {
                    cleanedValue = parsedString;
                    Logger.Debug("TimeOfDay {0} validated", parsedString);
                    return ValidationResult.ValidResult();
                }
            }

            try
            {
                var timeOfDayValue = Convert.ToDateTime(value, CultureInfo.InvariantCulture);

                if (timeOfDayValue.IsDefaultDate())
                {
                    if (value is string stringValue)
                    {
                        cleanedValue = stringValue;
                        Logger.Debug("TimeOfDay {0} validated", cleanedValue);
                        return ValidationResult.ValidResult();
                    }

                    if (value is DateTime dtValue)
                    {
                        cleanedValue = dtValue.ToString("o");
                        Logger.Debug("TimeOfDay {0} validated", cleanedValue);
                        return ValidationResult.ValidResult();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Trace(ex);
            }

            cleanedValue = null;

            return new ValidationResult
            {
                ResultKind = ValidationResultKind.Invalid,
                Message = $"'{value}' is not a valid Time of Day, for valid Time Of Day formats see http://www.w3.org/TR/xmlschema-2/#time."
            };
        }
    }
}
