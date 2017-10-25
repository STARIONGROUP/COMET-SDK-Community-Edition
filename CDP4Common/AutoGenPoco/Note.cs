// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Note.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
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
    /// Represents a record of points or ideas as an aid to memory
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(Page), "Note")]
    public abstract partial class Note : Thing, ICategorizableThing, INamedThing, IOwnedThing, IShortNamedThing, ITimeStampedThing
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
        /// Initializes a new instance of the <see cref="Note"/> class.
        /// </summary>
        protected Note()
        {
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class.
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
        protected Note(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.Category = new List<Category>();
        }

        /// <summary>
        /// Gets or sets a list of Category.
        /// </summary>
        /// <remarks>
        /// reference to zero or more Categories of which this CategorizableThing is a member
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual List<Category> Category { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn.
        /// </summary>
        /// <remarks>
        /// Note 1: This implies that any value shall comply with the following (informative) ISO 8601 format "yyyy-mm-ddThh:mm:ss.sssZ".
        /// Note 2: All persistent date-and-time-stamps in this model shall be stored in UTC. When local calendar dates and clock times in a specific timezone are needed they shall be converted on the fly from and to UTC by client applications.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual DateTime CreatedOn { get; set; }

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
        /// reference to a DomainOfExpertise that is the owner of this OwnedThing
        /// Note: Ownership in this data model implies the responsibility for the presence and content of this OwnedThing. The owner is always a DomainOfExpertise. The Participant or Participants representing an owner DomainOfExpertise are thus responsible for (i.e. take ownership of) a coherent set of concerns in a concurrent engineering activity.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual DomainOfExpertise Owner { get; set; }

        /// <summary>
        /// Gets or sets the ShortName.
        /// </summary>
        /// <remarks>
        /// Note 1: The implied LanguageCode of <i>shortName</i> is "en-GB".
        /// Note 2: The <i>shortName</i> is meant to be used to refer to something where little space is available, for example to name a domain of expertise, a parameter or a measurement scale or unit in the column header of a table or in a formula.
        /// Note 3: A <i>shortName</i> may be an acronym or an abbreviated term.
        /// Note 4: A <i>shortName</i> should not contain any whitespace. Additional constraints are defined for some specializations of ShortNamedThing in order to ensure that the <i>shortName</i> can be used as a variable name in a programming or modelling language.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string ShortName { get; set; }

        /// <summary>
        /// Creates and returns a copy of this <see cref="Note"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="Note"/>.
        /// </returns>
        public new Note Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (Note)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="Note"/>.
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

            if (this.Owner == null || this.Owner.Iid == Guid.Empty)
            {
                errorList.Add("The property Owner is null.");
                this.Owner = SentinelThingProvider.GetSentinel<DomainOfExpertise>();
                this.sentinelResetMap["Owner"] = () => this.Owner = null;
            }

            if (string.IsNullOrWhiteSpace(this.ShortName))
            {
                errorList.Add("The property ShortName is null or empty.");
            }

            return errorList;
        }
    }
}
