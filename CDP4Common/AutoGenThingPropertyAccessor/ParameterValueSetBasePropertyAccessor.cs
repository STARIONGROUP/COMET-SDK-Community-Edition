// ------------------------------------------------------------------------------------------------
// <copyright file="ParameterValueSetBasePropertyAccessor.cs" company="Starion Group S.A.">
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
    public partial class ParameterValueSetBase
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
                case "actualoption":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.ActualOption;
                    }

                    if (this.ActualOption != null)
                    {
                        return this.ActualOption.QueryValue(pd.Next.Input);
                    }

                    var sentinelactualoption = new Option(Guid.Empty, null, null);
                    return sentinelactualoption.QuerySentinelValue(pd.Next.Input, false);
                case "actualstate":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.ActualState;
                    }

                    if (this.ActualState != null)
                    {
                        return this.ActualState.QueryValue(pd.Next.Input);
                    }

                    var sentinelactualstate = new ActualFiniteState(Guid.Empty, null, null);
                    return sentinelactualstate.QuerySentinelValue(pd.Next.Input, false);
                case "actualvalue":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for ActualValue property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for ActualValue property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.ActualValue.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.ActualValue.Any())
                    {
                        return this.ActualValue.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.ActualValue.Count - 1;
                    }

                    if (this.ActualValue.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ActualValue property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.ActualValue.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ActualValue property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.ActualValue[pd.Lower.Value];
                    }

                    var actualValueObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        actualValueObjects.Add(this.ActualValue[i]);
                    }

                    return actualValueObjects;
                case "computed":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for Computed property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for Computed property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Computed.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.Computed.Any())
                    {
                        return this.Computed.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Computed.Count - 1;
                    }

                    if (this.Computed.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Computed property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Computed.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Computed property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Computed[pd.Lower.Value];
                    }

                    var computedObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        computedObjects.Add(this.Computed[i]);
                    }

                    return computedObjects;
                case "formula":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for Formula property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for Formula property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Formula.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.Formula.Any())
                    {
                        return this.Formula.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Formula.Count - 1;
                    }

                    if (this.Formula.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Formula property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Formula.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Formula property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Formula[pd.Lower.Value];
                    }

                    var formulaObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        formulaObjects.Add(this.Formula[i]);
                    }

                    return formulaObjects;
                case "manual":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for Manual property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for Manual property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Manual.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.Manual.Any())
                    {
                        return this.Manual.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Manual.Count - 1;
                    }

                    if (this.Manual.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Manual property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Manual.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Manual property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Manual[pd.Lower.Value];
                    }

                    var manualObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        manualObjects.Add(this.Manual[i]);
                    }

                    return manualObjects;
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.Owner;
                    }

                    if (this.Owner != null)
                    {
                        return this.Owner.QueryValue(pd.Next.Input);
                    }

                    var sentinelowner = new DomainOfExpertise(Guid.Empty, null, null);
                    return sentinelowner.QuerySentinelValue(pd.Next.Input, false);
                case "published":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for Published property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for Published property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Published.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.Published.Any())
                    {
                        return this.Published.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Published.Count - 1;
                    }

                    if (this.Published.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Published property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Published.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Published property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Published[pd.Lower.Value];
                    }

                    var publishedObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        publishedObjects.Add(this.Published[i]);
                    }

                    return publishedObjects;
                case "reference":
                    if (!pd.Lower.HasValue || !pd.Upper.HasValue)
                    {
                        throw new Exception("Invalid Multiplicity for Reference property, the lower and upper bound must be specified");
                    }
                    
                    if (!string.IsNullOrEmpty(pd.NextPath))
                    {
                        throw new ArgumentException($"Invalid nesting for Reference property");
                    }
                    
                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && !this.Reference.Any())
                    {
                        return new List<string>();
                    }

                    if (pd.Lower.Value == 0 && pd.Upper.Value == int.MaxValue && this.Reference.Any())
                    {
                        return this.Reference.ToList();
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        pd.Upper = this.Reference.Count - 1;
                    }

                    if (this.Reference.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Reference property, the lower bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (this.Reference.Count - 1 < pd.Upper.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Reference property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        return this.Reference[pd.Lower.Value];
                    }

                    var referenceObjects = new List<string>();

                    for (var i = pd.Lower.Value; i < pd.Upper.Value + 1; i++)
                    {
                        referenceObjects.Add(this.Reference[i]);
                    }

                    return referenceObjects;
                case "valueswitch":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return this.ValueSwitch;
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
                case "actualoption":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is Option actualOptionValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Option" , nameof(value));
                    }

                    this.ActualOption = actualOptionValue;
                    return;
                case "actualstate":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ActualFiniteState actualStateValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ActualFiniteState" , nameof(value));
                    }

                    this.ActualState = actualStateValue;
                    return;
                case "actualvalue":

                    if(value == null)
                    {
                        this.ActualValue = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string actualValueValue:
                            this.ActualValue = new ValueArray<string>(new List<string>{ actualValueValue });
                            return;
                        case IEnumerable<string> actualValueValues:
                            this.ActualValue = new ValueArray<string>(actualValueValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "computed":

                    if(value == null)
                    {
                        this.Computed = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string computedValue:
                            this.Computed = new ValueArray<string>(new List<string>{ computedValue });
                            return;
                        case IEnumerable<string> computedValues:
                            this.Computed = new ValueArray<string>(computedValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "formula":

                    if(value == null)
                    {
                        this.Formula = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string formulaValue:
                            this.Formula = new ValueArray<string>(new List<string>{ formulaValue });
                            return;
                        case IEnumerable<string> formulaValues:
                            this.Formula = new ValueArray<string>(formulaValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "manual":

                    if(value == null)
                    {
                        this.Manual = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string manualValue:
                            this.Manual = new ValueArray<string>(new List<string>{ manualValue });
                            return;
                        case IEnumerable<string> manualValues:
                            this.Manual = new ValueArray<string>(manualValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "owner":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is DomainOfExpertise ownerValue))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a DomainOfExpertise" , nameof(value));
                    }

                    this.Owner = ownerValue;
                    return;
                case "published":

                    if(value == null)
                    {
                        this.Published = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string publishedValue:
                            this.Published = new ValueArray<string>(new List<string>{ publishedValue });
                            return;
                        case IEnumerable<string> publishedValues:
                            this.Published = new ValueArray<string>(publishedValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "reference":

                    if(value == null)
                    {
                        this.Reference = new ValueArray<string>(this);
                        return;
                    }

                    switch(value)
                    {
                        case string referenceValue:
                            this.Reference = new ValueArray<string>(new List<string>{ referenceValue });
                            return;
                        case IEnumerable<string> referenceValues:
                            this.Reference = new ValueArray<string>(referenceValues);
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a string or a collection of string" , nameof(value));
                    }
                case "valueswitch":
                    pd.VerifyPropertyDescriptorForValueProperty();

                    if(value == null)
                    {
                        throw new ArgumentNullException(nameof(value), "The provided value cannot be null");
                    }

                    if(!(value is ParameterSwitchKind valueSwitchValue || (value is string valueSwitchString) && ParameterSwitchKind.TryParse(valueSwitchString, out valueSwitchValue)))
                    {
                        throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ParameterSwitchKind" , nameof(value));
                    }

                    this.ValueSwitch = valueSwitchValue;
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
