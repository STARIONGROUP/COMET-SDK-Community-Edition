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
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
