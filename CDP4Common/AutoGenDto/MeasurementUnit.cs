// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MeasurementUnit.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    #pragma warning disable S1128
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
    #pragma warning restore S1128

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="MeasurementUnit"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ReferenceDataLibrary), "Unit")]
    public abstract partial class MeasurementUnit : DefinedThing, IDeprecatableThing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementUnit"/> class.
        /// </summary>
        protected MeasurementUnit()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MeasurementUnit"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected MeasurementUnit(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether IsDeprecated.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual bool IsDeprecated { get; set; }

        /// <summary>
        /// Gets the route for the current <see ref="MeasurementUnit"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
