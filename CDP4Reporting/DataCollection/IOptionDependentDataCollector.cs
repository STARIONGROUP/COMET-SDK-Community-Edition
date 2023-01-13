// --------------------------------------------------------------------------------------------------------------------
//    Copyright (c) 2015-2023 RHEA System S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft
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

namespace CDP4Reporting.DataCollection
{
    using CDP4Common.EngineeringModelData;

    /// <summary>
    /// The interface used for classes that can be used in an <see cref="Option"/> dependent Report Script.
    /// Its main purpose is to provide commonly used objects to the script editor.
    /// </summary>
    public interface IOptionDependentDataCollector : IIterationDependentDataCollector
    {
        /// <summary>
        /// Gets or sets the selected <see cref="Option"/>
        /// </summary>
        Option SelectedOption { get; }

        /// <summary>
        /// Selects an <see cref="Option"/> and sets the <see cref="SelectedOption"/> property
        /// </summary>
        void SelectOption();
    }
}
