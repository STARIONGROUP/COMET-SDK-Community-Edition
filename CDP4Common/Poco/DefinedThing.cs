// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefinedThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.CommonData
{
    /// <summary>
    /// Extended part for auto-generated <see cref="DefinedThing"/>
    /// </summary>
    public partial class DefinedThing
    {
        /// <summary>
        /// Gets the <see cref="Name"/>
        /// </summary>
        public override string UserFriendlyName
        {
            get { return this.Name; }
        }

        /// <summary>
        /// Gets the <see cref="ShortName"/>
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.ShortName; }
        }
    }
}