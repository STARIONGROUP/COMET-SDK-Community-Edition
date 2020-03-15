// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Thing.cs" company="RHEA System S.A.">
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

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using CDP4Common.Polyfills;
    using CDP4Common.Types;
    using CommonData;
    using Helpers;

    /// <summary>
    /// The Data Transfer Object representing the abstract <see cref="Thing"/> class.
    /// </summary>
    [DataContract]
    public abstract class Thing
    {
        /// <summary>
        /// a list of <see cref="ClassKind"/> representing the container that are added to compute the route
        /// </summary>
        private readonly List<ClassKind> partialClassKindRoute = new List<ClassKind>(); 

        /// <summary>
        /// Gets or sets the <see cref="CommonData.Thing"/> that the current DTO was created from.
        /// </summary>        
        private CommonData.Thing SourceThing { get; set; }

        /// <summary>
        /// a list of partial routes, the outermost part of the route is the first in the list
        /// </summary>
        internal readonly List<string> PartialRoutes = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Thing"/> class.
        /// </summary>
        protected Thing()
        {
            this.ClassKind = this.ComputeCurrentClassKind();

            this.ExcludedDomain = new List<Guid>();
            this.ExcludedPerson = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Thing"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected Thing(Guid iid, int rev)
        {
            this.Iid = iid;
            this.ClassKind = this.ComputeCurrentClassKind();
            this.RevisionNumber = rev;

            this.ExcludedDomain = new List<Guid>();
            this.ExcludedPerson = new List<Guid>();
        }

        /// <summary>
        /// Gets the assertion of the ClassKind of this Thing, denoting its actual class.
        /// Note: Typically this is used internally by the implementing software to improve classification of instances and optimise performance when moving data between different programming environments. In an object-oriented software engineering environment that supports reflection such information would be redundant.
        /// </summary>
        [DataMember]
        public readonly ClassKind ClassKind;

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced ExcludedDomain instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ExcludedDomain { get; set; }

        /// <summary>
        /// Gets or sets the list of unique identifiers of the referenced ExcludedPerson instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ExcludedPerson { get; set; }

        /// <summary>
        /// Gets or sets the Universally Unique Identifier (UUID) that uniquely identifies an instance of Thing
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false)]
        [DataMember]
        public Guid Iid { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedOn.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual DateTime ModifiedOn { get; set; }

        /// <summary>
        /// Gets or set the revision number of this Thing
        /// Note: In this data model a revision numbering approach similar to Subversion is used, see http://svnbook.red-bean.com/en/1.7/svn-book.html#svn.basic. Therefore the revision number is actually a change set number. At any time that an update to a Thing is made and committed to a persistent data store, the revisionNumber of its TopContainer is incremented by one, and then the revisionNumber of the updated Thing is set to the new TopContainer's revisionNumber. See also TopContainer. When a Thing is first created (in a client application) its revisionNumber is set to zero, implying it has not yet been persisted.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]        
        public int RevisionNumber { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Guid"/> of the <see cref="Iteration"/> container
        /// </summary>
        /// <remarks>
        /// This is null if this is not an iteration data
        /// </remarks>
        public Guid? IterationContainerId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ContainerLevelKind"/> that determines where in the containment tree
        /// the DTO is situated.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Thrown when the <see cref="ContainerLevelKind"/> is fixed and may not be updated.
        /// </exception>
        [XmlIgnore]
        public virtual ContainerLevelKind ContainerLevelKind
        {
            get { return ContainerLevelKind.Invalid; }
            set { throw new InvalidOperationException("The ContainerLevelKind may not be set."); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Thing"/>
        /// </summary>
        public virtual IEnumerable<IEnumerable> ContainerLists
        {
            get
            {
                var containers = new List<IEnumerable>();

                return containers;
            }
        }

        /// <summary>
        /// Queries the <see cref="CommonData.Thing"/> that was the source of the DTO
        /// </summary>        
        /// <returns>
        /// The <see cref="Thing"/> that is the source from which the DTO may have been created.
        /// </returns>
        /// <remarks>
        /// The return value may be null if the DTO was not created based on an existing POCO.
        /// </remarks>
        public CommonData.Thing QuerySourceThing()
        {
            return this.SourceThing;
        }

        /// <summary>
        /// Register the Source <see cref="CommonData.Thing"/> with the current DTO
        /// </summary>
        /// <param name="thing">
        /// The <see cref="CommonData.Thing"/> that is to be registered
        /// </param>
        internal void RegisterSourceThing(CommonData.Thing thing)
        {
            this.SourceThing = thing;
        }
        
        /// <summary>
        /// Gets the route for the current <see ref="Thing"/>
        /// </summary>
        public virtual string Route
        {
            get { throw new NotSupportedException("This object does not have a Route property associated with it."); }
        }

        /// <summary>
        /// Instantiate a <see cref="CommonData.Thing"/> from a <see cref="Thing"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/></param>
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CommonData.Thing"/></param>
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public abstract CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri);

        /// <summary>
        /// Check if the current <see cref="Thing"/> contains the <paramref name="thing"/>
        /// </summary>
        /// <param name="thing">The potential contained <see cref="Thing"/></param>
        /// <returns>True if the current <see cref="Thing"/> does contain the <paramref name="thing"/></returns>
        public bool Contains(Thing thing)
        {
            foreach (var containerList in this.ContainerLists)
            {
                foreach (var element in containerList)
                {
                    var orderedItem = element as OrderedItem;
                    if (orderedItem != null)
                    {
                        Guid guid;
                        var parseRes = Guid.TryParse(orderedItem.V.ToString(), out guid);
                        if (parseRes && guid == thing.Iid)
                        {
                            return true;
                        }

                        continue;
                    }

                    var id = (Guid)element;
                    if (thing.Iid == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Adds a container to the current <see cref="Thing"/>. The containers should be added following the containment
        /// hierarchy starting at the current <see cref="Thing"/>. The last addition shall be either a <see cref="EngineeringModel"/>
        /// or a <see cref="SiteDirectory"/>
        /// </summary>
        /// <param name="classKind">
        /// A <see cref="ClassKind"/> specifying the type of the container that is being added
        /// </param>
        /// <param name="iid">
        /// the unique id of the container that is being added
        /// </param>
        public virtual void AddContainer(ClassKind classKind, Guid iid)
        {
            var lastRouteClassKind = this.partialClassKindRoute.Any()
                ? this.partialClassKindRoute.Last()
                : this.ClassKind;

            switch (lastRouteClassKind)
            {
                case ClassKind.SiteDirectory:
                    throw new InvalidOperationException("Cannot add another container, SiteDirectory is a top container");
                case ClassKind.EngineeringModel:
                    throw new InvalidOperationException("Cannot add another container, EngineeringModel is a top container");
                default:
                    {
                        if (this.IsAuthorizedRoute(lastRouteClassKind, classKind))
                        {
                            var containerPropertyName = ContainerPropertyHelper.ContainerPropertyName(classKind);
                            var partialRoute = string.Format("{0}/{1}", containerPropertyName, iid);
                            this.PartialRoutes.Add(partialRoute);
                            this.partialClassKindRoute.Add(classKind);
                            break;
                        }

                        throw new InvalidOperationException(string.Format("the added container of classKind: {0} is not consistent with the existing route", classKind));
                    }
            }
        }
        
        /// <summary>
        /// Returns the computed route of the current <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// a string that represents the route
        /// </returns>
        protected string ComputedRoute()
        {
            var temporaryList = new List<string>(this.PartialRoutes);
            temporaryList.Reverse();
            var containerRoute = string.Join("/", temporaryList);

            var containerPropertyName = ContainerPropertyHelper.ContainerPropertyName(this.ClassKind);
            var partialRoute = string.Format("{0}/{1}", containerPropertyName, this.Iid);

            if (string.IsNullOrEmpty(containerRoute))
            {
                return "/" + partialRoute;
            }

            return string.Format("/{0}/{1}", containerRoute, partialRoute);
        }

        /// <summary>
        /// Computes the ClassKind of the current object based on it's type
        /// </summary>
        /// <returns>
        /// the <see cref="ClassKind"/> of the current object
        /// </returns>
        protected virtual ClassKind ComputeCurrentClassKind()
        {
            ClassKind classKind;
            var type = this.GetType();
            if (Enum.TryParse(type.Name, out classKind))
            {
                return classKind;
            }

            throw new InvalidOperationException(string.Format("The current Thing {0} does not have a corresponding ClassKind", type));
        }

        /// <summary>
        /// Assert that the new added container is consistent with the container previously added
        /// </summary>
        /// <param name="lastRoute">container previously added</param>
        /// <param name="newRoute">new container</param>
        /// <returns>true if the new route is consistent with the existing one</returns>
        private bool IsAuthorizedRoute(ClassKind lastRoute, ClassKind newRoute)
        {
            var lastRouteContainerClass = ContainerPropertyHelper.ContainerClassName(lastRoute);
            if (newRoute.ToString() == lastRouteContainerClass)
            {
                return true;
            }

            // the newRoute may not correspond to the container class because the container class is abstract.
            // Check if the parent of the added container is that abstract class
            var type = Type.GetType("CDP4Common.DTO." + newRoute);
            if (type != null)
            {
                var parent = type.QueryBaseType();
                while (parent != null)
                {
                    if (parent.Name == lastRouteContainerClass)
                    {
                        return true;
                    }

                    parent = parent.QueryBaseType();
                }
            }

            return false;
        }

        /// <summary>
        /// Retrieves the top container route
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> representing the route to the top container.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// If no valid route is determined this exception is thrown
        /// </exception>
        public string GetTopContainerRoute()
        {
            var temporaryList = new List<string>(this.PartialRoutes);
            temporaryList.Reverse();

            // if this is a top container simply return itself
            if (this is SiteDirectory || this is Iteration || this is EngineeringModel)
            {
                return this.ComputedRoute();
            }

            if (!this.PartialRoutes.Any())
            {
                throw new InvalidOperationException(string.Format("No valid top container found for DTO: {0}.", this.Iid));
            }

            if (temporaryList[0].Contains("SiteDirectory"))
            {
                return string.Format("/{0}", temporaryList[0]);
            }

            if (temporaryList[0].Contains("EngineeringModel"))
            {
                // make a distinction on Iteration and Engineering Model things
                if (temporaryList.Count == 1 || !temporaryList[1].Contains("iteration"))
                {
                    // a thing that is directly under an EngineeringModel
                    return string.Format("/{0}", temporaryList[0]);
                }

                return string.Format("/{0}", string.Join("/", temporaryList.GetRange(0, 2)));
            }

            throw new InvalidOperationException(string.Format("No valid top container found for DTO: {0}.", this.Iid));
        }

        /// <summary>
        /// Returns a deep clone of the current <see cref="Thing"/>
        /// </summary>
        /// <typeparam name="T">A type of <see cref="Thing"/></typeparam>
        /// <returns>A deep clone of the current <see cref="Thing"/></returns>
        public T DeepClone<T>() where T : Thing
        {
            // todo can be refactored to removed reflection
            if (!(this is T))
            {
                throw new InvalidOperationException("The type of the clone to create is invalid.");
            }

            var clone = this.MemberwiseClone();
            var type = clone.GetType();
            foreach (var propertyInfo in type.GetProperties())
            {
                if (!propertyInfo.IsAttributeDefined<DataMemberAttribute>())
                {
                    // only create a clone of the list that is part of the DataMember
                    continue;
                }

                object newValue;
                if (propertyInfo.PropertyType.QueryIsGenericType() && 
                        typeof(IEnumerable).QueryIsAssignableFrom(propertyInfo.PropertyType.GetGenericTypeDefinition()))
                {
                    var oldValue = propertyInfo.GetValue(this);
                    newValue = Activator.CreateInstance(propertyInfo.PropertyType, oldValue);
                }
                else
                {
                    continue;
                }

                propertyInfo.SetValue(clone, newValue);
            }

            return (T)clone;
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>
        /// <param name="originalCopyMap">The map containing all instance of copied <see cref="Thing"/>s with their original</param>
        public abstract void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap);

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map
        /// </summary>
        /// <param name="originalCopyMap">The map containing all instance of copied <see cref="Thing"/>s with their original</param>
        /// <returns>True if a modification was done in the process of this method</returns>
        public abstract bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap);
    }
}