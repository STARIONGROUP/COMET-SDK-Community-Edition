// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PostOperation.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal.Operations
{
    using System.Collections.Generic;
    using CDP4Common;
    using CDP4Common.DTO;

    /// <summary>
    /// The abstract super class from which all POST operations derive.
    /// </summary>
    public abstract class PostOperation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PostOperation"/> class
        /// </summary>
        protected PostOperation()
        {
            this.Delete = new List<ClasslessDTO>();
            this.Create = new List<Thing>();
            this.Update = new List<ClasslessDTO>();
            this.Copy = new List<ClasslessDTO>();
        }

        /// <summary>
        /// Gets or sets the collection of DTOs to delete.
        /// </summary>
        public abstract List<ClasslessDTO> Delete { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to create.
        /// </summary>
        public abstract List<Thing> Create { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to update.
        /// </summary>
        public abstract List<ClasslessDTO> Update { get; set; }

        /// <summary>
        /// Gets or sets the collection of DTOs to copy.
        /// </summary>
        public abstract List<ClasslessDTO> Copy { get; set; }

        /// <summary>
        /// Populate the current <see cref="PostOperation"/> with the content based on the 
        /// provided <see cref="Operation"/>
        /// </summary>
        /// <param name="operation">
        /// The <see cref="Operation"/> that contains all the <see cref="Thing"/>s that need to be
        /// updated to the data-source
        /// </param>
        public abstract void ConstructFromOperation(Operation operation);
    }
}
