// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdp4DalJsonSerializer.cs" company="Starion Group S.A.">
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

namespace CDP4JsonSerializer
{
    using System;

    using CDP4Common.MetaInfo;

    using CDP4JsonSerializer.JsonConverter;

    /// <summary>
    /// The <see cref="Cdp4DalJsonSerializer" /> is a <see cref="CDP4JsonSerializer.Cdp4JsonSerializer" /> that also supports (de)serialization of
    /// <see cref="CDP4DalCommon.Protocol.Operations.PostOperation" />
    /// </summary>
    public class Cdp4DalJsonSerializer : Cdp4JsonSerializer
    {
        /// <summary>
        /// Asserts that the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation.Copy"/> have to be ignored
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
        /// <param name="ignorePostOperationCopyProperty">Asserts that the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation.Copy"/> have to be ignored</param>
        public Cdp4DalJsonSerializer(IMetaDataProvider metaInfoProvider, Version supportedVersion, bool ignorePostOperationCopyProperty)
        {
            this.ignorePostOperationCopyProperty = ignorePostOperationCopyProperty;
            this.Initialize(metaInfoProvider, supportedVersion);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CDP4JsonSerializer.Cdp4JsonSerializer" /> class.
        /// </summary>
        /// <param name="ignorePostOperationCopyProperty">Asserts that the <see cref="CDP4DalCommon.Protocol.Operations.PostOperation.Copy"/> have to be ignored</param>
        public Cdp4DalJsonSerializer(bool ignorePostOperationCopyProperty)
        {
            this.ignorePostOperationCopyProperty = ignorePostOperationCopyProperty;
        }

        /// <summary>
        /// Initialize the <see cref="CDP4JsonSerializer.Cdp4JsonSerializer.JsonSerializerOptions" /> property
        /// </summary>
        public override void InitializeJsonSerializerOptions()
        {
            base.InitializeJsonSerializerOptions();
            this.JsonSerializerOptions.Converters.Add(new PostOperationJsonConverter(this.ignorePostOperationCopyProperty));
        }
    }
}
