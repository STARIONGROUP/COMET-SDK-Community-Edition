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

        [Test]
        public void VerifyThatTheContainerCanBeQueried()
        {
            var category = new Category();
            const string containerName = nameof(Category.Container);

            var containerValue = category.QueryValue(containerName);
            Assert.That(containerValue, Is.Null);

            var rdl = new SiteReferenceDataLibrary()
            {
                Iid = Guid.NewGuid(),
                Name = "RDL"
            };

            rdl.DefinedCategory.Add(category);
            containerValue = category.QueryValue(containerName);
            Assert.That(containerValue, Is.EqualTo(rdl));

            const string nameOfRdlName = containerName + "." + nameof(SiteReferenceDataLibrary.Name);

            var nameOfContainerValue = category.QueryValue(nameOfRdlName);

            Assert.Multiple(() =>
            {
                Assert.That(nameOfContainerValue, Is.EqualTo(rdl.Name));
                Assert.That(() => category.QueryValue($"{containerName}[0..*]"), Throws.ArgumentException);
            });
        }

        [Test]
        public void VerifyThatTheActorCanBeQueried()
        {
            var category = new Category();
            const string actorName = nameof(Category.Actor);

            var actorValue = category.QueryValue(actorName);
            Assert.That(actorValue, Is.Null);

            var actor = new Person()
            {
                ShortName = "person"
            };

            category.Actor = actor;
            actorValue = category.QueryValue(actorName);
            Assert.That(actorValue, Is.EqualTo(actor));

            const string shortNameOfActorName = actorName + "." + nameof(Person.ShortName);

            var nameOfActorValue = category.QueryValue(shortNameOfActorName);

            Assert.Multiple(() =>
            {
                Assert.That(nameOfActorValue, Is.EqualTo(actor.ShortName));
                Assert.That(() => category.QueryValue($"{actorName}[0..*]"), Throws.ArgumentException);
            });
        }

        // Case for collection of Enum
        [Test]
        public void VerifyCategoryPropertyAccessorSetValueForPermissibleClassKind()
        {
            var category = new Category();
            const string permissibleClassName = nameof(Category.PermissibleClass);

            Assert.That(category.PermissibleClass, Is.Empty);

            category.SetValue(permissibleClassName, ClassKind.ActionItem);

            Assert.Multiple(() =>
            {
                Assert.That(category.PermissibleClass, Has.Count.EqualTo(1));
                Assert.That(category.PermissibleClass[0], Is.EqualTo(ClassKind.ActionItem));
            });

            category.SetValue(permissibleClassName, "ElementDefinition");

            Assert.Multiple(() =>
            {
                Assert.That(category.PermissibleClass, Has.Count.EqualTo(1));
                Assert.That(category.PermissibleClass[0], Is.EqualTo(ClassKind.ElementDefinition));
            });

            category.SetValue(permissibleClassName, new List<ClassKind> { ClassKind.Parameter , ClassKind.Alias});
            
            Assert.Multiple(() =>
            {
                Assert.That(category.PermissibleClass, Has.Count.EqualTo(2));
                Assert.That(category.PermissibleClass, Is.EquivalentTo(new List<ClassKind> { ClassKind.Parameter , ClassKind.Alias}));
            });

            category.SetValue(permissibleClassName, new List<string> { "Iteration", "Option"});
            
            Assert.Multiple(() =>
            {
                Assert.That(category.PermissibleClass, Has.Count.EqualTo(2));
                Assert.That(category.PermissibleClass, Is.EquivalentTo(new List<ClassKind> { ClassKind.Iteration , ClassKind.Option}));
            });

            category.SetValue(permissibleClassName, null);

            Assert.Multiple(() =>
            {
                Assert.That(category.PermissibleClass, Is.Empty);
                Assert.That(() => category.SetValue(permissibleClassName, "Iterationn"), Throws.ArgumentException);
                Assert.That(() => category.SetValue(permissibleClassName, new List<string>{"Iterationn", "optionn"}), Throws.ArgumentException);
                Assert.That(() => category.SetValue(permissibleClassName, true), Throws.ArgumentException);
            });
        }
    }
}
