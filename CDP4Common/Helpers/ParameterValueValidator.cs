// -------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueValidator.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Validation;
    using NLog;

    /// <summary>
    /// A utility class that validates a parameter value using the <see cref="ValueValidator"/>
    /// </summary>
    public static class ParameterValueValidator
    {
        /// <summary>
        /// The nlog logger
        /// </summary>
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Validates the new value of a <see cref="ParameterValueSetBase"/> or <see cref="ParameterSubscriptionValueSet"/> and return an error if any
        /// </summary>
        /// <param name="newValue">The new value to validate</param>
        /// <param name="parameterType">The associated <see cref="ParameterType"/></param>
        /// <param name="scale">An optional <see cref="MeasurementScale"/> if the <paramref name="parameterType"/> is a <see cref="QuantityKind"/></param>
        /// <returns>An error message if any</returns>
        public static string Validate(object newValue, ParameterType parameterType, MeasurementScale scale = null)
        {
            if (parameterType == null)
            {
                logger.Error("The parameter type is null.");
                return "Error: The parameter type is null.";
            }

            var stringValue = newValue.ToValueSetString(parameterType);
            var result = parameterType.Validate(stringValue, scale);
            return (result.ResultKind == ValidationResultKind.Valid) ? null : result.Message;
        }
    }
}