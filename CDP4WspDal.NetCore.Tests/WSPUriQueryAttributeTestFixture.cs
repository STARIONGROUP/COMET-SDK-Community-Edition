// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WSPUriQueryAttributeTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2015-2018 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4WspDal.Tests
{
    using CDP4Dal.DAL.ECSS1025AnnexC;

    using NUnit.Framework;

    [TestFixture]
    public class WspUriQueryAttributeTestFixture
    {
        private QueryAttributes attributes;

        [SetUp]
        public void Setup()
        {
            this.attributes = new QueryAttributes();;
        }

        [Test]
        public void TestToString()
        {
            this.attributes.Extent = ExtentQueryAttribute.deep;
            this.attributes.IncludeAllContainers = true;
            this.attributes.IncludeFileData = true;
            this.attributes.IncludeReferenceData = true;
            this.attributes.RevisionNumber = 2;

            var test = this.attributes.ToString();
            Assert.IsTrue(test.Contains("extent"));
            Assert.IsTrue(test.Contains("includeReferenceData"));
            Assert.IsTrue(test.Contains("includeAllContainers"));
            Assert.IsTrue(test.Contains("includeFileData"));
            Assert.IsTrue(test.Contains("revisionNumber"));
        }

        [Test]
        public void TestEmptyAttributeToString()
        {
            var str = this.attributes.ToString();
            Assert.AreEqual(string.Empty, str);
        }
    }
}
