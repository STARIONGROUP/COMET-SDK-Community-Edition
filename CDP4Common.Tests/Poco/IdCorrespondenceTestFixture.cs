﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdCorrespondenceTestFixture.cs" company="Starion Group S.A.">
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
    using System;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    public class IdCorrespondenceTestFixture
    {
        [Test]
        public void VerifyGetOwner()
        {
            var thing = new IdCorrespondence(Guid.NewGuid(), null, null);
            var externalIdentifierMap = new ExternalIdentifierMap(Guid.NewGuid(), null, null);
            externalIdentifierMap.Owner = new DomainOfExpertise(Guid.NewGuid(), null, null);

            thing.Container = externalIdentifierMap;

            Assert.That(ReferenceEquals(thing.Owner, externalIdentifierMap.Owner), Is.True);
        }

        [Test]
        public void VerifyGetOwnerThrowException()
        {
            var thing = new IdCorrespondence(Guid.NewGuid(), null, null);

            Assert.That(() => { Console.WriteLine(thing.Owner); }, Throws.TypeOf<ContainmentException>());
        }
    }
}