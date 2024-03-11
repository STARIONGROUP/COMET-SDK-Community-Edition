// ------------------------------------------------------------------------------------------------
// <copyright file="DiagrammingStylePropertyAccessor.cs" company="RHEA System S.A.">
//    Copyright (c) 2015-2023 RHEA System S.A.
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
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace CDP4Common.DiagramData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using CDP4Common.CommonData;
    using CDP4Common.DiagramData;
    using CDP4Common.EngineeringModelData;
    using CDP4Common.PropertyAccesor;
    using CDP4Common.ReportingData;
    using CDP4Common.SiteDirectoryData;
    using CDP4Common.Types;

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class DiagrammingStyle
    {
        /// <summary>
        /// Queries the value(s) of the specified property
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <returns>
        /// an object that represents the value.
        /// </returns>
        /// <remarks>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof
        /// </remarks>
        public override object QueryValue(string path)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    return base.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return base.QueryThingValues(pd.Input);
                case "classkind":
                    return base.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return base.QueryThingValues(pd.Input);
                case "excludedperson":
                    return base.QueryThingValues(pd.Input);
                case "modifiedon":
                    return base.QueryThingValues(pd.Input);
                case "thingpreference":
                    return base.QueryThingValues(pd.Input);
                case "actor":
                    return base.QueryThingValues(pd.Input);
                case "fillcolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.FillColor;
                    }

                    if (this.FillColor != null)
                    {
                        return this.FillColor.QueryValue(pd.Next.Input);
                    }

                    var sentinelfillcolor = new Color(Guid.Empty, null, null);
                    return sentinelfillcolor.QuerySentinelValue(pd.Next.Input, false);
                case "fillopacity":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FillOpacity;
                case "fontbold":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontBold;
                case "fontcolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.FontColor;
                    }

                    if (this.FontColor != null)
                    {
                        return this.FontColor.QueryValue(pd.Next.Input);
                    }

                    var sentinelfontcolor = new Color(Guid.Empty, null, null);
                    return sentinelfontcolor.QuerySentinelValue(pd.Next.Input, false);
                case "fontitalic":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontItalic;
                case "fontname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontName;
                case "fontsize":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontSize;
                case "fontstrokethrough":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontStrokeThrough;
                case "fontunderline":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.FontUnderline;
                case "name":
                    return base.QueryValue(pd.Input);
                case "strokecolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.StrokeColor;
                    }

                    if (this.StrokeColor != null)
                    {
                        return this.StrokeColor.QueryValue(pd.Next.Input);
                    }

                    var sentinelstrokecolor = new Color(Guid.Empty, null, null);
                    return sentinelstrokecolor.QuerySentinelValue(pd.Next.Input, false);
                case "strokeopacity":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.StrokeOpacity;
                case "strokewidth":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.StrokeWidth;
                case "usedcolor":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var usedColorUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && usedColorUpperBound == int.MaxValue && !this.UsedColor.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Color>();
                        }

                        var sentinelColor = new Color(Guid.Empty, null, null);

                        return sentinelColor.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        usedColorUpperBound = this.UsedColor.Count - 1;
                    }

                    if (this.UsedColor.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for UsedColor property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.UsedColor.Count - 1 < usedColorUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the UsedColor property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.UsedColor[pd.Lower.Value];
                        }

                        return this.UsedColor[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var usedColorObjects = new List<Color>();

                        for (var i = pd.Lower.Value; i < usedColorUpperBound + 1; i++)
                        {
                            usedColorObjects.Add(this.UsedColor[i]);
                        }

                        return usedColorObjects;
                    }

                    var usedColorNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < usedColorUpperBound + 1; i++)
                    {
                        var queryResult = this.UsedColor[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    usedColorNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                usedColorNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return usedColorNextObjects;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }

        /// <summary>
        /// Sets the value of the specified property
        /// </summary>
        /// <param name="path">The path of the property for which the value is to be set</param>
        /// <param name="value">Any value to set</param>
        /// <exception cref="ArgumentException">If the type of the <paramref name="value"/> do not match the type of the property to set</exception>
        /// <remarks>This action override the currently set value, if any</remarks>
        public override void SetValue(string path, object value)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);
            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "revisionnumber":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "classkind":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludeddomain":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "excludedperson":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "modifiedon":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "thingpreference":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "actor":
                    this.SetThingValue(pd.Input, value);
                    return;
                case "fillcolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Color fillColorValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Color" , nameof(value));
                    }

                    this.FillColor = fillColorValue;
                    return;
                case "fillopacity":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FillOpacity = null;
                        return;
                    }

                    if(!(value is float fillOpacityValue || (value is string fillOpacityString) && float.TryParse(fillOpacityString, out fillOpacityValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a float" , nameof(value));
                    }

                    this.FillOpacity = fillOpacityValue;
                    return;
                case "fontbold":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontBold = null;
                        return;
                    }

                    if(!(value is bool fontBoldValue || (value is string fontBoldString) && bool.TryParse(fontBoldString, out fontBoldValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.FontBold = fontBoldValue;
                    return;
                case "fontcolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Color fontColorValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Color" , nameof(value));
                    }

                    this.FontColor = fontColorValue;
                    return;
                case "fontitalic":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontItalic = null;
                        return;
                    }

                    if(!(value is bool fontItalicValue || (value is string fontItalicString) && bool.TryParse(fontItalicString, out fontItalicValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.FontItalic = fontItalicValue;
                    return;
                case "fontname":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontName = null;
                        return;
                    }

                    if(!(value is string fontNameValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string" , nameof(value));
                    }

                    this.FontName = fontNameValue;
                    return;
                case "fontsize":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontSize = null;
                        return;
                    }

                    if(!(value is float fontSizeValue || (value is string fontSizeString) && float.TryParse(fontSizeString, out fontSizeValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a float" , nameof(value));
                    }

                    this.FontSize = fontSizeValue;
                    return;
                case "fontstrokethrough":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontStrokeThrough = null;
                        return;
                    }

                    if(!(value is bool fontStrokeThroughValue || (value is string fontStrokeThroughString) && bool.TryParse(fontStrokeThroughString, out fontStrokeThroughValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.FontStrokeThrough = fontStrokeThroughValue;
                    return;
                case "fontunderline":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.FontUnderline = null;
                        return;
                    }

                    if(!(value is bool fontUnderlineValue || (value is string fontUnderlineString) && bool.TryParse(fontUnderlineString, out fontUnderlineValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a bool" , nameof(value));
                    }

                    this.FontUnderline = fontUnderlineValue;
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "strokecolor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Color strokeColorValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Color" , nameof(value));
                    }

                    this.StrokeColor = strokeColorValue;
                    return;
                case "strokeopacity":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.StrokeOpacity = null;
                        return;
                    }

                    if(!(value is float strokeOpacityValue || (value is string strokeOpacityString) && float.TryParse(strokeOpacityString, out strokeOpacityValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a float" , nameof(value));
                    }

                    this.StrokeOpacity = strokeOpacityValue;
                    return;
                case "strokewidth":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        this.StrokeWidth = null;
                        return;
                    }

                    if(!(value is float strokeWidthValue || (value is string strokeWidthString) && float.TryParse(strokeWidthString, out strokeWidthValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a float" , nameof(value));
                    }

                    this.StrokeWidth = strokeWidthValue;
                    return;
                case "usedcolor":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.UsedColor.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Color usedColorValue:
                            this.UsedColor.Clear();
                            this.UsedColor.Add(usedColorValue);
                            return;
                        case IEnumerable<Color> usedColorValues:
                            this.UsedColor.Clear();
                            this.UsedColor.AddRange(usedColorValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Color or a collection of Color" , nameof(value));
                    }
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
