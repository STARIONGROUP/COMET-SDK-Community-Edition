// -------------------------------------------------------------------------------------------------
// <copyright file="PostOperationTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

using CDP4Common;

namespace CDP4Dal.Tests
{
    using System.Collections.Generic;
    using CDP4Common.DTO;
    using CDP4Dal.Operations;
    using NUnit.Framework;

    [TestFixture]
    public class PostOperationTestFixture
    {
        [Test]
        public void VerifyThatConstructorSetsLists()
        {
            var testPostOperation = new TestPostOperation();
            Assert.IsNotNull(testPostOperation.Delete);
            Assert.IsNotNull(testPostOperation.Create);
            Assert.IsNotNull(testPostOperation.Update);
            Assert.IsNotNull(testPostOperation.Copy);           
        }
    }

    internal class TestPostOperation : PostOperation
    {
        public override List<ClasslessDTO> Delete { get; set; }
        public override List<Thing> Create { get; set; }
        public override List<ClasslessDTO> Update { get; set; }
        public override List<ClasslessDTO> Copy { get; set; }
        public override void ConstructFromOperation(Operation operation)
        {
            throw new System.NotImplementedException();
        }
    }
}
