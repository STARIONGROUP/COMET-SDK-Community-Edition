// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBase.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterGroup"/>
    /// </summary>
    public partial class ParameterBase : IModelCode
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.ModelCode(); }
        }

        /// <summary>
        /// Gets the user-friendly shortName
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ModelCode(); }
        }

        /// <summary>
        /// Queries the grouping level of the current <see cref="ParameterBase"/>.
        /// </summary>
        /// <returns>
        /// The level of the <see cref="ParameterBase"/> in it's virtual <see cref="ParameterGroup"/> containment hierarchy.
        /// </returns>
        /// <remarks>
        /// The level of a <see cref="ParameterBase"/> that has no <see cref="Group"/> is zero.
        /// </remarks>
        public int Level()
        {
            if (this.Group == null)
            {
                return 0;
            }

            return this.Group.Level() + 1;
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the required <see cref="ReferenceDataLibrary"/> 
        /// for the current <see cref="Thing"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var requiredRdls = new HashSet<ReferenceDataLibrary>(base.RequiredRdls);
                requiredRdls.UnionWith(this.ParameterType.RequiredRdls);
                return requiredRdls;
            }
        }

        /// <summary>
        /// Gets the <see cref="IValueSet"/> for this <see cref="ParameterBase"/>
        /// </summary>
        /// <remarks>
        /// This is a convenience property that simply returns the actual value-sets of the concrete <see cref="ParameterBase"/>
        /// ie, <see cref="Parameter.ValueSet"/>, <see cref="ParameterOverride.ValueSet"/> or <see cref="ParameterSubscription.ValueSet"/>
        /// </remarks>
        public IEnumerable<IValueSet> ValueSets
        {
            get
            {
                if (this is Parameter parameter)
                {
                    return parameter.ValueSet;
                }

                if (this is ParameterOverride parameterOverride)
                {
                    return parameterOverride.ValueSet;
                }

                var subscription = (ParameterSubscription)this;
                return subscription.ValueSet;
            }
        }

        /// <summary>
        /// Computes the model code of the current object
        /// </summary>
        /// <param name="componentIndex">
        /// The component Index.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> that represents the model code, valid separators are <code>.</code> and <code>/</code>
        /// </returns>
        public abstract string ModelCode(int? componentIndex = null);

        /// <summary>
        /// Searches for a <see cref="IValueSet"/> for the given <see cref="Option"/> and <see cref="ActualFiniteState"/>.
        /// </summary>
        /// <param name="option">The <see cref="Option"/></param>
        /// <param name="actualState">The <see cref="ActualFiniteState"/></param>
        /// <returns>The <see cref="IValueSet"/></returns>
        public IValueSet QueryParameterBaseValueSet(Option option, ActualFiniteState actualState)
        {
            var valueSets = this.ValueSets.ToList();

            if (!valueSets.Any())
            {
                throw new IncompleteModelException($"{this.GetType().Name} {this.UserFriendlyName} doesn't contain any values.");
            }

            if (this.IsOptionDependent)
            {
                if (option == null)
                {
                    throw new ArgumentNullException($"{this.GetType().Name} {this.UserFriendlyName} is option dependent. The {nameof(option)} cannot be null.");
                }

                valueSets = valueSets.Where(x => x.ActualOption == option).ToList();

                if (!valueSets.Any())
                {
                    throw new ArgumentException($"{this.GetType().Name} {this.UserFriendlyName} doesn't have values for {nameof(Option)} {option.Name}.");
                }
            }

            if (this.StateDependence != null)
            {
                if (actualState == null)
                {
                    throw new ArgumentNullException($"{this.GetType().Name} {this.UserFriendlyName} is state dependent. The {nameof(actualState)} property cannot be null.");
                }

                valueSets = valueSets.Where(x => x.ActualState == actualState).ToList();

                if (!valueSets.Any())
                {
                    throw new ArgumentException($"{this.GetType().Name} {this.UserFriendlyName} doesn't have values for {nameof(ActualFiniteState)} {actualState.Name}.");
                }
            }

            if (valueSets.Count > 1)
            {
                throw new Cdp4ModelValidationException(
                    $"Multiple ValueSets found for {this.GetType().Name} {this.UserFriendlyName}" + 
                    $" having {nameof(option)} = {option?.Name ?? "<empty>"} and {nameof(actualState)} = {actualState?.Name ?? "<empty>"}");
            }

            return valueSets.First();
        }
    }
}