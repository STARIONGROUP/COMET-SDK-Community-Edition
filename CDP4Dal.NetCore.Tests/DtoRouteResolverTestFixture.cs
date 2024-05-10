// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DtoRouteResolverTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Dal.Tests.Helpers
{
    using System;
    using System.Collections.Generic;
    using CDP4Dal.Exceptions;
    using CDP4Common.DTO;
    using CDP4Common.Types;
    using Moq;
    using NUnit.Framework;

    using Poco = CDP4Common.EngineeringModelData;

    [TestFixture]
    internal class DtoRouteResolverTestFixture
    {
        private EngineeringModel model;
        private Iteration iteration;
        private PossibleFiniteStateList statelist;
        private PossibleFiniteState state;
        private Mock<ISession> session;
        private Assembler assembler;
        private Uri uri = new Uri("http://test.com");

        private Poco.EngineeringModel pocoModel;
        private Poco.Iteration pocoIt;
        private Poco.PossibleFiniteStateList pocoStateList;
        private Poco.PossibleFiniteState pocoState;
            
        [SetUp]
        public void Setup()
        {
            this.model = new EngineeringModel(Guid.NewGuid(), 0);
            this.iteration = new Iteration(Guid.NewGuid(), 0);
            this.statelist = new PossibleFiniteStateList(Guid.NewGuid(), 0){IterationContainerId = this.iteration.Iid};
            this.state = new PossibleFiniteState(Guid.NewGuid(), 0){IterationContainerId = this.iteration.Iid};
            this.model.Iteration.Add(this.iteration.Iid);
            this.iteration.PossibleFiniteStateList.Add(this.statelist.Iid);
            this.statelist.PossibleState.Add(new OrderedItem { K = 1, V = this.state.Iid });

            this.assembler = new Assembler(this.uri, new CDPMessageBus());
            this.session = new Mock<ISession>();
            this.session.Setup(x => x.Assembler).Returns(this.assembler);

            this.pocoModel = new Poco.EngineeringModel(this.model.Iid, this.assembler.Cache, this.uri);
            this.pocoIt = new Poco.Iteration(this.iteration.Iid, this.assembler.Cache, this.uri);
            this.pocoStateList = new Poco.PossibleFiniteStateList(this.statelist.Iid, this.assembler.Cache, this.uri);
            this.pocoState = new Poco.PossibleFiniteState(this.state.Iid, this.assembler.Cache, this.uri);

            this.pocoModel.Iteration.Add(pocoIt);
            this.pocoIt.PossibleFiniteStateList.Add(pocoStateList);
            this.pocoStateList.PossibleState.Add(pocoState);
        }

        [Test]
        public void VerifyThatResolveRouteWorks()
        {
            var list = new List<Thing>
            {
                this.model,
                this.iteration,
                this.statelist,
                this.state
            };

            this.state.ResolveRoute(list, this.session.Object);
            var route = this.state.Route;
            Assert.That($@"/EngineeringModel/{this.model.Iid}/iteration/{this.iteration.Iid}/possibleFiniteStateList/{this.statelist.Iid}/possibleState/{this.state.Iid}", Is.EqualTo(route));
        }

        [Test]
        public void VerifyThatResolveTopContainerRouteWorks()
        {
            var list = new List<Thing>
            {
                this.model,
                this.iteration,
                this.statelist,
                this.state
            };

            this.model.ResolveRoute(list, this.session.Object);
            var route = this.model.Route;
            Assert.That($@"/EngineeringModel/{this.model.Iid}", Is.EqualTo(route));
        }

        [Test]
        public void VerifyThatFullContainmentTreeIsBuiltFromSession()
        {
            var list = new List<Thing>
            {
                this.state
            };

            this.assembler.Cache.TryAdd(new CacheKey(this.model.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoModel));
            this.assembler.Cache.TryAdd(new CacheKey(this.iteration.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoIt));
            this.assembler.Cache.TryAdd(new CacheKey(this.statelist.Iid, this.iteration.Iid), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoStateList));
            this.assembler.Cache.TryAdd(new CacheKey(this.state.Iid, this.iteration.Iid), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoState));

            this.state.ResolveRoute(list, this.session.Object);
            var route = this.state.Route;
            Assert.That($@"/EngineeringModel/{this.model.Iid}/iteration/{this.iteration.Iid}/possibleFiniteStateList/{this.statelist.Iid}/possibleState/{this.state.Iid}", Is.EqualTo(route));
        }

        [Test]
        public void VerifyThatPartialContainmentTreeIsBuiltFromSession()
        {
            var list = new List<Thing>
            {
                this.statelist,
                this.state
            };

            this.assembler.Cache.TryAdd(new CacheKey(this.model.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoModel));
            this.assembler.Cache.TryAdd(new CacheKey(this.iteration.Iid, null), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoIt));
            this.assembler.Cache.TryAdd(new CacheKey(this.statelist.Iid, this.iteration.Iid), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoStateList));

            this.state.ResolveRoute(list, this.session.Object);
            var route = this.state.Route;
            Assert.That($@"/EngineeringModel/{this.model.Iid}/iteration/{this.iteration.Iid}/possibleFiniteStateList/{this.statelist.Iid}/possibleState/{this.state.Iid}", Is.EqualTo(route));
        }

        [Test]
        public void VerifyThatExceptionThrown()
        {
            var list = new List<Thing>
            {
                this.model,
                this.statelist,
                this.state
            };

            Assert.Throws<InstanceNotFoundException>(() =>
            
                this.state.ResolveRoute(list, this.session.Object)
            );
        }

        [Test]
        public void VerifyThatExceptionThrown2()
        {
            var list = new List<Thing>();

            Assert.Throws<InstanceNotFoundException>(() =>

                    this.state.ResolveRoute(list, this.session.Object)
            );
        }

        [Test]
        public void VerifyThatExceptionThrown3()
        {
            var list = new List<Thing>
            {
                this.state
            };

            this.pocoState.Container = null;
            this.assembler.Cache.TryAdd(new CacheKey(this.state.Iid, this.iteration.Iid), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoState));
            

            Assert.Throws<NullReferenceException>(() =>

                this.state.ResolveRoute(list, this.session.Object)
            );
        }

        [Test]
        public void VerifyThatExceptionThrown4()
        {
            var list = new List<Thing>
            {
                this.statelist,
                this.state
            };

            this.pocoStateList.Container = null;
            this.assembler.Cache.TryAdd(new CacheKey(this.statelist.Iid, this.iteration.Iid), new Lazy<CDP4Common.CommonData.Thing>(() => this.pocoStateList));
            
            Assert.Throws<NullReferenceException>(() =>

                this.state.ResolveRoute(list, this.session.Object)
            );
        }

        [Test]
        public void VerifyThatArgumentNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() =>

                this.state.ResolveRoute(null, this.session.Object)
            );
        }

        [Test]
        public void VerifyThatArgumentNullExceptionIsThrown2()
        {
            var list = new List<Thing>
            {
                this.model,
                this.statelist,
                this.state
            };

            
            Assert.Throws<ArgumentNullException>(() =>

                this.state.ResolveRoute(list, null)
            );
        }
    }
}