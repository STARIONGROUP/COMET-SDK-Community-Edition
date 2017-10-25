// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudyPhaseKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.SiteDirectoryData
{
    /// <summary>
    /// <!--StartFragment--><a id="ParameterValueKind">enumeration datatype that represents</a><!--EndFragment--> the different study phases that may apply to an EngineeringModelSetup / EngineeringModel
    /// </summary>
    public enum StudyPhaseKind
    {
        /// <summary>
        /// assertion that a model pertains to a study preparation phase
        /// </summary>
        PREPARATION_PHASE,

        /// <summary>
        /// assertion that a model pertains to a study design session phase
        /// </summary>
        DESIGN_SESSION_PHASE,

        /// <summary>
        /// assertion that a model pertains to a study reporting phase
        /// </summary>
        REPORTING_PHASE,

        /// <summary>
        /// assertion that a model pertains to a completed study
        /// </summary>
        COMPLETED_STUDY,
    }
}
