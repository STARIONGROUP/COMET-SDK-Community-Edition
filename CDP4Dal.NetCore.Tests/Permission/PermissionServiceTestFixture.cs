// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PermissionServiceTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
//
//    This file is part of CDP4-COMET SDK Community Edition
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests.Permission
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Exceptions;
    using CDP4Common.SiteDirectoryData;

    using CDP4Dal.DAL;
    using CDP4Dal.Permission;

    using Moq;

    using NUnit.Framework;

    [TestFixture]
    public class PermissionServiceTestFixture
    {
        private Mock<ISession> session;
        private Assembler assembler;
        private SiteDirectory sitedir;
        private EngineeringModelSetup modelsetup;
        private IterationSetup iterationSetup;
        private Person person;
        private Person person2;
        private DomainOfExpertise domain1;
        private DomainOfExpertise domain2;
        private PersonRole personRole;
        private Participant participant;
        private ParticipantRole participantRole;
        private EngineeringModel model;
        private Iteration iteration;
        private Uri uri = new Uri("http://www.stariongroup.eu");
        private Definition definition;
        private SiteReferenceDataLibrary srdl;
        private BooleanParameterType booleanpt;
        private ElementDefinition elementDef;
        private BinaryRelationship relationship;
        private Parameter parameter;
        private ParameterValueSet valueset;
        private Requirement requirement;
        private RequirementsSpecification requirementsSpecification;

        private PermissionService permissionService;
        private CommonFileStore commonFileStore;
        private File file;

        [SetUp]
        public void Setup()
        {
            this.assembler = new Assembler(this.uri, new CDPMessageBus());
            this.session = new Mock<ISession>();
            this.session.Setup(x => x.Assembler).Returns(this.assembler);
            var dal = new Mock<IDal>();
            dal.Setup(x => x.IsReadOnly).Returns(false);
            this.session.Setup(x => x.Dal).Returns(dal.Object);

            this.sitedir = new SiteDirectory(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.modelsetup = new EngineeringModelSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.iterationSetup = new IterationSetup(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.person = new Person(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain1 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.domain2 = new DomainOfExpertise(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.personRole = new PersonRole(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participant = new Participant(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.participantRole = new ParticipantRole(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.model = new EngineeringModel(Guid.NewGuid(), this.assembler.Cache, this.uri) { EngineeringModelSetup = this.modelsetup };
            this.iteration = new Iteration(Guid.NewGuid(), this.assembler.Cache, this.uri) { IterationSetup = this.iterationSetup };
            this.definition = new Definition(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.srdl = new SiteReferenceDataLibrary(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.booleanpt = new BooleanParameterType(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.person2 = new Person(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.elementDef = new ElementDefinition(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.relationship = new BinaryRelationship(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.parameter = new Parameter(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.valueset = new ParameterValueSet(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.requirementsSpecification = new RequirementsSpecification(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.requirement = new Requirement(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.commonFileStore = new CommonFileStore(Guid.NewGuid(), this.assembler.Cache, this.uri);
            this.file = new File(Guid.NewGuid(), this.assembler.Cache, this.uri);

            this.sitedir.Model.Add(this.modelsetup);
            this.sitedir.Person.Add(this.person);
            this.sitedir.Person.Add(this.person2);
            this.sitedir.PersonRole.Add(this.personRole);
            this.sitedir.Domain.Add(this.domain1);
            this.sitedir.Domain.Add(this.domain2);
            this.modelsetup.IterationSetup.Add(this.iterationSetup);
            this.modelsetup.Participant.Add(this.participant);
            this.sitedir.ParticipantRole.Add(this.participantRole);
            this.model.Iteration.Add(this.iteration);
            this.person.Role = this.personRole;
            this.participant.Person = this.person;
            this.participant.Role = this.participantRole;
            this.participant.Domain.Add(this.domain1);
            this.modelsetup.Definition.Add(this.definition);
            this.sitedir.SiteReferenceDataLibrary.Add(this.srdl);
            this.srdl.ParameterType.Add(this.booleanpt);
            this.iteration.Element.Add(this.elementDef);
            this.iteration.Relationship.Add(this.relationship);
            this.elementDef.Parameter.Add(this.parameter);
            this.parameter.ValueSet.Add(this.valueset);

            this.modelsetup.EngineeringModelIid = this.model.Iid;
            this.iterationSetup.IterationIid = this.iteration.Iid;
            this.elementDef.Owner = this.domain1;
            this.relationship.Owner = this.domain1;
            this.parameter.Owner = this.domain1;
            this.requirementsSpecification.Requirement.Add(this.requirement);
            this.iteration.RequirementsSpecification.Add(this.requirementsSpecification);
            this.model.CommonFileStore.Add(this.commonFileStore);
            this.file.Owner = this.domain1;
            this.commonFileStore.File.Add(this.file);

            this.session.Setup(x => x.ActivePerson).Returns(this.person);
            this.session.Setup(x => x.Assembler).Returns(this.assembler);

            this.session.Setup(x => x.OpenIterations).Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
            {
                { this.iteration, new Tuple<DomainOfExpertise, Participant>(this.domain1, this.participant) }
            });

            this.permissionService = new PermissionService(this.session.Object);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void TestCanWriteFalseWithDefaultPermission()
        {
            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.modelsetup), Is.False);
            Assert.That(this.permissionService.CanWrite(this.iterationSetup), Is.False);
            Assert.That(this.permissionService.CanWrite(this.person), Is.False);
            Assert.That(this.permissionService.CanWrite(this.participant), Is.False);
            Assert.That(this.permissionService.CanWrite(ClassKind.Person, this.sitedir), Is.False);

            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanWrite(this.iteration), Is.False);

            Assert.That(this.permissionService.CanRead(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanRead(this.modelsetup), Is.False);
            Assert.That(this.permissionService.CanRead(this.iterationSetup), Is.False);
            Assert.That(this.permissionService.CanRead(this.person), Is.False);
            Assert.That(this.permissionService.CanRead(this.participant), Is.False);

            Assert.That(this.permissionService.CanRead(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.iteration), Is.False);
            Assert.That(this.permissionService.CanRead(this.file), Is.False);
        }

        [Test]
        public void VerifyThatPersonPermissionReadModifyWorks()
        {
            var sdPermission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.SiteDirectory);
            sdPermission.AccessRight = PersonAccessRightKind.READ;

            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.modelsetup), Is.False);
            Assert.That(this.permissionService.CanWrite(this.iterationSetup), Is.False);
            Assert.That(this.permissionService.CanWrite(this.person), Is.False);
            Assert.That(this.permissionService.CanWrite(this.definition), Is.False);

            Assert.That(this.permissionService.CanRead(this.sitedir), Is.True);
            Assert.That(this.permissionService.CanRead(this.person), Is.False);
            Assert.That(this.permissionService.CanRead(this.definition), Is.False);

            sdPermission.AccessRight = PersonAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.True);
            Assert.That(this.permissionService.CanWrite(this.modelsetup), Is.False);
            Assert.That(this.permissionService.CanRead(this.sitedir), Is.True);
            Assert.That(this.permissionService.CanRead(this.person), Is.False);
            Assert.That(this.permissionService.CanWrite(ClassKind.EngineeringModelSetup, this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.definition), Is.False);
            Assert.That(this.permissionService.CanRead(this.definition), Is.False);
        }

        [Test]
        public void VerifyThatSameAsCotainerPermissionWorks()
        {
            var sdPermission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.EngineeringModelSetup);
            sdPermission.AccessRight = PersonAccessRightKind.READ;

            Assert.That(this.permissionService.CanRead(this.modelsetup), Is.True);
            Assert.That(this.permissionService.CanRead(this.definition), Is.True);
            Assert.That(this.permissionService.CanWrite(this.definition), Is.False);

            sdPermission.AccessRight = PersonAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanWrite(this.definition), Is.True);
            Assert.That(this.permissionService.CanWrite(this.definition), Is.True);
        }

        [Test]
        public void VerifyThatSameAsSuperclassPermissionWorks()
        {
            Assert.That(this.permissionService.CanRead(this.booleanpt), Is.False);
            Assert.That(this.permissionService.CanWrite(this.booleanpt), Is.False);

            var permission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.SiteReferenceDataLibrary);
            permission.AccessRight = PersonAccessRightKind.READ;
            Assert.That(this.permissionService.CanRead(this.booleanpt), Is.True);
            Assert.That(this.permissionService.CanWrite(this.booleanpt), Is.False);
            Assert.That(this.permissionService.CanWrite(ClassKind.BooleanParameterType, this.srdl), Is.False);

            permission.AccessRight = PersonAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanRead(this.booleanpt), Is.True);
            Assert.That(this.permissionService.CanWrite(this.booleanpt), Is.True);
            Assert.That(this.permissionService.CanWrite(ClassKind.BooleanParameterType, this.srdl), Is.True);
        }

        [Test]
        public void VerifyThatModifyIfOwnPersonPermissionWork()
        {
            Assert.That(this.permissionService.CanRead(this.person), Is.False);
            Assert.That(this.permissionService.CanWrite(this.person), Is.False);
            Assert.That(this.permissionService.CanRead(this.person2), Is.False);
            Assert.That(this.permissionService.CanWrite(this.person2), Is.False);

            var permission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.Person);
            permission.AccessRight = PersonAccessRightKind.MODIFY_OWN_PERSON;

            Assert.That(this.permissionService.CanRead(this.person), Is.True);
            Assert.That(this.permissionService.CanWrite(this.person), Is.True);

            Assert.That(this.permissionService.CanRead(this.person2), Is.False);
            Assert.That(this.permissionService.CanWrite(this.person2), Is.False);

            var sdpermission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.SiteDirectory);
            sdpermission.AccessRight = PersonAccessRightKind.MODIFY_OWN_PERSON;
            Assert.That(this.permissionService.CanRead(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.False);

            Assert.That(this.permissionService.CanRead(this.person), Is.True);
            Assert.That(this.permissionService.CanWrite(this.person), Is.True);
        }

        [Test]
        public void VerifyThatReadWriteIfParticipantWorks()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });

            var sdpermission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.SiteDirectory);
            sdpermission.AccessRight = PersonAccessRightKind.READ_IF_PARTICIPANT;

            var permission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.EngineeringModelSetup);
            permission.AccessRight = PersonAccessRightKind.READ_IF_PARTICIPANT;

            Assert.That(this.permissionService.CanRead(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.False);

            Assert.That(this.permissionService.CanRead(this.modelsetup), Is.True);
            Assert.That(this.permissionService.CanWrite(this.modelsetup), Is.False);

            sdpermission.AccessRight = PersonAccessRightKind.MODIFY_IF_PARTICIPANT;
            permission.AccessRight = PersonAccessRightKind.MODIFY_IF_PARTICIPANT;
            Assert.That(this.permissionService.CanRead(this.sitedir), Is.False);
            Assert.That(this.permissionService.CanWrite(this.sitedir), Is.False);

            Assert.That(this.permissionService.CanRead(this.modelsetup), Is.True);
            Assert.That(this.permissionService.CanWrite(this.modelsetup), Is.True);
        }

        [Test]
        public void VerifyReadWriteParticipantPermission()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.model), Is.False);

            var permission = this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.EngineeringModel);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanRead(this.model), Is.True);
            Assert.That(this.permissionService.CanWrite(this.model), Is.True);
        }

        [Test]
        public void VerifyModifyIfOwnerForIterationsWithoutDomainOfExpertiseAndParticipant()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.model), Is.False);

            var permission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.EngineeringModel);

            var defpermission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.ElementDefinition);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;
            defpermission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;

            Assert.That(this.permissionService.CanRead(this.model), Is.True);
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);

            Assert.That(this.permissionService.CanWrite(this.elementDef), Is.True);
            Assert.That(this.permissionService.CanRead(this.elementDef), Is.True);

            this.session.Setup(x => x.OpenIterations).Returns(new Dictionary<Iteration, Tuple<DomainOfExpertise, Participant>>
            {
                { this.iteration, new Tuple<DomainOfExpertise, Participant>(null, null) }
            });

            Assert.That(this.permissionService.CanWrite(this.elementDef), Is.False);
            Assert.That(this.permissionService.CanRead(this.elementDef), Is.True);
        }

        [Test]
        public void VerifyModifyIfOwnerForRequirement()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.model), Is.False);

            var permission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.Requirement);

            var specPermission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.RequirementsSpecification);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;
            specPermission.AccessRight = ParticipantAccessRightKind.MODIFY;

            //Requirement has no owner
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanWrite(this.requirement));
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanRead(this.requirement));

            //RequirementsSpecification has no owner
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanWrite(this.requirementsSpecification));
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanRead(this.requirementsSpecification));

            //Requirement has same owner than user's domain of expertise
            this.requirement.Owner = this.domain1;
            Assert.That(this.permissionService.CanWrite(this.requirement), Is.True);
            Assert.That(this.permissionService.CanRead(this.requirement), Is.True);

            //Requirement has other owner than user's domain of expertise
            this.requirement.Owner = this.domain2;
            Assert.That(this.permissionService.CanWrite(this.requirement), Is.False);
            Assert.That(this.permissionService.CanRead(this.requirement), Is.True);

            //RequirementsSepcification has same owner than user's domain of expertise
            this.requirementsSpecification.Owner = this.domain1;
            specPermission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;
            Assert.That(this.permissionService.CanWrite(this.requirementsSpecification), Is.True);
            Assert.That(this.permissionService.CanRead(this.requirementsSpecification), Is.True);

            //RequirementsSepcification has other owner than user's domain of expertise
            this.requirementsSpecification.Owner = this.domain2;
            Assert.That(this.permissionService.CanWrite(this.requirementsSpecification), Is.False);
            Assert.That(this.permissionService.CanRead(this.requirementsSpecification), Is.True);
        }

        [Test]
        public void VerifyModifyIfOwnerForThingsThatAreDirectlyUnderEngineeringModel()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.model), Is.False);

            var permission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.CommonFileStore);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;

            //Thing has no owner
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanWrite(this.commonFileStore));
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanRead(this.commonFileStore));

            //Thing has same owner as User's participant
            this.commonFileStore.Owner = this.domain1;
            Assert.That(this.permissionService.CanWrite(this.commonFileStore), Is.True);
            Assert.That(this.permissionService.CanRead(this.commonFileStore), Is.True);

            //Thing has other owner as User's participant
            this.commonFileStore.Owner = this.domain2;
            Assert.That(this.permissionService.CanWrite(this.commonFileStore), Is.False);
            Assert.That(this.permissionService.CanRead(this.commonFileStore), Is.True);
        }

        [Test]
        public void VerifyModifyIfOwnerForThingsThatContainedInThingsThatAreDirectlyUnderEngineeringModel()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.model), Is.False);
            Assert.That(this.permissionService.CanRead(this.model), Is.False);

            var permission =
                this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.File);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY_IF_OWNER;

            this.file.Owner = null;

            //Thing has no owner
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanWrite(this.file));
            Assert.Throws<IncompleteModelException>(() => this.permissionService.CanRead(this.file));

            //Thing has same owner as User's participant
            this.file.Owner = this.domain1;
            Assert.That(this.permissionService.CanWrite(this.file), Is.True);
            Assert.That(this.permissionService.CanRead(this.file), Is.True);

            //Thing has other owner as User's participant
            this.file.Owner = this.domain2;
            Assert.That(this.permissionService.CanWrite(this.file), Is.False);
            Assert.That(this.permissionService.CanRead(this.file), Is.True);
        }

        [Test]
        public void VerifySameAsSuperclassParticipantPermission()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.relationship), Is.False);
            Assert.That(this.permissionService.CanRead(this.relationship), Is.False);

            var permission = this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.Relationship);
            permission.AccessRight = ParticipantAccessRightKind.MODIFY;

            Assert.That(this.permissionService.CanWrite(this.relationship), Is.True);
            Assert.That(this.permissionService.CanRead(this.relationship), Is.True);
        }

        [Test]
        public void VerifySameAsContainerParticipantPermission()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            Assert.That(this.permissionService.CanWrite(this.valueset), Is.False);
            Assert.That(this.permissionService.CanRead(this.valueset), Is.False);

            var permission = this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.Parameter);

            permission.AccessRight = ParticipantAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanWrite(this.valueset), Is.True);
            Assert.That(this.permissionService.CanRead(this.valueset), Is.True);
        }

        [Test]
        public void VerifyCanWriteReturnsFalseWithFrozenIterationSetup()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });
            var permission = this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.ElementDefinition);
            permission.AccessRight = ParticipantAccessRightKind.MODIFY;
            permission = this.participantRole.ParticipantPermission.Single(x => x.ObjectClass == ClassKind.Iteration);
            permission.AccessRight = ParticipantAccessRightKind.MODIFY;

            Assert.That(this.iterationSetup.FrozenOn, Is.Null);
            Assert.That(this.permissionService.CanWrite(this.elementDef), Is.True);
            Assert.That(this.permissionService.CanWrite(this.iteration), Is.True);
            Assert.That(this.permissionService.CanWrite(ClassKind.ElementDefinition, this.iteration), Is.True);

            this.iterationSetup.FrozenOn = new DateTime();
            Assert.That(this.iterationSetup.FrozenOn, Is.Not.Null);
            Assert.That(this.permissionService.CanWrite(this.elementDef), Is.False);
            Assert.That(this.permissionService.CanWrite(this.iteration), Is.False);
            Assert.That(this.permissionService.CanWrite(ClassKind.ElementDefinition, this.iteration), Is.False);
        }

        [Test]
        public void VerifyCanCreateOverrideReturnsExpectedResult()
        {
            this.session.Setup(x => x.ActivePersonParticipants).Returns(new List<Participant> { this.participant });

            var permission = this.personRole.PersonPermission.Single(x => x.ObjectClass == ClassKind.EngineeringModelSetup);
            permission.AccessRight = PersonAccessRightKind.MODIFY;
            Assert.That(this.permissionService.CanCreateOverride(ClassKind.EngineeringModelSetup, ClassKind.SiteDirectory), Is.False);

            permission.AccessRight = PersonAccessRightKind.MODIFY_IF_PARTICIPANT;
            Assert.That(this.permissionService.CanCreateOverride(ClassKind.EngineeringModelSetup, ClassKind.SiteDirectory), Is.True);
            Assert.That(this.permissionService.CanCreateOverride(ClassKind.EngineeringModelSetup, ClassKind.EngineeringModelSetup), Is.False);
        }
    }
}
