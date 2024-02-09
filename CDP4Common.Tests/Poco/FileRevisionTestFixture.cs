// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevisionTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Tests.Poco
{
    using System;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class FileRevisionTestFixture
    {
        private FileRevision filerev;
        private Folder folder;

        [SetUp]
        public void Setup()
        {
            this.folder = new Folder(Guid.NewGuid(), null, null) { Name = "path" };

            this.filerev = new FileRevision(Guid.NewGuid(), null, null);
            this.filerev.Name = "filerev";

            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext1" });
            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = null });
            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "" });
            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext2" });

            this.filerev.ContainingFolder = this.folder;
        }

        [Test]
        public void VerifyPath()
        {
            Assert.That(this.filerev.Path, Is.EqualTo("/path/filerev.ext1.ext2"));
        }
    }
}
