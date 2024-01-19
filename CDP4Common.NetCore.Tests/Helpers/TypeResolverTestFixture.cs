// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeResolverTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.NetCore.Tests.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Reflection;

    using CDP4Common.CommonData;
    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="TypeResolver"/> class.
    /// </summary>
    [TestFixture]
    public class TypeResolverTestFixture
    {
        [Test]
        public void Verify_that_GetDerivedTypes_returns_expected_results()
        {
            var subjectType = typeof(DefinedThing);
            var assembly = Assembly.GetAssembly(subjectType);
            
            var subtypes = TypeResolver.GetDerivedTypes(subjectType, assembly).ToList();

            Assert.That(subtypes.Count, Is.EqualTo(68));
        }

        [Test]
        public void Verify_that_GetAllSuperTypes_returns_expected_result()
        {
            var category = new Category();

            var superTypes = TypeResolver.GetAllSuperTypes(category).ToList();

            var expectedTypes = new List<Type>() {typeof(Category), typeof(DefinedThing), typeof(Thing)};

            Assert.That(superTypes, Is.EqualTo(expectedTypes));
        }

        [Test]
        public void Verify_that_QueryBaseClassesAndInterfaces_returns_expected_result()
        {
            var type = typeof(SiteDirectory);

            var typesandinterfaces = type.QueryBaseClassesAndInterfaces().ToList();

            var expectedTypesAndInterfaces = new List<Type>()
                { typeof(IDisposable), typeof(TopContainer), typeof(Thing), typeof(ITimeStampedThing), typeof(INamedThing), typeof(IShortNamedThing) };

            Assert.That(typesandinterfaces, Is.EquivalentTo(expectedTypesAndInterfaces));
        }
    }
}