#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Iteration.cs" company="RHEA System S.A.">
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

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="Iteration"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(EngineeringModel), "Iteration")]
    public sealed partial class Iteration : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Iteration"/> class.
        /// </summary>
        public Iteration()
        {
            this.ActualFiniteStateList = new List<Guid>();
            this.DiagramCanvas = new List<Guid>();
            this.DomainFileStore = new List<Guid>();
            this.Element = new List<Guid>();
            this.ExternalIdentifierMap = new List<Guid>();
            this.Goal = new List<Guid>();
            this.Option = new List<OrderedItem>();
            this.PossibleFiniteStateList = new List<Guid>();
            this.Publication = new List<Guid>();
            this.Relationship = new List<Guid>();
            this.RequirementsSpecification = new List<Guid>();
            this.RuleVerificationList = new List<Guid>();
            this.SharedDiagramStyle = new List<Guid>();
            this.Stakeholder = new List<Guid>();
            this.StakeholderValue = new List<Guid>();
            this.StakeholderValueMap = new List<Guid>();
            this.ValueGroup = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Iteration"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public Iteration(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ActualFiniteStateList = new List<Guid>();
            this.DiagramCanvas = new List<Guid>();
            this.DomainFileStore = new List<Guid>();
            this.Element = new List<Guid>();
            this.ExternalIdentifierMap = new List<Guid>();
            this.Goal = new List<Guid>();
            this.Option = new List<OrderedItem>();
            this.PossibleFiniteStateList = new List<Guid>();
            this.Publication = new List<Guid>();
            this.Relationship = new List<Guid>();
            this.RequirementsSpecification = new List<Guid>();
            this.RuleVerificationList = new List<Guid>();
            this.SharedDiagramStyle = new List<Guid>();
            this.Stakeholder = new List<Guid>();
            this.StakeholderValue = new List<Guid>();
            this.StakeholderValueMap = new List<Guid>();
            this.ValueGroup = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ActualFiniteStateList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ActualFiniteStateList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced DefaultOption.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? DefaultOption { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DiagramCanvas instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> DiagramCanvas { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained DomainFileStore instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> DomainFileStore { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Element instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Element { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ExternalIdentifierMap instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ExternalIdentifierMap { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Goal instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Goal { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced IterationSetup.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public Guid IterationSetup { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Option instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: true, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<OrderedItem> Option { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained PossibleFiniteStateList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> PossibleFiniteStateList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Publication instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Publication { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Relationship instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Relationship { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RequirementsSpecification instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RequirementsSpecification { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained RuleVerificationList instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> RuleVerificationList { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained SharedDiagramStyle instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> SharedDiagramStyle { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced SourceIterationIid.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? SourceIterationIid { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained Stakeholder instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> Stakeholder { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained StakeholderValue instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> StakeholderValue { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained StakeholderValueMap instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> StakeholderValueMap { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced TopElement.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        [DataMember]
        public Guid? TopElement { get; set; }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ValueGroup instances.
        /// </summary>
        [CDPVersion("1.1.0")]
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public List<Guid> ValueGroup { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="Iteration"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

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
        /// Instantiate a <see cref="CDP4Common.EngineeringModelData.Iteration"/> from a <see cref="Iteration"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.EngineeringModelData.Iteration"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.EngineeringModelData.Iteration(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as Iteration;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.ActualFiniteStateList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ActualFiniteStateList.Add(copy.Value.Iid);
            }

            var copyDefaultOption = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.DefaultOption);
            this.DefaultOption = copyDefaultOption.Value == null ? original.DefaultOption : copyDefaultOption.Value.Iid;

            foreach (var guid in original.DiagramCanvas)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.DiagramCanvas.Add(copy.Value.Iid);
            }

            foreach (var guid in original.DomainFileStore)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.DomainFileStore.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Element)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Element.Add(copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedDomain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedDomain.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedPerson)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedPerson.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.ExternalIdentifierMap)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ExternalIdentifierMap.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Goal)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Goal.Add(copy.Value.Iid);
            }

            var copyIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.IterationSetup);
            this.IterationSetup = copyIterationSetup.Value == null ? original.IterationSetup : copyIterationSetup.Value.Iid;

            this.ModifiedOn = original.ModifiedOn;

            foreach (var orderedItem in original.Option)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == Guid.Parse(orderedItem.V.ToString()));
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", orderedItem.V));
                }
                this.Option.Add(new OrderedItem { K = orderedItem.K, V = copy.Value.Iid });
            }

            foreach (var guid in original.PossibleFiniteStateList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.PossibleFiniteStateList.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Publication)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Publication.Add(copy.Value.Iid);
            }

            foreach (var guid in original.Relationship)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Relationship.Add(copy.Value.Iid);
            }

            foreach (var guid in original.RequirementsSpecification)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.RequirementsSpecification.Add(copy.Value.Iid);
            }

            foreach (var guid in original.RuleVerificationList)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.RuleVerificationList.Add(copy.Value.Iid);
            }

            foreach (var guid in original.SharedDiagramStyle)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.SharedDiagramStyle.Add(copy.Value.Iid);
            }

            this.SourceIterationIid = original.SourceIterationIid;

            foreach (var guid in original.Stakeholder)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.Stakeholder.Add(copy.Value.Iid);
            }

            foreach (var guid in original.StakeholderValue)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.StakeholderValue.Add(copy.Value.Iid);
            }

            foreach (var guid in original.StakeholderValueMap)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.StakeholderValueMap.Add(copy.Value.Iid);
            }

            var copyTopElement = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.TopElement);
            this.TopElement = copyTopElement.Value == null ? original.TopElement : copyTopElement.Value.Iid;

            foreach (var guid in original.ValueGroup)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.ValueGroup.Add(copy.Value.Iid);
            }
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            var copyIterationSetup = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == this.IterationSetup);
            if (copyIterationSetup.Key != null)
            {
                this.IterationSetup = copyIterationSetup.Value.Iid;
                hasChanges = true;
            }

            return hasChanges;
        }
    }
}
