// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Option.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// Extension for the auto-generated part
    /// </summary>
    public partial class Option
    {
        /// <summary>
        /// Gets a value indicating whether this <see cref="Option"/> is the default in the current <see cref="Iteration"/>
        /// </summary>
        public bool IsDefault
        {
            get
            {
                var iteration = (Iteration)this.Container;
                return iteration.DefaultOption == this;
            }
        }
    }
}
