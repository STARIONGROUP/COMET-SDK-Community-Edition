// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsage.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
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
    /// named usage of an ElementDefinition in the context of a next higher level ElementDefinition that contains this ElementUsage
    /// Note 1: An ElementUsage has one and only one ElementDefinition as its <i>containingElement</i>.
    /// Note 2: When an ElementDefinition is made a member of a Category through its <i>category</i> property, then also any ElementUsage typed by such an ElementDefinition is implied to be a member of the same Category.
    /// Note 3: A ParameterType "NumberOf" may be defined in an associated ReferenceDataLibrary. Subsequently a "NumberOf" Parameter or ParameterOverride may be added to an ElementUsage as a short-cut to define a number of containedElements that are not named individually. Setting "NumberOf" to a value greater than one is typically only done in early conceptual design. In a later detailed design phase each usage would normally be instantiated individually, so that where needed different usage level Parameters can have different values.
    /// Note 4: Both the <i>owner</i> DomainOfExpertise of the <i>containingElement</i> and of the <i>elementDefinition</i> are owner(s) of this ElementUsage, i.e. the union of self.containingElement.owner and self.elementDefinition.owner.
    /// </summary>
    [Container(typeof(ElementDefinition), "ContainedElement")]
    public sealed partial class ElementUsage : ElementBase, IOptionDependentThing
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NONE;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUsage"/> class.
        /// </summary>
        public ElementUsage()
        {
            this.ExcludeOption = new List<Option>();
            this.ParameterOverride = new ContainerList<ParameterOverride>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ElementUsage"/> class.
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
        public ElementUsage(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ExcludeOption = new List<Option>();
            this.ParameterOverride = new ContainerList<ParameterOverride>(this);
        }

        /// <summary>
        /// Gets or sets the ElementDefinition.
        /// </summary>
        /// <remarks>
        /// reference to the ElementDefinition that defines this ElementUsage
        /// Note: The <i>elementDefinition</i> of an ElementUsage could also be regarded as the <i>type</i> of the ElementUsage.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ElementDefinition ElementDefinition { get; set; }

        /// <summary>
        /// Gets or sets a list of Option.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Options from which this OptionDependentThing is excluded
        /// Note: By default all OptionDependentThings are included in all Options in an EngineeringModel. Only the exclusions are recorded in the data model because this is the most efficient way of storing and handling the option dependency. In client applications it may be more intuitive to show the included Options, but that is a simple transformation.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public List<Option> ExcludeOption { get; set; }

        /// <summary>
        /// Gets or sets the InterfaceEnd.
        /// </summary>
        /// <remarks>
        /// indication whether this ElementUsage is a (potential) interface end
        /// Note 1: An interface end is one side of an interface, where the complete
        /// interface is defined as the connection plus two or more interface ends.
        /// Note 2: Interface definition is currently not explicitly modelled in
        /// this data model. However it is possible to define a Category e.g. named
        /// "InterfaceDefinitions", and then instantiate ElementDefinitions and
        /// ElementUsages that belong to this category for the interfaces to be
        /// defined, using the referencedElement property of ElementUsage to connect
        /// architectural elements that represent interface ends.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public InterfaceEndKind InterfaceEnd { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ParameterOverride.
        /// </summary>
        /// <remarks>
        /// representation of zero or more ParameterOverrides to hold overridden values for a Parameter at this ElementUsage level
        /// Note: The <i>parameter</i> of this ParameterOverride must be a Parameter of the <i>elementDefinition</i> of the containing ElementUsage.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ParameterOverride> ParameterOverride { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ElementUsage"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ParameterOverride);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="ElementUsage"/>
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

            if (this.ElementDefinition != null)
            {
                yield return this.ElementDefinition;
            }

            foreach (var thing in this.ExcludeOption)
            {
                yield return thing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ElementUsage"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ElementUsage"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (ElementUsage)this.MemberwiseClone();
            clone.Alias = cloneContainedThings ? new ContainerList<Alias>(clone) : new ContainerList<Alias>(this.Alias, clone);
            clone.Attachment = cloneContainedThings ? new ContainerList<Attachment>(clone) : new ContainerList<Attachment>(this.Attachment, clone);
            clone.Category = new List<Category>(this.Category);
            clone.Definition = cloneContainedThings ? new ContainerList<Definition>(clone) : new ContainerList<Definition>(this.Definition, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ExcludeOption = new List<Option>(this.ExcludeOption);
            clone.HyperLink = cloneContainedThings ? new ContainerList<HyperLink>(clone) : new ContainerList<HyperLink>(this.HyperLink, clone);
            clone.ParameterOverride = cloneContainedThings ? new ContainerList<ParameterOverride>(clone) : new ContainerList<ParameterOverride>(this.ParameterOverride, clone);

            if (cloneContainedThings)
            {
                clone.Alias.AddRange(this.Alias.Select(x => x.Clone(true)));
                clone.Attachment.AddRange(this.Attachment.Select(x => x.Clone(true)));
                clone.Definition.AddRange(this.Definition.Select(x => x.Clone(true)));
                clone.HyperLink.AddRange(this.HyperLink.Select(x => x.Clone(true)));
                clone.ParameterOverride.AddRange(this.ParameterOverride.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="ElementUsage"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="ElementUsage"/>.
        /// </returns>
        public new ElementUsage Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (ElementUsage)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="ElementUsage"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.ElementDefinition == null || this.ElementDefinition.Iid == Guid.Empty)
            {
                errorList.Add("The property ElementDefinition is null.");
                this.ElementDefinition = SentinelThingProvider.GetSentinel<ElementDefinition>();
                this.sentinelResetMap["ElementDefinition"] = () => this.ElementDefinition = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="ElementUsage"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.ElementUsage;
            if (dto == null)
            {
                throw new InvalidOperationException(string.Format("The DTO type {0} does not match the type of the current ElementUsage POCO.", dtoThing.GetType()));
            }

            this.Alias.ResolveList(dto.Alias, dto.IterationContainerId, this.Cache);
            this.Attachment.ResolveList(dto.Attachment, dto.IterationContainerId, this.Cache);
            this.Category.ResolveList(dto.Category, dto.IterationContainerId, this.Cache);
            this.Definition.ResolveList(dto.Definition, dto.IterationContainerId, this.Cache);
            this.ElementDefinition = this.Cache.Get<ElementDefinition>(dto.ElementDefinition, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ElementDefinition>();
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.ExcludeOption.ResolveList(dto.ExcludeOption, dto.IterationContainerId, this.Cache);
            this.HyperLink.ResolveList(dto.HyperLink, dto.IterationContainerId, this.Cache);
            this.InterfaceEnd = dto.InterfaceEnd;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.Owner = this.Cache.Get<DomainOfExpertise>(dto.Owner, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<DomainOfExpertise>();
            this.ParameterOverride.ResolveList(dto.ParameterOverride, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.ShortName = dto.ShortName;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="ElementUsage"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.ElementUsage(this.Iid, this.RevisionNumber);

            dto.Alias.AddRange(this.Alias.Select(x => x.Iid));
            dto.Attachment.AddRange(this.Attachment.Select(x => x.Iid));
            dto.Category.AddRange(this.Category.Select(x => x.Iid));
            dto.Definition.AddRange(this.Definition.Select(x => x.Iid));
            dto.ElementDefinition = this.ElementDefinition != null ? this.ElementDefinition.Iid : Guid.Empty;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ExcludeOption.AddRange(this.ExcludeOption.Select(x => x.Iid));
            dto.HyperLink.AddRange(this.HyperLink.Select(x => x.Iid));
            dto.InterfaceEnd = this.InterfaceEnd;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.Owner = this.Owner != null ? this.Owner.Iid : Guid.Empty;
            dto.ParameterOverride.AddRange(this.ParameterOverride.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.ShortName = this.ShortName;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}
