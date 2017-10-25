// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BinaryRelationshipTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
            Assert.IsEmpty(relationship.AppliedBinaryRelationshipRules);

            relationship.Category.Add(cat3);
            Assert.IsTrue(relationship.AppliedBinaryRelationshipRules.Contains(rule3));

            relationship.Category.Add(cat1);
            Assert.IsTrue(relationship.AppliedBinaryRelationshipRules.Contains(rule3));
            Assert.IsTrue(relationship.AppliedBinaryRelationshipRules.Contains(rule1));
            Assert.IsTrue(relationship.AppliedBinaryRelationshipRules.Contains(rule11));

            relationship.Category = null;
            Assert.IsEmpty(relationship.AppliedBinaryRelationshipRules);
        }
    }
}