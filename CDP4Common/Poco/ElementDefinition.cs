// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinition.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.Exceptions;

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
        /// <param name="elementdefinition">The given <see cref="ElementDefinition"/></param>
        /// <returns>True if it does or if the given <see cref="ElementDefinition"/> is the current one. False otherwise</returns>
        public bool HasUsageOf(ElementDefinition elementdefinition)
        {
            if (elementdefinition == null)
            {
                throw new ArgumentNullException("elementdefinition");
            }

            if (this == elementdefinition)
            {
                return true;
            }

            foreach (var elementUsage in this.ContainedElement)
            {
                var result = (elementUsage.ElementDefinition == elementdefinition) 
                                || elementUsage.ElementDefinition.HasUsageOf(elementdefinition);
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
    }
}