// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultPermissionProviderTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
        }

        [Test]
        public void Verify_that_For_unknown_type_exception_is_thrown_on_GetDefaultPersonPermission()
        {
            Assert.Throws<ArgumentException>(() => this.defaultPermissionProvider.GetDefaultPersonPermission("unknown-type"));
        }

        [Test]
        public void Verify_that_For_all_classkinds_a_default_PersonPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultPersonPermission(classKind));
            }
        }

        [Test]
        public void Verify_that_For_all_classkindsAsString_a_default_ParticipantPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultParticipantPermission(classKind.ToString()));
            }
        }

        [Test]
        public void Verify_that_For_unknown_type_exception_is_thrown_on_GetDefaultParticipantPermission()
        {
            Assert.Throws<ArgumentException>(() => this.defaultPermissionProvider.GetDefaultParticipantPermission("unknown-type"));
        }

        [Test]
        public void Verify_that_For_all_classkinds_a_default_ParticipantPermission_is_returned()
        {
            var classKinds = Enum.GetValues(typeof(ClassKind)).Cast<ClassKind>();

            foreach (var classKind in classKinds)
            {
                Assert.DoesNotThrow(() => this.defaultPermissionProvider.GetDefaultParticipantPermission(classKind));
            }
        }
    }
}