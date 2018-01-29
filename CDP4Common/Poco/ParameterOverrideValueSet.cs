// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSet.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.Exceptions;
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterOverrideValueSet"/>
    /// </summary>
    public partial class ParameterOverrideValueSet : IModelCode
    {
        /// <summary>
        /// Returns the derived <see cref="ActualState"/> value
        /// </summary>
        /// <returns>The <see cref="ActualState"/> value</returns>
        protected ActualFiniteState GetDerivedActualState()
        {
            return this.ParameterValueSet.ActualState;
        }

        /// <summary>
        /// Returns the derived <see cref="ActualOption"/> value
        /// </summary>
        /// <returns>The <see cref="ActualOption"/> value</returns>
        protected Option GetDerivedActualOption()
        {
            return this.ParameterValueSet.ActualOption;
        }

        /// <summary>
        /// Computes the model code of the current <see cref="ParameterValueSet"/>
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ParameterType.Shortname#.#Component.ParameterType.ShortName#\#Option.ShortName#\#ActualState.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ParameterOverrideValueSet"/>
        /// </returns>
        public string ModelCode(int? componentIndex = null)
        {
            var parameterOverride = (ParameterOverride)this.Container;

            if (parameterOverride == null)
            {
                throw new ContainmentException(string.Format("The container ParameterOverride of ParameterOverrideValueSet with iid {0} is null, the model code cannot be computed.", this.Iid));
            }

            if (!parameterOverride.IsOptionDependent && parameterOverride.StateDependence == null)
            {
                return parameterOverride.ModelCode(componentIndex);
            }

            if (parameterOverride.IsOptionDependent && parameterOverride.StateDependence == null)
            {
                return string.Format("{0}\\{1}", parameterOverride.ModelCode(componentIndex), this.ActualOption.ShortName);
            }

            if (!parameterOverride.IsOptionDependent && parameterOverride.StateDependence != null)
            {
                return string.Format("{0}\\{1}", parameterOverride.ModelCode(componentIndex), this.ActualState.ShortName);
            }

            return string.Format("{0}\\{1}\\{2}", parameterOverride.ModelCode(componentIndex), this.ActualOption.ShortName, this.ActualState.ShortName);
        }
    }
}