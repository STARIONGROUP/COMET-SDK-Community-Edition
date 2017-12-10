// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAttributeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests
{
    using CDP4Common;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Test fixture for the <see cref="ContainerAttribute"/> class
    /// </summary>
    [TestFixture]
    public class ContainerAttributeTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsProperties()
        {
            var propertyName = "EmailAddress";
            var containerPropertyNameAttribute = new ContainerAttribute(typeof(Person), propertyName);

            Assert.AreEqual(propertyName, containerPropertyNameAttribute.PropertyName);
            Assert.AreEqual(typeof(Person), containerPropertyNameAttribute.ClassType);
        }
    }
}
