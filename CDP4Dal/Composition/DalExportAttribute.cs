// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DalExportAttribute.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2021 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexandervan Delft, Nathanael Smiechowski, Ahmed Abulwafa Ahmed
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Composition
{
    using System;

    using CDP4Dal.DAL;

#if NETFRAMEWORK

    using System.ComponentModel.Composition;
    
    /// <summary>
    /// The purpose of the <see cref="DalExportAttribute"/> is to decorate <see cref="IDal"/> implementations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false), MetadataAttribute]
    public class DalExportAttribute : ExportAttribute, IDalMetaData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalExportAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The human readable name of the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="description">
        /// The human readable description of the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="modelVersion">
        /// The max version of the CDP Model that is supported by the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="type">
        /// The type of <see cref="IDal"/> based on <see cref="DalType"/> this export defines.
        /// </param>
        public DalExportAttribute(string name, string description, string modelVersion, DalType type)
            : base(typeof(IDal))
        {
            this.Name = name;
            this.Description = description;
            this.CDPVersion = modelVersion;
            this.DalType = type;
        }

        /// <summary>
        /// Gets the human readable name of the exported <see cref="IDal"/>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the human readable description of the exported <see cref="IDal"/>
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the maximum CDP Model version of the exported <see cref="IDal"/>
        /// </summary>
        public string CDPVersion { get; private set; }

        /// <summary>
        /// Gets the type of <see cref="IDal"/> this export defines.
        /// </summary>
        public DalType DalType { get; private set; }
    }
#else
    /// <summary>
    /// The purpose of the <see cref="DalExportAttribute"/> is to decorate <see cref="IDal"/> implementations
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class DalExportAttribute : Attribute, IDalMetaData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DalExportAttribute"/> class.
        /// </summary>
        /// <param name="name">
        /// The human readable name of the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="description">
        /// The human readable description of the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="modelVersion">
        /// The max version of the CDP Model that is supported by the <see cref="IDal"/> implementation that is being decorated
        /// </param>
        /// <param name="type">
        /// The type of <see cref="IDal"/> based on <see cref="DalType"/> this export defines.
        /// </param>
        public DalExportAttribute(string name, string description, string modelVersion, DalType type)
        {
            this.Name = name;
            this.Description = description;
            this.CDPVersion = modelVersion;
            this.DalType = type;
        }

        /// <summary>
        /// Gets the human readable name of the exported <see cref="IDal"/>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the human readable description of the exported <see cref="IDal"/>
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the maximum CDP Model version of the exported <see cref="IDal"/>
        /// </summary>
        public string CDPVersion { get; private set; }

        /// <summary>
        /// Gets the type of <see cref="IDal"/> this export defines.
        /// </summary>
        public DalType DalType { get; private set; }
    }
#endif
}