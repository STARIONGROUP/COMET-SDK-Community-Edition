﻿// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Dal.cs" company="Starion Group S.A.">
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

namespace CDP4Dal.DAL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.CommonData;
    using CDP4Common.DTO;
    using CDP4Common.Helpers;
    using CDP4Common.MetaInfo;

    using CDP4Dal.Composition;
    using CDP4Dal.Exceptions;
    using CDP4Dal.Operations;

    using CDP4DalCommon.Protocol.Operations;
    using CDP4DalCommon.Protocol.Tasks;
    using CDP4DalCommon.Authentication;

    using NLog;

    using Iteration = CDP4Common.DTO.Iteration;
    using Thing = CDP4Common.DTO.Thing;

    /// <summary>
    /// An abstract Data Access Layer class.
    /// </summary>
    public abstract class Dal : IDal
    {
        /// <summary>
        /// The current logger
        /// </summary>
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Initializes a new instance of the <see cref="Dal"/> class
        /// </summary>
        protected Dal()
        {
            this.MetaDataProvider = StaticMetadataProvider.GetMetaDataProvider;
            this.SetCdpVersion();
        }

        /// <summary>
        /// Gets the supported version of the data-model
        /// </summary>
        public Version DalVersion { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="ISession"/> that uses this <see cref="IDal"/>
        /// </summary>
        public ISession Session { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Credentials"/> that are used to connect the data-store
        /// </summary>
        public Credentials Credentials { get; protected set; }

        /// <summary>
        /// Gets or sets the <see cref="IMetaDataProvider"/>
        /// </summary>
        public IMetaDataProvider MetaDataProvider { get; protected set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        public abstract bool IsReadOnly { get; }

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
        public abstract Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainer, IEnumerable<string> files = null);

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously.
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
        public abstract Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null);

        /// <summary>
        /// Write all the <see cref="Operation"/>s from an <see cref="OperationContainer"/> asynchronously for a possible long running task.
        /// </summary>
        /// <param name="operationContainer">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="waitTime">The maximum time that we allow the server before responding. If the write operation takes more time
        /// than the provided <paramref name="waitTime"/>, a <see cref="CometTask"/></param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        public abstract Task<LongRunningTaskResult> Write(OperationContainer operationContainer, int waitTime, IEnumerable<string> files = null);

        /// <summary>
        /// Reads the data related to the provided <see cref="Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="token">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be passed along with the request
        /// </param>
        /// <returns>
        /// a list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/> itself
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken token, IQueryAttributes attributes = null) where T : Thing;

        /// <summary>
        /// Reads the data related to the provided <see cref="CDP4Common.DTO.Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="CDP4Common.DTO.Iteration"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="CDP4Common.DTO.EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null);

        /// <summary>
        /// Reads the <see cref="EngineeringModel"/> instances from the data-source
        /// </summary>
        /// <param name="engineeringModels">
        /// The <see cref="EngineeringModel"/>s that needs to be read from the data-source, in case the list is empty
        /// all the <see cref="EngineeringModel"/>s will be read
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>
        /// A list of <see cref="EngineeringModel"/>s
        /// </returns>
        /// <remarks>
        /// Only those <see cref="EngineeringModel"/>s are retunred that the <see cref="Person"/> is a <see cref="Participant"/> in
        /// </remarks>
        public abstract Task<IEnumerable<EngineeringModel>> Read(IEnumerable<EngineeringModel> engineeringModels, CancellationToken cancellationToken);

        /// <summary>
        /// Reads the <see cref="CometTask" /> identified by the provided <see cref="Guid" />
        /// </summary>
        /// <param name="id">The <see cref="CometTask" /> identifier</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>The read <see cref="CometTask" /></returns>
        public abstract Task<CometTask> ReadCometTask(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Reads all <see cref="CometTask" /> available for the current logged <see cref="Person" />
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>All available <see cref="CometTask" /></returns>
        public abstract Task<IEnumerable<CometTask>> ReadCometTasks(CancellationToken cancellationToken);

        /// <summary>
        /// Reads a physical file from a DataStore
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that references a physical file
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <returns>an await-able <see cref="Task"/> that returns a <see cref="byte"/> array.</returns>
        public abstract Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken);

        /// <summary>
        /// Creates the specified <see cref="Thing"/> on a data source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed. This includes the thing that was created.
        /// </returns>
        public abstract IEnumerable<Thing> Create<T>(T thing) where T : Thing;

        /// <summary>
        /// Performs an update to the <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be updated
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public abstract IEnumerable<Thing> Update<T>(T thing) where T : Thing;

        /// <summary>
        /// Deletes the specified <see cref="Thing"/> from the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be deleted
        /// </param>
        /// <typeparam name="T">
        /// a type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been updated since the last Read has been performed.
        /// </returns>
        public abstract IEnumerable<Thing> Delete<T>(T thing) where T : Thing;

        /// <summary>
        /// Opens a connection to a data source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> that the services return when connecting to the <see cref="CDP4Common.DTO.SiteDirectory"/>.
        /// </returns>
        public abstract Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Closes the connection to the data-source.
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Assertion that the provided string is a valid <see cref="Uri"/> to connect to
        /// a data-source with the current implementation of the <see cref="IDal"/>
        /// </summary>
        /// <param name="uri">
        /// a string representing a <see cref="Uri"/>
        /// </param>
        /// <returns>
        /// true when valid, false when invalid
        /// </returns>
        public abstract bool IsValidUri(string uri);

        /// <summary>
        /// Cherry pick <see cref="Thing"/>s contained into an <see cref="Iteration"/> that match provided <see cref="Category"/> and <see cref="ClassKind"/>
        /// filter
        /// </summary>
        /// <param name="engineeringModelId">The <see cref="Guid"/> of the <see cref="EngineeringModel"/></param>
        /// <param name="iterationId">The <see cref="Guid"/> of the <see cref="Iteration"/></param>
        /// <param name="classKinds">A collection of <see cref="ClassKind"/></param>
        /// <param name="categoriesId">A collection of <see cref="Category"/> <see cref="Guid"/>s</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{T}" /> of type <see cref="IEnumerable{T}"/> of read <see cref="Thing" /></returns>
        public abstract Task<IEnumerable<Thing>> CherryPick(Guid engineeringModelId, Guid iterationId, IEnumerable<ClassKind> classKinds,
            IEnumerable<Guid> categoriesId, CancellationToken cancellationToken);
        
        /// <summary>
        /// Provides login capabitilities against data-source, based on provided <paramref name="userName"/> and <paramref name="password"/>. 
        /// </summary>
        /// <param name="userName">The username that should be used for authentication</param>
        /// <param name="password">The password that should be used for authentication</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <remarks>This method should be used when using a CDP4-COMET WebServices and that it provides LocalJwtBearer authentication flow</remarks>
        public abstract Task Login(string userName, string password, CancellationToken cancellationToken);
        
        /// <summary>
        /// Requests to retrieve all available <see cref="AuthenticationSchemeKind" /> available on the datasource
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <returns>An awaitable <see cref="Task{TResult}"/> that contains the value of the queried <see cref="AuthenticationSchemeResponse" /></returns>
        public virtual Task<AuthenticationSchemeResponse> RequestAvailableAuthenticationScheme(CancellationToken cancellationToken)
        {
            return Task.FromResult(new AuthenticationSchemeResponse()
            {
                Schemes = [AuthenticationSchemeKind.Basic]
            });
        }

        /// <summary>
        /// Initializes this <see cref="Dal" /> with created <see cref="Credentials" />. 
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials"/></param>
        /// <remarks>To be used in case of multiple-step authentication, requires to be able to support multiple Authentication scheme</remarks>
        public virtual void InitializeDalCredentials(Credentials credentials)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException(nameof(credentials), $"The {nameof(credentials)} may not be null");
            }

            if (credentials.Uri == null)
            {
                throw new ArgumentNullException(nameof(credentials.Uri), "The Credentials URI may not be null");
            }

            this.Credentials = credentials;
        }

        /// <summary>
        /// Applies Authentication information based on the <see cref="Credentials" /> 
        /// </summary>
        /// <param name="credentials">The <see cref="Credentials" /></param>
        public abstract void ApplyAuthenticationCredentials(Credentials credentials);

        /// <summary>
        /// Closes the active session
        /// </summary>
        public virtual void CloseSession()
        {
            this.Credentials = null;
        }

        /// <summary>
        /// If the given Uri ends with '/' remove it.
        /// </summary>
        /// <param name="uri">
        /// The uri to clean up.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> consisting of the uri without the final /
        /// </returns>
        protected string CleanUriFinalSlash(string uri)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return string.Empty;
            }

            return uri.EndsWith("/") ? uri.TrimEnd(uri[uri.Length - 1]) : uri;
        }

        /// <summary>
        /// If the given path starts with '/' remove it.
        /// </summary>
        /// <param name="path">
        /// The path to clean up.
        /// </param>
        /// <returns>
        /// The <see cref="string"/> consisting of the cleaned up path.
        /// </returns>
        protected string CleanPathStartingSlash(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            return path.StartsWith("/") ? path.TrimStart(path[0]) : path;
        }

        /// <summary>
        /// Gets the <see cref="UriBuilder"/> object with appropriate base and paths set, accounting that the original uri might have
        /// subpaths in it already
        /// </summary>
        /// <param name="uri">The base uri (including subpaths)</param>
        /// <param name="path">The ref to a path to be appended.</param>
        /// <returns>A complete <see cref="UriBuilder"/> object.</returns>
        protected UriBuilder GetUriBuilder(Uri uri, ref string path)
        {
            var cleanPath = this.CleanPathStartingSlash(path);

            // make sure the original request path is consistently WITHOUT leading slash
            path = cleanPath;

            var result = new UriBuilder(uri);

            result.Path = $"{result.Path}{(result.Path.EndsWith("/") ? string.Empty : "/")}{cleanPath}";
            return result;
        }

        /// <summary>
        /// Set the <see cref="Iteration"/> container id for all applicable <see cref="Thing"/>
        /// </summary>
        /// <param name="dtos">
        /// The <see cref="Thing"/> to set
        /// </param>
        /// <param name="iterationId">
        /// The iteration Id.
        /// </param>
        public virtual void SetIterationContainer(IEnumerable<Thing> dtos, Guid iterationId)
        {
            if (iterationId == Guid.Empty)
            {
                throw new ArgumentException("The Iteration Id must be set");
            }

            var engineeringModelContainmentClassKind = EngineeringModelContainmentClassType.ClassKindArray;

            foreach (var thing in dtos.Where(x => !engineeringModelContainmentClassKind.Contains(x.ClassKind)))
            {
                // all the returned thing are iteration contained
                thing.IterationContainerId = iterationId;
            }

            var partitionDependantContainmentClassKind = PartitionDependentContainmentClassType.EngineeringModelAndIterationClassKindArray;

            foreach (var thing in dtos.Where(x => x.IterationContainerId == null && partitionDependantContainmentClassKind.Contains(x.ClassKind)))
            {
                // set as iteration dependent and check at a later stage if this is correct.
                thing.IterationContainerId = iterationId;
            }
        }

        /// <summary>
        /// Extract the iteration containment id from the supplied uri.
        /// </summary>
        /// <param name="uri">
        /// The uri route of the iteration contained resource.
        /// </param>
        /// <param name="iterationId">
        /// The unique identifier of the Iteration as out parameter.
        /// </param>
        /// <returns>
        /// true if iteration id was extracted from the uri, otherwise false
        /// </returns>
        public bool TryExtractIterationIdfromUri(Uri uri, out Guid iterationId)
        {
            try
            {
                var uriString = uri.ToString();
                var iterationUriName = ContainerPropertyHelper.ContainerPropertyName(ClassKind.Iteration);
                var regexPatter = iterationUriName + Constants.UriPathSeparator + Constants.UriGuidPattern;

                var match = Regex.Match(uriString, regexPatter);

                if (!match.Success)
                {
                    iterationId = Guid.Empty;
                    return false;
                }

                var id = match.Value.Split(Constants.UriPathSeparatorChar).Last();
                iterationId = new Guid(id);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Warn(ex, "The Iteration identifier could not be exracted from {0}", uri);

                iterationId = Guid.Empty;
                return false;
            }
        }

        /// <summary>
        /// Queries the request context from the uri which is either the route to an specific <see cref="CDP4Common.DTO.SiteDirectory"/> or a specific <see cref="Iteration"/>
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> to a 10-25 resource
        /// </param>
        /// <returns>
        /// A string that represents the route to a specific <see cref="CDP4Common.DTO.SiteDirectory"/> or <see cref="Iteration"/> using the following
        /// format: /SiteDirectory/{iid} /EngineeringModel/{iid}/iteration/{iid}
        /// </returns>
        public string QueryRequestContext(Uri uri)
        {
            var siteDirectoryPattern = @"(/SiteDirectory" + Constants.UriPathSeparator + Constants.UriGuidPattern + ")";
            var match = Regex.Match(uri.AbsolutePath, siteDirectoryPattern);

            if (match.Success)
            {
                return match.Groups[0].Value;
            }

            var iterationPattern = @"(/EngineeringModel" + Constants.UriPathSeparator + Constants.UriGuidPattern + Constants.UriPathSeparator + "iteration" + Constants.UriPathSeparator + Constants.UriGuidPattern + ")";
            match = Regex.Match(uri.AbsolutePath, iterationPattern);

            if (match.Success)
            {
                return match.Groups[0].Value;
            }

            return uri.AbsolutePath;
        }

        /// <summary>
        /// Verifies that the hash of the provided files matches the hashes of the <see cref="CDP4Common.DTO.FileRevision"/>
        /// objects in the <see cref="OperationContainer"/>.
        /// </summary>
        /// <param name="operationContainer">
        /// The <see cref="OperationContainer"/> that contains the <see cref="Operation"/>s that need to be verified
        /// </param>
        /// <param name="files">
        /// The paths to the files whose sha1 hash needs to match the hash present in the <see cref="OperationContainer"/>
        /// </param>
        /// <exception cref="InvalidOperationContainerException">
        /// An <see cref="InvalidOperationContainerException"/> is thrown when the <see cref="OperationContainer"/> does not contain an <see cref="Operation"/>
        /// that contains a <see cref="CDP4Common.DTO.FileRevision"/> instant whose content-hash matches the hash of the provided <paramref name="files"/>.
        /// </exception>
        protected void OperationContainerFileVerification(OperationContainer operationContainer, IEnumerable<string> files)
        {
            foreach (var file in files)
            {
                var hash = string.Empty;

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    hash = StreamToHashComputer.CalculateSha1HashFromStream(fileStream);
                }

                var contentFoundInAnOperation = false;

                foreach (var operation in operationContainer.Operations)
                {
                    var fileRevision = operation.ModifiedThing as CDP4Common.DTO.FileRevision;

                    if (fileRevision != null && fileRevision.ContentHash == hash)
                    {
                        contentFoundInAnOperation = true;
                        break;
                    }
                }

                if (!contentFoundInAnOperation)
                {
                    throw new InvalidOperationContainerException($"The hash of the specified file {file} could not be found in the operation");
                }
            }
        }

        /// <summary>
        /// Sets the CDP Version data model version that is supported by the current <see cref="CDP4Dal.Session"/>
        /// </summary>
        /// <remarks>
        /// In case the <see cref="Dal"/> is not decorated with <see cref="DalExportAttribute"/> then
        /// the <see cref="Version"/> is set to "1.0.0"
        /// </remarks>
        protected virtual void SetCdpVersion()
        {
            var dalType = this.GetType();
            var dalExportAttribute = (DalExportAttribute)Attribute.GetCustomAttribute(dalType, typeof(DalExportAttribute));

            if (dalExportAttribute != null)
            {
                this.DalVersion = new Version(dalExportAttribute.CDPVersion);
            }
            else
            {
                this.DalVersion = new Version("1.0.0");
            }
        }

        /// <summary>
        /// Queries the shortname of the authenticated User
        /// </summary>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
        /// <returns>A <see cref="Task{TResult}"/> that contains the retrieved user shortname</returns>
        public abstract Task<string> QueryAuthenticatedUserName(CancellationToken cancellationToken);

        /// <summary>
        /// Requests new <see cref="AuthenticationToken" /> based on the current refresh token
        /// </summary>
        /// <returns>An awaitabl <see cref="Task" /></returns>
        /// <param name="cancellationToken">The <see cref="CancellationToken" /></param>
        /// <exception cref="InvalidOperationException">If the current <see cref="Credentials" /> does not meet following constraints : not null, with non-null <see cref="AuthenticationToken" />
        ///  containing a refresh token and where the <see cref="AuthenticationSchemeKind" /> is <see cref="AuthenticationSchemeKind.LocalJwtBearer" /></exception>
        /// <exception cref="DalReadException">In case of non successful response from the CDP4 Data source</exception>
        public abstract Task RequestAuthenticationTokenFromRefreshToken(CancellationToken cancellationToken);
    }
}
