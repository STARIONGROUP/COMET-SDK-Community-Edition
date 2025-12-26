// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GuidExtensionsTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.NetCore.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.Extensions;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="GuidExtensions"/>.
    /// </summary>
    [TestFixture]
    public class GuidExtensionsTestFixture
    {
        [Test]
        public void VerifyShortGuidRoundTrip()
        {
            var guid = Guid.NewGuid();

            var shortGuid = guid.ToShortGuid();
            var roundTrip = shortGuid.FromShortGuid();

            Assert.Multiple(() =>
            {
                Assert.That(shortGuid, Has.Length.EqualTo(22));
                Assert.That(shortGuid, Does.Not.Contain("/").And.Not.Contain("+"));
                Assert.That(roundTrip, Is.EqualTo(guid));
            });
        }

        [Test]
        public void VerifyShortGuidArrayRoundTrip()
        {
            var guids = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            var shortGuidArray = guids.ToShortGuidArray();
            var roundTrip = shortGuidArray.FromShortGuidArray().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(shortGuidArray.StartsWith("[") && shortGuidArray.EndsWith("]"), Is.True);
                Assert.That(roundTrip, Is.EqualTo(guids));
            });
        }

    }
}
