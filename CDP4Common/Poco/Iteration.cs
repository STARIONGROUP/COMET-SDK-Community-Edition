// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iteration.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

    using CDP4Common.Extensions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Hand-coded part for the auto-generated <see cref="Iteration"/> class.
    /// </summary>
    public partial class Iteration
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{T}"/> that contains the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Iteration"/> 
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var engineeringModelSetup = (EngineeringModelSetup)this.IterationSetup.Container;
                var requiredModelReferenceDataLibrary = engineeringModelSetup.RequiredRdl.Single();
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);                
                requiredRdls.Add(requiredModelReferenceDataLibrary);
                requiredRdls.UnionWith(requiredModelReferenceDataLibrary.GetRequiredRdls());
                return requiredRdls;
            }
        }

        /// <summary>
        /// Queries the name of the associated <see cref="Iteration" />
        /// </summary>
        /// <returns>
        /// The name of the <see cref="Iteration" /> composed of the container
        /// Engineering Model name and Iteration number
        /// </returns>
        public string QueryName()
        {
            var engineeringSetup = (EngineeringModelSetup)this.IterationSetup.Container;
            return $"{engineeringSetup.Name} - Iteration {this.IterationSetup.IterationNumber}";
        }

        /// <summary>
        /// Queries the used <see cref="ParameterType" /> inside an <see cref="Iteration" />
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of used <see cref="ParameterType" />
        /// </returns>
        public IEnumerable<ParameterType> QueryUsedParameterTypes()
        {
            return this.Element.SelectMany(x => x.Parameter).Select(x => x.ParameterType).DistinctBy(x => x.Iid);
        }

        /// <summary>
        /// Queries all <see cref="ParameterValueSetBase" /> of the given iteration
        /// </summary>
        /// <returns>A collection of <see cref="ParameterValueSetBase" /></returns>
        public IEnumerable<ParameterValueSetBase> QueryParameterValueSetBase()
        {
            var valueSets = new List<ParameterValueSetBase>();

            if (this.TopElement != null)
            {
                valueSets.AddRange(this.TopElement.Parameter.SelectMany(x => x.ValueSet));
            }

            foreach (var elementUsage in this.Element.SelectMany(elementDefinition => elementDefinition.ContainedElement))
            {
                if (!elementUsage.ParameterOverride.Any())
                {
                    valueSets.AddRange(elementUsage.ElementDefinition.Parameter.SelectMany(x => x.ValueSet));
                }
                else
                {
                    valueSets.AddRange(elementUsage.ParameterOverride.SelectMany(x => x.ValueSet));

                    valueSets.AddRange(elementUsage.ElementDefinition.Parameter.Where(x => elementUsage.ParameterOverride.All(o => o.Parameter.Iid != x.Iid))
                        .SelectMany(x => x.ValueSet));
                }
            }

            return valueSets.DistinctBy(x => x.Iid);
        }

        /// <summary>
        /// Queries all <see cref="NestedParameter" /> that belongs to a given <see cref="Option" />
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option" /> for which the <see cref="NestedParameter"/>s are to be queried
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{T}"/> of <see cref="NestedParameter" />
        /// </returns>
        public IEnumerable<NestedParameter> QueryNestedParameters(Option option)
        {
            var generator = new NestedElementTreeGenerator();
            return this.TopElement == null ? Enumerable.Empty<NestedParameter>() : generator.GetNestedParameters(option);
        }

        /// <summary>
        /// Queries all the unreferenced <see cref="ElementDefinition" /> in an <see cref="Iteration" />
        /// An unreferenced element is an element with no associated ElementUsage
        /// </summary>
        /// <returns>
        /// All unreferenced <see cref="ElementDefinition" />
        /// </returns>
        public IEnumerable<ElementDefinition> QueryUnreferencedElements()
        {
            var elementUsages = this.Element.SelectMany(x => x.ContainedElement).ToList();

            var associatedElementDefinitions = elementUsages.Select(x => x.ElementDefinition);

            var unreferencedElementDefinitions = this.Element.ToList();
            unreferencedElementDefinitions.RemoveAll(x => associatedElementDefinitions.Any(e => e.Iid == x.Iid));
            unreferencedElementDefinitions.RemoveAll(x => x.Iid == this.TopElement.Iid);

            return unreferencedElementDefinitions;
        }

        /// <summary>
        /// Queries unused <see cref="ElementDefinition" /> in an <see cref="Iteration" />
        /// An unused element is an element not used in an option
        /// </summary>
        /// <returns>All unused <see cref="ElementDefinition" /></returns>
        public IEnumerable<ElementDefinition> QueryUnusedElementDefinitions()
        {
            var nestedElements = this.QueryNestedElements().ToList();

            var associatedElements = nestedElements.SelectMany(x => x.ElementUsage.Select(e => e.ElementDefinition))
                .DistinctBy(x => x.Iid).ToList();

            var unusedElementDefinitions = this.Element.ToList();
            unusedElementDefinitions.RemoveAll(e => associatedElements.Any(x => x.Iid == e.Iid));
            unusedElementDefinitions.RemoveAll(x => x.Iid == this.TopElement?.Iid);
            return unusedElementDefinitions;
        }

        /// <summary>
        /// Queries all <see cref="NestedElement" /> of the given <see cref="Iteration" />
        /// </summary>
        /// <returns>A collection of <see cref="NestedElement" /></returns>
        public IEnumerable<NestedElement> QueryNestedElements()
        {
            var nestedElementTreeGenerator = new NestedElementTreeGenerator();
            var nestedElements = new List<NestedElement>();

            if (this.TopElement != null)
            {
                nestedElements.AddRange(this.Option.SelectMany(o => nestedElementTreeGenerator.Generate(o)));
            }

            return nestedElements;
        }

        /// <summary>
        /// Queries all <see cref="NestedElement" /> of the given <see cref="Iteration" /> based on <see cref="Option" />
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option" />
        /// </param>
        /// <returns>
        /// A collection of <see cref="NestedElement" />
        /// </returns>
        public IEnumerable<NestedElement> QueryNestedElements(Option option)
        {
            var nestedElementTreeGenerator = new NestedElementTreeGenerator();
            var nestedElements = new List<NestedElement>();

            if (this.TopElement != null)
            {
                nestedElements.AddRange(nestedElementTreeGenerator.Generate(option));
            }

            return nestedElements;
        }

        /// <summary>
        /// Gets the <see cref="ElementBase"/> from this iteration
        /// </summary>
        /// <returns>an <see cref="IEnumerable{ElementBase}"/></returns>
        /// <exception cref="ArgumentNullException">if the iteration is null</exception>
        public IEnumerable<ElementBase> QueryElementsBase()
        {
            var elements = new List<ElementBase>();

            if (this.TopElement != null)
            {
                elements.Add(this.TopElement);
            }

            this.Element.ForEach(e => elements.AddRange(e.ContainedElement));

            return elements;
        }

        /// <summary>
        /// Queries all <see cref="ParameterSubscription" /> owned by a given <see cref="DomainOfExpertise" />
        /// contained into an <see cref="Iteration" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public IEnumerable<ParameterSubscription> QueryOwnedParameterSubscriptions(DomainOfExpertise domain)
        {
            var subscriptions = new List<ParameterSubscription>();

            if (this.TopElement != null)
            {
                subscriptions.AddRange(this.TopElement.QueryOwnedParameterSubscriptions(domain));
            }

            subscriptions.AddRange(this.Element.SelectMany(x => x.ContainedElement).SelectMany(x => x.QueryOwnedParameterSubscriptions(domain)));
            return subscriptions.DistinctBy(x => x.Iid).OrderBy(p => p.ParameterType.Name);
        }

        /// <summary>
        /// Queries owned <see cref="ParameterOrOverrideBase" /> contained into an <see cref="Iteration" />
        /// that contains <see cref="ParameterSubscription" /> of other <see cref="DomainOfExpertise" />
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public IEnumerable<ParameterOrOverrideBase> QuerySubscribedParameterByOthers(DomainOfExpertise domain)
        {
            var subscriptions = new List<ParameterOrOverrideBase>();

            if (this.TopElement != null)
            {
                subscriptions.AddRange(this.TopElement.QuerySubscribedParameterByOthers(domain));
            }

            subscriptions.AddRange(this.Element.SelectMany(x => x.ContainedElement).SelectMany(x => x.QuerySubscribedParameterByOthers(domain)));
            return subscriptions.DistinctBy(x => x.Iid).OrderBy(p => p.ParameterType.Name);
        }
    }
}
