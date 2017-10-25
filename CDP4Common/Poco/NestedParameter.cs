// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameter.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    using CDP4Common.SiteDirectoryData;

    /// <summary>
    /// Extended part for the auto-generated <see cref="NestedParameter"/>
    /// </summary>
    public partial class NestedParameter
    {
        /// <summary>
        /// Returns the derived <see cref="Path"/> value
        /// </summary>
        /// <returns>The <see cref="Path"/> value</returns>
        /// /// <remarks>
        /// The path is defined as the concatenation of:
        /// (1) path to the nestedElement,
        /// (2) short-name of <see cref="ParameterType"/>, and <see cref="ParameterTypeComponent"/> if applicable, of the associated <see cref="Parameter"/>,
        /// (3) short name of the associated <see cref="Option"/>.
        /// (4) short-name of the associated <see cref="ActualFiniteState"/> or empty string if it is null
        /// </remarks>
        protected string GetDerivedPath()
        {
            var nestedElement = (NestedElement)this.Container;
            var option = (Option)nestedElement.Container;

            var nestedElementPath = nestedElement.ShortName;
            var parameterShortName = this.QueryParameterShortName();            
            var actualFiniteStateShortname = this.ActualState == null ? string.Empty : this.ActualState.ShortName;

            var result = string.Format("{0}\\{1}\\{2}\\{3}", nestedElementPath, parameterShortName, option.ShortName, actualFiniteStateShortname);

            return result;
        }

        /// <summary>
        /// Gets or sets the <see cref="ParameterTypeComponent"/> of the associated <see cref="ParameterType"/> that the current <see cref="NestedParameter"/>
        /// represents.
        /// </summary>
        /// <remarks>
        /// In case the <see cref="ParameterType"/> is a <see cref="ScalarParameterType"/> then this property is null.
        /// </remarks>
        public ParameterTypeComponent Component { get; set; }

        /// <summary>
        /// Queries the short-name of the <see cref="ParameterType"/> of the associated <see cref="Parameter"/>
        /// </summary>
        /// <returns>
        /// a string that represents the parameter short-name.
        /// </returns>
        private string QueryParameterShortName()
        {
            string parameterShortName;
            if (this.AssociatedParameter.ParameterType is ScalarParameterType)
            {
                parameterShortName = this.AssociatedParameter.ParameterType.ShortName;
            }
            else
            {
                parameterShortName = string.Format("{0}.{1}", this.AssociatedParameter.ParameterType.ShortName, this.Component.ShortName);
            }

            return parameterShortName;
        }

        /// <summary>
        /// Gets the user-friendly name
        /// </summary>
        /// <remarks>
        /// this returns the same value as the <see cref="UserFriendlyShortName"/>
        /// </remarks>
        public override string UserFriendlyName
        {
            get { return this.QueryParameterShortName(); }
        }

        /// <summary>
        /// Gets the user-friendly short name
        /// </summary>
        public override string UserFriendlyShortName
        {
            get { return this.QueryParameterShortName(); }
        }
    }
}