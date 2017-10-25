// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IISession.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Dal
{
    /// <summary>
    /// Definition of an interface that exposes a <see cref="ISession"/> property
    /// </summary>
    public interface IISession
    {
        /// <summary>
        /// Gets the <see cref="ISession"/>
        /// </summary>
        ISession Session { get;  }
    }
}
