#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RuleVerification.cs" company="RHEA System S.A.">
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
    /// representation of built-in data model rule or user-defined Rule to be verified and its current verification result
    /// </summary>
    [Container(typeof(RuleVerificationList), "RuleVerification")]
    public abstract partial class RuleVerification : Thing, INamedThing, IOwnedThing
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
        /// Initializes a new instance of the <see cref="RuleVerification"/> class.
        /// </summary>
        protected RuleVerification()
        {
            this.Violation = new ContainerList<RuleViolation>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RuleVerification"/> class.
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
        protected RuleVerification(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Violation = new ContainerList<RuleViolation>(this);
        }

        /// <summary>
        /// Gets or sets the ExecutedOn.
        /// </summary>
        /// <remarks>
        /// date and time of the last executed verification of the associated rule
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual DateTime? ExecutedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive.
        /// </summary>
        /// <remarks>
        /// assertion whether the associated built-in data model rule or user-defined Rule is active, i.e. shall be verified in the next verification execution
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <remarks>
        /// human readable character string in English by which something can be       referred       to
        /// Note: The implied LanguageCode of <i>name</i> is "en-GB".
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string Name { get; set; }

        /// <summary>
        /// Gets or sets the Owner.
        /// </summary>
        /// <remarks>
        /// reference to the owner DomainOfExpertise of this RuleVerification
        /// Note: The owner is the same as the <i>owner</i> of the containing RuleVerificationList.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The Owner property is a derived property; when the getter and setter are invoked an InvalidOperationException will be thrown.
        /// </exception>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: true, isOrdered: false, isNullable: false, isPersistent: false)]
        public DomainOfExpertise Owner
        {
            get { return this.GetDerivedOwner(); }
            set { throw new InvalidOperationException("Forbidden Set value for the derived property RuleVerification.Owner"); }
        }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <remarks>
        /// status of the last executed verification of the associated rule
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual RuleVerificationStatusKind Status { get; set; }

        /// <summary>
        /// Gets or sets a list of contained RuleViolation.
        /// </summary>
        /// <remarks>
        /// set of violations, if any, of rules having been verified
        /// Note: A RuleViolation provides explanatory information to help the user correct the EngineeringModel so that the associated rule will be satisfied.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: false)]
        public virtual ContainerList<RuleViolation> Violation { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="RuleVerification"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.Violation);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="RuleVerification"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="RuleVerification"/>.
        /// </returns>
        public new RuleVerification Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (RuleVerification)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="RuleVerification"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            if (string.IsNullOrWhiteSpace(this.Name))
            {
                errorList.Add("The property Name is null or empty.");
            }

            return errorList;
        }
    }
}
