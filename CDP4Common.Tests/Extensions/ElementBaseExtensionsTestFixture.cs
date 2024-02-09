// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ElementBaseExtensionsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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

namespace CDP4Common.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;
    
    using NUnit.Framework;

    [TestFixture]
    public class ElementBaseExtensionsTestFixture
    {
        private List<ElementBase> elementDefinitions;
        private ActualFiniteState actualFiniteState;
        private ElementDefinition elementDefinition;
        private ElementUsage elementUsage;
        private ElementBase elementBase;

        [SetUp]
        public void SetUp()
        {
            this.actualFiniteState = new ActualFiniteState()
            {
                Iid = Guid.NewGuid(),
            };

            var parameterType1 = new TextParameterType()
            {
                Iid = Guid.NewGuid(),
                Name = "parameter1",
                ShortName = "param1"
            };

            var parameterType2 = new SimpleQuantityKind()
            {
                Iid = Guid.NewGuid(),
                Name = "parameter2",
                ShortName = "param2"
            };

            var parameter1 = new Parameter
            {
                Iid = Guid.NewGuid(),
                ParameterType = parameterType1,
                ValueSet =
                {
                    new ParameterValueSet()
                    {
                        ActualState = this.actualFiniteState
                    }
                }
            };

            var parameter2 = new Parameter
            {
                Iid = Guid.NewGuid(),
                ParameterType = parameterType2,
            };

            var parameter3 = new ParameterOverride
            {
                Parameter = parameter1,
                Iid = Guid.NewGuid(),
            };

            var parameter4 = new ParameterOverride
            {
                Parameter = parameter2,
                Iid = Guid.NewGuid(),
            };

            this.elementDefinition = new ElementDefinition()
            {
                Parameter = { parameter1, parameter2 }
            };

            this.elementUsage = new ElementUsage()
            {
                ElementDefinition = this.elementDefinition,
                ParameterOverride = { parameter3, parameter4 }
            };

            this.elementBase = new ElementDefinition()
            {
                Parameter = { parameter2 }
            };

            this.elementDefinitions = new List<ElementBase>()
            {
                this.elementUsage,
                this.elementDefinition,
                this.elementBase
            };
        }

        [Test]
        public void VerifyThatParametersCanBeRetrievedFromElements()
        {
            var result1 = this.elementUsage.QueryParametersInUse().ToList();
            var result2 = this.elementDefinition.QueryParametersInUse().ToList();
            var result3 = this.elementBase.QueryParametersInUse().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(result1, Is.Not.Null);
                Assert.That(result1, Has.Count.EqualTo(2));
                Assert.That(result2, Is.Not.Null);
                Assert.That(result2, Has.Count.EqualTo(2));
                Assert.That(result3, Is.Not.Null);
                Assert.That(result3, Has.Count.EqualTo(1));
            });
        }

        [Test]
        public void VerifyThatFilterByStateWorks()
        {
            var result = this.elementDefinitions.FilterByState(this.actualFiniteState);

            Assert.Multiple(() =>
            {
                Assert.That(this.elementDefinitions, Has.Count.EqualTo(3));
                Assert.That(result, Has.Count.EqualTo(2));
            });
        }
    }
}
