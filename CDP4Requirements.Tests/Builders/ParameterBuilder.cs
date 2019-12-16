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
