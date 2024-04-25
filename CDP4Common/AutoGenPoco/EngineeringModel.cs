// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModel.cs" company="Starion Group S.A.">
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
    /// representation of a parametric concurrent engineering model that specifies the problem to be solved and defines one or more (possible) design solutions
    /// Note 1: An EngineeringModel also references a chain of one or more ReferenceDataLibraries (through the <i>requiredRdl</i> property of the associated EngineeringModelSetup) that define the reference data that is or can be used in the model.
    /// Note 2: When an EngineeringModel is created for first time, it shall contain one Iteration and one Option (with <i>name</i> and <i>shortName</i> set to "Default"), which shall also be referenced as the <i>defaultOption</i>.
    /// </summary>
    public partial class EngineeringModel : TopContainer
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
        /// Initializes a new instance of the <see cref="EngineeringModel"/> class.
        /// </summary>
        public EngineeringModel()
        {
            this.Book = new OrderedItemList<Book>(this, true);
            this.CommonFileStore = new ContainerList<CommonFileStore>(this);
            this.GenericNote = new ContainerList<EngineeringModelDataNote>(this);
            this.Iteration = new ContainerList<Iteration>(this);
            this.LogEntry = new ContainerList<ModelLogEntry>(this);
            this.ModellingAnnotation = new ContainerList<ModellingAnnotationItem>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModel"/> class.
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
        public EngineeringModel(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Book = new OrderedItemList<Book>(this, true);
            this.CommonFileStore = new ContainerList<CommonFileStore>(this);
            this.GenericNote = new ContainerList<EngineeringModelDataNote>(this);
            this.Iteration = new ContainerList<Iteration>(this);
            this.LogEntry = new ContainerList<ModelLogEntry>(this);
            this.ModellingAnnotation = new ContainerList<ModellingAnnotationItem>(this);
        }

        /// <summary>
        /// Gets or sets a list of ordered contained Book.
        /// </summary>
        /// <remarks>
        /// collection of Books in this EngineeringModel
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        public OrderedItemList<Book> Book { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained CommonFileStore.
        /// </summary>
        /// <remarks>
        /// representation of the CommonFileStore in this EngineeringModel
        /// Note: Typically there will be one CommonFileStore shared by all domains in a particular EngineeringModel, plus one DomainFileStore for each DomainOfExpertise.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<CommonFileStore> CommonFileStore { get; protected set; }

        /// <summary>
        /// Gets or sets the EngineeringModelSetup.
        /// </summary>
        /// <remarks>
        /// reference to the set-up information for this EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public EngineeringModelSetup EngineeringModelSetup { get; set; }

        /// <summary>
        /// Gets or sets a list of contained EngineeringModelDataNote.
        /// </summary>
        /// <remarks>
        /// The generic annotations made on Things contained by this EngineeringModel
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<EngineeringModelDataNote> GenericNote { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained Iteration.
        /// </summary>
        /// <remarks>
        /// collection of Iterations in this EngineeringModel
        /// Note 1: An iteration is a version of the EngineeringModel that is considered as one complete and coherent step in the development of the EngineeringModel in a concurrent engineering activity. The detailed definition and understanding of the meaning of a "complete and coherent" step depends on the organization that develops the EngineeringModel.
        /// Note 2: In a concurrent engineering activity the engineering model for the system-of-interest is developed in a number of iterations, where in each iteration the problem specification in the form of the RequirementsSpecification and a design solution in the form of the Options and ElementDefinitions are elaborated and refined. With an iteration the engineering team strives to set one more step in the direction of achieving a converged definition that fulfills the objectives of their activity.
        /// Note 3: In an implementation of E-TM-10-25 the actual Iteration objects may be stored in different partitions in a persistent data store.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<Iteration> Iteration { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ModelLogEntry.
        /// </summary>
        /// <remarks>
        /// collection of logbook entries for this EngineeringModel
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ModelLogEntry> LogEntry { get; protected set; }

        /// <summary>
        /// Gets or sets a list of contained ModellingAnnotationItem.
        /// </summary>
        /// <remarks>
        /// The modelling annotation made on the Things contained by this EngineeringModel
        /// </remarks>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public ContainerList<ModellingAnnotationItem> ModellingAnnotation { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModel"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Book);
                containers.Add(this.CommonFileStore);
                containers.Add(this.GenericNote);
                containers.Add(this.Iteration);
                containers.Add(this.LogEntry);
                containers.Add(this.ModellingAnnotation);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="EngineeringModel"/>
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

            if (this.EngineeringModelSetup != null)
            {
                yield return this.EngineeringModelSetup;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModel"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModel"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (EngineeringModel)this.MemberwiseClone();
            clone.Book = cloneContainedThings ? null : new OrderedItemList<Book>(this.Book, clone);
            clone.CommonFileStore = cloneContainedThings ? new ContainerList<CommonFileStore>(clone) : new ContainerList<CommonFileStore>(this.CommonFileStore, clone);
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.GenericNote = cloneContainedThings ? new ContainerList<EngineeringModelDataNote>(clone) : new ContainerList<EngineeringModelDataNote>(this.GenericNote, clone);
            clone.Iteration = cloneContainedThings ? new ContainerList<Iteration>(clone) : new ContainerList<Iteration>(this.Iteration, clone);
            clone.LogEntry = cloneContainedThings ? new ContainerList<ModelLogEntry>(clone) : new ContainerList<ModelLogEntry>(this.LogEntry, clone);
            clone.ModellingAnnotation = cloneContainedThings ? new ContainerList<ModellingAnnotationItem>(clone) : new ContainerList<ModellingAnnotationItem>(this.ModellingAnnotation, clone);

            if (cloneContainedThings)
            {
                clone.Book = this.Book.Clone(clone);
                clone.CommonFileStore.AddRange(this.CommonFileStore.Select(x => x.Clone(true)));
                clone.GenericNote.AddRange(this.GenericNote.Select(x => x.Clone(true)));
                clone.Iteration.AddRange(this.Iteration.Select(x => x.Clone(true)));
                clone.LogEntry.AddRange(this.LogEntry.Select(x => x.Clone(true)));
                clone.ModellingAnnotation.AddRange(this.ModellingAnnotation.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModel"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModel"/>.
        /// </returns>
        public new EngineeringModel Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (EngineeringModel)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="EngineeringModel"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.EngineeringModelSetup == null || this.EngineeringModelSetup.Iid == Guid.Empty)
            {
                errorList.Add("The property EngineeringModelSetup is null.");
                this.EngineeringModelSetup = SentinelThingProvider.GetSentinel<EngineeringModelSetup>();
                this.sentinelResetMap["EngineeringModelSetup"] = () => this.EngineeringModelSetup = null;
            }

            var iterationCount = this.Iteration.Count();
            if (iterationCount < 1)
            {
                errorList.Add("The number of elements in the property Iteration is wrong. It should be at least 1.");
            }

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="EngineeringModel"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.EngineeringModel;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current EngineeringModel POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.Book.ResolveList(dto.Book, dto.IterationContainerId, this.Cache);
            this.CommonFileStore.ResolveList(dto.CommonFileStore, dto.IterationContainerId, this.Cache);
            this.EngineeringModelSetup = this.Cache.Get<EngineeringModelSetup>(dto.EngineeringModelSetup, dto.IterationContainerId) ?? SentinelThingProvider.GetSentinel<EngineeringModelSetup>();
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.GenericNote.ResolveList(dto.GenericNote, dto.IterationContainerId, this.Cache);
            this.Iteration.ResolveList(dto.Iteration, dto.IterationContainerId, this.Cache);
            this.LastModifiedOn = dto.LastModifiedOn;
            this.LogEntry.ResolveList(dto.LogEntry, dto.IterationContainerId, this.Cache);
            this.ModellingAnnotation.ResolveList(dto.ModellingAnnotation, dto.IterationContainerId, this.Cache);
            this.ModifiedOn = dto.ModifiedOn;
            this.RevisionNumber = dto.RevisionNumber;
            this.ThingPreference = dto.ThingPreference;

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="EngineeringModel"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.EngineeringModel(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.Book.AddRange(this.Book.ToDtoOrderedItemList());
            dto.CommonFileStore.AddRange(this.CommonFileStore.Select(x => x.Iid));
            dto.EngineeringModelSetup = this.EngineeringModelSetup != null ? this.EngineeringModelSetup.Iid : Guid.Empty;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.GenericNote.AddRange(this.GenericNote.Select(x => x.Iid));
            dto.Iteration.AddRange(this.Iteration.Select(x => x.Iid));
            dto.LastModifiedOn = this.LastModifiedOn;
            dto.LogEntry.AddRange(this.LogEntry.Select(x => x.Iid));
            dto.ModellingAnnotation.AddRange(this.ModellingAnnotation.Select(x => x.Iid));
            dto.ModifiedOn = this.ModifiedOn;
            dto.RevisionNumber = this.RevisionNumber;
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
