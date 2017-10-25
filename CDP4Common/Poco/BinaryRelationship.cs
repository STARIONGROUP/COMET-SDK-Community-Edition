// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationship.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// The extended-part for the <see cref="Relationship"/> class
    /// </summary>
    public partial class BinaryRelationship
    {
        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        public override string UserFriendlyName
        {
            get { return string.Format("{0} -> {1}", this.Source.UserFriendlyName, this.Target.UserFriendlyName); }
        }

        /// <summary>
        /// Gets the user-friendly short name
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return string.Format("{0}.{1}", this.Source.UserFriendlyShortName, this.Target.UserFriendlyShortName); }
        }

        /// <summary>
        /// Gets the list of <see cref="BinaryRelationshipRule"/> applied to this <see cref="BinaryRelationship"/>
        /// </summary>
        public IEnumerable<BinaryRelationshipRule> AppliedBinaryRelationshipRules
        {
            get
            {
                if (this.Category == null)
                {
                    return new List<BinaryRelationshipRule>();
                }

                var model = this.GetContainerOfType<EngineeringModel>();
                if (model == null)
                {
                    throw new InvalidOperationException("The Engineering Model container is null.");
                }

                var mrdl = model.EngineeringModelSetup.RequiredRdl.Single();

                var appliedRules =
                    new List<BinaryRelationshipRule>(
                        mrdl.Rule.OfType<BinaryRelationshipRule>()
                            .Where(c => this.Category.Contains(c.RelationshipCategory)));
                appliedRules.AddRange(mrdl.GetRequiredRdls()
                    .SelectMany(rdl => rdl.Rule.OfType<BinaryRelationshipRule>())
                    .Where(c => this.Category.Contains(c.RelationshipCategory)));

                return appliedRules;
            }
        }
    }
}