// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoRouteResolver.cs" company="RHEA System S.A.">
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

namespace CDP4Dal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.DTO;
    using CDP4Common.Types;
    
    using CDP4Dal.Exceptions;
    
    using Poco = CDP4Common.CommonData.Thing;

    /// <summary>
    /// A class that resolve the route of a <see cref="Thing"/>
    /// </summary>
    public static class DtoRouteResolver
    {
        /// <summary>
        /// Resolve the route of a <see cref="Thing"/> from a <see cref="IEnumerable{Thing}"/> that contains all its containers
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> to resolve</param>
        /// <param name="dtolist">The <see cref="IEnumerable{Thing}"/> that shall contain</param>
        /// <param name="session">The <see cref="ISession"/> associated to the <see cref="Thing"/></param>
        /// <exception cref="ArgumentNullException">The arguments cannot be null</exception>
        /// <exception cref="InstanceNotFoundException">If the container cannot be found</exception>
        /// <exception cref="InvalidOperationException">If the multiple containers are found for one thing</exception>
        /// <exception cref="NullReferenceException">The containement tree is broken for a <see cref="Poco"/> currently in the <see cref="ISession"/></exception>
        public static void ResolveRoute(this Thing thing, IEnumerable<Thing> dtolist, ISession session)
        {
            if (dtolist == null)
            {
                throw new ArgumentNullException("dtolist");
            }

            if (session == null)
            {
                throw new ArgumentNullException("session");
            }

            if (thing is TopContainer)
            {
                return;
            }

            var dtos = dtolist.ToList();
            Thing container = dtos.SingleOrDefault(dto => dto.Contains(thing));
            if (container == null)
            {
                // the container is not in the list of dtos, search in the current ISession
                Lazy<Poco> lazyThing;
                var res = session.Assembler.Cache.TryGetValue(new CacheKey(thing.Iid, thing.IterationContainerId), out lazyThing);
                if (!res)
                {
                    throw new InstanceNotFoundException(string.Format("The {0} with id {1} could not be found", thing.ClassKind, thing.Iid));
                }

                // Build the complete containement tree
                thing.AddContainerCompleteTree(lazyThing.Value);
                return;
            }

            // the container is in the list of dtos
            thing.AddContainer(container.ClassKind, container.Iid);
            while (!(container is TopContainer))
            {
                var previousContainer = container;
                container = dtos.SingleOrDefault(dto => dto.Contains(container));
                if (container != null)
                {
                    thing.AddContainer(container.ClassKind, container.Iid);
                    continue;
                }

                // one of the container nnot be found in the list of dto => search in the current ISession and build the partial tree up to the topcontainer
                Lazy<Poco> lazyThing;
                var res = session.Assembler.Cache.TryGetValue(new CacheKey(previousContainer.Iid, previousContainer.IterationContainerId), out lazyThing);
                if (!res)
                {
                    throw new InstanceNotFoundException(string.Format("The {0} with id {1} could not be found", previousContainer.ClassKind, previousContainer.Iid));
                }

                thing.AddContainerPartialTree(lazyThing.Value);
                break;
            }
        }

        /// <summary>
        /// Build the full containment tree for a <see cref="Thing"/> from its associated <see cref="Poco"/>
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> which containment tree is computed</param>
        /// <param name="cachedThing">Its associated <see cref="Poco"/> in the current <see cref="ISession"/></param>
        private static void AddContainerCompleteTree(this Thing thing, Poco cachedThing)
        {
            var container = cachedThing.Container;
            if (container == null)
            {
                throw new NullReferenceException(string.Format("The container of the {0} with id {1} is null.", thing.ClassKind, thing.Iid));
            }

            thing.AddContainer(container.ClassKind, container.Iid);
            while (!(container is CDP4Common.CommonData.TopContainer))
            {
                container = container.Container;
                if (container == null)
                {
                    throw new NullReferenceException(string.Format("The containment tree is broken for the {0} with id {1}.", thing.ClassKind, thing.Iid));
                }

                thing.AddContainer(container.ClassKind, container.Iid);
            }
        }

        /// <summary>
        /// Build the partial containment tree of a <see cref="Thing"/> starting from one of its container
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> which containment tree is computed</param>
        /// <param name="container">One of its container in the containment tree in the current <see cref="ISession"/></param>
        private static void AddContainerPartialTree(this Thing thing, Poco container)
        {
            var tmpContainer = container;
            while (!(tmpContainer is CDP4Common.CommonData.TopContainer))
            {
                tmpContainer = tmpContainer.Container;
                if (tmpContainer == null)
                {
                    throw new NullReferenceException(string.Format("The containment tree is broken for the {0} with id {1}.", thing.ClassKind, thing.Iid));
                }

                thing.AddContainer(tmpContainer.ClassKind, tmpContainer.Iid);
            }
        }
    }
}