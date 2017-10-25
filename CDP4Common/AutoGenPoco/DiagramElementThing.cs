// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagramElementThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DiagramData
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
    /// The abstract class for all types that represent diagramming elements. This abstract corresponds to the "DiagramElement" class defined by the OMG Diagram Definition v1.1
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementContainer), "DiagramElement")]
    public abstract partial class DiagramElementThing : DiagramElementContainer
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementThing"/> class.
        /// </summary>
        protected DiagramElementThing()
        {
            this.LocalStyle = new ContainerList<OwnedStyle>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramElementThing"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        protected DiagramElementThing(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.LocalStyle = new ContainerList<OwnedStyle>(this);
        }

        /// <summary>
        /// Gets or sets the DepictedThing.
        /// </summary>
        /// <remarks>
        /// The Thing that is depicted by this DiagramElementThing.
        /// NOTE: The depicted Thing cannot be a DiagramThingBase.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Thing DepictedThing { get; set; }

        /// <summary>
        /// Gets or sets a list of contained OwnedStyle.
        /// </summary>
        /// <remarks>
        /// The optional style applied locally on this DiagramElementThing
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<OwnedStyle> LocalStyle { get; protected set; }

        /// <summary>
        /// Gets or sets the SharedStyle.
        /// </summary>
        /// <remarks>
        /// An optional shared style for this DiagramElementThing
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual SharedStyle SharedStyle { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagramElementThing"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.LocalStyle);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DiagramElementThing"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DiagramElementThing"/>.
        /// </returns>
        public new DiagramElementThing Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (DiagramElementThing)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="DiagramElementThing"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }
    }
}
