// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SiteDirectoryTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="SiteDirectory"/> class.
    /// </summary>
    public class SiteDirectoryTestFixture
    {
        [Test]
        public void VerifyThatAvailableReferenceDataLibrariesReturnsExpected()
        {
            var siteDirectory = new SiteDirectory(Guid.NewGuid(), null, null);

            var siterefenceDataLibrary = new SiteReferenceDataLibrary(Guid.NewGuid(), null, null);            
            siteDirectory.SiteReferenceDataLibrary.Add(siterefenceDataLibrary);

            var engineeringModelSetup = new EngineeringModelSetup(Guid.NewGuid(), null, null);
            var modelReferenceDataLibrary = new ModelReferenceDataLibrary(Guid.NewGuid(), null, null);
            engineeringModelSetup.RequiredRdl.Add(modelReferenceDataLibrary);
            siteDirectory.Model.Add(engineeringModelSetup);

            var availableReferenceDataLibraries = siteDirectory.AvailableReferenceDataLibraries();

            CollectionAssert.Contains(availableReferenceDataLibraries, siterefenceDataLibrary);
            CollectionAssert.Contains(availableReferenceDataLibraries, modelReferenceDataLibrary);
        }
    }
}
