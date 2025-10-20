// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperationTestFixture.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
// 
//    Authors: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary, Jaime Bernar
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
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4ServicesDal.Tests
{
    using System;
    using System.IO;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;

    using CDP4Dal;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    using CDP4JsonSerializer;

    using CDP4ServicesDal.Tests.Helper;

    using Moq;

    using NUnit.Framework;

    using File = System.IO.File;

    [TestFixture]
    public class PostOperationTestFixture
    {
        private Cdp4DalJsonSerializer serializer;

        [SetUp]
        public void Setup()
        {
            var metamodel = new MetaDataProvider();
            this.serializer = new Cdp4DalJsonSerializer(metamodel, new Version(1, 1, 0), false);
        }

        [Test]
        public void Verify_that_deserialization_of_Post_Operation_does_not_throw_an_exception()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/PostOperation.json"));

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                var test = this.serializer.Deserialize<TestPostOperation>(stream);
                Assert.That(test.Copy.Count, Is.EqualTo(1));
            }
        }

        [Test]
        public void Verify_that_serialization_of_Post_Operation_returns_expected_result()
        {
            var expected = @"{""_delete"":[],""_create"":[{""category"":[],""classKind"":""File"",""excludedDomain"":[],""excludedPerson"":[],""fileRevision"":[""cb54801a-9a08-495f-996c-6467a86ed9cc""],""iid"":""643e6154-a035-4445-a4f2-2c7ff5d2fdbd"",""lockedBy"":null,""modifiedOn"":""0001-01-01T00:00:00.000Z"",""owner"":""0e92edde-fdff-41db-9b1d-f2e484f12535"",""revisionNumber"":0},{""classKind"":""FileRevision"",""containingFolder"":null,""contentHash"":""F73747371CFD9473C19A0A7F99BCAB008474C4CA"",""createdOn"":""0001-01-01T00:00:00.000Z"",""creator"":""284334dd-e8e5-42d6-bc8a-715c507a7f02"",""excludedDomain"":[],""excludedPerson"":[],""fileType"":[{""k"":1,""v"":""b16894e4-acb5-4e81-a118-16c00eb86d8f""}],""iid"":""cb54801a-9a08-495f-996c-6467a86ed9cc"",""modifiedOn"":""0001-01-01T00:00:00.000Z"",""name"":""testfile"",""revisionNumber"":0}],""_update"":[{""classKind"":""DomainFileStore"",""iid"":""da7dddaa-02aa-4897-9935-e8d66c811a96"",""file"":[""643e6154-a035-4445-a4f2-2c7ff5d2fdbd""]}],""_copy"":[]}";

            var engineeringModelIid = Guid.Parse("9ec982e4-ef72-4953-aa85-b158a95d8d56");
            var iterationIid = Guid.Parse("e163c5ad-f32b-4387-b805-f4b34600bc2c");
            var domainFileStoreIid = Guid.Parse("da7dddaa-02aa-4897-9935-e8d66c811a96");
            var fileIid = Guid.Parse("643e6154-a035-4445-a4f2-2c7ff5d2fdbd");
            var fileRevisionIid = Guid.Parse("cb54801a-9a08-495f-996c-6467a86ed9cc");
            var domainOfExpertiseIid = Guid.Parse("0e92edde-fdff-41db-9b1d-f2e484f12535");
            var fileTypeIid = Guid.Parse("b16894e4-acb5-4e81-a118-16c00eb86d8f");
            var participantIid = Guid.Parse("284334dd-e8e5-42d6-bc8a-715c507a7f02");

            var originalDomainFileStore = new DomainFileStore(domainFileStoreIid, 0);
            originalDomainFileStore.AddContainer(ClassKind.Iteration, iterationIid);
            originalDomainFileStore.AddContainer(ClassKind.EngineeringModel, engineeringModelIid);

            var modifiedDomainFileStore = originalDomainFileStore.DeepClone<DomainFileStore>();
            modifiedDomainFileStore.File.Add(fileIid);

            var file = new CDP4Common.DTO.File(fileIid, 0);
            file.Owner = domainOfExpertiseIid;
            file.FileRevision.Add(fileRevisionIid);
            file.AddContainer(ClassKind.DomainFileStore, domainFileStoreIid);
            file.AddContainer(ClassKind.Iteration, iterationIid);
            file.AddContainer(ClassKind.EngineeringModel, engineeringModelIid);

            var fileRevision = new FileRevision(fileRevisionIid, 0);
            fileRevision.Name = "testfile";
            fileRevision.ContentHash = "F73747371CFD9473C19A0A7F99BCAB008474C4CA";
            fileRevision.FileType.Add(new OrderedItem() { K = 1, V = fileTypeIid });
            fileRevision.Creator = participantIid;
            fileRevision.AddContainer(ClassKind.File, fileIid);
            fileRevision.AddContainer(ClassKind.DomainFileStore, domainFileStoreIid);
            fileRevision.AddContainer(ClassKind.Iteration, iterationIid);
            fileRevision.AddContainer(ClassKind.EngineeringModel, engineeringModelIid);

            var context = $"/EngineeringModel/{engineeringModelIid}/iteration/{iterationIid}";
            var operationContainer = new OperationContainer(context, null);

            var updateCommonFileStoreOperation = new Operation(originalDomainFileStore, modifiedDomainFileStore, OperationKind.Update);
            operationContainer.AddOperation(updateCommonFileStoreOperation);

            var createFileOperation = new Operation(null, file, OperationKind.Create);
            operationContainer.AddOperation(createFileOperation);

            var createFileRevisionOperation = new Operation(null, fileRevision, OperationKind.Create);
            operationContainer.AddOperation(createFileRevisionOperation);

            var postOperation = new CdpPostOperation(new MetaDataProvider(), null);

            foreach (var operation in operationContainer.Operations)
            {
                postOperation.ConstructFromOperation(operation);
            }

            using (var stream = new MemoryStream())
            using (var streamReader = new StreamReader(stream))
            {
                this.serializer.SerializeToStream(postOperation, stream);

                stream.Position = 0;
                Assert.That(streamReader.ReadToEnd(), Is.EqualTo(expected));
            }
        }

        [Test]
        public void Verify_that_null_modified_thing_throws()
        {
            var operation = new Operation(null, null, OperationKind.Create);
            var postOperation = new CdpPostOperation(new MetaDataProvider(), Mock.Of<CDP4Dal.ISession>());

            Assert.That(() => postOperation.ConstructFromOperation(operation), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Verify_that_delete_operation_creates_classless_entry()
        {
            var thing = new CDP4Common.DTO.DomainOfExpertise(Guid.NewGuid(), 0);
            var operation = new Operation(null, thing, OperationKind.Delete);
            var postOperation = new CdpPostOperation(new MetaDataProvider(), Mock.Of<ISession>());

            postOperation.ConstructFromOperation(operation);

            Assert.That(postOperation.Delete, Has.Count.EqualTo(1));
            Assert.That(postOperation.Delete[0]["ClassKind"], Is.EqualTo(thing.ClassKind));
        }

        [Test]
        public void Verify_that_update_operation_adds_modified_values()
        {
            var iid = Guid.NewGuid();
            var original = new CDP4Common.DTO.DomainOfExpertise(iid, 0)
            {
                Name = "Original"
            };

            var modified = new CDP4Common.DTO.DomainOfExpertise(iid, 0)
            {
                Name = "Updated"
            };

            var operation = new Operation(original, modified, OperationKind.Update);
            var postOperation = new CdpPostOperation(new MetaDataProvider(), Mock.Of<ISession>());

            postOperation.ConstructFromOperation(operation);

            Assert.That(postOperation.Update, Has.Count.EqualTo(1));
            Assert.That(postOperation.Update[0]["Name"], Is.EqualTo("Updated"));
        }

        [Test]
        public void Verify_that_move_operation_is_not_supported()
        {
            var thing = new CDP4Common.DTO.DomainOfExpertise(Guid.NewGuid(), 0);
            var operation = new Operation(thing, thing, OperationKind.Move);
            var postOperation = new CdpPostOperation(new MetaDataProvider(), Mock.Of<ISession>());

            Assert.That(() => postOperation.ConstructFromOperation(operation), Throws.TypeOf<NotImplementedException>());
        }

        private class TestPostOperation : PostOperation
        {
        }
    }
}
