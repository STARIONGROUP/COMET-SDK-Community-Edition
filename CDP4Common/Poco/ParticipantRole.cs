// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRole.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Yevhen Ikonnykov
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

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Linq;
    using CDP4Common.CommonData;
    using CDP4Common.Helpers;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParticipantRole"/>
    /// </summary>
    public partial class ParticipantRole
    {
        /// <summary>
        /// The populate participant permission.
        /// </summary>
        private void PopulateParticipantPermissions()
        {
            var provider = new DefaultPermissionProvider();
            var classKindType = ClassKind.GetType();
            provider.GetDefaultTypeNameParticipantPermissions()
                    .Where(x => x.Value.Equals(ParticipantAccessRightKind.NONE))
                    .ToList()
                    .ForEach(x => {
                        var participantPermission = new ParticipantPermission(Guid.NewGuid(), null, null);
                        participantPermission.AccessRight = x.Value;
                        participantPermission.ObjectClass = (ClassKind)Enum.Parse(classKindType, x.Key);
                        this.ParticipantPermission.Add(participantPermission);
                    });
        }
    }
}