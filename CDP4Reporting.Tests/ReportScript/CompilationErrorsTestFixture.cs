// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompilationErrorsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: OpenAI Assistant
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

namespace CDP4Reporting.Tests.ReportScript
{
    using System.Collections.Generic;

    using CDP4Reporting.ReportScript;

    using NUnit.Framework;

    [TestFixture]
    public class CompilationErrorsTestFixture
    {
        [Test]
        public void VerifyThatEmptyErrorsAreHandled()
        {
            var errors = new CompilationErrors(new List<string>());

            Assert.That(errors.HasErrors, Is.False);
            Assert.That(errors.ToString(), Is.Empty);
        }

        [Test]
        public void VerifyThatErrorsAreReturned()
        {
            var errors = new CompilationErrors(new List<string> { "first", "second" });

            Assert.That(errors.HasErrors, Is.True);
            Assert.That(errors.ToString(), Is.EqualTo("first\nsecond"));
        }
    }
}
