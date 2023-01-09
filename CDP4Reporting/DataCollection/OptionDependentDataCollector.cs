// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OptionDependentDataCollector.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2022 RHEA System S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou, Alexander van Delft, Nathanael Smiechowski
//
//    This file is part of COMET-SDK Community Edition
//
//    The COMET-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The COMET-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// </copyright>
// -------------------------------------------------------------------------------------------------------------------------------

// The namespace for this class should be CDP4Reporting.DataCollection, as this class can have different implementations in
// different environments and reports datasource code needs to be 100% compatible in all environments.
namespace CDP4Reporting.DataCollection
{
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// This class is a base class for classes that can be used in a Report Script that is <see cref="CDP4Common.EngineeringModelData.Option"/> dependent.
    /// It provides commonly used objects to the script editor.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class OptionDependentDataCollector : IterationDependentDataCollector, IOptionDependentDataCollector
    {
        /// <summary>
        /// Backing field for <see cref="SelectedOption"/>
        /// </summary>
        private Option selectedOption;

        /// <summary>
        /// Gets or sets the selected <see cref="CDP4Common.EngineeringModelData.Option"/>
        /// </summary>
        public Option SelectedOption
        {
            get => this.selectedOption ?? this.Iteration.DefaultOption ?? this.Iteration.Option.FirstOrDefault();
            set => this.selectedOption = value;
        }

        /// <summary>
        /// Selects an <see cref="CDP4Common.EngineeringModelData.Option"/> and sets the <see cref="SelectedOption"/> property
        /// </summary>
        public void SelectOption()
        {
            if (this.Iteration != null) 
            {
                if (this.Iteration.Option.Count == 1)
                {
                    this.selectedOption = this.Iteration.Option.Single();
                }
                else
                {
                    ReportScript.ReportingSettings.OptionSelector.Invoke(this.Iteration.Option, this.SelectedOption);
                }
            }
        }
    }
}
