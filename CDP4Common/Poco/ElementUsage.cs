#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsage.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
    using System;
    using System.Linq;

    using CDP4Common.Exceptions;

    /// <summary>
    /// Extension for the <see cref="ElementUsage"/> class
    /// </summary>
    public partial class ElementUsage : IModelCode
    {
        /// <summary>
        /// Computes the model code of the current <see cref="ElementUsage"/>
        /// </summary>
        /// <param name="componentIndex">
        /// This parameter is ignored when computing the model code of a <see cref="ElementDefinition"/>
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#.#ElementUsage.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ElementUsage"/>
        /// </returns>
        /// <exception cref="ContainmentException">
        /// Thrown when the containment tree is incomplete
        /// </exception>
        /// <exception cref="ArgumentException">
        /// The component index for an <see cref="ElementUsage"/> must be 0.
        /// </exception>
        public string ModelCode(int? componentIndex = null)
        {
            if (componentIndex != null)
            {
                throw new ArgumentException("The component index must be null", "componentIndex");
            }

            var elementDefinition = (ElementDefinition)this.Container;
            if (elementDefinition == null)
            {
                throw new ContainmentException(string.Format("The container ElementDefinition of ElementUsage with iid {0} is null, the model code cannot be computed.", this.Iid));
            }

            return string.Format("{0}.{1}", elementDefinition.ModelCode(), this.ShortName);
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ElementUsage"/> can be published.
        /// </summary>
        public override bool CanBePublished
        {
            get { return this.ParameterOverride.Any(parameterOverride => parameterOverride.CanBePublished); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ElementUsage"/> will be published in the next <see cref="Publication"/>.
        /// </summary>
        public override bool ToBePublished
        {
            get
            {
                return this.CanBePublished && this.ParameterOverride.Where(parameterOverride => parameterOverride.CanBePublished).All(parameterOverride => parameterOverride.ToBePublished);
            }

            set
            {
                foreach (var parameterOverride in this.ParameterOverride.Where(parameterOverride => parameterOverride.CanBePublished))
                {
                    parameterOverride.ToBePublished = value;
                }
            }
        }
    }
}
