// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PersonRole.cs" company="RHEA System S.A.">
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
    /// Extended part for the auto-generated <see cref="PersonRole"/>
    /// </summary>
    public partial class PersonRole
    {
        /// <summary>
        /// The populate person permission.
        /// </summary>
        private void PopulatePersonPermissions()
        {
            var pocos = typeof(Thing).QueryAssembly().GetTypes().Where(x => typeof(Thing).QueryIsAssignableFrom(x));
            foreach (var poco in pocos)
            {
                var field = poco.QueryField("DefaultPersonAccess");
                if (field == null)
                {
                    continue;
                }

                var accessRight = (PersonAccessRightKind)field.GetRawConstantValue();
                if (accessRight != PersonAccessRightKind.NONE)
                {
                    continue;
                }

                ClassKind classkind;
                Enum.TryParse(poco.Name, out classkind);
                var personPermission = new PersonPermission(Guid.NewGuid(), null, null)
                                           {
                                               AccessRight = accessRight,
                                               ObjectClass = classkind
                                           };
                this.PersonPermission.Add(personPermission);
            }
        }
    }
}