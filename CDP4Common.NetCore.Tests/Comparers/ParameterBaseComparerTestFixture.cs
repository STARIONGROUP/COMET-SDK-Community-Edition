// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterBaseComparerTestFixture.cs" company="RHEA System S.A.">
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
    internal class ParameterBaseComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var type1 = new EnumerationParameterType { Name = "a"};
            var type2 = new EnumerationParameterType { Name = "c" };

            var para1 = new Parameter {ParameterType = type1};
            var para2 = new Parameter {ParameterType = type2};

            var comparer = new ParameterBaseComparer();
            Assert.AreEqual(-2, comparer.Compare(para1, para2));

            type1.Name = "d";
            Assert.AreEqual(1, comparer.Compare(para1, para2));

            type2.Name = "d";
            Assert.AreEqual(0, comparer.Compare(para1, para2));
        }

        [Test]
        public void TestComparer2()
        {
            var type1 = new CompoundParameterType { Name = "C" };
            var type2 = new BooleanParameterType { Name = "a" };

            var para1 = new Parameter { ParameterType = type1 };
            var para2 = new Parameter { ParameterType = type2 };

            var comparer = new ParameterBaseComparer();
            Assert.AreEqual(2, comparer.Compare(para1, para2));
        }
    }
}