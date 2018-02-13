#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailableDals.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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
#endregion

namespace CDP4Dal
{
    using System;
    using System.Collections.Generic;
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    using System.ComponentModel.Composition;
#endif
    using CDP4Dal.Composition;
    using CDP4Dal.DAL;

    /// <summary>
    /// Instantiated by MEF to provide a list of <see cref="IDal"/> available in the application
    /// </summary>
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
    [Export(typeof(AvailableDals))]
    [PartCreationPolicy(CreationPolicy.Shared)]
#endif
    public class AvailableDals
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AvailableDals"/> class
        /// </summary>
        /// <param name="dataAccessLayerKinds">the list of <see cref="IDal"/> in the application</param>
#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47
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