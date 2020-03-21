// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseComparerTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterBaseComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var type1 = new EnumerationParameterType { Name = "a"};
            var type2 = new EnumerationParameterType { Name = "c" };

            var para1 = new Parameter {ParameterType = type1};
            var para2 = new Parameter {ParameterType = type2};

            var comparer = new ParameterBaseComparer();
            Assert.AreEqual(-2, comparer.Compare(para1, para2));

            type1.Name = "d";
            Assert.AreEqual(1, comparer.Compare(para1, para2));

            type2.Name = "d";
            Assert.AreEqual(0, comparer.Compare(para1, para2));
        }

        [Test]
        public void TestComparer2()
        {
            var type1 = new CompoundParameterType { Name = "C" };
            var type2 = new BooleanParameterType { Name = "a" };

            var para1 = new Parameter { ParameterType = type1 };
            var para2 = new Parameter { ParameterType = type2 };

            var comparer = new ParameterBaseComparer();
            Assert.AreEqual(2, comparer.Compare(para1, para2));
        }
    }
}