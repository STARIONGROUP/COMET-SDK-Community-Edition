// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonRoleTestFixture.cs" company="RHEA System S.A.">
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
    internal class PersonRoleTestFixture
    {
        [Test]
        public void VerifyPopulatePersonPermissions()
        {
            var personRole = new PersonRole();
            Assert.AreEqual(17, personRole.PersonPermission.Count);
            Assert.IsTrue(personRole.PersonPermission.All(x => x.AccessRight == PersonAccessRightKind.NONE));
        }
    }
}