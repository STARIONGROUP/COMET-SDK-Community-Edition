// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementDefinitionComparerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Comparers
{
    using CDP4Common.Comparers;
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;

    [TestFixture]
    internal class ElementDefinitionComparerTestFixture
    {
        [Test]
        public void TestComparer()
        {
            var usage1 = new ElementDefinition { Name = "type1" };
            var usage2 = new ElementDefinition { Name = "type5" };

            var comparer = new ElementDefinitionComparer();
            Assert.AreEqual(-4, comparer.Compare(usage1, usage2));
        }
    }
}