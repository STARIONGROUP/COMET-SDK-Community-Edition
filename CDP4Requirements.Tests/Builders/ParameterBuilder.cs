// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBuilder.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
namespace CDP4Requirements.Tests.Builders
{
    using System;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    public class ParameterBuilder
    {
        private Option option;
        private ScalarParameterType parameterType;
        private ValueArray<string> values;
        private ElementDefinition elementDefinition;

        public ParameterBuilder WithOption(Option option)
        {
            this.option = option;

            return this;
        }

        public ParameterBuilder WithSimpleQuantityKindParameterType()
        {
            this.parameterType = new SimpleQuantityKind
            {
                ClassKind = ClassKind.SimpleQuantityKind
            };

            return this;
        }

        public ParameterBuilder WithValue(object value)
        {
            this.values = new ValueArray<string>(new[] { value.ToString() });

            return this;
        }

        public Parameter Build()
        {
            var parameter = new Parameter(Guid.NewGuid(), null, null)
            {
                ParameterType = this.parameterType ?? throw new NullReferenceException($"{nameof(this.parameterType)} not set")
            };

            var parameterValueSet =
                new ParameterValueSet
                {
                    ActualOption = this.option,
                    ValueSwitch = ParameterSwitchKind.MANUAL,
                    Manual = this.values ?? throw new NullReferenceException($"{nameof(this.values)} not set")
                };

            parameter.ValueSet.Add(parameterValueSet);

            if (this.elementDefinition != null)
            {
                this.elementDefinition.Parameter.Add(parameter);
            }

            return parameter;
        }

        public ParameterBuilder AddToElementDefinition(ElementDefinition elementDefinition)
        {
            this.elementDefinition = elementDefinition;

            return this;
        }
    }
}
