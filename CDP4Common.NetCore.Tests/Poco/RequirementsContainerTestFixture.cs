// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    internal class RequirementsContainerTestFixture
    {
        [Test]
        public void VerifyThatGetAllGroupsWorks()
        {
            var spec = new RequirementsSpecification();
            var grp1 = new RequirementsGroup();
            var grp11 = new RequirementsGroup();
            var grp111 = new RequirementsGroup();
            var grp12 = new RequirementsGroup();

            var grp2 = new RequirementsGroup();
            var grp21 = new RequirementsGroup();

            var grp3 = new RequirementsGroup();

            spec.Group.Add(grp1);
            spec.Group.Add(grp2);
            spec.Group.Add(grp3);

            grp1.Group.Add(grp11);
            grp1.Group.Add(grp12);

            grp11.Group.Add(grp111);

            grp2.Group.Add(grp21);

            var specAllGroups = spec.GetAllContainedGroups();
            Assert.AreEqual(7, specAllGroups.Count());

            var grp1AllGroup = grp1.GetAllContainedGroups();
            Assert.AreEqual(3, grp1AllGroup.Count());

            var grp2AllGroup = grp2.GetAllContainedGroups();
            Assert.AreEqual(1, grp2AllGroup.Count());
        }

        [Test]
        public void VerifyThatPathReturnsTheExpectedResultWithDefaultDelimiter()
        {
            var iteration = new Iteration();
            var spec = new RequirementsSpecification() { ShortName = "spec" };
            var group_a = new RequirementsGroup() { ShortName = "a" };
            var group_a_a = new RequirementsGroup() { ShortName = "a_a" };
            var group_a_a_a = new RequirementsGroup() { ShortName = "a_a_a" };

            iteration.RequirementsSpecification.Add(spec);

            Assert.AreEqual("a", group_a.Path());
            Assert.AreEqual("a_a", group_a_a.Path());
            Assert.AreEqual("a_a_a", group_a_a_a.Path());
            
            group_a_a.Group.Add(group_a_a_a);
            Assert.AreEqual("a_a.a_a_a", group_a_a_a.Path());

            group_a.Group.Add(group_a_a);
            Assert.AreEqual("a.a_a.a_a_a", group_a_a_a.Path());

            spec.Group.Add(group_a);
            Assert.AreEqual("spec.a.a_a.a_a_a", group_a_a_a.Path());
        }
        
        [Test]
        public void VerifyThatPathReturnsShortNameOfSpec()
        {
            var iteration = new Iteration();
            var spec = new RequirementsSpecification() { ShortName = "spec" };
            iteration.RequirementsSpecification.Add(spec);

            Assert.AreEqual("spec", spec.Path());
        }

        [Test]
        public void VerifyThatPathReturnsTheExpectedResultWithNonDefaultDelimiter()
        {
            var iteration = new Iteration();
            var spec = new RequirementsSpecification() { ShortName = "spec" };
            var group_a = new RequirementsGroup() { ShortName = "a" };
            var group_a_a = new RequirementsGroup() { ShortName = "a_a" };
            var group_a_a_a = new RequirementsGroup() { ShortName = "a_a_a" };

            iteration.RequirementsSpecification.Add(spec);

            Assert.AreEqual("a", group_a.Path(';'));
            Assert.AreEqual("a_a", group_a_a.Path(';'));
            Assert.AreEqual("a_a_a", group_a_a_a.Path(';'));

            group_a_a.Group.Add(group_a_a_a);
            Assert.AreEqual("a_a;a_a_a", group_a_a_a.Path(';'));

            group_a.Group.Add(group_a_a);
            Assert.AreEqual("a;a_a;a_a_a", group_a_a_a.Path(';'));

            spec.Group.Add(group_a);
            Assert.AreEqual("spec;a;a_a;a_a_a", group_a_a_a.Path(';'));
        }
    }
}