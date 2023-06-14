// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CherryPickTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski, Antoine Théate
//
//    This file is part of COMET-SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.DAL;

    [TestFixture]
    public class CherryPickTestFixture
    {
        private CdpServicesDal dal;
        private Credentials credentials;
        private ISession session;

        private readonly Uri uri = new Uri("http://localhost:5005");
        private CancellationTokenSource cancelationTokenSource;

        [SetUp]
        public void Setup()
        {
            this.cancelationTokenSource = new CancellationTokenSource();

            this.credentials = new Credentials("admin", "pass", this.uri);
            this.dal = new CdpServicesDal();
            this.session = new Session(this.dal, this.credentials);
        }

        [TearDown]
        public void Teardown()
        {
            CDPMessageBus.Current.ClearSubscriptions();
            this.credentials = null;
            this.dal = null;
            this.session = null;
        }

        [Test]
        [Category("WebServicesDependent")]
        public async Task VerifyCanCherryPick()
        {
            await this.session.Open();
            var engineeringModelId = Guid.Parse("1a02872b-d126-42d5-b8f1-b30455a70cbf");
            var iterationId = Guid.Parse("b3064923-e3dc-4a07-8306-71392997c097");
            var viewerCategory = Guid.Parse("2b64bcd8-c6e2-4a00-b830-11d35f6d0765");
            var earthSensor = Guid.Parse("502caabd-17c3-4ce3-9c54-dcc50a2ab4ee");
            await this.dal.CherryPick(engineeringModelId, iterationId, new List<ClassKind> { ClassKind.ElementDefinition, ClassKind.ElementUsage, ClassKind.ParameterOverride,  ClassKind.Parameter },
                new List<Guid> { viewerCategory, earthSensor }, this.cancelationTokenSource.Token);
        }
    }
}
