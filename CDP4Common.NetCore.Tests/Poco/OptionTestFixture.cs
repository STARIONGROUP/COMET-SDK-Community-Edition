// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Tests.Helpers;

    using NUnit.Framework;

    [TestFixture]
    internal class OptionTestFixture
    {
        [Test]
        public void VerifyThatIsDefaultWorks()
        {
            var iteration = new Iteration();
            var option1 = new Option();
            var option2 = new Option();

            iteration.Option.Add(option1);
            iteration.Option.Add(option2);
            iteration.DefaultOption = option1;

            Assert.IsTrue(option1.IsDefault);
            Assert.IsFalse(option2.IsDefault);
        }

        [Test]
        public void VerifyGetNestedParameterValuesByPath()
        {
            var nestedElementTreeGeneratorTestFixture = new NestedElementTreeGeneratorTestFixture();
            nestedElementTreeGeneratorTestFixture.SetUp();

            var option = nestedElementTreeGeneratorTestFixture.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var doubleParameters = option.GetNestedParameterValuesByPath<double>("Sat\\m\\\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise);
            Assert.AreEqual(2, doubleParameters.Count());
            Assert.AreEqual(2D, doubleParameters.First());
            Assert.AreEqual(3D, doubleParameters.Last());

            var stringParameters = option.GetNestedParameterValuesByPath<string>("Sat\\m\\\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise);
            Assert.AreEqual(2, stringParameters.Count());
            Assert.AreEqual("2", stringParameters.First());
            Assert.AreEqual("3", stringParameters.Last());

            Assert.Throws<FormatException>(() => option.GetNestedParameterValuesByPath<bool>("Sat\\m\\\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise));
        }
    }
}