// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingSerializerTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4JsonSerializer.Tests.JsonConverter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.Json;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer.JsonConverter;

    using NUnit.Framework;

    using Thing = CDP4Common.DTO.Thing;

    [TestFixture]
    public class ThingSerializerTestFixture
    {
        [Test]
        public void VerifyThatReadReturnsThing()
        {
            var json = $"{{\"classKind\":\"Category\",\"iid\":\"{Guid.NewGuid()}\",\"revisionNumber\":1}}";
            var bytes = Encoding.UTF8.GetBytes(json);
            var reader = new Utf8JsonReader(bytes);
            reader.Read();

            var serializer = new ThingSerializer(new MetaDataProvider(), new Version(1, 0, 0));
            var thing = serializer.Read(ref reader, typeof(Thing), new JsonSerializerOptions());

            Assert.That(thing, Is.InstanceOf<Category>());
        }

        [Test]
        public void VerifyThatWriteSkipsWhenClassVersionIsHigherThanRequested()
        {
            var provider = new TestMetaDataProvider(new MetaDataProvider());
            provider.SetClassVersion("Category", "2.0.0");

            var serializer = new ThingSerializer(provider, new Version(1, 0, 0));
            var category = new Category(Guid.NewGuid(), 0);

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            serializer.Write(writer, category, new JsonSerializerOptions());
            writer.Flush();

            Assert.That(stream.Length, Is.EqualTo(0));
        }

        [Test]
        public void VerifyThatWriteRemovesIncompatiblePermissibleClasses()
        {
            var provider = new TestMetaDataProvider(new MetaDataProvider());
            provider.SetClassVersion("Category", "1.0.0");
            provider.SetClassVersion("ElementDefinition", "1.0.0");
            provider.SetClassVersion("Parameter", "2.0.0");

            var serializer = new ThingSerializer(provider, new Version(1, 0, 0));
            var category = new Category(Guid.NewGuid(), 0);
            category.PermissibleClass.Add(ClassKind.ElementDefinition);
            category.PermissibleClass.Add(ClassKind.Parameter);

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            serializer.Write(writer, category, new JsonSerializerOptions());
            writer.Flush();

            Assert.That(category.PermissibleClass, Has.Count.EqualTo(1));
            Assert.That(category.PermissibleClass, Does.Contain(ClassKind.ElementDefinition));
            Assert.That(stream.Length, Is.GreaterThan(0));
        }

        [Test]
        public void VerifyThatWriteSkipsWhenAssertSerializationReturnsFalse()
        {
            var provider = new TestMetaDataProvider(new MetaDataProvider());
            provider.SetClassVersion("PersonPermission", "1.0.0");
            provider.SetClassVersion("Parameter", "2.0.0");

            var serializer = new ThingSerializer(provider, new Version(1, 0, 0));
            var permission = new PersonPermission(Guid.NewGuid(), 0)
            {
                ObjectClass = ClassKind.Parameter
            };

            using var stream = new MemoryStream();
            using var writer = new Utf8JsonWriter(stream);

            serializer.Write(writer, permission, new JsonSerializerOptions());
            writer.Flush();

            Assert.That(stream.Length, Is.EqualTo(0));
        }

        private sealed class TestMetaDataProvider : IMetaDataProvider
        {
            private readonly IMetaDataProvider inner;
            private readonly Dictionary<string, string> classVersionOverrides = new (StringComparer.Ordinal);

            public TestMetaDataProvider(IMetaDataProvider inner)
            {
                this.inner = inner;
            }

            public void SetClassVersion(string typeName, string version)
            {
                this.classVersionOverrides[typeName] = version;
            }

            public IMetaInfo GetMetaInfo(string typeName)
            {
                return this.inner.GetMetaInfo(typeName);
            }

            public string BaseType(string typeName)
            {
                return this.inner.BaseType(typeName);
            }

            public string GetClassVersion(string typeName)
            {
                return this.classVersionOverrides.TryGetValue(typeName, out var version) ? version : this.inner.GetClassVersion(typeName);
            }

            public string GetPropertyVersion(string typeName, string propertyName)
            {
                return this.inner.GetPropertyVersion(typeName, propertyName);
            }

            public IEnumerable<Version> QuerySupportedModelVersions()
            {
                return this.inner.QuerySupportedModelVersions();
            }

            public Version GetMaxSupportedModelVersion()
            {
                return this.inner.GetMaxSupportedModelVersion();
            }
        }
    }
}
