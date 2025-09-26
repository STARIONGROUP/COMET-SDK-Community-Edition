// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModel.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="EngineeringModel"/>
    /// </summary>
    public partial class EngineeringModel
    {
        /// <summary>
        /// Gets the active <see cref="Participant"/>
        /// </summary>
        /// <param name="person">The <see cref="Person"/> who is logged</param>
        /// <returns>The active <see cref="Participant"/></returns>
        /// <exception cref="InvalidOperationException ">if a unique Participant is not found</exception>
        /// <exception cref="ArgumentNullException "></exception>
        public Participant GetActiveParticipant(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException("person");
            }

            return this.EngineeringModelSetup.Participant.Single(x => x.Person == person);
        }

        /// <summary>
        /// Gets the required <see cref="ReferenceDataLibrary"/>
        /// </summary>
        public override IEnumerable<ReferenceDataLibrary> RequiredRdls
        {
            get
            {
                var rdls = new List<ReferenceDataLibrary>();
                var mrdl = this.EngineeringModelSetup.RequiredRdl.FirstOrDefault();
                if (mrdl != null)
                {
                    rdls.Add(mrdl);
                    rdls.AddRange(mrdl.GetRequiredRdls());
                }

                return rdls;
            }
        }
    }
}
