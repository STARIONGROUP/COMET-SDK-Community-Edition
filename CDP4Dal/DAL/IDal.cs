// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDal.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft
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

namespace CDP4Dal.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using CDP4Common.DTO;
    using CDP4Common.MetaInfo;

    using CDP4Dal.Operations;

    /// <summary>
    /// The Data Access Layer interface.
    /// </summary>
    public interface IDal
    {
        /// <summary>
        /// Gets the supported version of the data-model
        /// </summary>
        Version DalVersion { get; }

        /// <summary>
        /// Gets or sets the <see cref="IMetaDataProvider"/>
        /// </summary>
        IMetaDataProvider MetaDataProvider { get; }

        /// <summary>
        /// Gets or sets the <see cref="ISession"/> that uses this <see cref="IDal"/>
        /// </summary>
        ISession Session { get; set; }

        /// <summary>
        /// Gets the value indicating whether this <see cref="IDal"/> is read only
        /// </summary>
        bool IsReadOnly { get; }
        
        /// <summary>
        /// Write all the <see cref="Operation"/>s from all the <see cref="OperationContainer"/>s asynchronously.
        /// </summary>
        /// <param name="operationContainers">
        /// The provided <see cref="OperationContainer"/> to write
        /// </param>
        /// <param name="files">
        /// The path to the files that need to be uploaded. If <paramref name="files"/> is null, then no files are to be uploaded
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/>s that has been created or updated since the last Read or Write operation.
        /// </returns>
        Task<IEnumerable<Thing>> Write(IEnumerable<OperationContainer> operationContainers, IEnumerable<string> files = null);

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
        Task<IEnumerable<Thing>> Write(OperationContainer operationContainer, IEnumerable<string> files = null);

        /// <summary>
        /// Reads the data related to the provided <see cref="Thing"/> from the data-source
        /// </summary>
        /// <typeparam name="T">
        /// an type of <see cref="Thing"/>
        /// </typeparam>
        /// <param name="thing">
        /// An instance of <see cref="Thing"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="Thing"/> including the <see cref="Thing"/>.
        /// In case the <paramref name="thing"> is a top container then all the <see cref="Thing"/>s that have been updated since the
        /// last read will be returned.
        /// </returns>
        Task<IEnumerable<Thing>> Read<T>(T thing, CancellationToken cancellationToken, IQueryAttributes attributes = null) where T : Thing;

        /// <summary>
        /// Reads the data related to the provided <see cref="Iteration"/> from the data-source
        /// </summary>
        /// <param name="iteration">
        /// An instance of <see cref="Iteration"/> that needs to be read from the data-source
        /// </param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/>
        /// </param>
        /// <param name="attributes">
        /// An instance of <see cref="IQueryAttributes"/> to be used with the request
        /// </param>
        /// <returns>
        /// A list of <see cref="Thing"/> that are contained by the provided <see cref="EngineeringModel"/> including the Reference-Data.
        /// All the <see cref="Thing"/>s that have been updated since the last read will be returned.
        /// </returns>
        Task<IEnumerable<Thing>> Read(Iteration iteration, CancellationToken cancellationToken, IQueryAttributes attributes = null);

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
        Task<byte[]> ReadFile(Thing thing, CancellationToken cancellationToken);

        /// <summary>
        /// Creates the specified <see cref="Thing"/> on the data-source
        /// </summary>
        /// <param name="thing">
        /// The <see cref="Thing"/> that is to be created
        /// </param>
        /// <typeparam name="T">
        /// The type of <see cref="Thing"/>
        /// </typeparam>
        /// <returns>
        /// A list of <see cref="Thing"/> that have been created.
        /// </returns>
        IEnumerable<Thing> Create<T>(T thing) where T : Thing;

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
        /// A list of <see cref="Thing"/> that have been updated.
        /// </returns>
        IEnumerable<Thing> Update<T>(T thing) where T : Thing;

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
        IEnumerable<Thing> Delete<T>(T thing) where T : Thing;

        /// <summary>
        /// Opens a connection to a data-source <see cref="Uri"/>
        /// </summary>
        /// <param name="credentials">
        /// The <see cref="Credentials"/> that are used to connect to the data source such as username, password and <see cref="Uri"/>
        /// </param>
        /// <param name="cancellationToken">
        /// The cancellation Token.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/> that the services return when connecting to the <see cref="SiteDirectory"/>.
        /// </returns>
        Task<IEnumerable<Thing>> Open(Credentials credentials, CancellationToken cancellationToken);

        /// <summary>
        /// Closes the connection to the data-source.
        /// </summary>
        void Close();

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
        bool IsValidUri(string uri);
    }
}