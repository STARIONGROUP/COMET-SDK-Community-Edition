namespace CDP4Requirements.Tests.Builders
{
    using System;
    using System.Linq;

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
