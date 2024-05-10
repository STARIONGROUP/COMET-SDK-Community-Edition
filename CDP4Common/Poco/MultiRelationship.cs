// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MultiRelationship.cs" company="Starion Group S.A.">
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

namespace CDP4Common.EngineeringModelData
{
    /// <summary>
    /// The extended-part for the <see cref="MultiRelationship"/> class
    /// </summary>
    public partial class MultiRelationship
    {
        /// <summary>
        /// Perform extra operations on a <see cref="MultiRelationship"/>
        /// </summary>
        protected override void ResolveExtraProperties()
        {
            foreach (var thing in this.RelatedThing)
            {
                thing?.Relationships.Add(this);
            }
        }

        /// <summary>
        /// Clean the referenced Thing list of <see cref="Relationship"/> of this <see cref="Relationship"/>
        /// </summary>
        public override void CleanReferencedThingRelationship()
        {
            foreach (var thing in this.RelatedThing)
            {
                thing?.Relationships.Remove(this);
            }
        }
    }
}