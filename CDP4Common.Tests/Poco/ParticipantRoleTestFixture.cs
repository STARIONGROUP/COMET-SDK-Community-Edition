// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRoleTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Naron Phou, Patxi Ozkoidi, Alexander van Delft, Nathanael Smiechowski, Ahmed Ahmed, Simon Wood
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    
    using NUnit.Framework;

    [TestFixture]
    internal class ParticipantRoleTestFixture
    {
        [Test]
        public void VerifyPopulateParticipantPermissions()
        {
            var participantRole = new ParticipantRole();
            Assert.AreEqual(49, participantRole.ParticipantPermission.Count);
            Assert.IsTrue(participantRole.ParticipantPermission.All(x => x.AccessRight == ParticipantAccessRightKind.NONE));
        }
    }
}
