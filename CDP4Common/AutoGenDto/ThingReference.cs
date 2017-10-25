// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingReference.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ThingReference"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    public abstract partial class ThingReference : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThingReference"/> class.
        /// </summary>
        protected ThingReference()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ThingReference"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ThingReference(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets the ReferencedRevisionNumber.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual int ReferencedRevisionNumber { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier of the referenced ReferencedThing.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual Guid ReferencedThing { get; set; }
    }
}
