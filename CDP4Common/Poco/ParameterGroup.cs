// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroup.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterGroup"/>
    /// </summary>
    public partial class ParameterGroup
    {
        /// <summary>
        /// Queries the container <see cref="ElementDefinition"/> of the current <see cref="ParameterGroup"/>
        /// for those <see cref="ParameterGroup"/>s that are "contained" by the current <see cref="ParameterGroup"/>.
        /// </summary>
        /// <param name="extendDeep">
        /// If <paramref name="extendDeep"/> is true, get all <see cref="ParameterGroup"/>s contained 
        /// directly and indirectly by the current one
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{ParameterGroup}"/> that is "contained" by the current <see cref="ParameterGroup"/>
        /// </returns>
        public IEnumerable<ParameterGroup> ContainedGroup(bool extendDeep = false)
        {
            if (this.Container == null)
            {
                return Enumerable.Empty<ParameterGroup>();
            }

            var elementDefinition = (ElementDefinition)this.Container;
            return this.ContainedGroup(elementDefinition.ParameterGroup, extendDeep);
        }

        /// <summary>
        /// Queries the <see cref="ParameterGroup"/>s that are "contained" by the current <see cref="ParameterGroup"/>
        /// from the provided <see cref="IEnumerable{ParameterGroup}"/>.
        /// </summary>
        /// <param name="parameterGroups">
        /// An <see cref="IEnumerable{ParameterGroup}"/> that may contain <see cref="ParameterGroup"/>s that are 
        /// contained by the current <see cref="ParameterGroup"/>
        /// </param>
        /// <param name="extendDeep">
        /// If <paramref name="extendDeep"/> is true, get all <see cref="ParameterGroup"/>s contained 
        /// directly and indirectly by the current one
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{ParameterGroup}"/> that is "contained" by the current <see cref="ParameterGroup"/>
        /// </returns>
        public IEnumerable<ParameterGroup> ContainedGroup(IEnumerable<ParameterGroup> parameterGroups, bool extendDeep = false)
        {
            foreach (var parameterGroup in parameterGroups)
            {
                if (!extendDeep && parameterGroup.ContainingGroup != null && parameterGroup.ContainingGroup.Iid == this.Iid)
                {
                    yield return parameterGroup;
                }
                else if (extendDeep && this.Contains(parameterGroup))
                {
                    yield return parameterGroup;
                }
            }
        }

        /// <summary>
        /// Queries the <see cref="Parameter"/>s that are "contained" by the current <see cref="ParameterGroup"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Parameter}"/> that is "contained" by the current <see cref="ParameterGroup"/>
        /// </returns>
        public IEnumerable<Parameter> ContainedParameter()
        {
            if (this.Container == null)
            {
                return Enumerable.Empty<Parameter>();
            }

            var elementDefinition = (ElementDefinition)this.Container;
            return this.ContainedParameter(elementDefinition.Parameter);
        }

        /// <summary>
        /// Queries the <see cref="Parameter"/>s that are "contained" by the current <see cref="ParameterGroup"/>
        /// </summary>
        /// <param name="parameters">
        /// An <see cref="IEnumerable{Parameter}"/> that may contain <see cref="Parameter"/>s that are 
        /// contained by the current <see cref="ParameterGroup"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Parameter}"/> that is "contained" by the current <see cref="ParameterGroup"/>
        /// </returns>
        public IEnumerable<Parameter> ContainedParameter(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Group == this)
                {
                    yield return parameter;
                }
            }
        }

        /// <summary>
        /// Queries the grouping level of the current <see cref="ParameterGroup"/>.
        /// </summary>
        /// <returns>
        /// the level of the <see cref="ParameterGroup"/> in it's virtual group containment hierarchy. 
        /// The level of a <see cref="ParameterGroup"/> that has no <see cref="ContainingGroup"/> is zero.
        /// </returns>
        /// <remarks>
        /// If the containing <see cref="ElementDefinition"/> of the group is null, the result is -1.
        /// </remarks>
        public int Level()
        {
            if (this.Container == null)
            {
                return -1;
            }

            if (this.ContainingGroup == null)
            {
                return 0;
            }

            return this.ContainingGroup.Level() + 1;            
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ParameterGroup"/> can be published.
        /// </summary>
        public bool CanBePublished
        {
            get
            {
                return this.ContainedParameter().Any(parameter => parameter.CanBePublished) || this.ContainedGroup().Any(parameterGroup => parameterGroup.CanBePublished);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ParameterGroup"/> will be published in the next <see cref="Publication"/>.
        /// </summary>
        public bool ToBePublished
        {
            get
            {
                if (!this.CanBePublished)
                {
                    return false;
                }

                var canAndToBePublished = this.ContainedParameter().Where(parameter => parameter.CanBePublished).All(parameterBase => parameterBase.ToBePublished)
                                          && this.ContainedGroup().Where(parameterGroup => parameterGroup.CanBePublished).All(parameterGroup => parameterGroup.ToBePublished);
                return canAndToBePublished;
            }

            set
            {
                foreach (var parameterBase in this.ContainedParameter().Where(parameter => parameter.CanBePublished))
                {
                    parameterBase.ToBePublished = value;
                }

                foreach (var parameterGroup in this.ContainedGroup().Where(parameterGroup => parameterGroup.CanBePublished))
                {
                    parameterGroup.ToBePublished = value;
                }
            }
        }

        /// <summary>
        /// Check whether the <paramref name="group"/> is "contained" by the current <see cref="ParameterGroup"/> directly or indirectly
        /// </summary>
        /// <param name="group">The <see cref="Parameter"/> to check</param>
        /// <returns>True if the <paramref name="group"/> is contained by the current <see cref="ParameterGroup"/></returns>
        private bool Contains(ParameterGroup group)
        {
            if (group.Iid == this.Iid)
            {
                return false;
            }

            if (group.ContainingGroup == null)
            {
                return false;
            }

            return group.ContainingGroup.Iid == this.Iid || this.Contains(group.ContainingGroup);
        }
    }
}