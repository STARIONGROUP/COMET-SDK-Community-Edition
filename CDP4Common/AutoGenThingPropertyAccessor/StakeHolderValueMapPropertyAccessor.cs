// ------------------------------------------------------------------------------------------------
// <copyright file="StakeHolderValueMapPropertyAccessor.cs" company="RHEA System S.A.">
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
    public partial class StakeHolderValueMap
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
                case "alias":
                    return base.QueryValue(pd.Input);
                case "category":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var categoryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && categoryUpperBound == int.MaxValue && !this.Category.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Category>();
                        }

                        var sentinelCategory = new Category(Guid.Empty, null, null);

                        return sentinelCategory.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        categoryUpperBound = this.Category.Count - 1;
                    }

                    if (this.Category.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Category property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Category.Count - 1 < categoryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Category property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Category[pd.Lower.Value];
                        }

                        return this.Category[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var categoryObjects = new List<Category>();

                        for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                        {
                            categoryObjects.Add(this.Category[i]);
                        }

                        return categoryObjects;
                    }

                    var categoryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < categoryUpperBound + 1; i++)
                    {
                        var queryResult = this.Category[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    categoryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                categoryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return categoryNextObjects;
                case "definition":
                    return base.QueryValue(pd.Input);
                case "goal":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var goalUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && goalUpperBound == int.MaxValue && !this.Goal.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Goal>();
                        }

                        var sentinelGoal = new Goal(Guid.Empty, null, null);

                        return sentinelGoal.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        goalUpperBound = this.Goal.Count - 1;
                    }

                    if (this.Goal.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Goal property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Goal.Count - 1 < goalUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Goal property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Goal[pd.Lower.Value];
                        }

                        return this.Goal[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var goalObjects = new List<Goal>();

                        for (var i = pd.Lower.Value; i < goalUpperBound + 1; i++)
                        {
                            goalObjects.Add(this.Goal[i]);
                        }

                        return goalObjects;
                    }

                    var goalNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < goalUpperBound + 1; i++)
                    {
                        var queryResult = this.Goal[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    goalNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                goalNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return goalNextObjects;
                case "hyperlink":
                    return base.QueryValue(pd.Input);
                case "name":
                    return base.QueryValue(pd.Input);
                case "requirement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var requirementUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && requirementUpperBound == int.MaxValue && !this.Requirement.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Requirement>();
                        }

                        var sentinelRequirement = new Requirement(Guid.Empty, null, null);

                        return sentinelRequirement.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        requirementUpperBound = this.Requirement.Count - 1;
                    }

                    if (this.Requirement.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Requirement property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Requirement.Count - 1 < requirementUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Requirement property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Requirement[pd.Lower.Value];
                        }

                        return this.Requirement[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var requirementObjects = new List<Requirement>();

                        for (var i = pd.Lower.Value; i < requirementUpperBound + 1; i++)
                        {
                            requirementObjects.Add(this.Requirement[i]);
                        }

                        return requirementObjects;
                    }

                    var requirementNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < requirementUpperBound + 1; i++)
                    {
                        var queryResult = this.Requirement[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    requirementNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                requirementNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return requirementNextObjects;
                case "settings":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var settingsUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && settingsUpperBound == int.MaxValue && !this.Settings.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<StakeHolderValueMapSettings>();
                        }

                        var sentinelStakeHolderValueMapSettings = new StakeHolderValueMapSettings(Guid.Empty, null, null);

                        return sentinelStakeHolderValueMapSettings.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        settingsUpperBound = this.Settings.Count - 1;
                    }

                    if (this.Settings.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Settings property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Settings.Count - 1 < settingsUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Settings property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Settings[pd.Lower.Value];
                        }

                        return this.Settings[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var settingsObjects = new List<StakeHolderValueMapSettings>();

                        for (var i = pd.Lower.Value; i < settingsUpperBound + 1; i++)
                        {
                            settingsObjects.Add(this.Settings[i]);
                        }

                        return settingsObjects;
                    }

                    var settingsNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < settingsUpperBound + 1; i++)
                    {
                        var queryResult = this.Settings[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    settingsNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                settingsNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return settingsNextObjects;
                case "shortname":
                    return base.QueryValue(pd.Input);
                case "stakeholdervalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var stakeholderValueUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && stakeholderValueUpperBound == int.MaxValue && !this.StakeholderValue.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<StakeholderValue>();
                        }

                        var sentinelStakeholderValue = new StakeholderValue(Guid.Empty, null, null);

                        return sentinelStakeholderValue.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        stakeholderValueUpperBound = this.StakeholderValue.Count - 1;
                    }

                    if (this.StakeholderValue.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for StakeholderValue property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.StakeholderValue.Count - 1 < stakeholderValueUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the StakeholderValue property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.StakeholderValue[pd.Lower.Value];
                        }

                        return this.StakeholderValue[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var stakeholderValueObjects = new List<StakeholderValue>();

                        for (var i = pd.Lower.Value; i < stakeholderValueUpperBound + 1; i++)
                        {
                            stakeholderValueObjects.Add(this.StakeholderValue[i]);
                        }

                        return stakeholderValueObjects;
                    }

                    var stakeholderValueNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < stakeholderValueUpperBound + 1; i++)
                    {
                        var queryResult = this.StakeholderValue[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    stakeholderValueNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                stakeholderValueNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return stakeholderValueNextObjects;
                case "valuegroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var valueGroupUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && valueGroupUpperBound == int.MaxValue && !this.ValueGroup.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ValueGroup>();
                        }

                        var sentinelValueGroup = new ValueGroup(Guid.Empty, null, null);

                        return sentinelValueGroup.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        valueGroupUpperBound = this.ValueGroup.Count - 1;
                    }

                    if (this.ValueGroup.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ValueGroup property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ValueGroup.Count - 1 < valueGroupUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ValueGroup property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ValueGroup[pd.Lower.Value];
                        }

                        return this.ValueGroup[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var valueGroupObjects = new List<ValueGroup>();

                        for (var i = pd.Lower.Value; i < valueGroupUpperBound + 1; i++)
                        {
                            valueGroupObjects.Add(this.ValueGroup[i]);
                        }

                        return valueGroupObjects;
                    }

                    var valueGroupNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < valueGroupUpperBound + 1; i++)
                    {
                        var queryResult = this.ValueGroup[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    valueGroupNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                valueGroupNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return valueGroupNextObjects;
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
                case "alias":
                    base.SetValue(pd.Input, value);
                    return;
                case "category":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Category.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Category categoryValue:
                            this.Category.Clear();
                            this.Category.Add(categoryValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Category.Clear();
                            this.Category.AddRange(thingValues.OfType<Category>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Category or a collection of Category" , nameof(value));
                    }
                case "definition":
                    base.SetValue(pd.Input, value);
                    return;
                case "goal":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Goal.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Goal goalValue:
                            this.Goal.Clear();
                            this.Goal.Add(goalValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Goal.Clear();
                            this.Goal.AddRange(thingValues.OfType<Goal>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Goal or a collection of Goal" , nameof(value));
                    }
                case "hyperlink":
                    base.SetValue(pd.Input, value);
                    return;
                case "name":
                    base.SetValue(pd.Input, value);
                    return;
                case "requirement":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Requirement.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case Requirement requirementValue:
                            this.Requirement.Clear();
                            this.Requirement.Add(requirementValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Requirement.Clear();
                            this.Requirement.AddRange(thingValues.OfType<Requirement>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a Requirement or a collection of Requirement" , nameof(value));
                    }
                case "settings":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.Settings.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case StakeHolderValueMapSettings settingsValue:
                            this.Settings.Clear();
                            this.Settings.Add(settingsValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.Settings.Clear();
                            this.Settings.AddRange(thingValues.OfType<StakeHolderValueMapSettings>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a StakeHolderValueMapSettings or a collection of StakeHolderValueMapSettings" , nameof(value));
                    }
                case "shortname":
                    base.SetValue(pd.Input, value);
                    return;
                case "stakeholdervalue":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.StakeholderValue.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case StakeholderValue stakeholderValueValue:
                            this.StakeholderValue.Clear();
                            this.StakeholderValue.Add(stakeholderValueValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.StakeholderValue.Clear();
                            this.StakeholderValue.AddRange(thingValues.OfType<StakeholderValue>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a StakeholderValue or a collection of StakeholderValue" , nameof(value));
                    }
                case "valuegroup":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    if(value == null)
                    {
                        this.ValueGroup.Clear();
                        return;
                    }

                    switch(value)
                    {
                        case ValueGroup valueGroupValue:
                            this.ValueGroup.Clear();
                            this.ValueGroup.Add(valueGroupValue);
                            return;
                        case IEnumerable<Thing> thingValues:
                            this.ValueGroup.Clear();
                            this.ValueGroup.AddRange(thingValues.OfType<ValueGroup>());
                            return;
                        default: 
                            throw new ArgumentException($"The provided value is a {value.GetType().Name}, expected a ValueGroup or a collection of ValueGroup" , nameof(value));
                    }
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }

        /// <summary>
        /// Queries the value of a Sentinel object
        /// </summary>
        /// <param name="path">
        /// The path of the property for which the value is to be queried
        /// </param>
        /// <param name="isCallerEmunerable">
        /// A value indicating whether the result is a single value or an enumeration
        /// </param>
        /// <returns>
        /// An object, which is either an instance or List of <see cref="Thing"/>
        /// or an bool, int, string or List thereof 
        /// </returns>
        internal object QuerySentinelValue(string path, bool isCallerEmunerable)
        {
            var pd = PropertyDescriptor.QueryPropertyDescriptor(path);

            var propertyName = pd.Name.ToLower();

            switch (propertyName)
            {
                case "iid":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<Guid>() : null;
                case "revisionnumber":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<int>() : null;
                case "classkind":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<ClassKind>() : null;
                case "excludeddomain":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "excludedperson":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();
                    return pd.Next == null ? (object) new List<DomainOfExpertise>() : new DomainOfExpertise(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "modifiedon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "thingpreference":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "actor":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new Person(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<Person>() : default(Person);
                case "alias":
                    return pd.Next == null ? (object) new List<Alias>() : new Alias(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "category":
                    return pd.Next == null ? (object) new List<Category>() : new Category(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "definition":
                    return pd.Next == null ? (object) new List<Definition>() : new Definition(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "goal":
                    return pd.Next == null ? (object) new List<Goal>() : new Goal(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "hyperlink":
                    return pd.Next == null ? (object) new List<HyperLink>() : new HyperLink(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "name":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "requirement":
                    return pd.Next == null ? (object) new List<Requirement>() : new Requirement(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "settings":
                    return pd.Next == null ? (object) new List<StakeHolderValueMapSettings>() : new StakeHolderValueMapSettings(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "shortname":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<string>() : null;
                case "stakeholdervalue":
                    return pd.Next == null ? (object) new List<StakeholderValue>() : new StakeholderValue(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "valuegroup":
                    return pd.Next == null ? (object) new List<ValueGroup>() : new ValueGroup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
