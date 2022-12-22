// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingConverterExtensionsTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer_SystemTextJson.Tests.JsonConverter
{
    using System;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer_SystemTextJson.JsonConverter;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ThingConverterExtensions"/> class
    /// </summary>
    public class ThingConverterExtensionsTestFixture
    {
        private ThingConverterExtensions thingConverterExtensions;

        private IMetaDataProvider metaDataProvider;

        [SetUp]
        public void SetUp()
        {
            this.thingConverterExtensions = new ThingConverterExtensions();
            this.metaDataProvider = new MetaDataProvider();
        }

        [Test]
        public void Verify_that_PersonPermission_is_excluded_when_classkind_version_higher_than_requested_model_version()
        {
            var personPermission = new PersonPermission(Guid.NewGuid(), 1);
            personPermission.ObjectClass = ClassKind.SampledFunctionParameterType;

            Assert.That(this.thingConverterExtensions.AssertSerialization(personPermission,
                    this.metaDataProvider, new Version(1, 0, 0)),
                Is.False);
        }

        [Test]
        public void Verify_that_PersonPermission_is_included_when_classkind_version_eaual_or_lower_than_requested_model_version()
        {
            var personPermission = new PersonPermission(Guid.NewGuid(), 1);
            personPermission.ObjectClass = ClassKind.SampledFunctionParameterType;

            Assert.That(this.thingConverterExtensions.AssertSerialization(personPermission,
                    this.metaDataProvider, new Version(1, 2, 0)),
                Is.True);
        }

        [Test]
        public void Verify_that_ParticipantPermission_is_excluded_when_classkind_version_higher_than_requested_model_version()
        {
            var participantPermission = new ParticipantPermission(Guid.NewGuid(), 1);
            participantPermission.ObjectClass = ClassKind.ActionItem;

            Assert.That(this.thingConverterExtensions.AssertSerialization(participantPermission,
                    this.metaDataProvider, new Version(1, 0, 0)),
                Is.False);
        }

        [Test]
        public void Verify_that_ParticipantPermission_is_included_when_classkind_version_eaual_or_lower_than_requested_model_version()
        {
            var participantPermission = new ParticipantPermission(Guid.NewGuid(), 1);
            participantPermission.ObjectClass = ClassKind.ActionItem;

            Assert.That(this.thingConverterExtensions.AssertSerialization(participantPermission,
                    this.metaDataProvider, new Version(1, 1, 0)),
                Is.True);
        }
    }
}
