// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializerPostOperationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4JsonSerializer.NetCore.Tests.PostOperation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;

    using CDP4DalCommon.Protocol.Operations;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests to verify that PostOperation deserialization works as expected
    /// </summary>
    [TestFixture]
    public class JsonSerializerPostOperationTestFixture
    {
        private IMetaDataProvider metaDataProvider;

        private Version supportedVersion;

        [SetUp]
        public void SetUp()
        {
            this.metaDataProvider = new MetaDataProvider();
            this.supportedVersion = new Version(1,1,0);
        }

        [Test]
        public void Verify_that_post_message_with_move_keys_can_be_deserialized()
        {
            var postMessage = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "PostOperation/ReOderFactorsOfDerivedQuantityKindPostMessage.json"));
            var byteArray = Encoding.UTF8.GetBytes(postMessage);
            var stream = new MemoryStream(byteArray);

            var cdp4JsonSerializer = new Cdp4DalJsonSerializer(this.metaDataProvider, this.supportedVersion, false);
            
            var cdpPostOperation = cdp4JsonSerializer.Deserialize<PostOperation>(stream);

            Assert.That(cdpPostOperation.Create, Is.Empty);
            Assert.That(cdpPostOperation.Delete, Is.Empty);
            Assert.That(cdpPostOperation.Copy, Is.Empty);

            var classlessDto = cdpPostOperation.Update.First();

            var orderedItems = classlessDto["QuantityKindFactor"] as IEnumerable<OrderedItem>;

            var orderedItem_1 = orderedItems.First();
            orderedItem_1.M = 77606679;

            var orderedItem_2 = orderedItems.Last();
            orderedItem_2.M = -12551680;
        }

        [Test]
        public void Verify_that_post_message_can_be_deserialized()
        {
            var postMessage = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "PostOperation/CreateDerivedQuantityKindPostMessage.json"));
            var byteArray = Encoding.UTF8.GetBytes(postMessage);
            var stream = new MemoryStream(byteArray);

            var cdp4JsonSerializer = new Cdp4DalJsonSerializer(this.metaDataProvider, this.supportedVersion, false);

            var cdpPostOperation = cdp4JsonSerializer.Deserialize<PostOperation>(stream);
            
            Assert.That(cdpPostOperation.Delete, Is.Empty);
            Assert.That(cdpPostOperation.Copy, Is.Empty);

            var derivedQuantityKind = cdpPostOperation.Create.First() as DerivedQuantityKind;
            var qkf_1 = derivedQuantityKind.QuantityKindFactor.Single(x => x.K == -12551680);

            Assert.That(qkf_1.V, Is.Not.Null);

            Assert.That(qkf_1.M, Is.Null);
        }
    }
}