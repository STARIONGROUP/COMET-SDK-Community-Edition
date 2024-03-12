// ------------------------------------------------------------------------------------------------
// <copyright file="ParameterOrOverrideBasePropertyAccessor.cs" company="RHEA System S.A.">
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

namespace CDP4Common.EngineeringModelData
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
    public partial class ParameterOrOverrideBase
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
                    return this.QueryThingValues(pd.Input);
                case "revisionnumber":
                    return this.QueryThingValues(pd.Input);
                case "classkind":
                    return this.QueryThingValues(pd.Input);
                case "excludeddomain":
                    return this.QueryThingValues(pd.Input);
                case "excludedperson":
                    return this.QueryThingValues(pd.Input);
                case "modifiedon":
                    return this.QueryThingValues(pd.Input);
                case "thingpreference":
                    return this.QueryThingValues(pd.Input);
                case "actor":
                    return this.QueryThingValues(pd.Input);
                case "container":
                    return this.QueryThingValues(pd.Input);
                case "group":
                    return base.QueryValue(pd.Input);
                case "isoptiondependent":
                    return base.QueryValue(pd.Input);
                case "owner":
                    return base.QueryValue(pd.Input);
                case "parametersubscription":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var parameterSubscriptionUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && parameterSubscriptionUpperBound == int.MaxValue && !this.ParameterSubscription.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ParameterSubscription>();
                        }

                        var sentinelParameterSubscription = new ParameterSubscription(Guid.Empty, null, null);

                        return sentinelParameterSubscription.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        parameterSubscriptionUpperBound = this.ParameterSubscription.Count - 1;
                    }

                    if (this.ParameterSubscription.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ParameterSubscription property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ParameterSubscription.Count - 1 < parameterSubscriptionUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ParameterSubscription property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ParameterSubscription[pd.Lower.Value];
                        }

                        return this.ParameterSubscription[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var parameterSubscriptionObjects = new List<ParameterSubscription>();

                        for (var i = pd.Lower.Value; i < parameterSubscriptionUpperBound + 1; i++)
                        {
                            parameterSubscriptionObjects.Add(this.ParameterSubscription[i]);
                        }

                        return parameterSubscriptionObjects;
                    }

                    var parameterSubscriptionNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < parameterSubscriptionUpperBound + 1; i++)
                    {
                        var queryResult = this.ParameterSubscription[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    parameterSubscriptionNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                parameterSubscriptionNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return parameterSubscriptionNextObjects;
                case "parametertype":
                    return base.QueryValue(pd.Input);
                case "scale":
                    return base.QueryValue(pd.Input);
                case "statedependence":
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
                case "group":
                    base.SetValue(pd.Input, value);
                    return;
                case "isoptiondependent":
                    base.SetValue(pd.Input, value);
                    return;
                case "owner":
                    base.SetValue(pd.Input, value);
                    return;
                case "parametersubscription":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ParameterSubscription.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ParameterSubscription parameterSubscriptionValue:
                            this.ParameterSubscription.Clear();
                            this.ParameterSubscription.Add(parameterSubscriptionValue);
                            return;
                        case IEnumerable<ParameterSubscription> parameterSubscriptionValues:
                            this.ParameterSubscription.Clear();
                            this.ParameterSubscription.AddRange(parameterSubscriptionValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterSubscription or a collection of ParameterSubscription" , nameof(value));
                    }
                case "parametertype":
                    base.SetValue(pd.Input, value);
                    return;
                case "scale":
                    base.SetValue(pd.Input, value);
                    return;
                case "statedependence":
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
