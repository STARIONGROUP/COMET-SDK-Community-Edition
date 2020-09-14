// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Option.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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
    using System.Linq;

    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension for the auto-generated part
    /// </summary>
    public partial class Option
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="Option"/> is the default in the current <see cref="Iteration"/>
        /// </summary>
        public bool IsDefault
        {
            get
            {
                var iteration = this.Container as Iteration;
                return iteration?.DefaultOption == this;
            }
        }

        /// <summary>
        /// Finds a NestedParameter by its <see cref="NestedParameter.Path"/> and returns its <see cref="NestedParameter.ActualValue"/>
        /// as the generic <typeparamref name="T"></typeparamref>'s .
        /// </summary>
        /// <typeparam name="T">The generic type to which the <see cref="NestedParameter.ActualValue"/> needs to be converted.</typeparam>
        /// <param name="path">The path to search for in all <see cref="NestedParameter.Path"/> properties.</param>
        /// <param name="domain">The <see cref="DomainOfExpertise"/> for which the <see cref="NestedParameter"/>s should nbe found.</param>
        /// <returns>A single <see cref="NestedParameter"/> if the path was found
        /// and its <see cref="NestedParameter.ActualValue"/> could be converted to the requested generic <typeparamref name="T"></typeparamref>, otherwise null.</returns>
        public T GetNestedParameterValueByPath<T>(string path, DomainOfExpertise domain) where T : class
        {
            var allParameters = new NestedElementTreeGenerator().GetNestedParameters(this, domain);
            var nestedParameter = allParameters.SingleOrDefault(x => x.Path.Equals(path));

            return nestedParameter?.ActualValue.ToValueSetObject(nestedParameter.AssociatedParameter.ParameterType) as T;
        }
    }
}
