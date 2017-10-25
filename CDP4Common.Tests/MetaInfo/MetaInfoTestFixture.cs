// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MetaInfoTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.MetaInfo
{
    using CDP4Common.MetaInfo;
    using NUnit.Framework;

    [TestFixture]
    internal class MetaInfoTestFixture
    {
        [Test]
        public void VerifyThatGetPropertiesforMetaInfoWorks()
        {
            var modelRdlMetaInfo = new ModelReferenceDataLibraryMetaInfo();
            var properties = modelRdlMetaInfo.Properties;
            Assert.IsNotEmpty(properties);
        }
    }
}