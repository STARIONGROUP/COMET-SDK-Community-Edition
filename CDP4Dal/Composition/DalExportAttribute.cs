// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DalExportAttribute.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Composition
{
    using System;
    using System.ComponentModel.Composition;
    using CDP4Dal.DAL;

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
}
