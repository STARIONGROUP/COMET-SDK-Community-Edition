// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAttribute.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common
{
    using System;

    /// <summary>
    /// The purpose of the <see cref="ContainerAttribute"/> is to decorate classes that take part in a Composition
    /// relationship at the contained end. The <see cref="ContainerAttribute"/> has a property that specifies the name
    /// of the container property that contains the current class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ContainerAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerAttribute"/> class.
        /// </summary>
        /// <param name="classType">
        /// The <see cref="Type"/> of the container
        /// </param>
        /// <param name="propertyName">
        /// The name of the container property
        /// </param>
        public ContainerAttribute(Type classType, string propertyName)
        {
            this.ClassType = classType;
            this.PropertyName = propertyName;
        }

        /// <summary>
        /// Gets the <see cref="Type"/> of the container
        /// </summary>
        public Type ClassType { get; private set; }

        /// <summary>
        /// Gets the name of the container property
        /// </summary>
        public string PropertyName { get; private set; }
    }
}
