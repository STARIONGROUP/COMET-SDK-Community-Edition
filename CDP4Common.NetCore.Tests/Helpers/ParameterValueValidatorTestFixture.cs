// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueValidatorTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.Helpers
{
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Tests for <see cref="ParameterValueValidator"/>.
    /// </summary>
    [TestFixture]
    public class ParameterValueValidatorTestFixture
    {
        [Test]
        public void VerifyThatNullParameterTypeReturnsError()
        {
            var error = ParameterValueValidator.Validate("value", null);

            Assert.That(error, Is.EqualTo("Error: The parameter type is null."));
        }

        [Test]
        public void VerifyThatValidBooleanValueReturnsNull()
        {
            var parameterType = new BooleanParameterType();

            var error = ParameterValueValidator.Validate(true, parameterType);

            Assert.That(error, Is.Null);
        }

        [Test]
        public void VerifyThatInvalidBooleanValueReturnsValidationMessage()
        {
            var parameterType = new BooleanParameterType();

            var error = ParameterValueValidator.Validate("not-a-boolean", parameterType);

            Assert.That(error, Does.Contain("not-a-boolean"));
        }
    }
}
