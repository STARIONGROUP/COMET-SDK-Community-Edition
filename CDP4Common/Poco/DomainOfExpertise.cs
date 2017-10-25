// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertise.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System.Collections.Generic;
    using System.Linq;
    using EngineeringModelData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="DomainOfExpertise"/>
    /// </summary>
    public partial class DomainOfExpertise
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DomainOfExpertise"/> can be published based on the
        /// provided <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">
        /// The iteration to perform the check on.
        /// </param>
        /// <returns>
        /// True if this <see cref="DomainOfExpertise"/> has <see cref="ParameterOrOverrideBase"/>s that can be published.
        /// </returns>
        public bool CanBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Any(parameterBase => parameterBase.CanBePublished);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/>.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParameters(Iteration iteration)
        {
            var parameters = iteration.Element.SelectMany(element => element.Parameter).Where(parameter => parameter.Owner == this);
            var parameterOverrides = iteration.Element.SelectMany(ele => ele.ContainedElement).SelectMany(usage => usage.ParameterOverride).Where(parameterOverride => parameterOverride.Owner == this);

            return parameters.Concat<ParameterOrOverrideBase>(parameterOverrides);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/> that can be published.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns that can be published.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParametersThatCanBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Where(p => p.CanBePublished);
        }

        /// <summary>
        /// Gets the list of <see cref="ParameterOrOverrideBase"/> owned by this <see cref="DomainOfExpertise"/> based on <see cref="Iteration"/> to be published.
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to perform the check on.</param>
        /// <returns>
        /// All <see cref="Parameter"/>s and <see cref="ParameterOverride"/>s that this <see cref="DomainOfExpertise"/> owns that can be published.
        /// </returns>
        public IEnumerable<ParameterOrOverrideBase> OwnedParametersToBePublished(Iteration iteration)
        {
            return this.OwnedParameters(iteration).Where(p => p.CanBePublished && p.ToBePublished);
        }
    }
}
