// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Category.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Authors: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov, Smiechowski Nathanael
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
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of a user-defined category for categorization of instances that have common characteristics
    /// Note 1: The Category concept provides a user-defined, runtime classification mechanism in addition to the UML classification (classifier, class, generalization, specialization) applied in the data model itself.
    /// Note 2: The Category concept provides additional flexibility to assist in the definition and usage of views and filters on the instances in a population of the data model.
    /// </summary>
    [Container(typeof(ReferenceDataLibrary), "DefinedCategory")]
    public sealed partial class Category : DefinedThing, IDeprecatableThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            this.PermissibleClass = new List<ClassKind>();
            this.SuperCategory = new List<Category>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="CacheKey"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public Category(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.PermissibleClass = new List<ClassKind>();
            this.SuperCategory = new List<Category>();
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsAbstract.
        /// </summary>
        /// <remarks>
        /// assertion that this Category is abstract, i.e. it may not have direct
        /// members, but only not abstract sub categories of this Category may have
        /// members
        /// Note: The isAbstract property has similar semantics as the isAbstract property
        /// of classifiers in the UML meta-model.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsAbstract { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        /// <remarks>
        /// assertion whether a DeprecatableThing is deprecated or not
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets or sets a list of ClassKind.
        /// </summary>
        /// <remarks>
        /// one or more names of classes of which instances are permitted to be a
        /// member of this Category
        /// Note 1: This specifies a validation rule for a population of the data
        /// model.
        /// Note 2: By definition any class name specified in <i>permissibleClass</i>
        /// shall be the name of a subclass of CategorizableThing.
        /// Note 3: In order to execute the validation rule it is required that an
        /// implementation can verify at runtime that an instance is of a given
        /// class as specified by a character string name.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<ClassKind> PermissibleClass { get; set; }

        /// <summary>
        /// Gets or sets a list of Category.
        /// </summary>
        /// <remarks>
        /// reference to zero or more super categories of this Category
        /// Note 1: In other words by adding a Category to <i>superCategory</i> this referring Category is defined as a <i>subCategory</i>. This implies that all CategorizableThings that are a member of the <i>subCategory</i> constitute a subset of all CategorizableThings that are a member of the superCategory.
        /// Note 2: The super/sub-category hierarchy shall form an acyclic graph, i.e. no circular references are permitted.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Category> SuperCategory { get; set; }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Category"/>
        /// </summary>
        /// <remarks>
        /// This does not include the contained <see cref="Thing"/>s, the contained <see cref="Thing"/>s
        /// are exposed via the <see cref="ContainerLists"/> property
        /// </remarks>
        /// <returns>
        /// An <see cref="IEnumerable{Thing}"/>
        /// </returns>
        public override IEnumerable<Thing> QueryReferencedThings()
        {
            foreach (var thing in base.QueryReferencedThings())
            {
                yield return thing;
            }

            foreach (var thing in this.SuperCategory)
            {
                yield return thing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Category"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Category"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Category)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.PermissibleClass = new List<ClassKind>(this.PermissibleClass);
            clone.SuperCategory = new List<Category>(this.SuperCategory);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Category"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Category"/>.
        /// </returns>
        public new Category Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Category)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Category"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var permissibleClassCount = this.PermissibleClass.Count();
            if (permissibleClassCount < 1)
            {
                errorList.Add("The number of elements in the property PermissibleClass is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="Category"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Category;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current Category POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.IsAbstract = dto.IsAbstract;
            this.IsDeprecated = dto.IsDeprecated;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.PermissibleClass.ClearAndAddRange(dto.PermissibleClass);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.SuperCategory.ResolveList(dto.SuperCategory, dto.IterationContainerId, this.Cache);
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Category"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Category(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.IsAbstract = this.IsAbstract;
            dto.IsDeprecated = this.IsDeprecated;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.PermissibleClass.AddRange(this.PermissibleClass);
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.SuperCategory.AddRange(this.SuperCategory.Select(x => x.Iid));
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
