// -------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelContainmentClassType.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is the auto-generated EngineeringModelContainmentClassType class. Any manual changes on this file will be overwritten!
// </summary>
// -------------------------------------------------------------------------------------------------

namespace CDP4Common.Helpers
{
    using CDP4Common.CommonData;

    /// <summary>
    /// Class representing the Array of <see cref="ClassKind"/>'s contained by <see cref= "EngineeringModel"/>
    /// </summary>
    public static class EngineeringModelContainmentClassType
    {
        /// <summary>
        /// Array consisting of <see cref="ClassKind"/>'s which are contained through a composite aggregation by <see cref= "EngineeringModel"/> and 
        /// it's subtree, excluding the subtree of the <see cref="Iteration"/> class
        /// </summary>
        /// <remarks>
        /// The array does not contain any ClassKinds of abstract classes
        /// </remarks>
        public static readonly ClassKind[] ClassKindArray = new[] {
            ClassKind.ActionItem,
            ClassKind.Approval,
            ClassKind.BinaryNote,
            ClassKind.Book,
            ClassKind.ChangeProposal,
            ClassKind.ChangeRequest,
            ClassKind.CommonFileStore,
            ClassKind.ContractChangeNotice,
            ClassKind.EngineeringModelDataDiscussionItem,
            ClassKind.EngineeringModelDataNote,
            ClassKind.File,
            ClassKind.FileRevision,
            ClassKind.Folder,
            ClassKind.Iteration,
            ClassKind.ModellingThingReference,
            ClassKind.ModelLogEntry,
            ClassKind.Page,
            ClassKind.RequestForDeviation,
            ClassKind.RequestForWaiver,
            ClassKind.ReviewItemDiscrepancy,
            ClassKind.Section,
            ClassKind.Solution,
            ClassKind.TextualNote,
            ClassKind.EngineeringModel
        };
    }
}
