// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyOperationHandlerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
// 
//    This file is part of CDP4-COMET SDK Community Edition
// 
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
// 
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
// 
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal;
    using CDP4Dal.Operations;
    using CDP4Dal.Permission;

    using Moq;

    using NUnit.Framework;

    using Dto = CDP4Common.DTO;

    [TestFixture]
    internal class CopyOperationHandlerTestFixture
    {
        private Mock<ISession> session;
        private Mock<IPermissionService> permissionService;
        private Uri uri = new Uri("https://cdp4services-public.cdp4.org");
        private Assembler assembler;

        private SiteDirectory siteDir;
        private EngineeringModelSetup modelsetup1;
        private EngineeringModelSetup modelsetup2;
        private IterationSetup iterationSetup1;
        private IterationSetup iterationSetup2;
        private Person person;
        private Participant participant1;
        private Participant participant2;
        private DomainOfExpertise domain1;
        private DomainOfExpertise domain2;
        private DomainOfExpertise domain3;

        private SiteReferenceDataLibrary srdl1;
        private SiteReferenceDataLibrary srdl2;
        private ModelReferenceDataLibrary mrdl1;
        private ModelReferenceDataLibrary mrdl2;

        private Category category;
        private BooleanParameterType booleanPt;

        private EngineeringModel model1;
        private Iteration iteration1;
        private EngineeringModel model2;
        private Iteration iteration2;

        private ElementDefinition rootDef;
        private ElementDefinition def1;
        private ElementDefinition def2;
        private ElementUsage usage1;
        private ElementUsage usage11;
        private ElementUsage usage2;
        private ElementUsage usage21;
        private ElementUsage usage22;
        private Parameter parameter1;
        private ParameterOverride override1;
        private ParameterSubscription subscription1;
        private ParameterGroup group1;
        private ParameterGroup group2;

        [SetUp]
        public void Setup()
        {
            this.BuildSiteDirData();
            this.BuildModelData();
        }

        private void BuildSiteDirData()
        {
            this.session = new Mock<ISession>();
            this.permissionService = new Mock<IPermissionService>();
            this.session.Setup(x => x.PermissionService).Returns(this.permissionService.Object);

            this.assembler = new Assembler(this.uri, null);
            this.session.Setup(x => x.Assembler).Returns(this.assembler);

            this.siteDir = new SiteDirectory(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.modelsetup1 = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.modelsetup2 = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iterationSetup1 = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iterationSetup2 = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.person = new Person(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participant1 = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participant2 = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain1 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain2 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain3 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.mrdl1 = new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.mrdl2 = new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.category = new Category(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.booleanPt = new BooleanParameterType(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.srdl2.RequiredRdl = this.srdl1;
            this.mrdl1.RequiredRdl = this.srdl2;
            this.mrdl2.RequiredRdl = this.srdl1;

            this.participant1.Person = this.person;
            this.participant2.Person = this.person;

            this.modelsetup1.ActiveDomain.Add(this.domain1);
            this.modelsetup1.ActiveDomain.Add(this.domain2);
            this.modelsetup1.ActiveDomain.Add(this.domain3);
            this.modelsetup2.ActiveDomain.Add(this.domain1);
            this.modelsetup2.ActiveDomain.Add(this.domain2);

            this.srdl1.ParameterType.Add(this.booleanPt);
            this.srdl2.DefinedCategory.Add(this.category);

            this.siteDir.Model.Add(this.modelsetup1);
            this.siteDir.Model.Add(this.modelsetup2);
            this.siteDir.Person.Add(this.person);
            this.siteDir.Domain.Add(this.domain1);
            this.siteDir.Domain.Add(this.domain2);
            this.siteDir.Domain.Add(this.domain3);
            this.siteDir.SiteReferenceDataLibrary.Add(this.srdl1);
            this.siteDir.SiteReferenceDataLibrary.Add(this.srdl2);
            this.modelsetup1.IterationSetup.Add(this.iterationSetup1);
            this.modelsetup2.IterationSetup.Add(this.iterationSetup2);
            this.modelsetup1.Participant.Add(this.participant1);
            this.modelsetup2.Participant.Add(this.participant2);
            this.modelsetup1.RequiredRdl.Add(this.mrdl1);
            this.modelsetup2.RequiredRdl.Add(this.mrdl2);

            this.session.Setup(x => x.ActivePerson).Returns(this.person);

            this.session.Setup(x => x.ActivePersonParticipants)
                .Returns(new List<Participant> { this.participant1, this.participant2 });
        }

        private void BuildModelData()
        {
            this.model1 = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.model2 = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iteration1 = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iteration2 = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.rootDef = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri) { Name = "rootdef" };
            this.def1 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri) { Name = "def1" };
            this.def2 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri) { Name = "def2" };
            this.usage1 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage11 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage2 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage21 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage22 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.parameter1 = new Parameter(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.override1 = new ParameterOverride(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.subscription1 = new ParameterSubscription(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.group1 = new ParameterGroup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.group2 = new ParameterGroup(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.model1.EngineeringModelSetup = this.modelsetup1;
            this.model2.EngineeringModelSetup = this.modelsetup2;

            this.iteration1.IterationSetup = this.iterationSetup1;
            this.iteration2.IterationSetup = this.iterationSetup2;

            this.rootDef.Owner = this.domain1;
            this.def1.Owner = this.domain1;
            this.def2.Owner = this.domain2;
            this.usage1.Owner = this.domain1;
            this.usage1.ElementDefinition = this.def1;
            this.usage11.Owner = this.domain1;
            this.usage11.ElementDefinition = this.def1;
            this.usage2.Owner = this.domain1;
            this.usage2.ElementDefinition = this.def2;
            this.usage22.Owner = this.domain1;
            this.usage22.ElementDefinition = this.def2;
            this.usage21.Owner = this.domain1;
            this.usage21.ElementDefinition = this.def2;

            this.parameter1.Owner = this.domain2;
            this.parameter1.ParameterType = this.booleanPt;
            this.parameter1.AllowDifferentOwnerOfOverride = true;
            this.override1.Parameter = this.parameter1;
            this.override1.Owner = this.domain2;
            this.subscription1.Owner = this.domain1;

            this.group2.ContainingGroup = this.group1;
            this.parameter1.Group = this.group2;

            this.model1.Iteration.Add(this.iteration1);
            this.iteration1.Element.Add(this.def1);
            this.iteration1.Element.Add(this.def2);
            this.iteration1.Element.Add(this.rootDef);
            this.rootDef.ContainedElement.Add(this.usage1);
            this.rootDef.ContainedElement.Add(this.usage11);
            this.def1.ContainedElement.Add(this.usage2);
            this.def1.ContainedElement.Add(this.usage22);
            this.def1.ContainedElement.Add(this.usage21);
            this.def2.Parameter.Add(this.parameter1);
            this.def2.ParameterGroup.Add(this.group1);
            this.def2.ParameterGroup.Add(this.group2);
            this.usage1.ParameterOverride.Add(this.override1);
            this.override1.ParameterSubscription.Add(this.subscription1);

            this.model2.Iteration.Add(this.iteration2);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void VerifyThatModifyShiftCopyOperationsWorks()
        {
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);

            this.session.Setup(x => x.OpenIterations).Returns(
                new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
                {
                    { this.iteration1, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) },
                    { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain2, null) }
                });

            var iteration2Clone = this.iteration2.Clone(false);
            var defClone = this.rootDef.Clone(false);
            defClone.Iid = Guid.NewGuid();
            iteration2Clone.Element.Add(defClone);

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, this.model2.RevisionNumber);
            operationContainer.AddOperation(new Operation(this.iteration2.ToDto(), iteration2Clone.ToDto(), OperationKind.Update));
            operationContainer.AddOperation(new Operation(this.rootDef.ToDto(), defClone.ToDto(), OperationKind.Copy));

            var copyHandler = new CopyOperationHandler(this.session.Object);
            copyHandler.ModifiedCopyOperation(operationContainer);

            var operations = operationContainer.Operations.ToList();
            Assert.IsNotEmpty(operationContainer.Context);
            Assert.AreEqual(14, operations.Count);

            var operation = operations.Single(x => x.OperationKind == OperationKind.Update);
            var iteration = (CDP4Common.DTO.Iteration)operation.ModifiedThing;
            Assert.AreEqual(3, iteration.Element.Count);
        }

        [Test]
        public void VerifyThatModifyShiftCopyOperationsWorks2()
        {
            // all the things cannot be copied
            this.permissionService.Setup(x => x.CanWrite(It.Is<ClassKind>(cl => cl != ClassKind.ParameterSubscription), It.IsAny<Thing>())).Returns(true);

            this.session.Setup(x => x.OpenIterations).Returns(
                new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
                {
                    { this.iteration1, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) },
                    { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain2, null) }
                });

            var iteration2Clone = this.iteration2.Clone(false);
            var defClone = this.rootDef.Clone(false);
            defClone.Iid = Guid.NewGuid();
            iteration2Clone.Element.Add(defClone);

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, this.model2.RevisionNumber);
            operationContainer.AddOperation(new Operation(this.iteration2.ToDto(), iteration2Clone.ToDto(), OperationKind.Update));
            operationContainer.AddOperation(new Operation(this.rootDef.ToDto(), defClone.ToDto(), OperationKind.Copy));

            var copyHandler = new CopyOperationHandler(this.session.Object);
            copyHandler.ModifiedCopyOperation(operationContainer);

            var operations = operationContainer.Operations.ToList();
            Assert.AreEqual(13, operations.Count);
            Assert.IsNotEmpty(operationContainer.Context);
        }

        [Test]
        public void VerifyThatDryCopyWorks()
        {
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);

            this.session.Setup(x => x.OpenIterations).Returns(
                new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
                {
                    { this.iteration1, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) },
                    { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain3, null) }
                });

            var iteration2Clone = this.iteration2.Clone(false);
            var defClone = this.rootDef.Clone(false);
            defClone.Iid = Guid.NewGuid();
            iteration2Clone.Element.Add(defClone);

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, this.model2.RevisionNumber);
            operationContainer.AddOperation(new Operation(this.iteration2.ToDto(), iteration2Clone.ToDto(), OperationKind.Update));
            operationContainer.AddOperation(new Operation(this.rootDef.ToDto(), defClone.ToDto(), OperationKind.CopyDefaultValuesChangeOwner));

            var copyHandler = new CopyOperationHandler(this.session.Object);
            copyHandler.ModifiedCopyOperation(operationContainer);

            var operations = operationContainer.Operations.ToList();
            Assert.AreEqual(14, operations.Count);
            Assert.IsNotEmpty(operationContainer.Context); // check that operation container is correctly built

            var ownedThings =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .Where(x => x.ClassKind != ClassKind.ParameterSubscription)
                    .OfType<Dto.IOwnedThing>()
                    .ToList();

            var dtoOwner = ownedThings.Select(x => x.Owner).Distinct().Single();
            Assert.AreEqual(dtoOwner, this.domain3.Iid);

            var sub =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .OfType<Dto.ParameterSubscription>().Single();

            Assert.AreEqual(sub.Owner, this.subscription1.Owner.Iid);
        }

        [Test]
        public void VerifyThatDryCopyDoesNotCopySubscriptionWithOwnerAsActiveDomain()
        {
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);

            this.session.Setup(x => x.OpenIterations).Returns(
                new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
                {
                    { this.iteration1, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) },
                    { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) }
                });

            var iteration2Clone = this.iteration2.Clone(false);
            var defClone = this.rootDef.Clone(false);
            defClone.Iid = Guid.NewGuid();
            iteration2Clone.Element.Add(defClone);

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, this.model2.RevisionNumber);
            operationContainer.AddOperation(new Operation(this.iteration2.ToDto(), iteration2Clone.ToDto(), OperationKind.Update));
            operationContainer.AddOperation(new Operation(this.rootDef.ToDto(), defClone.ToDto(), OperationKind.CopyDefaultValuesChangeOwner));

            var copyHandler = new CopyOperationHandler(this.session.Object);
            copyHandler.ModifiedCopyOperation(operationContainer);

            var operations = operationContainer.Operations.ToList();
            Assert.AreEqual(13, operations.Count);
            Assert.IsNotEmpty(operationContainer.Context); // check that operation container is correctly built

            var ownedThings =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .Where(x => x.ClassKind != ClassKind.ParameterSubscription)
                    .OfType<Dto.IOwnedThing>()
                    .ToList();

            var dtoOwner = ownedThings.Select(x => x.Owner).Distinct().Single();
            Assert.AreEqual(dtoOwner, this.domain1.Iid);

            var subCount =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .OfType<Dto.ParameterSubscription>().Count();

            Assert.AreEqual(0, subCount);
        }

        [Test]
        public void VerifyThatDryCopyDoesNotCopySubscriptionWithInactiveDomain()
        {
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);

            this.session.Setup(x => x.OpenIterations).Returns(
                new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
                {
                    { this.iteration1, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) },
                    { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) }
                });

            this.subscription1.Owner = this.domain3;

            var iteration2Clone = this.iteration2.Clone(false);
            var defClone = this.rootDef.Clone(false);
            defClone.Iid = Guid.NewGuid();
            iteration2Clone.Element.Add(defClone);

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, this.model2.RevisionNumber);
            operationContainer.AddOperation(new Operation(this.iteration2.ToDto(), iteration2Clone.ToDto(), OperationKind.Update));
            operationContainer.AddOperation(new Operation(this.rootDef.ToDto(), defClone.ToDto(), OperationKind.CopyDefaultValuesChangeOwner));

            var copyHandler = new CopyOperationHandler(this.session.Object);
            copyHandler.ModifiedCopyOperation(operationContainer);

            var operations = operationContainer.Operations.ToList();
            Assert.AreEqual(13, operations.Count);
            Assert.IsNotEmpty(operationContainer.Context); // check that operation container is correctly built

            var ownedThings =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .Where(x => x.ClassKind != ClassKind.ParameterSubscription)
                    .OfType<Dto.IOwnedThing>()
                    .ToList();

            var dtoOwner = ownedThings.Select(x => x.Owner).Distinct().Single();
            Assert.AreEqual(dtoOwner, this.domain1.Iid);

            var subCount =
                operationContainer.Operations.Select(x => x.ModifiedThing)
                    .OfType<Dto.ParameterSubscription>().Count();

            Assert.AreEqual(0, subCount);
        }
    }
}
