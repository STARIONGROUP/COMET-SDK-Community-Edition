// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InterfaceEndKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// enumeration datatype that asserts whether an ElementUsage is an interface end, and if so, what kind of role the interface end fulfillsNote: An <i>interface end</i> is one side of an interface. A complete interface consists of at least two interface ends and a connection between them.
    /// </summary>
    public enum InterfaceEndKind
    {
        /// <summary>
        /// not an interface end
        /// </summary>
        NONE,

        /// <summary>
        /// general undirected interface endExample: For example a mechanical mounting plate.
        /// </summary>
        UNDIRECTED,

        /// <summary>
        /// interface end that acts as an input for its <i>containingElement</i> ElementDefinitionExample: For example a power inlet socket.
        /// </summary>
        INPUT,

        /// <summary>
        /// interface end that acts as an output for its <i>containingElement</i> ElementDefinitionExample: For example a signal output connector on a sensor.
        /// </summary>
        OUTPUT,

        /// <summary>
        /// interface end that acts both as an input and an output for its <i>containingElement</i> ElementDefinitionExample: For example an Ethernet port on an electronic device.
        /// </summary>
        IN_OUT,
    }
}
