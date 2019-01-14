#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionContextResolver.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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
#endregion

namespace CDP4Dal.Operations
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The purpose of the <see cref="TransactionContextResolver"/> is to resolve either the <see cref="SiteDirectory"/>
    /// or the <see cref="Iteration"/> that is in the containment chain of any <see cref="Thing"/>.
    /// In case a <see cref="Thing"/> is not contained somehow by an <see cref="Iteration"/> but by an <see cref="EngineeringModel"/>
    /// it is either the non-frozen <see cref="Iteration"/> or the <see cref="Iteration"/> with the highest revision
    /// number that is returned.
    /// </summary>
    /// <remarks>
    /// The <see cref="SiteDirectory"/> or <see cref="Iteration"/> that is resolved is used by the <see cref="ThingTransaction"/>
    /// </remarks>
    public static class TransactionContextResolver
    {
        /// <summary>
        /// Resolves either the <see cref="SiteDirectory"/> or the <see cref="Iteration"/> that is in the containment chain of any <see cref="Thing"/>.
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> for which the context needs to be resolved.
        /// </param>
        /// <returns>
        /// An instance of <see cref="SiteDirectory"/> or <see cref="Iteration"/>
        /// </returns>
        /// <exception cref="IncompleteModelException">
        /// an <see cref="IncompleteModelException"/> is thrown when the model is incomplete or the context could not be determined.
        /// </exception>
        public static TransactionContext ResolveContext(Thing thing)
        {
            var siteDirectory = thing as SiteDirectory;
            if (siteDirectory != null)
            {
                return new TransactionContext(siteDirectory);
            }

            var iteration = thing as Iteration;
            if (iteration != null)
            {
                return new TransactionContext(iteration);
            }

            var topContainer = thing.TopContainer;
            siteDirectory = topContainer as SiteDirectory;
            if (siteDirectory != null)
            {
                return new TransactionContext(siteDirectory);
            }

            var engineeringModel = topContainer as EngineeringModel;
            if (engineeringModel != null)
            {
                // first check if the thing has an Iteration as a container
                iteration = thing.GetContainerOfType<Iteration>();
                if (iteration != null)
                {
                    return new TransactionContext(iteration);
                }

                if (engineeringModel.Iteration.Count == 0)
                {
                    throw new IncompleteModelException("The EngineeringModel does not contain any iterations while this was expected: the transaction context cannot be resolved");
                }

                iteration = engineeringModel.Iteration.SingleOrDefault(x => x.IterationSetup.FrozenOn == null);
                if (iteration != null)
                {
                    return new TransactionContext(iteration);
                }
                else
                {
                    iteration = engineeringModel.Iteration.OrderByDescending(x => x.RevisionNumber).First();
                    return new TransactionContext(iteration);
                }
            }
            
            throw new IncompleteModelException(string.Format("The context of the {0}:{1} could not be determined.", thing.GetType().Name, thing.Iid));
        }

        /// <summary>
        /// Validates the provided context which must be a valid route to a <see cref="SiteDirectory"/> or an <see cref="Iteration"/>
        /// </summary>
        /// <param name="route">
        /// the route that is to be validated
        /// </param>
        /// <returns>
        /// true if the context is a valid context, false otherwise
        /// </returns>
        /// <example>
        /// The following are valid routes (the leading / is required)
        /// /SiteDirectory/{guid}
        /// /EngineeringModel/{guid}/iteration/{guid}
        /// </example>
        public static bool ValidateRouteContext(string route)
        {
            var siteDirectoryPattern = @"^/SiteDirectory" + Constants.UriPathSeparator + Constants.UriGuidPattern + "$";
            var siteDirectoryPatternMatch = Regex.Match(route, siteDirectoryPattern);
            if (siteDirectoryPatternMatch.Success)
            {
                return true;
            }

            var iterationPattern = @"^/EngineeringModel" + Constants.UriPathSeparator + Constants.UriGuidPattern + Constants.UriPathSeparator + "iteration" + Constants.UriPathSeparator + Constants.UriGuidPattern + "$";
            var iterationPatternMatch = Regex.Match(route, iterationPattern);
            if (iterationPatternMatch.Success)
            {
                return true;
            }

            return false;
        }
    }
}
