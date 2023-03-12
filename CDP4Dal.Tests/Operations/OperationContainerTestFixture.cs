// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationContainerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests
{
    using System;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;

    using CDP4Dal.Operations;

    using NUnit.Framework;
    
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
        public void Verify_that_token_is_set_when_constructed()
        {
            var operationContainer = new OperationContainer(this.siteDirectoryContext, 1);
            Assert.IsNotEmpty(operationContainer.Token);
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
