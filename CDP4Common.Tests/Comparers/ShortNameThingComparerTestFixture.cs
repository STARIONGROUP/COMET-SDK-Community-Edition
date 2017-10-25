// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShortNameThingComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ShortNameThingComparer"/> class
    /// </summary>
    [TestFixture]
    public class ShortNameThingComparerTestFixture
    {
        private DomainOfExpertise domainOfExpertise_1;
        private DomainOfExpertise domainOfExpertise_2;
        private ShortNameThingComparer comparer;

        [SetUp]
        public void SetUp()
        {
            this.comparer = new ShortNameThingComparer();

            this.domainOfExpertise_1 = new DomainOfExpertise();
            this.domainOfExpertise_2 = new DomainOfExpertise();
        }

        [Test]
        public void VerifyThatCompareIsCaseInsensitive()
        {
            this.domainOfExpertise_1.ShortName = "a";
            this.domainOfExpertise_2.ShortName = "A";
            
            Assert.AreEqual(0, this.comparer.Compare(this.domainOfExpertise_1, this.domainOfExpertise_2));            
        }
    }
}
