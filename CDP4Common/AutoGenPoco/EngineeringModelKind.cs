// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
