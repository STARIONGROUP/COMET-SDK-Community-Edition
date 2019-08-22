// <copyright file="BinaryRelationshipRuleCheckerTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené
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

namespace CDP4Rules.NetCore.Tests.RuleCheckers
{
    using System;
    using System.Linq;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Rules.Common;
    using CDP4Rules.RuleCheckers;
    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BinaryRelationshipRuleChecker"/> class.
    /// </summary>
    [TestFixture]
    public class BinaryRelationshipRuleCheckerTestFixture
    {
        private BinaryRelationshipRuleChecker binaryRelationshipRuleChecker;

        private Iteration iteration;

        private BinaryRelationship binaryRelationship;

        [SetUp]
        public void SetUp()
        {
            this.binaryRelationshipRuleChecker = new BinaryRelationshipRuleChecker();

            this.iteration = new Iteration {Iid = Guid.NewGuid()};
            this.binaryRelationship = new BinaryRelationship();
            this.iteration.Relationship.Add(this.binaryRelationship);
        }

        [Test]
        public void Verify_that_when_thing_is_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(null));
        }

        [Test]
        public void Verify_that_when_thing_is_not_a_BinaryRelationship_exception_is_thrown()
        {
            var elementDefinition = new ElementDefinition();

            Assert.Throws<ArgumentException>(() => this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(elementDefinition));
        }

        [Test]
        public void Verify_that_when_source_or_target_are_null_exception_is_thrown()
        {
            Assert.Throws<IncompleteModelException>(() => this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship));

            this.binaryRelationship.Source = new ElementDefinition();

            Assert.Throws<IncompleteModelException>(() => this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship));
        }

        [Test]
        public void Verify_that_when_source_is_not_contained_by_an_Iteration_a_result_is_returned()
        {
            var elementDefinition = new ElementDefinition();
            this.iteration.Element.Add(elementDefinition);

            var siteDirectory = new SiteDirectory();
            this.binaryRelationship.Source = siteDirectory;
            this.binaryRelationship.Target = elementDefinition;
            
            var result = this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship).Single();

            Assert.That(result.Id, Is.EqualTo("MA-0510"));
            Assert.That(result.Description,Is.EqualTo("The source is not contained by an Iteration"));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationship));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_target_is_not_contained_by_an_Iteration_a_result_is_returned()
        {
            var source = new ElementDefinition();
            this.iteration.Element.Add(source);
            this.binaryRelationship.Source = source;

            var siteDirectory = new SiteDirectory();
            this.binaryRelationship.Target = siteDirectory;
            
            var result = this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship).SingleOrDefault();

            Assert.That(result.Id, Is.EqualTo("MA-0510"));
            Assert.That(result.Description, Is.EqualTo("The target is not contained by an Iteration"));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationship));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_source_is_not_contained_by_the_same_iteration_a_result_is_returned()
        {
            var source = new ElementDefinition();
            var otherIteration = new Iteration();
            otherIteration.Element.Add(source);
            this.binaryRelationship.Source = source;

            var target = new ElementDefinition();
            this.iteration.Element.Add(target);
            this.binaryRelationship.Target = target;

            var result = this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship).SingleOrDefault();

            Assert.That(result.Id, Is.EqualTo("MA-0510"));
            Assert.That(result.Description, Is.EqualTo("The source of the BinaryRelationship is not contained by the same Iteration as the BinaryRelationship"));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationship));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_target_is_not_contained_by_the_same_iteration_a_result_is_returned()
        {
            var source = new ElementDefinition();
            this.iteration.Element.Add(source);
            this.binaryRelationship.Source = source;

            var otherIteration = new Iteration();
            var target = new ElementDefinition();
            otherIteration.Element.Add(target);
            this.binaryRelationship.Target = target;

            var result = this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship).SingleOrDefault();

            Assert.That(result.Id, Is.EqualTo("MA-0510"));
            Assert.That(result.Description, Is.EqualTo("The target of the BinaryRelationship is not contained by the same Iteration as the BinaryRelationship"));
            Assert.That(result.Thing, Is.EqualTo(this.binaryRelationship));
            Assert.That(result.Severity, Is.EqualTo(SeverityKind.Warning));
        }

        [Test]
        public void Verify_that_when_source_and_target_are_contained_by_the_same_iteration_as_the_BinaryRelationship_null_is_returned()
        {
            var source = new ElementDefinition();
            this.iteration.Element.Add(source);
            this.binaryRelationship.Source = source;

            var target = new ElementDefinition();
            this.iteration.Element.Add(target);
            this.binaryRelationship.Target = target;

            var results = this.binaryRelationshipRuleChecker.CheckWhetherSourceAndTargetAreContainedByTheSameIteration(this.binaryRelationship);

            Assert.That(results, Is.Empty);
        }
    }
}