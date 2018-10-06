// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheKey.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2018 RHEA System S.A.
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

namespace CDP4Common.Types
{
    using System;

    /// <summary>
    /// Represents the key of the Cache
    /// </summary>
    /// <remarks>
    /// This struct is optimized for performance to make the ConcurrentDictionary lookups fast. The readonly/immutable fields
    /// are used to compute the HashCode of the struct.
    /// </remarks>
    public struct CacheKey : IEquatable<CacheKey>
    {
        /// <summary>
        /// readonly backing field for the <see cref="Thing"/> property
        /// </summary>
        /// <remarks>
        /// readonly properties are used to ensure the GetHashCode() function always returns the same value 
        /// </remarks>
        private readonly Guid thing;
        
        /// <summary>
        /// readonly backing field for the <see cref="Iteration"/> property
        /// </summary>
        /// <remarks>
        /// readonly properties are used to ensure the GetHashCode() function always returns the same value 
        /// </remarks>
        private readonly Guid? iteration;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheKey"/> struct.
        /// </summary>
        /// <param name="thing">
        /// The unique identifier of the <see cref="CDP4Common.CommonData.Thing"/> that is cached
        /// </param>
        /// <param name="iteration">
        /// The unique identifier of the container <see cref="CDP4Common.EngineeringModelData.Iteration"/> that is cached
        /// </param>
        public CacheKey(Guid thing, Guid? iteration)
        {
            this.thing = thing;
            this.iteration = iteration;
        }

        /// <summary>
        /// Gets the unique identifier of the <see cref="CDP4Common.CommonData.Thing"/> that is represented by the key
        /// </summary>
        public Guid Thing
        {
            get { return this.thing; }
        }

        /// <summary>
        /// Gets the nullable unique identifier of the <see cref="CDP4Common.EngineeringModelData.Iteration"/> that is the container of the
        /// cached <see cref="Thing"/>
        /// </summary>
        public Guid? Iteration
        {
            get { return this.iteration; }
        }

        /// <summary>
        /// Implementation of the == operator
        /// </summary>
        /// <param name="left">
        /// the left CacheKey of the == operation
        /// </param>
        /// <param name="right">
        /// the right CacheKey of the == operation
        /// </param>
        /// <returns>
        /// true if left and right are the same; false if not
        /// </returns>
        public static bool operator ==(CacheKey left, CacheKey right)
        {
            return Equals(left, right);
        }

        /// <summary>
        /// Implementation of the != operator
        /// </summary>
        /// <param name="left">
        /// the left CacheKey of the != operation
        /// </param>
        /// <param name="right">
        /// the right CacheKey of the 1= operation
        /// </param>
        /// <returns>
        /// true if left and right are the  the same; true if not
        /// </returns>
        public static bool operator !=(CacheKey left, CacheKey right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">
        /// The object to compare with the current instance.
        /// </param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public override bool Equals(object other)
        {
            return (other is CacheKey cacheKey) && Equals(cacheKey);
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="other">
        /// The <see cref="CacheKey"/> to compare with the current instance.
        /// </param>
        /// <returns>
        /// true if obj and this instance are the same type and represent the same value; otherwise, false.
        /// </returns>
        public bool Equals(CacheKey other)
        {
            return this.Thing.Equals(other.Thing) && this.Iteration.Equals(other.Iteration);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        public override int GetHashCode()
        {
            return (this.thing, this.iteration).GetHashCode();
        }
    }
}