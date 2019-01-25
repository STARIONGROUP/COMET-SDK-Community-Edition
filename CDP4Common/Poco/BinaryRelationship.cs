// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationship.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Exceptions;
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
                    throw new ContainmentException("The Engineering Model container is null.");
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

        /// <summary>
        /// Perform extra operations on a <see cref="BinaryRelationship"/>
        /// </summary>
        protected override void ResolveExtraProperties()
        {
            if (this.Source != null && this.Target != null)
            {
                this.Source.Relationships.Add(this);
                this.Target.Relationships.Add(this);
            }
        }

        /// <summary>
        /// Clean the referenced Thing list of <see cref="Relationship"/> of this <see cref="Relationship"/>
        /// </summary>
        public override void CleanReferencedThingRelationship()
        {
            this.Source?.Relationships.Remove(this);
            this.Target?.Relationships.Remove(this);
        }
    }
}