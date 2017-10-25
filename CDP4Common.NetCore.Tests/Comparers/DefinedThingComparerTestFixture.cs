// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThingComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class DefinedThingComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var type1 = new Requirement { Name = "a"};
            var type2 = new Requirement { Name = "c" };

            var comparer = new DefinedThingComparer();
            Assert.AreEqual(-2, comparer.Compare(type1, type2));

            Assert.AreEqual(2, comparer.Compare(type2, type1));

            Assert.AreEqual(0, comparer.Compare(type2, type2));
        }
    }
}