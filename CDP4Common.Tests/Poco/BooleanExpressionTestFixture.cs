// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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
    using System;
    using System.Collections.Generic;

    using CDP4Common.EngineeringModelData;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BooleanExpression"/> class
    /// </summary>
    [TestFixture]
    public class BooleanExpressionTestFixture
    {
        private const ExpressionNumber AllRelationaExpressionNumbers = ExpressionNumber.Relational1 |
                    ExpressionNumber.Relational2 |
                    ExpressionNumber.Relational3 |
                    ExpressionNumber.Relational4;

        /// <summary>
        /// Because we are using TestCase as a source, a static object must be used to execute tests.
        /// In the Testcases, the <see cref="ExpressionNumber"/> enum is used and runtime the matching <see cref="BooleanExpression"/>
        /// can be found in this <see cref="Dictionary{ExpressionNumber,BooleanExpression}"/> 
        /// </summary>
        private IDictionary<ExpressionNumber, BooleanExpression> testCaseList;

        private ParametricConstraint parametricConstraint;

        private AndExpression andExpression;

        private OrExpression orExpression;

        private ExclusiveOrExpression exclusiveOrExpression;

        private NotExpression notExpression;

        private RelationalExpression relationalExpression1;

        private RelationalExpression relationalExpression2;

        private RelationalExpression relationalExpression3;

        private RelationalExpression relationalExpression4;

        [SetUp]
        public void SetUp()
        {
            this.andExpression = new AndExpression();
            this.orExpression = new OrExpression();
            this.exclusiveOrExpression = new ExclusiveOrExpression();
            this.notExpression = new NotExpression();
            this.relationalExpression1 = new RelationalExpression();
            this.relationalExpression2 = new RelationalExpression();
            this.relationalExpression3 = new RelationalExpression();
            this.relationalExpression4 = new RelationalExpression();

            this.parametricConstraint = new ParametricConstraint();

            this.parametricConstraint.Expression.AddRange(new List<BooleanExpression>
            {
                this.andExpression,
                this.orExpression,
                this.exclusiveOrExpression,
                this.notExpression,
                this.relationalExpression1,
                this.relationalExpression2,
                this.relationalExpression3,
                this.relationalExpression4
            });

            foreach (var expression in this.parametricConstraint.Expression)
            {
                expression.Container = this.parametricConstraint;
            }

            this.testCaseList = new Dictionary<ExpressionNumber, BooleanExpression>
            {
                { ExpressionNumber.And, this.andExpression },
                { ExpressionNumber.Or, this.orExpression },
                { ExpressionNumber.ExclusiveOr, this.exclusiveOrExpression },
                { ExpressionNumber.Not, this.notExpression },
                { ExpressionNumber.Relational1, this.relationalExpression1 },
                { ExpressionNumber.Relational2, this.relationalExpression2 },
                { ExpressionNumber.Relational3, this.relationalExpression3 },
                { ExpressionNumber.Relational4, this.relationalExpression4 }
            };
        }

        private IEnumerable<BooleanExpression> GetBooleanExpressionList(ExpressionNumber expectedExpressionNumbers)
        {
            foreach (var value in Enum.GetValues(typeof(ExpressionNumber)))
            {
                if (expectedExpressionNumbers.HasFlag((ExpressionNumber)value))
                {
                    yield return this.testCaseList[(ExpressionNumber)value];
                }
            }
        }


        [TestCase(ExpressionNumber.And, ExpressionNumber.And | ExpressionNumber.Relational1 | ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToAndExpression(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            var descendantCollection = this.testCaseList[expressionNumber].GetMeAndMyDescendantExpressions();
            var myAndFreeCollection = this.testCaseList[expressionNumber].GetMyAndFreeExpressions();

            var myExpressions = expectedExpressionNumbers & ~expressionNumber;
            var freeExpressions = AllRelationaExpressionNumbers & ~(ExpressionNumber.Relational1 | ExpressionNumber.Relational2);

            Assert.That(this.GetBooleanExpressionList(expectedExpressionNumbers), Is.EquivalentTo(descendantCollection));
            Assert.That(this.GetBooleanExpressionList(myExpressions | freeExpressions), Is.EquivalentTo(myAndFreeCollection));
        }

        [TestCase(ExpressionNumber.And, ExpressionNumber.And)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or | ExpressionNumber.Relational1 | ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToOrExpression(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.orExpression.Term.Add(this.relationalExpression1);
            this.orExpression.Term.Add(this.relationalExpression2);

            var descendantCollection = this.testCaseList[expressionNumber].GetMeAndMyDescendantExpressions();
            var myAndFreeCollection = this.testCaseList[expressionNumber].GetMyAndFreeExpressions();

            var myExpressions = expectedExpressionNumbers & ~expressionNumber;
            var freeExpressions = AllRelationaExpressionNumbers & ~(ExpressionNumber.Relational1 | ExpressionNumber.Relational2);

            Assert.That(this.GetBooleanExpressionList(expectedExpressionNumbers), Is.EquivalentTo(descendantCollection));
            Assert.That(this.GetBooleanExpressionList(myExpressions | freeExpressions), Is.EquivalentTo(myAndFreeCollection));
        }

        [TestCase(ExpressionNumber.And, ExpressionNumber.And)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr | ExpressionNumber.Relational1 | ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToExclusiveOrExpression(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.exclusiveOrExpression.Term.Add(this.relationalExpression1);
            this.exclusiveOrExpression.Term.Add(this.relationalExpression2);

            var descendantCollection = this.testCaseList[expressionNumber].GetMeAndMyDescendantExpressions();
            var myAndFreeCollection = this.testCaseList[expressionNumber].GetMyAndFreeExpressions();

            var myExpressions = expectedExpressionNumbers & ~expressionNumber;
            var freeExpressions = AllRelationaExpressionNumbers & ~(ExpressionNumber.Relational1 | ExpressionNumber.Relational2);

            Assert.That(this.GetBooleanExpressionList(expectedExpressionNumbers), Is.EquivalentTo(descendantCollection));
            Assert.That(this.GetBooleanExpressionList(myExpressions | freeExpressions), Is.EquivalentTo(myAndFreeCollection));
        }

        [TestCase(ExpressionNumber.And, ExpressionNumber.And)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not | ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionIsAddedToNotExpression(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.notExpression.Term = this.relationalExpression1;

            var descendantCollection = this.testCaseList[expressionNumber].GetMeAndMyDescendantExpressions();
            var myAndFreeCollection = this.testCaseList[expressionNumber].GetMyAndFreeExpressions();

            var myExpressions = expectedExpressionNumbers & ~expressionNumber;
            var freeExpressions = AllRelationaExpressionNumbers & ~(ExpressionNumber.Relational1);

            Assert.That(this.GetBooleanExpressionList(expectedExpressionNumbers), Is.EquivalentTo(descendantCollection));
            Assert.That(this.GetBooleanExpressionList(myExpressions | freeExpressions), Is.EquivalentTo(myAndFreeCollection));
        }

        [TestCase(ExpressionNumber.And, ExpressionNumber.And | ExpressionNumber.Relational1 | ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or | ExpressionNumber.Relational3 | ExpressionNumber.Relational4)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr | ExpressionNumber.And | ExpressionNumber.Or | ExpressionNumber.Relational1 | ExpressionNumber.Relational2 | ExpressionNumber.Relational3 | ExpressionNumber.Relational4)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not | ExpressionNumber.ExclusiveOr | ExpressionNumber.And | ExpressionNumber.Or | ExpressionNumber.Relational1 | ExpressionNumber.Relational2 | ExpressionNumber.Relational3 | ExpressionNumber.Relational4)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatDescendantCollectionChecksAreOKWhenRelationalExpressionsAreNested(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            this.orExpression.Term.Add(this.relationalExpression3);
            this.orExpression.Term.Add(this.relationalExpression4);

            this.exclusiveOrExpression.Term.AddRange(new BooleanExpression[] { this.andExpression, this.orExpression });

            this.notExpression.Term = this.exclusiveOrExpression;

            var descendantCollection = this.testCaseList[expressionNumber].GetMeAndMyDescendantExpressions();

            Assert.That(this.GetBooleanExpressionList(expectedExpressionNumbers), Is.EquivalentTo(descendantCollection));
        }

        [TestCase(ExpressionNumber.And, ExpressionNumber.And | ExpressionNumber.Relational1 | ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Or, ExpressionNumber.Or | ExpressionNumber.Relational3 | ExpressionNumber.Relational4)]
        [TestCase(ExpressionNumber.ExclusiveOr, ExpressionNumber.ExclusiveOr | ExpressionNumber.And | ExpressionNumber.Or)]
        [TestCase(ExpressionNumber.Not, ExpressionNumber.Not | ExpressionNumber.ExclusiveOr)]
        [TestCase(ExpressionNumber.Relational1, ExpressionNumber.Relational1)]
        [TestCase(ExpressionNumber.Relational2, ExpressionNumber.Relational2)]
        [TestCase(ExpressionNumber.Relational3, ExpressionNumber.Relational3)]
        [TestCase(ExpressionNumber.Relational4, ExpressionNumber.Relational4)]
        public void VerifyThatMyAndFreeCollectionChecksAreOKWhenRelationalExpressionsAreNested(ExpressionNumber expressionNumber, ExpressionNumber expectedExpressionNumbers)
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            this.orExpression.Term.Add(this.relationalExpression3);
            this.orExpression.Term.Add(this.relationalExpression4);

            this.exclusiveOrExpression.Term.AddRange(new BooleanExpression[] { this.andExpression, this.orExpression });

            this.notExpression.Term = this.exclusiveOrExpression;

            var myAndFreeCollection = this.testCaseList[expressionNumber].GetMyAndFreeExpressions();
            var myExpressions = expectedExpressionNumbers & ~expressionNumber;

            Assert.That(this.GetBooleanExpressionList(myExpressions), Is.EquivalentTo(myAndFreeCollection));
        }
    }
}
