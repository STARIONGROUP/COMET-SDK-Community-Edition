// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BooleanExpressionExtensionsTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.NetCore.Tests.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="BooleanExpressionExtensions"/> class
    /// </summary>
    [TestFixture]
    public class BooleanExpressionExtensionsTestFixture
    {
        private IList<BooleanExpression> booleanExpressions;

        /// <summary>
        /// Because we are using TestCase as a source, a static object must be used to execute tests.
        /// In the Testcases, the <see cref="ExpressionNumber"/> enum is used and runtime the matching <see cref="BooleanExpression"/>
        /// can be found in this <see cref="Dictionary{ExpressionNumber,BooleanExpression}"/> 
        /// </summary>
        private IDictionary<ExpressionNumber, BooleanExpression> testCaseList;

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

            this.booleanExpressions = new List<BooleanExpression>
            {
                this.andExpression,
                this.orExpression,
                this.exclusiveOrExpression,
                this.notExpression,
                this.relationalExpression1,
                this.relationalExpression2,
                this.relationalExpression3,
                this.relationalExpression4
            };

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

            SetClassKind(this.andExpression, ClassKind.AndExpression);
            SetClassKind(this.orExpression, ClassKind.OrExpression);
            SetClassKind(this.exclusiveOrExpression, ClassKind.ExclusiveOrExpression);
            SetClassKind(this.notExpression, ClassKind.NotExpression);
        }

        [Test]
        [TestCaseSource(nameof(AllTestCaseSource))]
        public void VerifyThatAllBooleanExpressionsAreReturned(ExpressionNumber expressionNumber)
        {
            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
        }

        private static IEnumerable<ExpressionNumber> AllTestCaseSource()
        {
            foreach (var expressionNumber in Enum.GetValues(typeof(ExpressionNumber)))
            {
                yield return (ExpressionNumber) expressionNumber;
            }
        }

        [TestCase(ExpressionNumber.And, true)]
        [TestCase(ExpressionNumber.Or, true)]
        [TestCase(ExpressionNumber.ExclusiveOr, true)]
        [TestCase(ExpressionNumber.Not, true)]
        [TestCase(ExpressionNumber.Relational1, false)]
        [TestCase(ExpressionNumber.Relational2, false)]
        [TestCase(ExpressionNumber.Relational3, true)]
        [TestCase(ExpressionNumber.Relational4, true)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToAndExpression(ExpressionNumber expressionNumber, bool shouldContain)
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            if (shouldContain)
            {
                CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
            }
            else
            {
                CollectionAssert.DoesNotContain(toplevelCollection, this.testCaseList[expressionNumber]);
            }
        }

        [TestCase(ExpressionNumber.And, true)]
        [TestCase(ExpressionNumber.Or, true)]
        [TestCase(ExpressionNumber.ExclusiveOr, true)]
        [TestCase(ExpressionNumber.Not, true)]
        [TestCase(ExpressionNumber.Relational1, false)]
        [TestCase(ExpressionNumber.Relational2, false)]
        [TestCase(ExpressionNumber.Relational3, true)]
        [TestCase(ExpressionNumber.Relational4, true)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToOrExpression(ExpressionNumber expressionNumber, bool shouldContain)
        {
            this.orExpression.Term.Add(this.relationalExpression1);
            this.orExpression.Term.Add(this.relationalExpression2);

            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            if (shouldContain)
            {
                CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
            }
            else
            {
                CollectionAssert.DoesNotContain(toplevelCollection, this.testCaseList[expressionNumber]);
            }
        }

        [TestCase(ExpressionNumber.And, true)]
        [TestCase(ExpressionNumber.Or, true)]
        [TestCase(ExpressionNumber.ExclusiveOr, true)]
        [TestCase(ExpressionNumber.Not, true)]
        [TestCase(ExpressionNumber.Relational1, false)]
        [TestCase(ExpressionNumber.Relational2, false)]
        [TestCase(ExpressionNumber.Relational3, true)]
        [TestCase(ExpressionNumber.Relational4, true)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreAddedToExclusiveOrExpression(ExpressionNumber expressionNumber, bool shouldContain)
        {
            this.exclusiveOrExpression.Term.Add(this.relationalExpression1);
            this.exclusiveOrExpression.Term.Add(this.relationalExpression2);

            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            if (shouldContain)
            {
                CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
            }
            else
            {
                CollectionAssert.DoesNotContain(toplevelCollection, this.testCaseList[expressionNumber]);
            }
        }

        [TestCase(ExpressionNumber.And, true)]
        [TestCase(ExpressionNumber.Or, true)]
        [TestCase(ExpressionNumber.ExclusiveOr, true)]
        [TestCase(ExpressionNumber.Not, true)]
        [TestCase(ExpressionNumber.Relational1, false)]
        [TestCase(ExpressionNumber.Relational2, true)]
        [TestCase(ExpressionNumber.Relational3, true)]
        [TestCase(ExpressionNumber.Relational4, true)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionIsAddedToNotExpression(ExpressionNumber expressionNumber, bool shouldContain)
        {
            this.notExpression.Term = this.relationalExpression1;

            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            if (shouldContain)
            {
                CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
            }
            else
            {
                CollectionAssert.DoesNotContain(toplevelCollection, this.testCaseList[expressionNumber]);
            }
        }

        [TestCase(ExpressionNumber.And, false)]
        [TestCase(ExpressionNumber.Or, false)]
        [TestCase(ExpressionNumber.ExclusiveOr, false)]
        [TestCase(ExpressionNumber.Not, true)]
        [TestCase(ExpressionNumber.Relational1, false)]
        [TestCase(ExpressionNumber.Relational2, false)]
        [TestCase(ExpressionNumber.Relational3, false)]
        [TestCase(ExpressionNumber.Relational4, false)]
        public void VerifyThatAllCollectionChecksAreOKWhenRelationalExpressionsAreNested(ExpressionNumber expressionNumber, bool shouldContain)
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            this.orExpression.Term.Add(this.relationalExpression3);
            this.orExpression.Term.Add(this.relationalExpression4);

            this.exclusiveOrExpression.Term.AddRange(new BooleanExpression[] { this.andExpression, this.orExpression });

            this.notExpression.Term = this.exclusiveOrExpression;

            var toplevelCollection = this.booleanExpressions.GetTopLevelExpressions();

            if (shouldContain)
            {
                CollectionAssert.Contains(toplevelCollection, this.testCaseList[expressionNumber]);
            }
            else
            {
                CollectionAssert.DoesNotContain(toplevelCollection, this.testCaseList[expressionNumber]);
            }
        }

        [Test]
        public void VerifyExpressionStringsAtThingLevel()
        {
            this.andExpression.Term.Add(this.relationalExpression1);
            this.andExpression.Term.Add(this.relationalExpression2);

            this.orExpression.Term.Add(this.relationalExpression3);
            this.orExpression.Term.Add(this.relationalExpression4);

            this.exclusiveOrExpression.Term.Add(this.orExpression);
            this.exclusiveOrExpression.Term.Add(this.andExpression);

            this.notExpression.Term = this.exclusiveOrExpression;

            this.FillRelationalExpression(this.relationalExpression1, "length", 180);
            this.FillRelationalExpression(this.relationalExpression2, "width", 40);
            this.FillRelationalExpression(this.relationalExpression3, "mass", 100);
            this.FillRelationalExpression(this.relationalExpression4, "accel", "pretty_fast");

            Assert.AreEqual("(length = 180) AND (width = 40)", this.andExpression.ToExpressionString());
            Assert.AreEqual("(mass = 100) OR (accel = pretty_fast)", this.orExpression.ToExpressionString());
            Assert.AreEqual("((mass = 100) OR (accel = pretty_fast)) XOR ((length = 180) AND (width = 40))", this.exclusiveOrExpression.ToExpressionString());
            Assert.AreEqual("NOT (((mass = 100) OR (accel = pretty_fast)) XOR ((length = 180) AND (width = 40)))", this.notExpression.ToExpressionString());
        }

        /// <summary>
        /// Fills properties on a <see cref="RelationalExpression"/>
        /// </summary>
        /// <param name="relationalExpression">The <see cref="RelationalExpression"/></param>
        /// <param name="parameterShortName">The <see cref="Parameter"/>'s ShortName'</param>
        /// <param name="value">The <see cref="Parameter"/>'s Value</param>
        private void FillRelationalExpression(RelationalExpression relationalExpression, string parameterShortName, object value)
        {
            relationalExpression.ParameterType = new SimpleQuantityKind { ShortName = parameterShortName };

            SetClassKind(relationalExpression, ClassKind.RelationalExpression);

            relationalExpression.RelationalOperator = RelationalOperatorKind.EQ;
            relationalExpression.Value = new ValueArray<string>(new[] { value.ToString() });
        }

        /// <summary>
        /// Sets the readonly ClassKind property of an object using reflection 
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of the object</typeparam>
        /// <param name="obj">The object</param>
        /// <param name="classKind">The <see cref="ClassKind"/></param>
        private static void SetClassKind<T>(T obj, ClassKind classKind)
        {
            var field = typeof(RelationalExpression).GetField("<ClassKind>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);
            field?.SetValue(obj, classKind);
        }
    }
}
