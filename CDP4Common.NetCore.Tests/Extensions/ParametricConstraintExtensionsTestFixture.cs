// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParametricConstraintExtensionsTestFixture.cs" company="RHEA System S.A.">
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
    using System.Reflection;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Extensions;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    using NUnit.Framework;

    /// <summary>
    /// Suite of tests for the <see cref="ParametricConstraintExtensions"/> class
    /// </summary>
    [TestFixture]
    public class ParametricConstraintExtensionsTestFixture
    {
        private AndExpression andExpression;

        private OrExpression orExpression;

        private ExclusiveOrExpression exclusiveOrExpression;

        private NotExpression notExpression;

        private RelationalExpression relationalExpression1;

        private RelationalExpression relationalExpression2;

        private RelationalExpression relationalExpression3;

        private RelationalExpression relationalExpression4;

        private RelationalExpression relationalExpression5;

        private ParametricConstraint parametricConstraint;

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
            this.relationalExpression5 = new RelationalExpression();
            this.parametricConstraint = new ParametricConstraint();

            SetClassKind(this.andExpression, ClassKind.AndExpression);
            SetClassKind(this.orExpression, ClassKind.OrExpression);
            SetClassKind(this.exclusiveOrExpression, ClassKind.ExclusiveOrExpression);
            SetClassKind(this.notExpression, ClassKind.NotExpression);
            SetClassKind(this.parametricConstraint, ClassKind.ParametricConstraint);
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

            this.parametricConstraint.Expression.Add(this.notExpression);
            this.parametricConstraint.Expression.Add(this.relationalExpression5);

            this.FillRelationalExpression(this.relationalExpression1, "length", 180);
            this.FillRelationalExpression(this.relationalExpression2, "width", 40);
            this.FillRelationalExpression(this.relationalExpression3, "mass", 100);
            this.FillRelationalExpression(this.relationalExpression4, "accel", "pretty_fast");
            this.FillRelationalExpression(this.relationalExpression5, "comment", "lx_is_awesome");

            Assert.AreEqual("NOT (((mass = 100) OR (accel = pretty_fast)) XOR ((length = 180) AND (width = 40))) AND (comment = lx_is_awesome)", this.parametricConstraint.ToExpressionString());
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
