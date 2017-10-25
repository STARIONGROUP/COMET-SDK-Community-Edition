// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSet.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterValueSet"/>
    /// </summary>
    public partial class ParameterValueSet
    {
        /// <summary>
        /// Queries the model code of the current <see cref="ParameterValueSet"/>
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
        /// A string that represents the model code of the current <see cref="ParameterValueSet"/>
        /// </returns>
        public string ModelCode(int? componentIndex = null)
        {
            var parameter = (Parameter)this.Container;

            if (parameter == null)
            {
                throw new ContainmentException(string.Format("The container Parameter of ParameterValueSet with iid {0} is null, the model code cannot be computed.", this.Iid));
            }

            if (!parameter.IsOptionDependent && parameter.StateDependence == null)
            {
                return parameter.ModelCode(componentIndex);
            }

            if (parameter.IsOptionDependent && parameter.StateDependence == null)
            {
                return string.Format("{0}\\{1}", parameter.ModelCode(componentIndex), this.ActualOption.ShortName);
            }

            if (!parameter.IsOptionDependent && parameter.StateDependence != null)
            {
                return string.Format("{0}\\{1}", parameter.ModelCode(componentIndex), this.ActualState.ShortName);
            }

            return string.Format("{0}\\{1}\\{2}", parameter.ModelCode(componentIndex), this.ActualOption.ShortName, this.ActualState.ShortName);
        }
    }
}
