// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultPermissionProviderTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4Common.Tests.AutoGenHelpers
{
    using System;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DefaultPermissionProvider"/>
    /// </summary>
    [TestFixture]
    public class DefaultPermissionProviderTestFixture
    {
        private DefaultPermissionProvider defaultPermissionProvider;

        [SetUp]
        public void SetUp()
        {
            this.defaultPermissionProvider = new DefaultPermissionProvider();
        }

        [Test]
        public void Verify_that_For_all_classkindsAsString_a_default_PersonPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultPersonPermission(classKind.ToString()));
            }

            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.Person.ToString()), Is.EqualTo(PersonAccessRightKind.NONE));
            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.NotThing.ToString()), Is.EqualTo(PersonAccessRightKind.NOT_APPLICABLE));

            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.ElementDefinition.ToString()), Is.EqualTo(PersonAccessRightKind.NOT_APPLICABLE));
        }
        
        [Test]
        public void Verify_that_For_unknown_type_exception_is_thrown_on_GetDefaultPersonPermission()
        {
            Assert.That(() => this.defaultPermissionProvider.GetDefaultPersonPermission("unknown-type"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_For_all_classkinds_a_default_PersonPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultPersonPermission(classKind));
            }

            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.Person), Is.EqualTo(PersonAccessRightKind.NONE));

            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.NotThing), Is.EqualTo(PersonAccessRightKind.NOT_APPLICABLE));
            Assert.That(this.defaultPermissionProvider.GetDefaultPersonPermission(ClassKind.ElementDefinition), Is.EqualTo(PersonAccessRightKind.NOT_APPLICABLE));
        }

        [Test]
        public void Verify_that_For_all_classkindsAsString_a_default_ParticipantPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultParticipantPermission(classKind.ToString()));
            }

            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.ElementDefinition.ToString()), Is.EqualTo(ParticipantAccessRightKind.NONE));
            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.Person.ToString()), Is.EqualTo(ParticipantAccessRightKind.NOT_APPLICABLE));
            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.NotThing.ToString()), Is.EqualTo(ParticipantAccessRightKind.NOT_APPLICABLE));
        }

        [Test]
        public void Verify_that_For_unknown_type_exception_is_thrown_on_GetDefaultParticipantPermission()
        {
            Assert.That(() => this.defaultPermissionProvider.GetDefaultParticipantPermission("unknown-type"), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void Verify_that_For_all_classkinds_a_default_ParticipantPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultParticipantPermission(classKind));
            }

            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.ElementDefinition), Is.EqualTo(ParticipantAccessRightKind.NONE));
            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.Person), Is.EqualTo(ParticipantAccessRightKind.NOT_APPLICABLE));
            Assert.That(this.defaultPermissionProvider.GetDefaultParticipantPermission(ClassKind.NotThing), Is.EqualTo(ParticipantAccessRightKind.NOT_APPLICABLE));
        }
    }
}