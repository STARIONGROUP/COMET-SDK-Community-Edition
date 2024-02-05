// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryPropertyAccssor.cs" company="RHEA System S.A.">
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
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tets for the <see cref="Category.QueryValue"/> method
    /// </summary>
    [TestFixture]
    public class CategoryPropertyAccssorTestFixture
    {
        [Test]
        public void Verify_that_the_PermissebleClass_can_be_queried()
        {
            var category = new Category(Guid.Parse("22e9dde4-d647-49af-b580-4461d4eef37e"), null, null);

            Assert.That(() => category.QueryValue("permissibleClass"), 
                Throws.Exception.TypeOf<ArgumentException>()
                    .With.Message.EqualTo("Invalid Multiplicity for the PermissibleClass property, the lower and upper bound must be specified"));

            var permissibleClasses = (List<ClassKind>)category.QueryValue("permissibleClass[0..*]");
            Assert.That(permissibleClasses, Is.Empty);

            category.PermissibleClass.Add(ClassKind.ActualFiniteState);

            permissibleClasses = (List<ClassKind>)category.QueryValue("permissibleClass[0..*]");
            Assert.That(permissibleClasses.Single(), Is.EqualTo(ClassKind.ActualFiniteState));

            var permissibleClass = (ClassKind)category.QueryValue("permissibleClass[0..0]");
            Assert.That(permissibleClass, Is.EqualTo(ClassKind.ActualFiniteState));

            category.PermissibleClass.Add(ClassKind.Definition);

            permissibleClasses = (List<ClassKind>)category.QueryValue("permissibleClass[0..*]");
            Assert.That(permissibleClasses, Is.EquivalentTo(new List<ClassKind> { ClassKind.ActualFiniteState, ClassKind.Definition }));
        }
    }
}
