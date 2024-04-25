// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
            Assert.That(specAllGroups.Count(), Is.EqualTo(7));

            var grp1AllGroup = grp1.GetAllContainedGroups();
            Assert.That(grp1AllGroup.Count(), Is.EqualTo(3));

            var grp2AllGroup = grp2.GetAllContainedGroups();
            Assert.That(grp2AllGroup.Count(), Is.EqualTo(1));
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

            Assert.That(group_a.Path(), Is.EqualTo("a"));
            Assert.That(group_a_a.Path(), Is.EqualTo("a_a"));
            Assert.That(group_a_a_a.Path(), Is.EqualTo("a_a_a"));
            
            group_a_a.Group.Add(group_a_a_a);
            Assert.That(group_a_a_a.Path(), Is.EqualTo("a_a.a_a_a"));

            group_a.Group.Add(group_a_a);
            Assert.That(group_a_a_a.Path(), Is.EqualTo("a.a_a.a_a_a"));

            spec.Group.Add(group_a);
            Assert.That(group_a_a_a.Path(), Is.EqualTo("spec.a.a_a.a_a_a"));
        }
        
        [Test]
        public void VerifyThatPathReturnsShortNameOfSpec()
        {
            var iteration = new Iteration();
            var spec = new RequirementsSpecification() { ShortName = "spec" };
            iteration.RequirementsSpecification.Add(spec);

            Assert.That(spec.Path(), Is.EqualTo("spec"));
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

            Assert.That(group_a.Path(';'), Is.EqualTo("a"));
            Assert.That(group_a_a.Path(';'), Is.EqualTo("a_a"));
            Assert.That(group_a_a_a.Path(';'), Is.EqualTo("a_a_a"));

            group_a_a.Group.Add(group_a_a_a);
            Assert.That(group_a_a_a.Path(';'), Is.EqualTo("a_a;a_a_a"));

            group_a.Group.Add(group_a_a);
            Assert.That(group_a_a_a.Path(';'), Is.EqualTo("a;a_a;a_a_a"));

            spec.Group.Add(group_a);
            Assert.That(group_a_a_a.Path(';'), Is.EqualTo("spec;a;a_a;a_a_a"));
        }
    }
}