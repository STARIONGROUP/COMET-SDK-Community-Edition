// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConstantPropertyAccessorTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elabiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.PropertyAccessor
{
    using System;
    using System.Collections.Generic;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="Constant.QueryValue"/> method
    /// </summary>
    [TestFixture]
    public class ConstantPropertyAccessorTestFixture
    {
        [Test]
        public void Verify_that_the_value_of_a_Constant_can_be_queried()
        {
            var constant = new Constant(Guid.Parse("5e09b1cf-59fe-4b78-9c6d-4d2852448811"), null, null);

            var values = (List<string>)constant.QueryValue("Value[0..*]");
            Assert.That(values, Is.Empty);

            constant.Value = new ValueArray<string>(new List<string> { "-" });

            values = (List<string>)constant.QueryValue("Value[0..*]");
            Assert.That(values, Is.EquivalentTo(constant.Value));

            constant.Value = new ValueArray<string>(new List<string> { "-", "abc", "123" });

            values = (List<string>)constant.QueryValue("Value[0..*]");
            Assert.That(values, Is.EquivalentTo(constant.Value));

            var value = (string)constant.QueryValue("Value[1..1]");
            Assert.That(value, Is.EqualTo("abc"));
        }

        [Test]
        public void Verify_that_the_value_of_an_empyt_list_of_Constant_can_be_queried()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var constants = (List<Constant>) siteReferenceDataLibrary.QueryValue("constant[0..*]");
            Assert.That(constants, Is.Empty);

            var values = (List<string>)siteReferenceDataLibrary.QueryValue("constant[0..*].value[0..*]");
            Assert.That(values, Is.Empty);
        }

        [Test]
        public void Verify_that_the_category_permissibleclass_of_an_empyt_list_of_Constant_can_be_queried()
        {
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);

            var constants = (List<Constant>)siteReferenceDataLibrary.QueryValue("constant[0..*]");
            Assert.That(constants, Is.Empty);

            var values = (List<string>)siteReferenceDataLibrary.QueryValue("constant[0..*].value[0..*]");
            Assert.That(values, Is.Empty);

            var categories = (List<Category>)siteReferenceDataLibrary.QueryValue("constant[0..*].category[0..*]");
            Assert.That(categories, Is.Empty);

            var classkinds = (List<ClassKind>)siteReferenceDataLibrary.QueryValue("constant[0..*].category[0..*].permissibleClass[0..*]");
            Assert.That(classkinds, Is.Empty);
        }
    }
}
