// -------------------------------------------------------------------------------------------------
// <copyright file="TransactionContextTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common.Tests.Operations
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Operations;
    using CDP4Common.SiteDirectoryData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="TransactionContext"/> class
    /// </summary>
    [TestFixture]
    public class TransactionContextTestFixture
    {
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;
        private Uri uri = new Uri("http://www.rheagroup.com");

        private Guid siteDirectoryIid;
        private Guid engineeringModelIid;
        private Guid iterationIid;

        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private Iteration iteration;

        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.siteDirectoryIid = Guid.Parse("7D445137-5E73-41A1-B326-983DB7A4E9A2");
            this.engineeringModelIid = Guid.Parse("BDDFB6A4-76B3-4CAC-ACAB-5540126C47B6");
            this.iterationIid = Guid.Parse("05F17A1A-1021-450F-976D-286037F04646");
            
            this.siteDirectory = new SiteDirectory(this.siteDirectoryIid, this.cache, this.uri);
            this.engineeringModel = new EngineeringModel(this.engineeringModelIid, this.cache, this.uri);

            this.iteration = new Iteration(this.iterationIid, this.cache, this.uri);
            var iterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, this.uri) { RevisionNumber = 1 };
            this.iteration.IterationSetup = iterationSetup;
            iterationSetup.IterationIid = this.iteration.Iid;

            this.engineeringModel.Iteration.Add(this.iteration);

            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.siteDirectory.Iid, null), new Lazy<Thing>(() => this.siteDirectory));
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.engineeringModel.Iid, null), new Lazy<Thing>(() => this.engineeringModel));
            this.cache.TryAdd(new Tuple<Guid, Guid?>(this.iteration.Iid, null), new Lazy<Thing>(() => this.iteration));
            this.cache.TryAdd(new Tuple<Guid, Guid?>(iterationSetup.Iid, null), new Lazy<Thing>(() => iterationSetup));
        }

        [Test]
        public void VerifyThatContextIsSet()
        {
            var siteDirectoryTransactionContex = new TransactionContext(this.siteDirectory);
            Assert.AreEqual(this.siteDirectory, siteDirectoryTransactionContex.Context);

            var iterationTransactionContex = new TransactionContext(this.iteration);
            Assert.AreEqual(this.iteration, iterationTransactionContex.Context);
        }

        [Test]
        public void Verify_That_ContextRoute_Returns_Expected_Result_for_SiteDirectory()
        {
            var siteDirectoryTransactionContex = new TransactionContext(this.siteDirectory);
            Assert.AreEqual("/SiteDirectory/7d445137-5e73-41a1-b326-983db7a4e9a2", siteDirectoryTransactionContex.ContextRoute());
        }

        [Test]
        public void Verify_That_ContextRoute_Returns_Expected_Result_for_Iteration()
        {
            var iterationTransactionContex = new TransactionContext(this.iteration);
            Assert.AreEqual("/EngineeringModel/bddfb6a4-76b3-4cac-acab-5540126c47b6/iteration/05f17a1a-1021-450f-976d-286037f04646", iterationTransactionContex.ContextRoute());
        }
    }
}
