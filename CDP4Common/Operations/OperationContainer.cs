// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationContainer.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Operations
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.DTO;

    /// <summary>
    /// A container for the <see cref="Operation"/>s that need to be executed on a data source using an implementation of <see cref="IDal"/>
    /// </summary>
    public class OperationContainer
    {
        /// <summary>
        /// Backing field for the <see cref="Operations"/> property.
        /// </summary>
        private readonly List<Operation> operations;

        /// <summary>
        /// Initializes a new instance of the <see cref="OperationContainer"/> class.
        /// </summary>
        /// <param name="context">
        /// The route of the <see cref="SiteDirectory"/> or <see cref="Iteration"/> for which the current <see cref="OperationContainer"/> is valid.
        /// </param>
        /// <param name="topContainerRevNumber">The unique <see cref="TopContainer.RevisionNumber"/> in this <see cref="OperationContainer"/></param>
        public OperationContainer(string context, int? topContainerRevNumber = null)
        {
            if (string.IsNullOrEmpty(context))
            {
                throw new ArgumentNullException("The context may not be null or empty", context);
            }

            if (!TransactionContextResolver.ValidateRouteContext(context))
            {
                throw new ArgumentException(string.Format("The context {0} is not a valid context", context),"context");
            }

            this.Context = context;
            
            this.operations = new List<Operation>();
            this.TopContainerRevisionNumber = topContainerRevNumber;
        }

        /// <summary>
        /// Gets the unique <see cref="TopContainer.RevisionNumber"/> in this <see cref="OperationContainer"/>
        /// </summary>
        public int? TopContainerRevisionNumber { get; internal set; }

        /// <summary>
        /// Get the context in which the <see cref="OperationContainer"/> shall be executed.
        /// This is either in the context of a <see cref="SiteDirectory"/> or an <see cref="Iteration"/>
        /// </summary>
        public string Context { get; private set; }
        
        /// <summary>
        /// Gets the list of <see cref="Operation"/>s.
        /// </summary>
        public IEnumerable<Operation> Operations
        {
            get
            {
                return this.operations;
            }
        }

        /// <summary>
        /// Validates and Adds the <see cref="Operation"/> to the current <see cref="OperationContainer"/>
        /// </summary>
        /// <param name="operation">
        /// The <see cref="Operation"/> that is to be added
        /// </param>
        public void AddOperation(Operation operation)
        {
            this.ValidateContextOfOperation(operation);

            this.operations.Add(operation);
        }

        /// <summary>
        /// Validates whether the provided <see cref="Operation"/> fits within 
        /// the current <see cref="Context"/>
        /// </summary>
        /// <param name="operation"></param>
        private void ValidateContextOfOperation(Operation operation)
        {
            var topcontainerRoute = operation.ModifiedThing.GetTopContainerRoute();

            if (!this.Context.Contains(topcontainerRoute))
            {
                throw new ArgumentException(string.Format("The Thing contained by the Operation does not share the context of the current OperationContainer: thing route: {0} - context: {1}", topcontainerRoute, this.Context));
            }
        }

        /// <summary>
        /// Removes the <see cref="Operation"/> from the current <see cref="OperationContainer"/>
        /// </summary>
        /// <param name="operation">
        /// The <see cref="Operation"/> that is to be removed
        /// </param>
        public void RemoveOperation(Operation operation)
        {
            this.operations.Remove(operation);            
        }
    }
}