#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueSetOperationCreatorTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal;
    using CDP4Dal.Operations;
    using CDP4Dal.Permission;
    using Moq;
    using NUnit.Framework;
    using Dto = CDP4Common.DTO;

    [TestFixture]
    internal class ValueSetOperationCreatorTestFixture
    {
        private Mock<ISession> session;
        private Mock<IPermissionService> permissionService;
        private Uri uri = new Uri("https://cdp4services-public.rheagroup.com");
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

        private Dictionary<Thing, Thing> map;

        private ElementDefinition def2Copy;
        private Parameter parameter1Copy;
        private ParameterSubscription subscriptionCopy;

        private Option option1;
        private Option option2;

        private PossibleFiniteStateList psl1;
        private PossibleFiniteState ps1;
        private ActualFiniteStateList asl1;
        private ActualFiniteState as1;

        private List<string> manual = new List<string>{"manual"};
            
        [SetUp]
        public void Setup()
        {
            this.BuildSiteDirData();
            this.BuildModelData();

            this.map = new Dictionary<Thing, Thing>();
            this.def2Copy = new ElementDefinition(Guid.NewGuid(), null, null);
            this.parameter1Copy = new Parameter(Guid.NewGuid(), null, null);
            this.subscriptionCopy = new ParameterSubscription(Guid.NewGuid(), null, null);

            this.def2Copy.Parameter.Add(this.parameter1Copy);
            this.parameter1Copy.ParameterSubscription.Add(this.subscriptionCopy);

            this.map.Add(this.def2, this.def2Copy);
            this.map.Add(this.parameter1, this.parameter1Copy);
            this.map.Add(this.subscription1, this.subscriptionCopy);
        }

        private void BuildSiteDirData()
        {
            this.session = new Mock<ISession>();
            this.permissionService = new Mock<IPermissionService>();
            this.session.Setup(x => x.PermissionService).Returns(this.permissionService.Object);

            this.assembler = new Assembler(this.uri);
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
            this.def1 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri) {Name = "def1"};
            this.def2 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri) { Name = "def2" };
            this.usage1 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage11 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage2 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage21 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage22 = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.parameter1 = new Parameter(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.override1 = new ParameterOverride(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.subscription1 = new ParameterSubscription(Guid.NewGuid(), this.assembler.Cache, this.uri);
            

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
            this.usage1.ParameterOverride.Add(this.override1);
            this.parameter1.ParameterSubscription.Add(this.subscription1);

            this.model2.Iteration.Add(this.iteration2);

            this.option1 = new Option(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.option2 = new Option(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.psl1 = new PossibleFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.ps1 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.asl1 = new ActualFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.as1 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.iteration1.Option.Add(this.option1);
            this.iteration1.Option.Add(this.option2);

            this.iteration1.PossibleFiniteStateList.Add(this.psl1);
            this.iteration1.ActualFiniteStateList.Add(this.asl1);

            this.psl1.PossibleState.Add(this.ps1);
            this.asl1.ActualState.Add(this.as1);

            this.iteration1.DefaultOption = this.option1;
            this.psl1.DefaultState = this.ps1;

            this.asl1.PossibleFiniteStateList.Add(this.psl1);
            this.as1.PossibleState.Add(this.ps1);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void VerifyThatCreateValueSetsUpdateOperationsWorks()
        {
            var valueset = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset.Manual = new ValueArray<string>(manual);
            this.parameter1.ValueSet.Add(valueset);

            var subscriptionvalueset = new ParameterSubscriptionValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            subscriptionvalueset.Manual = new ValueArray<string>(manual);
            this.subscription1.ValueSet.Add(subscriptionvalueset);

            var modeldto = this.model2.ToDto();
            var iterationDto = (Dto.Iteration)this.iteration2.ToDto();
            var def2Dto = new Dto.ElementDefinition(this.def2Copy.Iid, 2);
            var parameterDto = new Dto.Parameter(this.parameter1Copy.Iid, 2);
            var newValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2);

            var subscription = new Dto.ParameterSubscription(this.subscriptionCopy.Iid, 1);
            var subscriptionValueSet = new Dto.ParameterSubscriptionValueSet(Guid.NewGuid(), 1);

            iterationDto.Element.Add(def2Dto.Iid);
            def2Dto.Parameter.Add(parameterDto.Iid);
            parameterDto.ValueSet.Add(newValueSet.Iid);
            parameterDto.ParameterSubscription.Add(subscription.Iid);
            subscription.ValueSet.Add(subscriptionValueSet.Iid);

            var returnedDto = new List<Dto.Thing>
            {
                modeldto,
                iterationDto,
                def2Dto,
                parameterDto,
                newValueSet,
                subscription,
                subscriptionValueSet
            };

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationCreator = new ValueSetOperationCreator(this.session.Object);
            var operationContainer = operationCreator.CreateValueSetsUpdateOperations(context, returnedDto, this.map);

            Assert.AreEqual(2, operationContainer.Operations.Count());
            var operation = operationContainer.Operations.Single(x => x.OriginalThing.ClassKind == ClassKind.ParameterValueSet);
            var originalPvs = (Dto.ParameterValueSet)operation.OriginalThing;
            var modifiedPvs = (Dto.ParameterValueSet)operation.ModifiedThing;

            Assert.AreNotEqual(originalPvs.Manual, modifiedPvs.Manual);
        }

        [Test]
        public void VerifyThatCreateValueSetsUpdateOperationsWorksOptionDependent()
        {
            var valueset1 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset1.Manual = new ValueArray<string>(manual);
            this.parameter1.ValueSet.Add(valueset1);
            valueset1.ActualOption = this.option1;

            var valueset2 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset2.Manual = new ValueArray<string>();
            this.parameter1.ValueSet.Add(valueset2);
            valueset2.ActualOption = this.option2;

            this.parameter1.IsOptionDependent = true;
            this.parameter1Copy.IsOptionDependent = true;

            var modeldto = this.model2.ToDto();
            var iterationDto = (Dto.Iteration)this.iteration2.ToDto();
            var def2Dto = new Dto.ElementDefinition(this.def2Copy.Iid, 2);
            var parameterDto = new Dto.Parameter(this.parameter1Copy.Iid, 2);
            parameterDto.IsOptionDependent = true;
            var newValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2);

            iterationDto.Element.Add(def2Dto.Iid);
            def2Dto.Parameter.Add(parameterDto.Iid);
            parameterDto.ValueSet.Add(newValueSet.Iid);

            var returnedDto = new List<Dto.Thing>
            {
                modeldto,
                iterationDto,
                def2Dto,
                parameterDto,
                newValueSet
            };

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationCreator = new ValueSetOperationCreator(this.session.Object);
            var operationContainer = operationCreator.CreateValueSetsUpdateOperations(context, returnedDto, this.map);

            var operation = operationContainer.Operations.Single();
            var original = (Dto.ParameterValueSet)operation.OriginalThing;
            var modified = (Dto.ParameterValueSet)operation.ModifiedThing;

            Assert.AreNotEqual(original.Manual, modified.Manual);
        }

        [Test]
        public void VerifyThatCreateValueSetsUpdateOperationsWorksStateDependent()
        {
            var valueset1 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset1.Manual = new ValueArray<string>(manual);
            this.parameter1.ValueSet.Add(valueset1);
            valueset1.ActualState = this.as1;

            this.parameter1.IsOptionDependent = true;
            this.parameter1Copy.IsOptionDependent = true;
            this.parameter1.StateDependence = this.asl1;

            var modeldto = this.model2.ToDto();
            var iterationDto = (Dto.Iteration)this.iteration2.ToDto();
            var def2Dto = new Dto.ElementDefinition(this.def2Copy.Iid, 2);
            var parameterDto = new Dto.Parameter(this.parameter1Copy.Iid, 2);
            parameterDto.IsOptionDependent = true;
            var newValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2);

            iterationDto.Element.Add(def2Dto.Iid);
            def2Dto.Parameter.Add(parameterDto.Iid);
            parameterDto.ValueSet.Add(newValueSet.Iid);

            var returnedDto = new List<Dto.Thing>
            {
                modeldto,
                iterationDto,
                def2Dto,
                parameterDto,
                newValueSet
            };

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationCreator = new ValueSetOperationCreator(this.session.Object);
            var operationContainer = operationCreator.CreateValueSetsUpdateOperations(context, returnedDto, this.map);

            var operation = operationContainer.Operations.Single();
            var original = (Dto.ParameterValueSet)operation.OriginalThing;
            var modified = (Dto.ParameterValueSet)operation.ModifiedThing;

            Assert.AreNotEqual(original.Manual, modified.Manual);
        }

        [Test]
        public void VerifyThatCreateValueSetsUpdateOperationsWorksStateOptionDependent()
        {
            var valueset1 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset1.Manual = new ValueArray<string>(manual);
            this.parameter1.ValueSet.Add(valueset1);
            valueset1.ActualOption = this.option1;
            valueset1.ActualState = this.as1;

            var valueset2 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset2.Manual = new ValueArray<string>();
            this.parameter1.ValueSet.Add(valueset2);
            valueset2.ActualOption = this.option2;
            valueset2.ActualState = this.as1;

            this.parameter1.IsOptionDependent = true;
            this.parameter1Copy.IsOptionDependent = true;
            this.parameter1.StateDependence = this.asl1;

            var modeldto = this.model2.ToDto();
            var iterationDto = (Dto.Iteration)this.iteration2.ToDto();
            var def2Dto = new Dto.ElementDefinition(this.def2Copy.Iid, 2);
            var parameterDto = new Dto.Parameter(this.parameter1Copy.Iid, 2);
            parameterDto.IsOptionDependent = true;
            var newValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2);

            iterationDto.Element.Add(def2Dto.Iid);
            def2Dto.Parameter.Add(parameterDto.Iid);
            parameterDto.ValueSet.Add(newValueSet.Iid);

            var returnedDto = new List<Dto.Thing>
            {
                modeldto,
                iterationDto,
                def2Dto,
                parameterDto,
                newValueSet
            };

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationCreator = new ValueSetOperationCreator(this.session.Object);
            var operationContainer = operationCreator.CreateValueSetsUpdateOperations(context, returnedDto, this.map);

            var operation = operationContainer.Operations.Single();
            var original = (Dto.ParameterValueSet)operation.OriginalThing;
            var modified = (Dto.ParameterValueSet)operation.ModifiedThing;

            Assert.AreNotEqual(original.Manual, modified.Manual);
        }

        [Test]
        public void VerifyInvalidOperationException()
        {
            var valueset1 = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            valueset1.Manual = new ValueArray<string>(manual);
            this.parameter1.ValueSet.Add(valueset1);
            valueset1.ActualOption = this.option1;
            valueset1.ActualState = this.as1;

            var modeldto = this.model2.ToDto();
            var iterationDto = (Dto.Iteration)this.iteration2.ToDto();
            var def2Dto = new Dto.ElementDefinition(this.def2Copy.Iid, 2);
            var parameterDto = new Dto.Parameter(this.parameter1Copy.Iid, 2);
            parameterDto.IsOptionDependent = true;
            var newValueSet = new Dto.ParameterValueSet(Guid.NewGuid(), 2);

            iterationDto.Element.Add(def2Dto.Iid);
            def2Dto.Parameter.Add(parameterDto.Iid);
            parameterDto.ValueSet.Add(newValueSet.Iid);

            var returnedDto = new List<Dto.Thing>
            {
                iterationDto,
                def2Dto,
                parameterDto,
                newValueSet
            };

            var transactionContext = TransactionContextResolver.ResolveContext(this.iteration2);
            var context = transactionContext.ContextRoute();

            var operationCreator = new ValueSetOperationCreator(this.session.Object);

            Assert.Throws<InvalidOperationException>(() => operationCreator.CreateValueSetsUpdateOperations(context, returnedDto, this.map));
        }
    }
}