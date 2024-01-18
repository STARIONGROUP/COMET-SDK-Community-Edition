// ------------------------------------------------------------------------------------------------
// <copyright file="EngineeringModelPropertyAccessor.cs" company="RHEA System S.A.">
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

    /// <summary>
    /// Generated methods that support the QueryValue logic
    /// </summary>
    public partial class EngineeringModel
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
                case "book":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var bookUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && bookUpperBound == int.MaxValue && !this.Book.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Book>();
                        }

                        var sentinelBook = new Book(Guid.Empty, null, null);

                        return sentinelBook.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        bookUpperBound = this.Book.Count - 1;
                    }

                    if (this.Book.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Book property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Book.Count - 1 < bookUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Book property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Book[pd.Lower.Value];
                        }

                        return this.Book[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var bookObjects = new List<Book>();

                        for (var i = pd.Lower.Value; i < bookUpperBound + 1; i++)
                        {
                            bookObjects.Add(this.Book[i]);
                        }

                        return bookObjects;
                    }

                    var bookNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < bookUpperBound + 1; i++)
                    {
                        var queryResult = this.Book[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    bookNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                bookNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return bookNextObjects;
                case "commonfilestore":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var commonFileStoreUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && commonFileStoreUpperBound == int.MaxValue && !this.CommonFileStore.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<CommonFileStore>();
                        }

                        var sentinelCommonFileStore = new CommonFileStore(Guid.Empty, null, null);

                        return sentinelCommonFileStore.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        commonFileStoreUpperBound = this.CommonFileStore.Count - 1;
                    }

                    if (this.CommonFileStore.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for CommonFileStore property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.CommonFileStore.Count - 1 < commonFileStoreUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the CommonFileStore property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.CommonFileStore[pd.Lower.Value];
                        }

                        return this.CommonFileStore[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var commonFileStoreObjects = new List<CommonFileStore>();

                        for (var i = pd.Lower.Value; i < commonFileStoreUpperBound + 1; i++)
                        {
                            commonFileStoreObjects.Add(this.CommonFileStore[i]);
                        }

                        return commonFileStoreObjects;
                    }

                    var commonFileStoreNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < commonFileStoreUpperBound + 1; i++)
                    {
                        var queryResult = this.CommonFileStore[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    commonFileStoreNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                commonFileStoreNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return commonFileStoreNextObjects;
                case "engineeringmodelsetup":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next == null)
                    {
                        return this.EngineeringModelSetup;
                    }

                    if (this.EngineeringModelSetup != null)
                    {
                        return this.EngineeringModelSetup.QueryValue(pd.Next.Input);
                    }

                    var sentinelengineeringmodelsetup = new EngineeringModelSetup(Guid.Empty, null, null);
                    return sentinelengineeringmodelsetup.QuerySentinelValue(pd.Next.Input, false);
                case "genericnote":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var genericNoteUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && genericNoteUpperBound == int.MaxValue && !this.GenericNote.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<EngineeringModelDataNote>();
                        }

                        var sentinelEngineeringModelDataNote = new EngineeringModelDataNote(Guid.Empty, null, null);

                        return sentinelEngineeringModelDataNote.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        genericNoteUpperBound = this.GenericNote.Count - 1;
                    }

                    if (this.GenericNote.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for GenericNote property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.GenericNote.Count - 1 < genericNoteUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the GenericNote property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.GenericNote[pd.Lower.Value];
                        }

                        return this.GenericNote[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var genericNoteObjects = new List<EngineeringModelDataNote>();

                        for (var i = pd.Lower.Value; i < genericNoteUpperBound + 1; i++)
                        {
                            genericNoteObjects.Add(this.GenericNote[i]);
                        }

                        return genericNoteObjects;
                    }

                    var genericNoteNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < genericNoteUpperBound + 1; i++)
                    {
                        var queryResult = this.GenericNote[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    genericNoteNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                genericNoteNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return genericNoteNextObjects;
                case "iteration":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var iterationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && iterationUpperBound == int.MaxValue && !this.Iteration.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<Iteration>();
                        }

                        var sentinelIteration = new Iteration(Guid.Empty, null, null);

                        return sentinelIteration.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        iterationUpperBound = this.Iteration.Count - 1;
                    }

                    if (this.Iteration.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for Iteration property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.Iteration.Count - 1 < iterationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the Iteration property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.Iteration[pd.Lower.Value];
                        }

                        return this.Iteration[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var iterationObjects = new List<Iteration>();

                        for (var i = pd.Lower.Value; i < iterationUpperBound + 1; i++)
                        {
                            iterationObjects.Add(this.Iteration[i]);
                        }

                        return iterationObjects;
                    }

                    var iterationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < iterationUpperBound + 1; i++)
                    {
                        var queryResult = this.Iteration[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    iterationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                iterationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return iterationNextObjects;
                case "lastmodifiedon":
                    return base.QueryValue(pd.Input);
                case "logentry":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var logEntryUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && logEntryUpperBound == int.MaxValue && !this.LogEntry.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ModelLogEntry>();
                        }

                        var sentinelModelLogEntry = new ModelLogEntry(Guid.Empty, null, null);

                        return sentinelModelLogEntry.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        logEntryUpperBound = this.LogEntry.Count - 1;
                    }

                    if (this.LogEntry.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for LogEntry property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.LogEntry.Count - 1 < logEntryUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the LogEntry property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.LogEntry[pd.Lower.Value];
                        }

                        return this.LogEntry[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var logEntryObjects = new List<ModelLogEntry>();

                        for (var i = pd.Lower.Value; i < logEntryUpperBound + 1; i++)
                        {
                            logEntryObjects.Add(this.LogEntry[i]);
                        }

                        return logEntryObjects;
                    }

                    var logEntryNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < logEntryUpperBound + 1; i++)
                    {
                        var queryResult = this.LogEntry[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    logEntryNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                logEntryNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return logEntryNextObjects;
                case "modellingannotation":
                    pd.VerifyPropertyDescriptorForEnumerableReferenceProperty();

                    var modellingAnnotationUpperBound = pd.Upper.Value;

                    if (pd.Lower.Value == 0 && modellingAnnotationUpperBound == int.MaxValue && !this.ModellingAnnotation.Any())
                    {
                        if (pd.Next == null)
                        {
                            return new List<ModellingAnnotationItem>();
                        }

                        var sentinelModellingAnnotationItem = new ActionItem(Guid.Empty, null, null);

                        return sentinelModellingAnnotationItem.QuerySentinelValue(pd.NextPath, true);
                    }

                    if (pd.Upper.Value == int.MaxValue)
                    {
                        modellingAnnotationUpperBound = this.ModellingAnnotation.Count - 1;
                    }

                    if (this.ModellingAnnotation.Count - 1 < pd.Lower.Value)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for ModellingAnnotation property, the lower bound {pd.Lower.Value} is higher than the max index of this list.");
                    }

                    if (this.ModellingAnnotation.Count - 1 < modellingAnnotationUpperBound)
                    {
                        throw new IndexOutOfRangeException($"Invalid Multiplicity for the ModellingAnnotation property, the upper bound {pd.Upper.Value} is higher than the max index of this list.");
                    }

                    if (pd.Lower.Value == pd.Upper.Value)
                    {
                        if (pd.Next == null)
                        {
                            return this.ModellingAnnotation[pd.Lower.Value];
                        }

                        return this.ModellingAnnotation[pd.Lower.Value].QueryValue(pd.NextPath);
                    }

                    if (pd.Next == null)
                    {
                        var modellingAnnotationObjects = new List<ModellingAnnotationItem>();

                        for (var i = pd.Lower.Value; i < modellingAnnotationUpperBound + 1; i++)
                        {
                            modellingAnnotationObjects.Add(this.ModellingAnnotation[i]);
                        }

                        return modellingAnnotationObjects;
                    }

                    var modellingAnnotationNextObjects = new List<object>();

                    for (var i = pd.Lower.Value; i < modellingAnnotationUpperBound + 1; i++)
                    {
                        var queryResult = this.ModellingAnnotation[i].QueryValue(pd.Next.Input);

                        if (queryResult is IEnumerable<object> queriedValues)
                        {
                            foreach (var queriedValue in queriedValues)
                            {
                                if (queriedValue != null)
                                {
                                    modellingAnnotationNextObjects.Add(queriedValue);
                                }
                            }
                        }
                        else
                        {
                            if (queryResult != null)
                            {
                                modellingAnnotationNextObjects.Add(queryResult);
                            }
                        }
                    }

                    return modellingAnnotationNextObjects;
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
                case "book":
                    return pd.Next == null ? (object) new List<Book>() : new Book(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "commonfilestore":
                    return pd.Next == null ? (object) new List<CommonFileStore>() : new CommonFileStore(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "engineeringmodelsetup":
                    pd.VerifyPropertyDescriptorForReferenceProperty();

                    if (pd.Next != null)
                    {
                        return new EngineeringModelSetup(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                    }

                    return isCallerEmunerable ? (object) new List<EngineeringModelSetup>() : default(EngineeringModelSetup);
                case "genericnote":
                    return pd.Next == null ? (object) new List<EngineeringModelDataNote>() : new EngineeringModelDataNote(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "iteration":
                    return pd.Next == null ? (object) new List<Iteration>() : new Iteration(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "lastmodifiedon":
                    pd.VerifyPropertyDescriptorForValueProperty();
                    return isCallerEmunerable ? (object) new List<DateTime>() : null;
                case "logentry":
                    return pd.Next == null ? (object) new List<ModelLogEntry>() : new ModelLogEntry(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                case "modellingannotation":
                    return pd.Next == null ? (object) new List<ActionItem>() : new ActionItem(Guid.Empty, null, null).QuerySentinelValue(pd.Next.Input, true);
                default:
                    throw new ArgumentException($"The path:{path} does not exist on {this.ClassKind}");
            }
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
