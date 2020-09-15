// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeGenerator.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    using NLog;

    /// <summary>
    /// The purpose of the <see cref="NestedElementTreeGenerator"/> class is to generate the <see cref="NestedElement"/>s
    /// and <see cref="NestedParameter"/>s for an <see cref="Option"/> where the <see cref="NestedParameter"/>s
    /// are owned by a specific <see cref="DomainOfExpertise"/>
    /// </summary>
    /// <remarks>
    /// The <see cref="NestedParameter"/>s represent the owned <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s,
    /// and <see cref="ParameterSubscription"/>s. Each <see cref="ParameterTypeComponent"/> of a <see cref="CompoundParameterType"/> is 
    /// represented by a unique <see cref="NestedParameter"/>.
    /// </remarks>
    public class NestedElementTreeGenerator
    {
        /// <summary>
        /// The NLog logger
        /// </summary>
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Creates the <see cref="NestedParameter"/>s in a flat list from <see cref="NestedElement"/>s list for the of <see cref="NestedElement"/>s.
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedParameter"/>s flat list is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedParameter"/>s flat list needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/> that contains the generated <see cref="NestedParameter"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        public IEnumerable<NestedParameter> GetNestedParameters(Option option, DomainOfExpertise domainOfExpertise, bool updateOption = false)
        {
            if (domainOfExpertise == null)
            {
                throw new ArgumentNullException(nameof(domainOfExpertise), "The domainOfExpertise may not be null");
            }

            return this.GetNestedParameters_Impl(option, domainOfExpertise, updateOption);
        }

        /// <summary>
        /// Creates the <see cref="NestedParameter"/>s in a flat list from <see cref="NestedElement"/>s list for the of <see cref="NestedElement"/>s.
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedParameter"/>s flat list is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/> that contains the generated <see cref="NestedParameter"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        public IEnumerable<NestedParameter> GetNestedParameters(Option option, bool updateOption = false)
        {
            return this.GetNestedParameters_Impl(option, null, updateOption);
        }

        /// <summary>
        /// Creates the <see cref="NestedParameter"/>s in a flat list from <see cref="NestedElement"/>s list for the of <see cref="NestedElement"/>s.
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedParameter"/>s flat list is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedParameter"/>s flat list needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/> that contains the generated <see cref="NestedParameter"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        private IEnumerable<NestedParameter> GetNestedParameters_Impl(Option option, DomainOfExpertise domainOfExpertise, bool updateOption)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option), "The option may not be null");
            }

            var iteration = (Iteration) option.Container;

            Logger.Debug($"Generating NestedElement for Iteration {iteration.Iid}, Option: {option.ShortName}, DomainOfExpertise {domainOfExpertise?.ShortName ?? ": All"}");

            var nestedElements = this.Generate_Impl(option, domainOfExpertise, updateOption);

            Logger.Debug($"Crearing NestedParameters Iteration: {iteration.Iid}, Option: {option.ShortName}, DomainOfExpertise {domainOfExpertise?.ShortName ?? ": All"}");

            var flatNestedParameters = nestedElements.SelectMany(np => np.NestedParameter);

            return flatNestedParameters.ToList();
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        public IEnumerable<NestedElement> Generate(Option option, DomainOfExpertise domainOfExpertise, bool updateOption = false)
        {
            if (domainOfExpertise == null)
            {
                throw new ArgumentNullException(nameof(domainOfExpertise), "The domainOfExpertise may not be null");
            }

            return this.Generate_Impl(option, domainOfExpertise, updateOption);
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        public IEnumerable<NestedElement> Generate(Option option, bool updateOption = false)
        {
            return this.Generate_Impl(option, null, updateOption);
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s and <see cref="NestedParameter"/>s for the specified <see cref="Option"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree needs to be generated.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s filtered based on the provided <see cref="Option"/>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// </exception>
        private IEnumerable<NestedElement> Generate_Impl(Option option, DomainOfExpertise domainOfExpertise, bool updateOption)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option), "The option may not be null");
            }

            var iteration = (Iteration) option.Container;
            var rootElement = iteration.TopElement;

            if (rootElement == null)
            {
                throw new NestedElementTreeException($"The container Iteration of Option {option.ShortName} does not have a TopElement specified");
            }

            Logger.Debug($"Generating NestedElement for Iteration {iteration.Iid}, Option: {option.ShortName}, DomainOfExpertise {domainOfExpertise?.ShortName ?? ": All"}");

            var createNestedElements = this.GenerateNestedElements_Impl(option, domainOfExpertise, rootElement, updateOption);
            return createNestedElements;
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="domainOfExpertise"/> is null
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        public IEnumerable<NestedElement> GenerateNestedElements(Option option, DomainOfExpertise domainOfExpertise, ElementDefinition rootElement, bool updateOption = false)
        {
            if (domainOfExpertise == null)
            {
                throw new ArgumentNullException(nameof(domainOfExpertise), "The domainOfExpertise may not be null");
            }

            return this.GenerateNestedElements_Impl(option, domainOfExpertise, rootElement, updateOption);
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        public IEnumerable<NestedElement> GenerateNestedElements(Option option, ElementDefinition rootElement, bool updateOption = false)
        {
            return this.GenerateNestedElements_Impl(option, null, rootElement, updateOption);
        }

        /// <summary>
        /// Generates the <see cref="NestedElement"/>s starting at the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that serves as the root of the generated <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedElement}"/> that contains the generated <see cref="NestedElement"/>s
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown when the <paramref name="option"/> is null
        /// thrown when the <paramref name="rootElement"/> is null
        /// </exception>
        private IEnumerable<NestedElement> GenerateNestedElements_Impl(Option option, DomainOfExpertise domainOfExpertise, ElementDefinition rootElement, bool updateOption = false)
        {
            if (option == null)
            {
                throw new ArgumentNullException(nameof(option), "The option may not be null");
            }

            if (rootElement == null)
            {
                throw new ArgumentNullException(nameof(rootElement), "The rootElement may not be null");
            }

            var nestedElements = new List<NestedElement>();

            var rootNestedElement = this.CreateNestedElementAndNestedParametersForRootElement(rootElement, domainOfExpertise, option, updateOption);
            nestedElements.Add(rootNestedElement);

            var elementUsages = new List<ElementUsage>();
            var recursedNestedElements = this.RecursivelyCreateNestedElements(rootElement, rootElement, domainOfExpertise, elementUsages, option, updateOption);
            nestedElements.AddRange(recursedNestedElements);

            return nestedElements;
        }

        /// <summary>
        /// Recursively Create <see cref="NestedElement"/>s
        /// </summary>
        /// <param name="elementDefinition">
        /// The <see cref="ElementDefinition"/> that contains <see cref="ElementUsage"/>s that
        /// </param>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that is the root of the <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="elementUsages">
        /// A <see cref="List{ElementUsage}"/> that contains the <see cref="ElementUsage"/> that define the containment tree
        /// for the <see cref="NestedElement"/>s at the level of the <paramref name="elementDefinition"/>.
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{NestedElement}"/> that have been created.
        /// </returns>
        private IEnumerable<NestedElement> RecursivelyCreateNestedElements(ElementDefinition elementDefinition, ElementDefinition rootElement, DomainOfExpertise domainOfExpertise, List<ElementUsage> elementUsages, Option option, bool updateOption)
        {
            var cache = elementDefinition.Cache;
            var uri = elementDefinition.IDalUri;

            foreach (var elementUsage in elementDefinition.ContainedElement)
            {
                // comparison is done based on unique identifiers, not on object level. The provided option may be a clone
                if (elementUsage.ExcludeOption.Any(x => x.Iid == option.Iid))
                {
                    Logger.Debug($"ElementUsage {elementUsage.Iid}:{elementUsage.ShortName} is excluded from the Nested Elements.");
                    continue;
                }

                var nestedElement = new NestedElement(Guid.NewGuid(), cache, uri)
                {
                    RootElement = rootElement,
                    IsVolatile = true
                };

                if (updateOption)
                {
                    option.NestedElement.Add(nestedElement);
                }
                else
                {
                    nestedElement.Container = option;
                }

                var nestedParameters = this.CreateNestedParameters(elementUsage, domainOfExpertise, option);

                foreach (var nestedParameter in nestedParameters)
                {
                    nestedElement.NestedParameter.Add(nestedParameter);
                }

                var containmentUsages = new List<ElementUsage>();

                foreach (var usage in elementUsages)
                {
                    nestedElement.ElementUsage.Add(usage);
                    containmentUsages.Add(usage);
                }

                nestedElement.ElementUsage.Add(elementUsage);
                containmentUsages.Add(elementUsage);

                var referencedElementDefinition = elementUsage.ElementDefinition;

                var nestedElements = this.RecursivelyCreateNestedElements(referencedElementDefinition, rootElement, domainOfExpertise, containmentUsages, option, updateOption);

                foreach (var element in nestedElements)
                {
                    yield return element;
                }

                yield return nestedElement;
            }
        }

        /// <summary>
        /// Creates The <see cref="NestedElement"/> and contained <see cref="NestedParameter"/> that represents the <paramref name="rootElement"/>
        /// </summary>
        /// <param name="rootElement">
        /// The <see cref="ElementDefinition"/> that is the root of the <see cref="NestedElement"/> tree.
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. When the <see cref="Option"/>
        /// is null then none of the <see cref="ElementUsage"/>s are filtered.
        /// </param>
        /// <param name="updateOption">
        /// Value indicating whether the <see cref="Option"/> shall be updated with the created <see cref="NestedElement"/>s or not.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{NestedElement}"/> that have been created.
        /// </returns>
        private NestedElement CreateNestedElementAndNestedParametersForRootElement(ElementDefinition rootElement, DomainOfExpertise domainOfExpertise, Option option, bool updateOption)
        {
            var nestedElement = new NestedElement(Guid.NewGuid(), rootElement.Cache, rootElement.IDalUri)
            {
                RootElement = rootElement,
                IsVolatile = true,
                IsRootElement = true
            };

            if (updateOption)
            {
                option.NestedElement.Add(nestedElement);
            }
            else
            {
                nestedElement.Container = option;
            }

            foreach (var parameter in rootElement.Parameter)
            {
                var compoundParameterType = parameter.ParameterType as CompoundParameterType;

                if (domainOfExpertise == null || parameter.Owner == domainOfExpertise)
                {
                    var valueSets = parameter.IsOptionDependent ? parameter.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameter.ValueSet;

                    foreach (var parameterValueSet in valueSets)
                    {
                        if (compoundParameterType == null)
                        {
                            var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterValueSet, option);
                            nestedElement.NestedParameter.Add(nestedParameter);
                        }
                        else
                        {
                            foreach (var component in compoundParameterType.Component)
                            {
                                var comp = (ParameterTypeComponent) component;
                                var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterValueSet, option);
                                nestedElement.NestedParameter.Add(nestedParameter);
                            }
                        }
                    }
                }
                else
                {
                    var subscription = parameter.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);

                    if (subscription != null)
                    {
                        var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);

                        foreach (var nestedParameter in nestedParameters)
                        {
                            nestedElement.NestedParameter.Add(nestedParameter);
                        }
                    }
                }
            }

            return nestedElement;
        }

        /// <summary>
        /// Creates <see cref="NestedParameter"/>s based on the <see cref="Parameter"/> that are contained by the <see cref="ElementDefinition"/>
        /// that is referenced by the <paramref name="elementUsage"/> as well as <see cref="NestedParameter"/>s that are based on the <see cref="ParameterOverride"/>
        /// that are contained by the <paramref name="elementUsage"/> itself.
        /// </summary>
        /// <param name="elementUsage">
        /// The <see cref="ElementUsage"/> that corresponds to the <see cref="NestedElement"/> for which <see cref="NestedParameter"/>s need to be created
        /// </param>
        /// <param name="domainOfExpertise">
        /// The <see cref="DomainOfExpertise"/> for which the <see cref="NestedElement"/> tree needs to be generated. Only the <see cref="Parameter"/>s, <see cref="ParameterOverride"/>s and
        /// <see cref="ParameterSubscription"/>s that are owned by the <see cref="DomainOfExpertise"/> will be taken into account when generating <see cref="NestedParameter"/>s
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. 
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{NestedParameter}"/>.
        /// </returns>
        private IEnumerable<NestedParameter> CreateNestedParameters(ElementUsage elementUsage, DomainOfExpertise domainOfExpertise, Option option)
        {
            var elementDefinition = elementUsage.ElementDefinition;

            foreach (var parameter in elementDefinition.Parameter)
            {
                var compoundParameterType = parameter.ParameterType as CompoundParameterType;

                var parameterOveride = elementUsage.ParameterOverride.SingleOrDefault(po => po.Parameter == parameter);

                if (parameterOveride == null)
                {
                    if (domainOfExpertise == null || parameter.Owner == domainOfExpertise)
                    {
                        var valueSets = parameter.IsOptionDependent ? parameter.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameter.ValueSet;

                        foreach (var parameterValueSet in valueSets)
                        {
                            if (compoundParameterType == null)
                            {
                                var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterValueSet, option);
                                yield return nestedParameter;
                            }
                            else
                            {
                                foreach (var component in compoundParameterType.Component)
                                {
                                    var comp = (ParameterTypeComponent) component;
                                    var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterValueSet, option);
                                    yield return nestedParameter;
                                }
                            }
                        }
                    }
                    else
                    {
                        var subscription = parameter.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);

                        if (subscription != null)
                        {
                            var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);

                            foreach (var nestedParameter in nestedParameters)
                            {
                                yield return nestedParameter;
                            }
                        }
                    }
                }
                else
                {
                    if (domainOfExpertise == null || parameterOveride.Owner == domainOfExpertise)
                    {
                        var valueSets = parameterOveride.IsOptionDependent ? parameterOveride.ValueSet.Where(vs => vs.ActualOption == option).ToList() : parameterOveride.ValueSet;

                        foreach (var parameterOverrideValueSet in valueSets)
                        {
                            if (compoundParameterType == null)
                            {
                                var nestedParameter = this.CreatedNestedParameter(parameter, null, parameterOverrideValueSet, option);
                                yield return nestedParameter;
                            }
                            else
                            {
                                foreach (var component in compoundParameterType.Component)
                                {
                                    var comp = (ParameterTypeComponent) component;
                                    var nestedParameter = this.CreatedNestedParameter(parameter, comp, parameterOverrideValueSet, option);
                                    yield return nestedParameter;
                                }
                            }
                        }
                    }
                    else
                    {
                        var subscription = parameterOveride.ParameterSubscription.SingleOrDefault(ps => ps.Owner == domainOfExpertise);

                        if (subscription != null)
                        {
                            var nestedParameters = this.CreatedNestedParameters(subscription, option, compoundParameterType);

                            foreach (var nestedParameter in nestedParameters)
                            {
                                yield return nestedParameter;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="subscription">
        /// The <see cref="ParameterSubscription"/> that contains the <see cref="ParameterSubscriptionValueSet"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="option">
        /// The <see cref="Option"/> for which the <see cref="NestedElement"/> tree is created. 
        /// </param>
        /// <param name="compoundParameterType">
        /// The <see cref="CompoundParameterType"/> that contains the <see cref="ParameterTypeComponent"/> for which distinct <see cref="NestedParameter"/>
        /// are created.
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private IEnumerable<NestedParameter> CreatedNestedParameters(ParameterSubscription subscription, Option option, CompoundParameterType compoundParameterType)
        {
            var valueSets = subscription.IsOptionDependent ? subscription.ValueSet.Where(vs => vs.ActualOption == option).ToList() : subscription.ValueSet;

            foreach (var parameterSubscriptionValueSet in valueSets)
            {
                if (compoundParameterType == null)
                {
                    var nestedParameter = this.CreateNestedParameter(subscription, null, parameterSubscriptionValueSet, option);
                    yield return nestedParameter;
                }
                else
                {
                    foreach (var component in compoundParameterType.Component)
                    {
                        var comp = (ParameterTypeComponent) component;
                        var nestedParameter = this.CreateNestedParameter(subscription, comp, parameterSubscriptionValueSet, option);
                        yield return nestedParameter;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="parameter">
        /// The <see cref="ParameterOrOverrideBase"/> that contains the <see cref="ParameterValueSetBase"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="component">
        /// The <see cref="ParameterTypeComponent"/> that this <see cref="NestedParameter"/> is associated to. This may be null in case the <see cref="ParameterType"/>
        /// of the associated <see cref="Parameter"/> is a <see cref="ScalarParameterType"/>.
        /// </param>
        /// <param name="valueSet">
        /// The <see cref="ParameterValueSetBase"/> that provides the reference to the <see cref="ActualFiniteState"/> and values
        /// to create the <see cref="NestedParameter"/>
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private NestedParameter CreatedNestedParameter(ParameterOrOverrideBase parameter, ParameterTypeComponent component, ParameterValueSetBase valueSet, Option option)
        {
            var componentIndex = component == null ? 0 : component.Index;
            var actualValue = valueSet.ActualValue[componentIndex];
            var formula = valueSet.Formula[componentIndex];

            var nestedParameter = new NestedParameter(Guid.NewGuid(), parameter.Cache, parameter.IDalUri)
            {
                IsVolatile = true,
                AssociatedParameter = parameter,
                Owner = parameter.Owner,
                Component = component,
                ActualState = valueSet.ActualState,
                ActualValue = actualValue,
                Formula = formula,
                ValueSet = valueSet,
                Option = option
            };

            return nestedParameter;
        }

        /// <summary>
        /// Creates a <see cref="NestedParameter"/> based on the provided <see cref="ParameterOrOverrideBase"/> and <see cref="ParameterValueSetBase"/>
        /// </summary>
        /// <param name="subscription">
        /// The <see cref="ParameterSubscription"/> that contains the <see cref="ParameterSubscriptionValueSet"/> based on which the 
        /// <see cref="NestedParameter"/> is created.
        /// </param>
        /// <param name="component">
        /// The <see cref="ParameterTypeComponent"/> that this <see cref="NestedParameter"/> is associated to. This may be null in case the <see cref="ParameterType"/>
        /// of the associated <see cref="Parameter"/> is a <see cref="ScalarParameterType"/>.
        /// </param>
        /// <param name="valueSet">
        /// The <see cref="ParameterSubscriptionValueSet"/> that provides the reference to the <see cref="ActualFiniteState"/> and values
        /// to create the <see cref="NestedParameter"/>
        /// </param>
        /// <returns>
        /// An instance of a non-volatile <see cref="NestedParameter"/>
        /// </returns>
        private NestedParameter CreateNestedParameter(ParameterSubscription subscription, ParameterTypeComponent component, ParameterSubscriptionValueSet valueSet, Option option)
        {
            var componentIndex = component == null ? 0 : component.Index;
            var actualValue = valueSet.ActualValue[componentIndex];

            var nestedParameter = new NestedParameter(Guid.NewGuid(), subscription.Cache, subscription.IDalUri)
            {
                IsVolatile = true,
                AssociatedParameter = subscription,
                Owner = subscription.Owner,
                Component = component,
                ActualState = valueSet.ActualState,
                ActualValue = actualValue,
                ValueSet = valueSet,
                Option = option
            };

            return nestedParameter;
        }

        /// <summary>
        /// Get <see cref="NestedElement.ShortName"/> for an <see cref="ElementDefinition"/> 
        /// </summary>
        /// <param name="elementDefinition">The <see cref="ElementDefinition"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns>The <see cref="NestedElement.ShortName"/> if found, otherwise null</returns>
        public string GetNestedElementShortName(ElementDefinition elementDefinition, Option option)
        {
            var iteration = (Iteration) option.Container;
            return iteration.TopElement == elementDefinition ? elementDefinition.ShortName : null;
        }

        /// <summary>
        /// Get <see cref="NestedElement.ShortName"/> for an <see cref="ElementUsage"/> 
        /// </summary>
        /// <param name="elementUsage">The <see cref="ElementUsage"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns>The <see cref="NestedElement.ShortName"/> if found, otherwise null</returns>
        public string GetNestedElementShortName(ElementUsage elementUsage, Option option)
        {
            var nestedElements = this.Generate(option);

            return nestedElements.FirstOrDefault(x => x.GetElementUsage() == elementUsage)?.ShortName;
        }

        /// <summary>
        /// Get <see cref="NestedParameter.Path"/> for a <see cref="ParameterBase"/> 
        /// </summary>
        /// <param name="parameterBase">The <see cref="ParameterBase"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <returns>The <see cref="NestedParameter.Path"/> if found, otherwise null</returns>
        public string GetNestedParameterPath(ParameterBase parameterBase, Option option)
        {
            var nestedParameters = this.GetNestedParameters(option);

            var parameter = parameterBase;

            if (parameterBase is ParameterOverride parameterOverride)
            {
                parameter = parameterOverride.Parameter;
            }

            return nestedParameters.FirstOrDefault(x => x.AssociatedParameter == parameter)?.Path;
        }

        /// <summary>
        /// Get <see cref="NestedParameter.Path"/> for a <see cref="ParameterBase"/> 
        /// </summary>
        /// <param name="parameterBase">The <see cref="ParameterBase"/></param>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="actualFiniteState">Get the <see cref="NestedParameter.Path"/> from a specific <see cref="ActualFiniteState"/></param>
        /// <returns>The <see cref="NestedParameter.Path"/> if found, otherwise null</returns>
        public string GetNestedParameterPath(ParameterBase parameterBase, Option option, ActualFiniteState actualFiniteState)
        {
            var nestedParameters = this.GetNestedParameters(option);

            var parameter = parameterBase;

            if (parameterBase is ParameterOverride parameterOverride)
            {
                parameter = parameterOverride.Parameter;
            }

            return nestedParameters.FirstOrDefault(x => x.AssociatedParameter == parameter && x.ActualState == actualFiniteState)?.Path;
        }
    }
}
