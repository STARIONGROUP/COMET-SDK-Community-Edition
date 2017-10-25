// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    public class RequirementTestFixture
    {
        [Test]
        public void VerifyThatInvalidOperationIsThrownWhenContainerIsNotSet()
        {
            var requirement = new Requirement();
            Assert.Throws<InvalidOperationException>(() => requirement.GroupPath());
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenGroupedAndDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };
            requirementsSpecification.Requirement.Add(requirement);
            
            var requirementsGroupA = new RequirementsGroup() {ShortName = "a"};
            var requirementsGroupAA = new RequirementsGroup() { ShortName = "a_a" };

            requirementsGroupA.Group.Add(requirementsGroupAA);
            requirementsSpecification.Group.Add(requirementsGroupA);

            requirement.Group = requirementsGroupAA;

            Assert.AreEqual("spec.a.a_a.req", requirement.GroupPath());
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenGroupedAndNonDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };
            requirementsSpecification.Requirement.Add(requirement);

            var requirementsGroupA = new RequirementsGroup() { ShortName = "a" };
            var requirementsGroupAA = new RequirementsGroup() { ShortName = "a_a" };

            requirementsGroupA.Group.Add(requirementsGroupAA);
            requirementsSpecification.Group.Add(requirementsGroupA);

            requirement.Group = requirementsGroupAA;

            Assert.AreEqual("spec;a;a_a;req", requirement.GroupPath(';'));
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.AreEqual("spec.req", requirement.GroupPath());            
        }

        [Test]
        public void VerifyThatGroupPathReturnsExpectedResultWhenNotGroupedAndNonDefaultDelimiterIsUsed()
        {
            var requirementsSpecification = new RequirementsSpecification() { ShortName = "spec" };
            var requirement = new Requirement() { ShortName = "req" };

            requirementsSpecification.Requirement.Add(requirement);

            Assert.AreEqual("spec,req", requirement.GroupPath(','));
        }
    }
}
