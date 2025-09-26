// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompoundParameterTypeTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class CompoundParameterTypeTestFixture
    {
        [Test]
        public void VerifyThatNumberOfValuesIsCorrect()
        {
            var compound = new CompoundParameterType();

            var compound2 = new CompoundParameterType();
            var scalar = new EnumerationParameterType();

            var scalarc1 = new ParameterTypeComponent() {ParameterType = scalar};
            compound2.Component.Add(scalarc1);

            var compound2Component = new ParameterTypeComponent() {ParameterType = compound2};

            compound.Component.Add(compound2Component);
            compound.Component.Add(scalarc1);

            Assert.That(compound.NumberOfValues, Is.EqualTo(2));
        }
    }
}
