// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedElementTreeGeneratorTestFixtre.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Tests.Helpers
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="NestedElementTreeGenerator"/> class.
    /// </summary>
    [TestFixture]
    public class NestedElementTreeGeneratorTestFixture
    {
        public NestedElementTreeGenerator nestedElementTreeGenerator;
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;
        public Iteration iteration;
        public DomainOfExpertise domainOfExpertise;
        public DomainOfExpertise domainOfExpertise_2;
        private ElementDefinition elementDefinition_1;
        private ElementDefinition elementDefinition_2;
        private ElementUsage elementUsage_1;
        private ElementUsage elementUsage_2;
        private Option option_A;
        private Option option_B;
        private Parameter parameter;
        private ParameterOverride parameterOverride;
        private Parameter parameter2; 
        private Parameter parameter3;
        private ActualFiniteState actualState_3;
        private ActualFiniteState actualState_4;

        [SetUp]
        public void SetUp()
        {
            this.nestedElementTreeGenerator = new NestedElementTreeGenerator();

            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            this.domainOfExpertise = new DomainOfExpertise(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "SYS",
                Name = "System"
            };

            this.domainOfExpertise_2 = new DomainOfExpertise(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "TEST",
                Name = "Test"
            };

            this.iteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);

            this.option_A = new Option(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "OPT_A",
                Name = "Option A"
            };

            this.option_B = new Option(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "OPT_B",
                Name = "Option B"
            };

            this.elementDefinition_1 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "Sat",
                Name = "Satellite"
            };

            this.elementDefinition_2 = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "Bat",
                Name = "Battery"
            };

            this.elementUsage_1 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = this.elementDefinition_2,
                ShortName = "bat_a",
                Name = "battery a"
            };

            this.elementUsage_2 = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ElementDefinition = this.elementDefinition_2,
                ShortName = "bat_b",
                Name = "battery b"
            };

            var simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "m"
            };

            var simpleQuantityKind2 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "v"
            };

            var simpleQuantityKind3 = new SimpleQuantityKind(Guid.NewGuid(), null, null)
            {
                ShortName = "q"
            };

            this.parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = this.domainOfExpertise,
                ParameterType = simpleQuantityKind
            };

            this.parameter2 = new Parameter(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = this.domainOfExpertise_2,
                ParameterType = simpleQuantityKind2
            };

            this.parameter3 = new Parameter(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = this.domainOfExpertise,
                ParameterType = simpleQuantityKind3
            };

            this.parameterOverride = new ParameterOverride(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = this.domainOfExpertise,
                Parameter = this.parameter
            };

            var parameterValueset_1 = new ParameterValueSet()
            {
                ActualOption = this.option_B,
                Iid = Guid.NewGuid()
            };

            var parameterValueset_2 = new ParameterValueSet()
            {
                ActualOption = this.option_A,
                Iid = Guid.NewGuid()
            };

            var actualList = new ActualFiniteStateList(Guid.NewGuid(), null, null);
            actualList.Owner = this.domainOfExpertise;

            var possibleList1 = new PossibleFiniteStateList(Guid.NewGuid(), null, null);

            var possibleState1 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate1", ShortName = "1" };
            var possibleState2 = new PossibleFiniteState(Guid.NewGuid(), null, null) { Name = "possiblestate2", ShortName = "2" };

            possibleList1.PossibleState.Add(possibleState1);
            possibleList1.PossibleState.Add(possibleState2);

            actualList.PossibleFiniteStateList.Add(possibleList1);

            this.actualState_3 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);

            this.actualState_3.PossibleState.Add(possibleState1);

            this.actualState_4 = new ActualFiniteState(Guid.NewGuid(), this.cache, this.uri);

            this.actualState_4.PossibleState.Add(possibleState2);

            var parameterValueset_3 = new ParameterValueSet()
            {
                ActualState = this.actualState_3,
                Iid = Guid.NewGuid()
            };

            var parameterValueset_4 = new ParameterValueSet()
            {
                ActualState = this.actualState_4,
                Iid = Guid.NewGuid()
            };

            var parameterValueset_5 = new ParameterValueSet()
            {
                ActualOption = this.option_A,
                Iid = Guid.NewGuid()
            };

            var values_1 = new List<string> { "2" };
            var values_2 = new List<string> { "3" };
            var values_3 = new List<string> { "220" };
            var values_4 = new List<string> { "0" };

            var overrideValueset = new ParameterOverrideValueSet()
            {
                ParameterValueSet = parameterValueset_1,
                Iid = Guid.NewGuid()
            };

            this.iteration.Option.Add(this.option_A);
            this.iteration.Option.Add(this.option_B);
            this.iteration.DefaultOption = this.option_A;

            parameterValueset_1.Manual = new CDP4Common.Types.ValueArray<string>(values_1);
            parameterValueset_1.Reference = new CDP4Common.Types.ValueArray<string>(values_1);
            parameterValueset_1.Computed = new CDP4Common.Types.ValueArray<string>(values_1);
            parameterValueset_1.Formula = new CDP4Common.Types.ValueArray<string>(values_1);
            parameterValueset_1.ValueSwitch = ParameterSwitchKind.MANUAL;

            parameterValueset_2.Manual = new CDP4Common.Types.ValueArray<string>(values_2);
            parameterValueset_2.Reference = new CDP4Common.Types.ValueArray<string>(values_2);
            parameterValueset_2.Computed = new CDP4Common.Types.ValueArray<string>(values_2);
            parameterValueset_2.Formula = new CDP4Common.Types.ValueArray<string>(values_2);
            parameterValueset_2.ValueSwitch = ParameterSwitchKind.MANUAL;

            parameterValueset_3.Manual = new CDP4Common.Types.ValueArray<string>(values_3);
            parameterValueset_3.Reference = new CDP4Common.Types.ValueArray<string>(values_3);
            parameterValueset_3.Computed = new CDP4Common.Types.ValueArray<string>(values_3);
            parameterValueset_3.Formula = new CDP4Common.Types.ValueArray<string>(values_3);
            parameterValueset_3.ValueSwitch = ParameterSwitchKind.MANUAL;

            parameterValueset_4.Manual = new CDP4Common.Types.ValueArray<string>(values_4);
            parameterValueset_4.Reference = new CDP4Common.Types.ValueArray<string>(values_4);
            parameterValueset_4.Computed = new CDP4Common.Types.ValueArray<string>(values_4);
            parameterValueset_4.Formula = new CDP4Common.Types.ValueArray<string>(values_4);
            parameterValueset_4.ValueSwitch = ParameterSwitchKind.MANUAL;

            parameterValueset_5.Manual = null;
            parameterValueset_5.Reference = null;
            parameterValueset_5.Computed = null;
            parameterValueset_5.Formula = null;

            overrideValueset.Manual = new CDP4Common.Types.ValueArray<string>(values_1);
            overrideValueset.Reference = new CDP4Common.Types.ValueArray<string>(values_1);
            overrideValueset.Computed = new CDP4Common.Types.ValueArray<string>(values_1);
            overrideValueset.Formula = new CDP4Common.Types.ValueArray<string>(values_1);
            overrideValueset.ValueSwitch = ParameterSwitchKind.MANUAL;

            this.parameter.ValueSet.Add(parameterValueset_1);
            this.parameter.ValueSet.Add(parameterValueset_2);
            this.parameterOverride.ValueSet.Add(overrideValueset);

            this.parameter2.ValueSet.Add(parameterValueset_3);
            this.parameter2.ValueSet.Add(parameterValueset_4);

            this.elementUsage_1.ExcludeOption.Add(this.option_A);
            this.elementUsage_1.ParameterOverride.Add(this.parameterOverride);

            this.elementDefinition_1.Parameter.Add(this.parameter);
            this.elementDefinition_1.ContainedElement.Add(this.elementUsage_1);
            this.elementDefinition_1.ContainedElement.Add(this.elementUsage_2);
            this.elementDefinition_2.Parameter.Add(this.parameter);
            this.elementDefinition_2.Parameter.Add(this.parameter2);
            this.elementDefinition_2.Parameter.Add(this.parameter3);

            this.iteration.Element.Add(this.elementDefinition_1);
            this.iteration.Element.Add(this.elementDefinition_2);
            this.iteration.TopElement = this.elementDefinition_1;

            this.iteration.ActualFiniteStateList.Add(actualList);
            this.iteration.PossibleFiniteStateList.Add(possibleList1);
            actualList.ActualState.Add(this.actualState_3);
            actualList.ActualState.Add(this.actualState_4);
        }

        [Test]
        public void Verify_that_null_arguments_throws_exception()
        {
            var option = this.iteration.Option.First();

            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.Generate(null, null));

            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.Generate(option, null));

            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.GetNestedParameters(option, null));

            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.GetNestedParameters(null, null));

            Assert.Throws<ArgumentNullException>(() => this.nestedElementTreeGenerator.GetNestedParameters(null, this.domainOfExpertise));
        }

        [Test]
        public void Verify_that_excluded_usage_option_a_does_not_get_generated_as_nested_element()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var nestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise).ToList();

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(2, nestedElements.Count);
        }

        [Test]
        public void Verify_that_excluded_usage_option_a_does_not_get_generated_as_nested_element_if_option_is_a_cloned_object()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");
            var optionClone = option.Clone(false);

            var nestedElements = this.nestedElementTreeGenerator.Generate(optionClone, this.domainOfExpertise).ToList();

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(2, nestedElements.Count);
        }

        [Test]
        public void Verify_that_excluded_usage_from_a_In_option_b_get_generated_as_nested_element()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_B");

            var nestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise).ToList();

            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine(nestedElement.ShortName);
            }

            Assert.AreEqual(3, nestedElements.Count);
        }

        [Test]
        public void Verify_that_the_function_returns_values()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");
            var flatNestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, this.domainOfExpertise).ToList();

            Assert.IsNotEmpty(flatNestedParameters);
        }

        [Test]
        public void Verify_that_Path_returns_value_for_Each_NestedElement_and_NestedParameter()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");
            var flatNestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, this.domainOfExpertise).ToList();

            foreach (var nestedParameter in flatNestedParameters)
            {
                Assert.DoesNotThrow(() =>
                {
                    var path = nestedParameter.Path;
                });
            }
        }

        [Test]
        public void Verify_that_Option_is_set_on_NestedElement_and_NestedParameter()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var nestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise);

            foreach (var nestedElement in nestedElements)
            {
                Assert.AreEqual(option, nestedElement.Container);

                foreach (var nestedParameter in nestedElement.NestedParameter)
                {
                    Assert.AreEqual(option, nestedParameter.Option);
                }
            }
        }

        [Test]
        public void Verify_that_ValueSet_is_set_on_NestedElement_and_NestedParameter()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, this.domainOfExpertise, false).ToList();

            foreach (var nestedParameter in NestedParameters)
            {
                Assert.IsNotNull(nestedParameter.ValueSet);
            }
        }

        [Test]
        public void Verify_that_GetNestedParameters_Works_For_Specific_DomainOfExpertise()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, this.domainOfExpertise, false).ToList();

            Assert.AreEqual(4, NestedParameters.Count);

            NestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, this.domainOfExpertise_2, false).ToList();

            Assert.AreEqual(2, NestedParameters.Count);
        }

        [Test]
        public void Verify_that_GetNestedParameters_Works_For_All_DomainOfExpertises()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedParameters = this.nestedElementTreeGenerator.GetNestedParameters(option, false).ToList();

            Assert.AreEqual(6, NestedParameters.Count);
        }

        [Test]
        public void Verify_that_Generate_Works_For_Specific_DomainOfExpertise()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(4, NestedElements.SelectMany(x => x.NestedParameter).Count());

            NestedElements = this.nestedElementTreeGenerator.Generate(option, this.domainOfExpertise_2, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(2, NestedElements.SelectMany(x => x.NestedParameter).Count());
        }

        [Test]
        public void Verify_that_Generate_Works_For_All_DomainOfExpertises()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedElements = this.nestedElementTreeGenerator.Generate(option, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(6, NestedElements.SelectMany(x => x.NestedParameter).Count());
        }

        [Test]
        public void Verify_that_GenerateNestedElements_Works_For_Specific_DomainOfExpertise()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedElements = this.nestedElementTreeGenerator.GenerateNestedElements(option, this.domainOfExpertise, this.elementDefinition_1, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(4, NestedElements.SelectMany(x => x.NestedParameter).Count());

            NestedElements = this.nestedElementTreeGenerator.GenerateNestedElements(option, this.domainOfExpertise_2, this.elementDefinition_1, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(2, NestedElements.SelectMany(x => x.NestedParameter).Count());
        }

        [Test]
        public void Verify_that_GenerateNestedElements_Works_For_All_DomainOfExpertises()
        {
            var option = this.iteration.Option.Single(x => x.ShortName == "OPT_A");

            var NestedElements = this.nestedElementTreeGenerator.GenerateNestedElements(option, this.elementDefinition_1, false).ToList();

            Assert.AreEqual(2, NestedElements.Count);
            Assert.AreEqual(6, NestedElements.SelectMany(x => x.NestedParameter).Count());
        }

        [Test]
        public void VerifyThatGetNestedElementShortNameWorksForElementDefinition()
        {
            Assert.AreEqual("Sat", this.nestedElementTreeGenerator.GetNestedElementPath(this.elementDefinition_1, this.option_A));
            Assert.AreEqual(null, this.nestedElementTreeGenerator.GetNestedElementPath(this.elementDefinition_2, this.option_A));
            Assert.AreEqual("Sat", this.nestedElementTreeGenerator.GetNestedElementPath(this.elementDefinition_1, this.option_B));
            Assert.AreEqual(null, this.nestedElementTreeGenerator.GetNestedElementPath(this.elementDefinition_2, this.option_B));
        }

        [Test]
        public void VerifyThatGetNestedElementShortNameWorksForElementUsage()
        {
            Assert.AreEqual(null, this.nestedElementTreeGenerator.GetNestedElementPath(this.elementUsage_1, this.option_A));
            Assert.AreEqual("Sat.bat_b", this.nestedElementTreeGenerator.GetNestedElementPath(this.elementUsage_2, this.option_A));
            Assert.AreEqual("Sat.bat_a", this.nestedElementTreeGenerator.GetNestedElementPath(this.elementUsage_1, this.option_B));
            Assert.AreEqual("Sat.bat_b", this.nestedElementTreeGenerator.GetNestedElementPath(this.elementUsage_2, this.option_B));
        }

        [Test]
        public void VerifyThatGetNestedParameterPathWorks()
        {
            Assert.AreEqual(@"Sat\m\\OPT_A", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter, this.option_A));
            Assert.AreEqual(@"Sat.bat_b\v\1\OPT_A", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_A));
            Assert.AreEqual(@"Sat.bat_b\v\1\OPT_A", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_A, this.actualState_3));
            Assert.AreEqual(@"Sat.bat_b\v\2\OPT_A", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_A, this.actualState_4));
            Assert.AreEqual(@"Sat\m\\OPT_A", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameterOverride, this.option_A));
            Assert.AreEqual(@"Sat\m\\OPT_B", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter, this.option_B));
            Assert.AreEqual(@"Sat.bat_a\v\1\OPT_B", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_B));
            Assert.AreEqual(@"Sat.bat_a\v\1\OPT_B", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_B, this.actualState_3));
            Assert.AreEqual(@"Sat.bat_a\v\2\OPT_B", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameter2, this.option_B, this.actualState_4));
            Assert.AreEqual(@"Sat\m\\OPT_B", this.nestedElementTreeGenerator.GetNestedParameterPath(this.parameterOverride, this.option_B));
        }

        [Test]
        public void Verify_that_a_nested_parameter_for_an_override_references_the_override_and_not_the_a_parameter()
        {
            var testiteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            
            var option = new Option(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "option_1",
                Name = "option 1"
            };

            testiteration.Option.Add(option);

            var system_engineering = new DomainOfExpertise(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "SYS",
                Name = "System"
            };

            var mass = new SimpleQuantityKind(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "m"
            };
            
            var power = new SimpleQuantityKind(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "p"
            };

            var values_1 = new List<string> { "1" };
            var values_2 = new List<string> { "2" };

            var satellite_definition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "SAT",
                Name = "Satellite",
                Owner = system_engineering
            };

            testiteration.Element.Add(satellite_definition);
            testiteration.TopElement = satellite_definition;

            var battery_definition = new ElementDefinition(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "BAT",
                Name = "Battery",
                Owner = system_engineering
            };

            var mass_parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = system_engineering,
                ParameterType = mass
            };

            var mass_parameterValueset = new ParameterValueSet(Guid.NewGuid(), this.cache, this.uri)
            {
                Iid = Guid.NewGuid(),
                Manual = new CDP4Common.Types.ValueArray<string>(values_1),
                Reference = new CDP4Common.Types.ValueArray<string>(values_1),
                Computed = new CDP4Common.Types.ValueArray<string>(values_1),
                Formula = new CDP4Common.Types.ValueArray<string>(values_1),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };
            
            mass_parameter.ValueSet.Add(mass_parameterValueset);
            
            var power_parameter = new Parameter(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = system_engineering,
                ParameterType = power
            };

            var power_parameterValueset = new ParameterValueSet(Guid.NewGuid(), this.cache, this.uri)
            {
                Iid = Guid.NewGuid(),
                Manual = new CDP4Common.Types.ValueArray<string>(values_1),
                Reference = new CDP4Common.Types.ValueArray<string>(values_1),
                Computed = new CDP4Common.Types.ValueArray<string>(values_1),
                Formula = new CDP4Common.Types.ValueArray<string>(values_1),
                ValueSwitch = ParameterSwitchKind.MANUAL
            };

            power_parameter.ValueSet.Add(power_parameterValueset);

            battery_definition.Parameter.Add(mass_parameter);
            battery_definition.Parameter.Add(power_parameter);

            testiteration.Element.Add(battery_definition);

            var battery_usage = new ElementUsage(Guid.NewGuid(), this.cache, this.uri)
            {
                ShortName = "BAT_a",
                Name = "Battery A",
                ElementDefinition = battery_definition,
                Owner = system_engineering
            };

            var mass_parameteroverride = new ParameterOverride(Guid.NewGuid(), this.cache, this.uri)
            {
                Owner = system_engineering,
                Parameter = mass_parameter,
            };

            var mass_parameterOverrideValueset = new ParameterOverrideValueSet(Guid.NewGuid(), this.cache, this.uri)
            {
                Iid = Guid.NewGuid(),
                Manual = new CDP4Common.Types.ValueArray<string>(values_2),
                Reference = new CDP4Common.Types.ValueArray<string>(values_2),
                Computed = new CDP4Common.Types.ValueArray<string>(values_2),
                Formula = new CDP4Common.Types.ValueArray<string>(values_2),
                ValueSwitch = ParameterSwitchKind.MANUAL,
                ParameterValueSet = mass_parameterValueset
            };

            mass_parameteroverride.ValueSet.Add(mass_parameterOverrideValueset);

            battery_usage.ParameterOverride.Add(mass_parameteroverride);

            satellite_definition.ContainedElement.Add(battery_usage);
            
            var nestedElements =this.nestedElementTreeGenerator.Generate(option, system_engineering, false).ToList();
            
            foreach (var nestedElement in nestedElements)
            {
                Console.WriteLine($"NE: - {nestedElement.ShortName}:{nestedElement.Name}");

                foreach (var nestedParameter in nestedElement.NestedParameter)
                {
                    Console.WriteLine($"NP: - {nestedParameter.Path}:{nestedParameter.UserFriendlyShortName}:{nestedParameter.ActualValue}");
                }
            }

            var nested_battery_a = nestedElements.Single(x => x.ShortName == "SAT.BAT_a");

            var nested_mass_parameter = nested_battery_a.NestedParameter.Single(x => x.Path == @"SAT.BAT_a\m\\option_1");

            Assert.That(nested_mass_parameter.AssociatedParameter, Is.EqualTo(mass_parameteroverride));

            var nested_power_parameter = nested_battery_a.NestedParameter.Single(x => x.Path == @"SAT.BAT_a\p\\option_1");

            Assert.That(nested_power_parameter.AssociatedParameter, Is.EqualTo(power_parameter));
        }
    }
}
