#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDP4JsonSerializer_NewTestFixture.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4JsonSerializer_New.Tests
{
    using System;
    using System.IO;
    using CDP4Common.CommonData;
    using CDP4Common.MetaInfo;
    using CDP4JsonSerializer_New.Tests.Helper;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="CDP4JsonSerializer_New"/> class
    /// </summary>
    [TestFixture]
    public class CDP4JsonSerializer_NewTestFixture
    {
        [Test]
        public void Verify_serializestream_throws_exception_when_metadata_and_version_not_set()
        {
            var definition = new Definition();

            using (var stream = new MemoryStream())
            {
                var CDP4JsonSerializer_New = new CDP4JsonSerializer();

                Assert.Throws<InvalidOperationException>(() => CDP4JsonSerializer_New.SerializeToStream(definition, stream));

                Assert.Throws<InvalidOperationException>(() => CDP4JsonSerializer_New.SerializeToStream(definition, stream, false));
            }
        }

        [Test]
        public void Verify_that_serializestream_null_parameters_throws_exception()
        {
            var metadataprovider = new MetaDataProvider();

            var CDP4JsonSerializer_New = new CDP4JsonSerializer();
            CDP4JsonSerializer_New.Initialize(metadataprovider, new Version(1,0,0));
            
            Assert.Throws<ArgumentNullException>(() => CDP4JsonSerializer_New.SerializeToStream(null, null));
        }

        [Test]
        public void Verify_that_thing_serializestream_null_parameters_throws_exception()
        {
            var metadataprovider = new MetaDataProvider();

            var CDP4JsonSerializer_New = new CDP4JsonSerializer();
            CDP4JsonSerializer_New.Initialize(metadataprovider, new Version(1, 0, 0));

            Definition definition = null;
            Assert.Throws<ArgumentNullException>(() => CDP4JsonSerializer_New.SerializeToStream(definition, null, false));

            definition = new Definition();
            Assert.Throws<ArgumentNullException>(() => CDP4JsonSerializer_New.SerializeToStream(definition, null, false));
        }

        [Test]
        public void Verify_serializestring_throws_exception_when_metadata_and_version_not_set()
        {
            var definition = new Definition();
            
            var CDP4JsonSerializer_New = new CDP4JsonSerializer();

            Assert.Throws<InvalidOperationException>(() => CDP4JsonSerializer_New.SerializeToString(definition, false));
        }

        [Test]
        public void Verify_that_deserialize_throws_exception()
        {
            var response = System.IO.File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/SiteDirectory.json"));
            var CDP4JsonSerializer_New = new CDP4JsonSerializer();
            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                Assert.Throws<InvalidOperationException>(() => CDP4JsonSerializer_New.Deserialize(stream));
            }
        }
    }
}
