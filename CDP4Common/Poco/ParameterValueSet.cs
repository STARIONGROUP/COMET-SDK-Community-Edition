#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSet.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.Exceptions;
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
        /// #ElementDefinition.ShortName#.#ParameterType.ShortName#.#Component.ParameterType.ShortName#\#Option.ShortName#\#ActualState.ShortName#
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
