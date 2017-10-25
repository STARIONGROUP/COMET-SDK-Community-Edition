// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterizedCategoryRule.cs" company="RHEA System S.A.">
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
    /// Rule that asserts that one or more parameters of a given <see cref="ParameterType"/> should be defined for CategorizableThings that are a member of the associated Category
    /// </summary>
    public partial class ParameterizedCategoryRule : IRuleVerification
    {
        /// <summary>
        /// Verify an <see cref="Iteration"/> with respect to the <see cref="ParameterizedCategoryRule"/> 
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

            if (this.Category == null)
            {
                throw new InvalidOperationException("The Category of the Rule is null. The Rule cannot be verified.");
            }

            if (iteration.Element.Count == 0)
            {
                return Enumerable.Empty<RuleViolation>();
            }

            if (this.ParameterType.Count == 0)
            {
                return Enumerable.Empty<RuleViolation>();
            }

            var violations = new List<RuleViolation>();

            this.VerifyRelationship(iteration, violations);
            this.VerifySpecification(iteration, violations);
            this.VerifyElementDefinition(iteration, violations);

            return violations;
        }

        /// <summary>
        /// Verify the <see cref="ElementDefinition"/> against this <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to check</param>
        /// <param name="violations">The collection of <see cref="RuleViolation"/> to update</param>
        private void VerifyElementDefinition(Iteration iteration, List<RuleViolation> violations)
        {
            foreach (var elementDefinition in iteration.Element)
            {
                if (elementDefinition.IsMemberOfCategory(this.Category))
                {
                    var missingParameterTypes = new List<ParameterType>();
                    foreach (var parameterType in this.ParameterType)
                    {
                        var parameter = elementDefinition.Parameter.SingleOrDefault(p => p.ParameterType == parameterType);
                        if (parameter == null)
                        {
                            missingParameterTypes.Add(parameterType);
                        }
                    }

                    if (missingParameterTypes.Count > 0)
                    {
                        var iids = string.Join(",", missingParameterTypes.Select(x => x.Iid));
                        var shortnames = string.Join(",", missingParameterTypes.Select(x => x.ShortName));

                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.RuleViolatedClassKind.Add(elementDefinition.ClassKind);
                        violation.ViolatingThing.Add(elementDefinition.Iid);
                        violation.Description = string.Format("The Element Definition {0} does not contain parameters that reference the following parameter types {1} with shortnames: {2}", elementDefinition.Name, iids, shortnames);

                        violations.Add(violation);
                    }
                }
            }
        }

        /// <summary>
        /// Verify the <see cref="Relationship"/> against this <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to check</param>
        /// <param name="violations">The collection of <see cref="RuleViolation"/> to update</param>
        private void VerifyRelationship(Iteration iteration, List<RuleViolation> violations)
        {
            foreach (var relationship in iteration.Relationship)
            {
                if (relationship.IsMemberOfCategory(this.Category))
                {
                    var missingParameterTypes = new List<ParameterType>();
                    foreach (var parameterType in this.ParameterType)
                    {
                        var parameter = relationship.ParameterValue.SingleOrDefault(p => p.ParameterType == parameterType);
                        if (parameter == null)
                        {
                            missingParameterTypes.Add(parameterType);
                        }
                    }

                    if (missingParameterTypes.Count > 0)
                    {
                        var iids = string.Join(",", missingParameterTypes.Select(x => x.Iid));
                        var shortnames = string.Join(",", missingParameterTypes.Select(x => x.ShortName));

                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.RuleViolatedClassKind.Add(relationship.ClassKind);
                        violation.ViolatingThing.Add(relationship.Iid);
                        violation.Description = string.Format("The Relationship {0} does not contain parameters that reference the following parameter types {1} with shortnames: {2}", relationship.Iid, iids, shortnames);

                        violations.Add(violation);
                    }
                }
            }
        }

        /// <summary>
        /// Verify the <see cref="Relationship"/> against this <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="iteration">The <see cref="Iteration"/> to check</param>
        /// <param name="violations">The collection of <see cref="RuleViolation"/> to update</param>
        private void VerifySpecification(Iteration iteration, List<RuleViolation> violations)
        {
            foreach (var specificaton in iteration.RequirementsSpecification)
            {
                if (specificaton.IsMemberOfCategory(this.Category))
                {
                    var missingParameterTypes = new List<ParameterType>();
                    foreach (var parameterType in this.ParameterType)
                    {
                        var parameter = specificaton.ParameterValue.SingleOrDefault(p => p.ParameterType == parameterType);
                        if (parameter == null)
                        {
                            missingParameterTypes.Add(parameterType);
                        }
                    }

                    if (missingParameterTypes.Count > 0)
                    {
                        var iids = string.Join(",", missingParameterTypes.Select(x => x.Iid));
                        var shortnames = string.Join(",", missingParameterTypes.Select(x => x.ShortName));

                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.RuleViolatedClassKind.Add(specificaton.ClassKind);
                        violation.ViolatingThing.Add(specificaton.Iid);
                        violation.Description = string.Format("The RequirementsSpecification {0} does not contain parameters that reference the following parameter types {1} with shortnames: {2}", specificaton.Name, iids, shortnames);

                        violations.Add(violation);
                    }
                }

                this.VerifyGroup(specificaton, violations);
                this.VerifyRequirement(specificaton, violations);
            }
        }

        /// <summary>
        /// Verify the <see cref="RequirementsGroup"/> against this <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="requirementsContainer">The <see cref="RequirementsContainer"/> container to check</param>
        /// <param name="violations">The collection of <see cref="RuleViolation"/> to update</param>
        private void VerifyGroup(RequirementsContainer requirementsContainer, List<RuleViolation> violations)
        {
            foreach (var group in requirementsContainer.Group)
            {
                if (group.IsMemberOfCategory(this.Category))
                {
                    var missingParameterTypes = new List<ParameterType>();
                    foreach (var parameterType in this.ParameterType)
                    {
                        var parameter = group.ParameterValue.SingleOrDefault(p => p.ParameterType == parameterType);
                        if (parameter == null)
                        {
                            missingParameterTypes.Add(parameterType);
                        }
                    }

                    if (missingParameterTypes.Count > 0)
                    {
                        var iids = string.Join(",", missingParameterTypes.Select(x => x.Iid));
                        var shortnames = string.Join(",", missingParameterTypes.Select(x => x.ShortName));

                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.RuleViolatedClassKind.Add(group.ClassKind);
                        violation.ViolatingThing.Add(group.Iid);
                        violation.Description = string.Format("The RequirementsGroup {0} does not contain parameters that reference the following parameter types {1} with shortnames: {2}", group.Name, iids, shortnames);

                        violations.Add(violation);
                    }
                }

                this.VerifyGroup(group, violations);
            }
        }

        /// <summary>
        /// Verify the <see cref="RequirementsGroup"/> against this <see cref="ParameterizedCategoryRule"/>
        /// </summary>
        /// <param name="specification">The <see cref="RequirementsSpecification"/> container to check</param>
        /// <param name="violations">The collection of <see cref="RuleViolation"/> to update</param>
        private void VerifyRequirement(RequirementsSpecification specification, List<RuleViolation> violations)
        {
            foreach (var requirement in specification.Requirement)
            {
                if (requirement.IsMemberOfCategory(this.Category))
                {
                    var missingParameterTypes = new List<ParameterType>();
                    foreach (var parameterType in this.ParameterType)
                    {
                        var parameter = requirement.ParameterValue.SingleOrDefault(p => p.ParameterType == parameterType);
                        if (parameter == null)
                        {
                            missingParameterTypes.Add(parameterType);
                        }
                    }

                    if (missingParameterTypes.Count > 0)
                    {
                        var iids = string.Join(",", missingParameterTypes.Select(x => x.Iid));
                        var shortnames = string.Join(",", missingParameterTypes.Select(x => x.ShortName));

                        var violation = new RuleViolation(Guid.NewGuid(), this.Cache, this.IDalUri);
                        violation.RuleViolatedClassKind.Add(requirement.ClassKind);
                        violation.ViolatingThing.Add(requirement.Iid);
                        violation.Description = string.Format("The Requirement {0} does not contain parameters that reference the following parameter types {1} with shortnames: {2}", requirement.Name, iids, shortnames);

                        violations.Add(violation);
                    }
                }
            }
        }
    }
}
