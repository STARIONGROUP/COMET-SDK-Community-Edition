// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblerIntegrationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using CDP4Dal;

    using NUnit.Framework;

    using File = System.IO.File;

    /// <summary>
    /// Suite of tests to test the <see cref="Assembler"/> class using DTO's produced from JSON
    /// </summary>
    [TestFixture]
    public class AssemblerIntegrationTestFixture
    {
        private Uri uri;

        private IEnumerable<Thing> dtos;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.stariongroup.eu");

            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/SiteDiretoryExtentDeep.json"));

            var metaDataProvider = new MetaDataProvider();
            var version = new Version(1, 0, 0);

            var jsonSerializer = new CDP4JsonSerializer.Cdp4JsonSerializer(metaDataProvider, version);

            using (var stream = GenerateStreamFromString(response))
            {
                this.dtos = jsonSerializer.Deserialize(stream);
            }
        }

        [Test]
        public async Task Verify_that_Thing_Revisions_is_populated_on_second_load()
        {
            var assembler = new Assembler(this.uri, new CDPMessageBus());

            var sw = Stopwatch.StartNew();
            await assembler.Synchronize(this.dtos);
            Console.WriteLine($"Synchronize took {sw.ElapsedMilliseconds} [ms]");

            sw.Restart();
            await assembler.Synchronize(this.dtos);
            Console.WriteLine($"re-Synchronize took {sw.ElapsedMilliseconds} [ms]");

            foreach (var dto in this.dtos)
            {
                dto.RevisionNumber++;
            }

            sw.Restart();
            await assembler.Synchronize(this.dtos);
            Console.WriteLine($"update-Synchronize took {sw.ElapsedMilliseconds} [ms]");

            var things = assembler.Cache.Values.Select(x => x.Value);

            foreach (var thing in things)
            {
                Assert.That(thing.Revisions.Count, Is.EqualTo(1));
            }

            sw.Restart();
            await assembler.Synchronize(this.dtos);
            Console.WriteLine($"re-Synchronize took {sw.ElapsedMilliseconds} [ms]");
        }

        public static Stream GenerateStreamFromString(string s)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}
