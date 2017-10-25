// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DecompositionRule.cs" company="RHEA System S.A.">
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
    /// representation of a validation rule for system-of-interest decomposition through <i>containingElement</i> ElementDefinitions and <i>containedElement</i> ElementUsages
    /// Note: A DecompositionRule specifies for ElementDefinitions that are a member of the <i>containingCategory</i> what are the valid Categories (specified by <i>containedCategory</i>) for the <i>type</i> of contained ElementUsages. A <i>subCategory</i> of a valid Category is also valid.
    /// Example: A rule where the <i>containingCategory</i> is Category "Equipment" and the <i>containedCategory</i> is Category "Subequipment".
    /// </summary>
    public partial class DecompositionRule : IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to the <see cref="DecompositionRule"/> 
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

            var elementDefinitions = iteration.Element;
            if (elementDefinitions.Count == 0)
            {
                return Enumerable.Empty<RuleViolation>();
            }

            var violations = new List<RuleViolation>();

            foreach (var elementDefinition in elementDefinitions)
            {
                if (elementDefinition.IsMemberOfCategory(this.ContainingCategory) && elementDefinition.ContainedElement.Count != 0)
                {
                    var validUsages = new List<ElementUsage>();

                    violations.AddRange(this.VerifyValidUsages(elementDefinition, ref validUsages));

                    if (validUsages.Count < this.MinContained)
                    {
                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.ViolatingThing.Add(elementDefinition.Iid);
                        violation.Description = string.Format("The Element Definition {0} does not contain the minimum of {1} Element Usages specified", elementDefinition.Iid, this.MinContained);

                        violations.Add(violation);
                    }

                    if (this.MaxContained != null && validUsages.Count > this.MaxContained.Value)
                    {
                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.ViolatingThing.Add(elementDefinition.Iid);
                        violation.Description = string.Format("The Element Definition {0} contains more Element Usages than the maximum of {1} specified", elementDefinition.Iid, this.MaxContained.Value);

                        violations.Add(violation);
                    }
                }
            }

            return violations;
        }

        /// <summary>
        /// Verifies that the contained <see cref="ElementUsage"/>s of the  <paramref name="elementDefinition"/> are a member of the allowed categories
        /// </summary>
        /// <param name="elementDefinition">
        /// The <see cref="ElementDefinition"/> that is to be verified.
        /// </param> 
        /// <param name="validElementUsages">
        /// The valid <see cref="ElementUsage"/> that are contained by the <paramref name="elementDefinition"/>.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{RuleViolation}"/> that may contains <see cref="RuleViolation"/> if any of the contained <see cref="ElementUsage"/>s
        /// is not of the correct type.
        /// </returns>
        private IEnumerable<RuleViolation> VerifyValidUsages(ElementDefinition elementDefinition, ref List<ElementUsage> validElementUsages)
        {
            var violations = new List<RuleViolation>();

            foreach (var elementUsage in elementDefinition.ContainedElement)
            {
                var isValidUsage = false;

                foreach (var category in this.ContainedCategory)
                {
                    var isElementUsageAMember = elementUsage.IsMemberOfCategory(category);
                    if (isElementUsageAMember)
                    {
                        isValidUsage = true;
                        continue;
                    }

                    var isElementDefinitionAMember = elementUsage.ElementDefinition.IsMemberOfCategory(category);
                    if (isElementDefinitionAMember)
                    {
                        isValidUsage = true;
                        continue;
                    }
                }

                if (!isValidUsage)
                {
                    var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                    violation.ViolatingThing.Add(elementDefinition.Iid);
                    violation.ViolatingThing.Add(elementUsage.Iid);
                    violation.Description = string.Format("The Element Definition {0} contains an Element Usage {1} of an incorrect type", elementDefinition.Iid, elementUsage.Iid);

                    violations.Add(violation);
                }
                else
                {
                    validElementUsages.Add(elementUsage);                    
                }
            }

            return violations;
        }
    }
}
