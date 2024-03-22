// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperationTestFixture.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2024 RHEA System S.A.
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

namespace CDP4WspDal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using CDP4Common;
    using CDP4Common.CommonData;
    using CDP4Common.Dto;
    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;
    using CDP4Common.Types;

    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;

    using CDP4DalJsonSerializer;

    using CDP4WspDal.Tests.Helper;

    using NUnit.Framework;

    using File = System.IO.File;
    using Thing = CDP4Common.DTO.Thing;

    [TestFixture]
    public class PostOperationTestFixture
    {
        private Cdp4DalJsonSerializer serializer;

        [SetUp]
        public void Setup()
        {
            var metamodel = new MetaDataProvider();
            this.serializer = new Cdp4DalJsonSerializer(metamodel, new Version(1, 1, 0), true);
        }

        [Test]
        public void Verify_that_deserialization_of_Post_Operation_does_not_throw_an_exception()
        {
            var response = File.ReadAllText(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData/PostOperation.json"));

            using (var stream = StreamHelper.GenerateStreamFromString(response))
            {
                Assert.DoesNotThrow(() => this.serializer.Deserialize<TestPostOperation>(stream));
            }
        }

        [Test]
        public void Verify_that_serialization_of_Post_Operation_returns_expected_result()
        {
            var expected = @"{""_delete"":[],""_create"":[{""category"":[],""classKind"":""File"",""excludedDomain"":[],""excludedPerson"":[],""fileRevision"":[""cb54801a-9a08-495f-996c-6467a86ed9cc""],""iid"":""643e6154-a035-4445-a4f2-2c7ff5d2fdbd"",""lockedBy"":null,""modifiedOn"":""0001-01-01T00:00:00.000Z"",""owner"":""0e92edde-fdff-41db-9b1d-f2e484f12535"",""revisionNumber"":0},{""classKind"":""FileRevision"",""containingFolder"":null,""contentHash"":""F73747371CFD9473C19A0A7F99BCAB008474C4CA"",""createdOn"":""0001-01-01T00:00:00.000Z"",""creator"":""284334dd-e8e5-42d6-bc8a-715c507a7f02"",""excludedDomain"":[],""excludedPerson"":[],""fileType"":[{""k"":1,""v"":""b16894e4-acb5-4e81-a118-16c00eb86d8f""}],""iid"":""cb54801a-9a08-495f-996c-6467a86ed9cc"",""modifiedOn"":""0001-01-01T00:00:00.000Z"",""name"":""testfile"",""revisionNumber"":0}],""_update"":[{""classKind"":""DomainFileStore"",""iid"":""da7dddaa-02aa-4897-9935-e8d66c811a96"",""file"":[""643e6154-a035-4445-a4f2-2c7ff5d2fdbd""]}]}";

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
            fileRevision.FileType.Add(new OrderedItem { K = 1, V = fileTypeIid });
            fileRevision.Creator = participantIid;
            fileRevision.AddContainer(ClassKind.File, fileIid);
            fileRevision.AddContainer(ClassKind.DomainFileStore, domainFileStoreIid);
            fileRevision.AddContainer(ClassKind.Iteration, iterationIid);
            fileRevision.AddContainer(ClassKind.EngineeringModel, engineeringModelIid);

            var context = $"/EngineeringModel/{engineeringModelIid}/iteration/{iterationIid}";
            var operationContainer = new OperationContainer(context);

            var updateCommonFileStoreOperation = new Operation(originalDomainFileStore, modifiedDomainFileStore, OperationKind.Update);
            operationContainer.AddOperation(updateCommonFileStoreOperation);

            var createFileOperation = new Operation(null, file, OperationKind.Create);
            operationContainer.AddOperation(createFileOperation);

            var createFileRevisionOperation = new Operation(null, fileRevision, OperationKind.Create);
            operationContainer.AddOperation(createFileRevisionOperation);

            var postOperation = new WspPostOperation(new MetaDataProvider());

            foreach (var operation in operationContainer.Operations)
            {
                postOperation.ConstructFromOperation(operation);
            }

            using (var stream = new MemoryStream())
            using (var streamReader = new StreamReader(stream))
            {
                this.serializer.SerializeToStream(postOperation, stream);

                stream.Position = 0;
                Assert.AreEqual(expected, streamReader.ReadToEnd());
            }
        }

        private class TestPostOperation : PostOperation
        {
        }
    }
}
