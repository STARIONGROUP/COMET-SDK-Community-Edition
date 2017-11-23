// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterOrOverrideBase.cs" company="RHEA System S.A.">
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
    using System.Xml.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="ParameterOrOverrideBase"/> class.
    /// </summary>
    [DataContract]
    public abstract partial class ParameterOrOverrideBase : ParameterBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterOrOverrideBase"/> class.
        /// </summary>
        protected ParameterOrOverrideBase()
        {
            this.ParameterSubscription = new List<Guid>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterOrOverrideBase"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected ParameterOrOverrideBase(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
            this.ParameterSubscription = new List<Guid>();
        }

        /// <summary>
        /// Gets or sets the unique identifiers of the contained ParameterSubscription instances.
        /// </summary>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        [DataMember]
        public virtual List<Guid> ParameterSubscription { get; set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="ParameterOrOverrideBase"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.ParameterSubscription);
                return containers;
            }
        }
    }
}
