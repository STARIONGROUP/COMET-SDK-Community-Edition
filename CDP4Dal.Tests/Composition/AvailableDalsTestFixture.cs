// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableDalsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.Composition
{
    using System;
    using System.Collections.Generic;

    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class AvailableDalsTestFixture
    {
        [Test]
        public void VerifyThatDataAccessLayerKindsAreCopied()
        {
            var dalMock = new Mock<IDal>();
            var metadataMock = new Mock<IDalMetaData>();
            metadataMock.SetupGet(x => x.Name).Returns("Test DAL");
            metadataMock.SetupGet(x => x.Description).Returns("description");
            metadataMock.SetupGet(x => x.DalType).Returns(DalType.Web);
            metadataMock.SetupGet(x => x.CDPVersion).Returns("1.0");

            var availableDals = new AvailableDals(new[]
            {
                new Lazy<IDal, IDalMetaData>(() => dalMock.Object, metadataMock.Object)
            });

            Assert.That(availableDals.DataAccessLayerKinds, Has.Count.EqualTo(1));
            Assert.That(availableDals.DataAccessLayerKinds[0].Metadata.Name, Is.EqualTo("Test DAL"));
            Assert.That(availableDals.DataAccessLayerKinds[0].Value, Is.EqualTo(dalMock.Object));
        }

        [Test]
        public void VerifyThatDataAccessLayerKindsAreIndependentFromInputCollection()
        {
            var input = new List<Lazy<IDal, IDalMetaData>>();

            var availableDals = new AvailableDals(input);

            input.Add(new Lazy<IDal, IDalMetaData>(() => Mock.Of<IDal>(), new TestDalMetadata()));

            Assert.That(availableDals.DataAccessLayerKinds, Is.Empty);
        }

        private class TestDalMetadata : IDalMetaData
        {
            public string Name => "test";

            public string Description => "test description";

            public DalType DalType => DalType.Web;

            public string CDPVersion => "1.0";
        }
    }
}
