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

    public class RelationalExpressionBuilder
    {
        private ScalarParameterType parameterType;
        private ValueArray<string> values;
        private RelationalOperatorKind relationalOperatorKind;

        public RelationalExpressionBuilder WithSimpleQuantityKindParameterType()
        {
            this.parameterType = new SimpleQuantityKind
            {
                ClassKind = ClassKind.SimpleQuantityKind
            };
            return this;
        }

        public RelationalExpressionBuilder WithValue(object value)
        {
            this.values = new ValueArray<string>(new [] { value.ToString() });
            return this;
        }

        public RelationalExpressionBuilder WithRelationalOperatorKind(RelationalOperatorKind relationalOperatorKind)
        {
            this.relationalOperatorKind = relationalOperatorKind;

            return this;
        }

        public RelationalExpression Build()
        {
            var relationalExpression = new RelationalExpression(Guid.NewGuid(), null, null)
            {
                ParameterType = this.parameterType ?? throw new NullReferenceException($"{nameof(this.parameterType)} not set"),
                Value = this.values ?? throw new NullReferenceException($"{nameof(this.values)} not set"),
                RelationalOperator = this.relationalOperatorKind
            };

            return relationalExpression;
        }
    }
}
