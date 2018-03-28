#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Thing.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4Common.CommonData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.Polyfills;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using NLog;

    /// <summary>
    /// top level abstract superclass from which all domain concept classes in the model inherit
    /// </summary>
    public abstract partial class Thing : IDisposable
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Backing field for <see cref="CacheId"/> property.
        /// </summary>
        private Tuple<Guid, Guid?> cacheId;

        /// <summary>
        /// a value indicating whether the instance is disposed
        /// </summary>
        private bool isDisposed;

        /// <summary>
        /// The <see cref="List{T}"/> of validation error messages
        /// </summary>
        private readonly List<string> validationErrorList = new List<string>();

        /// <summary>
        /// The NLog logger
        /// </summary>
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// The <see cref="Dictionary{string, Action}"/> that contains reset method for properties that were replaced by sentinels
        /// </summary>
        protected Dictionary<string, Action> sentinelResetMap = new Dictionary<string, Action>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Thing"/> class.
        /// </summary>
        protected Thing()
        {
            this.ClassKind = this.ComputeCurrentClassKind();
            this.ExcludedDomain = new List<DomainOfExpertise>();
            this.ExcludedPerson = new List<Person>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Thing"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{TKey,TValue}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        protected Thing(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri)
        {
            this.Iid = iid;
            this.IDalUri = iDalUri;
            this.Cache = cache;
            this.ClassKind = this.ComputeCurrentClassKind();
            this.ClassKind = this.ComputeCurrentClassKind();
            this.ExcludedDomain = new List<DomainOfExpertise>();
            this.ExcludedPerson = new List<Person>();
        }
        
        /// <summary>
        /// assertion of the ClassKind of this Thing, denoting its actual class
        /// Note: Typically this is used internally by the implementing software to improve classification of instances and optimise performance when moving data between different programming environments. In an object-oriented software engineering environment that supports reflection such information would be redundant.
        /// </summary>
        [Browsable(true)]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public ClassKind ClassKind { get; internal set; }

        /// <summary>
        /// Gets or sets a list of DomainOfExpertise.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<DomainOfExpertise> ExcludedDomain { get; set; }
        
        /// <summary>
        /// Gets or sets a list of Person.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Person> ExcludedPerson { get; set; }

        /// <summary>
        /// Gets or sets the Universally Unique Identifier (UUID) that uniquely identifies an instance of Thing
        /// </summary>
        [Browsable(true)]
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
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
        /// revision number of this Thing
        /// Note: In this data model a revision numbering approach similar to Subversion is used, see <a href="http://svnbook.red-bean.com/en/1.7/svn-book.html#svn.basic">http://svnbook.red-bean.com/en/1.7/svn-book.html#svn.basic</a>. Therefore the revision number is actually a change set number. At any time that an update to a Thing is made and committed to a persistent data store, the <i>revisionNumber</i> of its TopContainer is incremented by one, and then the <i>revisionNumber</i> of the updated Thing is set to the new TopContainer's <i>revisionNumber</i>. See also TopContainer. When a Thing is first created (in a client application) its <i>revisionNumber</i> is set to zero, implying it has not yet been persisted.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public int RevisionNumber { get; internal set; }

        /// <summary>
        /// The data-source's <see cref="Uri"/> this <see cref="Thing"/> comes from
        /// </summary>
        [Browsable(true)]
        public Uri IDalUri { get; internal set; }

        /// <summary>
        /// Gets the Cache that contains the current <see cref="Thing"/>
        /// </summary>
        public ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> Cache { get; set; }

        /// <summary>
        /// Gets or sets the Container of the current Thing
        /// </summary>
        public Thing Container { get; set; }

        /// <summary>
        /// Gets the original <see cref="Thing"/> form which the current <see cref="Thing"/> has been cloned.
        /// </summary>
        /// <remarks>
        /// If the <see cref="Thing"/> is not a clone, this property returns null
        /// </remarks>
        public Thing Original { get; protected set; }

        /// <summary>
        /// Gets the user-friendly name for this <see cref="Thing"/>
        /// </summary>
        public virtual string UserFriendlyName
        {
            get { return "User-friendly name not implemented."; }
        }

        /// <summary>
        /// Gets the user-friendly short-name for this <see cref="Thing"/>
        /// </summary>
        public virtual string UserFriendlyShortName
        {
            get { return "User-friendly short-name not implemented."; }
        }

        /// <summary>
        /// Gets the key with which the current <see cref="Thing"/> is stored in the cache
        /// </summary>
        public Tuple<Guid, Guid?> CacheId
        {
            get
            {
                if (this.cacheId != null)
                {
                    return this.cacheId;
                }

                var iterationContainer = this.GetContainerOfType<Iteration>();
                Guid? iterationId = null;
                if (iterationContainer != null && this.ClassKind != ClassKind.Iteration)
                {
                    iterationId = iterationContainer.Iid;
                }

                this.cacheId = new Tuple<Guid, Guid?>(this.Iid, iterationId);
                return this.cacheId;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Thing"/> has sentinel instances
        /// </summary>
        public bool HasSentinelInstances
        {
            get { return this.sentinelResetMap.Count > 0; }
        }

        /// <summary>
        /// Gets the Route the current <see cref="Thing"/>.
        /// </summary>
        /// <remarks>
        /// The route is determined using the containment tree of the current <see cref="Thing"/>
        /// </remarks>
        /// <exception cref="ContainmentException">
        /// A <see cref="ContainmentException"/> is raised when the containment tree is broken due to the fact that
        /// the Container has not been set on one of the <see cref="Thing"/> classes in the containment tree.
        /// </exception>
        public string Route
        {
            get
            {
                var currentType = this.GetType();
                var typeName = currentType.Name;
                
                if (this is TopContainer)
                {
                    if (typeName == "SiteDirectory" && this.Iid == Guid.Empty)
                    {
                        return "/SiteDirectory/*";
                    }

                    return string.Format("/{0}/{1}", typeName, this.Iid);
                }

                if (this is NotThing)
                {
                    return "no thing, no route";
                }
                 
                var container = this.Container;

                if (container == null)
                {
                    throw new ContainmentException(string.Format("The container of {0} with iid {1} is null, the route cannot be computed.", typeName, this.Iid));
                }

                string containerPropertyName;
                var containerPropertyNameAttribute = (ContainerAttribute)currentType.QueryGetCustomAttribute<ContainerAttribute>();
                if (containerPropertyNameAttribute != null)
                {
                    containerPropertyName = char.ToLowerInvariant(containerPropertyNameAttribute.PropertyName[0]) + containerPropertyNameAttribute.PropertyName.Substring(1);
                }
                else
                {
                    containerPropertyName = char.ToLowerInvariant(typeName[0]) + typeName.Substring(1);
                }

                var containerRoute = container.Route;

                var route = string.Format("{0}/{1}/{2}", containerRoute, containerPropertyName, this.Iid);
                return route;                
            }
        }

        /// <summary>
        /// Queries all the contained <see cref="Thing"/>s of the current <see cref="Thing"/> along the
        /// complete containment hierarchy and returns them as a flat list. The current <see cref="Thing"/>
        /// is included as well
        /// </summary>
        /// <returns>
        /// An <see cref="IEnumerable{Thing}"/> 
        /// </returns>
        public IEnumerable<Thing> QueryContainedThingsDeep()
        {
            var temp = new List<Thing> { this };

            foreach (var containerList in this.ContainerLists)
            {
                foreach (Thing thing in containerList)
                {
                    var containedThings = thing.QueryContainedThingsDeep();
                    temp.AddRange(containedThings);
                }
            }

            return temp;
        }

        /// <summary>
        /// Gets or sets the Change status of this <see cref="Thing"/>.
        /// </summary>
        [Browsable(false)]
        public ChangeKind ChangeKind { get; set; }

        /// <summary>
        /// Gets the <see cref="TopContainer"/> of the current <see cref="Thing"/>
        /// </summary>
        /// <remarks>
        /// if the current <see cref="Thing"/> is a top-container, the <see cref="Thing"/> itself will be returned
        /// </remarks>
        public TopContainer TopContainer
        {
            get
            {
                if (this is NotThing)
                {
                    return null;
                }

                var topcontainer = this as TopContainer;
                if (topcontainer != null)
                {
                    return topcontainer;
                }

                var container = this.Container;
                if (container == null)
                {
                    var typeName = this.GetType().Name;
                    throw new ContainmentException(string.Format("The container of {0} with iid {1} is null, the TopContainer cannot be computed.", typeName, this.Iid));
                }

                if (container is TopContainer)
                {
                    return (TopContainer)container;
                }
                
                return container.TopContainer;
            }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{ReferenceDataLibrary}"/> that contains the required <see cref="ReferenceDataLibrary"/> for the current <see cref="Thing"/>
        /// </summary>
        public virtual IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get { return new HashSet<ReferenceDataLibrary>();  }
        } 

        /// <summary>
        /// Gets a <see cref="IEnumerable{T}"/> listing all the potential errors on this <see cref="Thing"/>
        /// </summary>
        public IEnumerable<string> ValidationErrors
        {
            get { return this.validationErrorList; }
        } 

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Thing"/> for edit purpose
        /// </summary>
        /// <param name="cloneContainedThings">Indicates whether the contained <see cref="Thing"/> should be cloned or not</param>
        /// <returns>
        /// A cloned instance of <see cref="Thing"/>
        /// </returns>
        public Thing Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Resolve extra properties that are not part of the data-model
        /// </summary>
        /// <remarks>
        /// This is called during the properties resolve operation of this <see cref="Thing"/>
        /// </remarks>
        protected virtual void ResolveExtraProperties()
        {
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// a value indicating whether the class is being disposed of
        /// </param>        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.isDisposed)
            {
                if (disposing)
                {
                    // Clear all property values that maybe have been set
                    // when the class was instantiated
                    this.Cache = null;
                }

                // Indicate that the instance has been disposed.
                this.isDisposed = true;
            }
        }

        /// <summary>
        /// Generate a clone of this <see cref="Thing"/> for edit purpose
        /// </summary>
        /// <param name="cloneContainedThings">Indicates whether the contained <see cref="Thing"/> should be cloned or not</param>
        /// <returns>A clone of this <see cref="Thing"/></returns>
        protected abstract Thing GenericClone(bool cloneContainedThings);

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Thing"/>
        /// </summary>
        public abstract DTO.Thing ToDto();

        /// <summary>
        /// Reset the cache Id
        /// </summary>
        protected void ResetCacheId()
        {
            this.cacheId = null;
        }

        /// <summary>
        /// Computes the ClassKind of the current object based on it's type
        /// </summary>
        /// <returns>
        /// the <see cref="ClassKind"/> of the current object
        /// </returns>
        private ClassKind ComputeCurrentClassKind()
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
        /// Resolve the properties of the current <see cref="Thing"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dto">The source <see cref="DTO.Thing"/></param>
        internal abstract void ResolveProperties(DTO.Thing dto);

        /// <summary>
        /// Reset all properties that use a sentinel and clear the dictionary
        /// </summary>
        internal void ResetSentinel()
        {
            foreach (var action in this.sentinelResetMap.Values)
            {
                action();
            }

            this.sentinelResetMap.Clear();
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> thats references the composite properties of the current <see cref="Thing"/>
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
        /// Returns true if the current object is within the containment tree of the specified container <see cref="Thing"/>.
        /// </summary>
        /// <param name="container">The <see cref="Thing"/> reference that you want to </param>
        /// <returns>True if this thing is contained within the container. False if not.</returns>
        public bool IsContainedBy(Thing container)
        {
            // if the specified container is null throw execption
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            // If this thing is not contained i.e. top container, return false immediately
            if (this.Container == null)
            {
                return false;
            }

            if (this.Container == container)
            {
                return true;
            }

            return this.Container.IsContainedBy(container);
        }

        /// <summary>
        /// Returns true if the current object is within the containment tree of the specified <see cref="Predicate{T}"/>.
        /// </summary>
        /// <param name="matchPredicate">The <see cref="Predicate{T}"/></param>
        /// <returns>True if this thing is contained by a Thing that matches the predicate. False if not.</returns>
        public bool IsContainedBy(Predicate<Thing> matchPredicate)
        {
            if (matchPredicate == null)
            {
                throw new ArgumentNullException("matchPredicate");
            }

            if (this is TopContainer)
            {
                return false;
            }

            return matchPredicate(this.Container) || this.Container.IsContainedBy(matchPredicate);
        }

        /// <summary>
        /// Returns true if the current object is within the containment tree of the specified <see cref="Guid"/> of a <see cref="Thing"/>.
        /// </summary>
        /// <param name="iid">The <see cref="Guid"/></param>
        /// <returns>True if this thing is contained by a Thing with the given identifier. False if not.</returns>
        public bool IsContainedBy(Guid iid)
        {
            if (iid == null || iid == Guid.Empty)
            {
                throw new ArgumentNullException("iid");
            }

            if (this is TopContainer)
            {
                return false;
            }

            return this.Container.Iid == iid || this.Container.IsContainedBy(iid);
        }

        /// <summary>
        /// Returns the containing <see cref="Thing"/> of the specified type. If this <see cref="Thing"/> is not contained by a <see cref="Thing"/> of the specified type a null is returned.
        /// </summary>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/> the expected container has.
        /// </typeparam>
        /// <returns>
        /// The containing <see cref="Thing"/> or null if no such exists.
        /// </returns>
        public T GetContainerOfType<T>() where T : Thing
        {
            if (this.Container == null)
            {
                return null;
            }

            if (this.Container is T TContainer)
            {
                return TContainer;
            }

            return this.Container.GetContainerOfType<T>();
        }

        /// <summary>
        /// Returns the containing <see cref="Thing"/> of the specified type. If this <see cref="Thing"/> is not contained by a <see cref="Thing"/> of the specified type a null is returned.
        /// </summary>
        /// <param name="type">The type of <see cref="Thing"/> the expected container has.</param>
        /// <returns>
        /// The containing <see cref="Thing"/> or null if no such exists.
        /// </returns>
        public Thing GetContainerOfType(Type type)
        {
            if (this.Container == null)
            {
                return null;
            }

            var containerType = this.GetContainerInformation().Item1;
            if (!containerType.QueryIsAssignableFrom(type))
            {
                return this.Container.GetContainerOfType(type);
            }

            return containerType.IsInstanceOfType(this.Container) ? this.Container : null;
        }

        /// <summary>
        /// Gets the container information for the current <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// The (Type, property name) of the container of this <see cref="Thing"/>
        /// </returns>
        public Tuple<Type, string> GetContainerInformation()
        {
            var type = this.GetType();           
            if (!type.QueryIsAttributeDefined<ContainerAttribute>())
            {
                return new Tuple<Type, string>(null, string.Empty);
            }

            var metadata = (ContainerAttribute)type.QueryGetCustomAttribute<ContainerAttribute>();
            return new Tuple<Type, string>(metadata.ClassType, metadata.PropertyName);
        }

        /// <summary>
        /// Add all the validation error messages to be returned
        /// </summary>
        public void ValidatePoco()
        {
            this.validationErrorList.Clear();
            this.validationErrorList.AddRange(this.ValidatePocoCardinality());
            this.validationErrorList.AddRange(this.ValidatePocoProperties());
        }

        /// <summary>
        /// Check the cardinalities of the properties of this <see cref="Thing"/>
        /// </summary>
        /// <returns>
        /// A list of potential error
        /// </returns>
        protected virtual IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>();
            if (this.Iid == Guid.Empty)
            {
                errorList.Add("The Id for this thing is null.");
            }

            return errorList;
        }

        /// <summary>
        /// Validate this <see cref="Thing"/> with custom rules
        /// </summary>
        /// <returns>A list of error messages</returns>
        protected virtual IEnumerable<string> ValidatePocoProperties()
        {
            var errorList = new List<string>();
            if (this.Iid == Guid.Empty)
            {
                errorList.Add("The Id for this thing is null.");
            }

            return errorList;
        }

        /// <summary>
        /// Asserts whether a <see cref="Thing"/> or a copy is stored in any cache
        /// </summary>
        /// <returns>true if the <see cref="Thing"/> is cached</returns>
        /// <remarks>
        /// The assertion is made using the <see cref="Guid"/> of the <see cref="Thing"/>
        /// </remarks>
        public bool IsCached()
        {
            if (this.Cache == null || this.Iid == Guid.Empty)
            {
                return false;
            }

            return this.Cache.ContainsKey(this.CacheId);
        }
        
        /// <summary>
        /// Populate the partialRoutes in the DTOs
        /// </summary>
        /// <param name="dto">the DTO to populate</param>
        protected void BuildDtoPartialRoutes(DTO.Thing dto)
        {
            var partialRoutes = this.Route.Split('/');

            // the last partial route doesnt need to be added directly as the Dto's route computes it directly
            for (var i = partialRoutes.Count() - 4; i >= 0; i -= 2)
            {
                // partialRoute = <container property>/<guid>
                var partialRoute = partialRoutes[i] + "/" + partialRoutes[i + 1];
                dto.PartialRoutes.Add(partialRoute);
            }
        }
    }
}