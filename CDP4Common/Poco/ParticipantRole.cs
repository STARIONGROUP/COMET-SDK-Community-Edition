#region Copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRole.cs" company="RHEA System S.A.">
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
#endregion

namespace CDP4Common.SiteDirectoryData
{
    using System;
    using System.Linq;
    using System.Reflection;
    using CDP4Common.CommonData;
    using CDP4Common.Polyfills;

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
            var pocos = typeof(Thing).QueryAssembly().GetTypes().Where(x => typeof(Thing).QueryIsAssignableFrom(x));
            foreach (var poco in pocos)
            {
                var field = poco.QueryField("DefaultParticipantAccess");
                if (field == null)
                {
                    continue;
                }

                var accessRight = (ParticipantAccessRightKind)field.GetRawConstantValue();
                if (accessRight != ParticipantAccessRightKind.NONE)
                {
                    continue;
                }

                ClassKind classkind;
                Enum.TryParse(poco.Name, out classkind);
                var personPermission = new ParticipantPermission(Guid.NewGuid(), null, null)
                {
                    AccessRight = accessRight,
                    ObjectClass = classkind
                };
                this.ParticipantPermission.Add(personPermission);
            }
        }
    }
}