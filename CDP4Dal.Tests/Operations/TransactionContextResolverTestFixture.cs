#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionContextResolverTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Concurrent;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Dal.Operations;
    using NUnit.Framework;

    [TestFixture]
    public class TransactionContextResolverTestFixture
    {
        private Uri uri;
        private ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache;

        private SiteDirectory siteDirectory;
        private TextParameterType textParameterType;
        private EngineeringModel engineeringModel;
        private Iteration frozenIteration;
        private Iteration activeIteration;
        private ElementDefinition frozenElementDefinition;
        private ElementDefinition activeElementDefinition;
        private Book book;

        [SetUp]
        public void SetUp()
        {
            this.uri = new Uri("http://www.rheagroup.com");
            this.cache = new ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>>();

            this.siteDirectory = new SiteDirectory(Guid.NewGuid(), this.cache, this.uri);
            var siteReferenceDataLibrary = new SiteReferenceDataLibrary(Guid.NewGuid(), this.cache, this.uri);
            this.siteDirectory.SiteReferenceDataLibrary.Add(siteReferenceDataLibrary);
            this.textParameterType = new TextParameterType(Guid.NewGuid(), this.cache, this.uri);
            siteReferenceDataLibrary.ParameterType.Add(this.textParameterType);

            this.engineeringModel = new EngineeringModel(Guid.NewGuid(), this.cache, this.uri);
            this.engineeringModel.RevisionNumber = 2;

            var frozenIterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, this.uri);
            frozenIterationSetup.FrozenOn = DateTime.Parse("2012-12-12");

            this.frozenIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            this.frozenIteration.RevisionNumber = 1;
            this.frozenIteration.IterationSetup = frozenIterationSetup;
            
            var activeIterationSetup = new IterationSetup(Guid.NewGuid(), this.cache, this.uri);
            
            this.activeIteration = new Iteration(Guid.NewGuid(), this.cache, this.uri);
            this.activeIteration.RevisionNumber = 2;
            this.activeIteration.IterationSetup = activeIterationSetup;
            
            this.engineeringModel.Iteration.Add(this.frozenIteration);
            this.engineeringModel.Iteration.Add(this.activeIteration);

            var frozenElementDefinitionIid = Guid.NewGuid();
            this.frozenElementDefinition = new ElementDefinition(frozenElementDefinitionIid, this.cache, this.uri);
            this.frozenElementDefinition.RevisionNumber = 1;
            this.frozenIteration.Element.Add(this.frozenElementDefinition);

            var activeElementDefinitionIid = Guid.NewGuid();
            this.activeElementDefinition = new ElementDefinition(activeElementDefinitionIid, this.cache, this.uri);
            this.activeElementDefinition.RevisionNumber = 2;
            this.activeIteration.Element.Add(this.activeElementDefinition);

            this.book = new Book(Guid.NewGuid(), this.cache, this.uri);
            this.engineeringModel.Book.Add(this.book);
        }

        [Test]
        public void VerifyThatExpectedContextIsReturned()
        {
            TransactionContext transactionContext;

            transactionContext = TransactionContextResolver.ResolveContext(this.siteDirectory);
            Assert.AreEqual(this.siteDirectory, transactionContext.Context);

            transactionContext = TransactionContextResolver.ResolveContext(this.textParameterType);
            Assert.AreEqual(this.siteDirectory, transactionContext.Context);

            transactionContext = TransactionContextResolver.ResolveContext(this.activeIteration);
            Assert.AreEqual(this.activeIteration, transactionContext.Context);

            transactionContext = TransactionContextResolver.ResolveContext(this.activeElementDefinition);
            Assert.AreEqual(this.activeIteration, transactionContext.Context);

            transactionContext = TransactionContextResolver.ResolveContext(this.frozenElementDefinition);
            Assert.AreEqual(this.frozenIteration, transactionContext.Context);

            transactionContext = TransactionContextResolver.ResolveContext(this.book);
            Assert.AreEqual(this.activeIteration, transactionContext.Context);

            this.engineeringModel.Iteration.Remove(this.activeIteration);
            transactionContext = TransactionContextResolver.ResolveContext(this.book);
            Assert.AreEqual(this.frozenIteration, transactionContext.Context);
        }

        [Test]
        public void VerifyThatExceptionIsThrownWhenModelContainsNoIterations()
        {
            this.engineeringModel.Iteration.Clear();

            Assert.Throws<IncompleteModelException>(() => TransactionContextResolver.ResolveContext(this.book));
        }

        [Test]
        public void VerifyThatContextValidates()
        {
            Assert.IsTrue(TransactionContextResolver.ValidateRouteContext("/SiteDirectory/47363f0d-eb6d-4a58-95f5-fa7854995650"));
            Assert.IsTrue(TransactionContextResolver.ValidateRouteContext("/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d"));

            Assert.IsFalse(TransactionContextResolver.ValidateRouteContext("SiteDirectory/47363f0d-eb6d-4a58-95f5-fa7854995650"));
            Assert.IsFalse(TransactionContextResolver.ValidateRouteContext("EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d"));

            Assert.IsFalse(TransactionContextResolver.ValidateRouteContext("/SiteDirectory/47363f0d-eb6d-4a58-95f5-fa7854995650/whatever"));
            Assert.IsFalse(TransactionContextResolver.ValidateRouteContext("/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b/iteration/b58ea73d-350d-4520-b9d9-a52c75ac2b5d/whatever"));
            Assert.IsFalse(TransactionContextResolver.ValidateRouteContext("/EngineeringModel/5e5dc7f8-833d-4331-b421-eb2c64fcf64b"));
        }
    }
}
