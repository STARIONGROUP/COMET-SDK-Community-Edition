// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipRule.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// representation of a validation rule for BinaryRelationships
    /// Note: A BinaryRelationshipRule specifies for BinaryRelationships that are a member of the <i>relationshipCategory</i> what are the valid Categories for the related <i>source</i> and <i>target</i> Things
    /// Example: A rule where the <i>relationshipCategory</i> is Category "RequirementSatisfactionTraces", the sourceCategory is "ArchitecturalElements" (with <i>permissibleClass</i> ElementDefinition, ElementUsage) and the <i>targetCategory</i> is Category "Requirements" (with <i>permissibleClass</i> Requirement).
    /// </summary>
    public partial class BinaryRelationshipRule : IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to the <see cref="BinaryRelationshipRule"/> 
        /// </summary>
        /// <param name="iteration">
        /// The <see cref="Iteration"/> that is to be verified.
        /// </param>
        /// <returns>
        /// an <see cref="IEnumerable{RuleViolation}"/>, this may be empty of no <see cref="RuleViolation"/>s have been found.
        /// </returns>
        public IEnumerable<RuleViolation> Verify(Iteration iteration)
        {
            if (iteration == null)
            {
                throw new ArgumentNullException("iteration", "The iteration may not be null");
            }

            var binaryRelationShips = iteration.Relationship.OfType<BinaryRelationship>().ToList();
            if (binaryRelationShips.Count == 0)
            {
                return Enumerable.Empty<RuleViolation>();
            }

            if (this.RelationshipCategory == null)
            {
                return Enumerable.Empty<RuleViolation>();
            }

            var applicableRelationshipCategories = this.RelationshipCategory.AllDerivedCategories().ToList();
            applicableRelationshipCategories.Add(this.RelationshipCategory);

            var violations = new List<RuleViolation>();

            foreach (var binaryRelationship in binaryRelationShips)
            {
                var allCategories = binaryRelationship.GetAllCategories().ToList();
                
                var relationshipIsCategorizedWithRuleRelationshipCategory = false;
                foreach (var category in allCategories)
                {
                    if (applicableRelationshipCategories.Contains(category))
                    {
                        relationshipIsCategorizedWithRuleRelationshipCategory = true;
                    }
                }

                if (!relationshipIsCategorizedWithRuleRelationshipCategory)
                {
                    continue;
                }

                var sourceViolation = this.VerifySource(binaryRelationship);
                if (sourceViolation != null)
                {
                    violations.Add(sourceViolation);
                }

                var targetViolation = this.VerifyTarget(binaryRelationship);
                if (targetViolation != null)
                {
                    violations.Add(targetViolation);
                }    
            }

            return violations;
        }

        /// <summary>
        /// Verifies that the source of the <see cref="BinaryRelationship"/> violates the <see cref="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="binaryRelationship">
        /// The <see cref="BinaryRelationship"/> to verify
        /// </param>
        /// <returns>
        /// An instance of <see cref="RuleViolation"/> if the <see cref="BinaryRelationshipRule"/> has been violated, null otherwise
        /// </returns>
        private RuleViolation VerifySource(BinaryRelationship binaryRelationship)
        {
            var sourceCategorizableThing = binaryRelationship.Source as ICategorizableThing;
            if (sourceCategorizableThing == null)
            {
                var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                violation.ViolatingThing.Add(binaryRelationship.Iid);
                violation.ViolatingThing.Add(binaryRelationship.Source.Iid);
                violation.Description = $"The Source [{binaryRelationship.Source.ClassKind}:{binaryRelationship.Source.Iid}] of the BinaryRelationShip is not a CategorizableThing";

                return violation;
            }

            var isMemberOfCategory = sourceCategorizableThing.IsMemberOfCategory(this.SourceCategory);
            if (!isMemberOfCategory)
            {
                var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                violation.ViolatingThing.Add(binaryRelationship.Iid);
                violation.ViolatingThing.Add(binaryRelationship.Source.Iid);
                violation.Description = $"The Source [{binaryRelationship.Source.ClassKind}:{binaryRelationship.Source.Iid}] of the BinaryRelationShip {binaryRelationship.Iid} is not a member of Category {this.SourceCategory.Iid} with shortname {this.SourceCategory.ShortName} or any of it's super categories";

                return violation;                    
            }
            
            return null;
        }

        /// <summary>
        /// Verifies that the target of the <see cref="BinaryRelationship"/> violates the <see cref="BinaryRelationshipRule"/>
        /// </summary>
        /// <param name="binaryRelationship">
        /// The <see cref="BinaryRelationship"/> to verify
        /// </param>
        /// <returns>
        /// An instance of <see cref="RuleViolation"/> if the <see cref="BinaryRelationshipRule"/> has been violated, null otherwise
        /// </returns>
        private RuleViolation VerifyTarget(BinaryRelationship binaryRelationship)
        {
            var targetCategorizableThing = binaryRelationship.Target as ICategorizableThing;
            if (targetCategorizableThing == null)
            {
                var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                violation.ViolatingThing.Add(binaryRelationship.Iid);
                violation.ViolatingThing.Add(binaryRelationship.Target.Iid);
                violation.Description = $"The Target [{binaryRelationship.Target.ClassKind}:{binaryRelationship.Target.Iid}] of the BinaryRelationShip is not a CategorizableThing";

                return violation;
            }
            
            var isMemberOfCategory = targetCategorizableThing.IsMemberOfCategory(this.TargetCategory);
            if (!isMemberOfCategory)
            {
                var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                violation.ViolatingThing.Add(binaryRelationship.Iid);
                violation.ViolatingThing.Add(binaryRelationship.Target.Iid);
                violation.Description = $"The Target [{binaryRelationship.Target.ClassKind}:{binaryRelationship.Target.Iid}] of the BinaryRelationShip {binaryRelationship.Iid} is not a member of Category {this.TargetCategory.Iid} with shortname {this.TargetCategory.ShortName} or any of it's super categories";

                return violation;
            }
            
            return null;
        }
    }
}