// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementUsageComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    internal class ElementUsageComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var usage1 = new ElementUsage { Name = "type1" };
            var usage2 = new ElementUsage { Name = "type5" };

            var comparer = new ElementUsageComparer();
            Assert.AreEqual(-4, comparer.Compare(usage1, usage2));
        }
    }
}