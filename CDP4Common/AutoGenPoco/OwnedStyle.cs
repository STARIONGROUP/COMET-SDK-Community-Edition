// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyle.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2025 Starion Group S.A.
//
//    Author: Sam Gerené, Alex Vorobiev, Alexander van Delft, Nathanael Smiechowski, 
//            Antoine Théate, Omar Elebiary, Jaime Bernar
//
//    This file is part of CDP4-COMET SDK Community Edition
//    This is an auto-generated class. Any manual changes to this file will be overwritten!
//
//    The CDP4-COMET SDK Community Edition is free software; you can redistribute it and/or
//    modify it under the terms of the GNU Lesser General Public
//    License as published by the Free Software Foundation; either
//    version 3 of the License, or (at your option) any later version.
//
//    The CDP4-COMET SDK Community Edition is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//    Lesser General Public License for more details.
//
//    You should have received a copy of the GNU Lesser General Public License
//    along with this program; if not, write to the Free Software Foundation,
//    Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
// --------------------------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.DiagramData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// The style owned by a DiagramElementThing
    /// </summary>
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementThing), "LocalStyle")]
    public partial class OwnedStyle : DiagrammingStyle
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.SAME_AS_CONTAINER;

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnedStyle"/> class.
        /// </summary>
        public OwnedStyle()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OwnedStyle"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="CacheKey"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        public OwnedStyle(Guid iid, ConcurrentDictionary<CacheKey, Lazy<CommonData.Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="OwnedStyle"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="OwnedStyle"/>.
        /// </returns>
        protected override Thing GenericClone(bool cloneContainedThings)
        {
            var clone = (OwnedStyle)this.MemberwiseClone();
            clone.ExcludedDomain = new List<DomainOfExpertise>(this.ExcludedDomain);
            clone.ExcludedPerson = new List<Person>(this.ExcludedPerson);
            clone.UsedColor = cloneContainedThings ? new ContainerList<Color>(clone) : new ContainerList<Color>(this.UsedColor, clone);

            if (cloneContainedThings)
            {
                clone.UsedColor.AddRange(this.UsedColor.Select(x => x.Clone(true)));
            }

            clone.Original = this;
            clone.ResetCacheId();
            return clone;
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="OwnedStyle"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="OwnedStyle"/>.
        /// </returns>
        public new OwnedStyle Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (OwnedStyle)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="OwnedStyle"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }

        /// <summary>
        /// Resolve the properties of the current <see cref="OwnedStyle"/> from its <see cref="DTO.Thing"/> counter-part
        /// </summary>
        /// <param name="dtoThing">The source <see cref="DTO.Thing"/></param>
        internal override void ResolveProperties(DTO.Thing dtoThing)
        {
            if (dtoThing == null)
            {
                throw new ArgumentNullException("dtoThing");
            }

            var dto = dtoThing as DTO.OwnedStyle;
            if (dto == null)
            {
                throw new InvalidOperationException($"The DTO type {dtoThing.GetType()} does not match the type of the current OwnedStyle POCO.");
            }

            this.Actor = (dto.Actor.HasValue) ? this.Cache.Get<Person>(dto.Actor.Value, dto.IterationContainerId) : null;
            this.ExcludedDomain.ResolveList(dto.ExcludedDomain, dto.IterationContainerId, this.Cache);
            this.ExcludedPerson.ResolveList(dto.ExcludedPerson, dto.IterationContainerId, this.Cache);
            this.FillColor = (dto.FillColor.HasValue) ? this.Cache.Get<Color>(dto.FillColor.Value, dto.IterationContainerId) : null;
            this.FillOpacity = dto.FillOpacity;
            this.FontBold = dto.FontBold;
            this.FontColor = (dto.FontColor.HasValue) ? this.Cache.Get<Color>(dto.FontColor.Value, dto.IterationContainerId) : null;
            this.FontItalic = dto.FontItalic;
            this.FontName = dto.FontName;
            this.FontSize = dto.FontSize;
            this.FontStrokeThrough = dto.FontStrokeThrough;
            this.FontUnderline = dto.FontUnderline;
            this.ModifiedOn = dto.ModifiedOn;
            this.Name = dto.Name;
            this.RevisionNumber = dto.RevisionNumber;
            this.StrokeColor = (dto.StrokeColor.HasValue) ? this.Cache.Get<Color>(dto.StrokeColor.Value, dto.IterationContainerId) : null;
            this.StrokeOpacity = dto.StrokeOpacity;
            this.StrokeWidth = dto.StrokeWidth;
            this.ThingPreference = dto.ThingPreference;
            this.UsedColor.ResolveList(dto.UsedColor, dto.IterationContainerId, this.Cache);

            this.ResolveExtraProperties();
        }

        /// <summary>
        /// Generates a <see cref="DTO.Thing"/> from the current <see cref="OwnedStyle"/>
        /// </summary>
        public override DTO.Thing ToDto()
        {
            var dto = new DTO.OwnedStyle(this.Iid, this.RevisionNumber);

            dto.Actor = this.Actor != null ? (Guid?)this.Actor.Iid : null;
            dto.ExcludedDomain.AddRange(this.ExcludedDomain.Select(x => x.Iid));
            dto.ExcludedPerson.AddRange(this.ExcludedPerson.Select(x => x.Iid));
            dto.FillColor = this.FillColor != null ? (Guid?)this.FillColor.Iid : null;
            dto.FillOpacity = this.FillOpacity;
            dto.FontBold = this.FontBold;
            dto.FontColor = this.FontColor != null ? (Guid?)this.FontColor.Iid : null;
            dto.FontItalic = this.FontItalic;
            dto.FontName = this.FontName;
            dto.FontSize = this.FontSize;
            dto.FontStrokeThrough = this.FontStrokeThrough;
            dto.FontUnderline = this.FontUnderline;
            dto.ModifiedOn = this.ModifiedOn;
            dto.Name = this.Name;
            dto.RevisionNumber = this.RevisionNumber;
            dto.StrokeColor = this.StrokeColor != null ? (Guid?)this.StrokeColor.Iid : null;
            dto.StrokeOpacity = this.StrokeOpacity;
            dto.StrokeWidth = this.StrokeWidth;
            dto.ThingPreference = this.ThingPreference;
            dto.UsedColor.AddRange(this.UsedColor.Select(x => x.Iid));

            dto.IterationContainerId = this.CacheKey.Iteration;
            dto.RegisterSourceThing(this);
            this.BuildDtoPartialRoutes(dto);
            return dto;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
