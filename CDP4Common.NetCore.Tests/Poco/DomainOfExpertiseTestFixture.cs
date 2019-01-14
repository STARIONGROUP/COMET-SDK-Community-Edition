#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertiseTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
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

namespace CDP4Common.Tests.Poco
{
    using System;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="DomainOfExpertise"/> class
    /// </summary>
    [TestFixture]
    public class DomainOfExpertiseTestFixture
    {
        private DomainOfExpertise domainOfExpertise;
        private EngineeringModel model;
        private Iteration iteration;
        
        [SetUp]
        public void SetUp()
        {
            this.domainOfExpertise = new DomainOfExpertise(Guid.NewGuid(), null, null);

            this.iteration = new Iteration(Guid.NewGuid(), null, null);
            this.model = new EngineeringModel(Guid.NewGuid(), null, null);
            this.model.Iteration.Add(this.iteration);
        }

        [Test]
        public void VerifyThatOwnedParametersReturnsExpectedResult()
        {
            var elementDefinition = new ElementDefinition(Guid.NewGuid(), null, null);
            elementDefinition.Owner = this.domainOfExpertise;
            this.iteration.Element.Add(elementDefinition);

            var parameter = new Parameter(Guid.NewGuid(), null, null);
            parameter.Owner = this.domainOfExpertise;
            elementDefinition.Parameter.Add(parameter);


            var ownedParameters = this.domainOfExpertise.OwnedParameters(this.iteration);
            CollectionAssert.Contains(ownedParameters, parameter);
        }
    }
}
