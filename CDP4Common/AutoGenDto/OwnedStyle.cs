// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OwnedStyle.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated DTO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DTO
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// A Data Transfer Object representation of the <see cref="OwnedStyle"/> class.
    /// </summary>
    [DataContract]
    [CDPVersion("1.1.0")]
    [Container(typeof(DiagramElementThing), "LocalStyle")]
    public sealed partial class OwnedStyle : DiagrammingStyle
    {
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
        /// <param name="rev">
        /// The revision number.
        /// </param>
        public OwnedStyle(Guid iid, int rev) : base(iid: iid, rev: rev)
        {
        }

        /// <summary>
        /// Gets the route for the current <see ref="OwnedStyle"/>.
        /// </summary>
        public override string Route
        {
            get { return this.ComputedRoute(); }
        }

        /// <summary>
        /// Instantiate a <see cref="CDP4Common.DiagramData.OwnedStyle"/> from a <see cref="OwnedStyle"/>
        /// </summary>
        /// <param name="cache">The cache that stores all the <see cref="CommonData.Thing"/>s</param>.
        /// <param name="uri">The <see cref="Uri"/> of the <see cref="CDP4Common.DiagramData.OwnedStyle"/></param>.
        /// <returns>A new <see cref="CommonData.Thing"/></returns>
        public override CommonData.Thing InstantiatePoco(ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<CommonData.Thing>> cache, Uri uri)
        {
            return new CDP4Common.DiagramData.OwnedStyle(this.Iid, cache, uri);
        }

        /// <summary>
        /// Resolves the properties of a copied <see cref="Thing"/> based on the original and a collection of copied <see cref="Thing"/>.
        /// </summary>
        /// <param name="originalThing">The original <see cref="Thing"/></param>.
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        public override void ResolveCopy(Thing originalThing, IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var original = originalThing as OwnedStyle;
            if (original == null)
            {
                throw new InvalidOperationException("The originalThing cannot be null or is of the incorrect type");
            }

            foreach (var guid in original.ExcludedDomain)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedDomain.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            foreach (var guid in original.ExcludedPerson)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                this.ExcludedPerson.Add(copy.Value == null ? guid : copy.Value.Iid);
            }

            var copyFillColor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.FillColor);
            this.FillColor = copyFillColor.Value == null ? original.FillColor : copyFillColor.Value.Iid;

            this.FillOpacity = original.FillOpacity;

            this.FontBold = original.FontBold;

            var copyFontColor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.FontColor);
            this.FontColor = copyFontColor.Value == null ? original.FontColor : copyFontColor.Value.Iid;

            this.FontItalic = original.FontItalic;

            this.FontName = original.FontName;

            this.FontSize = original.FontSize;

            this.FontStrokeThrough = original.FontStrokeThrough;

            this.FontUnderline = original.FontUnderline;

            this.ModifiedOn = original.ModifiedOn;

            this.Name = original.Name;

            var copyStrokeColor = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == original.StrokeColor);
            this.StrokeColor = copyStrokeColor.Value == null ? original.StrokeColor : copyStrokeColor.Value.Iid;

            this.StrokeOpacity = original.StrokeOpacity;

            this.StrokeWidth = original.StrokeWidth;

            foreach (var guid in original.UsedColor)
            {
                var copy = originalCopyMap.SingleOrDefault(kvp => kvp.Key.Iid == guid);
                if (Equals(copy, default(KeyValuePair<Thing, Thing>)))
                {
                    throw new InvalidOperationException(string.Format("The copy could not be found for {0}", guid));
                }

                this.UsedColor.Add(copy.Value.Iid);
            }
        }

        /// <summary>
        /// Resolves the references of a copied <see cref="Thing"/> based on a original to copy map.
        /// </summary>
        /// <param name="originalCopyMap">The map containig all instance of copied <see cref="Thing"/>s with their original</param>.
        /// <returns>True if a modification was done in the process of this method</returns>.
        public override bool ResolveCopyReference(IReadOnlyDictionary<Thing, Thing> originalCopyMap)
        {
            var hasChanges = false;

            return hasChanges;
        }
    }
}
