// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementBase.cs" company="RHEA System S.A.">
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
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ElementBase"/>
    /// </summary>
    public abstract partial class ElementBase : IPublishable
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="ElementBase"/> can be published.
        /// </summary>
        public abstract bool CanBePublished { get; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ElementBase"/> will be published in the next <see cref="Publication"/>.
        /// </summary>
        public abstract bool ToBePublished { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the 
        /// required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdl = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                foreach (var category in this.Category)
                {
                    requiredRdl.UnionWith(category.RequiredRdls);
                }

                return requiredRdl;
            }
        }

        /// <summary>
        /// Queries all <see cref="ParameterSubscription" /> owned by a given <see cref="DomainOfExpertise" />
        /// contained into an <see cref="ElementBase" />
        /// </summary>
        /// <param name="element">The <see cref="ElementBase" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public IEnumerable<ParameterSubscription> QueryOwnedParameterSubscriptions(DomainOfExpertise domain)
        {
            var subscriptions = new List<ParameterSubscription>();

            switch (this)
            {
                case ElementDefinition elementDefinition:
                    subscriptions.AddRange(elementDefinition.Parameter.QueryOwnedParameterSubscriptions(domain));
                    break;
                case ElementUsage elementUsage when !elementUsage.ParameterOverride.Any():
                    return elementUsage.ElementDefinition.QueryOwnedParameterSubscriptions(domain);
                case ElementUsage elementUsage:
                    var notOverridenParameters = elementUsage.ElementDefinition.Parameter.Where(x => elementUsage.ParameterOverride.All(p => p.Parameter.Iid != x.Iid));

                    subscriptions.AddRange(elementUsage.ParameterOverride.QueryOwnedParameterSubscriptions(domain));

                    subscriptions.AddRange(notOverridenParameters.QueryOwnedParameterSubscriptions(domain));
                    break;
            }

            return subscriptions;
        }

        /// <summary>
        /// Queries owned <see cref="ParameterOrOverrideBase" /> contained into an <see cref="ElementBase" />
        /// that contains <see cref="ParameterSubscription" /> of other <see cref="DomainOfExpertise" />
        /// </summary>
        /// <param name="element">The <see cref="ElementBase" /></param>
        /// <param name="domain">The <see cref="DomainOfExpertise" /></param>
        /// <returns>A collection of <see cref="ParameterSubscription" /></returns>
        public IEnumerable<ParameterOrOverrideBase> QuerySubscribedParameterByOthers(DomainOfExpertise domain)
        {
            var subscriptions = new List<ParameterOrOverrideBase>();

            switch (this)
            {
                case ElementDefinition elementDefinition:
                    subscriptions.AddRange(elementDefinition.Parameter.QuerySubscribedParameterByOthers(domain));
                    break;
                case ElementUsage elementUsage when !elementUsage.ParameterOverride.Any():
                    return elementUsage.ElementDefinition.QuerySubscribedParameterByOthers(domain);
                case ElementUsage elementUsage:
                    var notOverridenParameters = elementUsage.ElementDefinition.Parameter.Where(x => elementUsage.ParameterOverride.All(p => p.Parameter.Iid != x.Iid));
                    subscriptions.AddRange(elementUsage.ParameterOverride.QuerySubscribedParameterByOthers(domain));
                    subscriptions.AddRange(notOverridenParameters.QuerySubscribedParameterByOthers(domain));
                    break;
            }

            return subscriptions;
        }

        /// <summary> 
        /// Queries the <see cref="ParameterBase"/> that an <see cref="ElementBase"/> uses
        /// </summary> 
        /// <returns>
        /// a <see cref="IEnumerable{T}"/> with the <see cref="ParameterBase"/>
        /// </returns> 
        public IEnumerable<ParameterBase> QueryParametersInUse()
        {
            var parameters = new List<ParameterBase>();

            if (this is ElementDefinition elementDefinition)
            {
                parameters.AddRange(elementDefinition.Parameter.Distinct());
            }
            else if (this is ElementUsage elementUsage)
            {
                parameters.AddRange(elementUsage.ParameterOverride);

                foreach (var parameter in elementUsage.ElementDefinition.Parameter)
                {
                    if (parameters.All(p => p.ParameterType.Iid != parameter.ParameterType.Iid))
                    {
                        parameters.Add(parameter);
                    }
                }
            }

            return parameters.OrderBy(x => x.ParameterType.ShortName).ToList();
        }
    }
}
