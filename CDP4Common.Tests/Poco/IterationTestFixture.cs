// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Poco
{
    using System.Linq;

    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="Iteration"/> class
    /// </summary>
    [TestFixture]
    public class IterationTestFixture
    {
        [Test]
        public void VerifyThatRequriedRdlsReturnsExpectedResult()
        {
            var genericRdl = new SiteReferenceDataLibrary();
            var familyofRdl = new SiteReferenceDataLibrary();
            
            familyofRdl.RequiredRdl = genericRdl;

            var modelrdl = new ModelReferenceDataLibrary();
            modelrdl.RequiredRdl = familyofRdl;

            var iteration = new Iteration();
            var engineeringModel = new EngineeringModel();
            engineeringModel.Iteration.Add(iteration);
            
            var engineeringModelSetup = new EngineeringModelSetup();
            var iterationSetup = new IterationSetup();

            engineeringModelSetup.RequiredRdl.Add(modelrdl);
            engineeringModelSetup.IterationSetup.Add(iterationSetup);

            iteration.IterationSetup = iterationSetup;

            var requiredRdls = iteration.RequiredRdls;

            CollectionAssert.Contains(requiredRdls, genericRdl);
            CollectionAssert.Contains(requiredRdls, familyofRdl);
            CollectionAssert.Contains(requiredRdls, modelrdl);

            Assert.AreEqual(3, requiredRdls.Count());
        }
    }
}
