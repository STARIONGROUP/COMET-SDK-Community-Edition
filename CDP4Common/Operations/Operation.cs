// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Operation.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Operations
{
    using DTO;

    /// <summary>
    /// The change that is to be supplied to the data source via a Data-Access-Layer implementation
    /// </summary>
    public class Operation
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Operation"/> class. 
        /// </summary>
        /// <param name="originalThing">
        /// The original <see cref="Thing"/> fom the local domain store.
        /// </param>
        /// <param name="modifiedThing">
        /// The modified <see cref="Thing"/>
        /// </param>
        /// <param name="operationKind">
        /// the kind of operation that is to be executed
        /// </param>
        public Operation(Thing originalThing, Thing modifiedThing, OperationKind operationKind)
        {
            this.OriginalThing = originalThing;
            this.ModifiedThing = modifiedThing;
            this.OperationKind = operationKind;
        }

        /// <summary>
        /// Gets the kind of operation represented by this <see cref="Operation"/> object.
        /// </summary>
        public OperationKind OperationKind { get; internal set; }

        /// <summary>
        /// Gets the original <see cref="Thing"/> that is the subject of the <see cref="Operation"/>.
        /// </summary>
        public Thing OriginalThing { get; internal set; }

        /// <summary>
        /// Gets the modified <see cref="Thing"/> that is the subject of the <see cref="Operation"/>.
        /// </summary>
        public Thing ModifiedThing { get; internal set; }
    }
}
