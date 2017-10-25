// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DomainOfExpertiseTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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
