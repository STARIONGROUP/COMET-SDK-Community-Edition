// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ModellingThingReference.cs" company="RHEA System S.A.">
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
    public partial class ModellingThingReference
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModellingThingReference"/> class
        /// </summary>
        /// <param name="thing">The <see cref="Thing"/> that this instance references</param>
        /// <remarks>
        /// This is used in the context of a "Create" operation when a new <see cref="ThingReference"/>
        /// </remarks>
        public ModellingThingReference(Thing thing) : base(thing)
        {
        }
    }
}
