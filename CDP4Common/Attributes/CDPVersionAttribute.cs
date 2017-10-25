// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CDPVersionAttribute.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="CDPVersion"/> attribute is to decorated Classes and properties
    /// that constiute CDP4 extensions to the ECSS-E-TM-10-25 class library
    /// </summary>
    /// <remarks>
    /// A POCO or DTO Class or Property that is not decorated with this class
    /// is a vanila ECSS-E-TM-10-25 class or property. Valinla ECSS-E-TM-10-25 class may have
    /// properties decorated with this attribute.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, AllowMultiple = false)]
    public class CDPVersionAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CDPVersion"/> class.
        /// </summary>
        /// <param name="version">
        /// The version identifier
        /// </param>
        public CDPVersionAttribute(string version)
        {
            if (string.IsNullOrEmpty(version))
            {
                throw new ArgumentNullException(version, "The version may not be null or empty");
            }

            this.Version = version;
        }

        /// <summary>
        /// Gets the version of the CDP4 data-model that the decorated
        /// class or property belongs to.
        /// </summary>
        public string Version { get; private set; }
    }
}
