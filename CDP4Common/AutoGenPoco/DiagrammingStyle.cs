// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiagrammingStyle.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// <summary>
//   This is an auto-generated POCO Class. Any manual changes to this file will be overwritten!
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.DiagramData
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.Serialization;
    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.Helpers;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Contains formatting properties that affect the appearance or style of diagram elements, including diamgram themselves
    /// </summary>
    [CDPVersion("1.1.0")]
    public abstract partial class DiagrammingStyle : DiagramThingBase
    {
        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const PersonAccessRightKind DefaultPersonAccess = PersonAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Representation of the default value for the accessRight property of a PersonPermission for the affected class
        /// </summary>
        public new const ParticipantAccessRightKind DefaultParticipantAccess = ParticipantAccessRightKind.NOT_APPLICABLE;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagrammingStyle"/> class.
        /// </summary>
        protected DiagrammingStyle()
        {
            this.UsedColor = new ContainerList<Color>(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagrammingStyle"/> class.
        /// </summary>
        /// <param name="iid">
        /// The unique identifier.
        /// </param>
        /// <param name="cache">
        /// The <see cref="ConcurrentDictionary{T, U}"/> where the current thing is stored.
        /// The <see cref="Tuple{T}"/> of <see cref="Guid"/> and <see cref="Nullable{Guid}"/> is the key used to store this thing.
        /// The key is a combination of this thing's identifier and the identifier of its <see cref="Iteration"/> container if applicable or null.
        /// </param>
        /// <param name="iDalUri">
        /// The <see cref="Uri"/> of this thing
        /// </param>
        protected DiagrammingStyle(Guid iid, ConcurrentDictionary<Tuple<Guid, Guid?>, Lazy<Thing>> cache, Uri iDalUri) : base(iid, cache, iDalUri)
        {
            this.UsedColor = new ContainerList<Color>(this);
        }

        /// <summary>
        /// Gets or sets the FillColor.
        /// </summary>
        /// <remarks>
        /// a color that is used to paint the enclosed regions of graphical element. A fillColor value is
        /// exclusive with a fill value. If both are specified, the fill value is used. If none is specified, no fill is applied (i.e., the
        /// element becomes see-through).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Color FillColor { get; set; }

        /// <summary>
        /// Gets or sets the FillOpacity.
        /// </summary>
        /// <remarks>
        /// a real number (>=0 and <=1) representing the opacity of the fill or fillColor used to paint a
        /// graphical element. A value of 0 means totally transparent, while a value of 1 means totally opaque. The default is 1.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual float? FillOpacity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether FontBold.
        /// </summary>
        /// <remarks>
        /// whether the font used to render a text element has a bold style. The default is false.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual bool? FontBold { get; set; }

        /// <summary>
        /// Gets or sets the FontColor.
        /// </summary>
        /// <remarks>
        /// the color of the font used to render a text element. The default is black (red=0, green=0,
        /// blue=0).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Color FontColor { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether FontItalic.
        /// </summary>
        /// <remarks>
        /// whether the font used to render a text element has an italic style. The default is false.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual bool? FontItalic { get; set; }

        /// <summary>
        /// Gets or sets the FontName.
        /// </summary>
        /// <remarks>
        /// the name of the font used to render a text element (e.g., “Times New Roman,” “Arial,” or
        /// “Helvetica”). The default is “Arial.”
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual string FontName { get; set; }

        /// <summary>
        /// Gets or sets the FontSize.
        /// </summary>
        /// <remarks>
        /// a real number (>=0) representing the size (in unit of length) of the font used to render a text
        /// element. The default is 10.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual float? FontSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether FontStrokeThrough.
        /// </summary>
        /// <remarks>
        /// whether the font used to render a text element has a strike-through style. The
        /// default is false.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual bool? FontStrokeThrough { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether FontUnderline.
        /// </summary>
        /// <remarks>
        /// whether the font used to render a text element has an underline style. The default is
        /// false.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual bool? FontUnderline { get; set; }

        /// <summary>
        /// Gets or sets the StrokeColor.
        /// </summary>
        /// <remarks>
        /// the color of the stroke used to paint the outline of a graphical element. The default is black
        /// (red=0, green=0, blue=0).
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual Color StrokeColor { get; set; }

        /// <summary>
        /// Gets or sets the StrokeOpacity.
        /// </summary>
        /// <remarks>
        /// a real number (>=0 and <=1) representing the opacity of the stroke used for a graphical
        /// element. A value of 0 means totally transparent, while a value of 1 means totally opaque. The default is 1.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual float? StrokeOpacity { get; set; }

        /// <summary>
        /// Gets or sets the StrokeWidth.
        /// </summary>
        /// <remarks>
        /// a real number (>=0) representing the width of the stroke used to paint the outline of a
        /// graphical element. A value of 0 specifies no stroke is painted. The default is 1.
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.None, isDerived: false, isOrdered: false, isNullable: true, isPersistent: true)]
        public virtual float? StrokeWidth { get; set; }

        /// <summary>
        /// Gets or sets a list of contained Color.
        /// </summary>
        /// <remarks>
        /// The colors used in this style
        /// </remarks>
        [UmlInformation(aggregation: AggregationKind.Composite, isDerived: false, isOrdered: false, isNullable: false, isPersistent: true)]
        public virtual ContainerList<Color> UsedColor { get; protected set; }

        /// <summary>
        /// Gets an <see cref="IEnumerable{IEnumerable}"/> that references the composite properties of the current <see cref="DiagrammingStyle"/>.
        /// </summary>
        public override IEnumerable<IEnumerable> ContainerLists
        {
            get 
            {
                var containers = new List<IEnumerable>(base.ContainerLists);
                containers.Add(this.UsedColor);
                return containers;
            }
        }

        /// <summary>
        /// Creates and returns a copy of this <see cref="DiagrammingStyle"/> for edit purpose.
        /// </summary>
        /// <param name="cloneContainedThings">A value that indicates whether the contained <see cref="Thing"/>s should be cloned or not.</param>
        /// <returns>
        /// A cloned instance of <see cref="DiagrammingStyle"/>.
        /// </returns>
        public new DiagrammingStyle Clone(bool cloneContainedThings)
        {
            this.ChangeKind = ChangeKind.Update;
            return (DiagrammingStyle)this.GenericClone(cloneContainedThings);
        }

        /// <summary>
        /// Validates the cardinalities of the properties of this <see cref="DiagrammingStyle"/>.
        /// </summary>
        /// <returns>
        /// A list of potential errors.
        /// </returns>
        protected override IEnumerable<string> ValidatePocoCardinality()
        {
            var errorList = new List<string>(base.ValidatePocoCardinality());

            return errorList;
        }
    }
}
