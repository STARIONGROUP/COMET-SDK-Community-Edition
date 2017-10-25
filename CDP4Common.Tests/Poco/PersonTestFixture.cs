// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.Polyfills;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    public class PersonTestFixture
    {
        [Test]
        public void TestGetNAme()
        {
            var perosn = new Person();
            perosn.GivenName = "givenname";
            perosn.Surname = "surname";

            Assert.AreEqual("givenname surname", perosn.Name);
            
            var pocos = typeof(Thing).QueryAssembly().GetTypes().Where(x => (x.QueryBaseType() != null) && x.QueryBaseType().QueryIsSubclassOf(typeof(Thing)));
            foreach (var poco in pocos)
            {
                var field = poco.QueryField("DefaultPersonAccess");
                if (field != null)
                {
                    var test = (PersonAccessRightKind)field.GetRawConstantValue();
                }
            }
        }
    }
}