// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationshipRule.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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