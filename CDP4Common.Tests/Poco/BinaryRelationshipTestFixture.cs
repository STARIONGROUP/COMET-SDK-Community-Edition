// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

    [TestFixture]
    internal class BinaryRelationshipTestFixture
    {
        private SiteDirectory sitedir;
        private SiteReferenceDataLibrary srdl;
        private Category cat1;
        private Category cat2;
        private Category cat3;
        private BinaryRelationshipRule rule1;
        private BinaryRelationshipRule rule11;
        private BinaryRelationshipRule rule2;
        private BinaryRelationshipRule rule3;

        private EngineeringModelSetup modelSetup;
        private ModelReferenceDataLibrary mrdl;
        private IterationSetup iterationSetup;
        private EngineeringModel model;
        private Iteration iteration;

        [SetUp]
        public void Setup()
        {
            this.sitedir = new SiteDirectory();
            this.srdl = new SiteReferenceDataLibrary();
            sitedir.SiteReferenceDataLibrary.Add(srdl);

            this.cat1 = new Category();
            this.cat2 = new Category();
            this.rule1 = new BinaryRelationshipRule { RelationshipCategory = cat1 };
            this.rule2 = new BinaryRelationshipRule { RelationshipCategory = cat2 };

            srdl.DefinedCategory.Add(cat1);
            srdl.DefinedCategory.Add(cat2);
            srdl.Rule.Add(rule1);
            srdl.Rule.Add(rule2);

            this.modelSetup = new EngineeringModelSetup();
            this.mrdl = new ModelReferenceDataLibrary { RequiredRdl = srdl };
            modelSetup.RequiredRdl.Add(mrdl);

            this.cat3 = new Category();
            this.rule3 = new BinaryRelationshipRule { RelationshipCategory = cat3 };
            this.rule11 = new BinaryRelationshipRule { RelationshipCategory = cat1 };
            mrdl.DefinedCategory.Add(cat3);
            mrdl.Rule.Add(rule3);
            mrdl.Rule.Add(rule11);

            this.iterationSetup = new IterationSetup();
            modelSetup.IterationSetup.Add(iterationSetup);

            this.model = new EngineeringModel { EngineeringModelSetup = modelSetup };
            this.iteration = new Iteration { IterationSetup = iterationSetup };
            model.Iteration.Add(iteration);
        }

        [Test]
        public void VerifyThatAppliedRulesGetterWorks()
        {
            var relationship = new BinaryRelationship();
            iteration.Relationship.Add(relationship);

            // test
            Assert.IsEmpty(relationship.QueryAppliedBinaryRelationshipRules());

            relationship.Category.Add(cat3);
            Assert.IsTrue(relationship.QueryAppliedBinaryRelationshipRules().Contains(rule3));

            relationship.Category.Add(cat1);
            Assert.IsTrue(relationship.QueryAppliedBinaryRelationshipRules().Contains(rule3));
            Assert.IsTrue(relationship.QueryAppliedBinaryRelationshipRules().Contains(rule1));
            Assert.IsTrue(relationship.QueryAppliedBinaryRelationshipRules().Contains(rule11));

            relationship.Category = null;
            Assert.IsEmpty(relationship.QueryAppliedBinaryRelationshipRules());
        }
    }
}