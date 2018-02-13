#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRule.cs" company="RHEA System S.A.">
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

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// representation of a validation rule for <see cref="MultiRelationship"/>s that relate (potentially) more than two <see cref="ICategorizableThing"/>s
    /// </summary>
    public partial class MultiRelationshipRule : IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to the <see cref="MultiRelationshipRule"/> 
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

            var multiRelationships = iteration.Relationship.OfType<MultiRelationship>().ToList();
            if (multiRelationships.Count == 0)
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

            foreach (var multiReplationship in multiRelationships)
            {
                var allCategories = multiReplationship.GetAllCategories().ToList();

                var relationshipIsCategorizedWithRuleRelationshipCategory = false;
                foreach (var category in allCategories)
                {
                    if (applicableRelationshipCategories.Contains(category))
                    {
                        relationshipIsCategorizedWithRuleRelationshipCategory = true;
                        continue;
                    }
                }

                if (!relationshipIsCategorizedWithRuleRelationshipCategory)
                {
                    continue;
                }

                foreach (var relatedThing in multiReplationship.RelatedThing)
                {
                    var relatedCategorizableThing = relatedThing as ICategorizableThing;
                    if (relatedCategorizableThing == null)
                    {
                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.ViolatingThing.Add(multiReplationship.Iid);
                        violation.ViolatingThing.Add(relatedThing.Iid);
                        violation.Description = string.Format("The related Thing [{0}:{1}] of the MultiRelationship {2} is not a CategorizableThing", relatedThing.ClassKind, relatedThing.Iid, multiReplationship.Iid);

                        violations.Add(violation);
                    }
                    else
                    {
                        var isMemberOfCategory = false;

                        foreach (var category in this.RelatedCategory)
                        {
                            if (relatedCategorizableThing.IsMemberOfCategory(category))
                            {
                                isMemberOfCategory = true;
                               continue;
                            }                        
                        }

                        if (!isMemberOfCategory)
                        {
                            var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                            violation.ViolatingThing.Add(multiReplationship.Iid);
                            violation.ViolatingThing.Add(relatedThing.Iid);
                            violation.Description = string.Format("The related Thing [{0}:{1}] is not a member of any of the required categories", relatedThing.ClassKind, relatedThing.Iid);

                            violations.Add(violation);
                        }
                    }
                }
            }

            return violations;
        }
    }
}