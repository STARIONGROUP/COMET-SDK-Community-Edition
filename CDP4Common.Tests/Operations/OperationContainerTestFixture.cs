// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationContainerTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests
{
    using System;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Operations;
    using CDP4Common.Types;

    using NUnit.Framework;
    using Operations;
    
    [TestFixture]
    public class OperationContainerTestFixture
    {
        private string siteDirectoryContext;

        private string iterationContext;

        [SetUp]
        public void SetUp()
        {
            this.siteDirectoryContext = "/SiteDirectory/47363f0d-eb6d-4a58-95f5-fa7854995650";            
            this.iterationContext = "/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d";
        }

        [Test]
        public void VerifythatIfContextIsNullOrEmptyExceptionIsTrown()
        {
            Assert.Throws<ArgumentNullException>(() => new OperationContainer(null, 1));

            Assert.Throws<ArgumentNullException>(() => new OperationContainer(string.Empty, 1));
        }

        [Test]
        public void VerifyThatConstructorInitializesObjectPropertiesWithValidSiteDirectoryContext()
        {
            var operationContainer = new OperationContainer(this.siteDirectoryContext, 1);
            Assert.IsNotNull(operationContainer.Operations);

            Assert.AreEqual(1, operationContainer.TopContainerRevisionNumber);
        }

        [Test]
        public void VerifyThatConstructorInitializesObjectPropertiesWithInValidSiteDirectoryContext()
        {
            Assert.Throws<ArgumentException>(() => new OperationContainer("/blah/123", 1));
            Assert.Throws<ArgumentException>(() => new OperationContainer("/SiteDirectory/123", 1));
        }

        [Test]
        public void VerifyThatConstructorInitializesObjectPropertiesWithValidIterationContext()
        {
            var operationContainer = new OperationContainer(this.iterationContext, 1);
            Assert.IsNotNull(operationContainer.Operations);
        }

        [Test]
        public void VerifyThatConstructorInitializesObjectPropertiesWithValidInvalidIterationContext()
        {
            Assert.Throws<ArgumentException>(() => new OperationContainer("/EngineeringModel/123/iteration/456", 1));
            Assert.Throws<ArgumentException>(() => new OperationContainer("/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/456", 1));
            Assert.Throws<ArgumentException>(() => new OperationContainer("/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/blah/5e5dc7f8-833d-4331-b421-eb2c64fcf64b", 1));
        }

        [Test]
        public void VerifyExecutionOfOperationAddAndRemove()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), 0);
            elementDefinition.PartialRoutes.Add("iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d");
            elementDefinition.PartialRoutes.Add("EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b");
            
            var clone = elementDefinition.DeepClone<ElementDefinition>();
            var operation = new Operation(elementDefinition,  clone, OperationKind.Update);

            var operationContainer = new OperationContainer(this.iterationContext);

            operationContainer.AddOperation(operation);
            Assert.AreEqual(1, operationContainer.Operations.Count());

            operationContainer.RemoveOperation(operation);
            Assert.AreEqual(0, operationContainer.Operations.Count());
        }

        [Test]
        public void VerifyThatResolveRouteThrowsExceptionWhenOperationsAreForMultipleTopContainers()
        {
            var engineeringModelIid_1 = Guid.NewGuid();
            var iterationIid_1 = Guid.NewGuid();
            var iteration_1 = new Iteration(iterationIid_1, 1);
            iteration_1.AddContainer(ClassKind.EngineeringModel, engineeringModelIid_1);

            var topContainerContext = iteration_1.GetTopContainerRoute();
            var operationContainer = new OperationContainer(topContainerContext, 1);

            var modifiedIteration_1 = new Iteration(iterationIid_1, 2);
            modifiedIteration_1.AddContainer(ClassKind.EngineeringModel, engineeringModelIid_1);
            var operation_1 = new Operation(iteration_1, modifiedIteration_1, OperationKind.Update);
            operationContainer.AddOperation(operation_1);

            var engineeringModelIid_2 = Guid.NewGuid();
            var iterationIid_2 = Guid.NewGuid();
            var iteration_2 = new Iteration(iterationIid_2, 1);
            iteration_2.AddContainer(ClassKind.EngineeringModel, engineeringModelIid_2);
            var modifiedIteration_2 = new Iteration(iterationIid_2, 2);
            modifiedIteration_2.AddContainer(ClassKind.EngineeringModel, engineeringModelIid_2);
            var operation_2 = new Operation(iteration_2, modifiedIteration_2, OperationKind.Update);
            Assert.Throws<ArgumentException>(() => operationContainer.AddOperation(operation_2));
        }
    }
}
