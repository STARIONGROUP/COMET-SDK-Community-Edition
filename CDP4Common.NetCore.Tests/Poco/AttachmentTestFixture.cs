// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AttachmentTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
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
    using System;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    [TestFixture]
    internal class AttachmentTestFixture
    {
        private Attachment attachment;

        [SetUp]
        public void Setup()
        {
            this.attachment = new Attachment(Guid.NewGuid(), null, null);
            this.attachment.FileName = "filerev";

            this.attachment.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext1" });
            this.attachment.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext2" });
        }

        [Test]
        public void VerifyPathForFileRevisionLocatedInFileStore()
        {
            Assert.AreEqual("filerev.ext1.ext2", this.attachment.Path);
        }
    }
}