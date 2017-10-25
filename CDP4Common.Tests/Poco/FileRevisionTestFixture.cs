// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileRevisionTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
            this.folder = new Folder(Guid.NewGuid(), null, null) {Name = "path"};

            this.filerev = new FileRevision(Guid.NewGuid(), null, null);
            this.filerev.Name = "filerev";

            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext1" });
            this.filerev.FileType.Add(new FileType(Guid.NewGuid(), null, null) { Extension = "ext2" });

            this.filerev.ContainingFolder = this.folder;
        }

        [Test]
        public void VerifyPath()
        {
            Assert.AreEqual("/path/filerev.ext1.ext2", this.filerev.Path);
        }
    }
}