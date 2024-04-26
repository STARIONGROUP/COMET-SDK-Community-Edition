// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElement.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// representation of an explicit element of a system-of-interest in a fully expanded architectural decomposition tree for one Option
    /// Note 1: The hierarchy of NestedElements can be automatically generated from the implicit composite structure defined by ElementDefinitions and contained ElementUsages, and configured for an Option.
    /// Note 2: The unique path to a single, possibly deeply nested, NestedElement is defined by the <i>topElement</i> of the relevant Iteration (which is the same for all Options) and an ordered list of subtended ElementUsage references.
    /// Note 3: The NestedElement is an explicit representation of the so-called "deeply nested connector" concept in OMG SysML (v1.3).
    /// Example: Assume a spacecraft with a service module "sm" (an ElementUsage of ElementDefinition "SM") and two solar array wings with three panels each. The NestedElement representing panel 2 on wing 1 would be defined by the <i>topElement</i> ElementDefinition for the spacecraft (the "system-of-interest"), and a list of elementUsages referencing: the "sm" usage, the  "wing1" usage, the "panel2" usage, in that order.
    /// </summary>
    [Container(typeof(Option), "NestedElement")]
    public partial class NestedElement : Thing, INamedThing, IOwnedThing, IShortNamedThing, IVolatileThing
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
        /// Initializes a new instance of the <see cref="NestedElement"/> class.
        /// </summary>
        public NestedElement()
        {
            this.ElementUsage = new OrderedItemList<ElementUsage>(this);
            this.NestedParameter = new ContainerList<NestedParameter>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NestedElement"/> class.
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
        public NestedElement(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ElementUsage = new OrderedItemList<ElementUsage>(this);
            this.NestedParameter = new ContainerList<NestedParameter>(this);
        }

        /// <summary>
        /// Gets or sets a list of ordered ElementUsage.
        /// </summary>
        /// <remarks>
        /// unique path to a single NestedElement defined by an ordered list of references to ElementUsages
        /// Note: The first ElementUsage in the list must be a <i>containedElement</i> of the topElement of the relevant Iteration, the second ElementUsage must be a <i>containedElement</i> of the ElementDefinition pointed to by the <i>elementDefinition</i> of the first ElementUsage, and so on until the intended nested ElementUsage is reached.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<ElementUsage> ElementUsage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsVolatile.
        /// </summary>
        /// <remarks>
        /// Note: When an instance is marked volatile it will not be persisted in the persistent data store. This meant to allow for runtime-only use of such instances in a client application.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public bool IsVolatile { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// name derived from chain of the names of the <i>rootElement</i> and <i>elementUsage</i>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Name property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string Name
        {
            get { return this.GetDerivedName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property NestedElement.Name"); }
        }

        /// <summary>
        /// Gets or sets a list of contained NestedParameter.
        /// </summary>
        /// <remarks>
        /// ordered list of NestedParameters that defined the fully expanded parametric representation for this NestedElement for a combination of one Option and one DomainOfExpertise
        /// Note: NestedParameters are meant to be present only on generated NestedElements.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<NestedParameter> NestedParameter { get; protected set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to the owner DomainOfExpertise of this NestedElement
        /// Note: The owner DomainOfExpertise of this NestedElement is the same as the owner of the last ElementUsage in the <i>elementUsage</i> path.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public DomainOfExpertise Owner
        {
            get { return this.GetDerivedOwner(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property NestedElement.Owner"); }
        }

        /// <summary>
        /// Gets or sets the RootElement.
        /// </summary>
        /// <remarks>
        /// reference to the root ElementDefinition at which the path to this NestedElement starts
        /// Note: For an EngineeringModel that is an EngineeringModelKind.STUDY_MODEL this is typically the <i>topElement</i> of the selected Iteration. However the rootElement may be any ElementDefinition which allows for the generation of subtrees subtended from anywhere in the composite structure of a model, which is for example useful in EngineeringModels that are of the EngineeringModelKind.CATALOGUE kind.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ElementDefinition RootElement { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <remarks>
        /// short name derived from chain of the names of the <i>rootElement</i> and <i>elementUsage</i>
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The ShortName property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public string ShortName
        {
            get { return this.GetDerivedShortName(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property NestedElement.ShortName"); }
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="NestedElement"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.NestedParameter);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="NestedElement"/>
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

            foreach (var thing in this.ElementUsage.Select(x => x))
            {
                yield return thing;
            }

            if (this.RootElement != null)
            {
                yield return this.RootElement;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="NestedElement"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="NestedElement"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (NestedElement)this.MemberwiseClone();
            clone.ElementUsage = new OrderedItemList<ElementUsage>(this.ElementUsage, this);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.NestedParameter = cloneContainedThings ? new ContainerList<NestedParameter>(clone) : new ContainerList<NestedParameter>(this.NestedParameter, clone);

            if (cloneContainedThings)
            {
                clone.NestedParameter.AddRange(this.NestedParameter.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="NestedElement"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="NestedElement"/>.
        /// </returns>
        public new NestedElement Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (NestedElement)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="NestedElement"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            var elementUsageCount = this.ElementUsage.Count();
            if (elementUsageCount < 1)
            {
                errorList.Add("The number of elements in the property ElementUsage is wrong. It should be at least 1.");
            }

            if (this.RootElement == null || this.RootElement.Iid == Guid.Empty)
            {
                errorList.Add("The property RootElement is null.");
                this.RootElement = SentinelThingProvider.GetSentinel<ElementDefinition>();
                this.sentinelResetMap["RootElement"] = () => this.RootElement = null;
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="NestedElement"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.NestedElement;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current NestedElement POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.ElementUsage.ResolveList(dto.ElementUsage, dto.IterationContainerId, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.IsVolatile = dto.IsVolatile;
            this.ModifiedOn = dto.ModifiedOn;
            this.NestedParameter.ResolveList(dto.NestedParameter, dto.IterationContainerId, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.RootElement = this.Cache.Get<ElementDefinition>(dto.RootElement, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<ElementDefinition>();
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="NestedElement"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.NestedElement(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.ElementUsage.AddRange(this.ElementUsage.ToDtoOrderedItemList());
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.IsVolatile = this.IsVolatile;
            dto.ModifiedOn = this.ModifiedOn;
            dto.NestedParameter.AddRange(this.NestedParameter.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.RootElement = this.RootElement != null ? this.RootElement.Iid : Guid.Empty;
            dto.ThingPreference = this.ThingPreference;

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
