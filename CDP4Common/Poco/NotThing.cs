// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotThing.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2020 RHEA System S.A.
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
    using CDP4Common.CommonData;

    /// <summary>
    /// Represent an object of the CDP4 application but is not a 10-25 Thing
    /// </summary>
    public class NotThing : Thing
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotThing"/> class
        /// </summary>
        /// <param name="name">The Name</param>
        public NotThing(string name)
        {
            this.Name = name;
            this.Container = null;
        }

        /// <summary>
        /// Gets the Name of this <see cref="NotThing"/>
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Clones the current <see cref="Thing"/>
        /// </summary>
        /// <param name="cloneContainedThings">A value indicating whether the contained things should be cloned</param>
        /// <returns>The clone</returns>
        /// <exception cref="NotSupportedException">The methos is not supported by this class</exception>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// The Nothing class does not support the ResolveProperties method
        /// </summary>
        /// <exception cref="NotSupportedException">The methos is not supported by this class</exception>
        internal override void ResolveProperties(DTO.Thing dto)
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Creates <see cref="DTO.Thing"/> from the current <see cref="Thing"/>
        /// </summary>
        /// <returns>The <see cref="CDP4Common.DTO.Thing"/></returns>
        /// <exception cref="NotSupportedException">The methos is not supported by this class</exception>
        public override DTO.Thing ToDto()
        {
            throw new NotSupportedException();
        }
    }
}