// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandlerService.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
// 
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, Antoine Théate, Omar Elebiary
// 
//    This file is part of CDP4-COMET-IME Community Edition.
//    The CDP4-COMET-IME Community Edition is the Starion Concurrent Design Desktop Application and Excel Integration
//    compliant with ECSS-E-TM-10-25 Annex A and Annex C.
// 
//    The CDP4-COMET-IME Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Affero General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or any later version.
// 
//    The CDP4-COMET-IME Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//    GNU Affero General Public License for more details.
// 
//    You should have received a copy of the GNU Affero General Public License
//    along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.ExceptionHandlerService
{
    using System;
    using System.Collections.Generic;
#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif
    using System.Linq;

    /// <summary>
    /// The purpose of the <see cref="ExceptionHandlerService" /> is to check server exceptions and start Application processes accordingly
    /// </summary>

#if NETFRAMEWORK
    [Export(typeof(IExceptionHandlerService))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public class ExceptionHandlerService : IExceptionHandlerService
    {
        /// <summary>
        /// The collection of <see cref="IExceptionHandler"/>s
        /// </summary>
        private readonly List<IExceptionHandler> exceptionHandlers;

        /// <summary>
        /// Creates a new instance of the <see cref="ExceptionHandlerService"/> class
        /// </summary>
        /// <param name="exceptionHandlers">INJECTED collection of <see cref="IExceptionHandler"/>s registered in the application.</param>
#if NETFRAMEWORK
        [ImportingConstructor]
        public ExceptionHandlerService([ImportMany] IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            this.exceptionHandlers = exceptionHandlers.ToList();
        }
#else
        public ExceptionHandlerService(IEnumerable<IExceptionHandler> exceptionHandlers)
        {
            this.exceptionHandlers = exceptionHandlers.ToList();
        }
#endif

        /// <summary>
        /// Handles a specific <see cref="Exception"/> and enables the Application to start a process based on the ocntent or type of the <see cref="Exception"/>
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/></param>
        /// <param name="payload"></param>
        /// <returns>a boolean value indicating if the <see cref="Exception"/> was handled or not, so it could be thrown again</returns>
        public bool HandleException(Exception exception, params object[] payload)
        {
            var isHandled = false;

            foreach (var exceptionHandler in this.exceptionHandlers)
            {
                isHandled = exceptionHandler.HandleException(exception, payload) || isHandled;
            }

            return isHandled;
        }
    }
}
