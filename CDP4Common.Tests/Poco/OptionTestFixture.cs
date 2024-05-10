// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2020 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

            Assert.That(option1.IsDefault, Is.True);
            Assert.That(option2.IsDefault, Is.False);
        }

        [Test]
        public void VerifyGetNestedParameterValuesByPath()
        {
            var nestedElementTreeGeneratorTestFixture = new NestedElementTreeGeneratorTestFixture();
            nestedElementTreeGeneratorTestFixture.SetUp();

            var option = nestedElementTreeGeneratorTestFixture.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var doubleParameters = option.GetNestedParameterValuesByPath<double>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(doubleParameters.Count, Is.EqualTo(1));
            Assert.That(doubleParameters.First(), Is.EqualTo(3D));

            var stringParameters = option.GetNestedParameterValuesByPath<string>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(stringParameters.Count, Is.EqualTo(1));
            Assert.That(stringParameters.First(), Is.EqualTo("3"));

            Assert.That(() => option.GetNestedParameterValuesByPath<bool>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise), Throws.TypeOf<FormatException>());

            var objectParameters = option.GetNestedParameterValuesByPath<object>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(objectParameters.Count, Is.EqualTo(1));
            Assert.That(Convert.ChangeType(objectParameters.Single(), typeof(double)), Is.EqualTo(3D));
            Assert.That(Convert.ChangeType(objectParameters.Single(), typeof(string)), Is.EqualTo("3"));

            var domainCheckParameters = option.GetNestedParameterValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(domainCheckParameters.Count, Is.EqualTo(0));

            var domainCheckParametersWithCorrectDomain = option.GetNestedParameterValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise_2).ToList();
            Assert.That(domainCheckParametersWithCorrectDomain.Count, Is.EqualTo(1));
            Assert.That(domainCheckParametersWithCorrectDomain.First(), Is.EqualTo(220D));

            var domain2CheckParameters = option.GetNestedParameterValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A").ToList();
            Assert.That(domain2CheckParameters.Count, Is.EqualTo(1));
            Assert.That(domain2CheckParameters.First(), Is.EqualTo(220D));

            var defaultValueCheckParameter = option.GetNestedParameterValuesByPath<double>(@"Sat.bat_b\v\2\OPT_A").ToList();
            Assert.That(defaultValueCheckParameter.Count, Is.EqualTo(1));
            Assert.That(defaultValueCheckParameter.First(), Is.EqualTo(0D));
        }

        [Test]
        public void VerifyGetNestedPublishedParameterValuesByPath()
        {
            var nestedElementTreeGeneratorTestFixture = new NestedElementTreeGeneratorTestFixture();
            nestedElementTreeGeneratorTestFixture.SetUp();

            var option = nestedElementTreeGeneratorTestFixture.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var doubleParameters = option.GetNestedParameterPublishedValuesByPath<double>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(doubleParameters.Count, Is.EqualTo(1));
            Assert.That(doubleParameters.Single(), Is.EqualTo(123));

            var stringParameters = option.GetNestedParameterPublishedValuesByPath<string>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(stringParameters.Count, Is.EqualTo(1));
            Assert.That(stringParameters.Single(), Is.EqualTo("123"));

            Assert.That(() => option.GetNestedParameterPublishedValuesByPath<bool>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise), Throws.TypeOf<FormatException>());

            var objectParameters = option.GetNestedParameterPublishedValuesByPath<object>(@"Sat\m\\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(objectParameters.Count, Is.EqualTo(1));
            Assert.That(Convert.ChangeType(objectParameters.Single(), typeof(double)), Is.EqualTo(123));
            Assert.That(Convert.ChangeType(objectParameters.Single(), typeof(string)), Is.EqualTo("123"));

            var domainCheckParameters = option.GetNestedParameterPublishedValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise).ToList();
            Assert.That(domainCheckParameters.Count, Is.EqualTo(0));

            var domainCheckParametersWithCorrectDomain = option.GetNestedParameterPublishedValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A", nestedElementTreeGeneratorTestFixture.domainOfExpertise_2).ToList();
            Assert.That(domainCheckParametersWithCorrectDomain.Count, Is.EqualTo(1));
            Assert.That(domainCheckParametersWithCorrectDomain.Single(), Is.EqualTo(0D));

            var domain2CheckParameters = option.GetNestedParameterPublishedValuesByPath<double>(@"Sat.bat_b\v\1\OPT_A").ToList();
            Assert.That(domain2CheckParameters.Count, Is.EqualTo(1));
            Assert.That(domain2CheckParameters.Single(), Is.EqualTo(0D));

            var defaultValueCheckParameter = option.GetNestedParameterPublishedValuesByPath<double>(@"Sat.bat_b\v\2\OPT_A").ToList();
            Assert.That(defaultValueCheckParameter.Count, Is.EqualTo(1));
            Assert.That(defaultValueCheckParameter.Single(), Is.EqualTo(123D));
        }
    }
}
