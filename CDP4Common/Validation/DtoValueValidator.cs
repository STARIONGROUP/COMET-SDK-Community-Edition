// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoValueValidator.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    using System.IO;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.Exceptions;
    using CDP4Common.Extensions;
    using CDP4Common.Types;

    /// <summary>
    /// The purpose of the <see cref="DtoValueValidator" /> is to validate the value of a <see cref="DTO.Parameter" /> with respect to
    /// it's referenced <see cref="ParameterType" />. The default value is a hyphen "-", which is a valid value for all
    /// <see cref="ParameterType" />s.
    /// </summary>
    /// <remarks>
    /// The <see cref="DtoValueValidator" /> uses the <see cref="CultureInfo.InvariantCulture" />.
    /// </remarks>
    public static class DtoValueValidator
    {
        /// <summary>
        /// Validate the <paramref name="value" /> to check whether the <paramref name="value" /> is valid with respect to the
        /// <paramref name="parameterType" />
        /// </summary>
        /// <param name="parameterType">
        /// A <see cref="ParameterType" />
        /// </param>
        /// <param name="value">
        /// The value that is to be validated
        /// </param>
        /// <param name="measurementScaleId">
        /// The <see cref="Guid" /> of the possible <see cref="MeasurementScale" /> to use to validate scalar values
        /// </param>
        /// <param name="cleanedValue">The cleaned value (- or compliant value for the <paramref name="parameterType" />)</param>
        /// <param name="things">
        /// A <see cref="IReadOnlyCollection{T}" /> of related <see cref="Thing" /> that will help to validate the value
        /// </param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this ParameterType parameterType, object value,
            Guid? measurementScaleId, out string cleanedValue, IReadOnlyCollection<Thing> things = null, IFormatProvider provider = null)
        {
            if (value.IsDefaultString(out var parsedValue))
            {
                cleanedValue = parsedValue;
                return new ValidationResult { ResultKind = ValidationResultKind.Valid };
            }

            switch (parameterType)
            {
                case BooleanParameterType booleanParameter:
                    return booleanParameter.Validate(value, out cleanedValue);
                case DateParameterType dateParameter:
                    return dateParameter.Validate(value, out cleanedValue);
                case DateTimeParameterType dateTimeParameter:
                    return dateTimeParameter.Validate(value, out cleanedValue);
                case EnumerationParameterType enumerationParameter:
                    return enumerationParameter.Validate(value, things, out cleanedValue);
                case TextParameterType textParameter:
                    return textParameter.Validate(value, out cleanedValue);
                case TimeOfDayParameterType timeOfDayParameter:
                    return timeOfDayParameter.Validate(value, out cleanedValue);
                case QuantityKind quantity:
                    return quantity.Validate(value, measurementScaleId, things, out cleanedValue, provider);
            }

            cleanedValue = null;

            return new ValidationResult
            {
                Message = $"Unsupported ParameterType {parameterType.GetType().Name}",
                ResultKind = ValidationResultKind.Invalid
            };
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a <see cref="bool" />
        /// </summary>
        /// <param name="_"> A <see cref="BooleanParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a <see cref="bool" />.
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/true/false)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this BooleanParameterType _, object value, out string cleanedValue)
        {
            return value.ValidateBoolean(out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a <see cref="DateTime" /> that does not contain any time data
        /// </summary>
        /// <param name="_"> A <see cref="DateParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a <see cref="DateTime" /> value that only contains date data and not any time data.
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 Date)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this DateParameterType _, object value, out string cleanedValue)
        {
            return value.ValidateDate(out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a <see cref="DateTime" />
        /// </summary>
        /// <param name="_"> A <see cref="DateTimeParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a <see cref="DateTime" /> value.
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 DateTime)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this DateTimeParameterType _, object value, out string cleanedValue)
        {
            return value.ValidateDateTime(out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a valid value for the
        /// <see cref="EnumerationParameterType" />
        /// </summary>
        /// <param name="enumerationParameter"> A <see cref="EnumerationParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a the enumeration value.
        /// </param>
        /// <param name="things">
        /// A <see cref="IReadOnlyCollection{T}" /> <see cref="Thing" /> to retrieve referenced
        /// <see cref="EnumerationValueDefinition" />s
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/enumeration value)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this EnumerationParameterType enumerationParameter, object value, IReadOnlyCollection<Thing> things, out string cleanedValue)
        {
            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "The provided collection of Thing cannot be null");
            }

            var enumerationValueDefinitions = things
                .OfType<EnumerationValueDefinition>()
                .Where(x => enumerationParameter.ValueDefinition.Exists(v => v.V is Guid guid && guid == x.Iid))
                .ToList();

            if (enumerationValueDefinitions.Count != enumerationParameter.ValueDefinition.Count)
            {
                throw new ThingNotFoundException($"Some EnumerationValueDefinition are missing from the provided {nameof(things)} data, cannot proceed");
            }

            return value.ValidateEnumeration(enumerationValueDefinitions.Select(x => x.ShortName).ToList(), enumerationParameter.AllowMultiSelect, out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a valid text
        /// </summary>
        /// <param name="_"> A <see cref="TextParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a text value.
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/text)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this TextParameterType _, object value, out string cleanedValue)
        {
            return value.ValidateText(out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a Time
        /// </summary>
        /// <param name="_"> A <see cref="TimeOfDayParameterType" /> </param>
        /// <param name="value">
        /// The value that is to be validated for a Time value.
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/ISO 8601 Time)</param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this TimeOfDayParameterType _, object value, out string cleanedValue)
        {
            return value.ValidateTimeOfDay(out cleanedValue);
        }

        /// <summary>
        /// Validates the <paramref name="value" /> to check whether it is a numeric value
        /// </summary>
        /// <param name="_">The <see cref="QuantityKind" /></param>
        /// <param name="value">
        /// The value that is to be validated for a numeric value.
        /// </param>
        /// <param name="measurementScaleId">The <see cref="MeasurementScale" /> to use to validate the numeric value</param>
        /// <param name="things">
        /// A <see cref="IReadOnlyCollection{T}" /> of related <see cref="Thing" /> that will help to validate the value
        /// </param>
        /// <param name="cleanedValue">The cleaned value (-/numeric value)</param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>
        /// a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.
        /// </returns>
        public static ValidationResult Validate(this QuantityKind _, object value, Guid? measurementScaleId, IReadOnlyCollection<Thing> things, out string cleanedValue, IFormatProvider provider = null)
        {
            if (!measurementScaleId.HasValue)
            {
                throw new ArgumentNullException(nameof(measurementScaleId), "The provided MeasurementScale cannot be null");
            }

            if (things == null)
            {
                throw new ArgumentNullException(nameof(things), "The provided collection of Thing cannot be null");
            }

            var measurementScale = things.OfType<MeasurementScale>().FirstOrDefault(x => x.Iid == measurementScaleId.Value)
                                   ?? throw new ThingNotFoundException($"The provided collection of Things does not contain a reference to the MeasurementScale {measurementScaleId.Value}");

            return value.ValidateNumeric(measurementScale.NumberSet, out cleanedValue, provider);
        }

        /// <summary>
        /// Validates all provides values of a <see cref="ParameterValueSetBase" /> for a <see cref="ParameterType" />.
        /// </summary>
        /// <param name="parameterType">The <see cref="ParameterType" /> to use for the validation</param>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase" /> to validate</param>
        /// <param name="measurementScaleId">The <see cref="Guid" /> of the referenced <see cref="MeasurementScale" /></param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// a
        /// <see cref="ValidationResult" />
        /// that carries the
        /// <see cref="ValidationResultKind" />
        /// and an optional message.
        /// <exception cref="InvalidDataException">
        /// If one of the <see cref="ValueArray{T}" /> of the <paramref name="valueSet" />
        /// do not have the correct number of values
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this ParameterType parameterType, ParameterValueSetBase valueSet, Guid? measurementScaleId, IReadOnlyCollection<Thing> things = null, IFormatProvider provider = null)
        {
            switch (parameterType)
            {
                case CompoundParameterType compoundParameterType:
                    return compoundParameterType.ValidateAndCleanup(valueSet, things, provider);
                case SampledFunctionParameterType sampledFunctionParameterType:
                    return sampledFunctionParameterType.ValidateAndCleanup(valueSet, things, provider);
            }

            foreach (var (valueArray, valueArrayKind) in valueSet.QueryAllValueArrays())
            {
                if (valueArray.Count != 1)
                {
                    throw new InvalidDataException($"The ValueArray {valueArrayKind} ({valueArray}) should have one and only one value!");
                }

                var validationResult = parameterType.Validate(valueArray[0], measurementScaleId, out var cleanedValue, things, provider);

                if (validationResult.ResultKind != ValidationResultKind.Valid)
                {
                    return validationResult;
                }

                valueArray[0] = cleanedValue;
            }

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates all provides values of a <see cref="ParameterValueSetBase" /> for a <see cref="CompoundParameterType" />.
        /// The number of provided values should be equal to the number of referenced <see cref="ParameterTypeComponent" /> and each one should be validated
        /// against the <see cref="ParameterType " /> and <see cref="MeasurementScale" /> (if applicable)
        /// </summary>
        /// <param name="compoundParameterType">The <see cref="CompoundParameterType" /> to use for the validation</param>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase" /> to validate</param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// a
        /// <see cref="ValidationResult" />
        /// that carries the
        /// <see cref="ValidationResultKind" />
        /// and an optional message.
        /// <exception cref="InvalidDataException">
        /// If one of the <see cref="ValueArray{T}" /> of the <paramref name="valueSet" />
        /// does not have the correct number of values
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this CompoundParameterType compoundParameterType, ParameterValueSetBase valueSet, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            foreach (var (valueArray, valueArrayKind) in valueSet.QueryAllValueArrays())
            {
                var result = compoundParameterType.ValidateAndCleanup(valueArray, valueArrayKind.ToString(), things, provider);

                if (result.ResultKind != ValidationResultKind.Valid)
                {
                    return result;
                }
            }

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates all provides values of a <see cref="ParameterValueSetBase" /> for a
        /// <see cref="SampledFunctionParameterType" />.
        /// The number of provided values should be a multiple of the number of referenced <see cref="IParameterTypeAssignment" />
        /// and each one should be validated
        /// against the <see cref="ParameterType " /> and <see cref="MeasurementScale" /> (if applicable)
        /// </summary>
        /// <param name="sampledFunctionParameterType">The <see cref="SampledFunctionParameterType" /> to use for the validation</param>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase" /> to validate</param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// a
        /// <see cref="ValidationResult" />
        /// that carries the
        /// <see cref="ValidationResultKind" />
        /// and an optional message.
        /// <exception cref="InvalidDataException">
        /// If one of the <see cref="ValueArray{T}" /> of the <paramref name="valueSet" />
        /// does not have the correct number of values
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this SampledFunctionParameterType sampledFunctionParameterType, ParameterValueSetBase valueSet, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            foreach (var (valueArray, valueArrayKind) in valueSet.QueryAllValueArrays())
            {
                var result = sampledFunctionParameterType.ValidateAndCleanup(valueArray, valueArrayKind.ToString(), things, provider);

                if (result.ResultKind != ValidationResultKind.Valid)
                {
                    return result;
                }
            }

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates and cleanup the <see cref="ValueArray{T}" /> contained in a <see cref="ClasslessDTO" /> for a
        /// <see cref="ParameterOverride" />
        /// </summary>
        /// <param name="parameterOverride">The <see cref="ParameterOverride" /> to be validated</param>
        /// <param name="classlessDto">The <see cref="ClasslessDTO" /> that contains <see cref="ValueArray{T}" /> to validate</param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        /// <exception cref="ThingNotFoundException">
        /// If the <see cref="ParameterType" /> referenced by the <see cref="ParameterOrOverrideBase" />
        /// is not contained inside the <paramref name="things" />
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this ParameterOverride parameterOverride, ClasslessDTO classlessDto, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            var parameter = things.OfType<Parameter>()
                                    .FirstOrDefault(x => x.Iid == parameterOverride.Parameter)
                                ?? throw new ThingNotFoundException($"The provided collection of Things does not contain a reference to the Parameter {parameterOverride.Parameter}");

            var parameterType = things.OfType<ParameterType>()
                                    .FirstOrDefault(x => x.Iid == parameter.ParameterType)
                                ?? throw new ThingNotFoundException($"The provided collection of Things does not contain a reference to the ParameterType {parameter.ParameterType}");

            foreach (var kvp in classlessDto)
            {
                if (!(kvp.Value is ValueArray<string> valueArray))
                {
                    continue;
                }

                var validationResult = parameterType.ValidateAndCleanup(valueArray, kvp.Key, parameterOverride.Scale, things, provider);

                if (validationResult.ResultKind != ValidationResultKind.Valid)
                {
                    return validationResult;
                }
            }

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates and cleanup the <see cref="ValueArray{T}" /> for a <see cref="ParameterType" />
        /// </summary>
        /// <param name="parameterType">The <see cref="ParameterType" /> to use for validation</param>
        /// <param name="valueArray">The <see cref="ValueArray{T}" /> to validate and cleanup</param>
        /// <param name="valueArrayKind">The kind of <see cref="ValueArray{T}" /></param>
        /// <param name="measurementScaleId">The <see cref="Guid" /> of the possible <see cref="MeasurementScale" /> to use to validate scalar values</param>
        /// <param name="things">A <see cref="IReadOnlyCollection{T}" /> of related <see cref="Thing" /> that will help to validate the value</param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        /// <exception cref="InvalidDataException">If the <see cref="ValueArray{T}" /> does not have the correct amount of values</exception>
        public static ValidationResult ValidateAndCleanup(this ParameterType parameterType, ValueArray<string> valueArray, string valueArrayKind, Guid? measurementScaleId, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            switch (parameterType)
            {
                case CompoundParameterType compoundParameterType:
                    return compoundParameterType.ValidateAndCleanup(valueArray, valueArrayKind, things, provider);
                case SampledFunctionParameterType sampledFunctionParameterType:
                    return sampledFunctionParameterType.ValidateAndCleanup(valueArray, valueArrayKind, things, provider);
            }

            if (valueArray.Count != 1)
            {
                throw new InvalidDataException($"The ValueArray {valueArrayKind} ({valueArray}) should have one and only one value!");
            }

            var validationResult = parameterType.Validate(valueArray[0], measurementScaleId, out var cleanedValue, things, provider);

            if (validationResult.ResultKind != ValidationResultKind.Valid)
            {
                return validationResult;
            }

            valueArray[0] = cleanedValue;

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates all provides values of a <see cref="ValueArray{T}" /> for a <see cref="CompoundParameterType" />.
        /// The number of provided values should be equal to the number of referenced <see cref="ParameterTypeComponent" /> and each one should be validated
        /// against the <see cref="ParameterType " /> and <see cref="MeasurementScale" /> (if applicable)
        /// </summary>
        /// <param name="compoundParameterType">The <see cref="CompoundParameterType" /> to use for the validation</param>
        /// <param name="valueArray">The <see cref="ValueArray{T}" /> to validate</param>
        /// <param name="valueArrayKind">The kind of <see cref="ValueArray{T}" /></param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        /// <exception cref="InvalidDataException">
        /// If the <see cref="ValueArray{T}" /> does not have the correct number of values
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this CompoundParameterType compoundParameterType, ValueArray<string> valueArray, string valueArrayKind, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            var parameterTypeComponents = compoundParameterType.QueryParameterTypesAndMeasurementScale(things);

            if (valueArray.Count != parameterTypeComponents.Count)
            {
                throw new InvalidDataException($"The ValueArray {valueArrayKind} ({valueArray}) does not have the required amount of values ! Expected: {parameterTypeComponents.Count} Received: {valueArray.Count}");
            }

            for (var valueIndex = 0; valueIndex < valueArray.Count; valueIndex++)
            {
                var (parameterType, measurementScaleId) = parameterTypeComponents[valueIndex];
                var valueToValidate = valueArray[valueIndex];

                var validationResult = parameterType.Validate(valueToValidate, measurementScaleId, out var cleanedValue, things, provider);

                if (validationResult.ResultKind == ValidationResultKind.Valid)
                {
                    valueArray[valueIndex] = cleanedValue;
                }
                else
                {
                    return validationResult;
                }
            }

            return ValidationResult.ValidResult();
        }

        /// <summary>
        /// Validates all provides values of a <see cref="ValueArray{T}" /> for a
        /// <see cref="SampledFunctionParameterType" />.
        /// The number of provided values should be a multiple of the number of referenced <see cref="IParameterTypeAssignment" />
        /// and each one should be validated
        /// against the <see cref="ParameterType " /> and <see cref="MeasurementScale" /> (if applicable)
        /// </summary>
        /// <param name="sampledFunctionParameterType">The <see cref="SampledFunctionParameterType" /> to use for the validation</param>
        /// <param name="valueArray">The <see cref="ValueArray{T}" /> to validate</param>
        /// <param name="valueArrayKind">The kind of <see cref="ValueArray{T}" /></param>
        /// <param name="things">The collection of <see cref="Thing" /> to retrieve referenced <see cref="Thing" /></param>
        /// <param name="provider">
        /// The <see cref="IFormatProvider" /> used to validate, if set to null
        /// <see cref="CultureInfo.CurrentCulture" /> will be used.
        /// </param>
        /// <returns>a <see cref="ValidationResult" /> that carries the <see cref="ValidationResultKind" /> and an optional message.</returns>
        /// <exception cref="InvalidDataException">
        /// If the <see cref="ValueArray{T}" /> does not have the correct number of values
        /// </exception>
        public static ValidationResult ValidateAndCleanup(this SampledFunctionParameterType sampledFunctionParameterType, ValueArray<string> valueArray, string valueArrayKind, IReadOnlyCollection<Thing> things, IFormatProvider provider = null)
        {
            var parameterTypeAssignments = sampledFunctionParameterType.QueryParameterTypesAndMeasurementScale(things);

            if (valueArray.Count % parameterTypeAssignments.Count != 0)
            {
                throw new InvalidDataException($"The ValueArray {valueArrayKind} ({valueArray}) does not have the required amount of values !");
            }

            for (var valueIndex = 0; valueIndex < valueArray.Count; valueIndex++)
            {
                var (parameterType, measurementScaleId) = parameterTypeAssignments[valueIndex % parameterTypeAssignments.Count];
                var valueToValidate = valueArray[valueIndex];

                var validationResult = parameterType.Validate(valueToValidate, measurementScaleId, out var cleanedValue, things, provider);

                if (validationResult.ResultKind == ValidationResultKind.Valid)
                {
                    valueArray[valueIndex] = cleanedValue;
                }
                else
                {
                    return validationResult;
                }
            }

            return ValidationResult.ValidResult();
        }
    }
}
