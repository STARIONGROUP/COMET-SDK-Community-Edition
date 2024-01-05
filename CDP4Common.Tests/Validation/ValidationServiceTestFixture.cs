// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationServiceTestFixture.cs" company="RHEA System S.A.">
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
    using CDP4Common.Validation;

    using NUnit.Framework;

    [TestFixture]
    public class ValidationServiceTestFixture
    {
        [Test]
        public void VerifyValidateProperty()
        {
            var validEmails = new []
            {
                "simple@example.com",
                "very.common@example.com",
                "x@example.com",
                "long.email-address-with-hyphens@and.subdomains.example.com",
                "user.name+tag+sorting@example.com",
                "name/surname@example.com",
                "admin@example",
                "mailhost!username@example.org",
                "user%example.com@example.org",
                "user-@example.org",
            };

            var invalidEmails = new[]
            {
                "abc.example.com",
                "a@b@c@example.com",
                "a\"b(c)d,e:f;g<h>i[j\\k]l@example.com",
                "just\"not\"right@example.com",
                "this is\"not\\allowed@example.com",
                "this\\ still\\\"not\\\\allowed@example.com",
                "1234567890123456789012345678901234567890123456789012345678901234+x@example.com",
                "i.like.underscores@but_they_are_not_allowed_in_this_part"
            };

            var validationService = new ValidationService();

            Assert.Multiple(() =>
            {
                Assert.That(validationService.ValidateProperty("SelectedSource", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("SelectedSource", "valid source"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ShortName", "invalid ShortName"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ShortName", "validShortName"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RDLShortName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RDLShortName", "validRDL"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RDLName", " invalidRDLName"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RDLName", "validRDLName"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("NativeName", "1nativeName1"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("NativeName", "nativeName"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("FileRevisionName", " invalid FileRevisionName"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("FileRevisionName", "FileRevisionName"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Name", "invalidName)"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Name", "validName"), Is.Null.Or.Empty);

                foreach (var validEmail in validEmails)
                {
                    Assert.That(validationService.ValidateProperty("EmailAddress", validEmail), Is.Null.Or.Empty);
                }

                foreach (var invalid in invalidEmails)
                {
                    Assert.That(validationService.ValidateProperty("EmailAddress", invalid), Is.Not.Null.Or.Empty);
                }

                Assert.That(validationService.ValidateProperty("TelephoneNumber", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("TelephoneNumber", "000 000 000"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("UserPreference", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("UserPreference", "userPref"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("LanguageCode", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("LanguageCode", "language code"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Content", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Content", "content"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Password", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Password", "password"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ForwardRelationshipName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ForwardRelationshipName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("InverseRelationshipName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("InverseRelationshipName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Exponent", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Exponent", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Symbol", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Symbol", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ScaleValueDefinition", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ScaleValueDefinition", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ScaleReferenceQuantityValue", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ScaleReferenceQuantityValue", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Factor", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Factor", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Modulus", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Modulus", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Extension", "invalidExtension"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Extension", "valid1"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("FileTypeName", "invented"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("FileTypeName", "audio/1"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Value", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Value", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ModelSetupShortName", "invalid!"), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ModelSetupShortName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonShortName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonShortName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonGivenName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonGivenName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonSurname", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("PersonSurname", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RequirementShortName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("RequirementShortName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ModelSetupName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ModelSetupName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ConversionFactor", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("ConversionFactor", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Description", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Description", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Title", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("Title", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("EnumerationValueDefinitionShortName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("EnumerationValueDefinitionShortName", "valid"), Is.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("EnumerationValueDefinitionName", ""), Is.Not.Null.Or.Empty);
                Assert.That(validationService.ValidateProperty("EnumerationValueDefinitionName", "valid"), Is.Null.Or.Empty);
            });
        }
    }
}
