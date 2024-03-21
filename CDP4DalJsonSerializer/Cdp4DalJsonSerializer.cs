// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4DalJsonSerializer.cs" company="RHEA System S.A.">
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

namespace CDP4DalJsonSerializer
{
    using System;

    using CDP4Common.MetaInfo;

    using CDP4DalCommon.Protocol.Operations;

    using CDP4DalJsonSerializer.JsonConverter;

    using CDP4JsonSerializer;

    /// <summary>
    /// The <see cref="Cdp4DalJsonSerializer" /> is a <see cref="Cdp4JsonSerializer" /> that also supports (de)serialization of
    /// <see cref="PostOperation" />
    /// </summary>
    public class Cdp4DalJsonSerializer : Cdp4JsonSerializer
    {
        /// <summary>
        /// Asserts that the <see cref="PostOperation.Copy"/> have to be ignored
        /// </summary>
        private readonly bool ignorePostOperationCopyProperty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4DalJsonSerializer" /> class.
        /// </summary>
        /// <param name="metaInfoProvider">
        /// The meta Info Provider.
        /// </param>
        /// <param name="supportedVersion">
        /// The supported version of the data-model
        /// </param>
        /// <param name="ignorePostOperationCopyProperty">Asserts that the <see cref="PostOperation.Copy"/> have to be ignored</param>
        public Cdp4DalJsonSerializer(IMetaDataProvider metaInfoProvider, Version supportedVersion, bool ignorePostOperationCopyProperty = false) 
        {
            this.ignorePostOperationCopyProperty = ignorePostOperationCopyProperty;

            this.Initialize(metaInfoProvider, supportedVersion);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cdp4JsonSerializer" /> class.
        /// </summary>
        /// <param name="ignorePostOperationCopyProperty">Asserts that the <see cref="PostOperation.Copy"/> have to be ignored</param>
        public Cdp4DalJsonSerializer(bool ignorePostOperationCopyProperty = false)
        {
            this.ignorePostOperationCopyProperty = ignorePostOperationCopyProperty;
        }

        /// <summary>
        /// Initialize this instance with the required <see cref="IMetaDataProvider" /> and supported <see cref="Version" />
        /// </summary>
        /// <param name="metaInfoProvider">The <see cref="IMetaDataProvider" /></param>
        /// <param name="supportedVersion">The supported <see cref="Version" /></param>
        public override void Initialize(IMetaDataProvider metaInfoProvider, Version supportedVersion)
        {
            base.Initialize(metaInfoProvider, supportedVersion);

            this.JsonSerializerOptions.Converters.Add(new PostOperationJsonConverter(this.ignorePostOperationCopyProperty));
        }
    }
}
