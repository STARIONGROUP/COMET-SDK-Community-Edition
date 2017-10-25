// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsage.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Linq;

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
        /// #ElementDefinition.ShortName#.#ElementUsage.shortname#
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
