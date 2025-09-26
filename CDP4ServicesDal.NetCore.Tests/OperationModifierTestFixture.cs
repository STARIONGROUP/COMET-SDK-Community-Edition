﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationModifierTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.Operations;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    internal class OperationModifierTestFixture
    {
        private Uri uri = new Uri("https://cdp4services-public.cdp4.org");
        private Mock<ISession> session;
        private Assembler assembler;

        [SetUp]
        public void SetUp()
        {
            this.session = new Mock<ISession>();
            this.assembler = new Assembler(this.uri, new CDPMessageBus());
            this.session.Setup(x => x.Assembler).Returns(this.assembler);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void VerifyThatNoOperationAdded()
        {
            var domain1 = new CDP4Common.SiteDirectoryData.DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache,
                this.uri);

            var domain2 = new CDP4Common.SiteDirectoryData.DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache,
                this.uri);

            var model = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var iteration = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);

            var elementDef = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache,
                this.uri) { Owner = domain1 };

            var defForUsage = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache,
                this.uri) { Owner = domain1 };

            var usage = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                ElementDefinition = defForUsage
            };

            var parameter = new Parameter(Guid.NewGuid(), this.assembler.Cache, this.uri) { Owner = domain1 };

            var parameterSubscription = new ParameterSubscription(Guid.NewGuid(),
                this.assembler.Cache, this.uri) { Owner = domain2 };

            parameter.ParameterSubscription.Add(parameterSubscription);

            var parameterOverride = new ParameterOverride(Guid.NewGuid(), this.assembler.Cache, this.uri)
            {
                Owner = domain1,
                Parameter = parameter
            };

            usage.ParameterOverride.Add(parameterOverride);

            model.Iteration.Add(iteration);
            iteration.Element.Add(elementDef);
            iteration.Element.Add(defForUsage);
            elementDef.ContainedElement.Add(usage);
            defForUsage.Parameter.Add(parameter);

            var transactionContext = TransactionContextResolver.ResolveContext(iteration);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, model.RevisionNumber);
            operationContainer.AddOperation(new Operation(null, parameterOverride.ToDto(), OperationKind.Create));

            var modifier = new OperationModifier(this.session.Object);
            modifier.ModifyOperationContainer(operationContainer);

            Assert.That(operationContainer.Operations.Count(), Is.EqualTo(1));
        }

        [Test]
        public void VerifyThatActualFiniteStateKindIsUpdatedOnNewDefault()
        {
            var model = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var iteration = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);

            var possibleList1 = new PossibleFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var possibleList2 = new PossibleFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var possibleList3 = new PossibleFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);

            var ps11 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var ps12 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);

            var ps21 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var ps22 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);

            var ps31 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var ps32 = new PossibleFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);

            possibleList1.PossibleState.Add(ps11);
            possibleList1.PossibleState.Add(ps12);
            possibleList2.PossibleState.Add(ps21);
            possibleList2.PossibleState.Add(ps22);
            possibleList3.PossibleState.Add(ps31);
            possibleList3.PossibleState.Add(ps32);

            var actualList1 = new ActualFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);
            var actualList2 = new ActualFiniteStateList(Guid.NewGuid(), this.assembler.Cache, this.uri);

            actualList1.PossibleFiniteStateList.Add(possibleList1);
            actualList1.PossibleFiniteStateList.Add(possibleList2);
            var as11 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as11.PossibleState.Add(ps11);
            as11.PossibleState.Add(ps21);
            var as12 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as12.PossibleState.Add(ps11);
            as12.PossibleState.Add(ps22);
            var as13 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as13.PossibleState.Add(ps12);
            as13.PossibleState.Add(ps21);
            var as14 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as14.PossibleState.Add(ps12);
            as14.PossibleState.Add(ps22);

            actualList1.ActualState.Add(as11);
            actualList1.ActualState.Add(as12);
            actualList1.ActualState.Add(as13);
            actualList1.ActualState.Add(as14);

            actualList2.PossibleFiniteStateList.Add(possibleList2);
            actualList2.PossibleFiniteStateList.Add(possibleList3);
            var as21 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as21.PossibleState.Add(ps21);
            as21.PossibleState.Add(ps31);
            var as22 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as22.PossibleState.Add(ps21);
            as22.PossibleState.Add(ps32);
            var as23 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as23.PossibleState.Add(ps22);
            as23.PossibleState.Add(ps31);
            var as24 = new ActualFiniteState(Guid.NewGuid(), this.assembler.Cache, this.uri);
            as24.PossibleState.Add(ps22);
            as24.PossibleState.Add(ps32);

            actualList2.ActualState.Add(as21);
            actualList2.ActualState.Add(as22);
            actualList2.ActualState.Add(as23);
            actualList2.ActualState.Add(as24);

            model.Iteration.Add(iteration);
            iteration.PossibleFiniteStateList.Add(possibleList1);
            iteration.PossibleFiniteStateList.Add(possibleList2);
            iteration.PossibleFiniteStateList.Add(possibleList3);
            iteration.ActualFiniteStateList.Add(actualList1);
            iteration.ActualFiniteStateList.Add(actualList2);

            this.assembler.Cache.TryAdd(new CacheKey(model.Iid, null), new Lazy<Thing>(() => model));
            this.assembler.Cache.TryAdd(new CacheKey(iteration.Iid, null), new Lazy<Thing>(() => iteration));
            this.assembler.Cache.TryAdd(new CacheKey(possibleList1.Iid, iteration.Iid), new Lazy<Thing>(() => possibleList1));
            this.assembler.Cache.TryAdd(new CacheKey(possibleList2.Iid, iteration.Iid), new Lazy<Thing>(() => possibleList2));
            this.assembler.Cache.TryAdd(new CacheKey(possibleList3.Iid, iteration.Iid), new Lazy<Thing>(() => possibleList3));
            this.assembler.Cache.TryAdd(new CacheKey(ps11.Iid, iteration.Iid), new Lazy<Thing>(() => ps11));
            this.assembler.Cache.TryAdd(new CacheKey(ps12.Iid, iteration.Iid), new Lazy<Thing>(() => ps12));
            this.assembler.Cache.TryAdd(new CacheKey(ps21.Iid, iteration.Iid), new Lazy<Thing>(() => ps21));
            this.assembler.Cache.TryAdd(new CacheKey(ps22.Iid, iteration.Iid), new Lazy<Thing>(() => ps22));
            this.assembler.Cache.TryAdd(new CacheKey(ps31.Iid, iteration.Iid), new Lazy<Thing>(() => ps31));
            this.assembler.Cache.TryAdd(new CacheKey(ps32.Iid, iteration.Iid), new Lazy<Thing>(() => ps32));
            this.assembler.Cache.TryAdd(new CacheKey(actualList1.Iid, iteration.Iid), new Lazy<Thing>(() => actualList1));
            this.assembler.Cache.TryAdd(new CacheKey(actualList2.Iid, iteration.Iid), new Lazy<Thing>(() => actualList2));
            this.assembler.Cache.TryAdd(new CacheKey(as11.Iid, iteration.Iid), new Lazy<Thing>(() => as11));
            this.assembler.Cache.TryAdd(new CacheKey(as12.Iid, iteration.Iid), new Lazy<Thing>(() => as12));
            this.assembler.Cache.TryAdd(new CacheKey(as13.Iid, iteration.Iid), new Lazy<Thing>(() => as13));
            this.assembler.Cache.TryAdd(new CacheKey(as14.Iid, iteration.Iid), new Lazy<Thing>(() => as14));
            this.assembler.Cache.TryAdd(new CacheKey(as21.Iid, iteration.Iid), new Lazy<Thing>(() => as21));
            this.assembler.Cache.TryAdd(new CacheKey(as22.Iid, iteration.Iid), new Lazy<Thing>(() => as22));
            this.assembler.Cache.TryAdd(new CacheKey(as23.Iid, iteration.Iid), new Lazy<Thing>(() => as23));
            this.assembler.Cache.TryAdd(new CacheKey(as24.Iid, iteration.Iid), new Lazy<Thing>(() => as24));

            possibleList1.DefaultState = ps11;
            as11.Kind = ActualFiniteStateKind.FORBIDDEN;

            var transactionContext = TransactionContextResolver.ResolveContext(iteration);
            var context = transactionContext.ContextRoute();

            var operationContainer = new OperationContainer(context, model.RevisionNumber);

            var original = possibleList2.ToDto();
            var modify = (CDP4Common.DTO.PossibleFiniteStateList)possibleList2.ToDto();
            modify.DefaultState = ps21.Iid;

            operationContainer.AddOperation(new Operation(original, modify, OperationKind.Update));

            Assert.That(operationContainer.Operations.Count(), Is.EqualTo(1));

            var modifier = new OperationModifier(this.session.Object);
            modifier.ModifyOperationContainer(operationContainer);

            Assert.That(operationContainer.Operations.Count(), Is.EqualTo(2));
            var addedOperation = operationContainer.Operations.Last();
            var originalActualState = (CDP4Common.DTO.ActualFiniteState)addedOperation.OriginalThing;
            var modifiedActualState = (CDP4Common.DTO.ActualFiniteState)addedOperation.ModifiedThing;

            Assert.That(originalActualState.Iid, Is.EqualTo(as11.Iid));
            Assert.That(modifiedActualState.Kind, Is.EqualTo(ActualFiniteStateKind.MANDATORY));
            Assert.That(originalActualState.Kind, Is.EqualTo(ActualFiniteStateKind.FORBIDDEN));
        }
    }
}
