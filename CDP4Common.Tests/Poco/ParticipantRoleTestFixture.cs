// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRoleTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
            Assert.AreEqual(48, participantRole.ParticipantPermission.Count);
            Assert.IsTrue(participantRole.ParticipantPermission.All(x => x.AccessRight == ParticipantAccessRightKind.NONE));
        }
    }
}