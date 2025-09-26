﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueValidator.cs" company="Starion Group S.A.">
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