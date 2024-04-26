// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterSubscriptionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    internal class ParameterSubscriptionTestFixture
    {
        private ElementDefinition elementDefinition1;
        private ParameterSubscription parameterSubscription;
        private Parameter parameter;

        private DomainOfExpertise domain;
        private Iteration iteration;
        private Option option1;
        private Option option2;
        private PossibleFiniteStateList possibleList;
        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;
        private ActualFiniteStateList actualList;
        private ActualFiniteState actualState1;
        private ActualFiniteState actualState2;

        [SetUp]
        public void Setup()
        {
            this.domain = new DomainOfExpertise(Guid.NewGuid(), null, null) { Name = "domain", ShortName = "d" };

            this.parameterSubscription = new ParameterSubscription(Guid.NewGuid(), null, null) { Owner = this.domain };
            this.parameter = new Parameter(Guid.NewGuid(), null, null) { Owner = this.domain };
            this.parameter.ParameterType = new BooleanParameterType(Guid.NewGuid(), null, null);
            this.parameter.IsOptionDependent = true;
            this.parameter.Scale = new LogarithmicScale(Guid.NewGuid(), null, null);
            this.parameter.StateDependence = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.parameter.Group = new ParameterGroup(Guid.NewGuid(), null, null);

            this.parameter.ParameterSubscription.Add(this.parameterSubscription);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.option1 = new Option(Guid.NewGuid(), null, null) { Name = "option1", ShortName = "o1" };
            this.option2 = new Option(Guid.NewGuid(), null, null) { Name = "option2", ShortName = "o2" };

            this.possibleList = new PossibleFiniteStateList(Guid.NewGuid(), null, null) { Name = "possible list", ShortName = "pl" };
            this.possibleState1 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "ps1", ShortName = "ps1" };
            this.possibleState2 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "ps2", ShortName = "ps2" };
            this.possibleList.PossibleState.Add(this.possibleState1);
            this.possibleList.PossibleState.Add(this.possibleState2);

            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualList.PossibleFiniteStateList.Add(this.possibleList);
            this.actualState1 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualState1.PossibleState.Add(this.possibleState1);
            this.actualState2 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualState2.PossibleState.Add(this.possibleState2);
            this.actualList.ActualState.Add(this.actualState1);
            this.actualList.ActualState.Add(this.actualState2);

            this.elementDefinition1 = new ElementDefinition(Guid.NewGuid(), null, null) { Owner = this.domain };

            this.iteration.Option.Add(this.option1);
            this.iteration.Option.Add(this.option2);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList);
            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.Element.Add(this.elementDefinition1);

            this.elementDefinition1.Parameter.Add(this.parameter);
        }

        [Test]
        public void TestGets()
        {
            Assert.IsTrue(ReferenceEquals(this.parameter.ParameterType, this.parameterSubscription.ParameterType));
            Assert.That(this.parameterSubscription.IsOptionDependent, Is.EqualTo(this.parameter.IsOptionDependent));
            Assert.IsTrue(ReferenceEquals(this.parameter.Scale, this.parameterSubscription.Scale));
            Assert.IsTrue(ReferenceEquals(this.parameter.StateDependence, this.parameterSubscription.StateDependence));
            Assert.IsTrue(ReferenceEquals(this.parameter.Group, this.parameterSubscription.Group));
        }

        [Test]
        public void TestGetParameterType2()
        {
            var parameterOverride = new ParameterOverride(Guid.NewGuid(), null, null);
            this.parameter = new Parameter(Guid.NewGuid(), null, null);
            this.parameter.ParameterType = new BooleanParameterType(Guid.NewGuid(), null, null);
            this.parameter.IsOptionDependent = true;
            this.parameter.Scale = new LogarithmicScale(Guid.NewGuid(), null, null);
            this.parameter.StateDependence = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.parameter.Group = new ParameterGroup(Guid.NewGuid(), null, null);

            parameterOverride.Parameter = this.parameter;

            parameterOverride.ParameterSubscription.Add(this.parameterSubscription);

            Assert.IsTrue(ReferenceEquals(this.parameter.ParameterType, this.parameterSubscription.ParameterType));
        }

        [Test]        
        public void TestException()
        {
            this.parameterSubscription = new ParameterSubscription();

            Assert.That(() =>
            {
                Console.WriteLine(this.parameterSubscription.ParameterType);
            }, Throws.TypeOf<ContainmentException>());
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet()
        {
            // no option, no state
            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = null;
            this.parameterSubscription.ValidatePoco();
            Assert.IsNotEmpty(this.parameterSubscription.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet2()
        {
            // option/State dependent
            this.parameter.IsOptionDependent = true;
            this.parameter.StateDependence = this.actualList;

            this.parameterSubscription.ValidatePoco();
            Assert.IsNotEmpty(this.parameterSubscription.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet3()
        {
            // option dependent
            this.parameter.IsOptionDependent = true;
            this.parameter.StateDependence = null;

            this.parameterSubscription.ValidatePoco();
            Assert.IsNotEmpty(this.parameterSubscription.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasErrorWhenNoValueSet4()
        {
            // State dependent
            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = this.actualList;

            this.parameterSubscription.ValidatePoco();
            Assert.IsNotEmpty(this.parameterSubscription.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterWithEmptyArrayValueSetHasError()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null) { SubscribedValueSet = valuesetoverriden};
            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = null;

            this.parameterSubscription.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.parameterSubscription.ValidatePoco();

            Assert.IsNotEmpty(this.parameterSubscription.ValidationErrors);
        }

        [Test]
        public void VerifyThatParameterHasNoError()
        {
            var valuesetoverriden = new ParameterValueSet(Guid.NewGuid(), null, null);
            var valueset = new ParameterSubscriptionValueSet(Guid.NewGuid(), null, null) { SubscribedValueSet = valuesetoverriden };
            var data = new List<string> { "-" };
            valueset.Manual = new ValueArray<string>(data);
            valuesetoverriden.Computed = new ValueArray<string>(data);
            valuesetoverriden.Reference = new ValueArray<string>(data);
            valuesetoverriden.Formula = new ValueArray<string>(data);
            valuesetoverriden.Published = new ValueArray<string>(data);

            this.parameter.IsOptionDependent = false;
            this.parameter.StateDependence = null;

            this.parameterSubscription.ValueSet.Add(valueset);
            valueset.ValidatePoco();
            this.parameterSubscription.ValidatePoco();

            Assert.IsEmpty(this.parameterSubscription.ValidationErrors);
        }
    }
}