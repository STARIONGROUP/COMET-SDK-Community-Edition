// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iteration.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
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
    /// representation of an Iteration of an EngineeringModel
    /// Note 1: An iteration is a version of the EngineeringModel that was considered as one complete and coherent step in the development of the EngineeringModel in a concurrent engineering activity. The detailed definition and understanding of the meaning of a "complete and coherent" step depends on the organization and activity that develops the EngineeringModel.
    /// Note 2: In a concurrent engineering activity the engineering model for the system-of-interest is developed in a number of iterations, where in each iteration the problem specification in the form of the RequirementsSpecification and a design solution in the form of the Options and ElementDefinitions are elaborated and refined. With an iteration the engineering team strives to set one more step in the direction of achieving a converged definition that fulfills the objectives of their activity.
    /// </summary>
    [Container(typeof(EngineeringModel), "Iteration")]
    public partial class Iteration : Thing
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
        /// Initializes a new instance of the <see cref="Iteration"/> class.
        /// </summary>
        public Iteration()
        {
            this.ActualFiniteStateList = new ContainerList<ActualFiniteStateList>(this);
            this.DiagramCanvas = new ContainerList<DiagramCanvas>(this);
            this.DomainFileStore = new ContainerList<DomainFileStore>(this);
            this.Element = new ContainerList<ElementDefinition>(this);
            this.ExternalIdentifierMap = new ContainerList<ExternalIdentifierMap>(this);
            this.Goal = new ContainerList<Goal>(this);
            this.Option = new OrderedItemList<Option>(this, true);
            this.PossibleFiniteStateList = new ContainerList<PossibleFiniteStateList>(this);
            this.Publication = new ContainerList<Publication>(this);
            this.Relationship = new ContainerList<Relationship>(this);
            this.RequirementsSpecification = new ContainerList<RequirementsSpecification>(this);
            this.RuleVerificationList = new ContainerList<RuleVerificationList>(this);
            this.SharedDiagramStyle = new ContainerList<SharedStyle>(this);
            this.Stakeholder = new ContainerList<Stakeholder>(this);
            this.StakeholderValue = new ContainerList<StakeholderValue>(this);
            this.StakeholderValueMap = new ContainerList<StakeHolderValueMap>(this);
            this.ValueGroup = new ContainerList<ValueGroup>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Iteration"/> class.
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
        public Iteration(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.ActualFiniteStateList = new ContainerList<ActualFiniteStateList>(this);
            this.DiagramCanvas = new ContainerList<DiagramCanvas>(this);
            this.DomainFileStore = new ContainerList<DomainFileStore>(this);
            this.Element = new ContainerList<ElementDefinition>(this);
            this.ExternalIdentifierMap = new ContainerList<ExternalIdentifierMap>(this);
            this.Goal = new ContainerList<Goal>(this);
            this.Option = new OrderedItemList<Option>(this, true);
            this.PossibleFiniteStateList = new ContainerList<PossibleFiniteStateList>(this);
            this.Publication = new ContainerList<Publication>(this);
            this.Relationship = new ContainerList<Relationship>(this);
            this.RequirementsSpecification = new ContainerList<RequirementsSpecification>(this);
            this.RuleVerificationList = new ContainerList<RuleVerificationList>(this);
            this.SharedDiagramStyle = new ContainerList<SharedStyle>(this);
            this.Stakeholder = new ContainerList<Stakeholder>(this);
            this.StakeholderValue = new ContainerList<StakeholderValue>(this);
            this.StakeholderValueMap = new ContainerList<StakeHolderValueMap>(this);
            this.ValueGroup = new ContainerList<ValueGroup>(this);
        }

        /// <summary>
        /// Gets or sets a list of contained ActualFiniteStateList.
        /// </summary>
        /// <remarks>
        /// collection of ActualFiniteStateLists defined for this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ActualFiniteStateList> ActualFiniteStateList { get; protected set; }

        /// <summary>
        /// Gets or sets the DefaultOption.
        /// </summary>
        /// <remarks>
        /// reference to the Option that is considered the default Option for this Iteration
        /// Note: The referenced default Option must be one of the Options defined in the <i>option</i> property of the Iteration.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public Option DefaultOption { get; set; }

        /// <summary>
        /// Gets or sets a list of contained DiagramCanvas.
        /// </summary>
        /// <remarks>
        /// The diagrams created in the scope of the current iteration
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<DiagramCanvas> DiagramCanvas { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained DomainFileStore.
        /// </summary>
        /// <remarks>
        /// collection of DomainFileStores in this Iteration
        /// Note: Typically there will be one DomainFileStore for each DomainOfExpertise in a particular EngineeringModel, plus one additional CommonFileStore shared by all domains.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<DomainFileStore> DomainFileStore { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ElementDefinition.
        /// </summary>
        /// <remarks>
        /// representation of all ElementDefinitions that represent the system-of-interest for this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ElementDefinition> Element { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ExternalIdentifierMap.
        /// </summary>
        /// <remarks>
        /// collection of ExternalIdentifierMaps defined in this EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ExternalIdentifierMap> ExternalIdentifierMap { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Goal.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Goal> Goal { get; protected set; }

        /// <summary>
        /// Gets or sets the IterationSetup.
        /// </summary>
        /// <remarks>
        /// reference to the IterationSetup that contains descriptive information about this Iteration at SiteDirectory level
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public IterationSetup IterationSetup { get; set; }

        /// <summary>
        /// Gets or sets a list of ordered contained Option.
        /// </summary>
        /// <remarks>
        /// collection of Options defined in this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<Option> Option { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained PossibleFiniteStateList.
        /// </summary>
        /// <remarks>
        /// collection of PossibleFiniteStateLists defined for this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<PossibleFiniteStateList> PossibleFiniteStateList { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Publication.
        /// </summary>
        /// <remarks>
        /// collection of Publications that are part of this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Publication> Publication { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Relationship.
        /// </summary>
        /// <remarks>
        /// collection of Relationships defined in this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Relationship> Relationship { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained RequirementsSpecification.
        /// </summary>
        /// <remarks>
        /// collection of RequirementsSpecifications defined in this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<RequirementsSpecification> RequirementsSpecification { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained RuleVerificationList.
        /// </summary>
        /// <remarks>
        /// collection of RuleVerificationLists defined for this Iteration of an EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<RuleVerificationList> RuleVerificationList { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained SharedStyle.
        /// </summary>
        /// <remarks>
        /// The shared styles to be applied on diagram elements
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<SharedStyle> SharedDiagramStyle { get; protected set; }

        /// <summary>
        /// Gets or sets the SourceIterationIid.
        /// </summary>
        /// <remarks>
        /// definition of the unique instance identifier of Iteration that was used as the source to create this Iteration
        /// Note: This property records the provenance of the Iteration. Except for the first Iteration of an EngineeeringModel any subsequent Iteration is created as a copy of a source Iteration. For the first Iteration the <i>sourceIterationIid</i> is set to <i>null</i>, which means there was no source.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public Guid? SourceIterationIid { get; set; }

        /// <summary>
        /// Gets or sets a list of contained Stakeholder.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Stakeholder> Stakeholder { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained StakeholderValue.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<StakeholderValue> StakeholderValue { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained StakeHolderValueMap.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<StakeHolderValueMap> StakeholderValueMap { get; protected set; }

        /// <summary>
        /// Gets or sets the TopElement.
        /// </summary>
        /// <remarks>
        /// reference to the ElementDefinition that represents the top node of the decomposition of the system-of-interest for this Iteration of an EngineeringModel
        /// Note: There is one single topElement for all Options.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ElementDefinition TopElement { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ValueGroup.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ValueGroup> ValueGroup { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="Iteration"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ActualFiniteStateList);
                containers.Add(this.DiagramCanvas);
                containers.Add(this.DomainFileStore);
                containers.Add(this.Element);
                containers.Add(this.ExternalIdentifierMap);
                containers.Add(this.Goal);
                containers.Add(this.Option);
                containers.Add(this.PossibleFiniteStateList);
                containers.Add(this.Publication);
                containers.Add(this.Relationship);
                containers.Add(this.RequirementsSpecification);
                containers.Add(this.RuleVerificationList);
                containers.Add(this.SharedDiagramStyle);
                containers.Add(this.Stakeholder);
                containers.Add(this.StakeholderValue);
                containers.Add(this.StakeholderValueMap);
                containers.Add(this.ValueGroup);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="Iteration"/>
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

            if (this.DefaultOption != null)
            {
                yield return this.DefaultOption;
            }

            if (this.IterationSetup != null)
            {
                yield return this.IterationSetup;
            }

            if (this.TopElement != null)
            {
                yield return this.TopElement;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Iteration"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Iteration"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (Iteration)this.MemberwiseClone();
            clone.ActualFiniteStateList = cloneContainedThings ? new ContainerList<ActualFiniteStateList>(clone) : new ContainerList<ActualFiniteStateList>(this.ActualFiniteStateList, clone);
            clone.DiagramCanvas = cloneContainedThings ? new ContainerList<DiagramCanvas>(clone) : new ContainerList<DiagramCanvas>(this.DiagramCanvas, clone);
            clone.DomainFileStore = cloneContainedThings ? new ContainerList<DomainFileStore>(clone) : new ContainerList<DomainFileStore>(this.DomainFileStore, clone);
            clone.Element = cloneContainedThings ? new ContainerList<ElementDefinition>(clone) : new ContainerList<ElementDefinition>(this.Element, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.ExternalIdentifierMap = cloneContainedThings ? new ContainerList<ExternalIdentifierMap>(clone) : new ContainerList<ExternalIdentifierMap>(this.ExternalIdentifierMap, clone);
            clone.Goal = cloneContainedThings ? new ContainerList<Goal>(clone) : new ContainerList<Goal>(this.Goal, clone);
            clone.Option = cloneContainedThings ? null : new OrderedItemList<Option>(this.Option, clone);
            clone.PossibleFiniteStateList = cloneContainedThings ? new ContainerList<PossibleFiniteStateList>(clone) : new ContainerList<PossibleFiniteStateList>(this.PossibleFiniteStateList, clone);
            clone.Publication = cloneContainedThings ? new ContainerList<Publication>(clone) : new ContainerList<Publication>(this.Publication, clone);
            clone.Relationship = cloneContainedThings ? new ContainerList<Relationship>(clone) : new ContainerList<Relationship>(this.Relationship, clone);
            clone.RequirementsSpecification = cloneContainedThings ? new ContainerList<RequirementsSpecification>(clone) : new ContainerList<RequirementsSpecification>(this.RequirementsSpecification, clone);
            clone.RuleVerificationList = cloneContainedThings ? new ContainerList<RuleVerificationList>(clone) : new ContainerList<RuleVerificationList>(this.RuleVerificationList, clone);
            clone.SharedDiagramStyle = cloneContainedThings ? new ContainerList<SharedStyle>(clone) : new ContainerList<SharedStyle>(this.SharedDiagramStyle, clone);
            clone.Stakeholder = cloneContainedThings ? new ContainerList<Stakeholder>(clone) : new ContainerList<Stakeholder>(this.Stakeholder, clone);
            clone.StakeholderValue = cloneContainedThings ? new ContainerList<StakeholderValue>(clone) : new ContainerList<StakeholderValue>(this.StakeholderValue, clone);
            clone.StakeholderValueMap = cloneContainedThings ? new ContainerList<StakeHolderValueMap>(clone) : new ContainerList<StakeHolderValueMap>(this.StakeholderValueMap, clone);
            clone.ValueGroup = cloneContainedThings ? new ContainerList<ValueGroup>(clone) : new ContainerList<ValueGroup>(this.ValueGroup, clone);

            if (cloneContainedThings)
            {
                clone.ActualFiniteStateList.AddRange(this.ActualFiniteStateList.Select(x => x.Clone(true)));
                clone.DiagramCanvas.AddRange(this.DiagramCanvas.Select(x => x.Clone(true)));
                clone.DomainFileStore.AddRange(this.DomainFileStore.Select(x => x.Clone(true)));
                clone.Element.AddRange(this.Element.Select(x => x.Clone(true)));
                clone.ExternalIdentifierMap.AddRange(this.ExternalIdentifierMap.Select(x => x.Clone(true)));
                clone.Goal.AddRange(this.Goal.Select(x => x.Clone(true)));
                clone.Option = this.Option.Clone(clone);
                clone.PossibleFiniteStateList.AddRange(this.PossibleFiniteStateList.Select(x => x.Clone(true)));
                clone.Publication.AddRange(this.Publication.Select(x => x.Clone(true)));
                clone.Relationship.AddRange(this.Relationship.Select(x => x.Clone(true)));
                clone.RequirementsSpecification.AddRange(this.RequirementsSpecification.Select(x => x.Clone(true)));
                clone.RuleVerificationList.AddRange(this.RuleVerificationList.Select(x => x.Clone(true)));
                clone.SharedDiagramStyle.AddRange(this.SharedDiagramStyle.Select(x => x.Clone(true)));
                clone.Stakeholder.AddRange(this.Stakeholder.Select(x => x.Clone(true)));
                clone.StakeholderValue.AddRange(this.StakeholderValue.Select(x => x.Clone(true)));
                clone.StakeholderValueMap.AddRange(this.StakeholderValueMap.Select(x => x.Clone(true)));
                clone.ValueGroup.AddRange(this.ValueGroup.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Iteration"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Iteration"/>.
        /// </returns>
        public new Iteration Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Iteration)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Iteration"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.IterationSetup == null || this.IterationSetup.Iid == Guid.Empty)
            {
                errorList.Add("The property IterationSetup is null.");
                this.IterationSetup = SentinelThingProvider.GetSentinel<IterationSetup>();
                this.sentinelResetMap["IterationSetup"] = () => this.IterationSetup = null;
            }

            var optionCount = this.Option.Count();
            if (optionCount < 1)
            {
                errorList.Add("The number of elements in the property Option is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="Iteration"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.Iteration;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current Iteration POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.Iid) : null;
            this.ActualFiniteStateList.ResolveList(dto.ActualFiniteStateList, dto.Iid, this.Cache);
            this.DefaultOption = (dto.DefaultOption.HasValue) ? this.Cache.Get<Option>(dto.DefaultOption.Value, dto.Iid) : null;
            this.DiagramCanvas.ResolveList(dto.DiagramCanvas, dto.Iid, this.Cache);
            this.DomainFileStore.ResolveList(dto.DomainFileStore, dto.Iid, this.Cache);
            this.Element.ResolveList(dto.Element, dto.Iid, this.Cache);
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.Iid, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.Iid, this.Cache);
            this.ExternalIdentifierMap.ResolveList(dto.ExternalIdentifierMap, dto.Iid, this.Cache);
            this.Goal.ResolveList(dto.Goal, dto.Iid, this.Cache);
            this.IterationSetup = this.Cache.Get<IterationSetup>(dto.IterationSetup, dto.Iid) ?? SentinelThingProvider.GetSentinel<IterationSetup>();
            this.ModifiedOn = dto.ModifiedOn;
            this.Option.ResolveList(dto.Option, dto.Iid, this.Cache);
            this.PossibleFiniteStateList.ResolveList(dto.PossibleFiniteStateList, dto.Iid, this.Cache);
            this.Publication.ResolveList(dto.Publication, dto.Iid, this.Cache);
            this.Relationship.ResolveList(dto.Relationship, dto.Iid, this.Cache);
            this.RequirementsSpecification.ResolveList(dto.RequirementsSpecification, dto.Iid, this.Cache);
            this.RevisionNumber = dto.RevisionNumber;
            this.RuleVerificationList.ResolveList(dto.RuleVerificationList, dto.Iid, this.Cache);
            this.SharedDiagramStyle.ResolveList(dto.SharedDiagramStyle, dto.Iid, this.Cache);
            this.SourceIterationIid = dto.SourceIterationIid;
            this.Stakeholder.ResolveList(dto.Stakeholder, dto.Iid, this.Cache);
            this.StakeholderValue.ResolveList(dto.StakeholderValue, dto.Iid, this.Cache);
            this.StakeholderValueMap.ResolveList(dto.StakeholderValueMap, dto.Iid, this.Cache);
            this.ThingPreference = dto.ThingPreference;
            this.TopElement = (dto.TopElement.HasValue) ? this.Cache.Get<ElementDefinition>(dto.TopElement.Value, dto.Iid) : null;
            this.ValueGroup.ResolveList(dto.ValueGroup, dto.Iid, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="Iteration"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.Iteration(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.ActualFiniteStateList.AddRange(this.ActualFiniteStateList.Select(x => x.Iid));
            dto.DefaultOption = this.DefaultOption != null ? (Guid?)this.DefaultOption.Iid : null;
            dto.DiagramCanvas.AddRange(this.DiagramCanvas.Select(x => x.Iid));
            dto.DomainFileStore.AddRange(this.DomainFileStore.Select(x => x.Iid));
            dto.Element.AddRange(this.Element.Select(x => x.Iid));
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.ExternalIdentifierMap.AddRange(this.ExternalIdentifierMap.Select(x => x.Iid));
            dto.Goal.AddRange(this.Goal.Select(x => x.Iid));
            dto.IterationSetup = this.IterationSetup != null ? this.IterationSetup.Iid : Guid.Empty;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Option.AddRange(this.Option.ToDtoOrderedItemList());
            dto.PossibleFiniteStateList.AddRange(this.PossibleFiniteStateList.Select(x => x.Iid));
            dto.Publication.AddRange(this.Publication.Select(x => x.Iid));
            dto.Relationship.AddRange(this.Relationship.Select(x => x.Iid));
            dto.RequirementsSpecification.AddRange(this.RequirementsSpecification.Select(x => x.Iid));
            dto.RevisionNumber = this.RevisionNumber;
            dto.RuleVerificationList.AddRange(this.RuleVerificationList.Select(x => x.Iid));
            dto.SharedDiagramStyle.AddRange(this.SharedDiagramStyle.Select(x => x.Iid));
            dto.SourceIterationIid = this.SourceIterationIid;
            dto.Stakeholder.AddRange(this.Stakeholder.Select(x => x.Iid));
            dto.StakeholderValue.AddRange(this.StakeholderValue.Select(x => x.Iid));
            dto.StakeholderValueMap.AddRange(this.StakeholderValueMap.Select(x => x.Iid));
            dto.ThingPreference = this.ThingPreference;
            dto.TopElement = this.TopElement != null ? (Guid?)this.TopElement.Iid : null;
            dto.ValueGroup.AddRange(this.ValueGroup.Select(x => x.Iid));

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
