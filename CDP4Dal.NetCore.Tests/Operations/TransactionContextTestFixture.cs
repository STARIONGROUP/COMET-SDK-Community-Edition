// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionContextTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2019 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;
    using CDP4Dal.Operations;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="TransactionContext"/> class
    /// </summary>
    [TestFixture]
    public class TransactionContextTestFixture
    {
        private ConcurrentDictionary<CacheKey, Lazy<Thing>> cache;
        private Uri uri = new Uri("http://www.stariongroup.eu");

        private Guid siteDirectoryIid;
        private Guid engineeringModelIid;
        private Guid iterationIid;

        private SiteDirectory siteDirectory;
        private EngineeringModel engineeringModel;
        private Iteration iteration;

        [SetUp]
        public void SetUp()
        {
            this.cache = new ConcurrentDictionary<CacheKey, Lazy<CDP4Common.CommonData.Thing>>();

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
            
            this.cache.TryAdd(new CacheKey(this.siteDirectory.Iid, null), new Lazy<Thing>(() => this.siteDirectory));
            this.cache.TryAdd(new CacheKey(this.engineeringModel.Iid, null), new Lazy<Thing>(() => this.engineeringModel));
            this.cache.TryAdd(new CacheKey(this.iteration.Iid, null), new Lazy<Thing>(() => this.iteration));
            this.cache.TryAdd(new CacheKey(iterationSetup.Iid, null), new Lazy<Thing>(() => iterationSetup));
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
