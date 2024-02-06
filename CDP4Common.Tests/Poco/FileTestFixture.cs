// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;
    
    using System;

    /// <summary>
    /// Suite of tests for the <see cref="File"/> class
    /// </summary>
    [TestFixture]
    internal class FileTestFixture
    {
        private File file;
        private Folder folder1;
        private Folder folder2;
        private FileRevision oldFileRevision;
        private FileRevision newFileRevision;

        [SetUp]
        public void Setup()
        {
            this.file = new File(Guid.NewGuid(), null, null);
            this.folder1 = new Folder(Guid.NewGuid(), null, null);
            this.folder2 = new Folder(Guid.NewGuid(), null, null);

            this.oldFileRevision = new FileRevision(Guid.NewGuid(), null, null) { CreatedOn = DateTime.UtcNow.AddHours(-1), ContainingFolder = this.folder1};
            this.newFileRevision = new FileRevision(Guid.NewGuid(), null, null) { CreatedOn = DateTime.UtcNow, ContainingFolder = this.folder2 };
        }

        [Test]
        public void VerifyContainingFolder()
        {
            //When no FileRevision is present, the CurrentContainingFolder is writable
            Assert.DoesNotThrow(() => this.file.CurrentContainingFolder = this.folder1);
            Assert.That(this.file.CurrentContainingFolder, Is.EqualTo(this.folder1));

            Assert.DoesNotThrow(() => this.file.CurrentContainingFolder = null);
            Assert.That(this.file.CurrentContainingFolder, Is.Null);

            //When any FileRevision is present, the CurrentContainingFolder is readonly and returns the latest FileRevisions folder
            this.file.FileRevision.Add(this.oldFileRevision);
            Assert.That(() => this.file.CurrentContainingFolder = this.folder1, Throws.TypeOf<InvalidOperationException>());
            Assert.That(this.file.CurrentContainingFolder, Is.EqualTo(this.folder1));

            this.file.FileRevision.Add(this.newFileRevision);
            Assert.That(this.file.CurrentContainingFolder, Is.EqualTo(this.folder2));
        }

        [Test]
        public void VerifyCurrentFileRevision()
        {
            Assert.That(this.file.CurrentFileRevision, Is.Null);

            this.file.FileRevision.Add(this.oldFileRevision);
            Assert.That(this.file.CurrentFileRevision, Is.EqualTo(this.oldFileRevision));

            this.file.FileRevision.Add(this.newFileRevision);
            Assert.That(this.file.CurrentFileRevision, Is.EqualTo(this.newFileRevision));
        }
    }
}
