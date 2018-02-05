// -------------------------------------------------------------------------------------------------
// <copyright file="NotThing.cs" company="RHEA System S.A.">
//   Copyright (c) 2017-2018 RHEA System S.A.
// </copyright>
// -------------------------------------------------------------------------------------------------

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