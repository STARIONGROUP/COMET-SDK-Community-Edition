#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValueArrayParserTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
#endregion

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
            Assert.IsTrue(stringArray.TryParseToIntValueArray(out result, out error));

            Assert.AreEqual(1, this.result[0]);
            Assert.AreEqual(2, this.result[1]);
            Assert.AreEqual(3, this.result[2]);
        }

        [Test]
        public void VerifyThatStringToValueArrayIntWorks2()
        {
            var stringArray = "{1}";
            Assert.IsTrue(stringArray.TryParseToIntValueArray(out result, out error));

            Assert.AreEqual(1, this.result[0]);
        }

        [Test]
        public void VerifyThatExceptionThrown1()
        {
            var stringArray = "";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }

        [Test]
        public void VerifyThatExceptionThrown2()
        {
            var stringArray = "1";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }

        [Test]
        public void VerifyThatExceptionThrown3()
        {
            var stringArray = "{1,2}";
            Assert.IsFalse(stringArray.TryParseToIntValueArray(out result, out error));
            Assert.IsNotEmpty(error);
            Assert.IsNull(result);
        }
    }
}