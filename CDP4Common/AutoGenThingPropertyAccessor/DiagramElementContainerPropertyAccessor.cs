// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramElementContainerPropertyAccessor.cs" company="Starion Group S.A.">
//    Copyright (c) 2015-2024 Starion Group S.A.
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
    public partial class DiagramElementContainer
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
                case "container":
                    return base.QueryThingValues(pd.Input);
                case "bounds":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var boundsUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && boundsUpperBound == int.MaxValue && !this.Bounds.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Bounds>();
                        }

                        var sentinelBounds = new Bounds(Guid.Empty, null, null);

                        return sentinelBounds.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        boundsUpperBound = this.Bounds.Count - 1;
                    }

                    if (this.Bounds.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Bounds property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Bounds.Count - 1 < boundsUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Bounds property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Bounds[pd.Lower.Value];
                        }

                        return this.Bounds[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var boundsObjects = new List<Bounds>();

                        for (var i = pd.Lower.Value; i < boundsUpperBound + 1; i++)
                        {
                            boundsObjects.Add(this.Bounds[i]);
                        }

                        return boundsObjects;
                    }

                    var boundsNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < boundsUpperBound + 1; i++)
                    {
                        var queryResult = this.Bounds[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    boundsNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                boundsNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return boundsNextObjects;
                case "diagramelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var diagramElementUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && diagramElementUpperBound == int.MaxValue && !this.DiagramElement.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<DiagramElementThing>();
                        }

                        var sentinelDiagramElementThing = new DiagramEdge(Guid.Empty, null, null);

                        return sentinelDiagramElementThing.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        diagramElementUpperBound = this.DiagramElement.Count - 1;
                    }

                    if (this.DiagramElement.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for DiagramElement property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.DiagramElement.Count - 1 < diagramElementUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the DiagramElement property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.DiagramElement[pd.Lower.Value];
                        }

                        return this.DiagramElement[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var diagramElementObjects = new List<DiagramElementThing>();

                        for (var i = pd.Lower.Value; i < diagramElementUpperBound + 1; i++)
                        {
                            diagramElementObjects.Add(this.DiagramElement[i]);
                        }

                        return diagramElementObjects;
                    }

                    var diagramElementNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < diagramElementUpperBound + 1; i++)
                    {
                        var queryResult = this.DiagramElement[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    diagramElementNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                diagramElementNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return diagramElementNextObjects;
                case "name":
                    return base.QueryValue(pd.Input);
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
                case "bounds":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Bounds.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Bounds boundsValue:
                            this.Bounds.Clear();
                            this.Bounds.Add(boundsValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Bounds.Clear();
                            this.Bounds.AddRange(thingValues.OfType<Bounds>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Bounds or a collection of Bounds" , nameof(value));
                    }
                case "diagramelement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.DiagramElement.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case DiagramElementThing diagramElementValue:
                            this.DiagramElement.Clear();
                            this.DiagramElement.Add(diagramElementValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.DiagramElement.Clear();
                            this.DiagramElement.AddRange(thingValues.OfType<DiagramElementThing>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DiagramElementThing or a collection of DiagramElementThing" , nameof(value));
                    }
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
