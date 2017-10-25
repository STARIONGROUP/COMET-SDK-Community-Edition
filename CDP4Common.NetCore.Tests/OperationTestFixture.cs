// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests
{
    using CDP4Common.DTO;
    using CDP4Common.Operations;
    using NUnit.Framework;

    [TestFixture]
    public class OperationTestFixture
    {
        [Test]
        public void VerifyThatPropertiesAreSetInConstructor()
        {
            var alias = new Alias();
            var aliasMod = new Alias();
            var operationKind = OperationKind.Create;

            var operation = new Operation(alias, aliasMod, operationKind);

            Assert.AreEqual(alias, operation.OriginalThing);
            Assert.AreEqual(operationKind, operation.OperationKind);
        }
    }
}
