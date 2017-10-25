// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferenceDataLibraryTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    [TestFixture]
    internal class ReferenceDataLibraryTestFixture
    {
        [Test]
        public void VerifyThatGetRequiresRdlWorks()
        {
            var mRdl = new ModelReferenceDataLibrary();
            var sRdl1 = new SiteReferenceDataLibrary();
            var srdl11 = new SiteReferenceDataLibrary();
            var sRdl2 = new SiteReferenceDataLibrary();

            mRdl.RequiredRdl = srdl11;
            srdl11.RequiredRdl = sRdl1;

            int i = 0;
            foreach (var rdl in mRdl.GetRequiredRdls())
            {
                i++;
            }

            Assert.AreEqual(2, i);

            i = 0;
            foreach (var rdl in sRdl2.GetRequiredRdls())
            {
                i++;
            }

            Assert.AreEqual(0, i);
        }
    }
}