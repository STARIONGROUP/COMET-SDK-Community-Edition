// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModel.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
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
