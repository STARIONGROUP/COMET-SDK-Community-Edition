// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayParserTestFixture.cs" company="Starion Group S.A.">
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

namespace CDP4Common.Tests.Types
{
    using CDP4Common.Types;

    using NUnit.Framework;

    [TestFixture]
    internal class ValueArrayParserTestFixture
    {
        private string error;
        private ValueArray<int> result;

        [SetUp]
        public void Setup()
        {
            this.error = string.Empty;
            result = null;
        }

        [Test]
        public void VerifyThatStringToValueArrayIntWorks()
        {
            var stringArray = "{1;2;3}";
            Assert.That(stringArray.TryParseToIntValueArray(out result, out error), Is.True);

            Assert.That(this.result[0], Is.EqualTo(1));
            Assert.That(this.result[1], Is.EqualTo(2));
            Assert.That(this.result[2], Is.EqualTo(3));
        }

        [Test]
        public void VerifyThatStringToValueArrayIntWorks2()
        {
            var stringArray = "{1}";
            Assert.That(stringArray.TryParseToIntValueArray(out result, out error), Is.True);

            Assert.That(this.result[0], Is.EqualTo(1));
        }

        [Test]
        public void VerifyThatExceptionThrown1()
        {
            var stringArray = "";
            Assert.That(stringArray.TryParseToIntValueArray(out result, out error), Is.False);
            Assert.That(error, Is.Not.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void VerifyThatExceptionThrown2()
        {
            var stringArray = "1";
            Assert.That(stringArray.TryParseToIntValueArray(out result, out error), Is.False);
            Assert.That(error, Is.Not.Empty);
            Assert.That(result, Is.Null);
        }

        [Test]
        public void VerifyThatExceptionThrown3()
        {
            var stringArray = "{1,2}";
            Assert.That(stringArray.TryParseToIntValueArray(out result, out error), Is.False);
            Assert.That(error, Is.Not.Empty);
            Assert.That(result, Is.Null);
        }
    }
}