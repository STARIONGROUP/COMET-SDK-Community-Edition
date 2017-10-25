// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThingReference.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   Extension of the auto-generated class
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.ReportingData
{
    using System;
    using CommonData;

    /// <summary>
    /// A thing that references another Thing through its unique identifier and potentially its iteration container's one
    /// </summary>
    public abstract partial class ThingReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ThingReference"/> class
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that this instance references</param>
        /// <remarks>
        /// This is used in the context of a "Create" operation when a new <see cref="ThingReference"/>
        /// </remarks>
        protected ThingReference(Thing thing)
        {
            this.ReferencedThing = thing;
            this.ReferencedRevisionNumber = thing.RevisionNumber;
        }
    }
}
