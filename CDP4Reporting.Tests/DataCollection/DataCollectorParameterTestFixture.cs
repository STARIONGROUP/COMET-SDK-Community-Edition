﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataSourceParameterTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Reporting.Tests.DataCollection
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using CDP4Reporting.DataCollection;

    using NUnit.Framework;

    [TestFixture]
    public class DataCollectorParameterTestFixture
    {
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;

        public Iteration iteration;

        public Option option;

        public Category cat1;
        private Category cat2;

        private DomainOfExpertise elementOwner;
        private DomainOfExpertise parameterOwner;
        private DomainOfExpertise parameterOverrideOwner;

        private RatioScale scale;

        private SimpleQuantityKind parameterType1;
        private SimpleQuantityKind parameterType2;
        private SimpleQuantityKind parameterType3;
        private SimpleQuantityKind parameterType4;
        private CompoundParameterType parameterType5;

        public ElementDefinition ed1;
        private ElementDefinition ed2;

        private ElementUsage eu1;
        private ElementUsage eu2;

        private ActualFiniteState actualFiniteState1;
        private ActualFiniteState actualFiniteState2;
        public ActualFiniteStateList actualList;
        private EngineeringModel model;

        private PossibleFiniteStateList possibleList;

        private PossibleFiniteState possibleState1;
        private PossibleFiniteState possibleState2;

        private class TestParameter1 : DataCollectorParameter<Row, string>
        {
            public override string Parse(string value)
            {
                return value;
            }
        }

        private class TestParameter2 : DataCollectorParameter<Row, string>
        {

            public override string Parse(string value)
            {
                return value;
            }
        }

        private class TestParameter3 : DataCollectorParameter<Row, string>
        {
            public override string Parse(string value)
            {
                return value;
            }
        }

        private class ComputedTestParameter : DataCollectorParameter<Row, string>
        {
            public override string Parse(string value)
            {
                return null;
            }
        }

        private class Row : DataCollectorRow
        {
            [DefinedThingShortName("type1")]
            public TestParameter1 parameter1 { get; set; }

            [DefinedThingShortName("type2")]
            public TestParameter2 parameter2 { get; set; }

            public ComputedTestParameter ComputedParameter { get; set; }
        }

        private class CollectParentValuesRow : DataCollectorRow
        {
            [DefinedThingShortName("type1")]
            [CollectParentValues]
            public TestParameter1 parameter1 { get; set; }

            [DefinedThingShortName("type2")]
            public TestParameter2 parameter2 { get; set; }

            [CollectParentValues]
            public string ComputedParameter => "ComputedValue";
        }

        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<Thing>>();

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, null);

            this.model = new EngineeringModel(Guid.NewGuid(), null, null);
            this.model.Iteration.Add(this.iteration);

            var modelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.NewGuid(), this.cache, null);
            var iterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, null);
            var engineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), this.cache, null);

            this.model.EngineeringModelSetup = engineeringModelSetup;

            iterationSetup.Container = engineeringModelSetup;
            this.model.EngineeringModelSetup = engineeringModelSetup;
            engineeringModelSetup.RequiredRdl.Add(modelReferenceDataLibrary);

            this.iteration.IterationSetup = iterationSetup;
            this.iteration.Container = this.model;

            // Option

            this.option = new Option(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "option1",
                Name = "option1"
            };

            this.iteration.Option.Add(this.option);

            this.actualFiniteState1 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualFiniteState2 = new ActualFiniteState(Guid.NewGuid(), null, null);
            this.actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            this.actualList.Owner = new DomainOfExpertise(Guid.NewGuid(), null, null);

            this.possibleList = new PossibleFiniteStateList(Guid.NewGuid(), null, null);

            this.possibleState1 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate1", ShortName = "state1" };
            this.possibleState2 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate2", ShortName = "state2" };

            this.possibleList.PossibleState.Add(this.possibleState1);
            this.possibleList.PossibleState.Add(this.possibleState2);

            this.actualFiniteState1.PossibleState.Add(this.possibleState1);
            this.actualFiniteState2.PossibleState.Add(this.possibleState2);

            this.actualList.PossibleFiniteStateList.Add(this.possibleList);

            this.iteration.ActualFiniteStateList.Add(this.actualList);
            this.iteration.PossibleFiniteStateList.Add(this.possibleList);
            this.actualList.ActualState.Add(this.actualFiniteState1);
            this.actualList.ActualState.Add(this.actualFiniteState2);

            // Categories

            this.cat1 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat1",
                Name = "cat1"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat1);

            this.cache.TryAdd(
                new CacheKey(this.cat1.Iid, null),
                new Lazy<Thing>(() => this.cat1));

            this.cat2 = new Category(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "cat2",
                Name = "cat2"
            };

            modelReferenceDataLibrary.DefinedCategory.Add(this.cat2);

            this.cache.TryAdd(
                new CacheKey(this.cat2.Iid, null),
                new Lazy<Thing>(() => this.cat2));

            // Domains of expertise

            this.elementOwner = new DomainOfExpertise(Guid.NewGuid(), null, null)
            {
                ShortName = "owner",
                Name = "element owner"
            };

            this.parameterOwner = new DomainOfExpertise(Guid.NewGuid(), null, null)
            {
                ShortName = "owner1",
                Name = "parameter owner"
            };

            this.parameterOverrideOwner = new DomainOfExpertise(Guid.NewGuid(), null, null)
            {
                ShortName = "owner2",
                Name = "parameter override owner"
            };

            // Scale

            this.scale = new RatioScale(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "scale",
                Name = "scale"
            };

            // Parameter types

            this.parameterType1 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "type1",
                Name = "parameter type 1"
            };

            this.parameterType2 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "type2",
                Name = "parameter type 2"
            };

            this.parameterType3 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "type3",
                Name = "parameter type 3"
            };

            this.parameterType4 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "type4",
                Name = "parameter type 4",
            };

            this.parameterType5 = new CompoundParameterType(Guid.NewGuid(), null, null)
            {
                ShortName = "type5",
                Name = "parameter type 5",
            };

            var param1 = new TextParameterType {ShortName = "param1", Name = "param1"};
            var param2 = new SimpleQuantityKind {ShortName = "param2", Name = "param2"};

            var paramc1 = new ParameterTypeComponent {ParameterType = param1, ShortName = "param1"};
            var paramc2 = new ParameterTypeComponent {ParameterType = param2, ShortName = "param2"};

            this.parameterType5.Component.Add(paramc1);
            this.parameterType5.Component.Add(paramc2);

            // Element Definitions

            this.ed1 = new ElementDefinition(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "ed1",
                Name = "element definition 1",
                Owner = this.elementOwner
            };

            this.AddParameter(this.ed1, this.parameterType1, this.parameterOwner, "11");
            this.AddParameter(this.ed1, this.parameterType2, this.parameterOwner, "12");
            this.AddParameter(this.ed1, this.parameterType3, this.parameterOwner, "13");
            this.AddStateDependentParameter(this.ed1, this.parameterType4, this.parameterOwner, this.actualList, "14");
            this.AddCompoundParameter(this.ed1, this.parameterType5, this.parameterOwner, new [] {"15", "16"});

            this.ed2 = new ElementDefinition(Guid.NewGuid(), this.cache, null)
            {
                ShortName = "ed2",
                Name = "element definition 2",
                Owner = this.elementOwner
            };

            var parameter1 = this.AddParameter(this.ed2, this.parameterType1, this.elementOwner, "-21");
            var parameter2 = this.AddParameter(this.ed2, this.parameterType2, this.elementOwner, "-22");
            var parameter3 = this.AddParameter(this.ed2, this.parameterType3, this.elementOwner, "-23");

            // Element Usages

            this.eu1 = new ElementUsage(Guid.NewGuid(), this.cache, null)
            {
                ElementDefinition = this.ed2,
                ShortName = "eu1",
                Name = "element usage 1",
                Owner = this.elementOwner
            };

            this.AddParameterOverride(this.eu1, this.parameterType1, this.parameterOverrideOwner, parameter1.ValueSet.First(), "121");
            this.AddParameterOverride(this.eu1, this.parameterType2, this.parameterOverrideOwner, parameter2.ValueSet.First(), "122");
            this.AddParameterOverride(this.eu1, this.parameterType3, this.parameterOverrideOwner, parameter3.ValueSet.First(), "123");

            this.eu2 = new ElementUsage(Guid.NewGuid(), this.cache, null)
            {
                ElementDefinition = this.ed2,
                ShortName = "eu2",
                Name = "element usage 2",
                Owner = this.elementOwner
            };

            // Structure

            this.iteration.TopElement = this.ed1;
            this.ed1.Category.Add(this.cat1);

            this.eu1.Category.Add(this.cat2);
            this.ed1.ContainedElement.Add(this.eu1);

            this.eu2.Category.Add(this.cat2);
            this.ed1.ContainedElement.Add(this.eu2);

            this.iteration.Element.Add(this.ed1);
            this.iteration.Element.Add(this.ed2);
        }

        private Parameter AddParameter(
            ElementDefinition elementDefinition,
            ParameterType parameterType,
            DomainOfExpertise owner,
            string value)
        {
            var parameter = new Parameter(Guid.NewGuid(), this.cache, null)
            {
                ParameterType = parameterType,
                Owner = owner,
                Scale = this.scale
        };

            var valueSet = new ParameterValueSet(Guid.NewGuid(), this.cache, null)
            {
                Published = new ValueArray<string>(new List<string> { value }),
                Manual = new ValueArray<string>(new List<string> { value }),
                Computed = new ValueArray<string>(new List<string> { value }),
                Formula = new ValueArray<string>(new List<string> { value }),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };

            parameter.ValueSet.Add(valueSet);

            elementDefinition.Parameter.Add(parameter);

            return parameter;
        }

        private Parameter AddStateDependentParameter(
            ElementDefinition elementDefinition,
            ParameterType parameterType,
            DomainOfExpertise owner,
            ActualFiniteStateList actualFiniteStateList,
            string value)
        {
            var parameter = new Parameter(Guid.NewGuid(), this.cache, null)
            {
                ParameterType = parameterType,
                Owner = owner,
                Scale = this.scale
            };

            foreach (var state in actualFiniteStateList.ActualState)
            {
                var valueSet = new ParameterValueSet(Guid.NewGuid(), this.cache, null)
                {
                    ActualState = state,
                    Published = new ValueArray<string>(new List<string> { value }),
                    Manual = new ValueArray<string>(new List<string> { value }),
                    Computed = new ValueArray<string>(new List<string> { value }),
                    Formula = new ValueArray<string>(new List<string> { value }),
                    ValueSwitch = ParameterSwitchKind.MANUAL
                };

                parameter.ValueSet.Add(valueSet);
            }

            elementDefinition.Parameter.Add(parameter);

            return parameter;
        }

        private Parameter AddCompoundParameter(
            ElementDefinition elementDefinition,
            ParameterType parameterType,
            DomainOfExpertise owner,
            string[] values)
        {
            var parameter = new Parameter(Guid.NewGuid(), this.cache, null)
            {
                ParameterType = parameterType,
                Owner = owner,
                Scale = this.scale
            };

            var valueSet = new ParameterValueSet(Guid.NewGuid(), this.cache, null)
            {
                Published = new ValueArray<string>(new List<string>(values)),
                Manual = new ValueArray<string>(new List<string>(values)),
                Computed = new ValueArray<string>(new List<string>(values)),
                Formula = new ValueArray<string>(new List<string>(values)),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };

            parameter.ValueSet.Add(valueSet);

            elementDefinition.Parameter.Add(parameter);

            return parameter;
        }

        private void AddParameterOverride(
            ElementUsage elementUsage,
            ParameterType parameterType,
            DomainOfExpertise owner,
            ParameterValueSet parameterValueSet,
            string value)
        {
            var parameter = elementUsage.ElementDefinition.Parameter
                .First(p => p.ParameterType == parameterType);

            var parameterOverride = new ParameterOverride(Guid.NewGuid(), this.cache, null)
            {
                Parameter = parameter,
                Owner = owner
            };

            var valueSet = new ParameterOverrideValueSet(Guid.NewGuid(), this.cache, null)
            {
                ParameterValueSet = parameterValueSet,
                Published = new ValueArray<string>(new List<string> { value }),
                Manual = new ValueArray<string>(new List<string> { value }),
                Computed = new ValueArray<string>(new List<string> { value }),
                Formula = new ValueArray<string>(new List<string> { value }),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };

            parameterOverride.ValueSet.Add(valueSet);

            elementUsage.ParameterOverride.Add(parameterOverride);
        }

        [Test]
        public void VerifyThatNodeIdentifiesParameters()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            Assert.That(node.GetColumns<TestParameter1>().Count(), Is.EqualTo(1));
            Assert.That(node.GetColumns<TestParameter2>().Count(), Is.EqualTo(1));
            Assert.That(node.GetColumns<TestParameter3>().Count(), Is.EqualTo(0));
            Assert.That(node.GetColumns<ComputedTestParameter>().Count(), Is.EqualTo(1));
        }

        [Test]
        public void VerifyThatNodeIdentifiesCollectParentValueParameters()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<CollectParentValuesRow>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var dataTable = dataSource.GetTable(
                hierarchy,
                nestedElementTree);

            Assert.That(dataTable.Columns.Contains($"{nameof(CollectParentValuesRow.parameter1)}"), Is.True);
            Assert.That(dataTable.Columns.Contains($"{nameof(CollectParentValuesRow.parameter2)}"), Is.True);
            Assert.That(dataTable.Columns.Contains($"{nameof(CollectParentValuesRow.ComputedParameter)}"), Is.True);
            Assert.That(dataTable.Columns.Contains($"{nameof(CollectParentValuesRow.parameter1)}_{this.cat1.ShortName}"), Is.True);
            Assert.That(dataTable.Columns.Contains($"{nameof(CollectParentValuesRow.ComputedParameter)}_{this.cat1.ShortName}"), Is.True);
        }

        [Test]
        public void VerifyParameterShortNameInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var parameter1 = node.GetColumns<TestParameter1>().Single();
            Assert.That(parameter1.FieldName, Is.EqualTo("type1"));

            var parameter2 = node.GetColumns<TestParameter2>().Single();
            Assert.That(parameter2.FieldName, Is.EqualTo("type2"));

            var computedParameter = node.GetColumns<ComputedTestParameter>().Single();
            Assert.That(computedParameter.FieldName, Is.Null);
        }

        [Test]
        public void VerifyComputedParameterInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var computedParameter = node.GetColumns<ComputedTestParameter>().Single();
            Assert.That(computedParameter.ValueSets, Is.EqualTo(null));
            Assert.That(computedParameter.Owner, Is.EqualTo(null));
        }

        [Test]
        public void VerifyParameterInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat1.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var parameter1 = node.GetColumns<TestParameter1>().Single();
            Assert.That(parameter1.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("11"));
            Assert.That(parameter1.Owner, Is.EqualTo(this.parameterOwner));

            var parameter2 = node.GetColumns<TestParameter2>().Single();
            Assert.That(parameter2.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("12"));
            Assert.That(parameter2.Owner, Is.EqualTo(this.parameterOwner));
        }

        [Test]
        public void VerifyParameterOverrideInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat2.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First();

            var parameter1 = node.GetColumns<TestParameter1>().Single();
            Assert.That(parameter1.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("121"));
            Assert.That(parameter1.Owner, Is.EqualTo(this.parameterOverrideOwner));

            var parameter2 = node.GetColumns<TestParameter2>().Single();
            Assert.That(parameter2.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("122"));
            Assert.That(parameter2.Owner, Is.EqualTo(this.parameterOverrideOwner));
        }

        [Test]
        public void VerifyNestedParameterInitialization()
        {
            var hierarchy = new CategoryDecompositionHierarchy
                    .Builder(this.iteration, this.cat2.ShortName)
                .Build();

            var dataSource = new DataCollectorNodesCreator<Row>();
            var nestedElementTree = new NestedElementTreeGenerator().Generate(this.option).ToList();

            var node = dataSource.CreateNodes(
                hierarchy,
                nestedElementTree).First(x => x.ElementBase.Iid == this.eu2.Iid);

            var parameter1 = node.GetColumns<TestParameter1>().Single();
            Assert.That(parameter1.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("-21"));
            Assert.That(parameter1.Owner, Is.EqualTo(this.elementOwner));

            var parameter2 = node.GetColumns<TestParameter2>().Single();
            Assert.That(parameter2.ValueSets.FirstOrDefault()?.ActualValue.First(), Is.EqualTo("-22"));
            Assert.That(parameter2.Owner, Is.EqualTo(this.elementOwner));
        }
    }
}
