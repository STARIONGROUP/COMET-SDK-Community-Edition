#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CopyPermissionHelperTestFixture.cs" company="RHEA System S.A.">
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

namespace CDP4Dal.Tests.Permission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Dal.Permission;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class CopyPermissionHelperTestFixture
    {
        private Mock<ISession> session;
        private Mock<IPermissionService> permissionService; 
        private Uri uri = new Uri("http://test.com");
        private Assembler assembler;

        private SiteDirectory siteDir;
        private EngineeringModelSetup modelsetup1;
        private EngineeringModelSetup modelsetup2;
        private IterationSetup iterationSetup1;
        private IterationSetup iterationSetup2;
        private Person person;
        private Participant participant1;
        private Participant participant2;
        private DomainOfExpertise domain1;
        private DomainOfExpertise domain2;
        private DomainOfExpertise domain3;

        private SiteReferenceDataLibrary srdl1;
        private SiteReferenceDataLibrary srdl2;
        private ModelReferenceDataLibrary mrdl1;
        private ModelReferenceDataLibrary mrdl2;

        private Category category;
        private BooleanParameterType booleanPt;

        private EngineeringModel model1;
        private Iteration iteration1;
        private EngineeringModel model2;
        private Iteration iteration2;

        private ElementDefinition def1;
        private ElementDefinition def2;
        private ElementUsage usage;
        private Parameter parameter1;
        private ParameterOverride override1;
        private ParameterSubscription subscription1;

        [SetUp]
        public void Setup()
        {
            this.BuildSiteDirData();
            this.BuildModelData();
        }

        private void BuildSiteDirData()
        {
            this.session = new Mock<ISession>();
            this.permissionService = new Mock<IPermissionService>();
            this.session.Setup(x => x.PermissionService).Returns(this.permissionService.Object);

            this.assembler = new Assembler(this.uri);
            this.session.Setup(x => x.Assembler).Returns(this.assembler);

            this.siteDir = new SiteDirectory(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.modelsetup1 = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.modelsetup2 = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iterationSetup1 = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iterationSetup2 = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.person = new Person(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participant1 = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participant2 = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain1 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain2 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain3 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.srdl1 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.srdl2 = new SiteReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.mrdl1 = new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.mrdl2 = new ModelReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.category = new Category(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.booleanPt = new BooleanParameterType(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.srdl2.RequiredRdl = this.srdl1;
            this.mrdl1.RequiredRdl = this.srdl2;
            this.mrdl2.RequiredRdl = this.srdl1;

            this.participant1.Person = this.person;
            this.participant2.Person = this.person;

            this.modelsetup1.ActiveDomain.Add(this.domain1);
            this.modelsetup1.ActiveDomain.Add(this.domain2);
            this.modelsetup1.ActiveDomain.Add(this.domain3);
            this.modelsetup2.ActiveDomain.Add(this.domain1);
            this.modelsetup2.ActiveDomain.Add(this.domain2);

            this.srdl1.ParameterType.Add(this.booleanPt);
            this.srdl2.DefinedCategory.Add(this.category);

            this.siteDir.Model.Add(this.modelsetup1);
            this.siteDir.Model.Add(this.modelsetup2);
            this.siteDir.Person.Add(this.person);
            this.siteDir.Domain.Add(this.domain1);
            this.siteDir.Domain.Add(this.domain2);
            this.siteDir.Domain.Add(this.domain3);
            this.siteDir.SiteReferenceDataLibrary.Add(this.srdl1);
            this.siteDir.SiteReferenceDataLibrary.Add(this.srdl2);
            this.modelsetup1.IterationSetup.Add(this.iterationSetup1);
            this.modelsetup2.IterationSetup.Add(this.iterationSetup2);
            this.modelsetup1.Participant.Add(this.participant1);
            this.modelsetup2.Participant.Add(this.participant2);
            this.modelsetup1.RequiredRdl.Add(this.mrdl1);
            this.modelsetup2.RequiredRdl.Add(this.mrdl2);

            this.session.Setup(x => x.ActivePerson).Returns(this.person);
            this.session.Setup(x => x.ActivePersonParticipants)
                .Returns(new List<Participant> { this.participant1, this.participant2 });
        }

        private void BuildModelData()
        {
            this.model1 = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.model2 = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iteration1 = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iteration2 = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.def1 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.def2 = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.usage = new ElementUsage(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.parameter1 = new Parameter(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.override1 = new ParameterOverride(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.subscription1 = new ParameterSubscription(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.model1.EngineeringModelSetup = this.modelsetup1;
            this.model2.EngineeringModelSetup = this.modelsetup2;

            this.iteration1.IterationSetup = this.iterationSetup1;
            this.iteration2.IterationSetup = this.iterationSetup2;

            this.def1.Owner = this.domain1;
            this.def2.Owner = this.domain2;
            this.usage.Owner = this.domain1;
            this.usage.ElementDefinition = this.def2;
            this.parameter1.Owner = this.domain2;
            this.parameter1.ParameterType = this.booleanPt;
            this.parameter1.AllowDifferentOwnerOfOverride = true;
            this.override1.Parameter = this.parameter1;
            this.override1.Owner = this.domain2;
            this.subscription1.Owner = this.domain1;

            this.model1.Iteration.Add(this.iteration1);
            this.iteration1.Element.Add(this.def1);
            this.iteration1.Element.Add(this.def2);
            this.def1.ContainedElement.Add(this.usage);
            this.def2.Parameter.Add(this.parameter1);
            this.usage.ParameterOverride.Add(this.override1);
            this.override1.ParameterSubscription.Add(this.subscription1);

            this.model2.Iteration.Add(this.iteration2);
        }

        [Test]
        public void VerifyThatCanCopyAll()
        {
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> {{ this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) }} );

            var copy = this.def1.Clone(false);
            var target = this.iteration2.Clone(false);

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var canCopyRes = helper.ComputeCopyPermission(copy, target);

            Assert.AreEqual(0, canCopyRes.ErrorList.Count);
            Assert.AreEqual(6, canCopyRes.CopyableThings.Count());
        }

        [Test]
        public void VerifyThatComputationWorksIfPermissionDenied()
        {
            this.permissionService.Setup(x => x.CanWrite(It.Is<ClassKind>(cls => 
                cls == ClassKind.ElementDefinition || 
                cls == ClassKind.ElementUsage || 
                cls == ClassKind.Parameter || 
                cls == ClassKind.ParameterSubscription), It.IsAny<Thing>())).Returns(true);
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> { { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) } });
            // permission denied for Override

            var copy = this.def1.Clone(false);
            var target = this.iteration2.Clone(false);

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var canCopyRes = helper.ComputeCopyPermission(copy, target);

            Assert.AreEqual(1, canCopyRes.ErrorList.Count);
            Assert.AreEqual(4, canCopyRes.CopyableThings.Count());
        }

        [Test]
        public void VerifyThatComputationWorksIfMissingRdls()
        {
            this.def2.Category.Add(this.category);
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> { { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) } });

            var copy = this.def1.Clone(false);
            var target = this.iteration2.Clone(false);

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var canCopyRes = helper.ComputeCopyPermission(copy, target);

            // element def for usage cant be copied - missing rdl
            // usage cant be copied as element def cannot
            Assert.AreEqual(2, canCopyRes.ErrorList.Count);
            Assert.AreEqual(1, canCopyRes.CopyableThings.Count());
        }

        [Test]
        public void VerifyThatComputationWorksWithNonActiveDomain()
        {
            this.subscription1.Owner = this.domain3;
            this.permissionService.Setup(x => x.CanWrite(It.IsAny<ClassKind>(), It.IsAny<Thing>())).Returns(true);
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> { { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) } });

            var copy = this.def1.Clone(false);
            var target = this.iteration2.Clone(false);

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var canCopyRes = helper.ComputeCopyPermission(copy, target);

            // subscription cant be copied
            Assert.AreEqual(1, canCopyRes.ErrorList.Count);
            Assert.AreEqual(5, canCopyRes.CopyableThings.Count());
        }

        [Test]
        public void VerifyException1()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                var helper = new CopyPermissionHelper(null, false);
            });
        }

        [Test]
        public void VerifyException2()
        {
            var helper = new CopyPermissionHelper(this.session.Object, false);
            var target = this.iteration2.Clone(false);
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                var res = helper.ComputeCopyPermission(null, target);
            });
        }

        [Test]
        public void VerifyException3()
        {
            var helper = new CopyPermissionHelper(this.session.Object, false);
            var copy = this.def1.Clone(false);
            var target = this.iteration2.Clone(false);
            
            Assert.Throws<ArgumentNullException>(() =>
            {
                var res = helper.ComputeCopyPermission(copy, null);
            });
        }

        [Test]
        public void VerifyException4()
        {
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> { { this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) } });

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var copy = this.def1.Clone(false);
            var target = this.model2.Clone(false);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                var res = helper.ComputeCopyPermission(copy, target);
            });
        }

        [Test]
        //[ExpectedException(typeof(InvalidOperationException))]
        public void VerifyException5()
        {
            this.session.Setup(x => x.OpenIterations)
                .Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>> {{ this.iteration2, new Tuple<DomainOfExpertise, Participant>(this.domain1, null) }} );

            var helper = new CopyPermissionHelper(this.session.Object, false);
            var copy = this.def1.Clone(false);
            var target = this.iteration1.Clone(false);
            
            Assert.Throws<InvalidOperationException>(() =>
            {
                var res = helper.ComputeCopyPermission(copy, target);
            });
        }
    }
}