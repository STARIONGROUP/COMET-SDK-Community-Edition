// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JsonSerializerPostOperationTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4JsonSerializer_SystemTextJson.Tests.PostOperation
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;
    using CDP4JsonSerializer_SystemTextJson.Tests.Cdp4PostOperation;
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

            var CDP4JsonSerializer_New = new CDP4JsonSerializer(this.metaDataProvider, this.supportedVersion);
            
            var cdpPostOperation = CDP4JsonSerializer_New.Deserialize<CdpPostOperation>(stream);

            Assert.IsEmpty(cdpPostOperation.Create);
            Assert.IsEmpty(cdpPostOperation.Delete);
            Assert.IsEmpty(cdpPostOperation.Copy);

            var classlessDto = cdpPostOperation.Update.First();

            var orderedItems = classlessDto["QuantityKindFactor"] as IEnumerable<OrderedItem>;

            var orderedItem_1 = orderedItems.First();
            //orderedItem_1.M = 77606679;

            var orderedItem_2 = orderedItems.Last();
            //orderedItem_2.M = -12551680;
        }

        [Test]
        public void Verify_that_post_message_can_be_deserialized()
        {
            var postMessage = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "PostOperation/CreateDerivedQuantityKindPostMessage.json"));
            var byteArray = Encoding.UTF8.GetBytes(postMessage);
            var stream = new MemoryStream(byteArray);

            var CDP4JsonSerializer_New = new CDP4JsonSerializer(this.metaDataProvider, this.supportedVersion);

            var cdpPostOperation = CDP4JsonSerializer_New.Deserialize<CdpPostOperation>(stream);
            
            Assert.IsEmpty(cdpPostOperation.Delete);
            Assert.IsEmpty(cdpPostOperation.Copy);

            var derivedQuantityKind = cdpPostOperation.Create.First() as DerivedQuantityKind;
            var qkf_1 = derivedQuantityKind.QuantityKindFactor.Single(x => x.K == -12551680);

            Assert.IsNotNull(qkf_1.V);
            Assert.IsNull(qkf_1.M);
        }
    }
}