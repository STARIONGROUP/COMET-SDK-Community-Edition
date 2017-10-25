// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParticipantRole.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

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