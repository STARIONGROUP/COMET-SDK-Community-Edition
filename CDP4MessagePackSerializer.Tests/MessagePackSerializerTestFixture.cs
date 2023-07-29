// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MessagePackSerializerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elabiary
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4MessagePackSerializer.Tests
{
    using System;
    using System.Buffers;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Pipelines;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    using Castle.Components.DictionaryAdapter;

    using CDP4Common.DTO;
    using CDP4Common.Types;

    using CDP4MessagePackSerializer;

    using NUnit.Framework;

    using ActionItem = CDP4Common.DTO.ActionItem;
    using ActualFiniteState = CDP4Common.DTO.ActualFiniteState;
    using ArrayParameterType = CDP4Common.DTO.ArrayParameterType;
    using Category = CDP4Common.DTO.Category;
    using CompoundParameterType = CDP4Common.DTO.CompoundParameterType;
    using Constant = CDP4Common.DTO.Constant;
    using CyclicRatioScale = CDP4Common.DTO.CyclicRatioScale;
    using ElementDefinition = CDP4Common.DTO.ElementDefinition;
    using Parameter = CDP4Common.DTO.Parameter;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// Suite of tests for the <see cref="MessagePackSerializer"/> class
    /// </summary>
    public class MessagePackSerializerTestFixture
    {
        private MessagePackSerializer messagePackSerializer;

        private List<Thing> things;

        [SetUp]
        public void Setup()
        {
            this.messagePackSerializer = new MessagePackSerializer();

            this.things = new List<Thing>();

            this.CreateData();
        }

        private void CreateData()
        {
            var actionItem = new ActionItem(Guid.Parse("830e37e4-80da-4a19-839c-8e92a86ef652"), 1)
            {
                Actionee = Guid.NewGuid(),
                ApprovedBy = new List<Guid>() { Guid.NewGuid() },
                Author = Guid.NewGuid(),
                Category = new List<Guid>() { Guid.NewGuid() },
                Classification = CDP4Common.ReportingData.AnnotationClassificationKind.MAJOR,
                CloseOutDate = new DateTime(1976, 08, 20),
                CloseOutStatement = "this is a closeOutStatement",
                Content = "this is the content",
                CreatedOn = new DateTime(1976, 08, 20),
                Discussion = new List<Guid>() { Guid.NewGuid() },
                DueDate = new DateTime(1976, 08, 20),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                LanguageCode = "en-GB",
                ModifiedOn = new DateTime(1976, 08, 20),
                Owner = Guid.NewGuid(),
                PrimaryAnnotatedThing = Guid.NewGuid(),
                RelatedThing = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ShortName = "AI-01",
                SourceAnnotation = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Status = CDP4Common.ReportingData.AnnotationStatusKind.CLOSED,
                Title = "action item title",
                ThingPreference = "{ \"key\": \"value\" }",
            };

            var actualFiniteState = new ActualFiniteState(Guid.Parse("b6288dc1-7dc2-48a5-be7c-230bca37bdb5"), 1)
            {
                Kind = CDP4Common.EngineeringModelData.ActualFiniteStateKind.FORBIDDEN,
                PossibleState = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }",
            };

            var actualFiniteStateList = new ActualFiniteStateList(Guid.Parse("80492750-b1e0-4db0-a80e-ef00cd148074"), 1)
            {
                ActualState = new EditableList<Guid>() { Guid.NewGuid() },
                ExcludeOption = new EditableList<Guid>() { Guid.NewGuid() },
                Owner = Guid.NewGuid(),
                PossibleFiniteStateList = new List<OrderedItem>()
                { 
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("62290849-4f48-4679-abfc-2f7b4d80f4f0")
                    }
                },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }",
            };

            var andExpression = new AndExpression(Guid.Parse("e9f82620-279c-4b10-9607-91bd8b78127c"), 1)
            {
                Term = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }",
            };

            var arrayParameterType = new ArrayParameterType(Guid.Parse("f7c2fa1e-39b4-4917-ba8f-235add46f41a"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Component = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("73c2851f-b00d-4f2f-937b-313102dcd867")
                    },
                    new OrderedItem()
                    {
                        K = 2,
                        V = Guid.Parse("3e088bac-6ccb-43a8-9efb-af657db7895e")
                    }
                },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Dimension = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = 99
                    }
                },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                IsFinalized = true,
                IsTensor = true,
                Name = "array Parameter Type",
                ShortName = "arrayParameterType",
                Symbol = "s",
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var category = new Category(Guid.Parse("233555ad-6700-4a7b-b9c8-9ffc50df7bfc"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsAbstract = true,
                IsDeprecated = true,
                Name = "category",
                PermissibleClass = new List<CDP4Common.CommonData.ClassKind>() { CDP4Common.CommonData.ClassKind.ActionItem, CDP4Common.CommonData.ClassKind.ElementDefinition },
                ShortName = "cat",
                SuperCategory = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var citation = new Citation(Guid.Parse("968b2bc5-6ebf-4de9-88e5-c8d940aa8acd"), 1)
            {
                IsAdaptation = true,
                Location = "a location",
                Remark = "a remark",
                ShortName = "loc",
                Source = Guid.NewGuid(),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var commonFileStore = new CommonFileStore(Guid.Parse("8376dd93-7dcb-489a-9c4f-a0f577c00b3f"), 1)
            {
                CreatedOn = new DateTime(1976, 08, 20),
                File = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Folder = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Name = "commonFileStore",
                Owner = Guid.NewGuid(),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var compoundParameterType = new CompoundParameterType(Guid.Parse("ec692830-f9a0-40e0-ba7d-bc00ad1c4e16"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Component = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("6e346cc9-f296-4403-afe9-1b10367a2656")
                    },
                    new OrderedItem()
                    {
                        K = 2,
                        V = Guid.Parse("d2ec9df3-cdc3-4ee6-a13d-928ffcd0dc66")
                    }
                },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                IsFinalized = true,
                Name = "compound ParameterType",
                ShortName = "compoundParameterType",
                Symbol = "ts",
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var constant = new Constant(Guid.Parse("c204564a-583f-4373-965b-335d63479232"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                Name = "Constant",
                ParameterType = Guid.NewGuid(),
                Scale = null,
                ShortName = "const",
                Value = new ValueArray<string>( new List<string> { "value1", "value2" }),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var cyclicRatioScale = new CyclicRatioScale(Guid.Parse("9edca989-548a-4949-965d-5c5af4f02216"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                IsMaximumInclusive = true,
                IsMinimumInclusive = true,
                MappingToReferenceScale = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                MaximumPermissibleValue = "MaximumPermissibleValue",
                MinimumPermissibleValue = "MinimumPermissibleValue",
                Modulus = "Modulus",
                Name = "cyclic RatioScale",
                NegativeValueConnotation = "NegativeValueConnotation",
                NumberSet = CDP4Common.SiteDirectoryData.NumberSetKind.INTEGER_NUMBER_SET,
                PositiveValueConnotation = "PositiveValueConnotation",
                ShortName = "cyclicRatioScale",
                Unit = Guid.NewGuid(),
                ValueDefinition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };
            
            var elementDefinition = new ElementDefinition(Guid.Parse("71475d28-3452-4284-8617-b582e58ec9b6"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ContainedElement = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Name = "Satellite",
                Owner = Guid.NewGuid(),
                Parameter = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ParameterGroup = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ReferencedElement = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ShortName = "SAT",
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                OrganizationalParticipant = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var engineeringModel = new EngineeringModel(Guid.Parse("adf93b62-1875-4596-9c65-d2abf517db53"), 1)
            {
                CommonFileStore = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                EngineeringModelSetup = Guid.NewGuid(),
                Iteration = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                LastModifiedOn = new DateTime(1976, 08, 20),
                LogEntry = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Book = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 2,
                        V = Guid.Parse("cc64732f-383c-4d2b-aca9-ab5d8dd8ad67")
                    },
                    new OrderedItem()
                    {
                        K = 5,
                        V = Guid.Parse("b510eb1a-33a3-4779-8e85-60e08c7e4d40")
                    }
                },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                GenericNote = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModellingAnnotation = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var engineeringModelSetup = new EngineeringModelSetup(Guid.Parse("48d94106-11a4-4f31-baf3-92d9292676e9"), 1)
            {
                ActiveDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                EngineeringModelIid = Guid.NewGuid(),
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IterationSetup = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Kind = CDP4Common.SiteDirectoryData.EngineeringModelKind.SCRATCH_MODEL,
                Name = "test model",
                Participant = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                RequiredRdl = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ShortName = "TM",
                SourceEngineeringModelSetupIid = null,
                StudyPhase = CDP4Common.SiteDirectoryData.StudyPhaseKind.PREPARATION_PHASE,
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                DefaultOrganizationalParticipant = Guid.NewGuid(),
                OrganizationalParticipant = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ThingPreference = null
            };

            var enumerationParameterType = new EnumerationParameterType(Guid.Parse("bcc9d4cd-29a8-4260-83c5-2fc0f84a2176"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                AllowMultiSelect = true,
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                Name = "enumerationParameterType",
                ShortName = "enumpt",
                Symbol = "s",
                ValueDefinition = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("efcbfa3c-4f91-4abc-bbf4-5b83cb6b15b7")
                    }
                },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = null
            };

            var exclusiveOrExpression = new ExclusiveOrExpression(Guid.Parse("d1302b2c-be4b-41b6-ab82-41bd30fa9357"), 1)
            {
                Term = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = null
            };

            var iteration = new Iteration(Guid.Parse("d58c34f2-7559-4269-add5-2343686482f2"), 1)
            {
                ActualFiniteStateList = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                DefaultOption = null,
                DomainFileStore = new List<Guid>(),
                Element = new List<Guid>(),
                ExternalIdentifierMap = new List<Guid>() { Guid.NewGuid() },
                IterationSetup = Guid.NewGuid(),
                Option = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("2b4fa102-2d4a-4ce5-92b4-3996177129b7")
                    }
                },
                PossibleFiniteStateList = new List<Guid>() { Guid.NewGuid() },
                Publication = new List<Guid>() { Guid.NewGuid() },
                Relationship = new List<Guid>() { Guid.NewGuid() },
                RequirementsSpecification = new List<Guid>() { Guid.NewGuid() },
                RuleVerificationList = new List<Guid>() { Guid.NewGuid() },
                SourceIterationIid = null,
                TopElement = Guid.NewGuid(),
                DiagramCanvas = new List<Guid>() { Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Goal = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                SharedDiagramStyle = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Stakeholder = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                StakeholderValueMap = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ValueGroup = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ThingPreference = null
            };

            var iterationSetup = new IterationSetup(Guid.Parse("05c2dee8-afce-4139-a8be-b6d5758258a9"), 1)
            {
                CreatedOn = new DateTime(1976, 08, 20),
                Description = "iteration 1",
                FrozenOn = null,
                IterationIid = Guid.NewGuid(),
                IterationNumber = 1,
                SourceIterationSetup = null,
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = null
            };

            var parameter = new Parameter(Guid.Parse("4bcf1fae-c6df-4a20-b54f-39d5693cff95"), 1)
            {
                AllowDifferentOwnerOfOverride = true,
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Owner = Guid.NewGuid(),
                ModifiedOn = new DateTime(1976, 08, 20),
                ExpectsOverride = true,
                IsOptionDependent = false,
                Group = null,
                ParameterSubscription = new List<Guid>() { Guid.NewGuid()},
                ParameterType = Guid.NewGuid(),
                RequestedBy = null,
                Scale = Guid.NewGuid(),
                StateDependence = null,
                ThingPreference = "{ \"key\": \"value\" }",
                ValueSet  = new List<Guid>() { Guid.NewGuid()}
            };

            var parameterOverride = new ParameterOverride(Guid.Parse("86c014b4-9026-40ff-9973-037938457fc1"), 1)
            {
                Owner = Guid.NewGuid(),
                Parameter = Guid.NewGuid(),
                ParameterSubscription = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ValueSet = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var parameterSubscription = new ParameterSubscription(Guid.Parse("37f45ff5-4e56-48e4-b45b-c0bd4d9d3b57"), 1)
            {
                Owner = Guid.NewGuid(),
                ValueSet = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var parameterSubscriptionValueSet = new ParameterSubscriptionValueSet(Guid.Parse("494e10fd-159a-4f69-a88d-9c9c6c7687e0"), 1)
            {
                Manual = new ValueArray<string>(new List<string> { "value1", "value2" }),
                SubscribedValueSet = Guid.NewGuid(),
                ValueSwitch = CDP4Common.EngineeringModelData.ParameterSwitchKind.REFERENCE,
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var parameterValueSet = new ParameterValueSet(Guid.Parse("15cd5ed8-35ec-4180-b92e-4c3bf704d948"), 1)
            {
                ActualOption = null,
                ActualState = Guid.NewGuid(),
                Computed = new ValueArray<string>(new List<string> { "value1", "value2" }),
                Formula = new ValueArray<string>(new List<string> { "value1", "value2" }),
                Manual = new ValueArray<string>(new List<string> { "value1", "value2" }),
                Published = new ValueArray<string>(new List<string> { "value1", "value2" }),
                Reference = new ValueArray<string>(new List<string> { "value1", "value2" }),
                ValueSwitch = CDP4Common.EngineeringModelData.ParameterSwitchKind.COMPUTED,
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var person = new Person(Guid.Parse("c87c028d-0d00-4361-ae74-9e9205df3c96"), 1)
            {
                DefaultDomain = null,
                DefaultEmailAddress = Guid.NewGuid(),
                DefaultTelephoneNumber = Guid.NewGuid(),
                EmailAddress = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                GivenName = "John",
                IsActive = true,
                IsDeprecated = true,
                Organization = Guid.NewGuid(),
                OrganizationalUnit = "MNSE",
                Password = "1234567890",
                Role = Guid.NewGuid(),
                ShortName = "jdoe",
                Surname = "Doe",
                TelephoneNumber = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                UserPreference = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var prefixedUnit = new PrefixedUnit(Guid.Parse("3e1230ef-8b1c-4b0c-aef0-53dd8074fdf9"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                Prefix = Guid.NewGuid(),
                ReferenceUnit = Guid.NewGuid(),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var referenceSource = new ReferenceSource(Guid.Parse("996a33fb-c1fa-4e64-91a4-62a1f4005047"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Author = "John Doe",
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                Language = "en-GB",
                Name = "resource",
                PublicationYear = 1976,
                PublishedIn = Guid.NewGuid(),
                Publisher = Guid.NewGuid(),
                ShortName = "res",
                VersionDate = new DateTime(1976, 08, 20),
                VersionIdentifier = "123-XX",
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var sampledFunctionParameterType = new SampledFunctionParameterType(Guid.Parse("1e201fa5-6100-4596-bdbd-31840d05942a"), 1)
            {
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Category = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                DegreeOfInterpolation = null,
                DependentParameterType = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("59134117-3b79-494e-94b1-11ed9249f22f")
                    }
                },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IndependentParameterType = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("a0a64d3b-937b-492d-9df1-0644ef3ebf3a")
                    }
                },
                InterpolationPeriod = new ValueArray<string>(new List<string> { "value1", "value2" }),
                IsDeprecated = true,
                Name = "sampled Function ParameterType",
                ShortName = "sampledFunctionParameterType",
                Symbol = "sss",
                ThingPreference = "{ \"key\": \"value\" }",
            };

            var siteDirectory = new SiteDirectory(Guid.Parse("0ac672c9-b776-4bb0-bf46-0aa496173a78"), 1)
            {
                CreatedOn = new DateTime(1976, 08, 20),
                DefaultParticipantRole = null,
                DefaultPersonRole = null,
                Domain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                DomainGroup = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                LastModifiedOn = new DateTime(1976, 08, 20),
                LogEntry = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Model = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Name = "RHEA",
                NaturalLanguage = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Organization = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ParticipantRole = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Person = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                PersonRole = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ShortName = "RHEA",
                SiteReferenceDataLibrary = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Annotation = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var siteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.Parse("011f4c05-ee5a-47aa-869a-61014b9d2ca4"), 1)
            {
                Alias = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                BaseQuantityKind = new List<OrderedItem>()
                {
                    new OrderedItem()
                    {
                        K = 1,
                        V = Guid.Parse("1a6b5440-0a92-4daf-9765-5c38ff1ee9ac")
                    }
                },
                BaseUnit = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Constant = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                DefinedCategory = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Definition = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                FileType = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Glossary = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                HyperLink = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                IsDeprecated = true,
                Name = "siteReferenceDataLibrary",
                ParameterType = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ReferenceSource = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                RequiredRdl = null,
                Rule = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Scale = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ShortName = "rdl",
                Unit = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                UnitPrefix = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var telephoneNumber = new TelephoneNumber(Guid.Parse("3a02ca6d-4540-47cb-afb2-b36dc81c121b"), 1)
            {
                Value = "new number",
                VcardType = new List<CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind>()
                {
                    CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind.HOME,
                    CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind.FAX
                },
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ModifiedOn = new DateTime(1976, 08, 20),
                ThingPreference = "{ \"key\": \"value\" }"
            };

            var textualNote = new TextualNote(Guid.Parse("aa5988ad-6f34-477a-8afe-aae27b17624f"),1)
            {
                Category =  new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                Content = "this is some content",
                CreatedOn = new DateTime(1976, 08, 20),
                ExcludedDomain = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                ExcludedPerson = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid() },
                LanguageCode = "en-GB",
                ModifiedOn = new DateTime(1976, 08, 20),
                Name = "textual note",
                Owner = Guid.NewGuid(),
                ShortName = "textualnote",
                ThingPreference = "{ \"key\": \"value\" }"
            };

            this.things.Add(actionItem);
            this.things.Add(actualFiniteState);
            this.things.Add(actualFiniteStateList);
            this.things.Add(andExpression);
            this.things.Add(arrayParameterType);
            this.things.Add(category);
            this.things.Add(citation);
            this.things.Add(commonFileStore);
            this.things.Add(compoundParameterType);
            this.things.Add(constant);
            this.things.Add(cyclicRatioScale);
            this.things.Add(elementDefinition);
            this.things.Add(engineeringModel);
            this.things.Add(engineeringModelSetup);
            this.things.Add(enumerationParameterType);
            this.things.Add(exclusiveOrExpression);
            this.things.Add(iteration);
            this.things.Add(iterationSetup);
            this.things.Add(parameter);
            this.things.Add(parameterOverride);
            this.things.Add(parameterSubscription);
            this.things.Add(parameterSubscriptionValueSet);
            this.things.Add(parameterValueSet);
            this.things.Add(person);
            this.things.Add(prefixedUnit);
            this.things.Add(referenceSource);
            this.things.Add(sampledFunctionParameterType);
            this.things.Add(siteDirectory);
            this.things.Add(siteReferenceDataLibrary);
            this.things.Add(telephoneNumber);
            this.things.Add(textualNote);
        }

        [Test]
        public async Task Verify_that_things_can_be_serialized_and_deserialized_async_using_stream()
        {
            var cts = new CancellationTokenSource();

            var stream = new MemoryStream();

            await this.messagePackSerializer.SerializeToStreamAsync(this.things, stream, cts.Token);

            stream.Position = 0;

            var deserializedThings = await this.messagePackSerializer.DeserializeAsync(stream, cts.Token);

            Assert.That(deserializedThings.Count(), Is.EqualTo(this.things.Count));

            this.ThingAssertions(deserializedThings);
        }

        [Test]
        public void Verify_that_things_can_be_serialized_and_deserialized_using_stream()
        {
            var stream = new MemoryStream();

            this.messagePackSerializer.SerializeToStream(this.things, stream);

            stream.Position = 0;

            var deserializedThings = this.messagePackSerializer.Deserialize(stream);

            Assert.That(deserializedThings.Count(), Is.EqualTo(this.things.Count));

            this.ThingAssertions(deserializedThings);
        }

        [Test]
        public async Task Verify_that_things_can_be_serialized_and_deserialized_using_Pipe()
        {
            var cts = new CancellationTokenSource();

            var pipe = new Pipe();
            
            this.messagePackSerializer.SerializeToBufferWriter(this.things, pipe.Writer , cts.Token);
            await pipe.Writer.FlushAsync(cts.Token);
            await pipe.Writer.CompleteAsync();

            var deserializedThings = await this.messagePackSerializer.DeserializeAsync(pipe.Reader.AsStream(), cts.Token);
            await pipe.Reader.CompleteAsync();

            Assert.That(deserializedThings.Count() , Is.EqualTo(this.things.Count));

            this.ThingAssertions(deserializedThings);
        }

        private void ThingAssertions(IEnumerable<Thing> deserializedThings)
        {
            var actionItem = deserializedThings.OfType<ActionItem>().Single(x => x.Iid == Guid.Parse("830e37e4-80da-4a19-839c-8e92a86ef652"));
            Assert.That(actionItem.Classification, Is.EqualTo(CDP4Common.ReportingData.AnnotationClassificationKind.MAJOR));
            Assert.That(actionItem.CloseOutDate, Is.EqualTo(new DateTime(1976, 8, 20)));
            Assert.That(actionItem.Status, Is.EqualTo(CDP4Common.ReportingData.AnnotationStatusKind.CLOSED));

            var actualFiniteState = deserializedThings.OfType<ActualFiniteState>().Single(x => x.Iid == Guid.Parse("b6288dc1-7dc2-48a5-be7c-230bca37bdb5"));
            Assert.That(actualFiniteState.Kind, Is.EqualTo(CDP4Common.EngineeringModelData.ActualFiniteStateKind.FORBIDDEN));

            var actualFiniteStateList = deserializedThings.OfType<ActualFiniteStateList>().Single(x => x.Iid == Guid.Parse("80492750-b1e0-4db0-a80e-ef00cd148074"));
            var possibleFiniteState = actualFiniteStateList.PossibleFiniteStateList.Single(x => x.K == 1);
            Assert.That(possibleFiniteState.V, Is.EqualTo(Guid.Parse("62290849-4f48-4679-abfc-2f7b4d80f4f0")));
            
            var andExpression = deserializedThings.OfType<AndExpression>().Single(x => x.Iid == Guid.Parse("e9f82620-279c-4b10-9607-91bd8b78127c"));
            Assert.That(andExpression.ModifiedOn, Is.EqualTo(new DateTime(1976, 8, 20)));

            var arrayParameterType = deserializedThings.OfType<ArrayParameterType>().Single(x => x.Iid == Guid.Parse("f7c2fa1e-39b4-4917-ba8f-235add46f41a"));
            Assert.That(arrayParameterType.Component.Count, Is.EqualTo(2));
            var component = arrayParameterType.Component.Single(x => x.K == 2);
            Assert.That(component.V, Is.EqualTo(Guid.Parse("3e088bac-6ccb-43a8-9efb-af657db7895e")));
            var dimension = arrayParameterType.Dimension.First();
            Assert.That(dimension.K, Is.EqualTo(1));
            Assert.That(dimension.V, Is.EqualTo(99));

            var category = deserializedThings.OfType<Category>().Single(x => x.Iid == Guid.Parse("233555ad-6700-4a7b-b9c8-9ffc50df7bfc"));
            Assert.That(category.IsAbstract, Is.True);
            Assert.That(category.IsDeprecated, Is.True);
            Assert.That(category.PermissibleClass, Is.EquivalentTo(new List<CDP4Common.CommonData.ClassKind>() { CDP4Common.CommonData.ClassKind.ActionItem, CDP4Common.CommonData.ClassKind.ElementDefinition }));

            var citation = deserializedThings.OfType<Citation>().Single(x => x.Iid == Guid.Parse("968b2bc5-6ebf-4de9-88e5-c8d940aa8acd"));
            Assert.That(citation.IsAdaptation, Is.True);
            Assert.That(citation.Location, Is.EqualTo("a location"));
            Assert.That(citation.Remark, Is.EqualTo("a remark"));
            Assert.That(citation.ShortName, Is.EqualTo("loc"));

            var commonFileStore = deserializedThings.OfType<CommonFileStore>().Single(x => x.Iid == Guid.Parse("8376dd93-7dcb-489a-9c4f-a0f577c00b3f"));
            Assert.That(commonFileStore.RevisionNumber, Is.EqualTo(1));

            var compnentcompoundParameterTypeParameterType = deserializedThings.OfType<CompoundParameterType>().Single(x => x.Iid == Guid.Parse("ec692830-f9a0-40e0-ba7d-bc00ad1c4e16"));

            var constant = deserializedThings.OfType<Constant>().Single(x => x.Iid == Guid.Parse("c204564a-583f-4373-965b-335d63479232"));
            Assert.That(constant.Scale, Is.Null);
            Assert.That(constant.Value[0], Is.EqualTo("value1"));
            Assert.That(constant.Value[1], Is.EqualTo("value2"));

            var cyclicRatioScale = deserializedThings.OfType<CyclicRatioScale>().Single(x => x.Iid == Guid.Parse("9edca989-548a-4949-965d-5c5af4f02216"));

            var elementDefinition = deserializedThings.OfType<ElementDefinition>().Single(x => x.Iid == Guid.Parse("71475d28-3452-4284-8617-b582e58ec9b6"));
            Assert.That(elementDefinition, Is.Not.Null);
            Assert.That(elementDefinition.Name, Is.EqualTo("Satellite"));
            Assert.That(elementDefinition.ShortName, Is.EqualTo("SAT"));

            var engineeringModel = deserializedThings.OfType<EngineeringModel>().Single(x => x.Iid == Guid.Parse("adf93b62-1875-4596-9c65-d2abf517db53"));

            var engineeringModelSetup = deserializedThings.OfType<EngineeringModelSetup>().Single(x => x.Iid == Guid.Parse("48d94106-11a4-4f31-baf3-92d9292676e9"));

            var enumerationParameterType = deserializedThings.OfType<EnumerationParameterType>().Single(x => x.Iid == Guid.Parse("bcc9d4cd-29a8-4260-83c5-2fc0f84a2176"));

            var iteration = deserializedThings.OfType<Iteration>().Single(x => x.Iid == Guid.Parse("d58c34f2-7559-4269-add5-2343686482f2"));

            var iterationSetup = deserializedThings.OfType<IterationSetup>().Single(x => x.Iid == Guid.Parse("05c2dee8-afce-4139-a8be-b6d5758258a9"));

            var parameter = deserializedThings.OfType<Parameter>().Single(x => x.Iid == Guid.Parse("4bcf1fae-c6df-4a20-b54f-39d5693cff95"));

            var parameterOverride = deserializedThings.OfType<ParameterOverride>().Single(x => x.Iid == Guid.Parse("86c014b4-9026-40ff-9973-037938457fc1"));

            var parameterSubscription = deserializedThings.OfType<ParameterSubscription>().Single(x => x.Iid == Guid.Parse("37f45ff5-4e56-48e4-b45b-c0bd4d9d3b57"));

            var parameterSubscriptionValueSet = deserializedThings.OfType<ParameterSubscriptionValueSet>().Single(x => x.Iid == Guid.Parse("494e10fd-159a-4f69-a88d-9c9c6c7687e0"));

            var parameterValueSet = deserializedThings.OfType<ParameterValueSet>().Single(x => x.Iid == Guid.Parse("15cd5ed8-35ec-4180-b92e-4c3bf704d948"));

            var persom = deserializedThings.OfType<Person>().Single(x => x.Iid == Guid.Parse("c87c028d-0d00-4361-ae74-9e9205df3c96"));

            var prefixedUnit = deserializedThings.OfType<PrefixedUnit>().Single(x => x.Iid == Guid.Parse("3e1230ef-8b1c-4b0c-aef0-53dd8074fdf9"));

            var referenceSource = deserializedThings.OfType<ReferenceSource>().Single(x => x.Iid == Guid.Parse("996a33fb-c1fa-4e64-91a4-62a1f4005047"));

            var sampledFunctionParameterType = deserializedThings.OfType<SampledFunctionParameterType>().Single(x => x.Iid == Guid.Parse("1e201fa5-6100-4596-bdbd-31840d05942a"));

            var siteDirectory = deserializedThings.OfType<SiteDirectory>().Single(x => x.Iid == Guid.Parse("0ac672c9-b776-4bb0-bf46-0aa496173a78"));

            var siteReferenceDataLibrary = deserializedThings.OfType<SiteReferenceDataLibrary>().Single(x => x.Iid == Guid.Parse("011f4c05-ee5a-47aa-869a-61014b9d2ca4"));

            var telephoneNumber = deserializedThings.OfType<TelephoneNumber>().Single(x => x.Iid == Guid.Parse("3a02ca6d-4540-47cb-afb2-b36dc81c121b"));
            Assert.That(telephoneNumber.VcardType, Is.EquivalentTo(
                new List<CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind>()
                {
                    CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind.HOME,
                    CDP4Common.SiteDirectoryData.VcardTelephoneNumberKind.FAX
                }));

            var textualNote = deserializedThings.OfType<TextualNote>().Single(x => x.Iid == Guid.Parse("aa5988ad-6f34-477a-8afe-aae27b17624f"));
        }
    }
}
