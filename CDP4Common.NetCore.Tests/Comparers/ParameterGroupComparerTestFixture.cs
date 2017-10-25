// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterGroupComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    internal class ParameterGroupComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var para1 = new ParameterGroup { Name = "type1" };
            var para2 = new ParameterGroup { Name = "type5" };

            var comparer = new ParameterGroupComparer();
            Assert.AreEqual(-4, comparer.Compare(para1, para2));
        }
    }
}