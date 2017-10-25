// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DerivedQuantityKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DerivedQuantityKind"/> class.
    /// </summary>
    [TestFixture]
    public class DerivedQuantityKindTestFixture
    {
        private DerivedQuantityKind derivedQuantityKind;

        [Test]
        public void VerifyThatErrorListContainsErrorWhenNoPossibleScalesAreSet()
        {
            this.derivedQuantityKind = new DerivedQuantityKind();
            this.derivedQuantityKind.ValidatePoco();

            CollectionAssert.Contains(this.derivedQuantityKind.ValidationErrors, "The PossibleScale property is empty.");
        }
    }
}
