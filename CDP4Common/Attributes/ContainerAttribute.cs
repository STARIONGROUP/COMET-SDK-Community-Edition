﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContainerAttribute.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
//
//    Author: Sam Gerené, Merlin Bieze, Alex Vorobiev, Naron Phou
//
//    This file is part of CDP4-SDK Community Edition
//
//    The CDP4-SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
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