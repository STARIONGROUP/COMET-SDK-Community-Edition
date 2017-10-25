// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parameter.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension for the <see cref="Parameter"/> class
    /// </summary>
    public partial class Parameter : IModelCode
    {
        /// <summary>
        /// Computes the model code of the current <see cref="Parameter"/>
        /// </summary>
        /// <param name="componentIndex">
        /// This parameter is ignored when computing the model code of a <see cref="Parameter"/>
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ParameterType.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="Parameter"/>
        /// </returns>
        public override string ModelCode(int? componentIndex = null)
        {
            var elementDefinition = (ElementDefinition)this.Container;

            if (elementDefinition == null)
            {
                throw new ContainmentException(string.Format("The container ElementDefinition of Parameter with iid {0} is null, the model code cannot be computed.", this.Iid));
            }

            var compoundParameterType = this.ParameterType as CompoundParameterType;
            if (compoundParameterType == null && componentIndex > 0)
            {
                throw new ArgumentException("The value must be 0 if the ParameterType is not a CompoundParameterType", "componentIndex");
            }

            if (compoundParameterType != null && componentIndex != null)
            {
                var component = Utils.FormatComponentShortname(compoundParameterType.Component[componentIndex.Value].ShortName);
                return string.Format("{0}.{1}.{2}", elementDefinition.ShortName, compoundParameterType.ShortName, component);
            }

            return string.Format("{0}.{1}", elementDefinition.ShortName, this.ParameterType.ShortName);
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Parameter"/> can be published.
        /// </summary>
        public override bool CanBePublished
        {
            get { return this.ValueSet.Any(vs => !vs.ActualValue.SequenceEqual(vs.Published)); }
        }

        /// <summary>
        /// Validate this <see cref="Parameter"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected override IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>(base.ValidatePocoProperties());
            if (this.IsOptionDependent)
            {
                var iteration = this.GetContainerOfType<Iteration>();
                if (this.StateDependence != null)
                {
                    foreach (Option option in iteration.Option)
                    {
                        foreach (var actualState in this.StateDependence.ActualState.Where(x => x.Kind == ActualFiniteStateKind.MANDATORY))
                        {
                            var valuesets = this.ValueSet.Where(vs => vs.ActualOption == option && vs.ActualState == actualState).ToList();
                            errorList.AddRange(this.ValidateValueSets(valuesets, option, actualState));
                        }
                    }
                }
                else
                {
                    foreach (Option option in iteration.Option)
                    {
                        var valuesets = this.ValueSet.Where(vs => vs.ActualOption == option).ToList();
                        errorList.AddRange(this.ValidateValueSets(valuesets, option, null));
                    }
                }
            }
            else
            {
                if (this.StateDependence != null)
                {
                    foreach (var actualState in this.StateDependence.ActualState.Where(x => x.Kind == ActualFiniteStateKind.MANDATORY))
                    {
                        var valuesets = this.ValueSet.Where(vs => vs.ActualState == actualState).ToList();
                        errorList.AddRange(this.ValidateValueSets(valuesets, null, actualState));
                    }
                }
                else
                {
                    var valuesets = this.ValueSet.ToList();
                    errorList.AddRange(this.ValidateValueSets(valuesets, null, null));
                }
            }

            return errorList;
        }

        /// <summary>
        /// Validate the value-sets of this <see cref="Parameter"/> for an option and state if applicable
        /// </summary>
        /// <param name="valueSets">The <see cref="ParameterValueSet"/>s found for the corresponding option and state</param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="state">The <see cref="ActualFiniteState"/></param>
        /// <returns>a list of error messages</returns>
        private IEnumerable<string> ValidateValueSets(IEnumerable<ParameterValueSet> valueSets, Option option, ActualFiniteState state)
        {
            var errorList = new List<string>();
            var valuesets = valueSets.ToList();
            if (valuesets.Count == 0)
            {
                errorList.Add(string.Format("No value-set was found for the option {0} and state {1}", (option == null) ? "-" : option.Name, (state == null) ? "-" : state.Name));
            }
            else if (valuesets.Count > 1)
            {
                errorList.Add(string.Format("Duplicated value-sets were found for the option {0} and state {1}", (option == null) ? "-" : option.Name, (state == null) ? "-" : state.Name));
            }
            else
            {
                var valueset = valuesets.Single();
                errorList.AddRange(valueset.ValidationErrors);
            }

            return errorList;
        }
    }
}
