// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpression.cs" company="RHEA System S.A.">
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
    /// A Data Transfer Object representation of the <see cref="BooleanExpression"/> class.
    /// </summary>
    [DataContract]
    [Container(typeof(ParametricConstraint), "Expression")]
    public abstract partial class BooleanExpression : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanExpression"/> class.
        /// </summary>
        protected BooleanExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanExpression"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="rev">
        /// The revision number.
        /// </param>
        protected BooleanExpression(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets the route for the current <see ref="BooleanExpression"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }
    }
}
