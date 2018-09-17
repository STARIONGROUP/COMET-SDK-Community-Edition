// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOverrideValueSet.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
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
        /// #ElementDefinition.ShortName#.#ParameterType.ShortName#.#Component.ParameterType.ShortName#\#Option.ShortName#\#ActualState.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ParameterOverrideValueSet"/>
        /// </returns>
        public override string ModelCode(int? componentIndex = null)
        {
            var parameterOverride = (ParameterOverride)this.Container;

            if (parameterOverride == null)
            {
                throw new ContainmentException($"The container ParameterOverride of ParameterOverrideValueSet with iid {this.Iid} is null, the model code cannot be computed.");
            }

            if (!parameterOverride.IsOptionDependent && parameterOverride.StateDependence == null)
            {
                return parameterOverride.ModelCode(componentIndex);
            }

            if (parameterOverride.IsOptionDependent && parameterOverride.StateDependence == null)
            {
                return $"{parameterOverride.ModelCode(componentIndex)}\\{this.ActualOption.ShortName}";
            }

            if (!parameterOverride.IsOptionDependent && parameterOverride.StateDependence != null)
            {
                return $"{parameterOverride.ModelCode(componentIndex)}\\{this.ActualState.ShortName}";
            }

            return $"{parameterOverride.ModelCode(componentIndex)}\\{this.ActualOption.ShortName}\\{this.ActualState.ShortName}";
        }

        /// <summary>
        /// Queries the <see cref="ParameterType"/> of the container <see cref="ParameterOverride"/>
        /// </summary>
        public override ParameterType QueryParameterType()
        {
            var parameterOverride = (ParameterOverride)this.Container;
            
            if (parameterOverride == null)
            {
                throw new ContainmentException($"The container ParameterOverride of ParameterOverrideValueSet with iid {this.Iid} is null, the ParameterTye cannot be queried.");
            }

            return parameterOverride.ParameterType;
        }
    }
}