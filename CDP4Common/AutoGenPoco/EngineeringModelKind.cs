// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelKind.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// enumeration datatype that represents the different possible kinds ofEngineeringModel
    /// </summary>
    public enum EngineeringModelKind
    {
        /// <summary>
        /// assertion that an engineering model (represented by an EngineeringModelSetup and an EngineeringModel) is the model of a concrete study
        /// </summary>
        STUDY_MODEL,

        /// <summary>
        /// assertion that an engineering model (represented by an EngineeringModelSetup and an EngineeringModel) is a template model intended to be used as the basis for new study modelsNote: A template model may have only one iteration (represented by a combination of IterationSetup and Iteration).
        /// </summary>
        TEMPLATE_MODEL,

        /// <summary>
        /// assertion that an engineering model (represented by an EngineeringModelSetup and an EngineeringModel) is a catalogue of model components and/or patterns that can be re-used in the model of a studyNote: A catalogue may have only one iteration (represented by a combination of IterationSetup and Iteration), and one Option.
        /// </summary>
        MODEL_CATALOGUE,

        /// <summary>
        /// assertion that an engineering model (represented by an EngineeringModelSetup and an EngineeringModel) is a scratch model to be used for preparation, training or experimentation purposes
        /// </summary>
        SCRATCH_MODEL,
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
