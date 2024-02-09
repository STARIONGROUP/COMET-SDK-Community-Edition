// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueValidatorTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4Common.Tests.Validation
{
    using System;
    using System.Collections.Concurrent;
    using System.Globalization;
    using System.Threading;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Validation;

    using NUnit.Framework;
    
    [TestFixture]
    public class ValueValidatorTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>> cache;

        private BooleanParameterType booleanParameterType;
        private DateParameterType dateParameterType;
        private DateTimeParameterType dateTimeParameterType;
        private EnumerationParameterType enumerationParameterType;
        private SimpleQuantityKind simpleQuantityKind;
        private TextParameterType textParameterType;
        private TimeOfDayParameterType timeOfDayParameterType;
        private RatioScale ratioScale;

        [SetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<CDP4Common.Types.CacheKey, Lazy<Thing>>();

            this.ratioScale = new RatioScale(Guid.NewGuid(), this.cache, this.uri);

            var valuedefLow = new EnumerationValueDefinition(Guid.NewGuid(), this.cache, this.uri);
            valuedefLow.ShortName = "low";
            var valuedefMedium = new EnumerationValueDefinition(Guid.NewGuid(), this.cache, this.uri);
            valuedefMedium.ShortName = "medium";

            this.booleanParameterType = new BooleanParameterType(Guid.NewGuid(), this.cache, this.uri);
            this.dateParameterType = new DateParameterType(Guid.NewGuid(), this.cache, this.uri);
            this.dateTimeParameterType = new DateTimeParameterType(Guid.NewGuid(), this.cache, this.uri);

            this.enumerationParameterType = new EnumerationParameterType(Guid.NewGuid(), this.cache, this.uri);
            this.enumerationParameterType.Name = "test";
            this.enumerationParameterType.ValueDefinition.Add(valuedefLow);
            this.enumerationParameterType.ValueDefinition.Add(valuedefMedium);

            this.simpleQuantityKind = new SimpleQuantityKind(Guid.NewGuid(), this.cache, this.uri);
            this.simpleQuantityKind.PossibleScale.Add(this.ratioScale);
            this.simpleQuantityKind.DefaultScale = this.ratioScale;

            this.textParameterType = new TextParameterType(Guid.NewGuid(), this.cache, this.uri);
            this.timeOfDayParameterType = new TimeOfDayParameterType(Guid.NewGuid(), this.cache, this.uri);
        }
        
        [Test]
        public void VerifyThatBooleanParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.booleanParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, true);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, false);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, 0);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, 1);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, -1);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "True");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "False");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "1");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "0");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "TRUE");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "FALSE");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "Falsch");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("Falsch is not a valid boolean, valid values are: -,true,false,True,False,1,0"));

            result = ValueValidator.Validate(this.booleanParameterType, "-1");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("-1 is not a valid boolean, valid values are: -,true,false,True,False,1,0"));
        }

        [Test]
        public void VerifyThatBooleanValidatesWithFrenchCulture()
        {
            var testCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = testCulture;

            ValidationResult result;

            result = ValueValidator.Validate(this.booleanParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.booleanParameterType, "True");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        [Category("CICDExclusion")]
        public void VerifyThatDateParameterTypeValidatesValue_with_Z()
        {
            ValidationResult result = ValueValidator.Validate(this.dateParameterType, "1976-08-20Z");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("1976-08-20Z is not a valid Date, valid dates are specified in ISO 8601 YYYY-MM-DD"));
        }

        [Test]
        public void VerifyThatDateParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.dateParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.dateParameterType, "1976-08-20");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
            
            result = ValueValidator.Validate(this.dateParameterType, "some text");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("some text is not a valid Date, valid dates are specified in ISO 8601 YYYY-MM-DD"));

            result = ValueValidator.Validate(this.dateParameterType, "2012-13-13");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("2012-13-13 is not a valid Date, valid dates are specified in ISO 8601 YYYY-MM-DD"));

            var date = new DateTime(2002, 12, 1);
            result = ValueValidator.Validate(this.dateParameterType, date);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            var dateTime = new DateTime(2002, 12, 1, 1, 0, 1);
            result = ValueValidator.Validate(this.dateParameterType, dateTime);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void VerifyThatDateTimeParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.dateTimeParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.dateTimeParameterType, "2010-01-02T07:59:00Z");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.dateTimeParameterType, "2009-10-23T16:04:23.332+02");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.dateTimeParameterType, "2012-13-13T12:01:01+02");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));

            var date = new DateTime(2002, 12, 1);
            result = ValueValidator.Validate(this.dateTimeParameterType, date);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatEnumerationParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.enumerationParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.enumerationParameterType, "low");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.enumerationParameterType, "medium");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.enumerationParameterType, "high");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("The test Enumeration Parametertype does not contain the following value definition high, allowed values are: low, medium"));

            this.enumerationParameterType.AllowMultiSelect = true;
            result = ValueValidator.Validate(this.enumerationParameterType, "low | medium");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesDefaultValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesNonDefaultValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "13");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesIntegerNumberSet()
        {
            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.INTEGER_NUMBER_SET;

            string stringValue = "-13";
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, stringValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            int intValue = -13;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            double intdoubleValue = -13d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intdoubleValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            double doubleValue = -13.001d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, doubleValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesNaturalNumberSet()
        {
            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.NATURAL_NUMBER_SET;

            string stringValue = "+13";
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, stringValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            string stringNegativeValue = "-13";
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, stringNegativeValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);

            int intValue = +13;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            int intNegativeValue = -13;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intNegativeValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);

            double intdoubleValue = +13d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intdoubleValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            double intdoubleNegativeValue = -13d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intdoubleNegativeValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);

            double doubleValue = +13.001d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, doubleValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesRealNumberSet()
        {
            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;

            string stringValue = "13.1e1";
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, stringValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            double doubleValue = 13d;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, doubleValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            int intValue = -13;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, intValue);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesRealWithFrenchCulture()
        {
            var testCulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = testCulture;

            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "13.1e1");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindInValidatesRealCommaSeparator()
        {
            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "131,1");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);
        }

        [Test]
        public void VerifyThatWithNumberFormatInfoSimpleQuantityKindValidatesRealCommaSeparator()
        {
            var excelNumberFormatInfo = new NumberFormatInfo
            {
                NumberDecimalSeparator = ",",
                NumberGroupSeparator = ".",
            };

            ValidationResult result;
            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;
            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "131,1", excelNumberFormatInfo);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatSimpleQuantityKindValidatesInvalidValue()
        {
            ValidationResult result;

            this.ratioScale.NumberSet = NumberSetKind.REAL_NUMBER_SET;

            result = ValueValidator.Validate(this.simpleQuantityKind, this.ratioScale, "a");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("String:\"a\" is not a member of the REAL NUMBER SET"));
        }

        [Test]
        public void VerifyThatTextParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.textParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);
        }

        [Test]
        public void VerifyThatTimeOfDayParameterTypeValidatesValue()
        {
            ValidationResult result;

            result = ValueValidator.Validate(this.timeOfDayParameterType, "-");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "10:15:49");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "17:49:30.453Z");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "17:49:30.453+01:00");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "17:49:30.453+01");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));
            Assert.IsEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "17:49:30.453Z+01:00");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);

            result = ValueValidator.Validate(this.timeOfDayParameterType, "25:23");
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.That(result.Message, Is.EqualTo("25:23 is not a valid Time of Day, for valid Time Of Day formats see http://www.w3.org/TR/xmlschema-2/#time."));

            DateTime dateTime;
            var isDateTime = DateTime.TryParse("10:15:49", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind | DateTimeStyles.NoCurrentDateDefault, out dateTime);
            result = ValueValidator.Validate(this.timeOfDayParameterType, dateTime);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Valid));

            result = ValueValidator.Validate(this.timeOfDayParameterType, false);
            Assert.That(result.ResultKind, Is.EqualTo(ValidationResultKind.Invalid));
            Assert.IsNotEmpty(result.Message);
        }
    }
}