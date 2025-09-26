// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationParameterTypeExtensions.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// This class contains methods for specific ParametricConstraint related functionality 
    /// </summary>
    public static class EnumerationParameterTypeExtensions
    {
        /// <summary>
        /// Resolves the names of a <see cref="Parameter"/> of type <see cref="EnumerationParameterType"/>, based on the strng representation
        /// according to a <see cref="ParameterValueSet"/>
        /// </summary>
        /// <param name="enumerationParameterType">The <see cref="EnumerationParameterType"/> for which the names will be resolved</param>
        /// <param name="value">The value to resolve as an object</param>
        /// <returns>A collection of <see cref="string"/>s that represent the Name(s) of the selected <see cref="EnumerationValueDefinition"/>s</returns>
        /// <exception cref="Cdp4ModelValidationException">When a specific ShortName is not found in the <paramref name="value"/></exception>
        public static IEnumerable<string> ResolveNames(this EnumerationParameterType enumerationParameterType, object value)
        {
            var result = new List<string>();
            
            if (value is string stringValue)
            {
                if (stringValue == "-")
                {
                    result.Add(stringValue);
                }
                else
                {
                    var values = stringValue.Split(Constants.MultiValueEnumSeparator);

                    foreach (var enumerationValue in values)
                    {
                        var name =
                            enumerationParameterType.ValueDefinition
                                .SingleOrDefault(x => x.ShortName == enumerationValue.Trim())?
                                .Name;

                        if (name == null)
                        {
                            var joinedShortnames = string.Empty;
                            var sortedItems = enumerationParameterType.ValueDefinition.SortedItems.Values;

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

                            throw new Cdp4ModelValidationException($"The {enumerationParameterType.Name} Enumeration Parametertype does not contain the following value definition {enumerationValue}, allowed values are: {joinedShortnames}");
                        }

                        result.Add(name);
                    }
                }
            }
            
            return result;
        }
    }
}
