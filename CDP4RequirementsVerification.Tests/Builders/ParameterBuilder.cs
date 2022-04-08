// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBuilder.cs" company="RHEA System S.A.">
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

namespace CDP4RequirementsVerification.Tests.Builders
{
    using System;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Class that follows the builder pattern, to construct a <see cref="Parameter"/>
    /// </summary>
    public class ParameterBuilder
    {
        /// <summary>
        /// The <see cref="Option"/>s
        /// </summary>
        private Option[] options;

        /// <summary>
        /// The <see cref="ScalarParameterType"/>
        /// </summary>
        private ScalarParameterType parameterType;

        /// <summary>
        /// The <see cref="ValueArray{T}"/>s
        /// </summary>
        private ValueArray<string>[] values;

        /// <summary>
        /// The <see cref="ElementDefinition"/>
        /// </summary>
        private ElementDefinition elementDefinition;

        /// <summary>
        /// Add an <see cref="Option"/> to be added to the <see cref="Parameter"/> when the <see cref="Build"/> method is used
        /// </summary>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns><see cref="ParameterBuilder"/> "this"</returns>
        public ParameterBuilder WithOptions(params Option[] options)
        {
            this.options = options;

            return this;
        }

        /// <summary>
        /// Create a <see cref="SimpleQuantityKind"/> to be added to the <see cref="Parameter"/> when the <see cref="Build"/> method is used
        /// </summary>
        /// <returns><see cref="ParameterBuilder"/> "this"</returns>
        public ParameterBuilder WithSimpleQuantityKindParameterType()
        {
            this.parameterType = new SimpleQuantityKind
            {
                ClassKind = ClassKind.SimpleQuantityKind
            };

            return this;
        }

        /// <summary>
        /// Create a <see cref="ValueArray{String}"/> to be added to the <see cref="Parameter"/> when the <see cref="Build"/> method is used
        /// </summary>
        /// <param name="value">The value of the first element in the <see cref="ValueArray{String}"/></param>
        /// <returns><see cref="ParameterBuilder"/> "this"</returns>
        public ParameterBuilder WithValue(object value)
        {
            this.values = new [] { new ValueArray<string>(new[] { value.ToString() })};

            return this;
        }

        /// <summary>
        /// Create a <see cref="ValueArray{String}"/> to be added to the <see cref="Parameter"/> when the <see cref="Build"/> method is used
        /// </summary>
        /// <param name="values">The values to be converted to <see cref="ValueArray{String}"/>s</param>
        /// <returns><see cref="ParameterBuilder"/> "this"</returns>
        public ParameterBuilder WithValues(params object[] values)
        {
            this.values = values.Select(x => new ValueArray<string> (new [] { x.ToString() })).ToArray();

            return this;
        }

        /// <summary>
        /// Sets the <see cref="elementDefinition"/> that will be used to add the <see cref="Parameter"/> to after it is constructed in the <see cref="Build"/> method
        /// </summary>
        /// <param name="elementDefinition">The <see cref="ElementDefinition"/></param>
        /// <returns><see cref="ParameterBuilder"/> "this"</returns>
        public ParameterBuilder AddToElementDefinition(ElementDefinition elementDefinition)
        {
            this.elementDefinition = elementDefinition;

            return this;
        }

        /// <summary>
        /// Construct a new <see cref="Parameter"/>
        /// </summary>
        /// <returns>The <see cref="Parameter"/></returns>
        public Parameter Build()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null)
            {
                ParameterType = this.parameterType ?? throw new NullReferenceException($"{nameof(this.parameterType)} not set")
            };

            if (this.values == null)
            {
                throw new NullReferenceException($"{nameof(this.values)} not set");
            }

            if (this.options != null && this.options.Length > 0)
            {
                parameter.IsOptionDependent = true;

                for (var i=0; i < this.options.Length;i++)
                {
                    var option = this.options[i];

                    var parameterValueSet =
                        new ParameterValueSet
                        {
                            ActualOption = option,
                            ValueSwitch = ParameterSwitchKind.MANUAL,
                            Manual = this.values.Length == 1 ? this.values[0] : this.values[i],
                            Formula = new ValueArray<string>(new [] { "-" })
                        };

                    parameter.ValueSet.Add(parameterValueSet);
                }
            }
            else
            {
                var parameterValueSet =
                   new ParameterValueSet
                   {
                       ValueSwitch = ParameterSwitchKind.MANUAL,
                       Manual = this.values[0],
                       Formula = new ValueArray<string>(new[] { "-" })
                   };

                parameter.ValueSet.Add(parameterValueSet);
            }

            this.elementDefinition?.Parameter.Add(parameter);

            return parameter;
        }
    }
}
