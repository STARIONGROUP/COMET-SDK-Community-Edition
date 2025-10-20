// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4DalJsonSerializerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: OpenAI Assistant
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.PostOperation
{
    using System;
    using System.Linq;
    using System.Text.Json;

    using CDP4Common.Dto;
    using CDP4Common.MetaInfo;

    using CDP4DalCommon.Protocol.Operations;

    using CDP4JsonSerializer.JsonConverter;

    using NUnit.Framework;

    [TestFixture]
    public class Cdp4DalJsonSerializerTestFixture
    {
        [Test]
        public void VerifyThatCopySectionIsOmittedWhenConfigured()
        {
            var serializer = new Cdp4DalJsonSerializer(new MetaDataProvider(), new Version(1, 0, 0), true);
            var postOperation = new PostOperation();
            postOperation.Copy.Add(new CopyInfo { ActiveOwner = Guid.NewGuid() });

            var json = JsonSerializer.Serialize(postOperation, serializer.JsonSerializerOptions);

            Assert.That(json.Contains("\"_copy\""), Is.False);
        }

        [Test]
        public void VerifyThatCopySectionIsIncludedByDefault()
        {
            var serializer = new Cdp4DalJsonSerializer(new MetaDataProvider(), new Version(1, 0, 0), false);
            var postOperation = new PostOperation();
            postOperation.Copy.Add(new CopyInfo { ActiveOwner = Guid.NewGuid() });

            var json = JsonSerializer.Serialize(postOperation, serializer.JsonSerializerOptions);

            Assert.That(json.Contains("\"_copy\""), Is.True);
        }
    }
}
