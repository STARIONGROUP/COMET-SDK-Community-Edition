// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterTypeComponent.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    using CDP4Common.Types;

    /// <summary>
    /// Extended part for the auto-generated <see cref="ParameterTypeComponent"/>
    /// </summary>
    public partial class ParameterTypeComponent
    {
        /// <summary>
        /// Gets the 0-based index of the <see cref="ParameterTypeComponent"/> that it has in the Component <see cref="OrderedItemList{T}"/>
        /// </summary>
        /// <remarks>
        /// returns -1 if the <see cref="ParameterTypeComponent"/> does not have a container set
        /// </remarks>
        public int Index
        {
            get
            {
                var compoundParameterType = this.Container as CompoundParameterType;
                if (compoundParameterType != null)
                {
                    return compoundParameterType.Component.IndexOf(this);
                }

                return -1;
            }
        }
    }
}