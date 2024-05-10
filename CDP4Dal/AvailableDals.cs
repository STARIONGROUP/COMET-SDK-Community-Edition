// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableDals.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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

namespace CDP4Dal
{
    using System;
    using System.Collections.Generic;
#if NETFRAMEWORK
    using System.ComponentModel.Composition;
#endif
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;

    /// <summary>
    /// Instantiated by MEF to provide a list of <see cref="IDal"/> available in the application
    /// </summary>
#if NETFRAMEWORK
    [Export(typeof(AvailableDals))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public class AvailableDals
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableDals"/> class
        /// </summary>
        /// <param name="dataAccessLayerKinds">the list of <see cref="IDal"/> in the application</param>
#if NETFRAMEWORK
        [ImportingConstructor]
        public AvailableDals([ImportMany] IEnumerable<Lazy<IDal, IDalMetaData>> dataAccessLayerKinds)
        {
            this.DataAccessLayerKinds = new List<Lazy<IDal, IDalMetaData>>();

            foreach (var dalkind in dataAccessLayerKinds)
            {
                this.DataAccessLayerKinds.Add(dalkind);
            }
        }
#else
        public AvailableDals(IEnumerable<Lazy<IDal, IDalMetaData>> dataAccessLayerKinds)
        {
            this.DataAccessLayerKinds = new List<Lazy<IDal, IDalMetaData>>();

            foreach (var dalkind in dataAccessLayerKinds)
            {
                this.DataAccessLayerKinds.Add(dalkind);
            }
        }
#endif

        /// <summary>
        /// Gets the Available IDAL implementations that the user can select one from
        /// </summary>
        public List<Lazy<IDal, IDalMetaData>> DataAccessLayerKinds { get; private set; }
    }
}