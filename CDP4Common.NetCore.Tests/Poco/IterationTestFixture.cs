﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IterationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-COMET-SDK Community Edition
//
//    The CDP4-COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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
        public void VerifyThatRequiredRdlRdlsReturnsExpectedResult()
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

            Assert.That(requiredRdls, Does.Contain(genericRdl));
            Assert.That(requiredRdls, Does.Contain(familyofRdl));
            Assert.That(requiredRdls, Does.Contain(modelrdl));

            Assert.That(requiredRdls.Count(), Is.EqualTo(3));
        }
    }
}
