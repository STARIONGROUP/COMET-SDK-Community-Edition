// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NestedParameter.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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

namespace CDP4Common.EngineeringModelData
{
    using System.Linq;

    using CDP4Common.Helpers;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

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
        /// (3) short-name of the associated <see cref="ActualFiniteState"/> or empty string if it is null
        /// (4) short name of the associated <see cref="Option"/>.
        /// </remarks>
        protected string GetDerivedPath()
        {
            var nestedElement = (NestedElement)this.Container;
            var option = (Option)nestedElement.Container;

            var nestedElementPath = nestedElement.ShortName;
            var parameterShortName = this.QueryParameterShortName();            
            var actualFiniteStateShortName = this.ActualState == null ? string.Empty : this.ActualState.ShortName;

            var result = $"{nestedElementPath}\\{parameterShortName}\\{actualFiniteStateShortName}\\{option.ShortName}";

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
        /// Gets or sets the <see cref="Option"/> the <see cref="NestedParameter"/> is valid for
        /// </summary>
        public Option Option { get; set; }
        
        /// <summary>
        /// Gets or sets the associated <see cref="IValueSet"/>
        /// </summary>
        public IValueSet ValueSet { get; set; }

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
                parameterShortName = $"{this.AssociatedParameter.ParameterType.ShortName}.{this.Component.ShortName}";
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

        /// <summary>
        /// Gets the published value <see cref="ValueArray{String}"/> for this <see cref="NestedParameter"/>
        /// </summary>
       /// <returns>The published <see cref="ValueArray{String}"/></returns>
        public ValueArray<string> GetPublishedValue()
        {
            if (this.AssociatedParameter is ParameterSubscription)
            {
                return this.ValueSet.Computed;
            }

            if (this.AssociatedParameter is ParameterOrOverrideBase parameterOrOverrideBase)
            {
                var parameterValueSetBase = parameterOrOverrideBase.QueryParameterBaseValueSet(this.Option, this.ActualState) as ParameterValueSetBase;
                var published = parameterValueSetBase?.Published;

                if (published != null)
                {
                    return published;
                }
            }

            return new ValueArray<string>(
                new []
                {
                    ValueSetConverter.DefaultObject(this.AssociatedParameter.ParameterType).ToValueSetString(this.AssociatedParameter.ParameterType)
                },
                this.AssociatedParameter
            );
        }
    }
}