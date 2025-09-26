// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelDataAnnotation.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.ReportingData
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
    /// The abstract annotation class made on EngineeringModel Things
    /// </summary>
    [CDPVersion("1.1.0")]
    public abstract partial class EngineeringModelDataAnnotation : GenericAnnotation
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
        /// Initializes a new instance of the <see cref="EngineeringModelDataAnnotation"/> class.
        /// </summary>
        protected EngineeringModelDataAnnotation()
        {
            this.Discussion = new ContainerList<EngineeringModelDataDiscussionItem>(this);
            this.RelatedThing = new ContainerList<ModellingThingReference>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EngineeringModelDataAnnotation"/> class.
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
        protected EngineeringModelDataAnnotation(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Discussion = new ContainerList<EngineeringModelDataDiscussionItem>(this);
            this.RelatedThing = new ContainerList<ModellingThingReference>(this);
        }

        /// <summary>
        /// Gets or sets the Author.
        /// </summary>
        /// <remarks>
        /// The participant who is the author of the annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Participant Author { get; set; }

        /// <summary>
        /// Gets or sets a list of contained EngineeringModelDataDiscussionItem.
        /// </summary>
        /// <remarks>
        /// The discussions that follows the creation of this annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<EngineeringModelDataDiscussionItem> Discussion { get; protected set; }

        /// <summary>
        /// Gets or sets the PrimaryAnnotatedThing.
        /// </summary>
        /// <remarks>
        /// The reference of the primary Thing that is being annotated
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ModellingThingReference PrimaryAnnotatedThing { get; set; }

        /// <summary>
        /// Gets or sets a list of contained ModellingThingReference.
        /// </summary>
        /// <remarks>
        /// The reference of the things that are related to this annotation
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<ModellingThingReference> RelatedThing { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="EngineeringModelDataAnnotation"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Discussion);
                containers.Add(this.RelatedThing);
                return containers;
            }
        }

        /// <summary>
        /// Queries the referenced <see cref="Thing"/>s of the current <see cref="EngineeringModelDataAnnotation"/>
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

            if (this.Author != null)
            {
                yield return this.Author;
            }

            if (this.PrimaryAnnotatedThing != null)
            {
                yield return this.PrimaryAnnotatedThing;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="EngineeringModelDataAnnotation"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="EngineeringModelDataAnnotation"/>.
        /// </returns>
        public new EngineeringModelDataAnnotation Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (EngineeringModelDataAnnotation)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="EngineeringModelDataAnnotation"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (this.Author == null || this.Author.Iid == Guid.Empty)
            {
                errorList.Add("The property Author is null.");
                this.Author = SentinelThingProvider.GetSentinel<Participant>();
                this.sentinelResetMap["Author"] = () => this.Author = null;
            }

            return errorList;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
