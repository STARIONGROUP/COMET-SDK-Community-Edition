// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UtilsTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.Helpers;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Utils"/>
    /// </summary>
    [TestFixture]
    public class UtilsTestFixture
    {
        [Test]
        public void verify_that_ToIdList_extracts_guid_values()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            var orderedItems = new List<OrderedItem>
            {
                new OrderedItem { V = guid1 },
                new OrderedItem { V = guid2 }
            };

            var ids = orderedItems.ToIdList().ToList();

            Assert.That(ids, Is.EqualTo(new[] { guid1, guid2 }));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public void verify_that_FormatComponentShortName_returns_empty_string_for_null_or_whitespace(string input)
        {
            var result = Utils.FormatComponentShortName(input);

            Assert.That(result, Is.EqualTo(string.Empty));
        }
    }
}
