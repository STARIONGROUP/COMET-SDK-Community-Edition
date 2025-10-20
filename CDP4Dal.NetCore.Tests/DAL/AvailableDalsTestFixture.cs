// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableDalsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.NetCore.Tests.DAL
{
    using System;
    using System.Collections.Generic;
    using CDP4Dal;
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="AvailableDals"/>.
    /// </summary>
    [TestFixture]
    public class AvailableDalsTestFixture
    {
        [Test]
        public void VerifyThatConstructorCopiesProvidedDalKinds()
        {
            var firstDal = new Lazy<IDal, IDalMetaData>(() => Mock.Of<IDal>(), new TestDalMetaData("first"));
            var secondDal = new Lazy<IDal, IDalMetaData>(() => Mock.Of<IDal>(), new TestDalMetaData("second"));
            var provided = new List<Lazy<IDal, IDalMetaData>> { firstDal, secondDal };

            var availableDals = new AvailableDals(provided);

            Assert.Multiple(() =>
            {
                Assert.That(availableDals.DataAccessLayerKinds, Is.Not.SameAs(provided));
                Assert.That(availableDals.DataAccessLayerKinds, Is.EquivalentTo(provided));
            });

            provided.Add(new Lazy<IDal, IDalMetaData>(() => Mock.Of<IDal>(), new TestDalMetaData("third")));

            Assert.That(availableDals.DataAccessLayerKinds, Has.Count.EqualTo(2));
        }

        private sealed class TestDalMetaData : IDalMetaData
        {
            public TestDalMetaData(string name)
            {
                this.Name = name;
            }

            public DalType DalType => DalType.Web;

            public string CDPVersion => "1";

            public string Name { get; }

            public string Description => this.Name;
        }
    }
}
