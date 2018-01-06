// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalTestFixture.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2018 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using CDP4Common;
    using CDP4Common.DTO;
    using CDP4Dal.Operations;
    using CDP4Dal.DAL;    
    using Moq;
    using NUnit.Framework;
    
    /// <summary>
    /// suite of tests for the abstract <see cref="Dal"/> class
    /// </summary>
    [TestFixture]
    public class DalTestFixture
    {
        private Credentials credentials;
        private string someuri = "http://someuri";

        [SetUp]
        public void SetUp()
        {
            this.credentials = new Credentials("John", "Doe", new Uri(this.someuri));
        }

        [Test]
        public void VerifyThatTheCredentialsAreSetToNullWhenClosed()
        {
            var dal = new DalTestClass(this.credentials);            
            dal.CloseSession();
            Assert.IsNull(dal.Credentials);
        }

        [Test]
        public void VerifyThatCleanUriFinalSlashRemovesLastSlashFromUri()
        {
            var dal = new DalTestClass(this.credentials);

            var uriwithtrailingslash = this.someuri + "/";

            Assert.AreEqual(this.someuri, dal.CleanSlashes(this.someuri));
            Assert.AreEqual(this.someuri, dal.CleanSlashes(uriwithtrailingslash));
            Assert.AreEqual(string.Empty, dal.CleanSlashes(string.Empty));
            Assert.AreEqual(string.Empty, dal.CleanSlashes(null));
        }

        
        [Test]
        public void VerifyThatSetIterationIdWorks()
        {
            var dal = new DalTestClass(this.credentials);
            var uri = new Uri(@"http://localhost.com/EngineeringModel/694508eb-2730-488c-9405-6ca561df68dd/iteration/44647ff6-ffe3-44ff-9ed9-3256e2a97f9d?extent=deep&includeReferenceData=true&includeAllContainers=true");

            var model = new EngineeringModel();
            var iteration = new Iteration();
            var elementdefinition = new ElementDefinition();
            var parameter = new Parameter();
            var list = new List<Thing>
            {
                model,
                iteration,
                elementdefinition,
                parameter
            };

            Guid iterationId;
            if (dal.TryExtractIterationIdfromUri(uri, out iterationId))
            {
                dal.SetIterationContainer(list, iterationId);
            }

            Assert.IsNull(model.IterationContainerId);
            Assert.IsNull(iteration.IterationContainerId);
            Assert.AreEqual("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", elementdefinition.IterationContainerId.Value.ToString());
            Assert.AreEqual("44647ff6-ffe3-44ff-9ed9-3256e2a97f9d", parameter.IterationContainerId.Value.ToString());
        }
    }

    /// <summary>
    /// concrete test class to test <see cref="Dal"/>
    /// </summary>
    [CDPVersion("1.1.0")]
    internal class DalTestClass : Dal
    {
        public override bool IsReadOnly { get { return false; } }

        public DalTestClass(Credentials credentials)
            : base()
        {
            this.Credentials = credentials;
        }

        public string CleanSlashes(string uri)
        {
            return base.CleanUriFinalSlash(uri);
        }
        
        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public override Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null)
        {
            throw new NotImplementedException();
        }

        public override Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Create<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Update<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Thing> Delete<T>(T thing)
        {
            throw new NotImplementedException();
        }

        public override void Close()
        {
            throw new NotImplementedException();
        }

        public override bool IsValidUri(string uri)
        {
            throw new NotImplementedException();
        }
    }
}
