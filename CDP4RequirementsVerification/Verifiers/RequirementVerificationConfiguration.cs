// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementVerificationConfiguration.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4RequirementsVerification.Verifiers
{
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Implements the <see cref="IRequirementVerificationConfiguration"/> for usage as general configuration setting during 
    /// Requirement Verification
    /// </summary>
    public class RequirementVerificationConfiguration : IRequirementVerificationConfiguration
    {
        /// <summary>
        /// Backing field for the <see cref="Option"/> property
        /// </summary>
        private Option option;

        /// <summary>
        /// The <see cref="Option"/> to use during RelationalExpression verification
        /// </summary>
        /// <remarks>
        /// For performance reasons, the <see cref="NestedParameters"/> property is set as a side effect to setting this Option property.
        /// This makes sure that the <see cref="NestedParameters"/> property is "created" only once per Option as the <see cref="IsValueSetAllowed"/>
        /// method can be run from multiple threads simultaneously.
        /// </remarks>
        public Option Option
        {
            get => this.option;
            set
            {
                this.option = value;

                if (this.option == null)
                {
                    this.NestedParameters = new List<NestedParameter>();
                    return;
                }

                var nestedElementTreeGenerator = new NestedElementTreeGenerator();

                this.NestedParameters = nestedElementTreeGenerator.GetNestedParameters(this.option).ToList();
            }
        }

        /// <summary>
        /// Holds a list of NestedParameters for the current option
        /// </summary>
        private List<NestedParameter> NestedParameters { get; set; } = new List<NestedParameter>();

        /// <summary>
        /// Checks if a <see cref="ParameterValueSetBase"/> is eligible for usage during RelationalExpression verification
        /// </summary>
        /// <param name="valueSet">The <see cref="ParameterValueSetBase"/> to check.</param>
        /// <returns>A boolean indicating that usage of the <see cref="ParameterValueSetBase"/> is eligible</returns>
        public bool IsValueSetAllowed(ParameterValueSetBase valueSet)
        {
            if (this.Option != null)
            {
                if (valueSet.Container is ParameterOrOverrideBase parameterOrOverrideBase)
                {
                    if (parameterOrOverrideBase.IsOptionDependent)
                    {
                        return valueSet.ActualOption == this.Option;
                    }

                    if (this.NestedParameters.All(x => x.AssociatedParameter != parameterOrOverrideBase))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
