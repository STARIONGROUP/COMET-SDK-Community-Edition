// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinition.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extension for the <see cref="ElementDefinition"/> class
    /// </summary>
    public partial class ElementDefinition : IModelCode
    {
        /// <summary>
        /// Queries the <see cref="ParameterGroup"/>s that are "contained" directly by the current <see cref="ElementDefinition"/>.
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{ParameterGroup}"/> that is "contained" by the current <see cref="ElementDefinition"/>
        /// </returns>
        public IEnumerable<ParameterGroup> ContainedGroup()
        {
            return this.ContainedGroup(this.ParameterGroup);
        }

        /// <summary>
        /// Queries the <see cref="ParameterGroup"/>s that are "contained" directly by the current <see cref="ElementDefinition"/>.
        /// </summary>
        /// <param name="parameterGroups">
        /// An <see cref="IEnumerable{ParameterGroup}"/> that may contain <see cref="ParameterGroup"/>s that are 
        /// contained by the current <see cref="ElementDefinition"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{ParameterGroup}"/> that is "contained" by the current <see cref="ElementDefinition"/>
        /// </returns>
        public IEnumerable<ParameterGroup> ContainedGroup(IEnumerable<ParameterGroup> parameterGroups)
        {
            foreach (var parameterGroup in parameterGroups)
            {
                if (parameterGroup.ContainingGroup == null)
                {
                    yield return parameterGroup;
                }
            }
        }

        /// <summary>
        /// Queries the <see cref="Parameter"/>s that are "contained" by the current <see cref="ElementDefinition"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Parameter}"/> that is "contained" directly by the current <see cref="ElementDefinition"/>
        /// </returns>
        public IEnumerable<Parameter> ContainedParameter()
        {
            return this.ContainedParameter(this.Parameter);
        }

        /// <summary>
        /// Queries the <see cref="Parameter"/>s that are "contained" by the current <see cref="ElementDefinition"/>
        /// </summary>
        /// <param name="parameters">
        /// An <see cref="IEnumerable{Parameter}"/> that may contain <see cref="Parameter"/>s that are 
        /// contained by the current <see cref="ElementDefinition"/>
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{Parameter}"/> that is "contained" by the current <see cref="ElementDefinition"/>
        /// </returns>
        public IEnumerable<Parameter> ContainedParameter(IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                if (parameter.Group == null)
                {
                    yield return parameter;
                }
            }
        }

        /// <summary>
        /// Assert whether this <see cref="ElementDefinition"/> contains in its usage tree a usage of the given <see cref="ElementDefinition"/>
        /// </summary>
        /// <param name="elementDefinition">The given <see cref="ElementDefinition"/></param>
        /// <returns>True if it does or if the given <see cref="ElementDefinition"/> is the current one. False otherwise</returns>
        public bool HasUsageOf(ElementDefinition elementDefinition)
        {
            if (elementDefinition == null)
            {
                throw new ArgumentNullException("elementDefinition");
            }

            if (this == elementDefinition)
            {
                return true;
            }

            foreach (var elementUsage in this.ContainedElement)
            {
                var result = (elementUsage.ElementDefinition == elementDefinition) 
                                || elementUsage.ElementDefinition.HasUsageOf(elementDefinition);
                if (result)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Queries the <see cref="ElementUsage"/>s that reference the current <see cref="ElementDefinition"/>
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{ElementUsage}"/> that reference the current <see cref="ElementDefinition"/>
        /// </returns>
        public IEnumerable<ElementUsage> ReferencingElementUsages()
        {
            var iteration = this.Container as Iteration;

            if (iteration == null)
            {
                throw new ContainmentException();
            }
            
            return iteration.Element.SelectMany(ed => ed.ContainedElement).Where(us => us.ElementDefinition == this);
        }

        /// <summary>
        /// Computes the model code of the current <see cref="ElementDefinition"/>
        /// </summary>
        /// <param name="componentIndex">
        /// This parameter is ignored when computing the model code of a <see cref="ElementDefinition"/>
        /// </param>
        /// <remarks>
        /// The model code is derived as follows:
        /// <code>
        /// #ElementDefinition.ShortName#
        /// </code>
        /// </remarks>
        /// <returns>
        /// A string that represents the model code of the current <see cref="ElementDefinition"/>
        /// </returns>
        /// <exception cref="ArgumentException">
        /// The component index for an <see cref="ElementDefinition"/> must be 0.
        /// </exception>
        public string ModelCode(int? componentIndex = null)
        {
            if (componentIndex != null)
            {
                throw new ArgumentException("The component index must be null", "componentIndex");
            }

            return this.ShortName;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ElementDefinition"/> can be published.
        /// </summary>
        public override bool CanBePublished
        {
            get
            {
                return this.ContainedElement.Any(elementUsage => elementUsage.CanBePublished) || this.Parameter.Any(parameter => parameter.CanBePublished);
            }
        }

        /// <summary>
        /// Gets or sets whether this <see cref="ElementDefinition"/> is to be published.
        /// </summary>
        public override bool ToBePublished
        {
            get
            {
                if (!this.CanBePublished)
                {
                    return false;
                }

                var containsObjectsAllToBePublished =
                    this.Parameter.Where(parameter => parameter.CanBePublished).All(parameter => parameter.ToBePublished)
                    && this.ParameterGroup.Where(parameterGroup => parameterGroup.CanBePublished).All(parameterGroup => parameterGroup.ToBePublished)
                    && this.ContainedElement.Where(elementUsage => elementUsage.CanBePublished).All(contEle => contEle.ToBePublished);

                return containsObjectsAllToBePublished;
            }

            set
            {
                foreach (var elementUsage in this.ContainedElement.Where(elementUsage => elementUsage.CanBePublished))
                {
                    elementUsage.ToBePublished = value;
                }

                foreach (var parameter in this.Parameter.Where(parameter => parameter.CanBePublished))
                {
                    parameter.ToBePublished = value;
                }
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the 
        /// required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var iteration = this.Container as Iteration;
                return iteration?.RequiredRdls;
            }
        }
    }
}