// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationContainer.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2019 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
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

namespace CDP4Dal.Operations
{
    using System;
    using System.Collections.Generic;    
    using CDP4Common.DTO;
    using CDP4Common.Helpers;

    /// <summary>
    /// A container for the <see cref="Operation"/>s that need to be executed on a data source using an implementation of <see cref="DAL.IDal"/>
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
                throw new ArgumentNullException(nameof(context), "The context may not be null or empty");
            }

            if (!TransactionContextResolver.ValidateRouteContext(context))
            {
                throw new ArgumentException($"The context {context} is not a valid context", nameof(context));
            }

            this.Token = TokenGenerator.GenerateRandomToken();

            this.Context = context;
            
            this.operations = new List<Operation>();
            this.TopContainerRevisionNumber = topContainerRevNumber;
        }

        /// <summary>
        /// Gets the unique <see cref="TopContainer.RevisionNumber"/> in this <see cref="OperationContainer"/>
        /// </summary>
        public int? TopContainerRevisionNumber { get; internal set; }

        /// <summary>
        /// Gets a correlation token that can be used to correlate the current <see cref="OperationContainer"/> to
        /// the operations executed on a data-source
        /// </summary>
        public string Token { get; private set; }

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
                throw new ArgumentException(nameof(operation), $"The Thing contained by the Operation does not share the context of the current OperationContainer: thing route: {topcontainerRoute} - context: {this.Context}");
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