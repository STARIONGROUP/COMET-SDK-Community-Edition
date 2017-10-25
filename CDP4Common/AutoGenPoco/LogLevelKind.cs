// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogLevelKind.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated Enumeration. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.CommonData
{
    /// <summary>
    /// enumeration datatype that defines the possible levels for a LogEntry
    /// </summary>
    public enum LogLevelKind
    {
        /// <summary>
        /// designation of a trace level log entry used to mark and annotate very low level detailed event logging for software development or problem fixing purposes
        /// </summary>
        TRACE,

        /// <summary>
        /// designation of a debug level log entry used to mark and annotate low level detailed event logging for software development or problem fixing purposes
        /// </summary>
        DEBUG,

        /// <summary>
        /// designation of an information level log entry used to mark and annotate event logging for informationNote: Information level LogEntry instances are typically produced automatically by executing applications.
        /// </summary>
        INFO,

        /// <summary>
        /// designation of a user level log entry used to mark and annotate event logging with user defined contentNote: User level LogEntry instances are typically produced on demand by a human user and its <i>content</i> is typically manually written. Its use is similar to the log message used upon commit or check-in in a configuration control system.
        /// </summary>
        USER,
    }
}
