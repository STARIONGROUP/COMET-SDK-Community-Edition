#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RequirementsContainerTestFixture.cs" company="RHEA System S.A.">
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