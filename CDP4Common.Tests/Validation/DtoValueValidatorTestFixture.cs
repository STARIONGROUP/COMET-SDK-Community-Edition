// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoValueValidatorTestFixture.cs" company="RHEA System S.A.">
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    using CDP4Common.DTO;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Common.Validation;

    using NUnit.Framework;

    using BooleanParameterType = CDP4Common.DTO.BooleanParameterType;
    using CompoundParameterType = CDP4Common.DTO.CompoundParameterType;
    using DateParameterType = CDP4Common.DTO.DateParameterType;
    using DateTimeParameterType = CDP4Common.DTO.DateTimeParameterType;
    using DependentParameterTypeAssignment = CDP4Common.DTO.DependentParameterTypeAssignment;
    using EnumerationParameterType = CDP4Common.DTO.EnumerationParameterType;
    using EnumerationValueDefinition = CDP4Common.DTO.EnumerationValueDefinition;
    using IndependentParameterTypeAssignment = CDP4Common.DTO.IndependentParameterTypeAssignment;
    using ParameterTypeComponent = CDP4Common.DTO.ParameterTypeComponent;
    using RatioScale = CDP4Common.DTO.RatioScale;
    using SampledFunctionParameterType = CDP4Common.DTO.SampledFunctionParameterType;
    using SimpleQuantityKind = CDP4Common.DTO.SimpleQuantityKind;
    using TextParameterType = CDP4Common.DTO.TextParameterType;
    using TimeOfDayParameterType = CDP4Common.DTO.TimeOfDayParameterType;

    [TestFixture]
    public class DtoValueValidatorTestFixture
    {
        private BooleanParameterType booleanParameterType;
        private DateParameterType dateParameterType;
        private DateTimeParameterType dateTimeParameterType;
        private EnumerationParameterType enumerationParameterType;
        private RatioScale ratioScale;
        private SimpleQuantityKind simpleQuantityKind;
        private TextParameterType textParameterType;
        private TimeOfDayParameterType timeOfDayParameterType;
        private List<EnumerationValueDefinition> valueDefinitions;
        private ParameterValueSetBase valueSet;

        [SetUp]
        public void Setup()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            this.booleanParameterType = new BooleanParameterType(Guid.NewGuid(), 1);
            this.dateParameterType = new DateParameterType(Guid.NewGuid(), 1);
            this.dateTimeParameterType = new DateTimeParameterType(Guid.NewGuid(), 1);
            this.enumerationParameterType = new EnumerationParameterType(Guid.NewGuid(), 1);
            this.simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), 1);
            this.textParameterType = new TextParameterType(Guid.NewGuid(), 1);
            this.timeOfDayParameterType = new TimeOfDayParameterType(Guid.NewGuid(), 1);

            this.ratioScale = new RatioScale(Guid.NewGuid(), 1)
            {
                NumberSet = NumberSetKind.NATURAL_NUMBER_SET
            };

            this.valueDefinitions = new List<EnumerationValueDefinition>()
            {
                new EnumerationValueDefinition(Guid.NewGuid(), 1)
                {
                    Name = "LOW",
                    ShortName = "low"
                },

                new EnumerationValueDefinition(Guid.NewGuid(), 1)
                {
                    Name = "MEDIUM",
                    ShortName = "medium"
                }
            };

            this.enumerationParameterType.ValueDefinition.Add(new OrderedItem { V = this.valueDefinitions[0].Iid });
            this.enumerationParameterType.ValueDefinition.Add(new OrderedItem { V = this.valueDefinitions[1].Iid });

            this.valueSet = new ParameterValueSet(Guid.NewGuid(), 1)
            {
                Reference = new ValueArray<string>(new List<string>(){ObjectValueValidator.DefaultValue}),
                Computed = new ValueArray<string>(new List<string>(){ObjectValueValidator.DefaultValue}),
                Manual = new ValueArray<string>(new List<string>(){ObjectValueValidator.DefaultValue})
            };
        }

        [Test]
        public void VerifyBooleanParameterTypeValidationAndCleanup()
        {
            var result = this.booleanParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Computed[0] = "false";
            this.valueSet.Reference[0] = "0";
            this.valueSet.Manual[0] = "1";

            result = this.booleanParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("false"));
                Assert.That(this.valueSet.Reference[0], Is.EqualTo("false"));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("true"));
            });

            this.valueSet.Computed[0] = "fAlSe";
            this.valueSet.Reference[0] = "FALSE";
            this.valueSet.Manual[0] = "tRUe";

            result = this.booleanParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("false"));
                Assert.That(this.valueSet.Reference[0], Is.EqualTo("false"));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("true"));
            });

            this.valueSet.Manual[0] = "-1";

            result = this.booleanParameterType.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.booleanParameterType.Validate(true, out var cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("true"));
            });

            result = this.booleanParameterType.Validate(false, out cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("false"));
            });

            result = this.booleanParameterType.Validate(1, out cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("true"));
            });

            result = this.booleanParameterType.Validate(0, out cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("false"));
            });

            result = this.booleanParameterType.Validate("FAlSce", out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.booleanParameterType.Validate("truCe", out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.booleanParameterType.Validate(42, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }

        [Test]
        public void VerifyDateParameterTypeValidationAndCleanup()
        {
            var result = this.dateParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "2024-02-26";

            result = this.dateParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("2024-02-26"));
            });

            this.valueSet.Manual[0] = "2024-02-26Z";
            result = this.dateParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("2024-02-26"));
            });

            result = this.dateParameterType.Validate("2024-13-13", out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateParameterType.Validate("2024-12-32", out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateParameterType.Validate(new DateTime(2024, 12, 13, 0, 0, 0, DateTimeKind.Utc), out var cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("2024-12-13"));
            });

            result = this.dateParameterType.Validate(new DateTime(2024, 12, 13, 0, 0, 1, DateTimeKind.Utc), out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateParameterType.Validate(false, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateParameterType.Validate(42, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }

        [Test]
        public void VerifyDateTimeParameterTypeValidationAndCleanup()
        {
            var result = this.dateTimeParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "2024-02-26";

            result = this.dateTimeParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("2024-02-26T00:00:00.0000000Z"));
            });

            this.valueSet.Manual[0] = "2024-02-26Z";
            result = this.dateTimeParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("2024-02-26T00:00:00.0000000Z"));
            });

            result = this.dateTimeParameterType.Validate(new DateTime(2024, 12, 13, 0, 0, 0, DateTimeKind.Utc), out var cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("2024-12-13T00:00:00.0000000Z"));
            });

            result = this.dateTimeParameterType.Validate(new DateTime(2024, 12, 13, 0, 0, 1, DateTimeKind.Utc), out cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("2024-12-13T00:00:01.0000000Z"));
            });

            result = this.dateTimeParameterType.Validate(false, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateTimeParameterType.Validate(42, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.dateTimeParameterType.Validate("2009-10-23T16:04:23.332+02", out cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("2009-10-23T14:04:23.3320000Z"));
            });
        }

        [Test]
        public void VerifyEnumerationParameterTypeValidationAndCleanup()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => this.enumerationParameterType.Validate("-", measurementScaleId: null, out _), Throws.Nothing);
                Assert.That(() => this.enumerationParameterType.Validate("a", null, out _), Throws.ArgumentNullException);
            });

            var things = new List<Thing>();

            Assert.That(() => this.enumerationParameterType.Validate("a", null, out _, things), Throws.Exception.TypeOf<ThingNotFoundException>());

            things.AddRange(this.valueDefinitions);

            var result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "low";
            this.valueSet.Computed[0] = "medium";

            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("low"));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("medium"));
            });

            this.valueSet.Manual[0] = "LOW";

            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            this.valueSet.Manual[0] = "low|medium";
            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
                Assert.That(result.Message, Is.EqualTo("The provided 'low|medium' contains multiple values, which is not allowed for a single selection"));
            });

            this.enumerationParameterType.AllowMultiSelect = true;
            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("low|medium"));
            });

            this.valueSet.Manual[0] = "low|medium|low";
            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
                Assert.That(result.Message, Is.EqualTo("The provided 'low|medium|low' contains duplicate"));
            });

            result = this.enumerationParameterType.Validate(42, things, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            
            this.valueSet.Manual[0] = "low | medium";
            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("low|medium"));
            });

            this.valueSet.Manual[0] = "low  |  medium";
            result = this.enumerationParameterType.ValidateAndCleanup(this.valueSet, null, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("low|medium"));
            });
        }

        [Test]
        public void VerifyTextParameterTypeValidationAndCleanup()
        {
            var result = this.textParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "any string";
            this.valueSet.Computed[0] = "123456789";
            this.valueSet.Reference[0] = "true|false=>false";

            result = this.textParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("any string"));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("123456789"));
                Assert.That(this.valueSet.Reference[0], Is.EqualTo("true|false=>false"));
            });

            this.valueSet.Manual[0] = "";
            result = this.textParameterType.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.textParameterType.Validate(42, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }


        [Test]
        public void VerifyTimeOfDayParameterTypeValidationAndCleanup()
        {
            var result = this.timeOfDayParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "14:00:12";
            this.valueSet.Computed[0] = "0001-01-01T14:00:12.0000000Z";
            this.valueSet.Reference[0] = "17:49:30.453Z";

            result = this.timeOfDayParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("14:00:12"));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("14:00:12"));
                Assert.That(this.valueSet.Reference[0], Is.EqualTo("17:49:30"));
            });

            this.valueSet.Computed[0] = "0001-01-01T14:00:12.0000000";
            result = this.timeOfDayParameterType.ValidateAndCleanup(this.valueSet, null);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Computed[0], Is.EqualTo("14:00:12"));
            });

            this.valueSet.Manual[0] = "0001-01-02T14:00:12.0000000";
            result = this.timeOfDayParameterType.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.timeOfDayParameterType.Validate(new DateTime(1, 1, 1, 12, 45, 35, DateTimeKind.Utc), out var cleanedValue);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("12:45:35"));
            });

            result = this.timeOfDayParameterType.Validate(new DateTime(2001, 1, 1, 12, 45, 35, DateTimeKind.Utc), out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = this.timeOfDayParameterType.Validate(false, out _);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }

        [Test]
        public void VerifyQuantityKindWithNaturalValidationAndCleanup()
        {
            Assert.That(() => this.simpleQuantityKind.Validate("1", null, out _), Throws.ArgumentNullException);

            var result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "1";
            var things = new List<Thing>();

            Assert.Multiple(() =>
            {
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid), Throws.ArgumentNullException);
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things), Throws.Exception.TypeOf<ThingNotFoundException>());
            });

            things.Add(this.ratioScale);

            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("1"));
            });

            this.valueSet.Manual[0] = "-1";

            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.Message, Is.EqualTo("The provided '-1' is not a member of the NATURAL NUMBER SET"));
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            });

            result = this.simpleQuantityKind.Validate(1, this.ratioScale.Iid, out var cleanedValue, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.00, this.ratioScale.Iid, out cleanedValue, things);
            
            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.001, this.ratioScale.Iid, out _, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.Message, Is.EqualTo("The provided '1.001' is not a member of the NATURAL NUMBER SET"));
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            });
        }

        [Test]
        public void VerifyQuantityKindWithIntegerValidationAndCleanup()
        {
            this.ratioScale.NumberSet = NumberSetKind.INTEGER_NUMBER_SET;

            var result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "1";
            var things = new List<Thing>();

            Assert.Multiple(() =>
            {
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid), Throws.ArgumentNullException);
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things), Throws.Exception.TypeOf<ThingNotFoundException>());
            });

            things.Add(this.ratioScale);

            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("1"));
            });

            this.valueSet.Manual[0] = "-1";

            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            result = this.simpleQuantityKind.Validate(1, this.ratioScale.Iid, out var cleanedValue, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.00, this.ratioScale.Iid, out cleanedValue, things);
            
            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.001, this.ratioScale.Iid, out _, things); 

            Assert.Multiple(() =>
            {
                Assert.That(result.Message, Is.EqualTo("The provided '1.001' is not a member of the INTEGER NUMBER SET"));
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            });
        }

        [Test]
        public void VerifyQuantityKindWithRealValidationAndCleanup()
        {
            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;

            var result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, null);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            this.valueSet.Manual[0] = "1";
            var things = new List<Thing>();

            Assert.Multiple(() =>
            {
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid), Throws.ArgumentNullException);
                Assert.That(() => this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things), Throws.Exception.TypeOf<ThingNotFoundException>());
            });

            things.Add(this.ratioScale);
            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet, this.ratioScale.Iid, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual[0], Is.EqualTo("1"));
            });

            this.valueSet.Manual[0] = "-1";

            result = this.simpleQuantityKind.ValidateAndCleanup(this.valueSet,  this.ratioScale.Iid, things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            result = this.simpleQuantityKind.Validate(1,  this.ratioScale.Iid, out var cleanedValue, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.00, this.ratioScale.Iid, out cleanedValue, things);
            
            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1"));
            });

            result = this.simpleQuantityKind.Validate(1.001, this.ratioScale.Iid, out cleanedValue, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(cleanedValue, Is.EqualTo("1.001"));
            });
            
            result = this.simpleQuantityKind.Validate(false, this.ratioScale.Iid, out _, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
                Assert.That(result.Message, Is.EqualTo("The provided 'False' is not a member of the REAL NUMBER SET"));
            });
        }

        [Test]
        public void VerifyQuantityKindWithRationalValidationAndCleanup()
        {
            this.ratioScale.NumberSet = NumberSetKind.RATIONAL_NUMBER_SET;

            var things = new List<Thing>()
            {
                this.ratioScale
            };

            var result = this.simpleQuantityKind.Validate(false,  this.ratioScale.Iid, out _, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(result.Message, Is.EqualTo("RATIONAL NUMBER SET are not validated"));
            });
        }

        [Test]
        public void VerifyQuantityKindWithInvalidNumberSetKindValidationAndCleanup()
        {
            this.ratioScale.NumberSet = (NumberSetKind)42;

            var things = new List<Thing>()
            {
                this.ratioScale
            };

            Assert.That(() => this.simpleQuantityKind.Validate(false, this.ratioScale.Iid, out _, things), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void VerifySampledFunctionParameterTypeValidationAndCleanup()
        {
            var sampledFunctionParameterType = new SampledFunctionParameterType(Guid.NewGuid(), 1);

            var independentParameterAssignment = new IndependentParameterTypeAssignment(Guid.NewGuid(), 1)
            {
                ParameterType = this.booleanParameterType.Iid
            };

            var dependentParameterAssignment = new DependentParameterTypeAssignment(Guid.NewGuid(), 1)
            {
                ParameterType = this.simpleQuantityKind.Iid,
                MeasurementScale = this.ratioScale.Iid
            };

            sampledFunctionParameterType.IndependentParameterType.Add(new OrderedItem(){V = independentParameterAssignment.Iid});
            sampledFunctionParameterType.DependentParameterType.Add(new OrderedItem(){V = dependentParameterAssignment.Iid});

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.Validate(this.valueSet, null, out _).Message, Is.EqualTo("Unsupported ParameterType SampledFunctionParameterType"));
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, null), Throws.ArgumentNullException);
            });

            var things = new List<Thing>();

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the IndependentParameterTypeAssignment"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the IndependentParameterTypeAssignment"));
            });
            
            things.Add(independentParameterAssignment);

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));
            });

            things.Add(this.booleanParameterType);

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the DependentParameterTypeAssignment"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the DependentParameterTypeAssignment"));
            });
            
            things.Add(dependentParameterAssignment);

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));
            });

            things.Add(this.simpleQuantityKind);

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<InvalidDataException>()
                    .With.Message.Contain("The ValueArray MANUAL ({\"-\"}) does not have the required amount of values !"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<InvalidDataException>()
                    .With.Message.Contain("The ValueArray Manual ({\"-\"}) does not have the required amount of values !"));
            });

            this.valueSet.Manual = new ValueArray<string>(new List<string>(){"-","-"});
            this.valueSet.Computed = new ValueArray<string>(new List<string>(){"-","-","-","-"});
            this.valueSet.Reference = new ValueArray<string>(new List<string>(){"-","-", "-","-", "-","-"});

            var result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
                Assert.That(this.valueSet.Computed, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-","-","-"})));
                Assert.That(this.valueSet.Reference, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-","-","-","-","-"})));
            });

            result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
            });

            this.valueSet.Manual[0] = "1";
            this.valueSet.Manual[1] = "2";

            Assert.Multiple(() =>
            {
                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the MeasurementScale"));

                Assert.That(() => sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the MeasurementScale"));
            });

            things.Add(this.ratioScale);

            result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"true","2"})));
            });

            this.valueSet.Manual[0] = "1";
            this.valueSet.Manual[1] = "2";
            result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"true","2"})));
            });

            this.valueSet.Manual[1] = "-1";
            result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet, things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = sampledFunctionParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }

        [Test]
        public void VerifyCompoundParameterTypeValidationAndCleanup()
        {
            var compoundParameterType = new CompoundParameterType(Guid.NewGuid(), 1);

            var boolParameterTypeComponent = new ParameterTypeComponent(Guid.NewGuid(), 1)
            {
                ParameterType = this.booleanParameterType.Iid
            };

            var textParameterTypeComponent = new ParameterTypeComponent(Guid.NewGuid(), 1)
            {
                ParameterType = this.textParameterType.Iid
            };

            compoundParameterType.Component.Add(new OrderedItem(){V = boolParameterTypeComponent.Iid});
            compoundParameterType.Component.Add(new OrderedItem(){V = textParameterTypeComponent.Iid});

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.Validate(this.valueSet, null, out _).Message, Is.EqualTo("Unsupported ParameterType CompoundParameterType"));
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, null), Throws.ArgumentNullException);
            });

            var things = new List<Thing>();

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the ParameterTypeComponent"));

                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the ParameterTypeComponent"));
            });
            
            things.Add(boolParameterTypeComponent);

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));

                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet.Manual,"Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));
            });

            things.Add(this.booleanParameterType);

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the ParameterTypeComponent"));

                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of referenced Things does not contain the ParameterTypeComponent"));
            });
            
            things.Add(textParameterTypeComponent);

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));

                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<ThingNotFoundException>()
                    .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));
            });

            things.Add(this.textParameterType);

            Assert.Multiple(() =>
            {
                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet, things), Throws.Exception.TypeOf<InvalidDataException>()
                    .With.Message.Contain("The ValueArray MANUAL ({\"-\"}) does not have the required amount of values ! Expected: 2 Received: 1"));

                Assert.That(() => compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things), Throws.Exception.TypeOf<InvalidDataException>()
                    .With.Message.Contain("The ValueArray Manual ({\"-\"}) does not have the required amount of values ! Expected: 2 Received: 1"));
            });

            this.valueSet.Manual = new ValueArray<string>(new List<string>(){"-","-"});
            this.valueSet.Computed = new ValueArray<string>(new List<string>(){"-","-"});
            this.valueSet.Reference = new ValueArray<string>(new List<string>(){"-","-"});

            var result = compoundParameterType.ValidateAndCleanup(this.valueSet, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
                Assert.That(this.valueSet.Computed, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
                Assert.That(this.valueSet.Reference, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
            });

            result = compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"-","-"})));
            });

            this.valueSet.Manual[0] = "1";
            this.valueSet.Manual[1] = "2";

            result = compoundParameterType.ValidateAndCleanup(this.valueSet, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"true","2"})));
            });

            this.valueSet.Manual[0] = "1";
            this.valueSet.Manual[1] = "2";

            result = compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That(this.valueSet.Manual, Is.EquivalentTo(new ValueArray<string>(new List<string>(){"true","2"})));
            });

            this.valueSet.Manual[1] = " ";

            result = compoundParameterType.ValidateAndCleanup(this.valueSet, things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            result = compoundParameterType.ValidateAndCleanup(this.valueSet.Manual, "Manual", things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }

        [Test]
        public void VerifyParameterValidation()
        {
            var parameter = new Parameter(Guid.NewGuid(), 1)
            {
                ParameterType = this.booleanParameterType.Iid
            };

            var classlessDto = new ClasslessDTO()
            {
                {"Manual", this.valueSet.Manual},
                {"Computed", this.valueSet.Computed},
                {"Reference", this.valueSet.Reference},
            };

            var things = new List<Thing>();

            Assert.That(() => parameter.ValidateAndCleanup(classlessDto,things), Throws.Exception.TypeOf<ThingNotFoundException>()
                .With.Message.Contain("The provided collection of Things does not contain a reference to the ParameterType"));

            things.Add(this.booleanParameterType);

            var result = parameter.ValidateAndCleanup(classlessDto, things);

            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            ((ValueArray<string>)classlessDto["Manual"])[0] = "FALSE";

            result =  parameter.ValidateAndCleanup(classlessDto, things);

            Assert.Multiple(() =>
            {
                Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
                Assert.That( ((ValueArray<string>)classlessDto["Manual"])[0], Is.EqualTo("false"));
            });

            ((ValueArray<string>)classlessDto["Manual"])[0] = "2";

            result = parameter.ValidateAndCleanup(classlessDto, things);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
        }
    }
}
