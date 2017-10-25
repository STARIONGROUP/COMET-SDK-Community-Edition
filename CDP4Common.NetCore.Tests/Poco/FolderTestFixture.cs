// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FolderTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.EngineeringModelData;
    using NUnit.Framework;
    using System;

    [TestFixture]
    internal class FolderTestFixture
    {
        private Folder folder;
        private Folder topfolder;
        private Folder superTopfolder;

        [SetUp]
        public void Setup()
        {
            this.folder = new Folder(Guid.NewGuid(), null, null) { Name = "path" };
            this.topfolder = new Folder(Guid.NewGuid(), null, null) { Name = "top" };
            this.superTopfolder = new Folder(Guid.NewGuid(), null, null) { Name = "supertop" };

            this.folder.ContainingFolder = this.topfolder;
            this.topfolder.ContainingFolder = this.superTopfolder;
        }

        [Test]
        public void VerifyPath()
        {
            Assert.AreEqual("supertop/top", this.folder.Path);
        }
    }
}